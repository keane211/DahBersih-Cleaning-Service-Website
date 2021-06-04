﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="DahBersih.register" %>

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
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
        .login{
            font-size:50px;
            color: white;
            text-decoration: none;
            padding:250px;
        }
        a:hover{
            color:white;
        }
        .box{
            width:600px;
            height:40px;
            text-align:left;
        }
        .label{
            text-align:left;
        }
        .Msg{
            margin-left: 100px;
        }
        a:hover{
            background-color: darkgrey;
        }
    </style>
    <title>Registration</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
            <li class="nav-item d-flex">
                <a class="nav-link m-auto" href="login.aspx">Login</a>
            </li>
            <li class="nav-item d-flex">
                <a class="nav-link m-auto" href="register.aspx">Register</a>
            </li>
        </ul>
    </nav>
        <div id="register">
            <br/><br/><br/><br/>
            <h1 style="margin:auto; text-align:center;">REGISTRATION FORM</h1><br/><br/>
            <table class="dahbersih-form">
                <tr>
                    <td> <asp:Label style="margin-left: 200px" class="label" ID="Label5" runat="server" Text="">Name</asp:Label></td>  
                    <td> <asp:TextBox class="box" ID="Name" runat="server"></asp:TextBox> <br/>
                    <asp:RequiredFieldValidator  ControlToValidate="Name" ID="RequiredFieldValidator5" runat="server" ForeColor="Red" ErrorMessage="Name Required"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td> <asp:Label style="margin-left: 200px" class="label" ID="Label3" runat="server" Text="">Email</asp:Label></td>  
                    <td> <asp:TextBox class="box" ID="Email" runat="server"></asp:TextBox> <br/>
                    <asp:RequiredFieldValidator  ControlToValidate="Email" ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ErrorMessage="Email Required"></asp:RequiredFieldValidator> &nbsp
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid Email address" ControlToValidate="Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator> </td>
                </tr>
                <tr>
                    <td> <asp:Label style="margin-left: 200px" class="label" ID="Label6" runat="server" Text="">Phone</asp:Label></td>  
                    <td> <asp:TextBox class="box" ID="Phone" runat="server" TextMode="Phone"></asp:TextBox>  <br/>
                    <asp:RequiredFieldValidator ControlToValidate="Phone" ID="RequiredFieldValidator6" runat="server" ForeColor="Red" ErrorMessage="Phone Number Required"></asp:RequiredFieldValidator> &nbsp
                    <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="Invalid Phone Number" ForeColor="Red" OnServerValidate="CustomValidator3_ServerValidate"></asp:CustomValidator> </td>
                </tr>
                <tr>
                    <td> <asp:Label style="margin-left: 200px" class="label" ID="Label4" runat="server" Text="">Password</asp:Label></td>  
                    <td> <asp:TextBox class="box" ID="Password" runat="server" TextMode="Password"></asp:TextBox> <br/>
                    <asp:RequiredFieldValidator  ControlToValidate="Password" ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ErrorMessage="Password Required"></asp:RequiredFieldValidator> &nbsp
                    <asp:CustomValidator ControlToValidate="Password" ID="CustomValidator1" runat="server" ErrorMessage="8 to 16 letters" OnServerValidate="CustomValidator1_ServerValidate"  ForeColor="Red"></asp:CustomValidator> </td>
                </tr>
                <tr>
                    <td> <asp:Label style="margin-left: 200px" class="label" ID="Label7" runat="server" Text="">Re-Enter Password</asp:Label></td>
                    <td> <asp:TextBox class="box" ID="Password2" runat="server" TextMode="Password"></asp:TextBox> <br/>
                    <asp:RequiredFieldValidator  ControlToValidate="Password2" ID="RequiredFieldValidator7" runat="server" ForeColor="Red" ErrorMessage="Password Required"></asp:RequiredFieldValidator> &nbsp
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password must be the same"
                        ForeColor ="Red"
                        ControlToCompare="Password2"
                        ControlToValidate="Password"></asp:CompareValidator> </td>
                </tr>
                <tr>
                    <td><asp:Label style="margin-left: 200px" class="label" ID="Label8" runat="server" Text="">Street Name</asp:Label> </td>
                    <td><asp:TextBox class="box" ID="Address" runat="server" TextMode="MultiLine"></asp:TextBox> <br/>
                    <asp:RequiredFieldValidator  ControlToValidate="Address" ID="RequiredFieldValidator9" runat="server" ForeColor="Red" ErrorMessage="Please enter street name"></asp:RequiredFieldValidator> </td>
                </tr>
                 <tr>
                    <td><asp:Label style="margin-left: 200px" class="label" ID="Label9" runat="server" Text="">City</asp:Label> </td>
                    <td><asp:TextBox class="box" ID="City" runat="server" TextMode="SingleLine"></asp:TextBox> <br/>
                    <asp:RequiredFieldValidator  ControlToValidate="City" ID="RequiredFieldValidator10" runat="server" ForeColor="Red" ErrorMessage="Please enter city"></asp:RequiredFieldValidator> </td>
                </tr>
                 <tr>
                    <td><asp:Label style="margin-left: 200px" class="label" ID="Label10" runat="server" Text="">State</asp:Label> </td>
                    <td><asp:DropDownList class="box" ID="State" runat="server" >
                        <asp:ListItem Value="0">- Please Select State -</asp:ListItem>
                        <asp:ListItem Text="Kuala Lumpur" Value="Kuala Lumpur">Kuala Lumpur</asp:ListItem>
                        <asp:ListItem Text="Selangor" Value="Selangor">Selangor</asp:ListItem>
                        </asp:DropDownList><br />
                     <asp:RequiredFieldValidator ControlToValidate="State" InitialValue="0" ID="RequiredFieldValidator8" runat="server" ForeColor="Red" ErrorMessage="Please select state"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td><asp:Label style="margin-left: 200px" class="label" ID="Label11" runat="server" Text="Label">Post Code</asp:Label> </td>
                    <td><asp:TextBox class="box" ID="Postcode" runat="server" TextMode="SingleLine"></asp:TextBox> <br/>
                    <asp:RequiredFieldValidator ForeColor="Red"  ControlToValidate="Postcode" ID="RequiredFieldValidator11" runat="server" ErrorMessage="Please enter post code"></asp:RequiredFieldValidator> &nbsp
                    <asp:CustomValidator ControlToValidate="Postcode" ID="CustomValidator2" runat="server" ErrorMessage="5 digits only" OnServerValidate="CustomValidator2_ServerValidate"  ForeColor="Red"></asp:CustomValidator> </td>
                    </tr>
                <tr>
                   <td colspan="2"><asp:Button style="margin-left: 475px"  class="btn-primary" ID="Submit" runat="server" Text="Register" OnClick="Submit_Click"/></td>
                </tr>
            </table>
        </div>
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
