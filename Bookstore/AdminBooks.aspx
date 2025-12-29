<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="AdminBooks.aspx.cs"
    Inherits="Bookstore.Admin.AdminBooks" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Admin - Manage Books</title>
    <link href="adminbooks.css" rel="stylesheet" />
</head>
<body>
<form id="form1" runat="server">

<div class="admin-container">

    <h2>📘 Manage Books</h2>

    <!-- ADD / UPDATE FORM -->
    <asp:HiddenField ID="hfBookId" runat="server" />

    <asp:TextBox ID="txtBookName" runat="server" Placeholder="Book Name"></asp:TextBox>
    <asp:TextBox ID="txtAuthorName" runat="server" Placeholder="Author Name"></asp:TextBox>
    <asp:TextBox ID="txtPrice" runat="server" Placeholder="Price"></asp:TextBox>
    <asp:TextBox ID="txtStock" runat="server" Placeholder="Stock"></asp:TextBox>

    <br />

    <asp:Button ID="btnAdd" runat="server"
        Text="Add Book" OnClick="AddBook_Click" />

    <asp:Button ID="btnUpdate" runat="server"
        Text="Update Book" Visible="false"
        OnClick="UpdateBook_Click" />

    <asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label>

    <hr />

    <!-- BOOK LIST -->
    <asp:GridView ID="gvBooks" runat="server"
        AutoGenerateColumns="False">

        <Columns>
            <asp:BoundField DataField="BookName" HeaderText="Book" />
            <asp:BoundField DataField="AuthorName" HeaderText="Author" />
            <asp:BoundField DataField="Price" HeaderText="Price" />
            <asp:BoundField DataField="Stock" HeaderText="Stock" />

            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button Text="Edit" runat="server"
                        CommandArgument='<%# Eval("BookId") %>'
                        OnClick="Edit_Click" />

                    <asp:Button Text="Delete" runat="server"
                        CommandArgument='<%# Eval("BookId") %>'
                        OnClick="Delete_Click"
                        OnClientClick="return confirm('Delete this book?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</div>

</form>
</body>
</html>
