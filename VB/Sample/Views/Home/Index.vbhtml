<script type="text/javascript">
    var browseClicked = false;

    //upload control
    function OnFileUploadComplete(s, e) {
        gridView.batchEditApi.SetCellValue($("#hf").val(), "FileName", e.callbackData);
        gridView.batchEditApi.EndEdit();
    }
    function OnTextChanged(s, e) {
        if (s.GetText()) {
            browseClicked = true;
            s.Upload();
        }
    }
    function SetUCText(text) {
        var $input = $("input:visible[type=text]", uc.GetMainElement());
        $input.val(text);
    }


    //grid
    function OnBatchStartEditing(s, e) {
        browseClicked = false;
        $("#hf").val(e.visibleIndex);
        var fileNameColumn = s.GetColumnByField("FileName");
        if (!e.rowValues.hasOwnProperty(fileNameColumn.index))
            return;
        var cellInfo = e.rowValues[fileNameColumn.index];

        setTimeout(function () {
            SetUCText(cellInfo.value);
        }, 0);
    }
    function OnBatchEditEndEditing(s, e) {
        browseClicked = false;
        SetUCText("");
    }
    function OnBatchConfirm(s, e) {
        e.cancel = browseClicked;
    }
</script>

@Using (Html.BeginForm())
    @<input type="hidden" name="hf" id="hf" />
    @Html.Action("GridViewPartial")
End Using 
