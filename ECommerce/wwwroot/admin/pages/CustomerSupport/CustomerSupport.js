

$(document).ready(function () {

    var table = null;
    /*Load dữ liệu thì viết hết trong đây */
    var LoadFunction = {
        //load table 
        GetCustomerSupport: function (){
            $.ajax({
                url: "/admin/CustomerSupport/GetCustomerSupport",
                type: 'POST',
                dataType: "json",
                success: function (res) {
                        table = $('#CustomerSupport').DataTable({
                            scrollY: 500,
                            scrollCollapse: true,
                            scrollX: true,
                            responsive: true,
                            "data": res,
                            "columns": [
                                { "data": "Name" },
                                { "data": "Phone" },
                                { "data": "CreatedName" },
                                { "data": "StrCreatedDate" },
                                { "data": "UpdatedName" },
                                { "data": "StrUpdatedDate" },
                                { "data": "CSId" },
                            ],
                            "columnDefs": [
                                { "targets": [6], "visible": false, "searchable": false, },
                            ],
                            "language": { 
                                "paginate": {
                                    "previous": "<",
                                    "next": ">",
                                    "last": "Cuối",
                                }
                            },
                        });
                    
                },
                error: function () {
                    XFunction.RenderMessage('error', "có lỗi phía server ! ");
                }
            });  
        },

    };
    LoadFunction.GetCustomerSupport();

    var Function = {
        CreateRow: function (data) {
            $.confirm({
                title: 'Xác nhận !',
                content: 'Bạn muốn thêm hỗ trợ ?',
                type: 'red',
                typeAnimated: true,
                buttons: {
                    tryAgain: {
                        text: 'OK',
                        btnClass: 'btn-red',
                        action: function () {

                            $.ajax({
                                url: "/admin/CustomerSupport/CreateCustomerSupport",
                                type: 'POST',
                                async: false,
                                dataType: "text",
                                data: { _model: data },
                                success: function (res) {
                                    var data = JSON.parse(res);
                                    if (data.Success == true) {
                                        table.row.add({
                                            Name: data.Data.Name,
                                            Phone: data.Data.Phone,
                                            CreatedName: data.Data.CreatedName,
                                            StrCreatedDate: data.Data.StrCreatedDate,
                                            UpdatedName: data.Data.UpdatedName,
                                            StrUpdatedDate: data.Data.StrUpdatedDate,
                                            CSId: data.Data.CSId
                                        }).draw();
                                        XFunction.RenderMessage('success', data.Message);
                                        $('#Name').val('');
                                        $('#Phone').val('')
                                    }
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
        UpdateRow: function (data) {
            $.confirm({
                title: 'Xác nhận !',
                content: 'Bạn muốn sửa thông tin hỗ trợ ?',
                type: 'red',
                typeAnimated: true,
                buttons: {
                    tryAgain: {
                        text: 'OK',
                        btnClass: 'btn-red',
                        action: function () {

                            $.ajax({
                                url: "/admin/CustomerSupport/UpdateCustomerSupport",
                                type: 'POST',
                                async: false,
                                dataType: "json",
                                data: { _model: data },
                                success: function (data) {
                                    table.row('.selected').remove().draw(false); // xóa dòng đã chọn 
                                    //tạo lại dòng cập nhật
                                    if (data.Success == true) {
                                        table.row.add({
                                            Name: data.Data.Name,
                                            Phone: data.Data.Phone,
                                            CreatedName: data.Data.CreatedName,
                                            StrCreatedDate: data.Data.StrCreatedDate,
                                            UpdatedName: data.Data.UpdatedName,
                                            StrUpdatedDate: data.Data.StrUpdatedDate,
                                            CSId: data.Data.CSId
                                        }).draw();
                                        XFunction.RenderMessage('success', data.Message);
                                    }
                                    else
                                        XFunction.RenderMessage('success', data.Message);

                                    $('#Name').val('');
                                    $('#Phone').val('')
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
        DeleteRow: function (Id,Name) {
            
            $.confirm({
                title: 'Xác nhận !',
                content: 'Bạn muốn xóa ' + Name + '?',
                type: 'red',
                typeAnimated: true,
                buttons: {
                    tryAgain: {
                        text: 'OK',
                        btnClass: 'btn-red',
                        action: function () {

                            $.ajax({
                                url: "/admin/CustomerSupport/DeleteCustomerSupport",
                                type: 'POST',
                                async: false,
                                dataType: "json",
                                data: { Id: Id },
                                success: function (data) {
                                    if (data.Success == true) {
                                        table.row('.selected').remove().draw(false); // xóa dòng đã chọn 
                                        XFunction.RenderMessage('success', data.Message);
                                    }
                                    else
                                        XFunction.RenderMessage('error', data.Message);
                                    $('#Name').val('');
                                    $('#Phone').val('')
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
    $('#CustomerSupport').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        }
        else {
           
            table.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
            var data = table.row('.selected').data();
            if (!data) { return false };
            $('#Name').val(data.Name);
            $('#Phone').val(data.Phone)
           
        }
    });



    $('#CreateRow').click(function () {

        if (!$('#Name').val()) { XFunction.RenderMessage('error', 'Nhập tên người hỗ trợ !'); return false; }
        if (!$('#Phone').val()) { XFunction.RenderMessage('error', 'Nhập số điện thoại hỗ trợ !'); return false; }
        var data =
        {
            Name: $('#Name').val(),
            Phone: $('#Phone').val(),
            IsDelete: false
        }
        Function.CreateRow(data)
    })

    $('#UpdateRow').click(function () {
        
        var data = table.row('.selected').data();
        if (!data) { XFunction.RenderMessage('error', 'Chọn dòng để sửa !'); return false; }
        if (!$('#Name').val()) { XFunction.RenderMessage('error', 'Nhập tên người hỗ trợ !'); return false; }
        if (!$('#Phone').val()) { XFunction.RenderMessage('error', 'Nhập số điện thoại hỗ trợ !'); return false; }
        var data =
        {
            Name: $('#Name').val(),
            Phone: $('#Phone').val(),
            IsDelete: $("[name=IsDelete]:checked").val(),
            CSId: data.CSId
        }
        Function.UpdateRow(data)
    })
    
    $('#DeleteRow').click(function () {
        var data = table.row('.selected').data();
        if (!data) { XFunction.RenderMessage('error', 'Chọn dòng để xóa !'); return false; }
        Function.DeleteRow(data.CSId,data.Name);
    });
    /*Hủy*/
    $('#Cannel').click(function () {
        var data = table.row('.selected').data();
        if (data) {
            table.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }
        $('#Name').val(""); $('#Phone').val('');
    })


});