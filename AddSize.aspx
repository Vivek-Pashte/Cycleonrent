<%@ Page Title="" Language="C#" MasterPageFile="~/adminmaster.Master" AutoEventWireup="true" CodeBehind="AddSize.aspx.cs" Inherits="oneceagain.AddSize" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class ="container ">
        <div class ="form-horizontal ">
            <br />
            <br />            
            <h2>Add Size</h2>
            <hr />           
            <div class ="form-group">
                <asp:Label ID="Label1" CssClass ="col-md-2 control-label " runat="server" Text="Size Name"></asp:Label>
                <div class ="col-md-3 ">
                    <asp:TextBox ID="txtSize" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorSize" runat="server" CssClass ="text-danger " ErrorMessage="*plz Enter Size" ControlToValidate="txtSize" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>            
            <div class ="form-group">
                <asp:Label ID="Label3" CssClass ="col-md-2 control-label " runat="server" Text="Brand"></asp:Label>
                <div class ="col-md-3 ">
                    <asp:DropDownList ID="ddlBrand" CssClass ="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorddlBrand" runat="server" CssClass ="text-danger " ErrorMessage="*plz Enter Brand" ControlToValidate="ddlBrand" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>            
            <div class ="form-group">
                <asp:Label ID="Label4" CssClass ="col-md-2 control-label " runat="server" Text="Category"></asp:Label>
                <div class ="col-md-3 ">
                    <asp:DropDownList ID="ddlCategory" CssClass ="form-control" runat="server" ></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCategory" runat="server" CssClass ="text-danger " ErrorMessage="*plz Enter  Category" ControlToValidate="ddlCategory" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>            
            <div class ="form-group">
                <div class ="col-md-2 "> </div>
                <div class ="col-md-6 ">
                    <asp:Button ID="btnAddSize" CssClass ="btn btn-success " runat="server" Text="Add Size" OnClick="btnAddSize_Click"  />
                </div>
            </div>
        </div>        
        <h1>Size</h1>
        <hr />        
        <div class="panel panel-default">
            <div class="panel-heading"> All Sizes</div>            
            <asp:repeater ID="rptrSize" runat="server">
                <HeaderTemplate>
                    <table class="table table-hover">
                        <thead>
                            <tr>
                                <th>No.</th>
                                <th>Size( in inch)</th>
                                <th>Brand</th>
                                <th>Category</th>                                 
                                <th>Edit</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th> <%# Eval("SizeID") %> </th>
                        <td><%# Eval("SizeName") %>'</td>
                        <td><%# Eval("Name") %>   </td>
                        <td><%# Eval("CartName") %>   </td>
                        <td><a href="EditSize.aspx" style="text-decoration:none;">Edit</a></td>
                    </tr>
                </ItemTemplate>                
                <FooterTemplate>
                    </tbody>
                    </table>
                </FooterTemplate>
            </asp:repeater>
        </div>
    </div>
</asp:Content>