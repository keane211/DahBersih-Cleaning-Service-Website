<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_bookings.aspx.cs" Inherits="DahBersih.admin_bookings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="Style/admin.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/js/bootstrap.bundle.min.js"></script>
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Lobster&display=swap');
        @import url('https://fonts.googleapis.com/css2?family=Lato:ital,wght@0,300;0,400;1,400&display=swap');
    </style>
    <title>Dahberdih | Admin Page | Bookings</title>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="admin-navbar d-inline-flex w-100 justify-content-between">
        <a href="adminMain.aspx"><img src="images/Logo-transparent.png" alt="Dahbersih Logo" class="dahbersih-logo" width="80"/></a>
        <ul class="nav justify-content-end">
            <li class="nav-item d-flex">
                <a class="nav-link active m-auto" href="admin_customers.aspx">Customers</a>
            </li>
            <li class="nav-item d-flex">
                <a class="nav-link m-auto" href="admin_feedbacks.aspx">Feedbacks</a>
            </li>
            <li class="nav-item d-flex">
                <a class="nav-link m-auto" href="admin_bookings.aspx">Bookings</a>
            </li>
            <li class="nav-item d-flex">
                <a class="nav-link m-auto" href="admin_services.aspx">Services</a>
            </li>
            <asp:PlaceHolder ID="Navigation" runat="server"></asp:PlaceHolder>
        </ul>
    </nav>
    <div class="admin-bookings-section d-inline-flex mt-5 mb-5" id="bookings">
            <div class="admin-item-content">
                <h3><b>BOOKINGS</b></h3>

                <asp:Label ID="Label1" runat="server" Text="">Search Bookings of Customer Named </asp:Label>
                <asp:TextBox ID="Name" runat="server" style="margin-right: 30px"></asp:TextBox>

                <asp:Label ID="Label2" runat="server" Text="">Booking Status </asp:Label>
                <asp:DropDownList ID="BookingStatus" runat="server" style="margin-right: 30px">
                    <asp:ListItem Selected="True" Text="All" Value="All">All</asp:ListItem>
                    <asp:ListItem Text="Pending" Value="Pending">Pending</asp:ListItem>
                    <asp:ListItem Text="Completed" Value="Completed">Completed</asp:ListItem>
                </asp:DropDownList>
                
                <asp:Label ID="Label3" runat="server" Text="">Bookings on </asp:Label>
                <asp:TextBox ID="ServiceDate" runat="server" TextMode="Date"></asp:TextBox>
                <br />

                <asp:Label ID="Label4" runat="server" Text="">Order by </asp:Label>
                <asp:RadioButtonList ID="DateType" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Payment Date" Value="PaymentDateTime" Selected="True" style="margin-right: 10px">Payment Date</asp:ListItem>
                    <asp:ListItem Text="Booked Service Date" Value="ServiceDate">Booked Service Date</asp:ListItem>
                </asp:RadioButtonList>

                <asp:RadioButtonList ID="Order" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Latest" Value="DESC" Selected="True" style="margin-right: 10px">Latest</asp:ListItem>
                    <asp:ListItem Text="Oldest" Value="ASC">Oldest</asp:ListItem>
                </asp:RadioButtonList>
                <br />
                <asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" class="admin-btn-primary"/>
                <asp:Button ID="CLearButton" runat="server" Text="Clear Search" OnClick="ClearButton_Click" class="admin-btn-primary"/>
                <br /><br />
                <table class="admin-item-table">
                    <tr>
                        <th>Booking ID</th>
                        <th>Customer Name</th>
                        <th>Address</th>
                        <th>City</th>
                        <th>State</th>
                        <th>Post Code</th>
                        <th>Phone Number</th>
                        <th>Service Type</th>
                        <th>Size</th>
                        <th>Service Date</th>
                        <th>Service Time</th>
                        <th>Payment Date and Time</th>
                        <th>Status</th>
                        <th>Action</th>
                    </tr>
                    <asp:PlaceHolder ID="ManageBookingPlaceHolder" runat="server"></asp:PlaceHolder>
                 </table>
            </div>
        </div>
    </form>
</body>
</html>
