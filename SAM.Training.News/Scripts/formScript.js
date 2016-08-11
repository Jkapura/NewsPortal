$(function () {    
    var urlPass = window.location.toString();
    var id = parseInt(urlPass.substr(41, 3));
    $.ajax({
        url: 'EditItem',
        data: { id: id },
        type: "GET",
        dataType: "json",
        error: function (json) { alert("Error" + json) },
        success: function (json) {

            $("[name='head']").val(json.Head);
            $("[name='content']").val(json.Content);
            $("[name='hotNews']").prop('checked', json.HotNews);
            $("[name='isArchive']").prop('checked', json.IsArchive);
            $("[name='categoryId']").val(json.CategoryId).prop('checked', true);

        }
    });
    $('#formSet').validate({
        rules: {
            categoryId: {
                required: true,
            },
            head: {
                required: true,
                minlength: 4,
                maxlength: 50
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
        highlight: function (element) {
            $(element).addClass('errorInput');
        }, unhighlight: function (element) {
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
    $("#formSet").keydown(function (event) {
        if (event.keyCode == 13) {
            event.preventDefault();
            return false;
        }
    });
    });    