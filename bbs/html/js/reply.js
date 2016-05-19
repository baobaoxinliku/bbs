$(document).ready(function () {
    $("#btn_ok").click(function () {
        var RContents = $("#RContents").val();
        if (RContents != "" ) {
            $.ajax({
                type: "post",
                url: "ashx/reply.ashx",
                data: { "RContents": RContents },
                datatype: "text",
                success: function (data) {
                    var json = eval('(' + data + ')');
                    alert(json.info);
                    //window.location.href = "\index.html";
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