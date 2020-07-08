

$(document).ready(function () {
    $("#btnUpdpate-Common").click(function () {
        var data = new FormData();
        data.append("CommonId", $("#commonid").val());
        data.append("CompanyName", $("#companyname").val());
        data.append("Phone", $("#phone").val());
        data.append("Youtube", $("#youtube").val());
        data.append("FaceBook", $("#faceBook").val());
        data.append("GoogleMap", $("#googlemap").val());
        data.append("Email", $("#email").val());
        data.append("Address", $("#address").val());
        data.append("SloganLeft", $("#sloganleft").val());
        data.append("SloganCenter", $("#slogancenter").val());
        data.append("SloganRight", $("#sloganright").val());

        $.ajax({
            url: "/admin/common/createupdate",
            type: 'POST',
            dataType: 'json',
            data: data,
            contentType: false,
            processData: false,
            async: true,
            success: function (res) {
                console.log(res);
                if (res.Success) {
                    if ($("#commonid").val() === 0 || $("#commonid").val() === "0") {
                        window.location.reload();
                    }
                    else {
                        XFunction.RenderMessage('success', res.Message);
                    }
                }
                else {
                    XFunction.RenderMessage('error', res.Message);
                }
            }
        });
    });
});