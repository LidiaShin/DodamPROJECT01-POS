<%@ Page Title="" Language="C#" MasterPageFile="~/COMP229.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="COMP229.index" Theme="comp229" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<!DOCTYPE html>

 <span class="menu">Signup</span> <hr />
 <table style="width: 40%;">
  <tr>
  <td>UserName:</td>
  <td><asp:TextBox ID="uName" runat="server"></asp:TextBox> </td>
  </tr>


  <tr>
  <td>Email:</td>
  <td><asp:TextBox ID="eMail" runat="server"></asp:TextBox> <asp:Label ID="emailcheck" runat="server" Text=""></asp:Label></td>
	  
  </tr>



  <tr>
  <td>Password:</td>
  <td><asp:TextBox ID="pWord" runat="server"></asp:TextBox> </td>
  </tr>

  </table>

	<asp:Button ID="btn" runat="server" Text="Create" OnClick="btn_Click" CssClass="btn"  />
	<asp:Label ID="Result" runat="server" Text=""></asp:Label>

</asp:Content>
