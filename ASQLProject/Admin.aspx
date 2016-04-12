<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="ASQLProject.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:lightgrey"> 
    <h1 style="color:white; background-color:cadetblue; font-family:Arial;">&nbsp;Administration</h1>
    <form id="adminForm" runat="server">
    <div>
          <table style="margin-bottom: 0px">
              <tr>
                  <td>
                    <asp:Button Text="Generate Reports" ID="reportButton" OnClick="reportButton_Click" runat="server" Width="201px" CausesValidation="False" />
                    <br />
                    <br />
                    <asp:Button Text="Change Schedule" runat="server" Height="26px" Width="201px" CausesValidation="False" />
                    <br />
                    <br />
                    <asp:Button Text="Add Product" ID="createProductButton" runat="server" OnClick="createProductButton_Click" Width="201px" CausesValidation="False" />
                    <br />
                    <br />
                    <asp:Button Text="Create New User" ID="createUserButton" runat="server" OnClick="createUserButton_Click" Width="201px" CausesValidation="False" />
                  </td>           
                  <td />
                  <td />
                  <td id="tdCreateUser" runat="server">
                    <p>Username: <asp:TextBox ID="usernameTextbox" runat="server" />
                    <asp:RequiredFieldValidator 
                        ControlToValidate="usernameTextbox"
                        Text="Username cannot be blank."
                        runat="server" /></p>

                    <p>Password: <asp:TextBox ID="passwordTextbox" runat="server" TextMode="Password" /> 
                    <asp:RequiredFieldValidator 
                        ControlToValidate="passwordTextbox"
                        Text="Password Is required."
                        runat="server" /></p>

                    <p>Confirm: <asp:TextBox ID="confirmTextbox" runat="server" TextMode="Password" />     
                    <asp:RequiredFieldValidator 
                        ControlToValidate="confirmTextbox"
                        Text="You must confirm your password."
                        runat="server" /></p>

                    <p>Admin: <asp:CheckBox ID="adminCheckbox" runat="server" /></p>
                    <asp:Button Text="Create" ID="addUserButton" runat="server" OnClick="addUserButton_Click"/>
                    <asp:Label ID="userFbLabel" runat="server" />      
                  </td>
                  <td id="tdCreateProduct" runat="server" >
                      <p>SKU: <asp:TextBox ID="skuTextbox" runat="server" />
                          <asp:RequiredFieldValidator
                              ControlToValidate="skuTextbox"
                              Text="You must enter an SKU."
                              runat="server" /></p>
                      <p>Description: <asp:TextBox ID="descTextbox" runat="server" />
                          <asp:RequiredFieldValidator
                              ControlToValidate="descTextbox"
                              Text="Description Required."
                              runat="server" /></p>
                      <p>Colour: <asp:DropDownList ID="colourDropdown" runat="server">                               
                                    <asp:ListItem Text="Blue" Value="Blue" />
                                    <asp:ListItem Text="Green" Value="Green" />
                                    <asp:ListItem Text="Red" Value="Red" />
                                    <asp:ListItem Text="Clear" Value="Clear" />
                                 </asp:DropDownList></p>
                      <asp:Button ID="addProductButton" Text="Create" runat="server" OnClick="addProductButton_Click" />
                      <asp:Label ID="productFbLabel" runat="server" />
                  </td>
                  <td id="tdSchedule" runat="server">

                  </td>
              </tr>
          </table>
    </div>
    </form>
</body>
</html>
