<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="booking.aspx.cs" Inherits="Dahbersih.sln.booking" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="Style/style.css" rel="stylesheet" />
    <link href="Style/keane.css" rel="stylesheet" />
    <link rel="stylesheet" href="../lib/font-awesome/css/all.css" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/js/bootstrap.bundle.min.js"></script>
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Lobster&display=swap');
        @import url('https://fonts.googleapis.com/css2?family=Lato:ital,wght@0,300;0,400;1,400&display=swap');
    </style>
    <title>Booking Page</title>
    <style type="text/css">
        .auto-style2 {
            height: 39px;
        }

         .box{
            width:400px;
            height:40px;
            text-align:left;
        }
    </style>
</head>
<body>
    <div class="bookNow text-center">
    <h1 style="margin-top:10px;"><b>Book Your Cleaning Now</b></h1>
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
                    <td> <asp:Label ID="Label1" runat="server" Text="">Choose your service</asp:Label></td>      
                    <td>
                        <asp:DropDownList ID="ServiceType" runat="server" OnSelectedIndexChanged="ServiceType_SelectedIndexChanged" AppendDataBoundItems="True" DataTextField="ServiceTypeName" DataValueField="ServiceTypeID" AutoPostBack="True">
                            <asp:ListItem Value="0">- Please Select Service Type -</asp:ListItem>
                        </asp:DropDownList> <br/>

                    <asp:RequiredFieldValidator ControlToValidate="ServiceType" ID="RequiredFieldValidator1" runat="server"  ForeColor="Red" ErrorMessage="Please choose a service" InitialValue="0"></asp:RequiredFieldValidator>                     </td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label2" runat="server" Text="">Size of Property</asp:Label></td>
                    <td>
                        <asp:DropDownList ID="Size" runat="server" AppendDataBoundItems="True" DataTextField="Size" DataValueField="ServiceID" OnSelectedIndexChanged="Size_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem Value="0">- Please Select Size of Property -</asp:ListItem>
                        </asp:DropDownList> <br/>

                    <asp:RequiredFieldValidator ForeColor="Red"  ControlToValidate="Size" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please select property size" InitialValue="0"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label3" runat="server" Text="">Service Date</asp:Label></td>
                    <td><asp:TextBox ID="ServiceDate" runat="server" TextMode="Date"></asp:TextBox> <br/>
                    <asp:RangeValidator ID="RangeValidatorDate" runat="server"
                        ErrorMessage="Date must be at least 3 days from today within 1 month period of time "
                        ControlToValidate="ServiceDate" 
                        Type ="Date"
                        Display="Dynamic"
                        ForeColor="Red">
                    </asp:RangeValidator> &nbsp
                    <asp:RequiredFieldValidator ForeColor="Red"  ControlToValidate="ServiceDate" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please select a date"></asp:RequiredFieldValidator> </td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label4" runat="server" Text="">Time</asp:Label></td>
                    <td><asp:TextBox ID="ServiceTime" runat="server" TextMode="Time"></asp:TextBox> <br/>
                    <asp:RangeValidator ID="RangeValidatorTime" runat="server"
                        ErrorMessage="Time must be within 9a.m. to 5 p.m."
                        ControlToValidate="ServiceTime" 
                        MinimumValue="09:00"
                        MaximumValue="16:59"
                        Type ="String"
                        Display="Dynamic"
                        ForeColor="Red"
                        ShowSummary="False">
                    </asp:RangeValidator> &nbsp
                    <asp:RequiredFieldValidator ForeColor="Red"  ControlToValidate="ServiceTime" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please select a time"></asp:RequiredFieldValidator> </td>
                </tr>
                <tr>
                    <td class="auto-style2"><asp:Label ID="Label5" runat="server" Text="">Street Name</asp:Label> </td>
                    <td class="auto-style2"><asp:TextBox ID="Address" runat="server" TextMode="MultiLine" Enabled="False"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td><asp:Label ID="Label8" runat="server" Text="">City</asp:Label> </td>
                    <td><asp:TextBox ID="City" runat="server" TextMode="SingleLine" Enabled="False"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td><asp:Label ID="Label9" runat="server" Text="">State</asp:Label> </td>
                    <td><asp:TextBox ID="State" runat="server" TextMode="SingleLine" Enabled="False"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label10" runat="server" Text="Label">Post Code</asp:Label> </td>
                    <td><asp:TextBox ID="Postcode" runat="server" TextMode="SingleLine" Enabled="False"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label6" runat="server" Text="">Phone Number</asp:Label></td>
                    <td><asp:TextBox ID="PhoneNumber" runat="server" TextMode="Phone" Enabled="False"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label7" runat="server" Text="">Price</asp:Label></td>
                    <td>RM <asp:Label ID="Price" runat="server" Text="-" ></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2"> <asp:Button style="margin-left: 200px" class="btn-primary" ID="CheckoutButton" runat="server" Text="Proceed to Checkout" OnClick="CheckoutButton_Click"/></td>
                </tr>
            </table>
            <a href="editProfile.aspx" onmouseover="this.style.color='darkgrey'">Modify Address / Phone Number</a>
        </div>
    </form><br/><br/>
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
