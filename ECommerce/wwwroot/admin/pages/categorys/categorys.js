


$(document).ready(function () {
    var dataRR = [];
    $('#FDisPlay').css('display', 'none');
    var table = null;
    /*Load dữ liệu thì viết hết trong đây */
    var LoadFunction = {
        //load table 
        Category: function () {
            $.ajax({
                url: "/admin/Categorys/GetCategory",
                type: 'GET',
                async: false,
                dataType: "text",
                success: function (res) {
                    if (res) {
                        var R = JSON.parse(res);
                        table = $('#Category').DataTable({
                            scrollY: 500,
                            scrollCollapse: true,
                            scrollX: true,
                            responsive: true,
                            "data": R,
                            "columns": [

                                { "data": "Name" },
                                { "data": "ParentIDName" },
                                { "data": "StatusName" },
                                { "data": "IsHomeCheck" },
                                //{ "data": "DisplayCheck" },
                                //{ "data": "CreatedName" },
                                { "data": "UpdatedName" },
                                { "data": "CreatedDate" },
                                { "data": "UpdatedDate" },
                                { "data": "CategoryId" }, /*ẩn*/
                                { "data": "IsHome" }, /*ẩn*/
                                { "data": "Display" }, /*ẩn*/

                            ],
                            "columnDefs": [
                                
                                {
                                    "targets": [3],
                                    render: function (data, type, row) {
                                        if (row.IsHome == false && row.IsHome != undefined)
                                            return '<span id="IsHome' + row.OrderId + '" class="label label-warning">Không- Vị trí ' + row.Display + '</span>';
                                        else if (row.IsHome == true && row.IsHome != undefined)
                                            return '<span id="IsHome' + row.OrderId + '" class="label label-success" >Có- Vị trí ' + row.Display + '</span>';
                                    }
                                },
                                { "targets": [7], "visible": false, "searchable": false }, /*ẩn CategoryId*/
                                { "targets": [8], "visible": false, "searchable": false }, 
                                { "targets": [9], "visible": false, "searchable": false }, 
                              
                            ],
                            //"pagingType": "full_numbers", /* Phân trang thay thế phân trang có sẵn */
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


        },
        // load thuộc loại
        ParentID: function () {

            $.ajax({
                url: "/admin/Categorys/GetJtreeCategory",
                type: 'GET',
                async: true,
                dataType: "json",
                success: function (response) {
                    var data = [], item = {};
                    //item = { id: -1, parent: "#", text: "Chọn loại yêu cầu " };
                    //data.push(item);
                    $.each(response, function (index, item) {
                        data.push(
                            {
                                id: item.CategoryId,
                                parent: item.ParentID == 0 ? "#" : item.ParentID,
                                text: item.Name
                            });
                    });
                    dataRR = data;
                    Config.JTree("Categorys-tree", "Categorys", "ParentID", data);
                    Config.RefreshJtreeOnAddNewItem("Categorys-tree", data);
                }
            });
            

        },
        Display: function () {
            $.ajax({
                url: "/admin/Categorys/GetCategory",
                type: 'GET',
                async: false,
                dataType: "text",
                success: function (res) {
                  
                }
            });
           
        }
    };
    LoadFunction.Category();
    LoadFunction.ParentID();


    /*Những gì update,delete, inset thì viết trong đây */
    var Function = {
        CreateRow: function (data) {
            $.confirm({
                title: 'Xác nhận !',
                content: 'Bạn muốn tạo loại yêu cầu ?',
                type: 'red',
                typeAnimated: true,
                buttons: {
                    tryAgain: {
                        text: 'OK',
                        btnClass: 'btn-red',
                        action: function () {
                           
                             $.ajax({
                                url: "/admin/Categorys/Create",
                                 type: 'POST',
                                async: false,
                                dataType: "text",
                                data: { _model:data },
                                 success: function (data) {
                                     var data = JSON.parse(data);
                                   
                                    table.row.add({
                                        CategoryId: data.Data.CategoryId,
                                        CreatedDate: data.Data.CreatedDate,
                                        //CreatedName: data.Data.CreatedName,
                                        IsDelete: data.Data.IsDelete,
                                        Name: data.Data.Name,
                                        ParentID: data.Data.ParentIDName,
                                        ParentIDName: data.Data.ParentIDName,
                                        StatusName: data.Data.StatusName,
                                        IsHome: data.Data.IsHome,
                                        Display:data.Data.Display,
                                        UpdatedDate: data.Data.UpdatedDate,
                                        UpdatedName: data.Data.UpdatedName
                                    }).draw();

                                     if (!data)
                                         return false;
                                     if (data.Success == true) {
                                         LoadFunction.ParentID(); // phải chạy đồng bộ mới làm được 
                                         $('#Categorys').val('');
                                         XFunction.RenderMessage('success', data.Message);
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
        UpdateRow: function (_model) {
            $.confirm({
                title: 'Xác nhận !',
                content: 'Bạn muốn sửa loại yêu cầu ?',
                type: 'red',
                typeAnimated: true,
                buttons: {
                    tryAgain: {
                        text: 'OK',
                        btnClass: 'btn-red',
                        action: function () {
                            $.ajax({
                                url: "/admin/Categorys/UpdateRow",
                                type: 'POST',
                                async: false,
                                dataType: "text",
                                data: { _model: _model },
                                success: function (res) {

                                    var data = JSON.parse(res);
                                    if (data.Success == true) {
                                        table.row('.selected').remove().draw(false); // xóa dòng đã chọn 
                                        //tạo lại dòng cập nhật
                                        table.row.add({
                                           
                                            CreatedDate: data.Data.CreatedDate,
                                            //CreatedName: data.Data.CreatedName,
                                            IsDelete: data.Data.IsDelete,
                                            Name: data.Data.Name,
                                            ParentIDName: data.Data.ParentIDName,
                                            StatusName: data.Data.StatusName,
                                            IsHomeCheck: (data.Data.IsHome == false && data.Data.IsHome != undefined) ? '< span id="IsHomeundefined" class= "label label-warning" > Không</span>' : '< span id="IsHomeundefined" class= "label label-success" >Có</span>',
                                            DisplayCheck: data.Data.Display != undefined ? '<span id="Display' + data.Data.Display + '" class="label label-success">' + "Vị trí thứ " + data.Data.Display+ '</span>' : "",
                                            Display: data.Data.Display,
                                            UpdatedDate: data.Data.UpdatedDate,
                                            UpdatedName: data.Data.UpdatedName,
                                            CategoryId: data.Data.CategoryId,
                                            IsHome: data.Data.IsHome,
                                            ParentID: data.Data.ParentID,
                                        }).draw(false);
                                        if (data.Data.IsHome == false)
                                            $('#FDisPlay').css('display', 'none');
                                        else
                                            $('#FDisPlay').css('display', 'block');

                                        LoadFunction.ParentID();
                                    }

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
        },
        DeleteRow: function () {
            $.ajax({
                url: "/admin/Categorys/DeleteRow",
                type: 'POST',
                async: false,
                dataType: "text",
                data: { _model: _model },
                success: function (res) {
                    var data = JSON.parse(res);
                    XFunction.RenderMessage('success', data.Message);
                },
                error: function () {
                    XFunction.RenderMessage('error', "có lỗi phía server ! ");
                }
            });
        }
    }
    /**************BẮT BUỘC PHẢI CÓ ĐẦY ĐỦ NẾU MUỐN DÙNG ***************/
    // config jtree dùng chung cho tất cả
    var Config = {
        DefaultJtree: function (txtjtree, txtId, defaultvalue, txtnameval, defaultname) {

            $('#' + txtjtree + '').jstree("deselect_all");
            $('#' + txtjtree + '').jstree("close_all");
            $('#' + txtId + '').val(defaultvalue);
            $('#' + txtnameval + '').val(defaultname);
            
        },
        RefreshJtree: function (txtjtree, txtId, defaultvalue, txtnameval, defaultname) {
            $('#' + txtjtree + '').jstree("deselect_all");
            $('#' + txtjtree + '').jstree("close_all");
            $('#' + txtId + '').val(defaultvalue);
            $('#' + txtnameval + '').val(defaultname);
        },
        SelectedWhenEventClick: function (txtjtree, txtId,txtParentId,txtShow, value) {
            $('#' + txtjtree + '').jstree("deselect_all"); // 
            $('#' + txtjtree + '').jstree("close_all");//
            $('#' + txtParentId + '').val(value.id);
            $('#' + txtId+'').val(value.text);
            //$('#' + txtjtree + '').focus();
            //$('#' + txtShow + '').show();
            $('#' + txtjtree + '').jstree('select_node',"s"+value);
            $('#' + txtjtree + '').jstree("search", value.text);
           
        },
        MouseupJtree: function (txtjtree, txtId) {
           // sự kiện trời chuột kích vào một nơi khác của jtree thì hide danh mục sổ xuống trong jtree
            $(document).mouseup(function (e) {
                var Categorys = $('#' + txtjtree + ''), txtCategorys = $('#'+txtId+'');
                if (!Categorys.is(e.target)
                    && Categorys.has(e.target).length === 0 && !txtCategorys.is(e.target)) {
                    Categorys.hide();
                }

            });
        },
        JtreeSearch: function (txtjtree, txtId) {
            $('#' + txtId + '').on('keyup', function () {
                // var to = false;
                //if (to) { clearTimeout(to); }
                setTimeout(function () {
                    var v = $('#' + txtId + '').val();
                    $('#' + txtjtree + '').jstree(true).search(v);
                }, 250);
            });
            $('#' + txtId + '').on('keypress', function (e) {
                if (e.which == 13) {
                    e.preventDefault();
                }
            })
        },
        RefreshJtreeOnAddNewItem: function (txtjtree,R) {
            $('#' + txtjtree + '').jstree(true).settings.core.data = R;
            $('#' + txtjtree+'').jstree(true).refresh();
        },
        JTree: function (txtjtree, txtname, txtvalue, data) {
            $('#' + txtjtree + '').on('changed.jstree', function (e, data) {
                $('#Categorys-tree-T').hide();
                var i, j, r = [];
                for (i = 0, j = data.selected.length; i < j; i++) {
                    $('#' + txtvalue + '').val(data.instance.get_node(data.selected[i]).id);
                    $('#' + txtname + '').val(data.instance.get_node(data.selected[i]).text);
                }
            }).jstree({
                'core': {
                    'data': data,
                    "multiple": false,
                    "animation": 0,
                    "themes": {
                        "variant": "large"
                    }
                },
                /* thêm check box */
                //"checkbox": {
                //    "keep_selected_style": true
                //},
                "search": {
                    "case_insensitive": false, // cấu hình cho phần search tìm theo like 
                    "show_only_matches": false  // khi tìm vẫn dữ nguyên các loại còn lại 
                },

                "plugins": [/* Thêm check box "checkbox"*/ "search", "wholerow", "types", "changed", "unique"],
                "types": {
                    "default": {
                        "icon": "/Admin/images/Maps-Pin-Place-icon.png"
                    }
                },
            });
        }
    }
   
    Config.DefaultJtree("Categorys-tree",'ParentID','0',"Categorys",'Chọn loại yêu cầu ')
    Config.JtreeSearch("Categorys-tree", "searchCategorys");
    Config.MouseupJtree("Categorys-tree-T", "Categorys");

    $('#Categorys-tree-T').hide();
    $('#Categorys').click(function () {
        $('#Categorys-tree-T').toggle();
        $('#searchCategorys').focus();
    });
    $('#refreshCategorys').click(function () {
        Config.RefreshJtree("Categorys-tree", 'ParentID', '0', "Categorys", 'Chọn loại yêu cầu ');
        table.$('tr.selected').removeClass('selected');
    });
  
   
     /**************BẮT BUỘC PHẢI CÓ ĐẦY ĐỦ NẾU MUỐN DÙNG ***************/

    $("#StatusHome").change(function () {
        if ($(this).is(":checked") == true) {
            $('#FDisPlay').css('display', 'block');
            $(this).val(1);
        }
        else {
            $(this).val(0);
            $('#FDisPlay').css('display', 'none');
        }
    })
    /* Sự kiện */
    $('#Category').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        }
        else {
           
            table.$('tr.selected').removeClass('selected');
            
            $(this).addClass('selected');
            var data = table.row('.selected').data();
           
            if (!data) { return false };
            $('#Name').val(data.Name);
        
            if (data.Display != null || data.Display != undefined)
                $("#Display").val(data.Display).change();
            
            if (data.IsDelete == false) {
                $("#StatusOff").prop("checked", false)
                $("#StatusOn").prop("checked", true)
            }
            else {
                $("#StatusOn").prop("checked", false)
                $("#StatusOff").prop("checked", true)
            };

            if (data.IsHome == false) {
                $('#FDisPlay').css('display', 'none');
                $("#StatusHome").prop("checked", false);
            }
            else
            {
                $("#StatusHome").prop("checked", true);
                $('#FDisPlay').css('display', 'block');
            }

            var newdata = {
                id: data.CategoryId,
                parent: data.ParentID,
                text: data.Name
            };
            Config.SelectedWhenEventClick("Categorys-tree", "Categorys", "ParentID", "Categorys-tree-T", newdata);
            

        }
    });
    /* Delete Item Row in table*/
    $('#DeleteRow').click(function () {
        //var data = table.row('.selected').data();
        //if (!data) { XFunction.RenderMessage('error', 'Chọn vào dòng để xóa !'); return false; }
        //Function.
        //table.row('.selected').remove().draw(false);

    })

    /* Tạo mới 1 Row Add vào table */
    $('#CreateRow').click(function () {
        if (!$('#Name').val()) { XFunction.RenderMessage('error', 'Nhập tên loại yêu cầu !'); return false; }
        var ParentID = $('#ParentID').val();
        //if (ParentID == -1) { ParentID = 0 }
        var data =
        {
            Name: $('#Name').val(),
            ParentID: ParentID,
            IsDelete: $("[name=IsDelete]:checked").val() == 0 ? false : true,
            //IsHome: $("#StatusHome").val() == 0 ? false : true,
            //Display: $("#Display").val()
        }
        Function.CreateRow(data);
        
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
        var IsHome = $("#StatusHome").val() == 0 ? false : true;
        var Display = $("#Display").val();
        var _model = { Name: Name, ParentID: ParentID, CategoryId: data.CategoryId, IsDelete: IsDelete, IsHome: IsHome,Display: Display};
        
        Function.UpdateRow(_model);
        

    })

    /*Hủy*/
    $('#Cannel').click(function () {
        var data = table.row('.selected').data();
        if (data) {
            table.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
            $('#Name').val("");
            $("#StatusOff").prop("checked", false);
            $("#StatusOn").prop("checked", true);
        }
        Config.RefreshJtree("Categorys-tree", 'ParentID', '0', "Categorys", 'Chọn loại yêu cầu ');
        LoadFunction.ParentID();

    })
    
   
});