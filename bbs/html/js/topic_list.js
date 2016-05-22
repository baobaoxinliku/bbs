$(document).ready(function () {
    $('#table').bootstrapTable({
        url: "ashx/list_section.ashx",//数据源
        sidePagination: 'server',//设置为服务器端分页
        pagination: true, //是否分页
        search: true, //显示搜索框
        pageSize: 5,//每页的行数 
        pageList: [5, 10, 20],
        pageNumber: 1,//显示的页数
        showRefresh: true,//刷新
        striped: true,//条纹
        sortName: 'SId',
        sortOrder: 'desc',
        uniqueId: "SId", //每一行的唯一标识，一般为主键列
    });
    //删除按钮
    $("#BtnDel").click(function () {
        var SId = getCheck();//获取选中行的人的编号
        //    alert(DelNumS);
        //判断是否为空 前面是否有多余的 逗号.(如果是全选，前面会多个，)
        if (SId.charAt(0) == ",") { SId = SId.substring(1); }
        if (SId == "") { alert("请选择额要删除的数据"); }
        else
        {
            $.ajax({
                type: "post",
                url: "ashx/section_del.ashx",
                data: { "Action": "Del", "SId": SId },
                dataType: "text",
                success: function (data) {
                    var json = eval('(' + data + ')');
                    alert(json.info);
                    //刷新页面
                    //  window.location.reload();
                    $('#table').bootstrapTable('refresh');
                }
            });
        }
    });
});

function editFormatter(value, row, index) { //处理操作
    var str = '<a href="modify.aspx?id=' + value + '">编辑</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="show.html?UserID=' + value + '">详情</a>'
    value = str;
    return value;
}

function getCheck() { //获取表格里选中的行 的编号
    var data = [];//数组
    $("#table").find(":checkbox:checked").each(function () {
        var val = $(this).parent().next().text();//当前元素的上一级---里的下一个元素--的内容
        data.push(val);
    });
    return data.join(",");//用，连接
}
