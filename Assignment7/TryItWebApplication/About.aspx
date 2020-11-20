<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="TryItWebApplication.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
     <div class="jumbotron">
        <p style="font-size:15px"> XPathSearch Operation: This operation takes the URL of an XML (.xml) file and a path expression as input. </p>
        <p style="font-size:15px"> Once the input URL and path expression are validated, It returns the path expression value of the given path.</p>
         
    </div> 

        <div style="font-family:Calibri" runat="server">
        <asp:Label LabelID="label1" runat="server" Text="Enter the URL of an XML(.xml) file" ></asp:Label>
        <br />
        <asp:TextBox ID="tbxml" runat="server" Width="868px" ></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Enter the Path Expression" ></asp:Label>
        <br />
        <asp:TextBox ID="tbss" runat="server" Width="216px"></asp:TextBox>
        <br />
        <br />
        <asp:Button OnClick="bnsearch_Click" ID="bnsearch" runat="server" Text="Search" />  
        <asp:Button OnClick="btnrefresh_Click" ID="btnrefresh" runat="server" Text="Refresh"  />  
        <br />
        <br />
        <asp:Label ID="lboutput" runat="server"  Visible="false" ></asp:Label>
        </div>
   
</asp:Content>
