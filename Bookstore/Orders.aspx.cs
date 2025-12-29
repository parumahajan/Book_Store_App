using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace Bookstore
    {
    public partial class OrdersPage : System.Web.UI.Page
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
                LoadOrders();
                }
            }

        private void LoadOrders()
            {
            int userId = Convert.ToInt32(Session["UserId"]);

            using (OurBookStoreEntities db = new OurBookStoreEntities())
                {
                var orders = db.Orders
                    .Where(o => o.UserId == userId)
                    .OrderByDescending(o => o.CreatedAt)
                    .ToList();

                gvOrders.DataSource = orders;
                gvOrders.DataBind();
                }
            }

        protected void ViewDetails_Click(object sender, EventArgs e)
            {
            int orderId = Convert.ToInt32(((Button)sender).CommandArgument);
            Response.Redirect("OrderDetails.aspx?orderId=" + orderId);
            }
        }
    }
