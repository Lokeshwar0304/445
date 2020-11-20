<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TryIt._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
       
        <asp:Table ID="Table1" runat="server" Height="123px" Width="100%">
            <asp:TableRow runat="server" style="font-size:100%;font-weight:bold">
                <asp:TableCell>Service Name</asp:TableCell>
                <asp:TableCell>Description</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" style="font-size:90%;">
               <asp:TableCell><a href="WeatherServiceTryIt.aspx">Weather</a> </asp:TableCell>
                <asp:TableCell>This service displays weather predictions for next 5-days based on zipcode.</asp:TableCell>

            </asp:TableRow>
            <asp:TableRow runat="server" style="font-size:90%;">
                <asp:TableCell><a href="WsOperationsTryIt.aspx">WsOperations</a></asp:TableCell>
                <asp:TableCell>This service displays the operation names, input parameters and return types of WSDL URLs.</asp:TableCell>

            </asp:TableRow>
            <asp:TableRow runat="server" style="font-size:90%;">
                <asp:TableCell><a href="ReviewsServiceTryIt.aspx"> Reviews</a></asp:TableCell>
                <asp:TableCell>This service displays the reviews of all the hospitals. Allows users to add reviews for existing hospitals or add new hospital reviews. </asp:TableCell>

            </asp:TableRow>
            <asp:TableRow runat="server" style="font-size:90%;">
               <asp:TableCell><a href="ProductsServiceTryIt.aspx"> Products </a></asp:TableCell>
                <asp:TableCell>This service is for the users to buy COVID support accessories. User can search for product and add it to cart and save the cart.</asp:TableCell>

            </asp:TableRow>
            <asp:TableRow runat="server" style="font-size:90%;">
                <asp:TableCell> <a href="CartServiceTryIt.aspx">Cart</a></asp:TableCell>
                <asp:TableCell>This service is fetch products added to the cart based on the specific user name or cart name.</asp:TableCell>

            </asp:TableRow>
        </asp:Table>
       
    </div>

    

</asp:Content>
