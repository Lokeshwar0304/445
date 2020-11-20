<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Assignment8.Member.Member" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3><% Response.Write("Hello " + Context.User.Identity.Name); %> </h3>
            <h3> Below are the services you can use.</h3>
            <asp:Button Text="SignOut" OnClick="signout_Click" ID="signout" RunAt="server" />
        </div>
    </form>
</body>
</html>
