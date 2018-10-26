<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="041report_today.aspx.cs" Inherits="DodamPOS._041report_today" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="height:100%;">
<head runat="server">
    <title>Today's Sales Report</title>
	<link href="css/poscss.css" rel="stylesheet" type="text/css" />
</head>
	<body id="container_newwindow">
    <form id="form1" runat="server">


		<h2>Today's Sales Report </h2><hr />

<div style="width:100%;  height:500px; display: flex; flex-wrap: wrap; border:1px solid pink;">
	<br />
		<div style="width:60%;  height:97%; border:1px solid yellow;" >

		<p style="font-size:16px; color:aquamarine">TODAY</p>
		<p> A. SALES STATUS (EACH CATEGORY)</p>
			<asp:GridView ID="ReportA" runat="server"></asp:GridView>

		<p> B. SALES STATUS (TOTAL) </p>
			<asp:GridView ID="ReportB" runat="server"></asp:GridView>

		
		</div>

		<div style="width:37%;  margin-left:10px; height:97%; border:1px solid yellow; "> 


		<p style="font-size:16px; color:aquamarine">PAST 7 DAYS</p>
		<p> C.SALES STATUS (EACH CATEGORY) </p>
			<asp:GridView ID="ReportC" runat="server"></asp:GridView>

        <p> D.SALES STATUS  (TOTAL) </p>
			<asp:GridView ID="ReportD" runat="server"></asp:GridView>


		<p> D. ITEM CHART TODAY </p>

		<p> E. ITEM CHART FOR PREVIOUS 7 DAYS </p>

		</div>

</div>




        
    </form>
</body>
</html>
