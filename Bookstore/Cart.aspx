<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Bookstore.CartPage" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>My Cart</title>
    <link href="CSS/cart.css" rel="stylesheet" />
</head>
<body>
<form id="form1" runat="server">
    <h2>My Cart</h2>

    <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False" CssClass="grid"
>
        <Columns>
            <asp:BoundField DataField="BookName" HeaderText="Book" />
            <asp:BoundField DataField="Price" HeaderText="Price" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="Total" HeaderText="Total" />

            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button Text="+" runat="server"
                        CommandArgument='<%# Eval("BookId") %>'
                        OnClick="IncreaseQty_Click" />

                    <asp:Button Text="-" runat="server"
                        CommandArgument='<%# Eval("BookId") %>'
                        OnClick="DecreaseQty_Click" />

                    <asp:Button Text="Remove" runat="server"
                        CommandArgument='<%# Eval("BookId") %>'
                        OnClick="Remove_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <br />

    <asp:Label ID="lblGrandTotal" runat="server" Font-Bold="true"></asp:Label>
    <br /><br />

    <asp:Button Text="Place Order" runat="server" OnClick="PlaceOrder_Click" />

</form>
</body>
</html>
