<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="oneceagain.Payment" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:HiddenField ID="hdCartAmount" runat="server" />
    <asp:HiddenField ID="hdCartDiscount" runat="server" />
    <asp:HiddenField ID="hdTotalPayed" runat="server" />
    <asp:HiddenField ID="hdQty" runat="server" />
    <asp:HiddenField ID="hdSizeID" runat="server" />
    <br />
    <br />        
    <div class="row" style="padding-top: 20px;">
        <div class="col-md-9">
            <div class="form-horizontal">
                <h3>Delivery Address</h3>
                <hr />
                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" CssClass="control-label" Text="Name"></asp:Label>
                    <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" CssClass="control-label" Text="Address"></asp:Label>
                    <asp:TextBox ID="txtAddress" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label3" runat="server" CssClass="control-label" Text="Pin Code"></asp:Label>
                    <asp:TextBox ID="txtPinCode" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="RequiredFieldValidator2"  CssClass="text-danger" runat="server" ErrorMessage="Enter pin code" ControlToValidate="txtPinCode" MaximumValue="499999" MinimumValue="400000"></asp:RangeValidator>                    
                </div>
                <div class="form-group">
                    <asp:Label ID="Label4" runat="server" CssClass="control-label" Text="Mobile Number"></asp:Label>
                    <asp:TextBox ID="txtMobileNumber" CssClass="form-control" runat="server" TextMode="Phone"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="txtMobileNumber"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="col-md-12 table"  CellPadding="6" ForeColor="#333333" GridLines="None" >
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                    <Columns>
                        <asp:BoundField DataField="PID" HeaderText="Product ID" />
                        <asp:BoundField DataField="PName" HeaderText="Product Name" />
                        <asp:BoundField DataField="Qty" HeaderText="Quantity" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="col-md-3" runat="server" id="divPriceDetails">
             <div style="border-bottom: 1px solid #eaeaec;">
                <h5 class="proNameViewCart">PRICE DETAILS</h5>
                <div>
                    <label>Cart Total</label>
                    <span class="float-right priceGray" id="spanCartTotal" runat="server"></span>
                </div>
                <div>
                    <label> Diposite</label>
                    <span class="float-right priceGray" id="spanDiposite" runat="server">1000</span>
                </div>
            </div>
            <div>
                <div class="proPriceView">
                    <label>Total</label>
                    <span class="float-right" id="spanTotal" runat="server"></span>
                </div>
            </div>
        </div>
        <div class="col-md-12">
            <h3>Choose Payment Mode</h3>
            <hr />
            <ul class="nav nav-tabs">
                <li class="nav-item"><a class="nav-link active" data-toggle="tab" href="#wallets">WALLETS</a></li>
                <li class="nav-item"><a class="nav-link" data-toggle="tab" href="#cards">CREDIT/DEBIT CARDS</a></li>
                <li class="nav-item"><a class="nav-link" data-toggle="tab" href="#cod">COD</a></li>
            </ul>
            <div class="tab-content">
                <div id="wallets" class="tab-pane fade">
                    <h3>Menu 1</h3>
                    <p>Some content.</p>
                </div>
                <div id="cards" class="tab-pane fade">
                    <h3>Menu 2</h3>
                    <p>Some content.</p>
                </div>
                <div id="cod" class="tab-pane fade">
                    <h3>Menu 3</h3>
                    <p>Some content.</p>
                </div>
            </div>
            <div class="tab-content">
                <div id="PlaceOrder" class="col-md-3">
                    <asp:Button ID="btnplaceorder" CssClass="buyNowbtn" runat="server" Text="Place Order &raquo;" OnClick="btnplaceorder_Click" />
                </div>
                <div class="col-md-9">

                </div>
            </div>
        </div>
    </div>
</asp:Content>