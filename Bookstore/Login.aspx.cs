using System;
using System.Linq;
using System.Web;
using BCrypt.Net;

namespace Bookstore
    {
    public partial class Login : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
            {
            }

        protected void LoginClickHandler(object sender, EventArgs e)
            {
            string email_f = emailText.Text.Trim();
            string password_f = passwordText.Text;

            using (OurBookStoreEntities ourBookStore = new OurBookStoreEntities())
                {
                var user = ourBookStore.UserInfoes
                    .FirstOrDefault(u => u.Email == email_f);

                if (user != null && BCrypt.Net.BCrypt.Verify(password_f, user.PasswordHash))
                    {
                    // ✅ 1. Store UserId in Session (CRITICAL)
                    Session["UserId"] = user.UserId;

                    // ✅ 2. Mark user as logged in
                    Session["JWT"] = true;

                    // ✅ 3. Create cookie (optional but allowed)
                    HttpCookie cookie_jwt = new HttpCookie("JWT", email_f)
                        {
                        HttpOnly = true,
                        Secure = false, // set TRUE only if HTTPS
                        SameSite = SameSiteMode.Strict,
                        Expires = DateTime.Now.AddHours(1)
                        };

                    Response.Cookies.Add(cookie_jwt);

                    // ✅ 4. Redirect to Show Books
                    Response.Redirect("ShowBooks.aspx");
                    }
                else
                    {
                    lblMessage.Text = "Invalid email or password.";
                    }
                }
            }
        }
    }
