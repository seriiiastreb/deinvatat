 function doPost(eventTarget, eventArgument) {
	__doPostBack(eventTarget, eventArgument);
	theForm.__EVENTTARGET.value = "";
	theForm.__EVENTARGUMENT.value = "";
}