var selectiors =
    {
        insertSnglPlaceById: "#resultForSngl[itemid='",
        insertListPlaceById: "#resultListItem[itemid='",
        closeBracket: "']",
        listTmpl: "#myTml",
        snglColumnTmpl: "#tmplForSingle"

    }

var locations =
    {

        getByCategory : "Home/GetByCategoryNews"
    }
var startData = (function () {
    return {
        InitAllNews: function (ForSngl, temp) {
            
            var tmplForSngl = ForSngl;
            var template = temp;
            for (var i = 1; i <= 7; i++) {
                InitSectionNews(i, tmplForSngl, template);
            }

        }
    }
})();
var modifyData = (function () {
        return {
        ToHot: function ( parent)
        {
            $.ajax({
                url: '/Home/ToHotItem',
                data: { id: parent, hotNews: true },
                type: "post",
                dataType: "json",
                error: function (json) {
                    alert("Error" + json)
                },
                success: function (json) {
                }
            });
        },
        ToArchive: function (selectedObjId) {
            var flag = $("#isArchive").text();
            if (flag === "Hot") {
                $.ajax({
                    url: '/Home/ToArchive',
                    data: { id: selectedObjId, isArchive: true },
                    type: "post",
                    dataType: "json",
                    error: function (json) {
                        location.href = location.href;
                    },
                    success: function (json) {
                        $("#toArchiveDialog").dialog("close");
                        $("#isArchive").text("");
                        $("#isArchive").text("Archive");
                    }
                });
            }
            else {
                $.ajax({
                    url: '/Home/ToArchive',
                    data: { id: selectedObjId, isArchive: false },
                    type: "post",
                    dataType: "json",
                    error: function (json) {
                        location.href = location.href;
                    },
                    success: function (json) {
                        $("#toArchiveDialog").dialog("close");
                        $("#isArchive").text("");
                        $("#isArchive").text("Hot");
                    }
                });
            }
            
           
        },
        Delete: function (selectedObjId) {
            $.ajax({

                url:'/Home/DeleteArticle',
                data: { id: selectedObjId },
                type: "post",
                dataType: "json",
                error: function (json) {
                    
                },
                success: function (json) {
                    var hosturl = location.host;
                    location.href = "/Home/GetHotNews";
                    startData.InitAllNews();
                    
                }
            });
           
        },
        Edit: function (selectedObjId) {
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: '/Home/EditItem',
                data: { id: selectedObjId },
                dataType: "json",
                error: function (item) {
                    var obj = JSON.parse(item);
                },
                success: function (json) {
                    var itemId = json.Id;
                    
                    window.location.href = "/Edit/Index?itemId=" + itemId;
                }
            });
            
        }
    }
})();

$.views.helpers({
    parseDate: function (jsonDate) {
        if (jsonDate != null) {
            var date = new Date(parseInt(jsonDate.substr(6)));
            var newDate = moment(date).startOf("day").fromNow();
            return newDate;
        }
    }
});

function InitSectionNews(categId, tmplForSngl, template)
{

    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: locations.getByCategory,
        data: { categoryId: categId, count:10},
        dataType: "json",
        error: function (result) {
            alert("Error" + result);
        },
        success: function (arrObj) {
            //listOfLenSectionObj.sectionObjLen[arrObj.result[0].CategoryId] = arrObj.resultLength;
            
            var htmlOutput = template.render(arrObj.result);            
            var htmlForSingle = tmplForSngl.render(arrObj.result[arrObj.resultLength-1]);
            $(selectiors.insertSnglPlaceById + categId + selectiors.closeBracket).html(htmlForSingle);
            $(selectiors.insertListPlaceById + categId + selectiors.closeBracket).html(htmlOutput);       

        }
        
    });
}
function InitSingleColumn(categId, value, tmplForSngl, template) {
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: locations.getByCategory,
        data: { categoryId: categId, count: value },
        dataType: "json",
        error: function (result) {

        },
        success: function (result) {
                
            //$(selectiors.insertSnglPlaceById + categId + selectiors.closeBracket).html("");
            var randValue = Math.floor(Math.random() * (result.resultLength + 1));
            
            var randIndex = result.resultLength - randValue;
            if (result.resultLength === randIndex)
            {
                randIndex = randIndex - 1;
            }
            //alert(result.result[randIndex].CategoryId + "||" + result.result[randIndex].Id)
            var htmlForSingle = tmplForSngl.render(result.result[randIndex]);
            //alert(result.result[0].CategoryId +" | "+ result.resultLength + " : " + randIndex);
            
                $(selectiors.insertSnglPlaceById + result.result[0].CategoryId + selectiors.closeBracket).html(htmlForSingle);
            
        }

    });
}
function UpdateSingleColumn(value) {
    setInterval(function () {
        for (var i = 1; i <= 7; i++) {
            value = 10;
            var template = $.templates(selectiors.listTmpl);
            var tmplForSngl = $.templates(selectiors.snglColumnTmpl);
            InitSingleColumn(i, value, tmplForSngl, template);
        }
    }, 10000)
}