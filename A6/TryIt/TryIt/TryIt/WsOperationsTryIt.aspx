<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="WsOperationsTryIt.aspx.cs" Inherits="TryIt.RequiredTryIt" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
        <div>
            <div class="jumbotron">
        <p >This page is to analyze a WSDL file in XML format and return operation names, their corresponding input parameters and return types.</p>
        <h5 style="font-size:100%;">Service Details:</h5>
        <p style="font-size:80%;">Method Name: WsOperations,     Input Parameter: string URL,     Return Type: String Array</p>
    </div>

    <div style="padding-left:0px;padding-right:0px;padding-top:0px;padding-bottom:15px">
        <asp:TextBox id="tb4" Text="Please provide a valid URL" runat="server"  Width="100%" OnTextChanged="tb4_TextChanged" Font-Size="X-Small"  />
        <asp:Button id="b1" Text="Analyze" runat="server"  OnClick="b1_Click" Font-Size="X-Small"/>
    </div>
    
    <div>
        <asp:Label ID="errorLabel" runat="server" Text="Error:"  Visible="false"  style="color:red; font-weight:bold;"></asp:Label>  
    <asp:Table ID="myTable" runat="server" Width="100%" Visible="false"> 
    <asp:TableRow style="font-size:90%;">
        <asp:TableCell>Method Name</asp:TableCell>
        <asp:TableCell>Input Parameters</asp:TableCell>
        <asp:TableCell>Return Type</asp:TableCell>
    </asp:TableRow>
    </asp:Table> 
    </div>
   
        </div>
    
</asp:Content>
