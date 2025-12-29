using System;

namespace Bookstore
    {
    public partial class _Default : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
            {
            // 🔒 If user already logged in → redirect to ShowBooks
            if (Session["JWT"] != null && Session["UserId"] != null)
                {
                Response.Redirect("ShowBooks.aspx");
                }
            }

        protected void btnLogin_Click(object sender, EventArgs e)
            {
            Response.Redirect("Login.aspx");
            }

        protected void btnRegister_Click(object sender, EventArgs e)
            {
            Response.Redirect("Registration.aspx");
            }
        }
    }
