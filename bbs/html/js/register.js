$(document).ready(function () {
    //注册提交按钮单击事件
    $("#btn_register").click(function () {
        var uname = $("#uname").val();
        var upassword = $("#upassword").val();
        var uemail = $("#uemail").val();
        var ubirthday = $("#ubirthday").val();

        //获得单选按钮选中项的值
        var usex = true;
        var usexcheck = $('input:radio[name="usex"]:checked').val();
        var ustatement = $("#ustatement").val();
        if (usexcheck == '女') { usex = false; }
       
        var ustatement = $("#ustatement").val();

        if (uname != "" && upassword != "" && uemail != "" && ubirthday != "") {
            $.ajax({
                type: "post",
                url: "ashx/register.ashx",
                data: { "uname": uname, "upassword": upassword, "uemail": uemail, "ubirthday": ubirthday, "usex": usexcheck, "ustatement": ustatement },
                datatype: "text",
                success: function (data) {
                    var json = eval('(' + data + ")");
                    alert(json.info);
                    window.location.href = "\login.html";
                },
                error: function (err) {
                    alert(err);
                }
            });
        }
        else {
            alert("请按规定输入！");
        }
    });

    //注册重置按钮单击事件
    $("#btn_clear").click(function () {
        $("#uname").val('');
        $("#upassword").val('');
        $("#uemail").val('');
        $("#ubirthday").val('');
        $("#ustatement").val('');
    });

    //$.ajax({
    //    type: "post",
    //    url: "register.ashx",
    //    data: { "action": "show" },
    //    datatype: "text",
    //    success: function (data) {
    //        var json = eval('(' + data + ')');
    //        alert(json.Age);
    //    }
    //});
});