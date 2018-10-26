
function SendName() {
	opener.document.getElementById("HdnCName").value = document.getElementById("CustomerSelection").value;
	opener.document.getElementById("HdnCNum").value = document.getElementById("CustomerNo").value;
	window.opener.document.getElementById("BtnHdn").click();
	window.close();
}

function PrintReceipt(sec1,sec2,sec3) {

	var p1 = document.all.item(sec1).innerHTML;

	var p2 = document.all.item(sec2).innerHTML;

	var p3 = document.all.item(sec3).innerHTML;

	var oldstr = document.body.innerHTML;

	document.body.innerHTML = p1 + "<br>" + p2 +"<br>" +  p3;

	window.print();

	document.body.innerHTML = oldstr;

	return false;
}