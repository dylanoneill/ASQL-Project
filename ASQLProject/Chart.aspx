<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chart.aspx.cs" Inherits="ASQLProject.Chart" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Prestige YoYo</title>
</head>
<body style="background-color:lightgrey"> 
    <form id="chartForm" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <p>Filter By:<asp:DropDownList ID="filterDropdown" runat="server" style="margin-left: 7px" OnSelectedIndexChanged="filterDropdown_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Text="Date" Value="0" />
                    <asp:ListItem Text="Colour" Value="1" />
                    <asp:ListItem Text="Product" Value="2" />
                    <asp:ListItem Text="Defect" Value="3" />
                    </asp:DropDownList>
                    </p>
                </td>
            </tr>
            <tr id="trDate" runat="server">
                <td>
                    <asp:Label Text="From:" runat="server" />
                    <asp:TextBox ID="startDateTextbox" runat="server" />
                    <asp:Label Text="To:" runat="server" />
                    <asp:TextBox ID="endDateTextbox" runat="server" />
                </td>
            </tr>
            <tr id="trColour" runat="server">
                <td>
                    <asp:Label Text="Colour:" runat="server" />
                    <asp:DropDownList ID="colourDropdown" runat="server">
                        <asp:ListItem Text="Red" Value="0" />
                        <asp:ListItem Text="Blue" Value="1" />
                        <asp:ListItem Text="Green" Value="2" />
                        <asp:ListItem Text="Clear" Value="3" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="trProduct" runat="server">
                <td>
                    <asp:Label Text="Product:" runat="server" />
                    <asp:DropDownList ID="productDropdown" runat="server">
                        <asp:ListItem Text="Prestige Classic" Value="0" />
                        <asp:ListItem Text="Clear Plastic" Value="1" />
                        <asp:ListItem Text="Whistler" Value="2" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="trDefect" runat="server">
                <td>
                    <asp:Label Text="Defect:" runat="server" />
                    <asp:DropDownList ID="defectDropdown" runat="server">

                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
        <asp:Chart ID="reportChart" runat="server" EnableViewState="True" Width="541px" Style="background-color:lightgrey">
            <series>
                <asp:Series Name="reportChartSeries">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="reportChartArea">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
        <asp:GridView ID="tableGridview" runat="server" AutoGenerateColumns="true" />
    </form>
</body>
</html>
