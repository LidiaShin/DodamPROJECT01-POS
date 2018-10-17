<%@ Page Title="" Language="C#" MasterPageFile="~/pos.Master" AutoEventWireup="true" CodeBehind="010pos.aspx.cs" Inherits="DodamPOS._001pos" EnableViewState="true" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<h3>Point Of Sales</h3><hr />
	<asp:Label ID="testlabel" runat="server" Text=""></asp:Label>
	<br />

	
<div style="width:95%;  display: flex; flex-wrap: wrap;">

<div style="width:35%; border: 1px solid red; height:350px;" >
<div>	
<asp:Button ID="CatAll" runat="server" ClientIDMode="Static" Text="All" CommandArgument="All" OnClick="SelectCat" CssClass="CatBtn" />
<asp:Button ID="CatGarment" runat="server" ClientIDMode="Static" Text="Garment" CommandArgument="GARMENT" OnClick="SelectCat" CssClass="CatBtn" />
<asp:Button ID="CatMagic" runat="server" ClientIDMode="Static" Text="Magic" CommandArgument="MAGIC" OnClick="SelectCat" CssClass="CatBtn" />
<asp:Button ID="CatWeapon" runat="server" ClientIDMode="Static" Text="Weapon" CommandArgument="WEAPON" OnClick="SelectCat" CssClass="CatBtn" />
<asp:Button ID="CatFood" runat="server" ClientIDMode="Static" Text="Food" CommandArgument="FOOD" OnClick="SelectCat" CssClass="CatBtn" />
<asp:Button ID="CatArmor" runat="server" ClientIDMode="Static" Text="Armor" CommandArgument="ARMOR" OnClick="SelectCat" CssClass="CatBtn"  />
<asp:Label ID="CatSelect" runat="server" Text="All" Visible="false"  ></asp:Label>
</div>
<br />

<asp:DataList ID="itemLists"  RepeatDirection="Horizontal" RepeatColumns="4" runat="server" >

  <ItemTemplate>
     <asp:Label ID="itemName" runat="server" Text='<%# Eval("Name") %>' Width="100px" Style="font-size:11px" /><br />	  
	 <asp:ImageButton ID="itemImage" runat="server" ImageUrl='<%# Eval("URL") %>' CommandArgument='<%# Eval("NO") %>' OnClick="SelectItem" Width="50px" Height="50px"  /><br />
	 <asp:Label ID="itemNo" runat="server" Text='<%# Eval("RetailPrice") %>' Style="font-size:14px"  /> <br />
	 
	 <asp:Label ID="QtySelect" runat="server" Text=""></asp:Label><br />

	 <asp:DropDownList ID="itemQtydll" runat="server" DataSource='<%# Stock((int)Eval("Quantity")) %>'  OnSelectedIndexChanged="SelectCartQty"  AutoPostBack="True">
		
		 
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

<div style="width:50%; border: 1px solid red; margin-left:20px; overflow:auto; height:350px;"> 

<div style="display: block;  border: 1px solid white; overflow:auto; width:95%; height:300px;">






<!--  계산대 헤더
<table style="width:100%; border-collapse: collapse; border-spacing: 0; text-align:left; position:center; ">
  <tr class="ListHeader">
    <th style="width:30px;">No</th>
    <th style="width:150px;">Name</th>
    <th style="width:60px;">Price</th>
	<th style="width:60px;">Qty</th>
  </tr>

계산대 목록 
  <tr style="font-size:14px; text-align:center;" onmouseover="this.style.backgroundColor='rgba(184,191,209, 0.6)'" onmouseout="this.style.backgroundColor=''">
    <td><asp:Label ID="cartItemNo" runat="server" Text=""></asp:Label></td>

	<td><asp:Label ID="cartItemName" runat="server" Text=""></asp:Label></td>
	<td><asp:Label ID="cartItemPrice" runat="server" Text=""></asp:Label></td>
	<td><asp:Label ID="cartItemQty" runat="server"></asp:Label></td>
	 
  </tr>
	
</table> -->
	<asp:GridView ID="GridView1"  runat ="server" OnRowDeleting="RowDelete" OnRowCreated = "RowCreate"   >


		<Columns>
			<asp:CommandField ShowDeleteButton="True" DeleteText="Cancel" ButtonType="Button" ItemStyle-ForeColor="#CCCCFF" ControlStyle-CssClass="SearchBtn"></asp:CommandField>
		</Columns>
	</asp:GridView>

</div>



	<br />
	<div style="display: block; width:95%; border: 1px solid white;">
	<asp:Label ID="subTotal" runat="server" Text="SubTotal" Font-Size="Large" ForeColor="White" BackColor="Fuchsia"></asp:Label>
	
	<asp:Button ID="Button1" runat="server" Text="CLEAR"  OnClick="test"/>
	</div>
</div>
	<br />
	
	
</div>

</asp:Content>
