<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NumberSortingWebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <p>
</p>
<asp:TextBox ID="TextBox1" runat="server" Height="85px" OnTextChanged="TextBox1_TextChanged" Width="778px"></asp:TextBox>
<asp:Button ID="Button1" runat="server" Height="114px" Text="Sort" Width="145px" />
<asp:TextBox ID="TextBox2" runat="server" Height="122px" ReadOnly="True" Width="927px"></asp:TextBox>


</asp:Content>
