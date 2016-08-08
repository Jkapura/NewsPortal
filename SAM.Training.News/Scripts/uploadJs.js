var jqXHRData;

$(document).ready(function () {
    $("div#notXmlDialog").dialog({
        autoOpen: false,
        modal: true,
        title: "Not XML File.",
        buttons: {
            "OK.": function () { $(this).dialog("close"); }
        }
    });
    $("div#countDialog").dialog({
        autoOpen: false,
        modal: true,
        title: "File was succesfully added!",
        buttons: {
            "OK.": function () { $(this).dialog("close"); }
        }
    });
    $("div#notValidDialog").dialog({
        autoOpen: false,
        modal: true,
        title: "File has incorrect structure.",
        buttons: {
            "OK.": function () { $(this).dialog("close"); }
        }
    });

    initFileUploadWithCheckingSize();

    
    $("#hl-start-upload-with-size").on('click', function () {
        if (jqXHRData) {
            var isStartUpload = true;
            var uploadFile = jqXHRData.files[0];

            if (!(/\.(xml)$/i).test(uploadFile.name)) {
                $("div#notXmlDialog").dialog("open");
                //alert('You must select a.xml file only');
                isStartUpload = false;
            } else if (uploadFile.size > 4000000) { // 4mb
                alert('Please upload a smaller image, max size is 4 MB');
                isStartUpload = false;
            }
            if (isStartUpload) {
                jqXHRData.submit();
            }
        }
        return false;
    });
});

function initFileUploadWithCheckingSize() {
    'use strict';

    $('#fu-my-simple-upload-with-size').fileupload({
        url: '/Upload/UploadFile',
        dataType: 'json',
        add: function (e, data) {
            jqXHRData = data;

        },
        done: function (event, data) {
            if (data.result.isUploaded) {
                //alert("You have added " + data.result.countOfNews + " news!");
                $("div#countDialog").text("You have added " + data.result.countOfNews + " news!").dialog("open");
            }
            else {
                $("div#notValidDialog").text(data.result.message).dialog("open");
            }
            
            //alert(data.result.message);
        },
        fail: function (event, data) {
            if (data.files[0].error) {
                $("div#notValidDialog").text(data.files[0].error).dialog("open");
                //alert(data.files[0].error);
            }
        }
    });
}
