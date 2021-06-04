<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="confirmBooking.aspx.cs" Inherits="Dahbersih.sln.confirmBooking" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Booking Confirmation</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="Style/style.css" rel="stylesheet" />
    <link href="Style/keane.css" rel="stylesheet" />
    <link rel="stylesheet" href="../lib/font-awesome/css/all.css" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/js/bootstrap.bundle.min.js"></script>
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Lobster&display=swap');
        @import url('https://fonts.googleapis.com/css2?family=Lato:ital,wght@0,300;0,400;1,400&display=swap');
    </style>
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
    </style>
</head>
<body>
    <div class="bookNow text-center">
    <h1 style="margin-top:10px;"><b>Booking Confirmation</b></h1>
    </div>
    <form id="form1" runat="server">
    <nav class="dahbersih-navbar d-inline-flex w-100 justify-content-between">
        <a href="main.aspx"><img src="images/Logo-transparent.png" alt="Dahbersih Logo" class="dahbersih-logo" width="80"/></a>
        <ul class="nav justify-content-end">
            <li class="nav-item d-flex">
                <a class="nav-link active m-auto" href="main.aspx#about">About Us</a>
            </li>
            <li class="nav-item d-flex">
                <a class="nav-link m-auto" href="main.aspx#service">Services</a>
            </li>
            <li class="nav-item d-flex">
                <a class="nav-link m-auto" href="#contactus">Contact Us</a>
            </li>
            <asp:PlaceHolder ID="Navigation" runat="server"></asp:PlaceHolder>
        </ul>
    </nav>
        <div class="div-form">
            <table class="dahbersih-form">
                <tr>
                    <td> <asp:Label ID="Label1" runat="server" Text="">Service Chosen</asp:Label></td>  
                    <td> <asp:Label ID="ServiceType" runat="server" Enabled="False"></asp:Label> </td>
                </tr>
                <tr>
                    <td> <asp:Label ID="Label2" runat="server" Text="">Property Size</asp:Label></td>
                    <td> <asp:Label ID="Size" runat="server" Enabled="False"></asp:Label> </td>
                </tr>
                <tr>
                    <td> <asp:Label ID="Label3" runat="server" Text="">Date Chosen</asp:Label></td>  
                    <td> <asp:Label ID="ServiceDate" runat="server" Enabled="False"></asp:Label> </td>
                </tr>
                <tr>
                    <td> <asp:Label ID="Label4" runat="server" Text="">Time Chosen</asp:Label></td>  
                    <td> <asp:Label ID="ServiceTime" runat="server" Enabled="False"></asp:Label> </td>
                </tr>
                <tr>
                    <td> <asp:Label ID="Label5" runat="server" Text="">Street Name</asp:Label></td>  
                    <td> <asp:Label ID="Address" runat="server" Enabled="False"></asp:Label> </td>
                </tr>
                <tr>
                    <td> <asp:Label ID="Label6" runat="server" Text="">City</asp:Label></td>  
                    <td> <asp:Label ID="City" runat="server" Enabled="False"></asp:Label> </td>
                </tr>
                <tr>
                    <td> <asp:Label ID="Label7" runat="server" Text="">State</asp:Label></td>  
                    <td> <asp:Label ID="State" runat="server" Enabled="False"></asp:Label> </td>
                </tr>
                <tr>
                    <td> <asp:Label ID="Label8" runat="server" Text="">Post Code</asp:Label></td>  
                    <td> <asp:Label ID="Postcode" runat="server" Enabled="False"></asp:Label> </td>
                </tr>
                <tr>
                    <td> <asp:Label ID="Label9" runat="server" Text="">Phone Number</asp:Label></td>  
                    <td> <asp:Label ID="PhoneNumber" runat="server" Enabled="False"></asp:Label> </td>
                </tr>
                <tr>
                    <td> <asp:Label ID="Label10" runat="server" Text="">Price</asp:Label></td>  
                    <td> <asp:Label ID="Price" runat="server" Enabled="False"></asp:Label> </td>
                </tr>
                <tr>
                    <td> <asp:Button class="btn-primary" ID="BackButton" runat="server" Text="Back" OnClick="BackButton_Click"/></td>
                    <td> <asp:Button class="btn-primary" ID="ConfirmButton" runat="server" Text="Confirm" OnClick="ConfirmButton_Click"/></td>
                </tr>
            </table>
        </div>
    </form>
    <footer>
        <div class="col-6">
            <h3 class="mb-4" id="contactus">Contact Us</h3>
            <div class="d-inline-flex w-100">
                <div class="col-2">
                    <p class="mb-0"><b>Email:</b></p>
                </div>
                <div class="col-10">
                    dahbersih@gmail.com
                </div>
            </div><br />
            <div class="d-inline-flex w-100">
                <div class="col-2">
                    <p class="mb-0"><b>Telephone:</b></p>
                </div>
                <div class="col-10">
                    +601 8965 6345
                </div>
            </div>
            <div class="d-inline-flex w-100 mt-3">
                <div class="col-2">
                    <p><b>Address:</b></p>
                </div>
                <div class="col-10">
                    Jalan Teknologi 5, Taman Teknologi Malaysia, 57000 Kuala Lumpur, Wilayah Persekutuan Kuala Lumpur
                </div>
                <br/>
           </div>
            <div class="col-12 mt-4">
                    &copy Copyright 2021 by DahBersih. All Rights Reserved. 
                </div>
            </div>
    </footer>
</body>
</html>
