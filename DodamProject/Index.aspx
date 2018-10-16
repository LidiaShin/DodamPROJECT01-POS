<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DodamProject.Index" %>

<!DOCTYPE html>
<html>
<head runat="server">
<title> Dodam Shin's Azure Web App Page :) </title>
<link href="https://fonts.googleapis.com/css?family=Lato|Dosis|Julius+Sans+One|Raleway" rel="stylesheet">
<link href="css/indexpage.css" rel="stylesheet">
</head>

<body>
<form id="form1" runat="server">
   
      <div class="container">
 
		<div class="header">
		    <h1> Dodam Shin's Project Index Page</h1><hr/>   
		</div>

	    <div class="contents">
         <p class="project"> 1. FreeCodeCamp <span class="url"> https://www.freecodecamp.org </span></p>	  

          <img src="img/freecodecamp.png" alt="freecodecamp" height="100">
           <br /><br />
	     
		  <details>
			  <summary class="sub-title">Responsive Web Design Projects : Basic HTML,HTML5,CSS,CSS flexbox</summary>
		   <ul>
             <li><asp:HyperLink ID="FCCweb1" runat="server" NavigateUrl="~/FCCweb/FCCweb1/BuildaTributePage.html" CssClass="list">Build a Tribute Page</asp:HyperLink></li>
	         <li><asp:HyperLink ID="FCCweb2" runat="server" NavigateUrl="~/FCCweb/FCCweb2/BuildaSurveyForm.html" CssClass="list">Build a Survey Form</asp:HyperLink></li>
             <li><asp:HyperLink ID="FCCweb3" runat="server" NavigateUrl="~/FCCweb/FCCweb3/BuildaProductLandingPage.html" CssClass="list">Build a Product Landing Page</asp:HyperLink></li>
	         <li runat="server"> Build a Technical Documentation Page</li>
		     <li><asp:HyperLink ID="FCCweb5" runat="server" NavigateUrl="~/FCCweb/FCCweb5/BuildaPersonalPortfolioWebpage.html" CssClass="list">Build a Personal Portfolio Webpage</asp:HyperLink></li>
		   </ul>
	      </details>

		  <details> 
			  <summary class="sub-title">JavaScript Algorithms and Data Structures Projects</summary> 
		   <ul>
			  <li>Palindrome Checker</li>
			  <li>Roman Numeral Converter</li>
			  <li>Caesars Cipher</li>
			  <li>Telephone Number Validator</li>
			  <li>Cash Register</li>
		  </ul>
           </details>

		   <details> 
			  <summary class="sub-title">Front End Libraries Projects</summary> 
		   <ul>
			  <li><asp:HyperLink ID="FCCfront1" runat="server" NavigateUrl="~/FCCfront/FCCfront1/quotemachine.html" CssClass="list">Build a Random Quote Machine</asp:HyperLink></li>			  
			  <li><asp:HyperLink ID="FCCfront2" runat="server" NavigateUrl="~/FCCfront/FCCfront2/localWeatherApp.html" CssClass="list">Build a Local Weather App</asp:HyperLink></li>
			  <li><asp:HyperLink ID="FCCfront3" runat="server" NavigateUrl="~/FCCfront/FCCfront3/wikiApp.html" CssClass="list">Build a Wiki App</asp:HyperLink></li>	
			  <li><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/FCCfront/FCCfront4/TwitchApp.html" CssClass="list">Build a TwitchView App</asp:HyperLink></li>	
			  
			  <li>Build a Markdown Previewer</li>
			  <li>Build a Drum Machine</li>
			  <li>Build a JavaScript Calculator</li>
			  <li>Build a Pomodoro Clock</li>
		   </ul>
           </details>

           <p class="project"> 2. Centennial College Class Project - COMP219 <span class="url"> https://www.freecodecamp.org </span></p>
		   <details>
			  <summary class="sub-title">Class labs & Practical Test Review</summary>
		   <ul>
             <li><asp:HyperLink ID="pr1" runat="server" NavigateUrl="https://comp229project01.azurewebsites.net/signup.aspx" CssClass="list">1. Simple SignUp & SignIn Page</asp:HyperLink></li>
	      
		   </ul>
	      </details>
		   <p class="project"> 3. Centennial College Class Project - COMP214 <span class="url"> https://www.freecodecamp.org </span></p>

		   <p class="project"> 4. Centennial College Class Project - COMP231<span class="url"> https://www.freecodecamp.org </span></p>
	     </div>
    
     
       <div id="footer">  ⓒ 2018 Dodam Shin PROJECT 
       </div> 
 </div>      

</form>
</body>
</html>
