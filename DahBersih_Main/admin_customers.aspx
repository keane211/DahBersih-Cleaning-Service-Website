<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_customers.aspx.cs" Inherits="DahBersih.admin_customers" %>

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
    <title>Dahberdih | Admin Page | Customers</title>
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
    <div class="admin-customers-section d-inline-flex mt-5 mb-5" id="customers">
            <div class="admin-item-content">
                <h3><b>CUSTOMERS</b></h3>
                <asp:Label ID="Label1" runat="server" Text="">Search Customer</asp:Label>
                <asp:TextBox ID="Name" runat="server"></asp:TextBox>
                <asp:DropDownList ID="State" runat="server">
                    <asp:ListItem Text="All" Value="All" Selected="True">All</asp:ListItem>
                    <asp:ListItem Text="Kuala Lumpur" Value="Kuala_Lumpur">Kuala Lumpur</asp:ListItem>
                    <asp:ListItem Text="Selangor" Value="Selangor">Selangor</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Label ID="Label2" runat="server" Text="">Name order by</asp:Label>
                <asp:RadioButtonList ID="Order" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Ascending" Value="ASC" Selected="True" style="margin-right: 20px">Ascending</asp:ListItem>
                    <asp:ListItem Text="Descending" Value="DESC">Descending</asp:ListItem>
                </asp:RadioButtonList>
                <br />
                <asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" class="admin-btn-primary"/>
                <asp:Button ID="CLearButton" runat="server" Text="Clear Search" OnClick="ClearButton_Click" class="admin-btn-primary"/>
                <br /> <br />
                <table class="admin-item-table">
                    <tr>
                        <th>Name</th>
                        <th>Email</th>
                        <th>Password</th>
                        <th>Phone Number</th>
                        <th>Adress</th>
                        <th>City</th>
                        <th>State</th>
                        <th>Post Code</th>
                    </tr>
                    <asp:PlaceHolder ID="ViewCustomerPlaceHolder" runat="server"></asp:PlaceHolder>
                 </table>
            </div>
        </div>
    </form>
</body>
</html>
