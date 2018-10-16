<%@ Page Title="" Language="C#" MasterPageFile="~/pos.Master" AutoEventWireup="true" CodeBehind="020item.aspx.cs" Inherits="DodamPOS._002item" Theme="pos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<h3>Item List<asp:Button ID="BtnAddNewItem" runat="server" Text="ADD NEW" SkinID="BtnAddNewCustomer" OnClick="BtnAddNewItem_Click" /> </h3> <hr />
	<asp:Label ID="testlabel" runat="server" Text=""></asp:Label>
	<br /><br />

	<asp:HiddenField ID="hdnText" runat="server" ClientIDMode="Static" Value="" /> 

<div style="width:90%;">

<asp:ListView ID="itemListBoard" runat="server" GroupPlaceholderID="groupPlaceHolder1" ItemPlaceholderID="itemPlaceHolder1" OnPagePropertiesChanging="OnPagePropertiesChanging" >

	   <LayoutTemplate>
	   <table style="width:100%; border-collapse: collapse; border-spacing: 0; text-align:left; position:center; ">
       
	   <tr class="ListHeader">

	   <th style="width:40px;">No</th>
       <th style="width:120px;">CATEGORY</th>
       <th style="width:150px;">NAME</th>
       <th style="width:60px;">PurchasePrice</th>
       <th style="width:60px;">RetailPrice</th>
       <th style="width:40px;">Quantity</th>
	   <th style="width:150px;">RegisterDay</th>
       </tr>
        
	   <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>

	   <tr><td colspan = "7">

	   <hr style="border: 0;height:0;border-top: 1px solid rgba(0, 0, 0, 0.1);border-bottom: 1px solid rgba(255, 255, 255, 0.3);">

	   <asp:DataPager ID="DataPager1" runat="server" PagedControlID="itemListBoard" PageSize="15" >

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
	
           <td><asp:Label ID="lblItemID" runat="server" Text='<%# Eval("NO") %>' /></td>

           <td><asp:Label ID="lblItemCategory" runat="server" Text ='<%# Eval("CATEGORY") %>' /></td>



		   <td style="text-align:left;"><asp:LinkButton ID="lkItemName" runat="server" Text ='<%# Eval("NAME") %>' CommandArgument='<%# Eval("NO") %>' Font-Overline="false" ForeColor="White"  
		    onmouseover="this.style.color='red'" onmouseout="this.style.color='white'" OnClick ="SeeItemDetail"/></td>
           

		   <td><asp:Label ID="lblItemPPrice" runat="server" Text='<%# Eval("PurchasePrice") %>' /></td>
           <td><asp:Label ID="lblItemRPrice" runat="server" Text='<%# Eval("RetailPrice") %>' /></td>
		   <td><asp:Label ID="lblItemQty" runat="server" Text='<%# Eval("Quantity") %>' /></td>
           <td><asp:Label ID="lblItemRDay" runat="server" Text=' <%# Eval("REGISTER DATE") %>' /></td>
           </tr>

		   </ItemTemplate>
    </asp:ListView>
</div>


	 <!--검색창 -->
		   <asp:DropDownList ID="searchKeyWordList" runat="server" CssClass="SearchInput" AppendDataBoundItems="True" AutoPostBack="True" >
		   <asp:ListItem Text="- Select  - " Selected="True" Value=""></asp:ListItem>
		   </asp:DropDownList>

		   <asp:TextBox ID="keywordbox" runat="server" CssClass="SearchInput" ></asp:TextBox>
		    &nbsp; &nbsp;
	        <!--검색버튼 -->
		   <asp:Button ID="BtnSearch" runat="server" Text="SEARCH" CssClass="SearchBtn" OnClick="BtnSearch_Click"  />


</asp:Content>
