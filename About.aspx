<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="oneceagain.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>About me Page</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <style>
        .jumbotron {
            background-color: #f4511e;
            color: #fff;
            padding: 100px 25px;
        }
        .container-fluid {
            padding: 60px 50px;
        }
        .bg-grey {
            background-color: #f6f6f6;
        }
        .logo-small {
            color: #f4511e;
            font-size: 50px;
        }
        .logo {
            color: #f4511e;
            font-size: 200px;
        }
        @media screen and (max-width: 768px) {
            .col-sm-4 {
                text-align: center;
                margin: 25px 0;
            }
        }
    </style>
    <script language="javascript" type="text/javascript">
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="jumbotron text-center">
    <h1>Cycle On Rent</h1> 
    </div>
    <!-- Container (About Section) -->
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-8">
                <h2>CYCLEONRENT is a one-stop destination which can fulfill all your cycle renting needs.</h2>           
                <p>Whether you are looking for a basic cycle for a fun weekend or want to practice cycling as a professional or looking
                   for a short ride or planning on including cycling as a part of your routine, you’ll find your pick here.One size never
                   fits all. We provide flexible plans with a range of cycles to carter the needs of all age group be its kids,
                   adolescent, men or women. Choose the plan that suits you best. We have everything from kids’ cycles to tandem and 
                   hybrid bikes. All the bicycles are owned by Cycle On Rent and regularly maintained by it at its service center.</p>      
                <asp:Button  class="btn btn-default btn-lg" ID="Button1" runat="server" Text="Get in Touch" onclick="Button1_Click" />
            </div>
            <div class="col-sm-4">
                <span class="glyphicon glyphicon-signal logo"></span>
            </div>
        </div>
    </div>
    <div class="container-fluid bg-grey">
        <div class="row">
            <div class="col-sm-4">
                <span class="glyphicon glyphicon-globe logo"></span>
            </div>
            <div class="col-sm-8">
                <h2>Our Values</h2>
                <h4><strong>MISSION:</strong>Cycle On Rent is an online rental solution for your bicycle needs.</h4>      
                <p><strong>VISION:</strong>  It caters to an online platform for all the bicycle lovers and cycle riders in India and 
                   provides hassle free bicycle renting experience.</p>
            </div>
        </div>
    </div>
    <br />
</asp:Content>