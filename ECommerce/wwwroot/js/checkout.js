let editedCart = false;
function updateWardSelect() {
    $.ajax({
        method: "get",
        url: "/api/ward/all",
        success: (data) => {
            if (data.success == true) {
                console.log(data)

                for (var i = 0; i < data.data; i++) {
                    let ward = data.data[i];
                    //console.log(`<option value="${ward.id}">${ward.name}</option>`)
                    //$("#deliveryWard").append(new Option(ward.name, ward.id));
                    //$("#deliveryWard").append(`<option value="${ward.id}">${ward.name}</option>`);

                    var o = new Option(ward.name, ward.id);
                    /// jquerify the DOM object 'o' so we can use the html method
                    $(o).html(ward.name);
                    $("#deliveryWard").append(o);
                }
            }
        },
        error: (e) => {
            console.log(e)
        }
    })
}
$(document).ready(function () {

    let wizard = $('#smartwizard').smartWizard({
        // theme : "sw-theme-arrows",
        justified: true,
        lang: { // Language variables for button
            next: 'Tiếp',
            previous: 'Quay lại'
        },
        toolbarSettings: {
            toolbarPosition: 'both', // none, top, bottom, both
            toolbarButtonPosition: 'center', // left, right, center
            // showNextButton: true, // show/hide a Next button
            // showPreviousButton: true, // show/hide a Previous button
            // toolbarExtraButtons: [] // Extra buttons to show on toolbar, array of jQuery input/buttons elements
        },
    });
    // wizard.smartWizard("reset");
    wizard.on("leaveStep", function (e, anchorObject, stepIndex, stepDirection) {
        console.log(`stepIndex : ${stepIndex}, stepDirection : ${stepDirection}`)
    let listSanPham = getCart();
        if (editedCart) {
            location.reload();
        }
        if (stepDirection == "backward") {
            console.log('1')
            return true;
        } else {
            //if (parseInt(stepIndex) == 1 && stepDirection != "backward" && listSanPham.length > 0) return false;
            console.log(parseInt(stepIndex) == 1 && stepDirection != "backward");
            if (parseInt(stepIndex) == 1 && stepDirection != "backward") {
            console.log('2')
                let allData = $('#deliveryForm').serializeArray();
                let isValid = true;
                allData.forEach(element => {
                    $(`#${element.name}`).parent().removeClass("has-error");
                    switch (element.name) {
                        case "customerName":
                            if (element.value == "") {
                                $(`#${element.name}`).parent().addClass("has-error");
                                isValid = false;
                            }
                            break;
                        case "customerPhone":
                            if (element.value == "") {
                                $(`#${element.name}`).parent().addClass("has-error");
                                isValid = false;
                            }
                            break;
                        case "deliveryAddress":
                            if (element.value == "") {
                                $(`#${element.name}`).parent().addClass("has-error");
                                isValid = false;
                            }
                            break;
                        default:
                            break;
                    }
                });
                if (!isValid) {
                    Swal.fire(
                        translateFunction('Vui lòng điền đầy đủ thông tin!'),
                        translateFunction('Chúng tôi cần đầy đủ thông tin để có thể phục vụ quý khách một cách tốt nhất!'),
                        'warning'
                    );
                }
                return isValid ? (listSanPham.length > 0 ? true : false) : false;
                // Swal.fire({
                //     title: 'Are you sure?',
                //     text: "You won't be able to revert this!",
                //     icon: 'warning',
                //     showCancelButton: true,
                //     confirmButtonColor: '#3085d6',
                //     cancelButtonColor: '#d33',
                //     confirmButtonText: 'Yes, delete it!'
                // }).then((result) => {
                //     if (result.value) {
                //         Swal.fire(
                //             'Deleted!',
                //             'Your file has been deleted.',
                //             'success'
                //         )
                //         return true;
                //     } else {
                //         return false;
                //     }
                // })
            }
            if (stepIndex == 2) {
                var allData = $('#deliveryForm').serializeArray();
                let orderData = {};
                var isValid = true;
                allData.forEach(element => {
                    $(`#${element.name}`).parent().removeClass("has-error");
                    switch (element.name) {
                        case "customerName":
                            if (element.value == "") {
                                $(`#${element.name}`).parent().addClass("has-error");
                                isValid = false;
                            } else {
                                orderData.CustomerName = element.value;
                            }
                            break;
                        case "customerPhone":
                            if (element.value == "") {
                                $(`#${element.name}`).parent().addClass("has-error");
                                isValid = false;
                            } else {
                                orderData.Phone = element.value;
                            }
                            break;
                        case "deliveryAddress":
                            if (element.value == "") {
                                $(`#${element.name}`).parent().addClass("has-error");
                                isValid = false;
                            } else {
                                orderData.Address = {
                                    Street: element.value,
                                    WardId: $("#deliveryWard").val(),
                                    DistrictId: $("#deliveryDistrict").val(),
                                    CityId: $("#deliveryCity").val(),
                                };
                            }
                            break;
                        case "Note":
                            if (element.value != "") {
                                orderData.Note = element.value;
                            }
                            break;
                        default:
                            break;
                    }
                });
                if (!isValid) {
                    Swal.fire(
                        translateFunction('Vui lòng điền đầy đủ thông tin người nhận hàng!'),
                        translateFunction('Chúng tôi cần đầy đủ thông tin để có thể phục vụ quý khách một cách tốt nhất!'),
                        'warning'
                    );
                }
                else {
                    let quanHe = $("#customerPosition").val();
                    orderData.ReceiverInfo = `Tên người nhận hàng ${orderData.CustomerName} là ${quanHe} ở địa chỉ ${orderData.Address.Street} ()`;
                    Swal.fire({
                        icon: 'success',
                        title: translateFunction('Đang lên đơn hàng!'),
                        html: translateFunction('Vui lòng đợi trong giây lát, tiến trình có thể mất vài giây'),
                        showCancelButton: false,
                        showConfirmButton: false,
                        allowOutsideClick: false,
                        timerProgressBar: true,
                        onBeforeOpen: () => {
                            Swal.showLoading()
                        }
                    })
                    console.log(orderData);
                    $.ajax({
                        url: '/' + getLang() + '/don-hang/createOrder',
                        type: 'POST',
                        data: orderData,
                        success: function (result) {
                            // Do something with the result
                            console.log(result);
                            if (result.success) {
                                Swal.fire({
                                    title: translateFunction('Lên đơn hàng thành công'),
                                    html: translateFunction('Chúng tôi sẽ sớm liên lạc với quý khách. Cám ơn đã tin dùng sản phẩm của chúng tôi!'),
                                    icon: 'success',
                                    onClose: () => {
                                        setCart([]);
                                        window.location.href = "/";
                                    }
                                })
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: result.message,
                                    html: `${result.errorMessage}`,
                                })
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            Swal.fire({
                                icon: 'error',
                                title: `${err.name}`,
                                html: `${err.message} <br> ${err.body ? err.body : ''}`,
                            })
                        }
                    });
                }
                return isValid;
            }
        }
    });
    $.ajax({
        method: "get",
        url: "/api/city/all",
        success: (result) => {
            if (result.success == true) {
                for (var i = 0; i < result.data.length; i++) {
                    let element = result.data[i];
                    //console.log(`<option value="${ward.id}">${ward.name}</option>`)
                    //$("#deliveryWard").append(new Option(ward.name, ward.id));
                    //$("#deliveryWard").append(`<option value="${ward.id}">${ward.name}</option>`);

                    var o = new Option(element.name, element.id);
                    /// jquerify the DOM object 'o' so we can use the html method
                    $(o).html(element.name);
                    $("#deliveryCity").append(o);
                }
                $("#deliveryCity").val(1).trigger('change');
            }
        },
        error: (e) => {
            console.log(e)
        }
    })
});
function deliveryCityChange(e) {
    let id = $("#deliveryCity").val();
    $.ajax({
        method: "get",
        url: "/api/city/district",
        data: { id: id },
        success: (result) => {
            if (result.success == true) {
                let allOption = [];
                for (var i = 0; i < result.data.length; i++) {
                    let element = result.data[i];
                    //console.log(`<option value="${ward.id}">${ward.name}</option>`)
                    //$("#deliveryWard").append(new Option(ward.name, ward.id));
                    //$("#deliveryWard").append(`<option value="${ward.id}">${ward.name}</option>`);

                    var o = new Option(element.name, element.id);
                    /// jquerify the DOM object 'o' so we can use the html method
                    $(o).html(element.name);
                    allOption.push(o);
                }
                if (allOption.length == 0) {
                    $("#deliveryWard").empty()
                }
                $("#deliveryDistrict").empty().append(allOption);
                $("#deliveryDistrict").val($("#deliveryDistrict option:first").val()).trigger('change');
            }
        },
        error: (e) => {
            console.log(e)
        }
    })
}
function deliveryDistrictChange(e) {
    let id = $("#deliveryDistrict").val();
    $.ajax({
        method: "get",
        url: "/api/district/ward",
        data: { id: id },
        success: (result) => {
            if (result.success == true) {
                let allOption = [];
                for (var i = 0; i < result.data.length; i++) {
                    let element = result.data[i];
                    //console.log(`<option value="${ward.id}">${ward.name}</option>`)
                    //$("#deliveryWard").append(new Option(ward.name, ward.id));
                    //$("#deliveryWard").append(`<option value="${ward.id}">${ward.name}</option>`);

                    var o = new Option(element.name, element.id);
                    /// jquerify the DOM object 'o' so we can use the html method
                    $(o).html(element.name);
                    allOption.push(o);
                }
                $("#deliveryWard").empty().append(allOption);
                $("#deliveryWard").val($("#deliveryWard option:first").val()).trigger('change');
            }
        },
        error: (e) => {
            console.log(e)
        }
    })
}


function tangSoLuongSanPham(productId,giaTien, tang) {
    let listSanPham = getCart();
    for (var i = 0; i < listSanPham.length; i++) {
        if (listSanPham[i].id == productId) {
            listSanPham[i].qty = tang ? listSanPham[i].qty + 1 : listSanPham[i].qty - 1;
            if (listSanPham[i].qty <= 0) {
                //$("#product-cart-" + productId).remove();
                listSanPham[i].qty = 1;
            }
            $("#product-qty-" + productId).val(listSanPham[i].qty);
            $("#price-total-" + productId).html(intToPrice(listSanPham[i].qty * parseInt(giaTien)));
            //console.log("#price-total-" + productId);
            //console.log((giaTien));
            //console.log(parseInt(giaTien));
        }
    }
    listSanPham = listSanPham.filter(x => x.qty > 0);
    editedCart = true;
    setCart(listSanPham);
    refreshCart();
}