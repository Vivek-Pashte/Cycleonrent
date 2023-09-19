<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="oneceagain.Products" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
     <!---image slider---->
            <div class="container">
                <div id="myCarousel" class="carousel slide" data-ride="carousel">
                    <!-- Indicators -->
                    <ol class="carousel-indicators">
                        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                        <li data-target="#myCarousel" data-slide-to="1"></li>
                        <li data-target="#myCarousel" data-slide-to="2"></li>
                    </ol>
                    <!-- Wrapper for slides -->
                    <div class="carousel-inner">
                        <div class="item active">
                            <img src="imageslider/img1.png" alt="imageslider" style="width: 100%;"/>
                            <div class="carousel-caption">
                            </div>
                        </div>
                        <div class="item">
                            <img src="imageslider/img2.png" alt="imageslider" style="width: 100%;"/>
                            <div class="carousel-caption">
                        </div>
                    </div>
                    <div class="item">
                        <img src="imageslider/img3.png" alt="imageslider" style="width: 100%;"/>
                        <div class="carousel-caption">
                        </div>
                    </div>
                </div>
                <!-- Left and right controls -->
                <a class="left carousel-control" href="#myCarousel" data-slide="prev"><span class="glyphicon glyphicon-chevron-left">
                </span><span class="sr-only">Previous</span> </a><a class="right carousel-control"
                    href="#myCarousel" data-slide="next"><span class="glyphicon glyphicon-chevron-right">
                    </span><span class="sr-only">Next</span> </a>
            </div>
        </div>
            <!---image slider End---->
    <div class="row" style="padding-top:50px">
        <asp:TextBox ID="txtFilterGrid1Record" CssClass="form-control" runat="server" placeholder="Search Products Name or Products Brand Name...." AutoPostBack="true" ontextchanged="txtFilterGrid1Record_TextChanged" ></asp:TextBox>        
        <hr />        
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <br />        
        <asp:repeater ID="rptrProducts" runat="server">
            <ItemTemplate>
                <div class="col-sm-3 col-md-3">
                    <a href="ProductView.aspx?PID=<%# Eval("PID") %>" style="text-decoration:none;">
                        <div class="thumbnail">
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("Image")%>' AlternateText='<%#Eval("Image")%>'  Height="200px" style="margin:auto;" />
                            <div class="caption"> 
                                <div class="probrand"><%# Eval ("BrandName") %>  </div>
                                <div class="proName"> <%# Eval ("PName") %> </div>
                                <div class="proPrice"><%#Eval("PPrice","{0:c}") %></div> 
                            </div>
                        </div>
                    </a>
                </div>
            </ItemTemplate>
        </asp:repeater>
    </div>
</asp:Content>