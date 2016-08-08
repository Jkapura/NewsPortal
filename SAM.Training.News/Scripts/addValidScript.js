$(function () {
    $('#formSet').validate({
        rules: {
            categoryId: {
                required: true,
            },
            head: {
                required: true,
                minlength: 4
            },
            content: {
                required: true,
                minlength: 4
            },

        },
        messages: {
            categoryId: {
                required: "*",
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
        errorElement: "div",
        wrapper: "div",  
        errorPlacement: function (error, element) {
            offset = element.offset();
            error.insertBefore(element)
            error.addClass('message');  
            error.css('position', 'relative');
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