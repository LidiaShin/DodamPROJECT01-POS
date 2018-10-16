<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DodamPOS._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dodam POS System</title>
	<link href="css/poscss.css" rel="stylesheet" type="text/css" />
</head>
<body>
  <form id="form1" runat="server">
  <div class="wrapperpic">
 
  <div class="container">

 

  <h1>Dodam's POS System</h1> <hr />
  
  <table id="loginform">
  <tr> 
  <td><asp:TextBox ID="uname" runat="server" placeholder="UserName" CssClass="loginInput" ></asp:TextBox> </td>
  </tr>

  <tr>
  <td><asp:TextBox ID="pword" runat="server" placeholder="Password"  CssClass="loginInput" TextMode="Password"></asp:TextBox> </td>
  </tr>

  <tr>
  <td class="KeepSignIn"><asp:CheckBox ID="CheckBox" runat="server" Text="  Keep me signin" /></td>
  </tr>

  <tr>
  <td><asp:Button ID="btnlogin" runat="server" Text="Login" CssClass="loginBtn" OnClick="btnlogin_Click"/> </td>
  </tr>
  </table>
	   Developed by Dodam Shin 2018<br />
  
  </div> 

</div>
</form>
</body>
</html>
