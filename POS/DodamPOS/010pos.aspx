<%@ Page Title="" Language="C#" MasterPageFile="~/pos.Master" AutoEventWireup="true" CodeBehind="010pos.aspx.cs" Inherits="DodamPOS._001pos" EnableViewState="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!-- TITLE MENU --> 
	<table>
	<tr>
	<td style="width:200px;"><h3>Point Of Sales</h3></td>
	</tr>
	</table>
	<hr />

<br />

<!-- MAIN MENU : ITEM LIST SECTION (LEFT 40%) + CART LIST SECTION (RIGHT 50%) --> 
<div style="width:95%;  display: flex; flex-wrap: wrap;">
	
<!-- ITEM LIST SECTION-->
<div style="width:40%;  height:380px;" >

<!-- CATEGORY BUTTONS -->
<div>	
<asp:Button ID="CatAll" runat="server" ClientIDMode="Static" Text="All" CommandArgument="All" OnClick="SelectCat" CssClass="CatBtn" />
<asp:Button ID="CatGarment" runat="server" ClientIDMode="Static" Text="MEAL" CommandArgument="MEAL" OnClick="SelectCat" CssClass="CatBtn" />
<asp:Button ID="CatMagic" runat="server" ClientIDMode="Static" Text="SNACK" CommandArgument="SNACK" OnClick="SelectCat" CssClass="CatBtn" />
<asp:Button ID="CatWeapon" runat="server" ClientIDMode="Static" Text="DRINK" CommandArgument="DRINK" OnClick="SelectCat" CssClass="CatBtn" />
<asp:Button ID="CatFood" runat="server" ClientIDMode="Static" Text="BEAUTY" CommandArgument="BEAUTY" OnClick="SelectCat" CssClass="CatBtn" />
<asp:Button ID="CatArmor" runat="server" ClientIDMode="Static" Text="ETC" CommandArgument="ETC" OnClick="SelectCat" CssClass="CatBtn"  />
<asp:Label ID="CatSelect" runat="server" Text="All" Visible="false"  ></asp:Label>
</div>
<br />
	
<!-- ITEM IMAGE + PRICE + QTY DISPLAY -->
<div>
<asp:DataList ID="itemLists"  RepeatDirection="Vertical" RepeatColumns="4" runat="server" >

  <ItemTemplate>

     <asp:Label ID="itemName" runat="server" Text='<%# Eval("Name") %>' Style="font-size:12px; color:#faf8f2;" Width="120px" height="20px" /><br />	  
	 
	 <asp:ImageButton ID="itemImage" runat="server" ImageUrl='<%# Eval("URL") %>' CommandArgument='<%# Eval("NO") %>' OnClick="SelectItem" Width="60px" Height="60px"  ValidateRequestMode="Inherit" CausesValidation="False" /> <br />
	 
	 <asp:Label ID="itemPrice" runat="server" Text= '<%# Eval("RetailPrice") %>' Style="font-size:15px; font-weight:600;"  /> 
	 
	
	 <asp:Label ID="lblStock" runat="server" Text="stock"  style="font-size:14px; display:block;  "></asp:Label> 
	 
	 <asp:DropDownList ID="itemQtydll" runat="server" DataSource='<%# Stock((int)Eval("Quantity")) %>'  OnSelectedIndexChanged="SelectCartQty"  AutoPostBack="True" CssClass="QtyInputDll">		 
	 </asp:DropDownList>
	 
	  <asp:Label ID="HdnQtySelect" runat="server"   Visible="false"></asp:Label> 
  </ItemTemplate>
	   
</asp:DataList>
</div>


<!-- DATA PAGER -->
	<table style="margin-right:auto; margin-left:auto;">
        <tr>
            <td><asp:LinkButton ID="BtnPrevious" runat="server" onclick="LinkButton2_Click" CssClass="ItemDataPager"> Previous</asp:LinkButton></td>
			<td>&nbsp&nbsp&nbsp&nbsp</td>
            <td><asp:LinkButton ID="BtnNext" runat="server" onclick="LinkButton3_Click" CssClass="ItemDataPager"> Next</asp:LinkButton></td>
        </tr>
    </table>  
</div>


<!-- CART SECTION -->
<div style="width:50%;  margin-left:20px; overflow:auto; height:380px; "> 



<!-- 1) CUSTOMER DISPLAY DIV -->
<div style="display: block;">

<!-- SEARCH BOX & BUTTON -->

Customer  <asp:Label ID="lblCustomerName" runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"  CssClass="DisplayCustomerInfo"  Width="270px"></asp:Label>&nbsp;&nbsp;
No <asp:Label ID="lblCustomerNumber" runat="server" Text="-" CssClass="DisplayCustomerInfo" Width="40px"></asp:Label>

<asp:Button ID="BtnSearch" runat="server" Text="GO"  CssClass="GoBtn"   OnClick="SearchCustomer" style="float:right;" /> 
<input type="text" id="SearchBox" Class="SearchCustomerBox" runat="server" style="float:right;"  placeholder="Find Customer" > 

<!--HIDDEN BUTTON + INPUT FOR GETTING VALUE -->

<asp:Button ID="BtnHdn" runat="server" OnClick="convert" ClientIDMode="Static" CssClass="hidden" />
<input id="HdnCName" runat="server"  ClientIDMode="Static" hidden="hidden"> 
<input id="HdnCNum" runat="server"  ClientIDMode="Static" hidden="hidden"> 
	
<br />
</div>
<hr /> <br />

<!-- 2) CART TABLE DIV -->
<div style="display: block;   overflow:auto;  height:50%">

	<asp:GridView ID="GridView1"  runat ="server" OnRowDeleting="RowDelete" OnRowCreated = "RowCreate"   HeaderStyle-CssClass="ListHeader">
		<Columns>
			<asp:CommandField ShowDeleteButton="True" DeleteText="Cancel" ButtonType="Button" ItemStyle-ForeColor="#CCCCFF" ControlStyle-CssClass="CancelBtn" ></asp:CommandField>
		</Columns>
	</asp:GridView>
</div>

<!-- 3) NET TOTAL + GRAND TOTAL DIV -->
<div style="display: block; border-top:1px solid yellow;">
<table style="float:right;">

<tr>
<td><asp:Label ID="lblNetTotal" runat="server" Text="Net Total"  Font-Italic="True"></asp:Label> &nbsp; &nbsp; &nbsp;</td> 
<td><asp:Label ID="subTotal" runat="server" Text="0" CssClass="DisplayTotalInfo" Width="150px"  ></asp:Label></td>
</tr>

<tr>
<td><asp:Label ID="lblGrandTotal" runat="server" Text="Grand Total" ForeColor="White"  Font-Italic="True"></asp:Label> &nbsp; &nbsp; &nbsp; </td>
<td><asp:Label ID="grandTotal" runat="server" Text="0" CssClass="DisplayTotalInfo" Width="150px" ></asp:Label></td>
</tr>

<tr>

<td><asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
<td><asp:Button ID="BtnCheckOut" runat="server" Text="CHECK OUT" onclick="CheckOut"  CssClass="loginBtn" Width="200px" /></td>
</tr>

</table>	
</div>

</div>
	
	
</div>

</asp:Content>
