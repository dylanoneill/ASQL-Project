<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ASQLProject.Login" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Prestige YoYo</title>
</head>
<body style="background-color:lightgrey">
    <h1 style="color:white; background-color:cadetblue; font-family:Arial;">&nbsp;Login</h1>
    <form id="loginForm" runat="server">
    <div>
        <p>
            Username: <asp:TextBox ID="usernameTextBox" runat="server" />
        </p>
        <p>
            Password: <asp:TextBox ID="passwordTextBox" runat="server" />
        </p>
        <asp:Button Text="Login" runat="server" OnClick="LoginClicked" style="margin-left: 0px" Width="50px" />
        <br />
    </div>
        <br />
        <br />
        <asp:Label ID="errorLogin" runat="server"></asp:Label>
    </form>
</body>
</html>
