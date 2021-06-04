<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminMain.aspx.cs" Inherits="DahBersih.adminMain" %>

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
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?sensor=false"></script>
    <title>Dahberdih | Admin Page</title>
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
    <div class="Welcom-admin text-center" >
        <h1>Welcome to Admin Page!</h1>
        <div class="d-inline-flex admin-section justify-content-around w-100">
            <div class="admin-navigation">
                <a href="admin_bookings.aspx"><img src="images/Bookings.png" /></a>
                <h5>BOOKINGS</h5>
            </div>
            <div class="admin-navigation">
                <a href="admin_feedbacks.aspx"><img src="images/Feedbacks.png" /></a>
                <h5>FEEDBACKS</h5>
            </div>
            <div class="admin-navigation">
                <a href="admin_customers.aspx"><img src="images/Custommers.png" /></a>
                <h5>CUSTOMERS</h5>
            </div>
            <div class="admin-navigation">
                <a href="admin_services.aspx"><img src="images/Services.png" /></a>
                <h5>SERVICES</h5>
            </div>
        </div>
    </div>
  
    </form>
   
</body>
</html>
