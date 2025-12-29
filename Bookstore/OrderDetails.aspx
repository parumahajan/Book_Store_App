<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderDetails.aspx.cs" Inherits="Bookstore.OrderDetailsPage" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Order Details</title>
    <link href="CSS/orders.css" rel="stylesheet" />
</head>
<body>
<form id="form1" runat="server">

    <h2>Order Details</h2>

    <asp:GridView ID="gvOrderItems" runat="server" AutoGenerateColumns="False" CssClass="grid"
>
        <Columns>
            <asp:BoundField DataField="BookName" HeaderText="Book" />
            <asp:BoundField DataField="Price" HeaderText="Price" />
            <asp:BoundField DataField="Quantity" HeaderText="Qty" />
            <asp:BoundField DataField="Total" HeaderText="Total" />
        </Columns>
    </asp:GridView>

</form>
</body>
</html>
