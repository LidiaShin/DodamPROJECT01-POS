<%@ Page Title="" Language="C#" MasterPageFile="~/pos.Master" AutoEventWireup="true" CodeBehind="050aboutme.aspx.cs" Inherits="DodamPOS._005aboutme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<table>
<tr>
<td style="width:180px;"><h3>About Me</h3></td>
</tr>
</table>
<hr />
<br /><br />



<div style="width:85%; margin-left:10px; height:400px; display: flex; flex-wrap:wrap; ">




<div style="display:flex;  width:100%; height:100%; flex-wrap:wrap; ">

<div style="width:100%; " >
<span style="color:yellow; font-size:20px;"> HELLO! </span>
</div>

<div style="width:65%; height:45%; ">

<ul class="mainul2">
<li class="mainli2"><span class="sub2">I AM </span> &nbsp; &nbsp;<asp:HyperLink ID="dodam" runat="server" NavigateUrl="javascript:void(0);" style="text-decoration:none; color:aquamarine; font-weight:600;">Dodam Shin, 신도담</asp:HyperLink>. 
Currently staying in Toronto, Canada.</li> 

<li class="mainli2"><span class="sub2">I WAS </span> born and raised in Seoul, South Korea (Not from North, please !). Also I used to stay in China, US and Taiwan.</li>

<li class="mainli2"> Not real nomadic but keep curiosity in mind for various languages and cultures 
- This is always important motivation for me to move forward.</li>

<li class="mainli2"> One of my favorite phrase is Nec spe, nec metu, 
meaning ‘without hope, without fear’. <asp:HyperLink ID="isabella" runat="server" NavigateUrl="javascript:void(0);" style="text-decoration:none; color:aquamarine; font-weight:600;"> The Lady</asp:HyperLink>
who took it as a motto is my favorite historical person as well.</li>

<li class="mainli2"><span class="sub2">I WILL </span> continue learning programming and working on various side-projects.
My next step is, creating small (but cute!) To-Do List app with React.js. Coming soon! </li>
</ul>
</div>

<div style="width:35%; height:45%; padding-top:20px; ">
<asp:Image ID="SnowCat" runat="server" ImageUrl="~/img/snowcat.png
	" Width="140px" Height="140px" />
</div>

<span style="color:yellow; font-size:20px;"> THIS PROJECT CREATED WITH </span>
<div style="width:100%; height:55%;  ">
<ul class="mainul2">

<li class="mainli2"><span class="sub2">LANGUAGE </span> .NET Framework ver 4.7.03056 Using C#,Javascript, CSS3 and HTML5 </li> 
<li class="mainli2"><span class="sub2">TOOL </span> Visual Studio Enterprise 2017 ver 15.8.7, MS SQL Management Studio ver 17.9 </li>
<li class="mainli2"><span class="sub2">RESOURCE </span> MS AZURE App Service, Blob, SQL Server and Database </li>
<li class="mainli2"><span class="sub2">REFERENCE MATERIAL </span> Google,Stack Overflow, Youtube, codepen.io </li>

</ul>
</div>




</div>
</div>



</asp:Content>
