<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="oneceagain.WebForm3" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> SignIn</title>
    <script src="https://code.jquery.com/jquery-3.6.1.js" integrity="sha256-3zlB5s2uwoUzrXK3BT7AX3FyvojsraNFxCc2vC/7pNI=" crossorigin="anonymous"></script>    
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta http-equiv="X-UA-Compatible" content="Google Chrome" />
    <link href="css/Custome.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</head>
<body style="background-image:url(imglogin.jpg)">
    <form id="form1" runat="server">
        <div>
            <div class="navbar navbar-default navbar-fixed-top" role="navigation"> 
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
                            <li ><a href="Userhome.aspx">Home</a></li>
                            <li ><a href="About.aspx" >About Us</a></li>                            
                            <li class="drodown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown">Type<b class="caret"></b></a>
                                <ul class="dropdown-menu">
                                    <li><a href="#" >Category</a> </li>
                                    <li><a href="#">Category</a> </li>
                                    <li><a href="#">Category</a> </li>
                                </ul>
                            </li>
                            <li>
                                <button class="btn btn-primary navbar-btn" type="button" >Cart <span class="badge" id="pCount" runat="server"></span></button>
                            </li>
                            <li>
                                <asp:Button ID="btnsingup" CssClass="btn btn-default navbar-btn" runat="server" Text="Registration"   PostBackUrl="~/SignUp.aspx" />
                            </li>
                            <li>
                                <asp:Button ID="Button1" CssClass="btn btn-default navbar-btn" runat="server" Text="LogIn" PostBackUrl="~/SignIn.aspx" />
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <br />
        <br />
        <div class ="container ">
            <div class ="form-horizontal " >
                <h2 style="color:white" >Login Form</h2>
                <hr />
                <div style="margin: auto;border: 2px solid black;background-color: rgba(0,0,0,0.5);border-radius: 5px; " >                    <br />
                    <br />
                    <div class ="form-group">
                        <asp:Label ID="Label1" CssClass ="col-md-2 control-label " style="color: white;" runat="server" Text="UserName"></asp:Label>
                        <div class ="col-md-3 ">
                            <asp:TextBox ID="txtUsername" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserName" runat="server" CssClass ="text-danger " ErrorMessage="*plz Enter Username" ControlToValidate="txtUsername" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>                    
                    <div class ="form-group">
                        <asp:Label ID="Label2" CssClass ="col-md-2 control-label " style="color: white;" runat="server" Text="Password"></asp:Label>
                        <div class ="col-md-3 ">
                            <asp:TextBox ID="txtPass" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPass" CssClass ="text-danger " runat="server" ErrorMessage="*the password field is required" ControlToValidate="txtPass" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>                    
                    <div class ="form-group">
                        <div class ="col-md-2 "> </div>
                        <div class ="col-md-6 ">
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                            <asp:Label ID="Label3" CssClass =" control-label " style="color: white;" runat="server" Text="Remember me"></asp:Label>
                        </div>
                    </div>
                    <div class ="form-group">
                        <div class ="col-md-2 "> </div>
                        <div class ="col-md-6 ">
                            <asp:Button ID="btnLogin" CssClass ="btn btn-success " runat="server" Text="Login&raquo;" OnClick="btnLogin_Click"  />
                            <asp:HyperLink ID="HyperLink1" runat="server" style="color: red;" NavigateUrl="~/SignUp.aspx">Sign Up</asp:HyperLink>
                        </div>
                    </div>
               </div>
            </div>           
        </div>
        <footer class="footer-pos" >
            <div class="alert alert-danger ">
                <p class="pull-right"><a href="#">Back to top</a></p>
                <p>&copy; 2022 VivekPashte.in &middot; <a href="Userhome.aspx">Home</a>&middot;<a href="About.aspx">About</a>&middot;<a href="#">Contact</a></p> 
            </div>
        </footer>
    </form>
</body>
</html>