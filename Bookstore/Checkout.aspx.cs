using System;
using System.Linq;

namespace Bookstore
    {
    public partial class Checkout : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
            {
            if (Session["JWT"] == null || Session["UserId"] == null)
                {
                Response.Redirect("Login.aspx");
                return;
                }

            if (!IsPostBack)
                {
                LoadCheckout();
                }
            }

        private void LoadCheckout()
            {
            int userId = Convert.ToInt32(Session["UserId"]);

            using (OurBookStoreEntities db = new OurBookStoreEntities())
                {
                var cart = (from c in db.Carts
                            join b in db.Books on c.BookId equals b.BookId
                            where c.UserId == userId
                            select new
                                {
                                b.BookName,
                                b.Price,
                                c.Quantity,
                                Total = b.Price * c.Quantity
                                }).ToList();

                gvCheckout.DataSource = cart;
                gvCheckout.DataBind();

                lblGrandTotal.Text = "Grand Total: ₹" + cart.Sum(x => x.Total);
                }
            }

        protected void PlaceOrder_Click(object sender, EventArgs e)
            {
            int userId = Convert.ToInt32(Session["UserId"]);

            using (OurBookStoreEntities db = new OurBookStoreEntities())
            using (var tx = db.Database.BeginTransaction())
                {
                try
                    {
                    var cartItems = db.Carts
                        .Where(c => c.UserId == userId)
                        .ToList();

                    if (!cartItems.Any())
                        return;

                    decimal totalAmount = (from c in cartItems
                                           join b in db.Books on c.BookId equals b.BookId
                                           select b.Price * c.Quantity).Sum();

                    // 1️⃣ Create Order
                    Order order = new Order
                        {
                        UserId = userId,
                        TotalAmount = totalAmount,
                        OrderStatus = "Placed",
                        CreatedAt = DateTime.Now
                        };

                    db.Orders.Add(order);
                    db.SaveChanges();

                    // 2️⃣ Create OrderItems
                    foreach (var item in cartItems)
                        {
                        decimal price = db.Books
                            .Where(b => b.BookId == item.BookId)
                            .Select(b => b.Price)
                            .First();

                        db.OrderItems.Add(new OrderItem
                            {
                            OrderId = order.OrderId,
                            BookId = item.BookId,
                            Quantity = item.Quantity,
                            Price = price
                            });
                        }

                    // 3️⃣ Clear Cart
                    db.Carts.RemoveRange(cartItems);

                    db.SaveChanges();
                    tx.Commit();

                    Response.Redirect("Orders.aspx");
                    }
                catch
                    {
                    tx.Rollback();
                    }
                }
            }
        }
    }
