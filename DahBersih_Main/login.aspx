<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="DahBersih.login" %>

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
        .box{
            width:400px;
            height:40px;
            text-align:left;
        }
        .label{
            text-align:right;
        }
        .Msg{
            margin-left: 100px;
        }
    </style>
    <title>Login</title>
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
        <div>
            <br/><br/><br/><br/><br/><br/>
            <h1 style="margin:auto; text-align:center;">LOGIN FORM</h1><br/><br/>
            <table class="dahbersih-form" style="text-align:left;">
                <tr>
                    <td> <asp:Label style="margin-left: 250px" class="label" ID="EmailLabel" runat="server" Text="">Email</asp:Label></td>  
                    <td> <asp:TextBox class="box" ID="Email" runat="server" TextMode="Email"></asp:TextBox> <br/>
                    <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" ControlToValidate="Email" runat="server" ForeColor="Red" ErrorMessage="Email Required"></asp:RequiredFieldValidator> &nbsp
                    <asp:RegularExpressionValidator ID="EmailRegularExpressionValidator" ControlToValidate="Email" runat="server" ErrorMessage="Invalid Email Address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ></asp:RegularExpressionValidator> </td>
                </tr>
                <tr>
                    <td> <asp:Label  style="margin-left: 250px" class="label" ID="PasswordLabel" runat="server" Text="">Password</asp:Label></td>  
                    <td> <asp:TextBox class="box" ID="Password" runat="server" TextMode="Password"></asp:TextBox>  <br/>
                    <asp:RequiredFieldValidator ControlToValidate="Password" ID="PasswordRequiredFieldValidator" runat="server" ForeColor="Red" ErrorMessage="Password Required"></asp:RequiredFieldValidator> </td>
                </tr>
                <tr>
                   <td colspan="2" class="text-center"><asp:Button class="dahbersih-login-btn btn-primary" ID="Button1" runat="server" Text="Login" OnClick="LoginButton_Click"/></td>
                </tr>
            </table>
            <asp:Label ID="Message" runat="server" Text=""></asp:Label><br />
            <asp:Label style="margin-left: 100px;" ID="RegisterMessage" runat="server" Text="">Don't have an account yet?&nbsp &nbsp&nbsp<a href="register.aspx" onmouseover="this.style.color='darkgrey'" >Register Now</a></asp:Label> <br/><br/>
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
