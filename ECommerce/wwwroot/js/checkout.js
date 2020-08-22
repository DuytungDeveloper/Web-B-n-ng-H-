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

    var wizard = $('#smartwizard').smartWizard({
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
        if (stepIndex == 1) {
            var allData = $('#deliveryForm').serializeArray();
            var isValid = true;
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
                    'Vui lòng điền đầy đủ thông tin!',
                    'Chúng tôi cần đầy đủ thông tin để có thể phục vụ quý khách một cách tốt nhất!',
                    'warning'
                );
            }
            return isValid;
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