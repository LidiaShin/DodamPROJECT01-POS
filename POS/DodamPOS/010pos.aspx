<%@ Page Title="" Language="C#" MasterPageFile="~/pos.Master" AutoEventWireup="true" CodeBehind="010pos.aspx.cs" Inherits="DodamPOS._001pos" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<h3>Point Of Sales</h3><hr />
	<asp:Label ID="testlabel" runat="server" Text=""></asp:Label>
	<br /><br />

	
	<div style="width:90%;">

		<asp:DataList ID="itemLists" runat="server">

  <ItemTemplate>
     <asp:Label ID="itemName" runat="server" Text='<%# Eval("NAME") %>' />
	 <asp:Image ID="Image1" runat="server" ImageUrl="<%# Eval("NAME") %>" />
  </ItemTemplate>
		</asp:DataList>
	</div>


</asp:Content>
