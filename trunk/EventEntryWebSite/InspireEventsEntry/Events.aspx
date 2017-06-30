<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="InspireEventsEntry.Events" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<script>
    function showDate(sender, args) {

        if (sender._textbox.get_element().value == "") {

            var todayDate = new Date();

            sender._selectedDate = todayDate;

        }

    }
</script>
<style>
    .shiftImage
    {
        margin-top: -68px;
    }
</style>
    <title>Event Entry:</title>
    <link rel="stylesheet" type="text/css" href="CSS/Stylesheet1.css">
</head>
<body style="filter:progid:DXImageTransform.Microsoft.Gradient(endColorstr='#C0CFE2', startColorstr='#FFFFFF', gradientType='0');">
    <form id="form1" runat="server" title="Event Entry:">
    <h1>Event Entry:</h1>
    <div>
        <table>
            <tr valign="top">
                <td valign="top">
                <table>
            <tr>
                <td>
                    <label>
                        Group Name:</label>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="TbGroupName" runat="server" Width="220"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="Add" Width="60px" 
                        onclick="Button1_Click"/>
                </td>
            </tr>
            <tr>
                <td>
                    <label>
                        Meeting Name:</label>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="TbMeetingName" runat="server" Width="220"></asp:TextBox>
                    <asp:Button ID="Button3" runat="server" Text="Update" Width="60px" 
                        onclick="Button3_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <label>
                        Room Name:</label>
                </td>
                <td colspan="3">
                    <asp:DropDownList ID="DdlGetRooms" runat="server" DataTextField="Name"
                        DataValueField="Name" Width="226px" DataSourceID="RoomsDataSource" >
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="RoomsDataSource" runat="server" 
                        SelectMethod="GetRooms" TypeName="InspireEventsEntry.RoomsProxy">
                    </asp:ObjectDataSource>
                    <asp:Button ID="Button2" runat="server" Text="Delete" Width="60px" 
                        onclick="Button2_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <label>
                        Start Time:</label>
                </td>
                <td>
                    <asp:TextBox id="TbStartTime" runat="server" />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" MaskType="Time" Mask="99:99"
                        runat="server" TargetControlID="TbStartTime" AcceptAMPM="true" MessageValidatorTip="true">
                    </cc1:MaskedEditExtender>
                </td>
                <td>
                    <label>
                        Start Date:</label>
                </td>
                <td>
                    <asp:TextBox id="TbStartDateInput" runat="server" />
                    <cc1:CalendarExtender OnClientShowing="showDate" ID="CalendarExtender1" runat="server" TargetControlID="TbStartDateInput">
                    </cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td>
                    <label>
                        End Time:</label>
                </td>
                <td>
                <asp:TextBox id="TbEndTime" runat="server" />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender2" MaskType="Time" Mask="99:99"
                        runat="server" TargetControlID="TbEndTime" AcceptAMPM="true" MessageValidatorTip="true">
                    </cc1:MaskedEditExtender>
                </td>
                <td>
                    <label>
                        End Date:</label>
                </td>
                <td>
                    <asp:TextBox id="TbEndDateInput" runat="server" />
                    <cc1:CalendarExtender ID="CldrEDI" OnClientShowing="showDate" runat="server" TargetControlID="TbEndDateInput">
                    </cc1:CalendarExtender>
                </td>
            </tr>
        </table>
                </td>
                <td valign="top">
                    <img class="shiftImage" width="350px" src="Images/logo.png" />
                </td>
            </tr>
        </table>
        
    </div>
    <asp:Label ID="LblFail" ForeColor="Red" Visible="false" runat="server" Text="Make sure all fields have a value before saving."></asp:Label>
    <br />
    <asp:GridView  ID="EventsGrid" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True"
        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" Width="890px" onselectedindexchanged="EventSelectionChanged">
        <RowStyle ForeColor="#000066" />
        <Columns>
            <asp:BoundField DataField="GroupName" HeaderText="GroupName" SortExpression="GroupName"/>
            <asp:BoundField DataField="MeetingName" HeaderText="MeetingName" SortExpression="MeetingName" />
            <asp:BoundField DataField="MeetingPostAs" Visible="false" HeaderText="MeetingPostAs" SortExpression="MeetingPostAs" />
            <asp:BoundField DataField="MeetingRoomName" HeaderText="MeetingRoomName" SortExpression="MeetingRoomName" />
            <asp:BoundField DataField="StartDateTime" HeaderText="StartTime" SortExpression="StartTime" />
            <asp:BoundField DataField="EndDateTime" HeaderText="EndTime" SortExpression="EndTime" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <br />
    </form>
</body>
</html>
