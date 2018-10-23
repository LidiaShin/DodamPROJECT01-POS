<%@ Page Title="" Language="C#" MasterPageFile="~/pos.Master" AutoEventWireup="true" CodeBehind="010pos.aspx.cs" Inherits="DodamPOS._001pos" EnableViewState="true" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<h3>Point Of Sales</h3><hr />
	<asp:Label ID="testlabel" runat="server" Text=""></asp:Label>
	<br />

	
<div style="width:95%;  display: flex; flex-wrap: wrap;">
	
<!-- 왼쪽  30% Section-->
<div style="width:35%;  height:380px; border: 1px solid yellow;" >

<br />
<div>	
<asp:Button ID="CatAll" runat="server" ClientIDMode="Static" Text="All" CommandArgument="All" OnClick="SelectCat" CssClass="CatBtn" />
<asp:Button ID="CatGarment" runat="server" ClientIDMode="Static" Text="Garment" CommandArgument="GARMENT" OnClick="SelectCat" CssClass="CatBtn" />
<asp:Button ID="CatMagic" runat="server" ClientIDMode="Static" Text="Magic" CommandArgument="MAGIC" OnClick="SelectCat" CssClass="CatBtn" />
<asp:Button ID="CatWeapon" runat="server" ClientIDMode="Static" Text="Weapon" CommandArgument="WEAPON" OnClick="SelectCat" CssClass="CatBtn" />
<asp:Button ID="CatFood" runat="server" ClientIDMode="Static" Text="Food" CommandArgument="FOOD" OnClick="SelectCat" CssClass="CatBtn" />
<asp:Button ID="CatArmor" runat="server" ClientIDMode="Static" Text="Armor" CommandArgument="ARMOR" OnClick="SelectCat" CssClass="CatBtn"  />
<asp:Label ID="CatSelect" runat="server" Text="All" Visible="false"  ></asp:Label>
</div>
	

<asp:DataList ID="itemLists"  RepeatDirection="Horizontal" RepeatColumns="4" runat="server" >

  <ItemTemplate>
     <asp:Label ID="itemName" runat="server" Text='<%# Eval("Name") %>' Width="100px" Style="font-size:11px" /><br />	  
	 <asp:ImageButton ID="itemImage" runat="server" ImageUrl='<%# Eval("URL") %>' CommandArgument='<%# Eval("NO") %>' OnClick="SelectItem" Width="50px" Height="50px"  ValidateRequestMode="Inherit" CausesValidation="False" /> <br />
	 <asp:Label ID="itemNo" runat="server" Text='<%# Eval("RetailPrice") %>' Style="font-size:13px; font-weight:600;"  /> 
	 
	 <asp:Label ID="QtySelect" runat="server" Text="" style="font-size:8px;"  ></asp:Label><br />
	 <asp:Label ID="Label1" runat="server" Text='<%# Eval("Quantity") %>' ForeColor="#33CC33" ></asp:Label>
	 <asp:DropDownList ID="itemQtydll" runat="server" DataSource='<%# Stock((int)Eval("Quantity")) %>'  OnSelectedIndexChanged="SelectCartQty"  AutoPostBack="True" CssClass="ProvinceInput">		 
	 </asp:DropDownList>
  </ItemTemplate>
	   
  </asp:DataList>

	<table>
        <tr>
            <td><asp:LinkButton ID="BtnPrevious" runat="server" onclick="LinkButton2_Click" CssClass="DataPager"> Previous</asp:LinkButton></td>
            <td><asp:LinkButton ID="BtnNext" runat="server" onclick="LinkButton3_Click" CssClass="DataPager"> Next</asp:LinkButton></td>
        </tr>
    </table>  
</div>


<!-- 오른쪽  50% Section-->
<div style="width:50%;  margin-left:20px; overflow:auto; height:380px; border: 1px solid yellow;"> 



<!-- 1) Customer Display div -->
<div style="display: block;  border: 1px solid yellow; ">

<!-- SEARCH BOX & BUTTON -->
<input type="text" id="SearchBox" Class="SearchInput" runat="server"  >
<asp:Button ID="BtnSearch" runat="server" Text="SEARCH"  CssClass="SearchBtn"  Width="60px"  OnClick="SearchCustomer" /> 


<!-- HIDDEN INPUT & BUTTON FOR DISPLAY CUSTOMER NAME ON LABEL -->

<asp:Button ID="BtnHdn" runat="server" OnClick="convert" ClientIDMode="Static" CssClass="hidden" />
<input id="IptHdn" runat="server"  ClientIDMode="Static" Class="lblCustomer" hidden="hidden"> <br />

Customer :<asp:Label ID="lblCustomerName" runat="server" Text="Customer Name Here" BackColor="#CC33FF"></asp:Label>

</div>

<!-- 2) Cart List div -->
<div style="display: block;  border: 1px solid white; overflow:auto;  height:280px;">

	<asp:GridView ID="GridView1"  runat ="server" OnRowDeleting="RowDelete" OnRowCreated = "RowCreate"   HeaderStyle-CssClass="ListHeader">
		<Columns>
			<asp:CommandField ShowDeleteButton="True" DeleteText="Cancel" ButtonType="Button" ItemStyle-ForeColor="#CCCCFF" ControlStyle-CssClass="CatBtn" ></asp:CommandField>
		</Columns>
	</asp:GridView>
</div>

<!-- 3) Net Total & Grand Total List div -->
<div style="display: block; border: 1px solid white;">
<asp:Label ID="lblNetTotal" runat="server" Text="Net Total" ForeColor="White"  Font-Italic="True"></asp:Label> &nbsp; &nbsp; &nbsp; 
<asp:Label ID="subTotal" runat="server" Text="0"  ForeColor="White" BackColor="#CC99FF" Width="100px"></asp:Label><br />

<asp:Label ID="lblGrandTotal" runat="server" Text="Grand Total" ForeColor="White"  Font-Italic="True"></asp:Label> &nbsp; &nbsp; &nbsp; 
<asp:Label ID="grandTotal" runat="server" Text="0"  ForeColor="White" BackColor="#CC00CC" Width="120px"></asp:Label>

<asp:Button ID="BtnCheckOut" runat="server" Text="TEST" onclick="CheckOut"  />
	<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
	
</div>

</div>
<br />
	
	
</div>

</asp:Content>
