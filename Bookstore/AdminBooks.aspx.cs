using System;
using System.Linq;

namespace Bookstore.Admin
    {
    public partial class AdminBooks : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
            {
            // 🔒 Admin protection
            if (Session["Role"] == null || Session["Role"].ToString() != "Admin")
                {
                Response.Redirect("Admin/Login.aspx");
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
                gvBooks.DataSource = db.Books.ToList();
                gvBooks.DataBind();
                }
            }

        // 🟢 CREATE
        protected void AddBook_Click(object sender, EventArgs e)
            {
            using (OurBookStoreEntities db = new OurBookStoreEntities())
                {
                Book book = new Book
                    {
                    BookName = txtBookName.Text.Trim(),
                    AuthorName = txtAuthorName.Text.Trim(),
                    Price = Convert.ToDecimal(txtPrice.Text),
                    Stock = Convert.ToInt32(txtStock.Text),
                    CreatedAt = DateTime.Now
                    };

                db.Books.Add(book);
                db.SaveChanges();
                }

            ClearForm();
            LoadBooks();
            lblMessage.Text = "Book added successfully.";
            }

        // 🟡 LOAD FOR EDIT
        protected void Edit_Click(object sender, EventArgs e)
            {
            int bookId = Convert.ToInt32(((System.Web.UI.WebControls.Button)sender).CommandArgument);

            using (OurBookStoreEntities db = new OurBookStoreEntities())
                {
                Book book = db.Books.Find(bookId);

                if (book != null)
                    {
                    hfBookId.Value = book.BookId.ToString();
                    txtBookName.Text = book.BookName;
                    txtAuthorName.Text = book.AuthorName;
                    txtPrice.Text = book.Price.ToString();
                    txtStock.Text = book.Stock.ToString();

                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    }
                }
            }

        // 🔵 UPDATE
        protected void UpdateBook_Click(object sender, EventArgs e)
            {
            int bookId = Convert.ToInt32(hfBookId.Value);

            using (OurBookStoreEntities db = new OurBookStoreEntities())
                {
                Book book = db.Books.Find(bookId);

                if (book != null)
                    {
                    book.BookName = txtBookName.Text.Trim();
                    book.AuthorName = txtAuthorName.Text.Trim();
                    book.Price = Convert.ToDecimal(txtPrice.Text);
                    book.Stock = Convert.ToInt32(txtStock.Text);

                    db.SaveChanges();
                    }
                }

            ClearForm();
            LoadBooks();
            lblMessage.Text = "Book updated successfully.";
            }

        // 🔴 DELETE
        protected void Delete_Click(object sender, EventArgs e)
            {
            int bookId = Convert.ToInt32(((System.Web.UI.WebControls.Button)sender).CommandArgument);

            using (OurBookStoreEntities db = new OurBookStoreEntities())
                {
                Book book = db.Books.Find(bookId);

                if (book != null)
                    {
                    db.Books.Remove(book);
                    db.SaveChanges();
                    }
                }

            LoadBooks();
            lblMessage.Text = "Book deleted.";
            }

        private void ClearForm()
            {
            txtBookName.Text = "";
            txtAuthorName.Text = "";
            txtPrice.Text = "";
            txtStock.Text = "";

            btnAdd.Visible = true;
            btnUpdate.Visible = false;
            hfBookId.Value = "";
            }
        }
    }
