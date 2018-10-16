$(document).ready(function(){
// JQuery start!

 
var channel=["freecodecamp","food","spammiej","bobross","flowervin","pennyarcade","ogamingsc2","mister903","arvalis"];

 for (var i = 0; i <9; i++){ //for(i)
  
(function(i){ //function (i)
  
var twitchApi="https://wind-bow.glitch.me/twitch-api/channels/"+channel[i]+"/?callback";
$.getJSON(twitchApi, function (data) { //getJSON
   
 //document.getElementById("logo"+i).src=data.logo;
 $("#logo"+i).html('<img src="'+data.logo + '">');
 $("#desc"+i).html('<a href="'+ data.url+'">'+channel[i]+'</a><br>'+data.status);
 
  //'<a href="'+ data.url+'">'+channel[i]+'</a><br>'+
  
  }); //getJSON
  })(i); //function (i) 
} // for(i)
   
  
  
for (var i = 0; i <9; i++){ //for(i)
  
(function(i){ //function (i)
  
var twitchApi="https://wind-bow.glitch.me/twitch-api/streams/"+channel[i]+"/?callback";
$.getJSON(twitchApi, function (data) { //getJSON  
   if(data.stream===null){
   $("#ch"+i).html(channel[i] + " is Currently Offline");
   $("#ch"+i).css("background-color","#99ebec");
   } 
   else{
   $("#ch"+i).html(channel[i] + " is Currently Online");   
   $("#ch"+i).css("background-color","#eacccc");}
  }); //getJSON 
  })(i); //function (i) 
} // for(i)


  
  
$("#online").click (function(){
for (var i = 0; i <9; i++){ //for(i)
  
(function(i){ //function (i)
  
var twitchApi="https://wind-bow.glitch.me/twitch-api/streams/"+channel[i]+"/?callback";
$.getJSON(twitchApi, function (data) { //getJSON   
  
   if(data.stream!==null){
   $("#ch"+i).addClass("show"); 
   $("#logo"+i).addClass("show"); 
   $("#desc"+i).addClass("show");  
   $("#ch"+i).removeClass("hide");   
   $("#logo"+i).removeClass("hide");
   $("#desc"+i).removeClass("hide"); 
   $("#box"+i).css("border","2px solid red");
   }
   
   else{
  $("#ch"+i).addClass("hide");
  $("#logo"+i).addClass("hide"); 
  $("#desc"+i).addClass("hide"); 
  $("#ch"+i).removeClass("show");
  $("#logo"+i).removeClass("show"); 
  $("#desc"+i).removeClass("show"); 
  $("#box"+i).css("border-style","none");
   }
  }); //getJSON 
  })(i); //function (i) 
} // for(i)
    
  }); //online button
  
  
$("#offline").click (function(){ //offline button
for (var i = 0; i <9; i++){ //for(i)
  
(function(i){ //function (i)
  
var twitchApi="https://wind-bow.glitch.me/twitch-api/streams/"+channel[i]+"/?callback";
$.getJSON(twitchApi, function (data) { //getJSON
   
  
   if(data.stream===null){
   $("#ch"+i).addClass("show");    
   $("#logo"+i).addClass("show");  
   $("#desc"+i).addClass("show");
   $("#ch"+i).removeClass("hide");
   $("#logo"+i).removeClass("hide");
   $("#desc"+i).removeClass("hide");
   $("#box"+i).css("border","2px solid #315c6b");
   
   }
   
  else{
  $("#ch"+i).addClass("hide");
  $("#logo"+i).addClass("hide"); 
  $("#desc"+i).addClass("hide");   
  $("#ch"+i).removeClass("show");
  $("#logo"+i).removeClass("show"); 
  $("#desc"+i).removeClass("show");
  $("#box"+i).css("border-style","none");
   }
  }); //getJSON 
  })(i); //function (i) 
} // for(i)
   }); //offline button 
  
  $("#all").click (function(){
for (var i = 0; i <9; i++){ //for(i)
  
(function(i){ //function (i)
  
var twitchApi="https://wind-bow.glitch.me/twitch-api/streams/"+channel[i]+"/?callback";
$.getJSON(twitchApi, function (data) { //getJSON
  //$("#ch"+i).addClass("show");
  //$("#logo"+i).addClass("show"); 
 
   $("#ch"+i).addClass("show"); 
   $("#ch"+i).removeClass("hide");
   $("#logo"+i).addClass("show"); 
   $("#logo"+i).removeClass("hide");
   $("#desc"+i).addClass("show"); 
   $("#desc"+i).removeClass("hide");
   $("#box"+i).css("border","3px solid #013b63");
   
   
  }); //getJSON 
  })(i); //function (i) 
} // for(i)
}); //all button   

  
}); //JQuery Ends!!