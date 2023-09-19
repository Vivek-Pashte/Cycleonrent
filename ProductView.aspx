<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ProductView.aspx.cs" Inherits="oneceagain.ProductView" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <div style="padding-top:50px">
        <!--- Success Alert --->
        <div id="divSuccess" runat="server" class="alert alert-success alert-dismissible fade in h4">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
            <strong>Success! </strong>Item successfully added to cart. 
            <a href="Cart.aspx">View Cart</a>
        </div>
        <div class="col-md-5">
            <div style="max-width:480px" class="thumbnail">
                <asp:repeater ID="rptrImage" runat="server">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("Image")%>' AlternateText='<%#Eval("Image")%>' Width="500px" />
                    </ItemTemplate>
                </asp:repeater>                
            </div>
        </div>
        <div class="col-md-5">
            <asp:Repeater ID="rptrProductDetails" runat="server" OnItemDataBound="rptrProductDetails_ItemDataBound" >
                <ItemTemplate>
                    <div class="divDet1">
                        <h1 class="proNameView"><%# Eval("PName") %> </h1>
                        <p class="proPriceView"><%#Eval("PPrice","{0:c}") %></p>                       
                    </div>
                    <div >
                        <h5 class="h5size"> SIZE</h5>
                        <div>
                            <asp:radiobuttonlist ID="rblSize" runat="server" RepeatDirection="Horizontal" >
                            </asp:radiobuttonlist>
                        </div>
                    </div>
                    <div class="divDet1">
                        <asp:button ID="btnAddtoCart" CssClass="mainButton" runat="server" text="ADD TO CART" OnClick="btnAddtoCart_Click"/>
                        <asp:Label ID="lblError" CssClass ="text-danger " runat="server" ></asp:Label>
                        <br />
                    </div>                    
                    <div class="divDet1">
                        <h5 class="h5size"> Product Details</h5>
                        <p> <%#Eval("PProductDetail") %> </p>
                    </div>
                    <div >
                        <p><%# ((int)Eval("FreeDelivery")==1)? "Free Delivery":""  %>    </p>
                        <p><%# ((int)Eval("COD")==1)? "Cash on Delivery":"" %></p>
                    </div>
                    <asp:HiddenField ID="hfCatID" runat="server" Value='<%# Eval("PcategoryID") %>' />
                    <asp:HiddenField ID="hfBrandID" runat="server" Value='<%# Eval("PBrandID") %>' />
                    <asp:HiddenField ID="hfPName" runat="server" Value='<%# Eval("PName") %>' />
                    <asp:HiddenField ID="hfPPrice" runat="server" Value='<%#Eval("PPrice") %>' />
                    <asp:HiddenField ID="hfPSelPrice" runat="server" Value='<%#Eval("PSelPrice") %>' />
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>