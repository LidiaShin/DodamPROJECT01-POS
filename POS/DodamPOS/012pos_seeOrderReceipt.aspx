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
<p style="text-align:right;"> 

Invoice # :<asp:Label ID="lblONum" runat="server" Text="ORDER NUM" Font-Size="Large" ></asp:Label>
Customer: <asp:Label ID="lblCName" runat="server" Text="CUSTOMER NAME" Font-Size="Large" ></asp:Label>

</p>
       
<div style="width:90%;  height:280px; margin:2px auto 5px auto; border:1px solid yellow;">

<!-- (1) RECEIPT FIELD --> 
<div style="display:block; border:1px solid red; height:60%; overflow:auto;"> 

 <table style="border-collapse: collapse; width:100%; border-spacing: 0; text-align:left; position:center; ">   
	   <tr style="font-size:14px;" class="ListHeader">
	   <th style="width:5%">Code</th>
       <th style="width:40%">Item Name</th>       
       <th style="width:15%">Price</th>
	   <th style="width:10%">Qty</th>
	   <th style="width:20%">Amount</th>
	   <th style="width:10%;">Tax</th>
       </tr>


	   <tr><td> NUMBER + CONTENTS</td></tr>
</table>

</div>

<!-- (2) TOTAL FIELD --> 
<div style="display:block; border:1px solid red; ">
Total Sales Qty : <br />
Total Amount : <br />
Total Tax: <hr style="color:lightyellow" />
Grand Total
</div>

<!-- (3) BUTTONS FIELD --> 

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
