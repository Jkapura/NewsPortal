
$(function () {
    var template = $.templates("#myTml");
    var tmplForSngl = $.templates("#tmplForSingle");
    startData.InitAllNews(tmplForSngl, template);
    setTimeout(UpdateSingleColumn(10, tmplForSngl, template), 10000);  

});