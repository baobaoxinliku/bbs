$(document).ready(function () {
    $("#btn_ok").click(function () {
        var TTopic = $("#ttopic").val();
        var TContents = $("#summernote").code();
        if (TTopic != "" && TContents != "") {
            $.ajax({
                type: "post",
                url: "ashx/posting.ashx",
                data: { "TTopic": TTopic, "TContents": TContents },
                datatype: "text",
                success: function (data) {
                    var json = eval('(' + data + ')');
                    alert(json.info + "发帖成功");
                    //window.location.href = "";
                },
                error: function (err) {
                    alert(err);
                }
            });
        }
        else {
            alert("请重新输入");
        }
    });
    $("#btn_clear").click(function () {
        $("#ttopic").val('');
        $("#summernote").code('');
    });
});