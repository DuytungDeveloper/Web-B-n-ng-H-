$(document).ready(function () {
    CKEDITOR.replace('rtxBlogContent', {
        height: '500px',
        filebrowserUploadUrl: '/admin/post/upload_ckeditor',
        filebrowserBrowseUrl: '/admin/post/filebrowse'
    });

    $.get('/admin/Categorys/GetJtreeCategory', null, function (response) {

        var data = [];
        $.each(response, function (index, item) {
            data.push(
                {
                    id: item.CategoryId,
                    parent: item.ParentID == 0 ? "#" : item.ParentID,
                    text: item.Name
                });
        });

        //truyền đúng thứ tự
        Config.JTree("Categorys-tree", "Categorys", "ParentID", data)
    });

    var functionEvent = {
        Create: function () {
            debugger
            var files = $('#filepost')[0].files;
            if (files.length>0) {
                if (Validater.endFile(files[0].name) != 1) {
                    XFunction.RenderMessage('error', 'không đúng định dạng hình ảnh ');
                    $('#filepost').val('');
                    return false;
                }
                if (Validater.CheckUpLoadFileIMG(files) == false) {
                    $('#filepost').val(''); return false;
                };
            }
            else { XFunction.RenderMessage('error', "Chọn hình đại diện cho bài viết ! "); return false; }

            if (!$('#Name').val()) { XFunction.RenderMessage('error', 'Hãy nhập tên bài viết !'); return false; }
            else if ($('#ParentID').val() === 0 || $('#ParentID').val() === '0') { XFunction.RenderMessage('error', 'Hãy chọn loại bài viết !'); return false; }
            else if (!$('#Description').val()) { XFunction.RenderMessage('error', 'hãy nhập mô tả bài viết !'); return false; }
            else {

                var IsDelete = $("[name=IsDelete]:checked").val() == 0 ? false : true;
                var data = new FormData();
                data.append("File", files[0]);
                data.append("Name", $('#Name').val());
                data.append("CategoryId", $('#ParentID').val());
                data.append("Description", $('#Description').val());
                data.append("IsDelete", IsDelete);
                data.append("Detail", CKEDITOR.instances['rtxBlogContent'].getData());

                $.ajax({
                    url: "/admin/post/CreatePost",
                    type: 'POST',
                    contentType: false,
                    processData: false,
                    async: false,
                    dataType: 'json',
                    data: data,
                }).done(function () {
                    window.location.href = '/admin/bai-viet/quan-ly';
                });
            }
        }
    }
    $('#btn-create-post1').click(function () {
        functionEvent.Create();
    });
    $('#btn-create-post2').click(function () {
        functionEvent.Create();
    });
});