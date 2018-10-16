$(document).ready(function () {
	//start jQuery!

	$("#searchBtn").click(function () {

		var searchItem = $("#searchItem").val();
		var wikiApi = "https://en.wikipedia.org/w/api.php?action=opensearch&search=" + searchItem + "&limit=7&format=json&callback=?";
		//$.ajax({
		//type:"GET",
		//url:wikiApi,
		//async:false,
		//dataType:"json", 
		//success: function(data){
		$.getJSON(wikiApi, function (data) {
			$("#output").html(' ');

			for (var i = 0; i < data[1].length; i++) { $("#output").append("<li><a href=" + data[3][i] + ">" + data[1][i] + "</a>" + "<br>" + data[2][i] + "</li>"); }

			//},
			//error: function(){
			//alert("Error! ");}
			//}) //ajax ends  
		}); // getJSON Ends!
	}); // searhBtn function ends

	$("#searchItem").keypress(function (e) {
		if (e.which == 13) {
			$("#searchBtn").click();
		}
	});

}); //end of jQuery! 

document.getElementById("randomBtn").addEventListener("click", random, false);
function random() {
	window.open("https://en.wikipedia.org/wiki/Special:Random");
};
