using System;
using System.Linq;

namespace Bookstore
    {
    public partial class Registration : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
            {
            }

        protected void RegisterClickHandler(object sender, EventArgs e)
            {
            string fullName = FullNameText.Text.Trim();
            string email = EmailText.Text.Trim();
            string password = PasswordText.Text;

            // 🔒 Basic validation
            if (string.IsNullOrEmpty(fullName) ||
                string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password))
                {
                lblMessage.Text = "All fields are required.";
                return;
                }

            if (password.Length < 6)
                {
                lblMessage.Text = "Password must be at least 6 characters long.";
                return;
                }

            using (OurBookStoreEntities db = new OurBookStoreEntities())
                {
                // ❌ Prevent duplicate email
                bool emailExists = db.UserInfoes.Any(u => u.Email == email);
                if (emailExists)
                    {
                    lblMessage.Text = "Email already registered.";
                    return;
                    }

                // 🔐 Hash password
                string hashPassword = BCrypt.Net.BCrypt.HashPassword(password);

                UserInfo user = new UserInfo
                    {
                    UserName = fullName,
                    Email = email,
                    PasswordHash = hashPassword,
                    CreatedAt = DateTime.Now
                    };

                db.UserInfoes.Add(user);
                db.SaveChanges();

                Response.Redirect("Login.aspx");
                }
            }
        }
    }
