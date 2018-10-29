<%@ Page Title="" Language="C#" MasterPageFile="~/pos.Master" AutoEventWireup="true" CodeBehind="040report.aspx.cs" Inherits="DodamPOS._004report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<!-- TITLE MENU --> 
	<table>
	<tr>
	<td style="width:180px;"> <h3>Invoice & Report </h3></td>
	<td style="width:280px; color:antiquewhite"> Please click order number to see details </td>
	<td><asp:Button ID="BtnDailyReport" runat="server" Text="REPORT" CssClass="AddNewBtn" OnClick="BtnDailyReport_Click" /></td>
	</tr>
	</table>	
    <hr />

	<br /><br />

	 
<div style="width:90%;">
<asp:Label ID="TEST" runat="server" Text=""></asp:Label>

<!-- INVOICE LIST BOARD -->
<asp:ListView ID="InvoiceList" runat="server" GroupPlaceholderID="groupPlaceHolder1" ItemPlaceholderID="itemPlaceHolder1" OnPagePropertiesChanging="OnPagePropertiesChanging">

<LayoutTemplate>

	 <!--(2) TABLE FOR  BOARD HEADER + PLACEHOLDER + PAGER -->
	 <table style="width:100%; border-collapse: collapse; border-spacing: 0; text-align:left; position:center; ">
       
     <!--(3) HEADER -->
	   <tr class="ListHeader">
	   <th style="width:40px;">ORDER</th>
       <th style="width:70px;">	NO</th>
       
       <th style="width:60px;">NAME</th>
       <th style="width:60px;">QTY</th>
       <th style="width:120px;">NET</th>
	   <th style="width:120px;">GROSS</th>
		<th style="width:150px;">DATE</th>
       </tr>
        
	 <!--(4) PLACE HOLDER -->
	   <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>

	   <tr><td colspan = "7">

	   <hr style="border: 0;height:0;border-top: 1px solid rgba(0, 0, 0, 0.1);border-bottom: 1px solid rgba(255, 255, 255, 0.3);">

    <!--(5) DATA PAGER -->
	   <asp:DataPager ID="DataPager1" runat="server" PagedControlID="InvoiceList" PageSize="15" >
	      <Fields>
          <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true" ShowNextPageButton="false" ButtonCssClass="DataPager" />
          <asp:NumericPagerField ButtonType="Link" NumericButtonCssClass="DataPager" />
          <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton = "false"  ButtonCssClass="DataPager" />		  
          </Fields>
			
        </asp:DataPager>
		   &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

		 </td></tr>
	   </table>	 
</LayoutTemplate>

	  <GroupTemplate>	
      <tr><asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder></tr>
      </GroupTemplate>
  
<ItemTemplate>
	  
	
	  <tr style="font-size:14px; text-align:center;" onmouseover="this.style.backgroundColor='rgba(184,191,209, 0.6)'" onmouseout="this.style.backgroundColor=''">
	
		   <td><asp:LinkButton ID="lkONum" runat="server" Text ='<%# Eval("ORDERNO") %>' CommandArgument='<%# Eval("ORDERNO") %>' Font-Overline="false" ForeColor="White"  
		    onmouseover="this.style.color='pink'" onmouseout="this.style.color='white'" OnClick ="SeeOrderDetail"/></td>

           <td><asp:Label ID="lblCNum" runat="server" Text ='<%# Eval("CUSTOMERNO") %>' /></td>

		  

		   <td><asp:Label ID="lblCName" runat="server" Text='<%# Eval("NAME") %>' /></td>

		   <td><asp:Label ID="lblQty" runat="server" Text='<%# Eval("QTY") %>' /></td>
           <td><asp:Label ID="lblNet" runat="server" Text='<%# Eval("NET") %>' /></td>
		   <td><asp:Label ID="lblGross" runat="server" Text='<%# Eval("GROSS") %>' /></td>
		   <td><asp:Label ID="lblODate" runat="server" Text ='<%# Eval("ORDERDATE") %>' /></td>
          
      </tr>

	 
</ItemTemplate> 
</asp:ListView>

</div>

 <!--SEARCH WINDOW -->
		   <asp:DropDownList ID="SearchDDL" runat="server" CssClass="SearchInput" AppendDataBoundItems="True" AutoPostBack="True" >
		   <asp:ListItem Text="- Select  - " Selected="True" Value=""></asp:ListItem>
		   </asp:DropDownList>

		   <asp:TextBox ID="keywordbox" runat="server" CssClass="SearchInput" ></asp:TextBox>
		    &nbsp; &nbsp;

	        <!--SEARCH BUTTON -->
		   <asp:Button ID="BtnSearch" runat="server" Text="SEARCH" CssClass="SearchBtn"  OnClick="SearchReceipt" />

















</asp:Content>
