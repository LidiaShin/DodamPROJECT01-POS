<%@ Page Title="" Language="C#" MasterPageFile="~/pos.Master" AutoEventWireup="true" CodeBehind="000home.aspx.cs" Inherits="DodamPOS._000home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table>
<tr>
<td style="width:100px;"><h3>Home</h3></td>
<td style="width:460px; color:antiquewhite"> Please click menu button left above to start </td>
<td><asp:Button ID="BtnLogOut" runat="server" Text="LOGOUT" CssClass="CloseBtn" OnClick="BtnLogOut_Click" /></td>
</tr>
</table>
<hr />
<br /><br />


<div style="width:60%; margin-left:10px; height:300px; display: flex; flex-wrap:wrap; ">




<div style="display:flex;  width:100%; height:100%; flex-wrap:wrap; ">

<div style="width:100%;height:10%" >
<span style="color:yellow; font-size:20px;">WELCOME!</span>
</div>

<div style="width:70%; height:70%;  ">
<ul class="mainul">

<li class="mainli"><span class="sub">POS </span> Check out order items, print and send email receipt to customer </li> 
<li class="mainli"><span class="sub">ITEM </span>Add new item, see details and update with images </li>
<li class="mainli"><span class="sub">CUSTOMER </span>Add new customer, see details and update info </li>
<li class="mainli"><span class="sub">REPORT </span>Sales report and invoice list available </li>
<li class="mainli"><span class="sub">ABOUT </span> About me (developer) and this app :) </li>
</ul>
</div>


<div style="width:30%; height:70%; padding-top:20px; ">
<asp:Image ID="SnowCat" runat="server" ImageUrl="~/img/POS.jpeg
	" Width="150px" Height="150px" />
</div>

</div>



</div>
</asp:Content>
