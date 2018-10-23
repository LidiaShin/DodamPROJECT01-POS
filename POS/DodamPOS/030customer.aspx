<%@ Page Title="" Language="C#" MasterPageFile="~/pos.Master" AutoEventWireup="true" CodeBehind="030customer.aspx.cs" Inherits="DodamPOS._003customer" Theme="pos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<h3>Customer List <asp:Button ID="BtnAddnew" runat="server" Text="ADD NEW" SkinID="BtnAddNewCustomer" OnClick="BtnAddnew_Click" /></h3><hr />	
	<br /><br />

<asp:HiddenField ID="hdnText" runat="server" ClientIDMode="Static" Value="" /> 

<div style="width:90%;">

<asp:ListView runat="server" ID="cListBoard" GroupPlaceholderID="groupPlaceHolder1" ItemPlaceholderID="itemPlaceHolder1" OnPagePropertiesChanging="OnPagePropertiesChanging" >

       <LayoutTemplate>

       <table style="width:100%; border-collapse: collapse; border-spacing: 0; text-align:left; position:center; ">
       <tr class="ListHeader">
		
       <th style="width:40px;">No</th>
       <th style="width:150px;">Name</th>
       <th style="width:180px;">E-Mail</th>
       <th style="width:140px;">City</th>
       <th style="width:35px;">Province</th>
       <th style="width:150px;">Register Date</th>
		  
       </tr>
	   
       <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
	  
       <tr>
       <td colspan = "6">
		
     <!--데이터 페이저 바로 위 (짧은줄) -->
       <hr style="border: 0;height:0;border-top: 1px solid rgba(0, 0, 0, 0.1);border-bottom: 1px solid rgba(255, 255, 255, 0.3);">
    
	 <!--데이터 페이저 previous 1 2 3 ....next -->
	     <asp:DataPager ID="DataPager1" runat="server" PagedControlID="cListBoard" PageSize="15" >
	      <Fields>
          <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true" ShowNextPageButton="false" ButtonCssClass="DataPager" />
          <asp:NumericPagerField ButtonType="Link" NumericButtonCssClass="DataPager" />
          <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton = "false"  ButtonCssClass="DataPager" />
			  
          </Fields>
			
          </asp:DataPager>
		   &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

	   </td>
       </tr>
     
   
    <!--테이블 위 (바깥, 긴줄) 
	<hr style="border: 0;height:0;border-top: 1px solid rgba(0, 0, 0, 0.1);border-bottom: 1px solid rgba(255, 255, 255, 0.3);"> -->   
	  </table>
     
	<!--테이블 아래 (바깥,긴줄) 
	<hr style="border: 0;height:0;border-top: 1px solid rgba(0, 0, 0, 0.1);border-bottom: 1px solid rgba(255, 255, 255, 0.3);">-->
     </LayoutTemplate>
	
	
    <GroupTemplate>	
    <tr><asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder></tr>
    </GroupTemplate>
	 
	
	

    <ItemTemplate>
		
    <tr style="font-size:14px; text-align:center;" onmouseover="this.style.backgroundColor='rgba(184,191,209, 0.6)'" onmouseout="this.style.backgroundColor=''">
	
    <td><asp:Label ID="lblCustomerID" runat="server" Text='<%# Eval("NO") %>' /></td>

    <td style="text-align:left;"><asp:LinkButton ID="lkCustomerName" runat="server" Text ='<%# Eval("NAME") %>' CommandArgument='<%# Eval("NO") %>' Font-Overline="false" ForeColor="White"  
		onmouseover="this.style.color='red'" onmouseout="this.style.color='white'" OnClick ="SeeDetail"/></td>

    <td style="text-align:left;"><asp:Label ID="lblCustomerEmail" runat="server" Text ='<%# Eval("E-MAIL") %>' /></td>
    <td><asp:Label ID="lblCity" runat="server" Text='<%# Eval("CITY") %>' /></td>
    <td><asp:Label ID="lblProvince" runat="server" Text='<%# Eval("PROVINCE") %>' /></td>
    <td><asp:Label ID="lblRegisterDate" runat="server" Text=' <%# Eval("REGISTER DATE") %>' /></td>
    </tr>
       
    </ItemTemplate>
	


	</asp:ListView>
     </div> 
           <!-- SEARCH FILTER DDL -->
		   <asp:DropDownList ID="searchKeyWordList" runat="server" CssClass="SearchInput" AppendDataBoundItems="True" AutoPostBack="True" >
		   <asp:ListItem Text="- Select  - " Selected="True" Value=""></asp:ListItem>
		   </asp:DropDownList>
	   
	       <!--SEARCH TEXTBOX  -->
		   <asp:TextBox ID="keywordbox" runat="server" CssClass="SearchInput" ></asp:TextBox>
		    &nbsp; &nbsp;
	        <!--검색버튼 -->
		   <asp:Button ID="Button1" runat="server" Text="SEARCH" OnClick="Button1_Click" CssClass="SearchBtn"  />

	<asp:Label ID="testlabel" runat="server" Text="Label"></asp:Label>

</asp:Content>
