<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="Bookstore.OrdersPage" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>My Orders</title>
    <link href="CSS/orders.css" rel="stylesheet" />
</head>
<body>
<form id="form1" runat="server">

    <h2>My Orders</h2>

    <asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="False" CssClass="grid"
> 
        <Columns>
            <asp:BoundField DataField="OrderId" HeaderText="Order #" />
            <asp:BoundField DataField="TotalAmount" HeaderText="Amount" />
            <asp:BoundField DataField="OrderStatus" HeaderText="Status" />
            <asp:BoundField DataField="CreatedAt" HeaderText="Date" />

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button Text="View Details" runat="server"
                        CommandArgument='<%# Eval("OrderId") %>'
                        OnClick="ViewDetails_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</form>
</body>
</html>
