<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="032customer_seedetail.aspx.cs" Inherits="DodamPOS._032customer_seedetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="height:100%;">
<head runat="server">
    <title></title>
	<link href="css/poscss.css" rel="stylesheet" type="text/css" />
</head>
<body id="container_newwindow">
    <form id="form1" runat="server">

		<h2>Customer Details</h2><hr />

		<p style="text-align:right;"> Customer No :<asp:Label ID="cnumlbl" runat="server" Text="" Font-Size="Medium"></asp:Label> </p>

				<table style="width:90%">
                
				<tr>        
                <td><span style="color:hotpink">● </span> First Name</td>		
				<td><span style="color:hotpink;">● </span> Address </td>
				</tr>

				<tr>
				<td><asp:TextBox ID="fnamebox" runat="server" CssClass="CustomerOutput" ></asp:TextBox></td>  
				<td><asp:TextBox ID="addressbox" runat="server" CssClass="CustomerOutput" ></asp:TextBox></td>           
                </tr>

				<tr>        
                <td><span style="color:hotpink">● </span> Last Name</td>			
				<td><span style="color:hotpink;">● </span> City</td>
				</tr>

				<tr>
				<td><asp:TextBox ID="lnamebox" runat="server" CssClass="CustomerOutput" ></asp:TextBox></td>
				<td><asp:TextBox ID="citybox" runat="server" CssClass="CustomerOutput" ></asp:TextBox></td> 
                </tr>

				<tr>        
                <td><span style="color:hotpink">● </span> Email </td>
				<td><span style="color:hotpink;">● </span> Province</td>
				</tr>

				<tr>
				<td><asp:TextBox ID="emailbox" runat="server" CssClass="CustomerOutput" ></asp:TextBox></td>
				
				<td><asp:DropDownList ID="provincelist" runat="server" CssClass="ProvinceInput" AppendDataBoundItems="True" AutoPostBack="True"  >
				<asp:ListItem Text="" Value="" Selected="false"></asp:ListItem>
				</asp:DropDownList></td> 
                </tr>
				 
				<tr>        
                <td><span style="color:hotpink">● </span> Phone</td>
				<td><span style="color:hotpink">● </span> Postal Code</td>
				</tr>

				<tr>
				<td><asp:TextBox ID="phonebox" runat="server" CssClass="CustomerOutput" ></asp:TextBox></td>
				<td><asp:TextBox ID="pcodebox" runat="server" CssClass="CustomerOutput" ></asp:TextBox></td>
                </tr>

				<tr>
				<td><span style="color:azure">● </span> Note</td>
				</tr>

				
				<tr>
				<td><asp:TextBox ID="notebox" runat="server" CssClass="CustomerOutput"  Height="60px" Width="300px"></asp:TextBox></td>
				</tr>


				</table>

		     <br />
             <asp:Button ID="btnUpdate" runat="server" Text="UPDATE" CssClass="RegisterBtn" OnClick="btnUpdate_Click" /> &nbsp;&nbsp;
		     <asp:Button ID="btnSave" runat="server" Text="SAVE" CssClass="RegisterBtn" OnClick="btnSave_Click" Visible="False"  /> &nbsp;&nbsp;
             <asp:Button ID="btnClose" runat="server" Text="CLOSE" CssClass="RegisterBtn" OnClientClick="javascript:window.close();" />&nbsp;&nbsp;
		     <asp:Label ID="TEST" runat="server" Text="Label"></asp:Label>
          

    </form>
</body>
</html>
