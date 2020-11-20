<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TryItWeatherApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    

    <div class="jumbotron">
        <p>This page displays a 5-day weather forecast of a particular location.</p>
        <p style="font-size:100%;">Given the zipcode of a particular location, this page displays weather forecast details like temperature, minimum and maximum temperature, humidity, pressure</p>
        <h5 style="font-size:100%;">Service Details:</h5>
        <p style="font-size:80%;">Method Name: Weather5day,     Input Parameter: string zipcode,     Return Type: String Array</p>
    </div>

    <div style="padding-left:0px;padding-right:0px;padding-top:0px;padding-bottom:15px">
        <asp:TextBox id="tb4" Text="Please provide a valid zipcode" runat="server"  Width="100%" OnTextChanged="tb4_TextChanged" Font-Size="X-Small"  />
        <asp:Button id="b1" Text="Forecast" runat="server"  OnClick="b1_Click" Font-Size="X-Small"/>
    </div>
    <div style="padding-left:15px;padding-right:0px;padding-top:0px;padding-bottom:15px">
       <asp:Table ID="Table0" runat="server" Width="100%" Visible="false"> 
    <asp:TableRow style="font-size:90%;">
        <asp:TableCell>ZipCode</asp:TableCell>
        <asp:TableCell>City</asp:TableCell>
        <asp:TableCell>Country</asp:TableCell>
        <asp:TableCell>Latitude</asp:TableCell>
        <asp:TableCell>Longitude</asp:TableCell>
    </asp:TableRow>
    </asp:Table> 
    </div>

    <div>
    <asp:Label ID="errorLabel" runat="server" Text="Error:"  Visible="false"  style="color:red; font-weight:bold;"></asp:Label>  
    <asp:Table ID="myTable" runat="server" Width="100%" Visible="false"> 
    <asp:TableRow style="font-size:90%;">
        <asp:TableCell>Date</asp:TableCell>
        <asp:TableCell>Temperature</asp:TableCell>
        <asp:TableCell>Minimum Temperature</asp:TableCell>
        <asp:TableCell>Maximum Temperature</asp:TableCell>
        <asp:TableCell>Humidity</asp:TableCell>
        <asp:TableCell>Pressure</asp:TableCell>
    </asp:TableRow>
    </asp:Table> 
    </div>

</asp:Content>
