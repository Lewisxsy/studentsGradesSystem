$(document).ready(function() {
	var noDownLoadPath = window.ATTACH__NO_DOWNLOAD_PATH;
	$(".attachNew").each(function(index, element) {
        var element = $(this).children("span:first");
        var objectId = $(element).attr("data");
		var fileOriName = $(element).text();
		fileOriName = encodeURIComponent(fileOriName);
		var url = "/ueditorupload/read?objectId=" + objectId+"&fileOriName="+fileOriName;
		if(noDownLoadPath && noDownLoadPath.length > 0){
			url = url.replace('/ueditorupload/read',noDownLoadPath);
		}
		url = encodeURI(url);
		$(element).parent().click(function() {
			window.open(url, '_blank').location;
		});
	});
	delete window.ATTACH__NO_DOWNLOAD_PATH;
    $(".attachNew img").unbind("click")
	$(".attachUrl span").each(function(index, element) {
		var url = $(this).attr("data");
		url = encodeURI(url);
		$(this).parent().click(function() {
			window.open(url, '_blank').location;
		});
	});

	$(".attachZT span").each(function(index, element) {
		var url = $(this).attr("data");
		url = encodeURI(url);
		$(this).parent().click(function() {
			window.open(url, '_blank').location;
		});
	});
	
	$(".attach a").each(function(index, element) {
		var url = $(this).attr("href");
		url = encodeURI(url);
		$(this).attr("href", url);
	});
});