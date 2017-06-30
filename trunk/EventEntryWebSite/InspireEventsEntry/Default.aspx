<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InspireEventsEntry._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Inspire Event Entry Login</title>
    <link rel="stylesheet" type="text/css" href="CSS/Stylesheet1.css">
    <style>
        .marginStyle
        {
            margin: 4px;
        }
        .shiftImage
        {
            margin-top: -40px;
        }
    </style>
</head>
<body style="height: 900px; filter:progid:DXImageTransform.Microsoft.Gradient(endColorstr='#C0CFE2', startColorstr='#FFFFFF', gradientType='0');">
    <form id="form1" runat="server" title="Inspire Event Entry Login">
    <h1>User Login:</h1>
    <div>
        <table>
            <tr valign="top">
                <td valign="top">
        <table>
            <tr>
                <td align="right">
                    <label>
                        User:</label>
                </td>
                <td colspan="3">
                    <asp:DropDownList ID="DdlUsers" runat="server" Width="220" DataTextField="Name" 
                        DataValueField="Name" >
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <label>
                        Password:</label>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="TbPassword" TextMode="Password" runat="server" Width="220"></asp:TextBox>
                    <asp:Label ID="LblFail" runat="server" ForeColor="Red" Visible="false" Text="Login Failed."></asp:Label>
                </td>
            </tr>
            <tr align="right">
                <td>
                    &nbsp;</td>
                <td >
                    <asp:Button CssClass="marginStyle" ID="Button2" runat="server" Text="Login" Width="60px" 
                        onclick="Button2_Click" />
                    <asp:Button CssClass="marginStyle" ID="Button1" runat="server" Text="Cancel" 
                        Width="60px" onclick="Button1_Click" 
                         />
                </td>
            </tr> 
        </table>
        </td>
                <td valign="top">
                    <img class="shiftImage" width="250px" src="Images/logo.png" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
