let productIdInput = null;
let productNameInput = null;
let productTitleSEOInput = null;
let productDescriptionShortSEOInput = null;
/** Cái này xài tagsInput */
let productKeyWordSEOInput = null;
let productCategoryInput = null;
let productPriceInput = null;
let productPriceDiscountInput = null;
let productDescriptionShortInput = null;
let productDescriptionFullInput = null;
/**Cái này xài summernote */
let editorProductFullDetail = null;
let formProductDetail = null;

let productBrandInput = null;
let productMachineIdInput = null;
let productBandIdInput = null;
let productStrapIdInput = null;
let productColorClockFaceIdInput = null;
let productMadeInIdInput = null;
let productStyleIdInput = null;
let productWaterproofIdInput = null;
let productCategoryIdInput = null;
let productQtyInWareHouseInput = null;



//#region initValue
let urlGetAllBrandProduct = '/api/BrandProduct/all';
let allBrandProductData = null;

let urlGetAllMachine = '/api/Machine/all';
let allMachineData = null;

let urlGetAllBand = '/api/Band/all';
let allBandData = null;

let urlGetAllStrap = '/api/Strap/all';
let allStrapData = null;

let urlGetAllColorClockFace = '/api/ColorClockFace/all';
let allColorClockFaceData = null;


let urlGetAllMadeIn = '/api/MadeIn/all';
let allMadeInData = null;

let urlGetAllStyle = '/api/Style/all';
let allStyleData = null;

let urlGetAllWaterproof = '/api/Waterproof/all';
let allWaterproofData = null;

let urlGetAllCategory = '/api/Category/all';
let allCategoryData = null;

//#endregion

//let table_orderDetail = $("#table-san-pham").DataTable();
let table_orderDetail = $("#table-san-pham").DataTable({
    "processing": true,
    serverSide: true,
    responsive: true,
    ajax: {
        url: '/api/product/search',
        "dataSrc": "data",
        "type": "POST"
    },
    "columns": [
        { "data": "id", "targets": 0 },
        {
            "data": "anh", "targets": 1,
            render: function (data, type, row) {
                return `<img src="${data}" class="img-responsive"  style="width: 100px;" />`;
            },
            "orderable": false
        },
        { "data": "name", "targets": 2 },
        {
            "data": "price", "targets": 3,
            render: function (data, type, row) {
                return data != null ? intToPrice(data) : "Không có";
            }
        },
        {
            "data": "priceDiscount", "targets": 4,
            render: function (data, type, row) {
                return data != null ? intToPrice(data) : "Không có";
            }
        },
        { "data": "point", "targets": 5, },
        { "data": "status", "targets": 6 },
        {
            "data": "id", "targets": 7, "orderable": false,
            render: function (data, type, row) {
                return `<button class="btn btn-info" onclick="showDetailProductData(event,${data})" data-loading-text="Đang tải ...">Xem chi tiết</button>`;
            },
        },
    ]
});

/**
 * Hiển thị Popup thông tin sản phẩm
 * @param {any} productId
 */
function showDetailProductData(e, productId) {
    var $btn = $(e.target).button('loading');
    // business logic...
    //setTimeout(() => {
    //    $.get(`/api/Product/${productId}`).done((data) => {
    //        console.log(data);
    //        let productData = JSON.parse(data.data);
    //        console.log(productData);
    //        $('#modal_large').modal('toggle')
    //        $btn.button('reset')
    //    })
    //}, 2000)
    $.get(`/api/Product/${productId}`).done((data) => {
        console.log(data);
        let productData = JSON.parse(data.data);
        $('#modal_large').modal('toggle')
        $btn.button('reset');
        updateDataToProductDetailView(productData);
    })
}

/**
 * Tải lại trang chi tiết sản phẩm
 * @param {any} e Event
 */
function reloadDetailProduct(e) {
    emptyDetailView();
    var $btn = $(e.target).button('loading');
    let productId = $("#maSanPham_detail").html();
    $.get(`/api/Product/${productId}`).done((data) => {
        let productData = JSON.parse(data.data);
        $btn.button('reset');
        updateDataToProductDetailView(productData);

    })
}

/**
 * Update thông tin Product lên view detail
 * @param {any} productData
 */
function updateDataToProductDetailView(productData) {
    emptyDetailView();
    console.log(productData);
    //console.log(JSON.stringify(productData));
    $("#maSanPham_detail").html(productData.Id);
    productIdInput.val(parseInt(productData.Id));
    productNameInput.val(productData.Name);
    productTitleSEOInput.val(productData.TitleSEO);
    productDescriptionShortSEOInput.val(productData.DescriptionShortSEO);
    productKeyWordSEOInput.importTags(productData.KeyWordSEO ?? "");
    productCategoryInput.val(productData.CategoryId).change();
    productPriceInput.val(productData.Price);
    productPriceDiscountInput.val(productData.PriceDiscount);
    productDescriptionShortInput.val(productData.DescriptionShort);
    productDescriptionFullInput.code(productData.DescriptionFull);

}

/**Lấy những thông tin cần thiết cho việc show dữ liệu hoặc update */
function getAllInitialData() {

    //#region BrandProduct
    $.ajax({
        type: "GET",
        url: urlGetAllBrandProduct,
    }).done((data) => {
        allBrandProductData = JSON.parse(data.data);
        allBrandProductData = allBrandProductData.map(x => { return { Id: x.Id, Name: x.Name } });
        console.log(allBrandProductData);
        productBrandInput.find('option').remove().end();
        allBrandProductData.forEach(x => {
            productBrandInput.append($('<option>', {
                value: x.Id,
                text: x.Name
            }));
        })
    });
    //#endregion 

    //#region Machine
    $.ajax({
        type: "GET",
        url: urlGetAllMachine,
    }).done((data) => {
        allMachineData = JSON.parse(data.data);
        allMachineData = allMachineData.map(x => { return { Id: x.Id, Name: x.Name } });
        console.log(allMachineData);
        productMachineIdInput.find('option').remove().end();
        allMachineData.forEach(x => {
            productMachineIdInput.append($('<option>', {
                value: x.Id,
                text: x.Name
            }));
        })
    });
    //#endregion

    //#region Band
    $.ajax({
        type: "GET",
        url: urlGetAllBand,
    }).done((data) => {
        allBandData = JSON.parse(data.data);
        allBandData = allBandData.map(x => { return { Id: x.Id, Name: x.Name } });
        console.log(allBandData);
        productBandIdInput.find('option').remove().end();
        allBandData.forEach(x => {
            productBandIdInput.append($('<option>', {
                value: x.Id,
                text: x.Name
            }));
        })
    });
    //#endregion

    //#region Strap
    $.ajax({
        type: "GET",
        url: urlGetAllStrap,
    }).done((data) => {
        allStrapData = JSON.parse(data.data);
        allStrapData = allStrapData.map(x => { return { Id: x.Id, Name: x.Name } });
        console.log(allStrapData);
        productStrapIdInput.find('option').remove().end();
        allStrapData.forEach(x => {
            productStrapIdInput.append($('<option>', {
                value: x.Id,
                text: x.Name
            }));
        })
    });
    //#endregion

    //#region ColorClockFaceId
    $.ajax({
        type: "GET",
        url: urlGetAllColorClockFace,
    }).done((data) => {
        allColorClockFaceData = JSON.parse(data.data);
        allColorClockFaceData = allColorClockFaceData.map(x => { return { Id: x.Id, Name: x.Name } });
        console.log(allColorClockFaceData);
        productColorClockFaceIdInput.find('option').remove().end();
        allColorClockFaceData.forEach(x => {
            productColorClockFaceIdInput.append($('<option>', {
                value: x.Id,
                text: x.Name
            }));
        })
    });
    //#endregion

    //#region MadeIn
    $.ajax({
        type: "GET",
        url: urlGetAllMadeIn,
    }).done((data) => {
        allMadeInData = JSON.parse(data.data);
        allMadeInData = allMadeInData.map(x => { return { Id: x.Id, Name: x.Name } });
        console.log(allMadeInData);
        productMadeInIdInput.find('option').remove().end();
        allMadeInData.forEach(x => {
            productMadeInIdInput.append($('<option>', {
                value: x.Id,
                text: x.Name
            }));
        })
    });
    //#endregion

    //#region Style
    $.ajax({
        type: "GET",
        url: urlGetAllStyle,
    }).done((data) => {
        allStyleData = JSON.parse(data.data);
        allStyleData = allStyleData.map(x => { return { Id: x.Id, Name: x.Name } });
        console.log(allStyleData);
        productStyleIdInput.find('option').remove().end();
        allStyleData.forEach(x => {
            productStyleIdInput.append($('<option>', {
                value: x.Id,
                text: x.Name
            }));
        })
    });
    //#endregion

    //#region Waterproof
    $.ajax({
        type: "GET",
        url: urlGetAllWaterproof,
    }).done((data) => {
        allWaterproofData = JSON.parse(data.data);
        allWaterproofData = allWaterproofData.map(x => { return { Id: x.Id, Name: x.Name } });
        console.log(allWaterproofData);
        productWaterproofIdInput.find('option').remove().end();
        allWaterproofData.forEach(x => {
            productWaterproofIdInput.append($('<option>', {
                value: x.Id,
                text: x.Name
            }));
        })
    });
    //#endregion

    //#region Category
    $.ajax({
        type: "GET",
        url: urlGetAllCategory,
    }).done((data) => {
        allCategoryData = JSON.parse(data.data);
        allCategoryData = allCategoryData.map(x => { return { Id: x.Id, Name: x.Name } });
        console.log(allCategoryData);
        productCategoryIdInput.find('option').remove().end();
        allCategoryData.forEach(x => {
            productCategoryIdInput.append($('<option>', {
                value: x.Id,
                text: x.Name
            }));
        })
    });
    //#endregion
}

/** Reset lại các trường dữ liệu về rỗng */
function emptyDetailView() {
    formProductDetail.trigger("reset");
    productKeyWordSEOInput.importTags('');
    productDescriptionFullInput.code('');

}

/**Cập nhật thông tin sản phẩm */
function updateDetailProduct() {
    Swal.fire({
        title: 'Bạn có muốn lưu những thay dổi này?',
        text: "Không thể hoàn tác!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        cancelButtonText: 'Hủy',
        confirmButtonText: 'Chắc chắn',
        showClass: {
            popup: 'animate__animated animate__lightSpeedInLeft'
        },
        hideClass: {
            popup: 'animate__animated animate__flipOutX'
        },
    }).then((result) => {
        if (result.isConfirmed) {
            let productDataUpdate = {
                "Id": 1,
                "Name": "Đồng Hồ Bulova Chính Hãng Nữ 96P160 Diamond Mother of Pearl Dial Ladies Watch",
                "Video": null,
                "Url": "dong-ho-bulova-chinh-hang-nu-p-diamond-mother-of-pearl-dial-ladies-watch",
                "Price": 58400565,
                "PriceDiscount": 57400565,
                "DiscountDateFrom": "2020-11-29T11:15:02.5966667",
                "DiscountDateTo": "2020-11-29T13:15:02.5966667",
                "Characteristics": null,
                "DescriptionShort": null,
                "DescriptionFull": "NHỮNG ĐIỀU NÊN TRÁNH KHI SỬ DỤNG ĐỒNG HỒ!.1. Không sử dụng hoặc để đồng hồ ở nơi có nhiều từ trường..2. Luôn rửa đồng hồ bằng nước ấm ngay sau khi bơi biển ( đối với đồng hồ được phép bơi lặn)..3.Tránh để đồng hồ bị va đập mạnh, nên tháo đồng hồ khi chơi thể thao ngoại trừ đồng hồ chuyên dụng dành riêng cho thể thao..4. Luôn kiểm tra tình trạng của núm vặn, vị trí đúng là ở nấc trong cùng. . Trong quá trình sử dụng núm rất đễ bị mắc vào chỉ áo hoặc những tác động khác mà bị kéo ra ngoài..5. Hàng tuần nên chùi rửa đồng hồ với nước ấm với xà-phòng để chải sạch bụi bẩn và muối đọng do mồ hôi tiết ra. Những bụi bẩn và mồ hôi muối chính là tác nhân gây ra nước vào trong đồng hồ..6. Không được sử dụng đồng hồ với hoá chất dễ làm hư hại dây, vỏ đồng hồ cũng như các chi tiết khác..7. Không để đồng hồ ở nơi có nhiệt độ cao quá 60 độ C (tương đương 140 độ F) hoặc những nơi thấp hơn 0 độ C ( tương đương 32 độ F)..8. Không sử dụng các nút bấm khi ở dưới nước đối với những đồng hồ nhiều chức năng..GIẢI ĐÁP NHỮNG CÂU HỎI THƯỜNG GẶP.Tôi mới mua một chiếc đồng hồ, về mới dùng được vài tháng đã chết, qua trung tâm bảo hành kỹ thuật viên bảo do đồng hồ bị hết pin. Vậy xin hỏi tại sao đồng hồ mới mà lại hết pin sớm như vậy? có phải do chất lượng không?.Đối với đồng hồ điện tử pin thường dùng được từ 2 năm rưỡi đến 3 năm. Tuy nhiên, khi sản xuất máy, nhà sản xuất đã lắp pin cho máy làm việc, vì như vậy sẽ tốt hơn cho máy đồng hồ, dầu mỡ và các chi tiết chạy trơn chu hơn. Sau đó, máy mới đựoc lắp ráp với các phần khác của đồng hồ như mặt số, vỏ, dây… rồi qua bộ phận đóng gói, lưu kho, phân phối đi các đại lý bán lẻ….Chính vì vậy, tuổi thọ của pin không thể tính tù thời điểm mua của khách hàng mà phải tính tù khi sản xuất chế tạo. Nếu đồng hồ của bạn hết pin, bạn nên mang qua trung tâm bảo hành để thay pin mới. Với trang thiết bị theo tiêu chuẩn của hãng cùng với kỹ thuật viên tay nghề cao, được đào tạo chuyên nghiệp chắc chắn sẽ làm bạn hài lòng mà không phải lo lắng gì..Tại sao đồng hồ chịu nước lại không nên dùng tắm biển…?.Khi tắm biển, cát và nước muối sẽ chui vào các khe gioăng ở kính, đắy và đặc biệt là núm. Khi nước biển khô đi ,muối và cát biển còn đọng lại trong núm làm cộm gioăng dẫn đến tạo khe hở lớn cho nước vào đồng hồ. Vì vậy, không nên đeo đồng hồ khi tắm biển, nếu có đeo thì phải tráng rửa lại bằng nước ấm với xà-phòng..Trường hợp, trong khi tắm biển mà thấy đồng hồ có hiện tượng nước vào phải kịp thời mang đến nơi sửa chữa gần nhất để tháo và xì khô nước biển. Với tác dụng muôí ăn mòn của nước biển, chỉ cần để sang ngày thứ hai là hỏng toàn bộ máy..✦    Tại sao đồng hồ cơ hay bị chết máy/đứng kim?.Hầu hết đồng hồ cơ hiện nay đều là đồng hồ Automatic phải đeo khoảng 8 tiếng mỗi ngày thì đồng hồ mới chạy (năng lượng sinh ra từ cử động tự nhiên của tay), nếu không nó sẽ bị đứng do hết năng lượng.",
                "Sku": "96P160",
                "BrandProductId": 167,
                "BrandProduct": {
                    "Id": 167,
                    "Name": "Bulova",
                    "Description": null,
                    "Products": [],
                    "CreateDate": "2020-11-29T11:12:51.64",
                    "CreateBy": null,
                    "UpdateDate": null,
                    "UpdateBy": null,
                    "Status": 1
                },
                "OriginNumber": null,
                "MachineId": 1,
                "Machine": null,
                "InternationalWarrantyTime": null,
                "StoreWarrantyTime": null,
                "Diameter": "27mm",
                "ThicknessOfClass": 7,
                "BandId": 13,
                "Band": null,
                "StrapId": 1,
                "Strap": null,
                "ColorClockFaceId": 4,
                "ColorClockFace": null,
                "MadeInId": 1,
                "MadeIn": null,
                "StyleId": 5,
                "Style": null,
                "WaterproofId": 1,
                "Waterproof": null,
                "CategoryId": 2,
                "Category": null,
                "Product_Function": null,
                "OrderItems": null,
                "Product_ProductStatus": [
                    {
                        "ProductId": 1,
                        "ProductStatusId": 3,
                        "ProductStatus": null
                    },
                    {
                        "ProductId": 1,
                        "ProductStatusId": 4,
                        "ProductStatus": null
                    },
                    {
                        "ProductId": 1,
                        "ProductStatusId": 5,
                        "ProductStatus": null
                    },
                    {
                        "ProductId": 1,
                        "ProductStatusId": 6,
                        "ProductStatus": null
                    },
                    {
                        "ProductId": 1,
                        "ProductStatusId": 7,
                        "ProductStatus": null
                    }
                ],
                "Product_Media": [
                    {
                        "ProductId": 1,
                        "MediaId": 167,
                        "Media": {
                            "Id": 167,
                            "Name": "Hình ảnh 353",
                            "Link": "https://gowatch.vn/wp-content/uploads/2019/11/dong-ho-gowatch-nam-Adee-Kaye-gold-4-500x500.jpg",
                            "Path": "https://gowatch.vn/wp-content/uploads/2019/11/dong-ho-gowatch-nam-Adee-Kaye-gold-4-500x500.jpg",
                            "MediaTypeId": 1,
                            "OrderIndex": 0,
                            "MediaType": null,
                            "Product_Media": [],
                            "CreateDate": "2020-11-29T11:15:34.7733333",
                            "CreateBy": null,
                            "UpdateDate": null,
                            "UpdateBy": null,
                            "Status": 1
                        }
                    },
                    {
                        "ProductId": 1,
                        "MediaId": 7403,
                        "Media": {
                            "Id": 7403,
                            "Name": "Hình ảnh 15273",
                            "Link": "https://gowatch.vn/wp-content/uploads/2020/02/dong-ho-gowatch-nu-Frederique-Constant-FC-200MPWD3V3B-4-500x500.jpg",
                            "Path": "https://gowatch.vn/wp-content/uploads/2020/02/dong-ho-gowatch-nu-Frederique-Constant-FC-200MPWD3V3B-4-500x500.jpg",
                            "MediaTypeId": 1,
                            "OrderIndex": 0,
                            "MediaType": null,
                            "Product_Media": [],
                            "CreateDate": "2020-11-29T11:15:38.6166667",
                            "CreateBy": null,
                            "UpdateDate": null,
                            "UpdateBy": null,
                            "Status": 1
                        }
                    }
                ],
                "Reviews": [],
                "Point": 0,
                "Qty": 0,
                "ViewsCount": 0,
                "QtyInWareHouse": 0,
                "TitleSEO": null,
                "KeyWordSEO": null,
                "DescriptionShortSEO": null,
                "CreateDate": "2020-11-29T11:14:28.21",
                "CreateBy": "Hệ thống",
                "UpdateDate": null,
                "UpdateBy": null,
                "Status": 1
            };

            Swal.fire({
                title: 'Vui lòng đợi trong giây lát!',
                html: 'Hệ thống đang cập nhật!',
                timerProgressBar: true,
                didOpen: () => {
                    Swal.showLoading();
                    console.log("abc");
                    let url = `/api/Product/${productIdInput.val()}`;
                    $.ajax({
                        type: "PUT",
                        url: url,
                        data: { Id: productIdInput.val() },
                        //success: success,
                        //dataType: dataType
                    }).done((data) => {
                        console.log(data);
                    });
                    return response.json()
                },
                showLoaderOnConfirm: true,
                allowOutsideClick: () => !Swal.isLoading()
            }).then((result) => {

            })
        }
    })
}

$(document).ready(function () {
    productIdInput = $("#ProductId_detail");
    productNameInput = $("#productName_detail");
    productTitleSEOInput = $("#productTitleSEO_detail");
    productDescriptionShortSEOInput = $("#productDescriptionShortSEO_detail");
    productKeyWordSEOInput = $("#productKeyWordSEO_detail");
    productCategoryInput = $("#productCategory_detail");
    productPriceInput = $("#productPrice_detail");
    productPriceDiscountInput = $("#productPriceDiscount_detail");
    productDescriptionShortInput = $("#productDescriptionShort_detail");
    productDescriptionFullInput = $("#productDescriptionFull_detail");
    formProductDetail = $("#form-cai-dat-thong-tin-productDetail");
    productBrandInput = $("#productBrand_detail");

    productMachineIdInput = $("#productMachineId_detail");
    productBandIdInput = $("#productBandId_detail");
    productStrapIdInput = $("#productStrapId_detail");
    productColorClockFaceIdInput = $("#productColorClockFaceId_detail");
    productMadeInIdInput = $("#productMadeInId_detail");
    productStyleIdInput = $("#productStyleId_detail");
    productWaterproofIdInput = $("#productWaterproofId_detail");
    productCategoryIdInput = $("#productCategoryId_detail");
    productQtyInWareHouseInput = $("#productQtyInWareHouse_detail");


    editorProductFullDetail = $('#productDescriptionFull_detail').summernote({
        placeholder: 'Nội dung chi tiết sản phẩm',
        //tabsize: 2,
        height: 200
    });
    productKeyWordSEOInput = $('#productKeyWordSEO_detail').tagsInput({
        //'autocomplete_url': url_to_autocomplete_api,
        //'autocomplete': { option: value, option: value },
        //'height': '100px',
        'width': '100%',
        //'interactive': true,
        //'defaultText': 'add a tag',
        //'onAddTag': callback_function,
        //'onRemoveTag': callback_function,
        //'onChange': callback_function,
        //'delimiter': [',', ';'],   // Or a string with a single delimiter. Ex: ';'
        //'removeWithBackspace': true,
        //'minChars': 0,
        //'maxChars': 0, // if not provided there is no limit
        //'placeholderColor': '#666666'
    });
    getAllInitialData();
});