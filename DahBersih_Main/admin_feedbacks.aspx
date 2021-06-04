<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_feedbacks.aspx.cs" Inherits="DahBersih.admin_feedbacks" %>

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
    <title>Dahberdih | Admin Page | Feedbacks</title>
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
    <div class="admin-feedbacks-section d-inline-flex mt-5 mb-5" id="feedbacks">
            <div class="admin-item-content">
                <h3><b>FEEDBACKS</b></h3>

                <asp:Label ID="Label1" runat="server" Text="">Search Comment Including </asp:Label>
                <asp:TextBox ID="Comment" runat="server"></asp:TextBox>

                <asp:DropDownList ID="Status" runat="server">
                    <asp:ListItem Selected="True" Text="All Comments" Value="All">All</asp:ListItem>
                    <asp:ListItem Text="Pending" Value="Pending">Pending</asp:ListItem>
                    <asp:ListItem Text="Approved" Value="Approved">Approved</asp:ListItem>
                </asp:DropDownList>

                <asp:Label ID="Label2" runat="server" Text="" style="margin-left: 20px">Commented by</asp:Label>
                <asp:DropDownList ID="Type" runat="server">
                    <asp:ListItem Selected="True" Text="All Commenters" Value="All">All Commenters</asp:ListItem>
                    <asp:ListItem Text="Customers" Value="Customers">Customers</asp:ListItem>
                    <asp:ListItem Text="Anonymous" Value="Anonymous">Anonymous</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Label ID="Label3" runat="server" Text="">Order by Date</asp:Label>
                <asp:RadioButtonList ID="Order" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Latest" Value="DESC" Selected="True">Latest</asp:ListItem>
                    <asp:ListItem Text="Oldest" Value="ASC">Oldest</asp:ListItem>
                </asp:RadioButtonList>

                <asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" class="admin-btn-primary"/>
                <asp:Button ID="CLearButton" runat="server" Text="Clear Search" OnClick="ClearButton_Click" class="admin-btn-primary"/>
                <br /> <br />
                <table class="admin-item-table">
                    <tr>
                        <th>Name</th>
                        <th>Email</th>
                        <th>Comment</th>
                        <th>Date and Time</th>
                        <th>Status</th>
                        <th>Action</th>
                    </tr>
                    <asp:PlaceHolder ID="ManageFeedbackPlaceHolder" runat="server"></asp:PlaceHolder>
                 </table>
            </div>
        </div>
    </form>
</body>
</html>
