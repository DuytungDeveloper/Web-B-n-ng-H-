
$(document).ready(function () {    
    DeletePost = function (model, event) {
        event.preventDefault();
        if (!model) return false;

        $.confirm({
            title: 'Xác nhận !',
            content: 'Bạn xóa bài viết ?',
            type: 'red',
            typeAnimated: true,
            buttons: {
                tryAgain: {
                    text: 'OK',
                    btnClass: 'btn-red',
                    action: function () {
                        $.ajax({
                            url: "/admin/post/DeletePost",
                            type: 'POST',
                            data: { PostId: model},
                            async: false,
                            dataType: "json",
                            success: function (res) {
                                if (res.Success) {
                                    XFunction.RenderMessage('success', res.Message);
                                    $('#Status_' + model + '').text(res.Data)
                                }
                                else XFunction.RenderMessage('error', res.Message);

                            },
                            error: function () {
                                XFunction.RenderMessage('error', "có lỗi phía server ! ");
                            }
                        })

                    }
                }, close: function () {
                }
            }
        });      
    }
});