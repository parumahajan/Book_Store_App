<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Bookstore.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CSS/login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Login</h1>
            <%--email--%>
          
            <asp:Label ID="emailLabel" runat="server">EMAIL</asp:Label>
            <asp:TextBox ID="emailText" runat="server" Placeholder="Enter your email" TextMode="Email"></asp:TextBox>

            <br />
            <%-- password --%>
            <asp:Label ID="passwordLabel" runat="server">PASSWORD</asp:Label>
            <asp:TextBox ID ="passwordText" runat="server" Placeholder ="Enter your password" TextMode="Password"></asp:TextBox>
            
            <br />
            <%-- Login Button --%>
            <asp:Button ID="LoginBtn" OnClick="LoginClickHandler" runat="server" Text="Login"/>

            <asp:Label ID="lblMessage" runat="server"></asp:Label>


        </div>
    </form>
</body>
</html>
