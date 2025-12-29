using System;
using System.Linq;

namespace Bookstore
    {
    public partial class OrderDetailsPage : System.Web.UI.Page
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
                int orderId = Convert.ToInt32(Request.QueryString["orderId"]);
                LoadOrderItems(orderId);
                }
            }

        private void LoadOrderItems(int orderId)
            {
            using (OurBookStoreEntities db = new OurBookStoreEntities())
                {
                var items = (from oi in db.OrderItems
                             join b in db.Books on oi.BookId equals b.BookId
                             where oi.OrderId == orderId
                             select new
                                 {
                                 b.BookName,
                                 oi.Price,
                                 oi.Quantity,
                                 Total = oi.Price * oi.Quantity
                                 }).ToList();

                gvOrderItems.DataSource = items;
                gvOrderItems.DataBind();
                }
            }
        }
    }
