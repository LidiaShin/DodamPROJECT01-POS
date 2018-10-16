$(document).ready(function(){
// JS start!
  
var lat,long;
var city,id,weather;

var weather;
var now = new Date();
var iconNum,icon;

  
var temp =[];
var maxtemp=[];
var mintemp=[];
var hum,wind,cloud,sunrise,sunset; 
  
  
var aweather,atime,aIconNum,aIcon;
var atemp =[];

var bweather,btime,bIconNum,bIcon;
var btemp =[];
  
var cweather,ctime,cIconNum,cIcon;
var ctemp =[];  

var dweather,dtime,dIconNum,dIcon;
var dtemp =[];

  
if (navigator.geolocation){
  navigator.geolocation.getCurrentPosition(function(position){
    lat = position.coords.latitude;
    long = position.coords.longitude;
  
   var today = "https://cors-anywhere.herokuapp.com/http://api.openweathermap.org/data/2.5/weather?lat="
                + lat + "&lon=" + long +"&APPID=f51b192fcdf6ae6730e222f3f02b1349";
    
  var forecast = "https://cors-anywhere.herokuapp.com/http://api.openweathermap.org/data/2.5/forecast?lat=" + lat +"&lon=" + long+"&APPID=f7f0cfa2cf63976d5049506602173d59";
    

  
  //today
   $.getJSON(today,function(Data){
     
   //현재 위치 이름
   city=Data.name;
   //현재 위치 ID
   id = Data.id;
     
   weather=Data.weather[0].description;
  
   
   temp[0]=Math.round(Data.main.temp - 273.15);
   temp[1]=Math.round((Data.main.temp - 273.15)*1.8+32);
     
   maxtemp[0]=Math.round(Data.main.temp_max - 273.15);
   maxtemp[1]=Math.round((Data.main.temp_max - 273.15)*1.8+32);  
     
     
   mintemp[0]=Math.round(Data.main.temp_min - 273.15); 
   mintemp[1]=Math.round((Data.main.temp_min - 273.15)*1.8+32); 
   
   hum= Data.main.humidity;
   wind= (Math.round(Data.wind.speed * 3.6)); 
   cloud=Data.clouds.all;
     
   sunrise=new Date(Data.sys.sunrise*1000);
   sunset=new Date(Data.sys.sunset*1000);
     
     
   // Function to switch between units
   $(".btn").click (function() {
      if ($(".btn").text() === 'to farenheit') {
        $(".btn").text("to celcius");
        $(".fc").html("&#8728;F");
        $("#temp").html(temp[1]);
        $("#maxtemp").html(maxtemp[1]);
        $("#mintemp").html(mintemp[1]);
        $("#atemp").html(atemp[1]);
        $("#btemp").html(btemp[1]);
        $("#ctemp").html(ctemp[1]);
        $("#dtemp").html(dtemp[1]);
      }
      else {
        $(".btn").text('to farenheit');
        $(".fc").html("&#8728;C");
        $("#temp").html(temp[0]);
        $("#maxtemp").html(maxtemp[0]);
        $("#mintemp").html(mintemp[0]);
        $("#atemp").html(atemp[0]);
        $("#btemp").html(btemp[0]);
        $("#ctemp").html(ctemp[0]);
        $("#dtemp").html(dtemp[0]);
      }
    });
     
     
   $("#loca").html(city)
   $("#lat").html(Math.round(lat));
   $("#long").html(Math.round(long));  
   $("#id").html(id);
   $("#des").html(weather);  
   $("#temp").html(temp[0]);
     
   $("#maxtemp").html(Math.round(maxtemp[0]));
   $("#mintemp").html(Math.round(mintemp[0]));
   
   $("#hum").html(hum + "%");
   $("#wind").html(wind+" km/h");
   $("#cloud").html(cloud+" %");
     
   $("#sunrise").html(sunrise.getHours() + " : " + sunrise.getMinutes());
   
   $("#sunset").html(sunset.getHours()+ " : " + sunset.getMinutes());
 
   //  아이콘     
   iconNum = Data.weather[0].icon;
   icon = ("http://openweathermap.org/img/w/" + iconNum + ".png");
   //$("#weathericon").append('<img src="' + icon + '"/>');
    $("#weathericon").append('<img src="' + icon + '"/>'); 
   });
    
    
   // future
   $.getJSON(forecast,function(Data){

   aweather=Data.list[2].weather[0].description;
   bweather=Data.list[6].weather[0].description; 
   cweather=Data.list[10].weather[0].description; 
   dweather=Data.list[14].weather[0].description; 
     
   atemp[0]=Math.round(Data.list[2].main.temp - 273.15); 
   atemp[1]=Math.round((Data.list[2].main.temp - 273.15)*1.8+32); 
   
   btemp[0]=Math.round(Data.list[6].main.temp - 273.15); 
   btemp[1]=Math.round((Data.list[6].main.temp - 273.15)*1.8+32); 
     
   ctemp[0]=Math.round(Data.list[10].main.temp - 273.15); 
   ctemp[1]=Math.round((Data.list[10].main.temp - 273.15)*1.8+32); 
   
   dtemp[0]=Math.round(Data.list[14].main.temp - 273.15); 
   dtemp[1]=Math.round((Data.list[14].main.temp - 273.15)*1.8+32); 
     
     
  
   // 아이콘
   aIconNum =Data.list[2].weather[0].icon;
   aIcon =("http://openweathermap.org/img/w/" + aIconNum + ".png");
   $("#aweathericon").append('<img src="' + aIcon + '"/>'); 
     
   bIconNum =Data.list[6].weather[0].icon;
   bIcon =("http://openweathermap.org/img/w/" + bIconNum + ".png");
   $("#bweathericon").append('<img src="' + bIcon + '"/>'); 
     
   cIconNum =Data.list[10].weather[0].icon;
   cIcon =("http://openweathermap.org/img/w/" + cIconNum + ".png");
   $("#cweathericon").append('<img src="' + cIcon + '"/>'); 
     
   dIconNum =Data.list[14].weather[0].icon;
   dIcon =("http://openweathermap.org/img/w/" + dIconNum + ".png");
   $("#dweathericon").append('<img src="' + dIcon + '"/>'); 
   
   atime=Data.list[2].dt_txt;
   btime=Data.list[6].dt_txt;
   ctime=Data.list[10].dt_txt;
   dtime=Data.list[14].dt_txt;
    
var month = new Array();
month[0] = "Jan";
month[1] = "Feb";
month[2] = "Mar";
month[3] = "Apr";
month[4] = "May";
month[5] = "Jun";
month[6] = "Jul";
month[7] = "Aug";
month[8] = "Sep";
month[9] = "Oct";
month[10] = "Nov";
month[11] = "Dec";
     
//var aaa=new Date(atime);
   
   
   $("#adate").html(new Date(atime).getDate()+ ", " + month[new Date(atime).getMonth()]); 
   $("#atime").html(new Date(atime).getHours() + ":00 "); 
     
   $("#bdate").html(new Date(btime).getDate()+ ", " + month[new Date(btime).getMonth()]); 
   $("#btime").html(new Date(btime).getHours() + ":00 ");  
     
   $("#cdate").html(new Date(ctime).getDate()+ ", " + month[new Date(ctime).getMonth()]); 
   $("#ctime").html(new Date(ctime).getHours() + ":00 "); 
     
   $("#ddate").html(new Date(dtime).getDate()+ ", " + month[new Date(dtime).getMonth()]); 
   $("#dtime").html(new Date(dtime).getHours() + ":00 ");  
     
  
     
     
   $("#aweather").html(aweather);
   $("#bweather").html(bweather);
   $("#cweather").html(cweather);
   $("#dweather").html(dweather);
     
   $("#atemp").html(atemp[0]); 
   $("#btemp").html(btemp[0]); 
   $("#ctemp").html(ctemp[0]); 
   $("#dtemp").html(dtemp[0]); 
     
   
   }); // getJSON
    
   });// function ends
}// if ends
   
}); // end of JS
