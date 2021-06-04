<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editServiceType.aspx.cs" Inherits="DahBersih.editServiceType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Style/AddEditServices.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="add-service">
            <h1>EDIT SERVICE TYPE</h1>
            <asp:HiddenField ID="IDHiddenField" runat="server" />
            <asp:Label ID="Label1" runat="server" Text="">Service Type Name</asp:Label><br />
            <asp:TextBox ID="ServiceTypeName" class="items" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ServiceTypeNameRequiredFieldValidator" ControlToValidate="ServiceTypeName" runat="server" ErrorMessage="Service Type Name cannot be blank" ForeColor="Red"></asp:RequiredFieldValidator>
            <br /><br />
            <asp:Label ID="Label2" runat="server" Text="">Description</asp:Label><br />
            <asp:TextBox ID="Description" class="items" style ="resize:none" cols="20" rows="5" TextMode="MultiLine" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="DescriptionRequiredFieldValidator" ControlToValidate="Description" runat="server" ErrorMessage="Description cannot be blank" ForeColor="Red"></asp:RequiredFieldValidator>
            <br /><br />
            <asp:Button ID="EditButton" Class="admin-btn-primary" runat="server" Text="Update Service Type" OnClick="EditButton_Click"/>
        </div>
    </form>
</body>
</html>
