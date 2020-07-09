$(document).ready(function () {
    var ImgGoc = "";
    CKEDITOR.replace('rtxBlogContent', {
        height: '500px',
        filebrowserUploadUrl: '/admin/post/upload_ckeditor',
        filebrowserBrowseUrl: '/admin/post/filebrowse'
    });
    /* Những hàm check dữ liều và hàm thường xuyên dùng chung viết trong đây */
    var FunctionCheck = {
        checkFileUploads: function (f) {
            $.each(f.files, function (index, item) {
                debugger;
                if (f.files[index].size > 10242880) {
                    var size = f.files[0].size;
                    $(f).val('');
                    alert('Chỉ cho úp load file hình có dung lượng <10MB! (' + size + ')');
                    return false;
                }
                var str = f.files[index].name.replace('.', '');
                if (/^[\w ]*$/.test(str) == false) {
                    alert('Cảnh báo : Tên file phải không dấu, không khoảng trắng và không có kí tự đặc biệt!');
                    $(f).val('');
                    return false;
                }
                else {
                    var inValid = /\s/;
                    if (inValid.test(str)) {
                        alert('Cảnh báo : Tên file không để khoảng trắng');
                        $(f).val('');
                        return false;
                    }
                }
            });
        },
        endFile: function (name) {
            var extension = name.split('.').pop().toLowerCase();
            if ($.inArray(extension, ['jpg', 'png', 'gif', 'jpeg']) != -1) {        //file ảnh
                return 1;
            }
            else if ($.inArray(extension, ['xls', 'xlsx']) != -1) {                         //excel
                return 2;
            }
            else if ($.inArray(extension, ['rar', 'zip']) != -1) {                           // file nén
                return 3;
            }
            else if ($.inArray(extension, ['doc', 'docx', 'txt']) != -1) {           // file word. text
                return 4;
            }
            else if ($.inArray(extension, ['ppsx', 'ppsx']) != -1) {         // file powerpoint
                return 5;
            }
            else if ($.inArray(extension, ['pdf']) != -1) {                        //file pdf
                return 6;
            }
            else if ($.inArray(extension, ['bmp', 'csv']) != -1) {                        //file khác
                return 7;
            }
            else {
                return 0;
            }
        },
    }

    /* up load file hình */
    ChangeFile = function (data) {
        var n = new Date();
        debugger;
        var selectedFiles = data[0].files;
        if (FunctionCheck.checkFileUploads(data) == false) {
            XFunction.RenderMessage('error', 'không đúng định dạng hình ảnh '); return false;
        }
        $("#displayimg").empty();
        $.each(selectedFiles, function (index, item) {
            selectedFiles[index].nameNew = n.toString() + '_' + selectedFiles[index].name;
            var tmppath = URL.createObjectURL(selectedFiles[index]);
            if (FunctionCheck.endFile(selectedFiles[index].nameNew) == 1) {
                var Html = "";
                Html = '<div class="Img-Post"><a href="' + tmppath + '" target="_blank" id="IMG' + 1 + '" class="renderlink" data-id="' + 1 + '" data-value="' + 1 + '" ><img class="IMG' + index + '" src="' + tmppath + '"height="110" width="110"></a> <button type="button" onclick="RefImg()" ><i class="fa fa-refresh fa-hover-show fa-fw"></i></button></div>';
                $('#displayimg').append(Html);
            }


        });
    }
    RefImg = function () {
        $("#displayimg").empty();
        var Html = '<div class="Img-Post"><a href="' + ImgGoc + '" target="_blank" id="IMG' + 1 + '" class="renderlink" data-id="' + 1 + '" data-value="' + 1 + '" ><img class="IMG' + 1 + '" src="' + ImgGoc + '"height="42" width="42"></a> <button type="button" onclick="RefImg()" ><i class="fa fa-refresh fa-hover-show fa-fw"></i></button></div>';
        $('#displayimg').append(Html);
    }
    /*Load dữ liệu thì viết hết trong đây */
    var LoadFunction = {
        Categorys: function (id) {

            $.get('/admin/Categorys/GetJtreeCategory', null, function (response) {
                var data = [];
                var newdata = {};

                $.each(response, function (index, item) {
                    if (item.CategoryId == id) {
                        newdata = {
                            id: item.CategoryId,
                            parent: item.ParentID == 0 ? "#" : item.ParentID,
                            text: item.Name
                        };
                    }
                    data.push(
                        {
                            id: item.CategoryId,
                            parent: item.ParentID == 0 ? "#" : item.ParentID,
                            text: item.Name
                        });
                  
                });
                //truyền đúng thứ tự
                Config.JTree("Categorys-tree", "Categorys", "ParentID", data);
                Config.SelectedWhenEventClick("Categorys-tree", "Categorys", "ParentID", "Categorys-tree-T", newdata);

                
            });
        },
        GetPostbById: function () {
            $.post('/admin/post/GetPostbById', { id: PosId}, function (response) {
                if (response) {
                    LoadFunction.Categorys(response.CategoryId);
                    ImgGoc = response.ImgUrl;
                    $('#Description').val(response.Description)
                    $('#Name').val(response.Name);
                    Html = '<div class="Img-Post"><a href="' + response.ImgUrl + '" target="_blank" id="IMG' + 1 + '" class="renderlink" data-id="' + 1 + '" data-value="' + 1 + '" ><img class="IMG' + 1 + '" src="' + response.ImgUrl + '"height="42" width="42"></a> <button type="button" onclick="RefImg()" ><i class="fa fa-refresh fa-hover-show fa-fw"></i></button></div>';
                    $('#displayimg').append(Html);
                    
                    if (response.IsDelete == false) {
                        $("#StatusOff").prop("checked", false)
                        $("#StatusOn").prop("checked", true)
                    }
                    else {
                        $("#StatusOn").prop("checked", false)
                        $("#StatusOff").prop("checked", true)
                    };
                    $('#rtxBlogContent').val(response.Detail);
                }
            });
        }
    }
   
    LoadFunction.GetPostbById();
    /*Những gì update,delete, inset thì viết trong đây */
    var Function = {
        Update: function () {

        }
    }

    
    $('#btn-edit-post').click(function () {
        var files = $('#filepost')[0].files;
        if (!$('#Name').val()) { XFunction.RenderMessage('error', 'Hãy nhập tên bài viết !'); return false; }
        else if ($('#ParentID').val() === 0 || $('#ParentID').val() === '0') { XFunction.RenderMessage('error', 'Hãy chọn loại bài viết !'); return false; }
        else if (!$('#Description').val()) { XFunction.RenderMessage('error', 'hãy nhập mô tả bài viết !'); return false; }
        //else if (files.length <= 0) { XFunction.RenderMessage('error', "Chọn hình đại diện cho bài viết ! "); return false; }
        else {
            var data = new FormData();
            data.append("File", files[0]);
            data.append("Name", $('#Name').val());
            data.append("CategoryId", $('#ParentID').val());
            data.append("Description", $('#Description').val());
            data.append("IsDelete", $("[name=IsDelete]:checked").val() == 0 ? false : true);
            data.append("Detail", CKEDITOR.instances['rtxBlogContent'].getData());
            data.append("PostId", PosId);

            $.ajax({
                url: "/admin/post/UpdatePost",
                type: 'POST',
                contentType: false,
                processData: false,
                async: false,
                dataType: 'json',
                data: data,
                success: function (res) {
                    if (res == true)
                        window.location = '/admin/bai-viet/quan-ly';
                    else
                        XFunction.RenderMessage('error', "success false : có lỗi phía server ! ");
                },error: function () {

                    XFunction.RenderMessage('error', "có lỗi phía server ! ");
                }
            })
        }
    });
});