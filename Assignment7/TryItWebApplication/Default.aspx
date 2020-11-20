<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TryItWebApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <p style="font-size:15px"> Verification Operation: This operation takes the URL of an XML(.xml) file and the URL of the corresponding XMLS(.xsd) file as input and validates the XML file against the corresponding XMLS(XSD) file.</p>
        <p style="font-size:15px"> Return NO ERROR message upon successful verification.</p>
    </div> 

    <div style="padding-top:25px; font-family:Calibri" runat="server">
        <asp:Label LabelID="label1" runat="server" Text="Enter the URL of an XML(.xml) file" ></asp:Label>
        <br />
        <asp:TextBox ID="tbxml" runat="server" Width="1273px" ></asp:TextBox>
        <br />
        <br />
        <asp:Label LabelID="label2" runat="server" Text="Enter the URL of an XMLS(.xsd) file"></asp:Label>
        <br />
        <asp:TextBox ID="tbxsd" runat="server" Width="1274px" ></asp:TextBox> 
        <br />
        <br />
        <asp:Button OnClick="bnvalidate_Click" ID="bnvalidate" runat="server" Text="Validate"  />  
        <asp:Button OnClick="btnrefresh_Click" ID="btnrefresh" runat="server" Text="Refresh"  />  
        
        <br />
        <br />
        <asp:Label ID="lbmessage" Visible="false" runat="server" ></asp:Label>
        
        
    </div>
    
</asp:Content>
