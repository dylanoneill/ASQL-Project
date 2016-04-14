<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="ASQLProject.Scehdule" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Prestige YoYo</title>
</head>
<body style="background-color:lightgrey">
    <h1 style="color:white; background-color:cadetblue; font-family:Arial;">&nbsp;Schedule</h1>
    <form id="scheduleForm" runat="server">
    <div>
    
        <asp:Label ID="startDateLabel" runat="server" Text="Start Date (YYYY-MM-DD)"></asp:Label>
        <br />
        <asp:TextBox ID="startDateTextBox" runat="server" Width="174px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="startTimeLabel" runat="server" Text="Start Time (HH:MM:SS)"></asp:Label>
        <br />
        <asp:TextBox ID="startTimeTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="endTimeLabel" runat="server" Text="End Time (HH:MM:SS)"></asp:Label>
        <br />
        <asp:TextBox ID="endTimeTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="skuLabel" runat="server" Text="SKU"></asp:Label>
        <br />
        <asp:DropDownList ID="skuDropBox" runat="server" Height="16px" Width="115px">
            <asp:ListItem Selected="True">Y001-1</asp:ListItem>
            <asp:ListItem>Y001-2</asp:ListItem>
            <asp:ListItem>Y001-3</asp:ListItem>
            <asp:ListItem>Y002-0</asp:ListItem>
            <asp:ListItem>Y005-1</asp:ListItem>
            <asp:ListItem>Y005-2</asp:ListItem>
            <asp:ListItem>Y005-3</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="UpdateButton" runat="server" OnClick="UpdateButton_Click" Text="Update" />
        <br />
        <br />
        <asp:Label ID="errorLabel" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
