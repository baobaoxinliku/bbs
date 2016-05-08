$(document).ready(function () {
    $("#btn_ok").click(function () {
        var TTopic = $("#TTopic").val();
        var TContents = $("#summernote").val();
        if (TTopic != "" && TContents != "") {
            $.ajax({
                type: "post",
                url: "ashx/posting.ashx",
                data: { "TTopic": TTopic, "TContents": TContents },
                datatype: "text",
                success: function (data) {
                    var json = eval('(' + data + ')');
                    alert(json.info + "登录成功");
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
    })
});