<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_services.aspx.cs" Inherits="DahBersih.admin_services" %>

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
    <title>Dahberdih | Admin Page | Services</title>
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
    <div class="admin-services-section d-inline-flex mt-5 mb-5" id="bookings">
            <div class="admin-item-content">
                <h3><b>SERVICES</b></h3>
                    <div class="admin-drop-list">
                        <asp:RadioButtonList ID="ServiceType" OnSelectedIndexChanged="ServiceType_SelectedIndexChanged" runat="server" AutoPostBack="True" class="mb-3"></asp:RadioButtonList>
                        <asp:Button ID="AddServiceTypeButton" runat="server" Text="Add New Service Type" OnClick="AddServiceTypeButton_Click" class="admin-btn-primary"/>
                        <asp:Button ID="AddServiceButton" runat="server" Text="Add New Service" OnClick="AddServiceButton_Click" class="admin-btn-primary"/>
                    </div>
                <asp:Label ID="Description" Visible="false" runat="server" Text=""></asp:Label><br />
                <asp:Button ID="EditServiceTypeButton" Visible="false" runat="server" Text="Edit This Service Type" OnClick="EditServiceTypeButton_Click" class="admin-btn-primary mt-3"/>
                <asp:Button ID="DeleteServiceTypeButton" Visible="false" runat="server" Text="Delete This Service Type" OnClick="DeleteServiceTypeButton_Click" class="admin-btn-primary"/>
                <br /> <br/>
                <asp:PlaceHolder ID="ManageServicePlaceHolder" runat="server"></asp:PlaceHolder>
            </div>
        </div>
    </form>
</body>
</html>