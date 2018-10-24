
function SendName() {
	opener.document.getElementById("HdnCName").value = document.getElementById("CustomerSelection").value;
	opener.document.getElementById("HdnCNum").value = document.getElementById("CustomerNo").value;
	window.opener.document.getElementById("BtnHdn").click();
	window.close();
}