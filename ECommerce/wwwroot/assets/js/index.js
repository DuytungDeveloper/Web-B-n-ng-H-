//$(document).ready(function () {

//    var wizard = $('#smartwizard').smartWizard({
//        // theme : "sw-theme-arrows",
//        justified: true,
//        lang: { // Language variables for button
//            next: 'Tiếp',
//            previous: 'Quay lại'
//        },
//        toolbarSettings: {
//            toolbarPosition: 'both', // none, top, bottom, both
//            toolbarButtonPosition: 'center', // left, right, center
//            // showNextButton: true, // show/hide a Next button
//            // showPreviousButton: true, // show/hide a Previous button
//            // toolbarExtraButtons: [] // Extra buttons to show on toolbar, array of jQuery input/buttons elements
//        },
//    });
//    // wizard.smartWizard("reset");
//    wizard.on("leaveStep", function (e, anchorObject, stepIndex, stepDirection) {
//        if (stepIndex == 1) {
//            var allData = $('#deliveryForm').serializeArray();
//            var isValid = true;
//            allData.forEach(element => {
//                $(`#${element.name}`).parent().removeClass("has-error");
//                switch (element.name) {
//                    case "customerName":
//                        if (element.value == "") {
//                            $(`#${element.name}`).parent().addClass("has-error");
//                            isValid = false;
//                        }
//                        break;
//                    case "customerPhone":
//                        if (element.value == "") {
//                            $(`#${element.name}`).parent().addClass("has-error");
//                            isValid = false;
//                        }
//                        break;
//                    case "deliveryAddress":
//                        if (element.value == "") {
//                            $(`#${element.name}`).parent().addClass("has-error");
//                            isValid = false;
//                        }
//                        break;
//                    default:
//                        break;
//                }
//            });
//            if (!isValid) {
//                Swal.fire(
//                    'Vui lòng điền đầy đủ thông tin!',
//                    'Chúng tôi cần đầy đủ thông tin để có thể phục vụ quý khách một cách tốt nhất!',
//                    'warning'
//                );
//            }
//            return isValid;
//            // Swal.fire({
//            //     title: 'Are you sure?',
//            //     text: "You won't be able to revert this!",
//            //     icon: 'warning',
//            //     showCancelButton: true,
//            //     confirmButtonColor: '#3085d6',
//            //     cancelButtonColor: '#d33',
//            //     confirmButtonText: 'Yes, delete it!'
//            // }).then((result) => {
//            //     if (result.value) {
//            //         Swal.fire(
//            //             'Deleted!',
//            //             'Your file has been deleted.',
//            //             'success'
//            //         )
//            //         return true;
//            //     } else {
//            //         return false;
//            //     }
//            // })
//        }

//    });
//});