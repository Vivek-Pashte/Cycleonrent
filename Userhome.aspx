<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Userhome.aspx.cs" Inherits="oneceagain.WebForm1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cycle On Rent</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta http-equiv="X-UA-Compatible" content="Google Chrome" />
    <link href="css/Custome.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="navbar navbar-default navbar-fixed-top" role="navigation">
                <div class="container ">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle " data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span>
                            <span class="icon-bar"></span><span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" href="Default.aspx">
                            <span><img src="icons/cycle.png" alt="Cycle On Rent" height="30"/></span>Cycle On Rent
                        </a>
                    </div>
                    <div class="navbar-collapse collapse">
                        <ul class="nav navbar-nav navbar-right">
                            <li class="active"><a href="Default.aspx">Home</a> </li>
                            <li><a href="About.aspx">About</a> </li>
                            <li><a href="#">Order history</a> </li>                         
                            <li class="drodown"><a href="#" class="dropdown-toggle" data-toggle="dropdown">Products<b class="caret"></b></a>
                                <ul class="dropdown-menu ">
                                    <li><a href="#" >Category</a> </li>
                                    <li><a href="#">Category</a> </li>
                                    <li><a href="#">Category</a> </li>
                                </ul>
                            </li>
                            <li>                                
                                <button id="btnCart" class="btn btn-primary navbar-btn " type="button">Cart</button>
                            </li>
                            <li id="btnSignUP" runat="server"><a href="SignUp.aspx">Registration</a> </li>
                            <li id="btnSignIN" runat="server"><a href="SignIn.aspx">Login</a> </li>
                            <li>
                                <asp:Button ID="btnlogout" CssClass="btn btn-default navbar-btn " runat="server" Text="Sign Out" OnClick="btnlogout_Click" />
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
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
                            <img src="imageslider/img2.png"alt="imageslider" style="width: 100%;"/>
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
            <div class="row" style="padding-top:50px; margin:10px">
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
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("Image")%>' AlternateText='<%#Eval("Image")%>' Height="200px" style="margin:auto;" />
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
        </div>
         <!--footer contents start--->
        <footer>
            <div class="container ">
                <p class="pull-right"><a href="#">Back to top</a></p>
                <p>&copy; 2022 VivekPashte.in &middot; <a href="Default.aspx">Home</a>&middot;<a href= "#">About</a>&middot;<a href="#">Contact</a>&middot;<a href="#">Products</a></p> 
            </div>
        </footer>
        <!--footer Contents end --->
    </form>
</body>
</html>