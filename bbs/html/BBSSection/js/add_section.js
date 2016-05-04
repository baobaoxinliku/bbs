$(document).ready(function () {
    $("#btn_add").click(function () {
        var sname = $("#sname").val();
        var smasterid = $("smasterid").val();
        var sstatement = $("statement").val();

        if (sname != "" && smasterid != "" && sstatement != "") {
            $.ajax({
                type: "post",
                url: "ashx/add_section.ashx",
                data: {"sname":sname,"smasterid":smasterid,"sstatement":sstatement},
                datatype: "text",
                success: function (data) {
                    var json = eval('(' + data + ")");
                    alert(json.info);
                },
                error: function (err) {
                    alert(err);
                }
            });
        }
    })
});