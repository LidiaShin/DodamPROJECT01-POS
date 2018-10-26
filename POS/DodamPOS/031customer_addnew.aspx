<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="031customer_addnew.aspx.cs" Inherits="DodamPOS._031customer_addnew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="height:100%;">
<head runat="server">
    <title></title>
	<link href="css/poscss.css" rel="stylesheet" type="text/css" />
</head>
<body id="container_newwindow">
    <form id="form1" runat="server">
      
				<h2>New Customer Registration</h2><hr />
				
				<p style="text-align:right;"> Please fill out customer detail form below</p>

				<table style="width:100%">
                
				<tr>        
                <td><span style="color:hotpink">● </span> First Name 
				<asp:RequiredFieldValidator ID="ReqFname" runat="server" ErrorMessage="&nbsp; Please enter first name &nbsp;"  ControlToValidate="fnamebox" CssClass="ErrorMSG" ></asp:RequiredFieldValidator></td> 
				<td><span style="color:hotpink; margin-left:20px;">● </span> Address
                <asp:RequiredFieldValidator ID="ReqAddress" runat="server" ErrorMessage="&nbsp; Please enter address &nbsp;"  ControlToValidate="addressbox" CssClass="ErrorMSG"></asp:RequiredFieldValidator>
				</td>
				</tr>

				<tr>
				<td><asp:TextBox ID="fnamebox" runat="server" CssClass="CustomerInput" ></asp:TextBox></td>  
				<td><asp:TextBox ID="addressbox" runat="server" Style="margin-left:20px" CssClass="CustomerInput" Width="250px" ></asp:TextBox></td>           
                </tr>

				<tr>        
                <td><span style="color:hotpink">● </span> Last Name
				<asp:RequiredFieldValidator ID="ReqLname" runat="server" ErrorMessage="&nbsp; Please enter last name &nbsp;" CssClass="ErrorMSG" ControlToValidate="lnamebox"  ></asp:RequiredFieldValidator></td>
				<td><span style="color:hotpink; margin-left:20px;">● </span> City
				<asp:RequiredFieldValidator ID="ReqCity" runat="server" ErrorMessage="&nbsp; Please enter city &nbsp;" CssClass="ErrorMSG" ControlToValidate="citybox"></asp:RequiredFieldValidator>
				</td>
				</tr>

				<tr>
				<td><asp:TextBox ID="lnamebox" runat="server" CssClass="CustomerInput" ></asp:TextBox></td>
				<td><asp:TextBox ID="citybox" runat="server" Style="margin-left:20px" CssClass="CustomerInput" ></asp:TextBox> </td> 
                </tr>

				<tr>        
                <td><span style="color:hotpink">● </span> Email 
				<asp:RequiredFieldValidator ID="ReqEmail" runat="server" ErrorMessage="&nbsp; Please enter email &nbsp;" CssClass="ErrorMSG"  Display="Dynamic" ControlToValidate="emailbox"></asp:RequiredFieldValidator>
				<asp:RegularExpressionValidator ID="RegexEmail" runat="server" ErrorMessage="&nbsp; Please enter valid email &nbsp;" ControlToValidate="emailbox" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="ErrorMSG" Display="Dynamic"></asp:RegularExpressionValidator></td>
				<td><span style="color:hotpink; margin-left:20px;">● </span> Province 
				<asp:RequiredFieldValidator ID="ReqProvince" runat="server" ErrorMessage="&nbsp; Please select province.Choose N/A if not in the list" CssClass="ErrorMSG" ControlToValidate="provincelist"></asp:RequiredFieldValidator>
				</td>
				</tr>

				<tr>
				<td><asp:TextBox ID="emailbox" runat="server" CssClass="CustomerInput" TextMode="Email" ></asp:TextBox> </td>
				<td>
				<asp:DropDownList ID="provincelist" runat="server" Style="margin-left:20px" CssClass="ProvinceInput" AppendDataBoundItems="True" AutoPostBack="True"  >
				<asp:ListItem Text="- Select Province - " Selected="True" Value=""></asp:ListItem>
				</asp:DropDownList></td> 
                </tr>
				 
				<tr>        
                <td><span style="color:hotpink">● </span> Phone
                <asp:RequiredFieldValidator ID="ReqPhone" runat="server" ErrorMessage="&nbsp; Please enter phone number &nbsp;" CssClass="ErrorMSG"  Display="Dynamic" ControlToValidate="phonebox"  ></asp:RequiredFieldValidator>
				<asp:RegularExpressionValidator ID="RegexPhone" runat="server" ErrorMessage="&nbsp; Please enter valid phone number " ControlToValidate="phonebox"  CssClass="ErrorMSG" Display="Dynamic" ValidationExpression="^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$"></asp:RegularExpressionValidator>
                </td>
				<td><span style="color:hotpink; margin-left:20px;">● </span> Postal Code 
				<asp:RequiredFieldValidator ID="ReqPcode" runat="server" ErrorMessage="&nbsp; Please enter Zipcode &nbsp;"  Display="Dynamic" ControlToValidate="postalcodebox" CssClass="ErrorMSG" ></asp:RequiredFieldValidator>
				<asp:RegularExpressionValidator ID="RegexPcode" runat="server" ErrorMessage="Please enter US/Canada Zipcode.Input12345 if N/A" ControlToValidate="postalcodebox"  CssClass="ErrorMSG" Display="Dynamic" ValidationExpression="(^\d{5}(-\d{4})?$)|(^[ABCEGHJKLMNPRSTVXYabceghjklmnprstvxy]{1}\d{1}[A-Za-z]{1} *\d{1}[A-Za-z]{1}\d{1}$)" ></asp:RegularExpressionValidator>
				</td>
				</tr>

				<tr>
				<td><asp:TextBox ID="phonebox" runat="server" CssClass="CustomerInput" ></asp:TextBox> </td>
				<td><asp:TextBox ID="postalcodebox" runat="server" Style="margin-left:20px" CssClass="CustomerInput" ></asp:TextBox> </td>
                </tr>

				<tr>
				<td><span style="color:azure">● </span> Note</td>
				</tr>

				
				<tr>
				<td><asp:TextBox ID="notebox" runat="server" CssClass="CustomerInput" TextMode="MultiLine" Height="60px" Width="300px" MaxLength="2000"></asp:TextBox></td>
				</tr>


				</table>

		     <br />
             <asp:Button ID="btnSubmit" runat="server" Text="SUBMIT" CssClass="RegisterBtn" OnClick="btnSubmit_Click" /> &nbsp;&nbsp;
             <asp:Button ID="btnClose" runat="server" Text="CLOSE" CssClass="RegisterBtn" OnClientClick="javascript:window.close();" />
          
		
    </form>
</body>
</html>
