<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowBooks.aspx.cs" Inherits="Bookstore.ShowBooks" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Show Books</title>
    <link href="CSS/showbooks.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView 
                ID="gvBooks" 
                runat="server" 
                AutoGenerateColumns="False" CssClass="grid">

                <Columns>
                    <asp:BoundField DataField="BookName" HeaderText="Book" />
                    <asp:BoundField DataField="AuthorName" HeaderText="Author" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />

                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button 
                                Text="Add to Cart" 
                                runat="server"
                                CommandArgument='<%# Eval("BookId") %>'
                                OnClick="AddToCart_Click" />

                            &nbsp;

                            <asp:Button 
                                Text="Wishlist" 
                                runat="server"
                                CommandArgument='<%# Eval("BookId") %>'
                                OnClick="AddToWishlist_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
        </div>
    </form>
</body>
</html>
