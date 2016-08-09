$(function () {

    var template = $.templates("#myTml");
    var cookData = getCookie("numberOfRows");
    $("#dropdownpage").val(cookData).prop('checked', true);
    if (cookData != "") {
        
        $.ajax({
            url: 'CallData',
            data: { num: cookData },
            type: "post",
            dataType: "json",
            error: function (json) { alert("Error"); },
            success: function (json) {
                
                var htmlOutput = template.render(json);
                $("#result").html(htmlOutput);
            }
        });
    }
    else {
        var qual = $("#dropdownpage").val();
        $.ajax({
            url: 'CallData',
            data: { num: qual },
            type: "post",
            dataType: "json",
            error: function (json) { alert("Error"); },
            success: function (json) {
                
                var htmlOutput = template.render(json);
                $("#result").html(htmlOutput);
            }
        });
    }
    var colrows = $("#dropdownpage").val();
    
    
    
    $("#dropdownpage").change(function () {
        var qual = $("#dropdownpage").val();
        // qual = $(".dropdown-content-CountItems ul li").text();
        $.ajax({
            url: 'CallData',
            data: { num: qual },
            type: "post",
            dataType: "json",
            error: function (json) { alert("Error"); },
            success: function (json) {

                var htmlOutput = template.render(json);
                $("#result").html(htmlOutput);
            }
        });
    });
    window.onunload = function () {
        var colrows = $("#dropdownpage").val();
        setCookie("numberOfRows", colrows);
        var temp = getCookie("numberOfRows");
        alert("Cookies updated" + getCookie("numberOfRows"));
    };
    function getCookie(name) {
        var matches =document.cookie.match(new RegExp(
          "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
        ));
        return matches ? decodeURIComponent(matches[1]) : undefined;
    }
    function setCookie(name, value, options) {
        options = options || {};

        var expires = options.expires;

        if (typeof expires == "number" && expires) {
            var d = new Date();
            d.setTime(d.getTime() + expires * 1000);
            expires = options.expires = d;
        }
        if (expires && expires.toUTCString) {
            options.expires = expires.toUTCString();
        }

        value = encodeURIComponent(value);

        var updatedCookie = name + "=" + value;

        for (var propName in options) {
            updatedCookie += "; " + propName;
            var propValue = options[propName];
            if (propValue !== true) {
                updatedCookie += "=" + propValue;
            }
        }

        document.cookie = updatedCookie;
    }
    $(".XmlSndBtnAjax").click(function () {
        colrows = $("#dropdownpage").val();
        $.fileDownload('/Archive/GetXmlFile?num=' + colrows, {
            //successCallback: function (url) {

            //    alert('You just got a file download dialog or ribbon for this URL :' + url);
            //},
            //failCallback: function (html, url) {

            //    alert('Your file download just failed for this URL:' + url + '\r\n' +
            //            'Here was the resulting error HTML: \r\n' + html
            //            );
            //}
        });
        
    });
    $(".CsvSndBtnLink").click(function () {
        colrows = $("#dropdownpage").val();
        $.ajax({
            url: 'GetCsvFile',
            data: { num: colrows },
            type: "post",
            dataType: "csv",
            error: function (csv) {
                var temp = window.location.pathname;
                
                var url = window.location.toString().substr(0, 31);
                //window.location.pathname="/Archive/GetCsvFile";
                //window.location.search = "?num=" + colrows
                var downlUrl = url + "GetCsvFile?num=" + colrows;                
                window.location.href = downlUrl;
            },
            success: function (csv) {               
            }
        });
    });
    $(".CsvSndBtnAjax").click(function () {
        colrows = $("#dropdownpage").val();
        $.ajax({
            url: 'GetCsvFile',
            data: { num: colrows },
            type: "post",
            dataType: "csv",
            error: function (csv) {
                $.fileDownload('/Archive/GetCsvFile?num=' + colrows, {});
            },
            success: function (csv) {
                $.fileDownload('/Archive/GetCsvFile?num=' + colrows, {});
            }
        });
    });
    $(".XmlSndBtnLink").click(function () {
        colrows = $("#dropdownpage").val();
        $.ajax({
            url: 'GetXmlFile',
            data: { num: colrows },
            type: "post",
            dataType: "xml",
            error: function (xml) { alert("Error"); },
            success: function (xml) {
                var url = window.location.toString().substr(0,31);                
                var downlUrl = url + "GetXmlFile?num=" + colrows;
                window.location.href = downlUrl;
                
            }
        });
    });
});
$.views.helpers({
    parseDate: function (jsonDate) {
        if (jsonDate != null) {
            var date = new Date(parseInt(jsonDate.substr(6)));
            var newDate = moment(date).startOf("day").fromNow();
            return newDate;
        }
    }
    });