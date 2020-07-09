


$(document).ready(function () {
    var dataRR = [];
   
    var table = null;
    /*Load dữ liệu thì viết hết trong đây */
    var LoadFunction = {
        //load table 
        Order: function () {
            $.ajax({
                url: "/admin/order/GetOrder",
                type: 'POST',
                async: false,
                dataType: "text",
                success: function (res) {
                    if (res) {
                        var R = JSON.parse(res);
                        table = $('#Order').DataTable({
                            "data": R,
                            scrollY: 500,
                            scrollCollapse: true,
                            scrollX: true,
                            responsive: true,
                            "columns": [

                                { "data": "Name" },
                                { "data": "Phone" },
                                {
                                    "mRender": function (data, type, row, meta) {
                                        if (row.IsDelete == false)
                                            return '<span id="StatusName' + row.OrderId + '" class="label label-success">' + row.StatusName + '</span>';
                                        else
                                            return '<span id="StatusName' + row.OrderId + '" class="label label-warning" > ' + row.StatusName+'</span>';
                                    }
                                },
                                { "data": "StrCreatedDate" },
                                { "data": "StrUpdatedDate" },
                                {
                                "mRender": function (data, type, row, meta) {
                                    if (row.IsDelete == false)
                                        return '<button class="btn label-success" value="0" id="Isdelete' + row.OrderId + '"><i style="color:white;"class="fa fa-check"></i></button>';
                                    else
                                        return '<button class="btn btn-danger" value="1"  id="Isdelete' + row.OrderId + '"><i class="fa fa-bank"></i></button>';
                                }
                                
                                },
                            ],
                            "columnDefs": [
                                
                                {
                                "targets": [5],
                                 "data": "OrderId",
                                "visible": true
                                },
                               
                            ],
                             "language": {  /* Chỉnh sửa lại ngôn ngữ  */
                                "paginate": {
                                    "previous": "<",
                                    "next": ">",
                                    "last": "Cuối",
                                }
                            },
                        });
                       
                    }
                }
                ,
                error: function () {
                    XFunction.RenderMessage('error', "có lỗi phía server ! ");
                }
            });


        }
      
    };
    LoadFunction.Order();



    /*Những gì update,delete, inset thì viết trong đây */
    var Function = {
        UpdateRow: function (id) {
            $.confirm({
                title: 'Xác nhận !',
                content: 'Bạn muốn liên hệ đến đơn hàng  ?',
                type: 'red',
                typeAnimated: true,
                buttons: {
                    tryAgain: {
                        text: 'OK',
                        btnClass: 'btn-red',
                        action: function () {
                            $.ajax({
                                url: "/admin/order/UpdateOrder",
                                type: 'POST',
                                async: false,
                                dataType: "json",
                                data: { id: id },
                                success: function (res) {
                                    if (res.Success == true) {
                                        XFunction.RenderMessage('success', res.Message);
                                        $('#StatusName' + id).removeClass("label-success");
                                        $('#StatusName' + id).last().addClass("label-warning");
                                        $('#StatusName' + id).html("Đã liên hệ");
                                        $('#Isdelete' + id).empty();
                                        $('#Isdelete' + id).val(1);
                                        $('#Isdelete' + id).removeClass('label-success');
                                        $('#Isdelete' + id).last().addClass("btn-danger");
                                        $('#Isdelete' + id).append('<i class="fa fa-bank"></i>');
                                    }
                                    else
                                        XFunction.RenderMessage('error', "Chưa liên hệ được khách hàng ! ");

                                },
                                error: function () {
                                    XFunction.RenderMessage('error', "có lỗi phía server ! ");
                                }
                            });
                        }
                    },
                    close: function () {
                    }
                }
            });
        },
        DeleteRow: function (id) {
            $.confirm({
                title: 'Xác nhận !',
                content: 'Bạn muốn xóa đơn hàng  ?',
                type: 'red',
                typeAnimated: true,
                buttons: {
                    tryAgain: {
                        text: 'OK',
                        btnClass: 'btn-red',
                        action: function () {

                            $.ajax({
                                url: "/admin/order/DeleteOrder",
                                type: 'POST',
                                async: false,
                                dataType: "json",
                                data: { id: id },
                                success: function (res) {
                                    if (res.Success == true) {
                                        table.row().remove().draw(false);
                                        XFunction.RenderMessage('success', res.Message);
                                    }
                                    else
                                        XFunction.RenderMessage('error', res.Message);
                                },
                                error: function () {
                                    XFunction.RenderMessage('error', "có lỗi phía server ! ");
                                }
                            });
                        }
                    },
                    close: function () {
                    }
                }
            });
            
        }
    }
   
   
    /* Sự kiện */
    $('#Order tbody').on('click', 'button', function () {
        var data = table.row($(this).parents('tr')).data();
        if (data) {
            var check = $('#Isdelete' + data.OrderId).val();
            if (check == 0)
                Function.UpdateRow(data.OrderId);
            else
                Function.DeleteRow(data.OrderId);
        }
        
    });
    /* Delete Item Row in table*/
    $('#DeleteRow').click(function () {
        //var data = table.row('.selected').data();
        //if (!data) { XFunction.RenderMessage('error', 'Chọn vào dòng để xóa !'); return false; }
        //Function.
        //table.row('.selected').remove().draw(false);

    })

    /* Sửa một dòng dữ liệu */
    $('#UpdateRow').click(function () {
        var ParentID = $('#ParentID').val();
        var data = table.row('.selected').data();
        if (!data) { XFunction.RenderMessage('error', 'Chọn vào dòng để sửa !'); return false; }

        if (data.CategoryId == ParentID)
            ParentID = 0; 

        var Name = $('#Name').val();
        if (!Name) { XFunction.RenderMessage('error', 'Chọn tên loại yêu cầu !'); return false; }
        var IsDelete = $("[name=IsDelete]:checked").val();
        if (IsDelete == 0) IsDelete = false; else IsDelete = true;

        var _model = { Name: Name, ParentID: ParentID, CategoryId: data.CategoryId, IsDelete: IsDelete };
        Function.UpdateRow(_model);
        LoadFunction.ParentID();

    })
});