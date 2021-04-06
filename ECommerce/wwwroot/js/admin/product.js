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

let productURLInput = null;
let productSKUInput = null;
let productOriginNumberInput = null;
let productInternationalWarrantyTimeInput = null;
let productStoreWarrantyTimeInput = null;
let productDiameterInput = null;
let productThicknessOfClassInput = null;



let productBrandInput = null;
let productMachineIdInput = null;
let productBandIdInput = null;
let productStrapIdInput = null;
let productColorClockFaceIdInput = null;
let productMadeInIdInput = null;
let productStyleIdInput = null;
let productWaterproofIdInput = null;
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
    $.get(`/api/Product/${productId}`).done((data) => {
        console.log("Product Lấy về : ", JSON.parse(data.data));
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
    //console.log(productData);
    //console.log(JSON.stringify(productData));
    $("#maSanPham_detail").html(productData.Id);
    productIdInput.val(parseInt(productData.Id));
    productNameInput.val(productData.Name);
    productTitleSEOInput.val(productData.TitleSEO);
    productDescriptionShortSEOInput.val(productData.DescriptionShortSEO);
    productKeyWordSEOInput.importTags(productData.KeyWordSEO ?? "");

    productURLInput.val(productData.Url);
    productSKUInput.val(productData.Sku);
    productOriginNumberInput.val(productData.OriginNumber);
    productInternationalWarrantyTimeInput.val(productData.InternationalWarrantyTime);
    productStoreWarrantyTimeInput.val(productData.StoreWarrantyTime);
    productDiameterInput.val(productData.Diameter);
    productThicknessOfClassInput.val(productData.ThicknessOfClass);





    productBrandInput.val(productData.BrandProductId).change();
    productMachineIdInput.val(productData.MachineId).change();
    productBandIdInput.val(productData.BandId).change();
    productStrapIdInput.val(productData.StrapId).change();
    productColorClockFaceIdInput.val(productData.ColorClockFaceId).change();
    productMadeInIdInput.val(productData.MadeInId).change();
    productStyleIdInput.val(productData.StyleId).change();
    productWaterproofIdInput.val(productData.WaterproofId).change();
    productQtyInWareHouseInput.val(productData.QtyInWareHouse).change();
    productCategoryInput.val(productData.CategoryId).change();







    productPriceInput.val(productData.Price);
    productPriceDiscountInput.val(productData.PriceDiscount);
    productDescriptionShortInput.val(productData.DescriptionShort);
    editorProductFullDetail.code(productData.DescriptionFull);

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
        //console.log(allBrandProductData);
        productBrandInput.find('option').remove().end();
        allBrandProductData.forEach(x => {
            productBrandInput.append($('<option>', {
                value: x.Id,
                text: x.Name
            }));
        });
        productBrandInput = productBrandInput.selectpicker({ liveSearch : true});
    });
    //#endregion 

    //#region Machine
    $.ajax({
        type: "GET",
        url: urlGetAllMachine,
    }).done((data) => {
        allMachineData = JSON.parse(data.data);
        allMachineData = allMachineData.map(x => { return { Id: x.Id, Name: x.Name } });
        //console.log(allMachineData);
        productMachineIdInput.find('option').remove().end();
        allMachineData.forEach(x => {
            productMachineIdInput.append($('<option>', {
                value: x.Id,
                text: x.Name
            }));
        })
        productMachineIdInput = productMachineIdInput.selectpicker({ liveSearch: true });

    });
    //#endregion

    //#region Band
    $.ajax({
        type: "GET",
        url: urlGetAllBand,
    }).done((data) => {
        allBandData = JSON.parse(data.data);
        allBandData = allBandData.map(x => { return { Id: x.Id, Name: x.Name } });
        //console.log(allBandData);
        productBandIdInput.find('option').remove().end();
        allBandData.forEach(x => {
            productBandIdInput.append($('<option>', {
                value: x.Id,
                text: x.Name
            }));
        })
        productBandIdInput = productBandIdInput.selectpicker({ liveSearch: true });

    });
    //#endregion

    //#region Strap
    $.ajax({
        type: "GET",
        url: urlGetAllStrap,
    }).done((data) => {
        allStrapData = JSON.parse(data.data);
        allStrapData = allStrapData.map(x => { return { Id: x.Id, Name: x.Name } });
        //console.log(allStrapData);
        productStrapIdInput.find('option').remove().end();
        allStrapData.forEach(x => {
            productStrapIdInput.append($('<option>', {
                value: x.Id,
                text: x.Name
            }));
        })
        productStrapIdInput = productStrapIdInput.selectpicker({ liveSearch: true });

    });
    //#endregion

    //#region ColorClockFaceId
    $.ajax({
        type: "GET",
        url: urlGetAllColorClockFace,
    }).done((data) => {
        allColorClockFaceData = JSON.parse(data.data);
        allColorClockFaceData = allColorClockFaceData.map(x => { return { Id: x.Id, Name: x.Name } });
        //console.log(allColorClockFaceData);
        productColorClockFaceIdInput.find('option').remove().end();
        allColorClockFaceData.forEach(x => {
            productColorClockFaceIdInput.append($('<option>', {
                value: x.Id,
                text: x.Name
            }));
        })
        productColorClockFaceIdInput = productColorClockFaceIdInput.selectpicker({ liveSearch: true });
    });
    //#endregion

    //#region MadeIn
    $.ajax({
        type: "GET",
        url: urlGetAllMadeIn,
    }).done((data) => {
        allMadeInData = JSON.parse(data.data);
        allMadeInData = allMadeInData.map(x => { return { Id: x.Id, Name: x.Name } });
        //console.log(allMadeInData);
        productMadeInIdInput.find('option').remove().end();
        allMadeInData.forEach(x => {
            productMadeInIdInput.append($('<option>', {
                value: x.Id,
                text: x.Name
            }));
        })
        productMadeInIdInput = productMadeInIdInput.selectpicker({ liveSearch: true });
    });
    //#endregion

    //#region Style
    $.ajax({
        type: "GET",
        url: urlGetAllStyle,
    }).done((data) => {
        allStyleData = JSON.parse(data.data);
        allStyleData = allStyleData.map(x => { return { Id: x.Id, Name: x.Name } });
        //console.log(allStyleData);
        productStyleIdInput.find('option').remove().end();
        allStyleData.forEach(x => {
            productStyleIdInput.append($('<option>', {
                value: x.Id,
                text: x.Name
            }));
        })
        productStyleIdInput = productStyleIdInput.selectpicker({ liveSearch: true });
    });
    //#endregion

    //#region Waterproof
    $.ajax({
        type: "GET",
        url: urlGetAllWaterproof,
    }).done((data) => {
        allWaterproofData = JSON.parse(data.data);
        allWaterproofData = allWaterproofData.map(x => { return { Id: x.Id, Name: x.Name } });
        //console.log(allWaterproofData);
        productWaterproofIdInput.find('option').remove().end();
        allWaterproofData.forEach(x => {
            productWaterproofIdInput.append($('<option>', {
                value: x.Id,
                text: x.Name
            }));
        })
        productWaterproofIdInput = productWaterproofIdInput.selectpicker({ liveSearch: true });
    });
    //#endregion

    //#region Category
    $.ajax({
        type: "GET",
        url: urlGetAllCategory,
    }).done((data) => {
        allCategoryData = JSON.parse(data.data);
        allCategoryData = allCategoryData.map(x => { return { Id: x.Id, Name: x.Name } });
        //console.log(allCategoryData);
        productCategoryInput.find('option').remove().end();
        allCategoryData.forEach(x => {
            productCategoryInput.append($('<option>', {
                value: x.Id,
                text: x.Name
            }));
        })
        productCategoryInput = productCategoryInput.selectpicker({ liveSearch: true });
    });
    //#endregion
}

/** Reset lại các trường dữ liệu về rỗng */
function emptyDetailView() {
    formProductDetail.trigger("reset");
    productKeyWordSEOInput.importTags('');
    editorProductFullDetail.code('');

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
                "Id": productIdInput.val(),
                "Name": productNameInput.val(),
                //"Video": null,
                "Url": productURLInput.val(),
                "Price": productPriceInput.val(),
                "PriceDiscount": productPriceDiscountInput.val(),
                //"DiscountDateFrom": "2020-11-29T11:15:02.5966667",
                //"DiscountDateTo": "2020-11-29T13:15:02.5966667",
                //"Characteristics": null,
                "DescriptionShort": productDescriptionShortInput.val(),
                "DescriptionFull": editorProductFullDetail.code(),
                "Sku": productSKUInput.val(),
                "BrandProductId": productBrandInput.val(),
                //"BrandProduct": {
                //    "Id": 167,
                //    "Name": "Bulova",
                //    "Description": null,
                //    "Products": [],
                //    "CreateDate": "2020-11-29T11:12:51.64",
                //    "CreateBy": null,
                //    "UpdateDate": null,
                //    "UpdateBy": null,
                //    "Status": 1
                //},
                "OriginNumber": productOriginNumberInput.val(),
                "MachineId": productMachineIdInput.val(),
                //"Machine": null,
                "InternationalWarrantyTime": productInternationalWarrantyTimeInput.val(),
                "StoreWarrantyTime": productStoreWarrantyTimeInput.val(),
                "Diameter": productDiameterInput.val(),
                "ThicknessOfClass": productThicknessOfClassInput.val(),
                "BandId": productBandIdInput.val(),
                //"Band": null,
                "StrapId": productStrapIdInput.val(),
                //"Strap": null,
                "ColorClockFaceId": productColorClockFaceIdInput.val(),
                //"ColorClockFace": null,
                "MadeInId": productMadeInIdInput.val(),
                //"MadeIn": null,
                "StyleId": productStyleIdInput.val(),
                //"Style": null,
                "WaterproofId": productWaterproofIdInput.val(),
                //"Waterproof": null,
                "CategoryId": productCategoryInput.val(),
                //"Category": null,
                //"Product_Function": null,
                //"OrderItems": null,
                //"Product_ProductStatus": [
                //    {
                //        "ProductId": 1,
                //        "ProductStatusId": 3,
                //        "ProductStatus": null
                //    },
                //    {
                //        "ProductId": 1,
                //        "ProductStatusId": 4,
                //        "ProductStatus": null
                //    },
                //    {
                //        "ProductId": 1,
                //        "ProductStatusId": 5,
                //        "ProductStatus": null
                //    },
                //    {
                //        "ProductId": 1,
                //        "ProductStatusId": 6,
                //        "ProductStatus": null
                //    },
                //    {
                //        "ProductId": 1,
                //        "ProductStatusId": 7,
                //        "ProductStatus": null
                //    }
                //],
                //"Product_Media": [
                //    {
                //        "ProductId": 1,
                //        "MediaId": 167,
                //        "Media": {
                //            "Id": 167,
                //            "Name": "Hình ảnh 353",
                //            "Link": "https://gowatch.vn/wp-content/uploads/2019/11/dong-ho-gowatch-nam-Adee-Kaye-gold-4-500x500.jpg",
                //            "Path": "https://gowatch.vn/wp-content/uploads/2019/11/dong-ho-gowatch-nam-Adee-Kaye-gold-4-500x500.jpg",
                //            "MediaTypeId": 1,
                //            "OrderIndex": 0,
                //            "MediaType": null,
                //            "Product_Media": [],
                //            "CreateDate": "2020-11-29T11:15:34.7733333",
                //            "CreateBy": null,
                //            "UpdateDate": null,
                //            "UpdateBy": null,
                //            "Status": 1
                //        }
                //    },
                //    {
                //        "ProductId": 1,
                //        "MediaId": 7403,
                //        "Media": {
                //            "Id": 7403,
                //            "Name": "Hình ảnh 15273",
                //            "Link": "https://gowatch.vn/wp-content/uploads/2020/02/dong-ho-gowatch-nu-Frederique-Constant-FC-200MPWD3V3B-4-500x500.jpg",
                //            "Path": "https://gowatch.vn/wp-content/uploads/2020/02/dong-ho-gowatch-nu-Frederique-Constant-FC-200MPWD3V3B-4-500x500.jpg",
                //            "MediaTypeId": 1,
                //            "OrderIndex": 0,
                //            "MediaType": null,
                //            "Product_Media": [],
                //            "CreateDate": "2020-11-29T11:15:38.6166667",
                //            "CreateBy": null,
                //            "UpdateDate": null,
                //            "UpdateBy": null,
                //            "Status": 1
                //        }
                //    }
                //],
                //"Reviews": [],
                //"Point": 0,
                //"Qty": productQtyInWareHouseInput.val(),
                //"ViewsCount": 0,
                "QtyInWareHouse": productQtyInWareHouseInput.val(),
                "TitleSEO": productTitleSEOInput.val(),
                "KeyWordSEO": productKeyWordSEOInput.val(),
                "DescriptionShortSEO": productDescriptionShortSEOInput.val(),
                //"CreateDate": "2020-11-29T11:14:28.21",
                //"CreateBy": "Hệ thống",
                "UpdateDate": DateToString(new Date, { type : "us"}),
                //"UpdateBy": null,
                //"Status": 1
            };
            console.log(productDataUpdate)
            Swal.fire({
                title: 'Vui lòng đợi trong giây lát!',
                html: 'Hệ thống đang cập nhật!',
                timerProgressBar: true,
                didOpen: () => {
                    Swal.showLoading();
                    console.log("abc");
                    //let url = `/api/Product/${productIdInput.val()}`;
                    let url = `/api/Product`;
                    $.ajax({
                        type: "PUT",
                        url: url,
                        data: productDataUpdate,
                    }).done((data) => {
                        console.log(data);
                        if (data.success) {
                            Swal.fire("Cập nhật thành công!", "", "success")
                        }
                    }).fail(function (xhr, status, error) {
                        console.log(xhr.responseJSON, status, error);
                        Swal.fire("Lỗi khi cập nhật!", "", "error")
                    });
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
    productQtyInWareHouseInput = $("#productQtyInWareHouse_detail");


    productURLInput = $("#productURL_detail");
    productSKUInput = $("#productSku_detail");
    productOriginNumberInput = $("#productOriginNumber_detail");
    productInternationalWarrantyTimeInput = $("#productInternationalWarrantyTime_detail");
    productStoreWarrantyTimeInput = $("#productStoreWarrantyTime_detail");
    productDiameterInput = $("#productDiameter_detail");
    productThicknessOfClassInput = $("#productThicknessOfClass_detail");


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