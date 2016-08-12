$(document).ready(function () {

    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: "Home/GetHotJson",
        data: {},
        dataType: "json",
        error: function (result) {
        },
        success: function (items) {
            $("#line").simplemarquee();
            
                //for (var i = 0; i < items.resultLength ; i++) {
                    
                    $("#line").text(items.result[0].Head);
                //}
            

            
            //  $jScroller.add("#breakingNews", "#line", "left", 10, true);
            // $jScroller.start();
        }

    });

});
