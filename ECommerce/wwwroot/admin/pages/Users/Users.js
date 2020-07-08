


$(document).ready(function () {
    $('#myDatepicker2').datetimepicker({
        format: 'DD/MM/YYYY'
    });
    var TableUser = null;
    /*Load dữ liệu thì viết hết trong đây */
    var LoadFunction = {
        //load table 
        User: function () {
            $.ajax({
                url: "/admin/User/GetUser",
                type: 'POST',
                dataType: "json",
                success: function (res) {
                        TableUser = $('#TableUser').DataTable({
                            scrollY: 500,
                            scrollCollapse: true,
                            scrollX: true,
                            responsive: true,
                            "data": (res),
                            responsive: true,
                            "columns": [

                                { "data": "Username" },
                                { "data": "Role" },
                                { "data": "FullName" },
                                { "data": "Phone" },
                                { "data": "SexName" },
                                { "data": "StrBirthday" },
                                { "data": "Email" },
                                { "data": "Address" },
                                { "data": "Status" },
                                { "data": "CreatedName" },
                                { "data": "StrCreatedDate" },
                                { "data": "UpdatedName" },
                                { "data": "StrUpdatedDate" },
                                { "data": "UserId" },/*ẩn*/
                                { "data": "RoleId" }, /*ẩn*/
                                { "data": "Sex" }, /*ẩn*/
                                { "data": "IsDelete" }, /*ẩn*/

                            ],
                            "columnDefs": [
                                { "targets": [13], "visible": false, "searchable": false },
                                { "targets": [14], "visible": false, "searchable": false },
                                { "targets": [15], "visible": false, "searchable": false },
                                { "targets": [16], "visible": false, "searchable": false }
                            ],

                            "language": {
                                "paginate": {
                                    "previous": "<",
                                    "next": ">",
                                    "last": "Cuối",
                                }
                            },
                    });
                    
                }
                ,
                error: function () {
                    XFunction.RenderMessage('error', "có lỗi phía server ! ");
                }
            });


        },
    };
    LoadFunction.User();

    /*Những gì update,delete, inset thì viết trong đây */
    var Function = {
        CreateRow: function (data) {
            $.confirm({
                title: 'Xác nhận !',
                content: 'Bạn muốn tạo tài khoản  ?',
                type: 'red',
                typeAnimated: true,
                buttons: {
                    tryAgain: {
                        text: 'OK',
                        btnClass: 'btn-red',
                        action: function () {
                            debugger
                            $.ajax({
                                url: "/admin/User/Create",
                                type: 'POST',
                                async: false,
                                dataType: "text",
                                data: { _model: data },
                                success: function (res) {
                                    var data = JSON.parse(res);
                                    if (data.Success == true) {
                                       
                                        XFunction.RenderMessage('success', data.Message);
                                        $('#IdModal').modal('hide');
                                        TableUser.row.add({
                                            Username: data.Data.Username,
                                            Role: data.Data.Role,
                                            FullName: data.Data.FullName,
                                            Phone: data.Data.Phone,
                                            SexName: data.Data.SexName,
                                            StrBirthday: data.Data.StrBirthday,
                                            Email: data.Data.Email,
                                            Address: data.Data.Address,
                                            Status: data.Data.Status,
                                            CreatedName: data.Data.CreatedName,
                                            StrCreatedDate: data.Data.StrCreatedDate,
                                            UpdatedName: data.Data.UpdatedName,
                                            StrUpdatedDate: data.Data.StrUpdatedDate,
                                            UserId: data.Data.UserId,
                                            RoleId: data.Data.RoleId,
                                            Sex: data.Data.Sex,
                                            IsDelete: data.Data.IsDelete
                                            
                                        }).draw();

                                    }
                                    else 
                                        XFunction.RenderMessage('success', data.Message);
                                },
                                error: function (data) {
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
        UpdateRow: function (_model) {
            $.confirm({
                title: 'Xác nhận !',
                content: 'Bạn muốn chỉnh sửa tài khoản  ?',
                type: 'red',
                typeAnimated: true,
                buttons: {
                    tryAgain: {
                        text: 'OK',
                        btnClass: 'btn-red',
                        action: function () {
                         
                            $.ajax({
                                url: "/admin/User/UpdateUser",
                                type: 'POST',
                                async: false,
                                dataType: "text",
                                data: { _model: _model },
                                success: function (res) {
                                 
                                    var data = JSON.parse(res);
                                    if (data) {
                                      
                                        TableUser.row('.selected').remove().draw(false); // xóa dòng 
                                        TableUser.row.add({
                                            Username: data.Data.Username,
                                            Role: data.Data.Role,
                                            FullName: data.Data.FullName,
                                            Phone: data.Data.Phone,
                                            SexName: data.Data.SexName,
                                            StrBirthday: data.Data.StrBirthday,
                                            Email: data.Data.Email,
                                            Address: data.Data.Address,
                                            Status: data.Data.Status,
                                            CreatedName: data.Data.CreatedName,
                                            StrCreatedDate: data.Data.StrCreatedDate,
                                            UpdatedName: data.Data.UpdatedName,
                                            StrUpdatedDate: data.Data.StrUpdatedDate,
                                            UserId: data.Data.UserId,
                                            RoleId: data.Data.RoleId,
                                            Sex: data.Data.Sex,
                                            IsDelete: data.Data.IsDelete
                                           
                                        }).draw();
                                        $('#IdModal').modal('hide');
                                        XFunction.RenderMessage('success', data.Message);
                                    }
                                    else
                                        XFunction.RenderMessage('error', data.Message);
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
        DeleteRow: function (_model) {
            $.confirm({
                title: 'Xác nhận !',
                content: 'Bạn muốn xóa tài khoản  ?',
                type: 'red',
                typeAnimated: true,
                buttons: {
                    tryAgain: {
                        text: 'OK',
                        btnClass: 'btn-red',
                        action: function () {
                            $.ajax({
                                url: "/admin/User/DeleteUser",
                                type: 'POST',
                                async: false,
                                dataType: "json",
                                data: { _model: _model },
                                success: function (data) {
                                    TableUser.row('.selected').remove().draw(false); // xóa dòng 
                                    TableUser.row.add({
                                        Username: data.Data.Username,
                                        Role: data.Data.Role,
                                        FullName: data.Data.FullName,
                                        Phone: data.Data.Phone,
                                        SexName: data.Data.SexName,
                                        StrBirthday: data.Data.StrBirthday,
                                        Email: data.Data.Email,
                                        Address: data.Data.Address,
                                        Status: data.Data.Status,
                                        CreatedName: data.Data.CreatedName,
                                        StrCreatedDate: data.Data.StrCreatedDate,
                                        UpdatedName: data.Data.UpdatedName,
                                        StrUpdatedDate: data.Data.StrUpdatedDate,
                                        UserId: data.Data.UserId,
                                        RoleId: data.Data.RoleId,
                                        Sex: data.Data.Sex,
                                        IsDelete: data.Data.IsDelete
                                    }).draw();
                                    $('#IdModal').modal('hide');

                                    XFunction.RenderMessage('success', data.Message);
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
    $('#TableUser').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        }
        else {
            
            TableUser.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
            var data = TableUser.row('.selected').data();
            if (!data) { return false };
            $('#UserName').val(data.Username);
            $('#Password').val('');
            $('#FullName').val(data.FullName);

      
            $('#NgaySinh').val(data.StrBirthday);
           
            $('#Address').val(data.Address);
            $('#Email').val(data.Email);
            $('#Phone').val(data.Phone);
            $("#Permission").val(data.RoleId).change();
            if (data.Sex == false) {
            $("#Nu").prop("checked", false)
            $("#Nam").prop("checked", true)
            }
            else {
                $("#Nam").prop("checked", false);
                $("#Nu").prop("checked", true);
            };
            if (data.IsDelete == false) {
                $("#StatusOff").prop("checked", false)
                $("#StatusOn").prop("checked", true)
            }
            else {
                $("#StatusOn").prop("checked", false)
                $("#StatusOff").prop("checked", true)

            };
        }
    });
    /* Delete Item Row in table*/
    $('#DeleteRow').click(function () {
        var data = TableUser.row('.selected').data();
        if (!data) { XFunction.RenderMessage('error', 'Chọn vào dòng để xóa !'); return false; }
        var model = { UserId: data.UserId, IsDelete: true }
        Function.DeleteRow(model);

    })
    /* Tạo mới 1 Row Add vào table */
    $('#CreateRow').click(function () {    
        var UserName = $('#UserName').val();
        if (Validater.CheckUserName(UserName) == false) { XFunction.RenderMessage('error', 'Tên tài khoản phải không dấu, không khoảng trắng, không có kí tự đặc biệt và không vượt quá 100 chữ !'); return false; }
        if (!UserName) { XFunction.RenderMessage('error', 'Nhập tên tài khoản !'); return false; }
        var Password = $('#Password').val();
        if (!Password) { XFunction.RenderMessage('error', 'Nhập mật khẩu !'); return false; }
        var Permission = $('#Permission').val(); 
        if (Permission == -1 ) { XFunction.RenderMessage('error', 'Nhập nhóm quyền !'); return false; }
        var FullName = $('#FullName').val();
        if (!FullName) { XFunction.RenderMessage('error', 'Nhập tên đầy đủ !'); return false; }
        var Sex = $("[name=Sex]:checked").val();
        if (Sex == 0) Sex = false; else Sex = true;
        var IsDelete = $("[name=IsDelete]:checked").val() == 0 ? false : true;
        var Email = $('#Email').val();
        if (!Email) { Email = ""; }
        var BirthDay = $('#NgaySinh').val();
        
        if (!BirthDay) { XFunction.RenderMessage('error', 'Nhập ngày sinh !'); return false; }
        var Address = $('#Address').val();
        if (!Address) { XFunction.RenderMessage('error', 'Nhập địa chỉ !'); return false; }
        var Phone = $('#Phone').val();
        if (!Phone) { XFunction.RenderMessage('error', 'Nhập số điện thoại !'); return false; }

        BirthDay = BirthDay.split("/").reverse().join("/");
        var data =
        {
            UserName: UserName,
            Password: Password,
            FullName: FullName,
            Email: Email,
            Role: Permission,
            RoleId: Permission,
            BirthDay: BirthDay,
            Sex: Sex,
            IsDelete: IsDelete,
            Phone: Phone,
            Address: Address
        }
        
        Function.CreateRow(data)
    })
    /* Sửa một dòng dữ liệu */
    $('#UpdateRow').click(function () {
        
        var data = TableUser.row('.selected').data();
        if (!data) { XFunction.RenderMessage('error', 'Chọn vào dòng để sửa !'); return false; }
        var UserName = $('#UserName').val();
        if (!UserName) { XFunction.RenderMessage('error', 'Nhập tên tài khoản !'); return false; }
        var Password = $('#Password').val();
        var Permission = $('#Permission').val();
        if (Permission == -1) { XFunction.RenderMessage('error', 'Nhập nhóm quyền !'); return false; }
        var FullName = $('#FullName').val();
        if (!FullName) { XFunction.RenderMessage('error', 'Nhập tên đầy đủ !'); return false; }
        var Sex = $("[name=Sex]:checked").val();
        if (Sex == 0) Sex = false; else Sex = true;
        var IsDelete = $("[name=IsDelete]:checked").val();
        if (IsDelete == 0) IsDelete = false; else IsDelete = true;
        var Email = $('#Email').val();
        if (!Email) { Email = ""; }
        var BirthDay = $('#NgaySinh').val();
        if (!BirthDay) { XFunction.RenderMessage('error', 'Nhập ngày sinh !'); return false; }
        var Address = $('#Address').val();
        if (!Address) { XFunction.RenderMessage('error', 'Nhập địa chỉ !'); return false; }
        var Phone = $('#Phone').val();
        if (!Phone) { XFunction.RenderMessage('error', 'Nhập số điện thoại !'); return false; }
      
        BirthDay = BirthDay.split("/").reverse().join("/");
        var _model = {
            UserId: data.UserId, UserName: data.UserName, Password: Password, Role: Permission, FullName: FullName,
            Sex: Sex, IsDelete: IsDelete, Email: Email, BirthDay: BirthDay, Address: Address, Phone: Phone
        };
        Function.UpdateRow(_model);
       
    })
    /*Hủy*/
    $('#Cannel').click(function () {
        var data = TableUser.row('.selected').data();
        if (data) {
            TableUser.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
            $('#UserName').val('');
            $('#Password').val('');
            $("#Permission").val(-1).change();
            $('#FullName').val('');
            $("#Nu").prop("checked", false);
            $("#Nam").prop("checked", true);
            $('#Email').val('');
            $('#NgaySinh').val("01/01/2019");
            $('#Address').val('');
            $('#Phone').val('');
            $("#StatusOff").prop("checked", false);
            $("#StatusOn").prop("checked", true);
        }
        $('#IdModal').modal('hide');
    })

    $('#CheckUpdate').click(function () {
        var data = TableUser.row('.selected').data();
        if (!data) { XFunction.RenderMessage('error', 'Chọn vào dòng để sửa !'); return false; }
        $('#CreateRow').css('display', 'none');
        $('#UpdateRow').css('display', 'inline-block');
        $("#UserName").prop('disabled', true);
    })
    $('#CheckCreate').click(function () {
        $("#UserName").prop('disabled', false);
        $('#IdModal').modal('show')
        $('#UserName').val('');
        $('#Password').val('');
        $("#Permission").val(-1).change();
        $('#FullName').val('');
        $("#Nu").prop("checked", false);
        $("#Nam").prop("checked", true);
        $('#Email').val('');
        $('#NgaySinh').val("01/01/1993");
        $('#Address').val('');
        $('#Phone').val('');
        $("#StatusOff").prop("checked", false);
        $("#StatusOn").prop("checked", true);
        $('#UpdateRow').css('display', 'none');
        $('#CreateRow').css('display', 'inline-block');
    })
    $('#modelclose').click(function () {
        $('#IdModal').modal('show')
        $('#UserName').val('');
        $('#Password').val('');
        $("#Permission").val(-1).change();
        $('#FullName').val('');
        $("#Nu").prop("checked", false);
        $("#Nam").prop("checked", true);
        $('#Email').val('');
        $('#NgaySinh').val("01/01/1993");
        $('#Address').val('');
        $('#Phone').val('');
        $("#StatusOff").prop("checked", false);
        $("#StatusOn").prop("checked", true);
       
    })
    
});