<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="021item_addnew.aspx.cs" Inherits="DodamPOS._021item_addnew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="height:100%;">
<head runat="server">
    <title></title>
	<link href="css/poscss.css" rel="stylesheet" type="text/css" />
</head>
	<body id="container_newwindow">
    <form id="form1" runat="server">
		<h2>New Item Registration</h2><hr />
		<p style="text-align:right;"> Please fill out item detail form below</p>

		<table style="width:100%">
                
				<tr>        
                <td><span style="color:hotpink">● </span> Item Category 
				<asp:RequiredFieldValidator ID="ReqCate" runat="server" ErrorMessage="&nbsp; Please Choose Category &nbsp;"  ControlToValidate="CategoryList"  CssClass="ErrorMSG"></asp:RequiredFieldValidator> 					
				</td> 
				
				<td><span style="color:hotpink; margin-left:20px;">● </span> Purchase Price
                <asp:RequiredFieldValidator ID="ReqPprice" runat="server" ErrorMessage="Please enter purchase price &nbsp;" CssClass="ErrorMSG" ControlToValidate="pPriceBox" Display="Dynamic"></asp:RequiredFieldValidator>
				<asp:RegularExpressionValidator ID="RegexPPrice" runat="server" ErrorMessage="Up to $10,0000,2 decimal" ControlToValidate="pPriceBox" Display="Dynamic" ValidationExpression="^(?:100000|[0-9]\d{0,4})(?:\.\d{1,2})?$" CssClass="ErrorMSG" ></asp:RegularExpressionValidator>
				
				</td>
				</tr>

				<tr>
				<td><asp:DropDownList ID="CategoryList" runat="server" CssClass="ProvinceInput" AppendDataBoundItems="True" AutoPostBack="True"  >
				<asp:ListItem Text="- Select Category - " Selected="True" Value=""></asp:ListItem>
				</asp:DropDownList></td>  

				<td><asp:TextBox ID="pPriceBox" runat="server" Style="margin-left:20px" CssClass="CustomerInput"  ></asp:TextBox></td>           
                </tr>

				<tr>        
                <td><span style="color:hotpink">● </span> Item Name
				<asp:RequiredFieldValidator ID="ReqIname" runat="server" ErrorMessage=" Please enter Item name (max 20character) &nbsp;"  ControlToValidate="iNameBox" CssClass="ErrorMSG"  Display="Dynamic"  ></asp:RequiredFieldValidator>
				<asp:RegularExpressionValidator ID="RegexName" runat="server" ErrorMessage=" Please enter valid name (max 20 character)  " CssClass="ErrorMSG"  Display="Dynamic"  ControlToValidate="iNameBox" ValidationExpression="^.{1,20}$" ></asp:RegularExpressionValidator>
				</td>

				<td><span style="color:hotpink; margin-left:20px;">● </span> Retail Price
				<asp:RequiredFieldValidator ID="ReqRprice" runat="server" ErrorMessage="&nbsp; Please enter retail price &nbsp;" CssClass="ErrorMSG"  Display="Dynamic" ControlToValidate="rPriceBox"></asp:RequiredFieldValidator>
				<asp:RegularExpressionValidator ID="RegexRPrice" runat="server" ErrorMessage="Up to $10,0000,2 decimal" CssClass="ErrorMSG" ControlToValidate="rPriceBox" Display="Dynamic" ValidationExpression="^(?:100000|[0-9]\d{0,4})(?:\.\d{1,2})?$"></asp:RegularExpressionValidator> 
				
				</td>
				</tr>

		
				<tr>
				<td><asp:TextBox ID="iNameBox" runat="server" CssClass="CustomerInput" ></asp:TextBox></td>
				<td><asp:TextBox ID="rPriceBox" runat="server" Style="margin-left:20px" CssClass="CustomerInput" ></asp:TextBox> </td> 
                </tr>



			    <tr>        
                <td><span style="color:hotpink">● </span> Item Quantity
				<asp:RequiredFieldValidator ID="ReqQty" runat="server" ErrorMessage="&nbsp; Please select quantity &nbsp;"     CssClass="ErrorMSG" ControlToValidate="qtyList"></asp:RequiredFieldValidator>
                </td>
				<td><span style="color:hotpink; margin-left:20px;">● </span> Image</td>
				</tr>



				<tr>
				<td><asp:DropDownList ID="qtyList" runat="server" CssClass="ProvinceInput" AppendDataBoundItems="True" AutoPostBack="True"  Width="90px">
				<asp:ListItem Text="-Select-" Selected="True" Value=""></asp:ListItem>
				</asp:DropDownList></td>  

				
					
				<td> <asp:FileUpload ID="imageUpload" runat="server" Style="margin-left:20px; display:inline;" CssClass="CustomerInput" Width="180px" />
					 <asp:Button ID="btnUpload" runat="server" Text="Upload"  Width="60px" OnClick="btnUpload_Click" style="margin-left:5px;" CausesValidation="False" /> </td> 
                </tr>

				<tr>
				<td> <span style="color:azure;">● </span> Note
					<asp:RegularExpressionValidator ID="RegNote" runat="server" ErrorMessage="max 200 characters"   CssClass="ErrorMSG"  ValidationExpression="^.{0,200}$" ControlToValidate="notebox"   ></asp:RegularExpressionValidator>
				</td> 
			    </tr>
		        
			    <tr>
				<td><asp:TextBox ID="notebox" runat="server" CssClass="CustomerInput" TextMode="MultiLine" Height="90px" Width="300px" MaxLength="2000"></asp:TextBox></td>
				
				<td>
					<asp:Image ID="testimg" runat="server" Height="90px" Width="200px" Style="margin-left:20px; border:none;" BorderStyle="None" BorderWidth="0px" />
					
				</td>
                </tr>
				 
			   
				</table>

		     <br />
             <asp:Button ID="btnSubmit" runat="server" Text="SUBMIT" CssClass="RegisterBtn" OnClick="btnSubmit_Click" /> &nbsp;&nbsp;
             <asp:Button ID="btnClose" runat="server" Text="CLOSE" CssClass="CloseBtn" OnClientClick="javascript:window.close();" />
          
		    
		    <asp:Label ID="imgurl" runat="server" Text="" Visible="false"></asp:Label>
      
    </form>
</body>
</html>
