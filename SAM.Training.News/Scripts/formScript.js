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
    })
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
                required: "Please enter category of article." ,                
            },
            head:{
                required: "Please enter head of article.",
                minlength: "Head should have at least 4 signs",
            },
            content: {
                required: "Please enter content of article.",
                minlength: "Content should have at least 4 signs",
            }
            
        }        
    });

    $("#formSet").keydown(function (event) {
        if (event.keyCode == 13) {
            event.preventDefault();
            return false;
        }
    });
    
});