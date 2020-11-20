<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="ProductsServiceTryIt.aspx.cs" Inherits="TryIt.ProductsTryIt" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron" style="padding-bottom:20px">
        
        <div runat="server" style="padding-bottom:25px">
            <asp:TextBox ID="tb_item" runat="server" Text="Enter an item to search" ></asp:TextBox>  
            <asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" />  
        </div>
           
        
        <div style="padding-bottom:25px ;font-family:Calibri">
            <asp:Label ID="errorLabel" runat="server" Text="Error:"  Visible="false"  style="color:red; font-weight:bold; "></asp:Label>  
             <asp:Table ID="productsTable" runat="server" Width="100%" Visible="false" BorderStyle="Solid"> 
            <asp:TableRow style="font-size:90%;font-weight:bold; font-family:Calibri; padding-top:10px;">
                <asp:TableCell>Product Name</asp:TableCell>
                <asp:TableCell>Category Name</asp:TableCell>
                <asp:TableCell>ShipToLocations</asp:TableCell>
                <asp:TableCell>Current Price</asp:TableCell>
                <asp:TableCell>Shipping Cost</asp:TableCell>
                <asp:TableCell>1DayShippingAvailable</asp:TableCell>
                <asp:TableCell>Return Accepted</asp:TableCell>
            </asp:TableRow>
            </asp:Table> 
        </div>
            <div id="buy" style="font-family:Calibri">
             <asp:Label LabelID="Label2" runat="server" Text="Want to buy products?" ></asp:Label>
             <asp:DropDownList ID="productsList" runat="server"  >  
            <asp:ListItem Value="">Please Select</asp:ListItem>
             </asp:DropDownList>
             <asp:TextBox ID="tb_quantity" runat="server"  Text="Enter Quantity"></asp:TextBox> 
            <asp:Button ID="AddToCart" runat="server" Text="Add to Cart" OnClick="AddToCart_Click"  />  
                <asp:Button ID="Button2" runat="server" Text="Done" OnClick="Button2_Click"   />
                  
         </div>
            <div style="padding-top:30px;font-family:Calibri" id="userCartdetails" runat="server">
                <asp:Label LabelID="Label3" runat="server" Text="Enter check out details" ></asp:Label>
                  <asp:TextBox ID="tb_username" runat="server"  Text="Enter userName"></asp:TextBox>
                  <asp:TextBox ID="tb_cartname" runat="server"  Text="Enter cartName"></asp:TextBox>
                  <asp:TextBox ID="tb_contact" runat="server"  Text="Enter contact number"></asp:TextBox>
                  <asp:TextBox ID="tb_address" runat="server"  Text="Enter address"></asp:TextBox>
                <asp:Button ID="CheckOutCart" runat="server" Text="CheckOutCart" OnClick="CheckOutCart_Click" />
                 <asp:Label LabelID="resultco" runat="server" Text=" "  Visible="false"></asp:Label>
            </div>
              
            
        </div>

          
         
          

</asp:Content>