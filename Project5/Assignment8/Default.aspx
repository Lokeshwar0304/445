<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment8._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div>
        <asp:Button OnClick="bnMemRegister_Click" ID="bnMemRegister" runat="server" Text="Member Register"  />  
        <asp:Button OnClick="bnMemLogin_Click" ID="bnMemLogin" runat="server" Text="Member Login"  />  
        <asp:Button OnClick="bnMemPage_Click" ID="bnMemPage" runat="server" Text="Member Page"  />  
        <br />
        <br />
        <asp:Button OnClick="bnStaffPage_Click" ID="bnStaffPage" runat="server" Text="Staff Page"  />  
        <asp:Button OnClick="bnStaffLogin_Click" ID="bnStaffLogin" runat="server" Text="Staff Login"  />  
       

        
    </div>

</asp:Content>
