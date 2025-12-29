using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace Bookstore
    {
    public partial class WishlistPage : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
            {
            // 🔒 Page protection
            if (Session["JWT"] == null || Session["UserId"] == null)
                {
                Response.Redirect("Login.aspx");
                return;
                }

            if (!IsPostBack)
                {
                LoadWishlist();
                }
            }

        private void LoadWishlist()
            {
            int userId = Convert.ToInt32(Session["UserId"]);

            using (OurBookStoreEntities db = new OurBookStoreEntities())
                {
                var wishlist = (from w in db.Wishlists
                                join b in db.Books on w.BookId equals b.BookId
                                where w.UserId == userId
                                select new
                                    {
                                    b.BookId,
                                    b.BookName,
                                    b.AuthorName,
                                    b.Price
                                    }).ToList();

                gvWishlist.DataSource = wishlist;
                gvWishlist.DataBind();
                }
            }

        protected void AddToCart_Click(object sender, EventArgs e)
            {
            int userId = Convert.ToInt32(Session["UserId"]);
            int bookId = Convert.ToInt32(((Button)sender).CommandArgument);

            using (OurBookStoreEntities db = new OurBookStoreEntities())
                {
                // Add to Cart (same logic as ShowBooks)
                var cartItem = db.Carts
                    .FirstOrDefault(c => c.UserId == userId && c.BookId == bookId);

                if (cartItem != null)
                    {
                    cartItem.Quantity += 1;
                    }
                else
                    {
                    db.Carts.Add(new Cart
                        {
                        UserId = userId,
                        BookId = bookId,
                        Quantity = 1
                        });
                    }

                // Remove from Wishlist after adding to cart
                var wishItem = db.Wishlists
                    .FirstOrDefault(w => w.UserId == userId && w.BookId == bookId);

                if (wishItem != null)
                    {
                    db.Wishlists.Remove(wishItem);
                    }

                db.SaveChanges();
                }

            LoadWishlist(); // refresh grid
            }

        protected void Remove_Click(object sender, EventArgs e)
            {
            int userId = Convert.ToInt32(Session["UserId"]);
            int bookId = Convert.ToInt32(((Button)sender).CommandArgument);

            using (OurBookStoreEntities db = new OurBookStoreEntities())
                {
                var wishItem = db.Wishlists
                    .FirstOrDefault(w => w.UserId == userId && w.BookId == bookId);

                if (wishItem != null)
                    {
                    db.Wishlists.Remove(wishItem);
                    db.SaveChanges();
                    }
                }

            LoadWishlist();
            }
        }
    }
