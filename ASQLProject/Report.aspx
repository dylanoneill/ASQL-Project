<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="ASQLProject.Report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Prestige YoYo</title>
</head>
<body style="background-color:lightgrey">
    <h1 style="color:white; background-color:cadetblue; font-family:Arial;">&nbsp;Reports</h1>
    <form id="reportForm" runat="server">
        <div>
            <asp:Button Text="First Time Yield Report" runat="server" OnClick="FirstYieldClicked" Height="26px" Width="201px" />
            <br />
            <br />
            <asp:Button Text="Final Yield Report" runat="server" OnClick="FinalYieldClicked" Width="201px" />
            <br />
            <br />
            <asp:Button Text="Defect Pareto Diagrams" runat="server" OnClick="DefectParetoClicked" Width="201px" />
        </div>
    </form>
</body>
</html>
