$("#btn_add").click(function () {
    var SName = $("#SName").val();
    var SMasterID = $("#SMasterID").val();
    var SStatement = $("#SStatement").val();

    if (SName != "" && SMasterID != "" && SStatement != "") {
        $.ajax({
            type: "post",
            url: "ashx/section_add.ashx",
            data: { "SName": SName, "SMasterID": SMasterID, "SStatement": SStatement },
            datatype: "text",
            success: function (data) {
                var json = eval('(' + data + ")");
                alert(json.info);
                window.location.href = "\section_list.html";
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

$("#btn_clear").click(function () {
    $("#SName").val('');
    $("#SMasterID").val('');
    $("#SStatement").val('');
  
});