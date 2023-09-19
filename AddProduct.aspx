<%@ Page Title="" Language="C#" MasterPageFile="~/adminmaster.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="oneceagain.AddProduct" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="form-horizontal">
            <br />
            <br />
            <h2>Add Product</h2>
            <hr />
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" CssClass="col-md-2 control-label" Text="Proudct Name"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="txtProductName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" CssClass="col-md-2 control-label" Text="Price"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="txtPrice" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" CssClass="col-md-2 control-label" Text="Deposite + Price"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="txtsellPrice" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label4" runat="server" CssClass="col-md-2 control-label" Text="Brand"></asp:Label>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlBrand" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBrand_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label5" runat="server" CssClass="col-md-2 control-label" Text="Category"></asp:Label>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlCategory" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label7" runat="server" CssClass="col-md-2 control-label" Text="Size"></asp:Label>
                <div class="col-md-3">
                    <asp:CheckBoxList ID="cblSize" CssClass="form-control" RepeatDirection="Horizontal" runat="server"></asp:CheckBoxList>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label20" runat="server" CssClass="col-md-2 control-label" Text="Quantity"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="txtQuantity" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label9" runat="server" CssClass="col-md-2 control-label" Text="Product Details"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="txtPDetail" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label11" runat="server" CssClass="col-md-2 control-label" Text="Upload Image"></asp:Label>
                <div class="col-md-3">
                    <asp:FileUpload ID="fuImg1" CssClass="form-control" runat="server" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label16" runat="server" CssClass="col-md-2 control-label" Text="Free Delivery"></asp:Label>
                <div class="col-md-3">
                    <asp:CheckBox ID="chFD" runat="server" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label18" runat="server" CssClass="col-md-2 control-label" Text="COD"></asp:Label>
                <div class="col-md-3">
                    <asp:CheckBox ID="cbCOD" runat="server" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2 "></div>
                <div class="col-md-6 ">
                    <asp:Button ID="btnAdd" CssClass="btn btn-success " runat="server" Text="ADD Product" OnClick="btnAdd_Click" />
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <hr />
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h2>Product Report</h2>
            </div>
            <div class="panel-body">
                <div class="col-md-12">
                    <div class="form-group">
                        <div class="table table-responsive">
                            <asp:GridView ID="GridView1" runat="server" CssClass="table" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="PID" HeaderText="P.ID" />
                                    <asp:BoundField DataField="PName" HeaderText="Product Name" />
                                    <asp:BoundField DataField="PPrice" HeaderText="Price" />
                                    <asp:BoundField DataField="PBrandID" HeaderText="Brand" />
                                    <asp:BoundField DataField="PCategoryID" HeaderText="Category" />
                                    <asp:BoundField DataField="SizeName" HeaderText="Size" />
                                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                    <asp:TemplateField HeaderText="Photo">
                                        <ItemTemplate>
                                            <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("image")%>' Height="80px" Style="margin: 5px;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--  <asp:CommandField ShowDeleteButton="true"  HeaderText="Delete"/>--%>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
