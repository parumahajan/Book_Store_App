using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace Bookstore
    {
    public partial class ShowBooks : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
            {
            // ✅ 1. PAGE PROTECTION (VERY IMPORTANT)
            if (Session["JWT"] == null || Session["UserId"] == null)
                {
                Response.Redirect("Login.aspx");
                return;
                }

            if (!IsPostBack)
                {
                LoadBooks();
                }
            }

        private void LoadBooks()
            {
            using (OurBookStoreEntities db = new OurBookStoreEntities())
                {
                var books = db.Books
                    .Select(b => new
                        {
                        b.BookId,
                        b.BookName,
                        b.AuthorName,
                        b.Price
                        })
                    .ToList();

                gvBooks.DataSource = books;
                gvBooks.DataBind();
                }
            }

        protected void AddToCart_Click(object sender, EventArgs e)
            {
            int userId = Convert.ToInt32(Session["UserId"]);
            int bookId = Convert.ToInt32(((Button)sender).CommandArgument);

            using (OurBookStoreEntities db = new OurBookStoreEntities())
                {
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

                db.SaveChanges();
                }

            // ✅ Redirect after successful action
            Response.Redirect("Cart.aspx");
            }

        protected void AddToWishlist_Click(object sender, EventArgs e)
            {
            int userId = Convert.ToInt32(Session["UserId"]);
            int bookId = Convert.ToInt32(((Button)sender).CommandArgument);

            using (OurBookStoreEntities db = new OurBookStoreEntities())
                {
                bool exists = db.Wishlists
                    .Any(w => w.UserId == userId && w.BookId == bookId);

                if (!exists)
                    {
                    db.Wishlists.Add(new Wishlist
                        {
                        UserId = userId,
                        BookId = bookId
                        });

                    db.SaveChanges();
                    }
                }

            // ✅ Redirect after successful action
            Response.Redirect("Wishlist.aspx");
            }
        }
    }
