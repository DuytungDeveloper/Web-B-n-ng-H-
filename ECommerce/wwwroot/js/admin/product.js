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
        { "data": "status", "targets": 6},
        {
            "data": "id", "targets": 7, "orderable": false,
            render: function (data, type, row) {
                return `<button class="btn btn-info" onclick="showDetailProductData(event,${data})" data-loading-text="Đang tải ...">Xem chi tiết</button>`;
            },},
    ]
});

/**
 * Hiển thị Popup thông tin sản phẩm
 * @param {any} productId
 */
function showDetailProductData(e,productId) {
    console.log(e);
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
        console.log(productData);
        $('#modal_large').modal('toggle')
        $btn.button('reset');
        $("#maSanPham_detail").html(productData.Id);
    })
}

/**
 * Tải lại trang chi tiết sản phẩm
 * @param {any} e Event
 */
function reloadDetailProduct(e) {
    var $btn = $(e.target).button('loading');
    let productId = $("#maSanPham_detail").html();
    $.get(`/api/Product/${productId}`).done((data) => {
        let productData = JSON.parse(data.data);
        console.log(productData);
        $btn.button('reset');
        $("#maSanPham_detail").html(productData.Id);
    })
}

$(document).ready(function () {
    let editor = $('#productDescriptionFull_detail').summernote({
        placeholder: 'Nội dung chi tiết sản phẩm',
        //tabsize: 2,
        height: 200
    });
    $('#productKeyWordSEO_detail').tagsInput({
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
});