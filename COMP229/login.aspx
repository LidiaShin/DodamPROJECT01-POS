<%@ Page Title="" Language="C#" MasterPageFile="~/COMP229.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="COMP229.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<span class="menu">SignIn</span> <hr />
 <table style="width: 40%;">

  <tr>
  <td>Email:</td>
  <td><asp:TextBox ID="eMail" runat="server"></asp:TextBox> </td>
  </tr>



  <tr>
  <td>Password:</td>
  <td><asp:TextBox ID="pWord" runat="server"></asp:TextBox> </td>
  </tr>

  </table>


	

<asp:Button ID="btn" runat="server" Text="SignIn" CssClass="btn" OnClick="btn_Click"  /> <br />
<asp:CheckBox ID="CheckBox" runat="server" Text="Keep SignIn" /> 
</asp:Content>
