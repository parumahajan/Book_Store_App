<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Bookstore.Registration" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <link href="CSS/registration.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="register-box">

            <h2>Create Account</h2>

            <asp:Label runat="server" Text="Full Name"></asp:Label>
            <asp:TextBox ID="FullNameText" runat="server" Placeholder="Enter full name"></asp:TextBox>

            <asp:Label runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="EmailText" runat="server" TextMode="Email" Placeholder="Enter email"></asp:TextBox>

            <asp:Label runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="PasswordText" runat="server" TextMode="Password" Placeholder="Enter password"></asp:TextBox>

            <asp:Button ID="RegisterBtn" runat="server" Text="Register" OnClick="RegisterClickHandler" />

            <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>

        </div>
    </form>
</body>
</html>
