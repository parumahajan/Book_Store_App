<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Bookstore.Checkout" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Checkout</title>
    <link href="CSS/checkout.css" rel="stylesheet" />
</head>
<body>
<form id="form1" runat="server">

    <h2>Checkout</h2>

    <asp:GridView ID="gvCheckout" runat="server" AutoGenerateColumns="False" CssClass="grid"
>
        <Columns>
            <asp:BoundField DataField="BookName" HeaderText="Book" />
            <asp:BoundField DataField="Price" HeaderText="Price" />
            <asp:BoundField DataField="Quantity" HeaderText="Qty" />
            <asp:BoundField DataField="Total" HeaderText="Total" />
        </Columns>
    </asp:GridView>

    <br />
    <asp:Label ID="lblGrandTotal" runat="server" Font-Bold="true"></asp:Label>
    <br /><br />

    <asp:Button Text="Place Order" runat="server" OnClick="PlaceOrder_Click" />

</form>
</body>
</html>
