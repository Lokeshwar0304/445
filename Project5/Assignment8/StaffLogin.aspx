<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffLogin.aspx.cs" Inherits="Assignment8.StaffLogin" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Staff Login</title>
  
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding-top:25px">
		<h3> Staff Login</h3>
		<asp:Label ID="lb1" Text="Username: " RunAt="server" />
		<asp:TextBox ID="UserName" RunAt="server" />
		<br />
		<br />
		<asp:Label ID="lb2" Text="Password: " RunAt="server" />
		<asp:TextBox ID="Password" TextMode="password" RunAt="server" />
		<br />
		<br />
		<asp:Button Text="Log In" OnClick="logIn_Click" ID="logIn" RunAt="server" />
		<br />
		<br />
		
		<asp:Label ID="Output" RunAt="server" />

		<asp:Image ID="Image1" runat="server" ImageUrl="~/Captcha.ascx.cs" />

			
		
	</div>
    </form>
</body>
</html>
