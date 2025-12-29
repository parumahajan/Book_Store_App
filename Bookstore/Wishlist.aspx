<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Wishlist.aspx.cs" Inherits="Bookstore.WishlistPage" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>My Wishlist</title>
</head>
<body>
<form id="form1" runat="server">

    <h2>My Wishlist</h2>

    <asp:GridView ID="gvWishlist" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="BookName" HeaderText="Book" />
            <asp:BoundField DataField="AuthorName" HeaderText="Author" />
            <asp:BoundField DataField="Price" HeaderText="Price" />

            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>

                    <asp:Button Text="Add to Cart" runat="server"
                        CommandArgument='<%# Eval("BookId") %>'
                        OnClick="AddToCart_Click" />

                    &nbsp;

                    <asp:Button Text="Remove" runat="server"
                        CommandArgument='<%# Eval("BookId") %>'
                        OnClick="Remove_Click" />

                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</form>
</body>
</html>
