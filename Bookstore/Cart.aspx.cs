using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace Bookstore
    {
    public partial class CartPage : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
            {
            if (Session["UserId"] == null)
                {
                Response.Redirect("Login.aspx");
                return;
                }

            if (!IsPostBack)
                {
                LoadCart();
                }
            }

        private void LoadCart()
            {
            int userId = Convert.ToInt32(Session["UserId"]);

            using (OurBookStoreEntities db = new OurBookStoreEntities())
                {
                var cart = (from c in db.Carts
                            join b in db.Books on c.BookId equals b.BookId
                            where c.UserId == userId
                            select new
                                {
                                b.BookId,
                                b.BookName,
                                b.Price,
                                c.Quantity,
                                Total = b.Price * c.Quantity
                                }).ToList();

                gvCart.DataSource = cart;
                gvCart.DataBind();

                lblGrandTotal.Text = "Grand Total: ₹" +
                    cart.Sum(x => x.Total).ToString();
                }
            }

        protected void IncreaseQty_Click(object sender, EventArgs e)
            {
            UpdateQuantity(sender, +1);
            }

        protected void DecreaseQty_Click(object sender, EventArgs e)
            {
            UpdateQuantity(sender, -1);
            }

        private void UpdateQuantity(object sender, int change)
            {
            int userId = Convert.ToInt32(Session["UserId"]);
            int bookId = Convert.ToInt32(((Button)sender).CommandArgument);

            using (OurBookStoreEntities db = new OurBookStoreEntities())
                {
                var item = db.Carts
                    .FirstOrDefault(c => c.UserId == userId && c.BookId == bookId);

                if (item != null)
                    {
                    item.Quantity += change;

                    if (item.Quantity <= 0)
                        db.Carts.Remove(item);

                    db.SaveChanges();
                    }
                }

            LoadCart();
            }

        protected void Remove_Click(object sender, EventArgs e)
            {
            int userId = Convert.ToInt32(Session["UserId"]);
            int bookId = Convert.ToInt32(((Button)sender).CommandArgument);

            using (OurBookStoreEntities db = new OurBookStoreEntities())
                {
                var item = db.Carts
                    .FirstOrDefault(c => c.UserId == userId && c.BookId == bookId);

                if (item != null)
                    {
                    db.Carts.Remove(item);
                    db.SaveChanges();
                    }
                }

            LoadCart();
            }

        protected void PlaceOrder_Click(object sender, EventArgs e)
            {
            Response.Redirect("Checkout.aspx");
            }
        }
    }
