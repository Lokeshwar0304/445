<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NumberSortingWebApp._Default"  %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="row">
    <h3>This application is to sort a string of numbers seperated by commas</h3>
</div>
<div class="row">
<asp:TextBox ID="TextBox1" runat="server" Height="50px" OnTextChanged="TextBox1_TextChanged"   ToolTip="Please enter a string of numbers" Width="800px" TextMode="MultiLine"></asp:TextBox>
<asp:Button ID="Button1" runat="server" Height="50px" Text="Sort" OnClick="Button1_Click" Width="100px"  />
<asp:TextBox ID="TextBox2" runat="server" Height="50px" ReadOnly="True"  Width="800px" TextMode="MultiLine"></asp:TextBox>
</div>


</asp:Content>
