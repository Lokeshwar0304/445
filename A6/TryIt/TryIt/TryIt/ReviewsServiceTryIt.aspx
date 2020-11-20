<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="ReviewsServiceTryIt.aspx.cs" Inherits="TryIt.ReviewsServiceTryIt" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
         <div class="jumbotron" style="padding-bottom:20px">
            <asp:Label ID="errorLabel" runat="server" Text="Error:"  Visible="false"  style="color:red; font-weight:bold;"></asp:Label>  
             <asp:Table ID="reviewTable" runat="server" Width="100%" Visible="false"> 
            <asp:TableRow style="font-size:90%;font-weight:bold; font-family:Calibri">
                <asp:TableCell>Hospital Name</asp:TableCell>
                <asp:TableCell>Hospital Address</asp:TableCell>
                <asp:TableCell>Distance(mi)</asp:TableCell>
                <asp:TableCell>Ratings</asp:TableCell>
                <asp:TableCell>Reviews</asp:TableCell>
                <asp:TableCell>Beds Available</asp:TableCell>
                <asp:TableCell>Ventilators Available</asp:TableCell>
                <asp:TableCell>COVID Testing</asp:TableCell>
                <asp:TableCell>Contact</asp:TableCell>
            </asp:TableRow>
            </asp:Table> 
        </div>

        
        <div style="padding-bottom:20px"> 
        <p style="font-family:Calibri">Do you want to provide a review?</p>  
        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true" >  
        <asp:ListItem Value="">Please Select</asp:ListItem>  
         </asp:DropDownList>
        <asp:TextBox ID="tb_review" runat="server"  Text="Enter Review" style="font-family:Calibri"></asp:TextBox>  
        <asp:TextBox ID="tb_rating" runat="server" Text="Enter Rating" style="font-family:Calibri"></asp:TextBox>  
        <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />  
        </div>

        <div style="padding-bottom:15px"> 
        <p style="font-family:Calibri">Do you want to provide a review to a new hospital?</p>  
        <asp:TextBox ID="tb_new_hospital" runat="server"  Text="Enter Hospital Name" OnTextChanged="tb_new_hospital_TextChanged" AutoPostBack="true" style="font-family:Calibri"></asp:TextBox>  
        <asp:TextBox ID="tb_new_review" runat="server"  Text="Enter Review" style="font-family:Calibri"></asp:TextBox>  
        <asp:TextBox ID="tb_new_rating" runat="server" Text="Enter Rating" style="font-family:Calibri"></asp:TextBox>
        <asp:TextBox ID="tb_new_contact" runat="server" Text="Enter Contact number" style="font-family:Calibri"></asp:TextBox> 
         <div>  
            <asp:Label LabelID="Label1" runat="server" Text="Is COVID testing available?"  style="font-family:Calibri"></asp:Label>  
            <asp:RadioButton ID="RadioButton1" runat="server" Text="Yes" GroupName="testing" style="font-family:Calibri; font-weight:normal" />  
            <asp:RadioButton ID="RadioButton2" runat="server" Text="No" GroupName="testing"  style="font-family:Calibri; font-weight:normal"/>  
        </div>
            <div>  
            <asp:Label LabelID="Label2" runat="server" Text="Are Ventilators available?" style="font-family:Calibri" ></asp:Label>  
            <asp:RadioButton ID="RadioButton3" runat="server" Text="Yes" GroupName="vent" style="font-family:Calibri; font-weight:normal" />  
            <asp:RadioButton ID="RadioButton4" runat="server" Text="No" GroupName="vent"  style="font-family:Calibri; font-weight:normal"/>  
        </div>  
        <asp:Button ID="SubmitButton2" runat="server" Text="Submit" OnClick="SubmitButton2_Click" />  
        </div>
        

        
</asp:Content>
