<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site.Master" CodeBehind="CartServiceTryIt.aspx.cs" Inherits="TryIt.CartServiceTryIT" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <div runat="server" style="padding-bottom:25px">
            <asp:TextBox ID="tb_cartname" runat="server" Text="Enter cart name or user name" ></asp:TextBox>  
            <asp:Button ID="bn_cartdet" runat="server" Text="Cart Details" OnClick="bn_cartdet_Click" />  
        </div>
        <div  style="padding-bottom:20px">
            <asp:Label ID="errorLabel" runat="server" Text="Error:"  Visible="false"  style="color:red; font-weight:bold;"></asp:Label>  
             <asp:Table ID="cartTable" runat="server" Width="100%" Visible="false" BorderStyle="Dotted"> 
            <asp:TableRow style="font-size:90%;font-weight:bold; font-family:Calibri">
                <asp:TableCell>Cart Name</asp:TableCell>
                <asp:TableCell>UserName</asp:TableCell>
                <asp:TableCell>Contact Number</asp:TableCell>
                <asp:TableCell>Address</asp:TableCell>
            </asp:TableRow>
            </asp:Table> 
        </div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Product Details"  Visible="false"  style="color:darkgreen; font-weight:bold; padding-bottom:20px"></asp:Label>  
             <asp:Table ID="products" runat="server" Width="100%" Visible="false" BorderStyle="Dotted"> 
            <asp:TableRow style="font-size:90%;font-weight:bold; font-family:Calibri">
                <asp:TableCell>Product Name</asp:TableCell>
                <asp:TableCell>Product Quantity</asp:TableCell>
            </asp:TableRow>
            </asp:Table> 
        </div>
        </div>
    
</asp:Content>
