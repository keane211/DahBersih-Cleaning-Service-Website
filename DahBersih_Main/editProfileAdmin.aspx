<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editProfileAdmin.aspx.cs" Inherits="DahBersih.editProfileAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="Style/admin.css" rel="stylesheet" />
    <link href="Style/keane.css" rel="stylesheet" />
    <link rel="stylesheet" href="../lib/font-awesome/css/all.css" />
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?sensor=false"></script>


    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/js/bootstrap.bundle.min.js"></script>
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Lobster&display=swap');
        @import url('https://fonts.googleapis.com/css2?family=Lato:ital,wght@0,300;0,400;1,400&display=swap');
        .box{
            width:400px;
            height:40px;
            text-align:left;
        }
    </style>
    <title>Dahberdih | Admin Page | Change Password</title>
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
        <div>
            <br/><br/><br/><br/>
            <h1 style="text-align:center;">Update Profile</h1><br/><br/>
            <table class="dahbersih-form" style="text-align:left;">
                <tr>
                    <td> <asp:Label style="margin-left: 250px" class="label" ID="Label5" runat="server" Text="">Name</asp:Label></td>  
                    <td> <asp:TextBox class="box" ID="Name" runat="server" Enabled="False"></asp:TextBox> <br/></td>
                </tr>
                <tr>
                    <td> <asp:Label style="margin-left: 250px" class="label" ID="Label3" runat="server" Text="">Email</asp:Label></td>  
                    <td> <asp:TextBox class="box" ID="Email" runat="server" Enabled="False"></asp:TextBox> <br/></td>
                </tr>
                <tr>
                    <td> <asp:Label style="margin-left: 250px" class="label" ID="Label1" runat="server" Text="">Old Password</asp:Label></td>  
                    <td> <asp:TextBox class="box" ID="OldPassword" runat="server" TextMode="Password"></asp:TextBox> <br/>
                    <asp:RequiredFieldValidator  ControlToValidate="OldPassword" ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="Please enter old password"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td> <asp:Label style="margin-left: 250px" class="label" ID="Label4" runat="server" Text="">New Password</asp:Label></td>  
                    <td> <asp:TextBox class="box" ID="Password" runat="server" TextMode="Password"></asp:TextBox> <br/>
                    <asp:RequiredFieldValidator  ControlToValidate="Password" ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ErrorMessage="Please enter new password"></asp:RequiredFieldValidator> &nbsp
                  <%--<asp:CustomValidator ControlToValidate="Password" ID="PasswordLengthValidator" runat="server" ErrorMessage="8 to 16 letters" OnServerValidate="PasswordLengthValidator_ServerValidate"  ForeColor="Red"></asp:CustomValidator>--%> </td>
                </tr>
                <tr>
                    <td> <asp:Label style="margin-left: 250px" class="label" ID="Label7" runat="server" Text="">Re-Enter New Password</asp:Label></td>
                    <td> <asp:TextBox class="box" ID="Password2" runat="server" TextMode="Password"></asp:TextBox> <br/>
                    <asp:RequiredFieldValidator  ControlToValidate="Password2" ID="RequiredFieldValidator7" runat="server" ForeColor="Red" ErrorMessage="Please re-enter new password"></asp:RequiredFieldValidator> &nbsp
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password must be the same"
                        ForeColor ="Red"
                        ControlToCompare="Password2"
                        ControlToValidate="Password"></asp:CompareValidator> </td>
                </tr>
                <tr>
                   <td colspan="2"><asp:Button style="margin-left: 525px" class="btn-primary" ID="Submit" runat="server" Text="Update" OnClick="UpdateButton_Click"/></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
