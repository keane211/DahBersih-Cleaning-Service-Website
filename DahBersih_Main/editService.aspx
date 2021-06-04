<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editService.aspx.cs" Inherits="DahBersih.editService" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Style/AddEditServices.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="add-service">
            <h1>EDIT SERVICE</h1>
            <asp:HiddenField ID="IDHiddenField" runat="server" />
            <asp:Label ID="Label1" runat="server" Text="">Service Type Name</asp:Label><br />
            <asp:DropDownList ID="ServiceType" class="items" runat="server" AppendDataBoundItems="True" DataTextField="ServiceTypeName" DataValueField="ServiceTypeID">
                <asp:ListItem Value="0">- Please Select Service Type -</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ControlToValidate="ServiceType" ID="RequiredFieldValidator1" runat="server"  ErrorMessage="Please choose the service type for this service" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label4" runat="server" Text="">Minimum Size of Property</asp:Label><br />
            <asp:TextBox ID="MinSize" class="items" runat="server" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator ID="MinSizeRequiredFieldValidator" ControlToValidate="MinSize" runat="server" ErrorMessage="Please enter minimum property size for this service" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label2" runat="server" Text="">Maximum Size of Property</asp:Label><br />
            <asp:TextBox ID="MaxSize" class="items" runat="server" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator ID="MaxSizeRequiredFieldValidator" ControlToValidate="MaxSize" runat="server" ErrorMessage="Please enter maximum property size for this service" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label3" runat="server" Text="">Price</asp:Label><br />
            <asp:TextBox ID="Price" class="items" runat="server" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator ID="PriceRequiredFieldValidator" ControlToValidate="Price" runat="server" ErrorMessage="Please enter price for this service" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Button ID="EditButton" runat="server" Text="Update Service" OnClick="EditButton_Click" class="admin-btn-primary"/>
        </div>
    </form>
</body>
</html>
