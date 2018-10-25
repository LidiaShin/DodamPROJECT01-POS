<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="012pos_seeOrderReceipt.aspx.cs" Inherits="DodamPOS._012pos_seeOrderReceipt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="height:100%;">
<head runat="server">
    <title></title>
	<link href="css/poscss.css" rel="stylesheet" type="text/css" />
</head>
	<body id="container_newwindow">
    <form id="form1" runat="server">

<div>

<h2>Customer Receipt </h2><hr />

       
<div style="width:90%;  height:280px; margin:2px auto 5px auto; border:1px solid yellow;">

<!-- (1) NAME + DATE --> 
<div style="display:block; border:1px solid lightgreen; width:100%; "> 

<p style="text-align:right; font-size:14px;"> 
Invoice # :<asp:Label ID="lblONum" runat="server" Text="ORDER NUM"  ></asp:Label>
Customer: <asp:Label ID="lblCName" runat="server" Text="CUSTOMER NAME"  ></asp:Label>
Date: <asp:Label ID="lblOrderDate" runat="server" Text="DATE" ></asp:Label> 
</p>
</div>
<br />

<!-- (2) RECEIPT TABLE (GRID VIEW) --> 
<div style="display:block; border:1px solid lightgreen; width:100%; height:55%; overflow:auto;"> 

	<asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCreated = "RowCreate" Width="100%">
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
<br />
<div style="display:block; border:1px solid red; margin-bottom:5ppx; ">
Total Sales Qty : <asp:Label ID="lblTQty" runat="server" Text="1"></asp:Label><br />
Total Amount :<asp:Label ID="lblTAmt" runat="server" Text="2"></asp:Label> <br />
Total Tax: <asp:Label ID="lblTTax" runat="server" Text="3"></asp:Label>
<hr style="color:lightyellow" />
Grand Total : <asp:Label ID="lblGTotal" runat="server" Text="4"></asp:Label>
</div>

<!-- (4) BUTTONS FIELD --> 

<div style="display: block; margin-left:40%; border:1px solid white; ">
<asp:Button ID="btnPrint" runat="server" Text="PRINT OUT" CssClass="RegisterBtn"   BackColor="#FF9966" /> &nbsp;&nbsp;
<asp:Button ID="btnEmail" runat="server" Text="SEND EMAIL" CssClass="RegisterBtn"   /> &nbsp;&nbsp;
<asp:Button ID="btnClose" runat="server" Text="CLOSE" CssClass="RegisterBtn" OnClientClick="javascript:window.close();" />&nbsp;&nbsp;
</div>


</div>

</div>


</form>
</body>
</html>
