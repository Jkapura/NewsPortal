$(function () {
    $('#formSet').validate({
        rules: {
            categoryId: {
                required: true,
            },
            head: {
                required: true,
                minlength: 4,
                maxlength:50
            },
            content: {
                required: true,
                minlength: 4
            },

        },
        messages: {
            categoryId: {
                required: "Choose one of the categories.",
            },
            head: {
                required: "Please enter head of article.",
                minlength: "Head should have at least 4 signs",
            },
            content: {
                required: "Please enter content of article.",
                minlength: "Content should have at least 4 signs",
            }

        },
        highlight: function(element) {
            $(element).addClass('errorInput');
        }, unhighlight: function(element) {
            $(element).removeClass('errorInput');
        },
        errorElement: "div",
        wrapper: "div",  
        errorPlacement: function (error, element) {

            offset = element.offset();
            if (element.attr("type") == "radio") {
                error.insertAfter($("#categoryId"));
            } else {
                error.insertAfter(element)
            }
            error.addClass('message');  
            error.css({
                'position': 'relative',
               

            });
            //error.css('left', offset.left + element.outerWidth());
            //error.css('top', offset.top + element.outerHeight());
        }

    });
    //$(".sndBtn").click(function () {
    //    $("div#saveDialog").dialog("open");

    //});
    //$("div#saveDialog").dialog({
    //    autoOpen: false,
    //    modal: true,
    //    buttons:
    //        {
    //            "Add new": function () { $(this).dialog("close"); },

    //            "To Home page": function () {

    //                //window.location.pathname = "/Home/GetHotNews";
    //            }

    //        }

    //});
    $("#formSet").keydown(function (event) {
        if (event.keyCode == 13) {
            event.preventDefault();
            return false;
        }
    });
});