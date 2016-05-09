$(document).ready(function () {
    $("#btn_login").click(function () {
        var uname = $("#uname").val();
        var upassword = $("#upassword").val();
        if (uname != "" && upassword != "") {
            $.ajax({
                type: "post",
                url: "ashx/login.ashx",
                data: { "uname": uname, "upassword": upassword },
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
    $("#btn_clear").click(function(){
        var uname = $("#uname").val('');
        var upassword = $("#upassword").val('');
    })
});