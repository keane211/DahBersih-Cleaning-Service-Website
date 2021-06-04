<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewBooking.aspx.cs" Inherits="DahBersih.viewBooking" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="Style/keane.css" rel="stylesheet" />
    <link rel="stylesheet" href="../lib/font-awesome/css/all.css" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/js/bootstrap.bundle.min.js"></script>
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Lobster&display=swap');
        @import url('https://fonts.googleapis.com/css2?family=Lato:ital,wght@0,300;0,400;1,400&display=swap');
    </style>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?sensor=false"></script>
    <style>
        .box {
            margin: 20px;
            padding: 10px;
            min-height: 500px;
            background-color: #e6f2f7;
            border-radius: 10px;
            flex: 0 0 30%; /* see note below */
            white-space: nowrap;
        }
    </style>

    <title>View Bookings</title>
</head>
<body>
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
        <div class="col-12" style="display: flex; flex-wrap: wrap; margin-top: 9em; padding: 0px 40px">
            <asp:PlaceHolder ID="BookingPlaceHolder" runat="server"></asp:PlaceHolder>
        </div>
   
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
    </form>
</body>
</html>
