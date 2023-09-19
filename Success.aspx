<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Success.aspx.cs" Inherits="oneceagain.Success" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Order Placed</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
         <div>
             <div class="container">
                 <div class="center">
                     <br />
                     <br />
                     <br />
                     <br />
                     <br />                    
                     <h1>Congrats! Order Placed Successfully...</h1>
                     <br />
                     <br />
                     <br />
                     <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Font-Size="Large" Text="Back To Products" OnClick="Button1_Click" />
                     <br />
                 </div>
             </div>
         </div>
     </div>
</asp:Content>