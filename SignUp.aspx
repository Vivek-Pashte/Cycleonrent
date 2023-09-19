<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="oneceagain.Singup" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SignUp</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta http-equiv="X-UA-Compatible" content="IE-edge"/>
    <link href="css/Custome.css" rel="stylesheet" />   
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</head>
<body style="background-image:url(imgregister.jpg)">
    <form id="form1" runat="server">
        <div>
            <div class ="navbar navbar-default navbar-fixed-top" role ="navigation">
             <div class="container">
                 <div class="navbar-header">
                     <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse"> 
                         <span class="sr-only">Toggle Navigation</span>
                         <span class="icon-bar"></span>
                         <span class="icon-bar"></span>
                         <span class="icon-bar"></span>
                     </button>
                     <a class="navbar-brand" href="Default.aspx"><span><img src="icons/cycle.png" alt="Cycle On Rent" height="30"/></span>Cycle On Rent</a>
                 </div>
                 <div class="navbar-collapse collapse">
                     <ul class="nav navbar-nav navbar-right">
                         <li ><a href="Default.aspx">Home</a></li>
                         <li ><a href="#">About Us</a></li>
                         <li><a href="#">Order history</a> </li>
                         <li class="drodown">
                             <a href="#" class="dropdown-toggle" data-toggle="dropdown">Type<b class="caret"></b></a>
                             <ul class="dropdown-menu">
                                 <li><a href="#" >Category</a> </li>
                                 <li><a href="#">Category</a> </li>
                                 <li><a href="#">Category</a> </li>
                             </ul>
                         </li>
                         <li class="active">
                             <asp:Button ID="btnsingup" CssClass="btn btn-default navbar-btn" runat="server" Text="Registration" PostBackUrl="~/SignUp.aspx" />
                         </li>
                         <li>
                             <asp:Button ID="Button1" CssClass="btn btn-default navbar-btn" runat="server" Text="LogIn" PostBackUrl="~/SignIn.aspx" />
                         </li>
                     </ul>
                 </div>
             </div>
            </div>
        </div>
        <!---signup page--->
        <div class ="center-page">
            <label class="col-xs-11" style="color:white">UserName:</label>
            <div class="col-xs-11">
                <asp:TextBox ID="txtUname" runat="server" Class="form-control" placeholder="Enter Your UserName"></asp:TextBox>
            </div>
            <label class="col-xs-11" style="color:white">Password:</label>
            <div class="col-xs-11">
                <asp:TextBox ID="txtPass" runat="server" TextMode="Password" Class="form-control" placeholder="Enter Your password"></asp:TextBox>
            </div>
            <label class="col-xs-11" style="color:white">Confirm Password:</label>
            <div class="col-xs-11">
                <asp:TextBox ID="txtCPass" runat="server" TextMode="Password" Class="form-control" placeholder="Enter Your Confirm password"></asp:TextBox>
            </div>
            <label class="col-xs-11" style="color:white">Your Full Name:</label>
            <div class="col-xs-11">
               <asp:TextBox ID="txtName" runat="server" Class="form-control" placeholder="Enter Your Name"></asp:TextBox>
            </div>
            <label class="col-xs-11" style="color:white">Email:</label>
            <div class="col-xs-11">
                <asp:TextBox ID="txtEmail" runat="server" Class="form-control" placeholder="Enter Your Email"></asp:TextBox>
            </div>
            <label class="col-xs-11"></label>
            <div class="col-xs-11">
                <asp:Button ID="txtsignup" Class="btn btn-success" runat="server" Text="SignUP" OnClick="txtsignup_Click" />
            </div>
        </div>
         <!---signup page end--->
        <hr />
        <footer class="footer-pos" >
            <div class="alert alert-danger ">
                <p class="pull-right"><a href="#">Back to top</a></p>
                <p>&copy; 2022 VivekPashte.in &middot; <a href="Userhome.aspx">Home</a>&middot;<a href="About.aspx">About</a>&middot;<a href="#">Contact</a></p> 
            </div>
        </footer>
        </form>
</body>
</html>