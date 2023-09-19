<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="oneceagain.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Cart</title>
    <link href="Styles.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>    
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <link href="css/Custome.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="container">
                <br />
                <br />
                    <div style="padding-top: 50px">
                        <div class="col-md-9">
                            <h4 class="proNameViewCart" runat="server" id="h4NoItems"></h4>
                            <div id="divQtyError" runat="server" class="alert alert-success alert-dismissible fade in h4">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close"> &times;</a>
                                <strong>Oops! </strong>Quantity cannot be less than 1.
                            </div>
                            <asp:Repeater ID="RptrCartProducts" OnItemCommand="RptrCartProducts_ItemCommand" runat="server">
                                <ItemTemplate>
                                    <%--Show cart details start--%>
                                    <div class="media" style="border: 1px solid black;">
                                        <div class="media-left">
                                            <a href="ProductView.aspx?PID=<%# Eval("PID") %>" target="_blank">
                                                <asp:Image ID="Image1" runat="server" class="media-object" ImageUrl='<%# Eval("Image") %>' Width="100px" AlternateText='<%# Eval("Image") %>' onerror="this.src='Images/NoImg.png'"/>                                                
                                            </a>
                                        </div>
                                        <div class="media-body">
                                            <h4 class="media-heading proNameViewCart"><%# Eval("PName") %></h4>
                                            <span class="proPriceView"><%#Eval("PPrice","{0:c}") %></span>
                                            <span class="proPriceView"> +<%# string.Format("{0:c}",Convert.ToInt64(Eval("PSelPrice"))-Convert.ToInt64(Eval("PPrice"))) %></span>                                            
                                            <span class="proPriceView">=<%#Eval("PSelPrice","{0:c}") %></span>                                           
                                            <div class="pull-right form-inline">
                                                <asp:Label ID="lblQty" runat="server" Text="Qty:" Font-Size="Large"></asp:Label>
                                                <asp:Button ID="BtnMinus" CommandArgument='<%# Eval("PID") %>' CommandName="DoMinus" Font-Size="Large" runat="server" Text="-" />&nbsp
                                                <asp:TextBox ID="txtQty" runat="server" Width="40" Font-Size="Large" TextMode="Number" Style="text-align: center" Text='<%# Eval("Qty") %>'></asp:TextBox>&nbsp
                                                <asp:Button ID="BtnPlus" CommandArgument='<%# Eval("PID") %>' CommandName="DoPlus" runat="server" Text="+" Font-Size="Large" />&nbsp&nbsp&nbsp                                          
                                            </div>
                                            <br />
                                            <p>
                                                <asp:Button CommandArgument='<%#Eval("CartID") %>' CommandName="RemoveThisCart" ID="btnRemoveCart" CssClass="RemoveButton1" runat="server" Text="Remove" />
                                                <br />
                                                <span class="proNameViewCart pull-right">SubTotal: <%# string.Format("{0:c}",Convert.ToInt64(Eval("PSelPrice"))*Convert.ToInt64(Eval("Qty"))) %></span>                                                    
                                            </p>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <%--Show cart details Ending--%>
                        </div>
                        <div class="col-md-3" runat="server" id="divAmountSect">
                            <div>
                                <h5 class=" proNameViewCart">Price Details</h5>
                                <div>
                                    <label class=" ">Cart Total</label>
                                    <span class="pull-right priceGray" runat="server" id="spanCartTotal"></span>
                                </div>
                                <div>
                                    <label class=" ">Diposite</label>
                                    <span class="pull-right priceGray" runat="server" id="spanDiposite"></span>
                                </div>
                            </div>
                            <hr />
                            <div>
                                <div class="cartTotal">
                                    <label>Total</label>
                                    <span class="pull-right " runat="server" id="spanTotal"></span>
                                    <div>
                                        <asp:Button ID="btnBuyNow" CssClass="buyNowbtn" runat="server" OnClick="btnBuyNow_Click" Text="BUY NOW" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>