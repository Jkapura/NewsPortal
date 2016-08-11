$(document).ready(function(){}) 
    
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: "Home/GetHotJson",
        data: {  },
        dataType: "json",
        error: function (result) {          
        },
        success: function (result) {
            $("#line").text(result[0].Head);
            $jScroller.add("#breakingNews", "#line", "left", 10, true);
            $jScroller.start();
        }

    });
    
