$(function () {
    
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: "Home/GetHotJson",
        data: {  },
        dataType: "json",
        error: function (result) {
          
        },
        success: function (result) {
            for (var i = 0; i < 10; i++) {            
                $(".line").html("");
                $("#line").html('<marquee id="line" behavior="scroll" direction="right" >'+"<result[1].Head"+'</marquee>');
            }
        }

    });
});