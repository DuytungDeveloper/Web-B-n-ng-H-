

$(document).ready(function () {

    /*Load dữ liệu thì viết hết trong đây */
    var LoadFunction = {
        GetBanner: function () {
            $.ajax({
                url: "/admin/Banner/GetBanner",
                type: 'POST',
                dataType: "json",
                async: false,
                success: function (res) {


                    if (!res) return false;
                    // sắp xếp banner đúng 
                    res.sort(function (a, b) {
                        if (a.BannerId > b.BannerId) {
                            return 1;
                        }
                        if (a.BannerId < b.BannerId) {
                            return -1;
                        }
                        return 0;
                    });

                    if (res.length > 0) {
                        var dem = 0;
                        $.each(res, function (index, item) {
                            dem++;
                            $('#CreateRow' + dem.toString()).val("0");
                            $('#CreateRow' + dem.toString()).html('Sửa');
                            switch (dem) {
                                case 1:
                                    {
                                        $('#Name1').val(item.TitleUp);
                                        $('#Name11').val(item.TitleDown);
                                        if (item.IsDelete == false) {
                                            $('#StatusOff' + dem.toString()).prop("checked", false)
                                            $('#StatusOn' + dem.toString()).prop("checked", true)
                                        }
                                        else {
                                            $('#StatusOn' + dem.toString()).prop("checked", false)
                                            $('#StatusOff' + dem.toString()).prop("checked", true)
                                        };

                                    }
                                    break;
                                case 2:
                                    {
                                        $('#Name2').val(item.TitleUp);
                                        $('#Name22').val(item.TitleDown);
                                        if (item.IsDelete == false) {
                                            $('#StatusOff' + dem.toString()).prop("checked", false)
                                            $('#StatusOn' + dem.toString()).prop("checked", true)
                                        }
                                        else {
                                            $('#StatusOn' + dem.toString()).prop("checked", false)
                                            $('#StatusOff' + dem.toString()).prop("checked", true)
                                        };
                                    }
                                    break;
                                case 3:
                                    {
                                        $('#Name3').val(item.TitleUp);
                                        $('#Name33').val(item.TitleDown);
                                        if (item.IsDelete == false) {
                                            $('#StatusOff' + dem.toString()).prop("checked", false)
                                            $('#StatusOn' + dem.toString()).prop("checked", true)
                                        }
                                        else {
                                            $('#StatusOn' + dem.toString()).prop("checked", false)
                                            $('#StatusOff' + dem.toString()).prop("checked", true)
                                        };
                                    }
                                    break;
                                case 4:
                                    {
                                        $('#Name4').val(item.TitleUp);
                                        $('#Name44').val(item.TitleDown);
                                        if (item.IsDelete == false) {
                                            $('#StatusOff' + dem.toString()).prop("checked", false)
                                            $('#StatusOn' + dem.toString()).prop("checked", true)
                                        }
                                        else {
                                            $('#StatusOn' + dem.toString()).prop("checked", false)
                                            $('#StatusOff' + dem.toString()).prop("checked", true)
                                        };
                                    }
                                    break;
                                case 5:
                                    {
                                        $('#Name5').val(item.TitleUp);
                                        $('#Name55').val(item.TitleDown);
                                        if (item.IsDelete == false) {
                                            $('#StatusOff' + dem.toString()).prop("checked", false)
                                            $('#StatusOn' + dem.toString()).prop("checked", true)
                                        }
                                        else {
                                            $('#StatusOn' + dem.toString()).prop("checked", false)
                                            $('#StatusOff' + dem.toString()).prop("checked", true)
                                        };
                                    }
                                    break;
                            }

                            var Html = "";
                            Html = '<div class="ULH"><a href="' + item.ImgUrl + '" id="IMG' + dem + '" target="_blank" class="renderlink" data-id="' + dem + '" data-value="' + item.BannerId + '" ><img class="IMG" src="' + item.ImgUrl + '"height="42" width="42"></a></div>';
                            $('#displayimg' + (dem).toString()).append(Html);

                        });

                    }
                }
            });
        }
    };
    LoadFunction.GetBanner();
    /*Những gì update,delete, inset thì viết trong đây */
    var Function = {
        CreateRow: function (fdata, indexchange) {

            $.confirm({
                title: 'Xác nhận !',
                content: 'Bạn muốn tạo Banner ?',
                type: 'red',
                typeAnimated: true,
                buttons: {
                    tryAgain: {
                        text: 'OK',
                        btnClass: 'btn-red',
                        action: function () {

                            $.ajax({
                                url: "/admin/banner/CreateBanner",
                                type: 'POST',
                                contentType: false,
                                processData: false,
                                async: false,
                                dataType: 'json',
                                data: fdata,
                                success: function (res) {
                                    XFunction.RenderMessage('success', res.Message);
                                    $('#CreateRow' + indexchange.toString()).val('0')
                                    $('#CreateRow' + indexchange.toString()).html("Sửa")
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
        UpdateRow: function (fdata, indexchange) {
            $.confirm({
                title: 'Xác nhận !',
                content: 'Bạn muốn sửa Banner ?',
                type: 'red',
                typeAnimated: true,
                buttons: {
                    tryAgain: {
                        text: 'OK',
                        btnClass: 'btn-red',
                        action: function () {

                            $.ajax({
                                url: "/admin/Banner/UpdateBanner",
                                type: 'POST',
                                contentType: false,
                                processData: false,
                                async: false,
                                dataType: 'json',
                                data: fdata,
                                success: function (res) {
                                     XFunction.RenderMessage('success', res.Message);
                                }
                                ,
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
        DeleteRow: function (Id) {
            $.confirm({
                title: 'Xác nhận !',
                content: 'Bạn muốn xóa Banner ?',
                type: 'red',
                typeAnimated: true,
                buttons: {
                    tryAgain: {
                        text: 'OK',
                        btnClass: 'btn-red',
                        action: function () {

                            $.ajax({
                                url: "/admin/Banner/DeleteBanner",
                                type: 'POST',
                                async: false,
                                data: {
                                    BannerId: Id, IsDelete: true
                                },
                                dataType: "text",
                                success: function (res) {
                                    var data = JSON.parse(res);
                                    if (data.Success == true)
                                        XFunction.RenderMessage('success', "Xóa thành công !");
                                    else {
                                        XFunction.RenderMessage('success', data.Message); return false;
                                    }
                                    switch (Id) {
                                        case 1:
                                            {
                                                BannerID = $('#displayimg' + Id.toString()).empty();
                                                $('#Name1').val('');
                                                $('#Name11').val('');
                                                $('#StatusOff' + Id.toString()).prop("checked", false);
                                                $('#StatusOn' + Id.toString()).prop("checked", true);
                                            }
                                            break;
                                        case 2:
                                            {
                                                BannerID = $('#displayimg' + Id.toString()).empty();
                                                $('#Name2').val('');
                                                $('#Name22').val('');
                                                $('#StatusOff' + Id.toString()).prop("checked", false);
                                                $('#StatusOn' + Id.toString()).prop("checked", true);
                                             
                                            }
                                            break;
                                        case 3:
                                            {
                                                BannerID = $('#displayimg' + Id.toString()).empty();
                                                $('#Name3').val('');
                                                $('#Name33').val('');
                                                $('#StatusOff' + Id.toString()).prop("checked", false);
                                                $('#StatusOn' + Id.toString()).prop("checked", true);
                                            }
                                            break;
                                        case 4:
                                            {
                                                BannerID = $('#displayimg' + Id.toString()).empty();
                                                $('#Name4').val('');
                                                $('#Name44').val('');
                                                $('#StatusOff' + Id.toString()).prop("checked", false);
                                                $('#StatusOn' + Id.toString()).prop("checked", true);
                                            }
                                            break;
                                        case 5:
                                            {
                                                BannerID = $('#displayimg' + Id.toString()).empty();
                                                $('#Name5').val('');
                                                $('#Name55').val('');
                                                $('#StatusOff' + Id.toString()).prop("checked", false);
                                                $('#StatusOn' + Id.toString()).prop("checked", true);
                                            }
                                            break;
                                        default:
                                            {
                                                alert("không tìm thấy thông tin hình ảnh ");
                                            }
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
        }
    }

    /* up load file hình */
    ChangeFile = function (indexChange, data) {
        var n = new Date();
        var selectedFiles = data[0].files;
        if (selectedFiles.length <= 0) return false;

        if (Validater.endFile(selectedFiles[0].name) != 1) {
            XFunction.RenderMessage('error', 'không đúng định dạng hình ảnh ');
            $('#file' + indexChange.toString() + '').val('');
            return false;
        }
        if (Validater.CheckUpLoadFileIMG(selectedFiles) == false) {
            $('#file' + indexChange.toString() + '').val(''); return false;
        };
        

        if (indexChange) {
            $("#displayimg" + indexChange).empty();
        }
        $.each(selectedFiles, function (index, item) {
            selectedFiles[index].nameNew = n.toString() + '_' + selectedFiles[index].name;
            var tmppath = URL.createObjectURL(selectedFiles[index]);
            var Html = "";
            Html = '<div class="ULH"><a href="' + tmppath + '" target="_blank" id="IMG' + indexChange + '" class="renderlink" data-id="' + indexChange + '" data-value="' + indexChange + '" ><img class="IMG' + index + '" src="' + tmppath + '"height="42" width="42"></a></div>';
            $('#displayimg' + indexChange).append(Html);
        });
    }
    CreareorUpdateRow = function (indexchange) {
        debugger
        var fdata = new FormData();
        switch (indexchange) {
            case 1:
                {
                    var IsDelete = $("[name=IsDelete1]:checked").val() == 0 ? false : true;
                    //if (!$('#Name1').val()) { XFunction.RenderMessage('error', "Nhập tiêu đề 1 "); return false; }
                    //if (!$('#Name11').val()) { XFunction.RenderMessage('error', "Nhập tiêu đề 2 "); return false; }
                    var files = $('#file1')[0].files;

                    if ($('#CreateRow' + indexchange.toString()).val() != "0") {
                        if (files.length <= 0) { XFunction.RenderMessage('error', "Chọn file hình ! "); return false; }
                    }

                    fdata.append("File", files[0]);
                    fdata.append("TitleUp", $('#Name1').val());
                    fdata.append("TitleDown", $('#Name11').val());
                    fdata.append("IsDelete", IsDelete);
                }
                break;
            case 2:
                {
                    var IsDelete = $("[name=IsDelete2]:checked").val() == 0 ? false : true;
                    key = 2;
                     //if (!$('#Name2').val()) { XFunction.RenderMessage('error', "Nhập tiêu đề 1 "); return false; }
                     //if (!$('#Name22').val()) { XFunction.RenderMessage('error', "Nhập tiêu đề 2 "); return false; }
                    var files = $('#file2')[0].files;
                    if ($('#CreateRow' + indexchange).val() != 0) {
                        if (files.length <= 0) { XFunction.RenderMessage('error', "Chọn file hình ! "); return false; }
                    }
                    fdata.append("File", files[0]);
                    fdata.append("TitleUp", $('#Name2').val());
                    fdata.append("TitleDown", $('#Name22').val());
                    fdata.append("IsDelete", IsDelete);
                }
                break;
            case 3:
                {
                    var IsDelete = $("[name=IsDelete3]:checked").val() == 0 ? false : true;
                    key = 3;
                    //if (!$('#Name3').val()) { XFunction.RenderMessage('error', "Nhập tiêu đề 1 "); return false; }
                    //if (!$('#Name33').val()) { XFunction.RenderMessage('error', "Nhập tiêu đề 2 "); return false; }
                    var files = $('#file3')[0].files;
                    fdata.append("File", files[0]);
                    if ($('#CreateRow' + indexchange).val() != 0) // trường hợp sửa thì có hình thì úp ko có thì dữ nguyên hình củ 
                    {
                        if (files.length <= 0) { XFunction.RenderMessage('error', "Chọn file hình ! "); return false; }
                    }
                    fdata.append("TitleUp", $('#Name3').val());
                    fdata.append("TitleDown", $('#Name33').val());
                    fdata.append("IsDelete", IsDelete);
                }
                break;
            case 4:
                {
                    var IsDelete = $("[name=IsDelete4]:checked").val() == 0 ? false : true;
                    key = 4;
                    //if (!$('#Name4').val()) { XFunction.RenderMessage('error', "Nhập tiêu đề 1 "); return false; }
                    //if (!$('#Name44').val()) { XFunction.RenderMessage('error', "Nhập tiêu đề 2 "); return false; }
                    var files = $('#file4')[0].files;
                    fdata.append("File", files[0]);
                    if ($('#CreateRow' + indexchange).val() != 0) {
                        if (files.length <= 0) { XFunction.RenderMessage('error', "Chọn file hình ! "); return false; }
                    }
                    fdata.append("TitleUp", $('#Name4').val());
                    fdata.append("TitleDown", $('#Name44').val());
                    fdata.append("IsDelete", IsDelete);
                }
                break;
            case 5:
                {

                    var IsDelete = $("[name=IsDelete5]:checked").val() == 0 ? false : true;
                    key = 5;
                    //if (!$('#Name5').val()) { XFunction.RenderMessage('error', "Nhập tiêu đề 1 "); return false; }
                    //if (!$('#Name55').val()) { XFunction.RenderMessage('error', "Nhập tiêu đề 2 "); return false; }
                    var files = $('#file5')[0].files;
                    if ($('#CreateRow' + indexchange).val() != 0) {
                        if (files.length <= 0) { XFunction.RenderMessage('error', "Chọn file hình ! "); return false; }
                    }
                    fdata.append("File", files[0]);
                    fdata.append("TitleUp", $('#Name5').val());
                    fdata.append("TitleDown", $('#Name55').val());
                    fdata.append("IsDelete", IsDelete);
                }
                break;
            default:
                {
                    alert("không tìm thấy vị trí hình !");
                }
        }
        
        if ($('#CreateRow' + indexchange).val() == 0) {
            var BannerID = $('#IMG' + indexchange).data("id");
            fdata.append("BannerId", BannerID);
            Function.UpdateRow(fdata, indexchange);
        }
        else
            Function.CreateRow(fdata, indexchange);

    }
    /* Delete*/
    DeleteRow = function (indexchange) {
        var BannerID = -1;
        switch (indexchange) {
            case 1:
                {
                    BannerID = $('#IMG' + indexchange.toString()).data("id");
                }
                break;
            case 2:
                {
                    BannerID = $('#IMG' + indexchange.toString()).data("id");
                }
                break;
            case 3:
                {
                    BannerID = $('#IMG' + indexchange.toString()).data("id");
                }
                break;
            case 4:
                {
                    BannerID = $('#IMG' + indexchange.toString()).data("id");
                }
                break;
            case 5:
                {
                    BannerID = $('#IMG' + indexchange.toString()).data("id");
                }
                break;
            default:
                {
                    alert("Không tìm thấy vị trí xóa ! ");
                }
        }
        if (!BannerID) {
            XFunction.RenderMessage('error', "Hình đã xóa ! "); return false;
        }
        Function.DeleteRow(BannerID);
    }
});