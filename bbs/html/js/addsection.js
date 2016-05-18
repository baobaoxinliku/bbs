$(document).ready(function () {
    $("#btn_ok").click(function () {
        var sname = $("#sname").val();
        var smasterid = $("#smasterid").val();
        var sstatement = $("#sstatement").val();
        if (sname != "" && smaster != "") {
            $.ajax({
                type: "post",
                url: "ashx/addsection.ashx",
                data: { "sname": sname, "smasterid": smasterid, "sstatement": sstatement },
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
    $("#btn_clear").click(function () {
        var sname = $("#sname").val('');
        var smasterid = $("#smasterid").val('');
        var sstatement = $("#sstatement").val('');
    })
});