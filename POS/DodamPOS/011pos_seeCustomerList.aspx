<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="011pos_seeCustomerList.aspx.cs" Inherits="DodamPOS._011pos_seeCustomerList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="height:100%;">
<head runat="server">
    <title></title>
	<link href="css/poscss.css" rel="stylesheet" type="text/css" />
	<script src="js/posjs.js"></script>
</head>
	<body id="container_newwindow">
    <form id="form1" runat="server">



<h2>Select Customer</h2><hr /><br />
<div style="height:200px; overflow:auto;">

    <table style="width:100%; border-collapse: collapse; border-spacing: 0; text-align:left; position:center; ">   
	   <tr style="font-size:20px;" class="ListHeader">
       <th style="width:10%; ">No</th>
       <th style="width:35%;">Name</th>
       <th style="width:35%;">E-Mail</th>
       <th style="width:20%;">City</th>
       </tr>
	</table>


<asp:DataList ID="CustomerList" runat="server" RepeatDirection="Vertical">

<ItemTemplate>

<table style="width:100%; border-spacing: 0;  position:center; ">

	<tr style="font-size:16px;" onmouseover="this.style.backgroundColor='rgba(184,191,209, 0.6)'" onmouseout="this.style.backgroundColor=''">		
    
	<td style="width:60px; text-align:center;"><asp:Label ID="lblCustomerID" runat="server" Text='<%# Eval("NO") %>' /></td>
    
	<td style="text-align:left; width:240px "><asp:LinkButton ID="lkCustomerName" runat="server" Text ='<%# Eval("NAME") %>' CommandArgument='<%# Eval("NAME")+ ";" +Eval("NO")%>' Font-Overline="false" ForeColor="White"  
		onmouseover="this.style.color='red'" onmouseout="this.style.color='white'" OnClick="SelectName"  /></td>

    <td style="width:240px; text-align:left; "><asp:Label ID="lblCustomerEmail" runat="server" Text ='<%# Eval("E-MAIL") %>' /></td>
    
	<td  style="width:100px; text-align:left; "><asp:Label ID="lblCity" runat="server" Text='<%# Eval("CITY") %>' /></td>
	</tr>
</table>


</ItemTemplate>
</asp:DataList>
</div>	
		
<!-- HIDDEN INPUT FOR SENDING CHOSEN CUSTOMER NAME ON LABEL -->		
<input id="CustomerSelection" type="text" runat="server"  hidden="hidden" />
<input id="CustomerNo" type="text" runat="server"  hidden="hidden" />

</form>
</body>
</html>
