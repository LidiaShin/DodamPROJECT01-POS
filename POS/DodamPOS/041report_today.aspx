<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="041report_today.aspx.cs" Inherits="DodamPOS._041report_today" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="height:100%;">
<head runat="server">
    <title>Today's Sales Report</title>
	<link href="css/poscss.css" rel="stylesheet" type="text/css" />
</head>
	<body id="container_newwindow">
    <form id="form1" runat="server">


<h2>Sales Report </h2><hr />

<div style="width:100%; height:530px;  ">

<!-- FOR TODAY --> 
<p style="font-size:17px; color:aquamarine">TODAY</p> 
<div style="width:100%;  border-bottom:1px solid yellow; height:45%;  display: flex; flex-wrap: wrap;">

<!-- 1. SUMMARY --> 
<div style="width:40%;    " >
		<p style="font-size:14px; color:deepskyblue" > SALES SUMMARY</p>
	
	<asp:GridView ID="ReportA" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="300px" Font-Size="Large">
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
	</asp:GridView> <br />
</div>

<!-- 2. TOP ITEM --> 
<div style="width:32%;     "> 
        <p style="font-size:14px; color:deepskyblue">TOP 10 SELLING ITEMS</p>

	<asp:GridView ID="ReportB" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="240px" Font-Size="Small">
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


<!-- 3. TOP 5 CUSTOMER --> 
<div style="width:28%;    "> 
        <p style="font-size:14px; color:deepskyblue">TOP 5 CUSTOMER</p>
	<asp:GridView ID="ReportC" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Size="Small" Width="200px">
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
</div>



<!--  PAST 7 DAYS --> 
<p style="font-size:17px; color:aquamarine">PAST 7 DAYS</p> 
<div style="width:100%;  height:45%;  display: flex; flex-wrap: wrap;">

<!-- 1. SUMMARY --> 
<div style="width:40%;  "> 		
			<p style="font-size:14px; color:deepskyblue" > SUMMARY </p>


	<asp:GridView ID="ReportD" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="300px" Font-Size="Small">
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


<!-- 2. TOP ITEM --> 
<div style="width:32%;  "> 		
        <p style="font-size:14px; color:deepskyblue"> TOP 10 SELLING ITEMS </p>
	<asp:GridView ID="ReportE" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="240px">
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

<!-- 3. TOP CUSTOMER --> 
<div style="width:28%;  "> 		
        <p style="font-size:14px; color:deepskyblue"> TOP 5 CUSTOMER </p>
	<asp:GridView ID="ReportF" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="200px">
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


	<asp:Button ID="btnClose" runat="server" Text="CLOSE" CssClass="CloseBtn" OnClientClick="javascript:window.close();"  />&nbsp;&nbsp;
</div>
</div>
  
</form>
</body>
</html>
