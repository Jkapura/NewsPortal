$(function () {    
    $(".edit").click(function () {
        $("#editDialog").dialog("open");
    });
    $(".toArc").click(function () {
        $("#toArchiveDialog").dialog("open");
    });
    $(".delete").click(function () {
        $("#deleteDialog").dialog("open");
    });
    $("#editDialog").dialog({
        autoOpen: false,
        title: "Edit article.",
        buttons: {
            "Edit": function () { modifyData.Edit($("#hdnId").text()) },
            "Cancel": function () { $(this).dialog("close"); }
        }
    });
    $("#deleteDialog").dialog({
        autoOpen: false,
        title: "Delete article.",
        buttons: {
            "Delete": function () { modifyData.Delete($("#hdnId").text()) },
            "Cancel": function () { $(this).dialog("close"); }
        }
    });
    $("#toArchiveDialog").dialog({
        autoOpen: false,
        title: "Edit article.",
        buttons: {
            "Add to archive": function () { modifyData.ToArchive($("#hdnId").text()) },
            "Cancel": function () { $(this).dialog("close"); }
        }
    });
});
