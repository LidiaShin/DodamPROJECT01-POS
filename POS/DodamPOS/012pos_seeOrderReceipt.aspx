<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="012pos_seeOrderReceipt.aspx.cs" Inherits="DodamPOS._012pos_seeOrderReceipt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="height:100%;">
<head runat="server">
    <title></title>
	<link href="css/poscss.css" rel="stylesheet" type="text/css" />
	<script src="js/posjs.js"></script>
</head>
	<body id="container_newwindow">
    <form id="form1" runat="server">

<div>

<!-- (1) NAME + DATE --> 
<div id="header" style="width:100%">
<h2>Customer Receipt </h2> 
<p style="text-align:right; font-size:14px; "> 
Invoice # :<asp:Label ID="lblONum" runat="server" Text="ORDER NUM"  ></asp:Label>
Customer: <asp:Label ID="lblCName" runat="server" Text="CUSTOMER NAME"  ></asp:Label>
Customer# : <asp:Label ID="lblCNum" runat="server" Text=""></asp:Label>
Email: <asp:Label ID="lblCEmail" runat="server" Text=""></asp:Label>
Date: <asp:Label ID="lblOrderDate" runat="server" Text="DATE" ></asp:Label> 
</p>
<hr /> <br />
</div>
       
<!-- (2) RECEIPT TABLE (GRID VIEW) --> 
<div id="receipt" style ="display:block; width:100%; height:170px; overflow:auto;  margin-bottom:5px;"> 

	<asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCreated = "RowCreate" Width="100%"  >
		<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>

		<EditRowStyle BackColor="#999999"></EditRowStyle>

		<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

		<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

		<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

		<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

		<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

		<SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>

		<SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>

		<SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>

		<SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>
	</asp:GridView>
</div>

<!-- (3) TOTAL FIELD --> 

<div id="total" style="width:100%; padding-left:70%; height:30%; margin-bottom:3px; font-size:14px; display:block; ">

<table>
<tr>
<td>Total Sales Qty :</td>
<td><asp:Label ID="lblTQty" runat="server" Text="1"></asp:Label></td> 
</tr>

<tr>
<td>Total Amount:</td>
<td><asp:Label ID="lblTAmt" runat="server" Text="2"></asp:Label></td>
</tr>

<tr>
<td>Total Tax: </td>
<td><asp:Label ID="lblTTax" runat="server" Text="3"></asp:Label></td>
</tr>
</table>

<table style="border-top:1px solid lavender;" >
<tr>
<td style="font-weight:600; font-size:large">Grand Total :</td>
<td><asp:Label ID="lblGTotal" style="font-weight:700; font-size:large; color:yellow; " runat="server" Text="4"></asp:Label></td>
</tr>
</table>
</div>

<!-- (4) BUTTONS FIELD --> 

<div style="display: block; width:100%; padding-right:20px;">
<table>
<tr>
<td><asp:Button ID="btnPrint" runat="server" Text="PRINT OUT" CssClass="RegisterBtn"   BackColor="#FF9966"  OnClientClick="PrintReceipt('header','receipt','total');" value=" Print"/> </td>
<td><asp:Button ID="btnEmail" runat="server" Text="SEND EMAIL" CssClass="RegisterBtn" OnClick="btnEmail_Click"   /> </td>
<td><asp:Button ID="btnClose" runat="server" Text="CLOSE" CssClass="RegisterBtn" OnClientClick="javascript:window.close();" /></td>
</tr>
</table>
</div>


</div>



</form>
</body>
</html>
