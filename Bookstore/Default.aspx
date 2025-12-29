<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Bookstore._Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bookstore - Home</title>
    <link href="CSS/default.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center; margin-top:100px;">

            <h1>📚 Welcome to Bookstore</h1>
            <p>Your one-stop destination for books</p>

            <br /><br />

            <asp:Button 
                ID="btnLogin" 
                runat="server" 
                Text="Login"
                Width="120px"
                OnClick="btnLogin_Click" />

            &nbsp;&nbsp;

            <asp:Button 
                ID="btnRegister" 
                runat="server" 
                Text="Register"
                Width="120px"
                OnClick="btnRegister_Click" />

        </div>
    </form>
</body>
</html>
