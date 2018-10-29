<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="042report_orderdetail.aspx.cs" Inherits="DodamPOS._042report_orderdetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="height:100%;">
<head runat="server">
    <title>Order Detail</title>
	<link href="css/poscss.css" rel="stylesheet" type="text/css" />
</head>
	<body id="container_newwindow">

    <form id="form1" runat="server">
       <h2>Order Detail</h2><hr />

		<p style="text-align:right;"> ORDER #<asp:Label ID="lblONum" runat="server" Text="" Font-Size="Medium"></asp:Label> </p>
		Customer : <asp:Label ID="lblCInfo" runat="server" Text=""></asp:Label><br />
		Date: <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
		<br /><br /><br />


<!-- (2) RECEIPT TABLE (GRID VIEW) --> 
<div id="receipt" style ="display:block; width:100%; height:150px; overflow:auto;  margin-bottom:5px;"> 

		<asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCreated = "RowCreate" Width="100%" >
			<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

			<EditRowStyle BackColor="#7C6F57"></EditRowStyle>

			<FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White"></FooterStyle>

			<HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White"></HeaderStyle>

			<PagerStyle HorizontalAlign="Center" BackColor="#666666" ForeColor="White"></PagerStyle>

			<RowStyle BackColor="#E3EAEB"></RowStyle>

			<SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

			<SortedAscendingCellStyle BackColor="#F8FAFA"></SortedAscendingCellStyle>

			<SortedAscendingHeaderStyle BackColor="#246B61"></SortedAscendingHeaderStyle>

			<SortedDescendingCellStyle BackColor="#D4DFE1"></SortedDescendingCellStyle>

			<SortedDescendingHeaderStyle BackColor="#15524A"></SortedDescendingHeaderStyle>
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

    </form>
</body>
</html>
