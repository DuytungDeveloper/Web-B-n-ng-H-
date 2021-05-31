////productStatusInput = productStatusInput.selectpicker({ liveSearch: true, multiple: true, tags: true });

let productViewSelect = null;
let listViewProduct = null;
let productInView = null;

let table_orderDetail = $("#table-san-pham").DataTable({
    "lengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "All"]],
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
                return `<button class="btn btn-info" onclick="addProductToView(event,${data})" data-loading-text="Đang tải ...">Thêm</button>`;
            },
        },
    ]
});

const addProductToView = (e, productId) => {
    if ($("#listViewShow .grid-square").length < 10) {
        if ($(`#listViewShow #productView_${productId}`).length == 0) {
            getProductById(productId).then(x => {
                listViewProduct.append(createLiProduct(x));
                updateProductViewType();
            })
        }
    }

}

const updateProductViewType = async () => {
    let viewTypeId = productViewSelect.val();
    let products = [];
    let allElement = $(`#listViewShow .grid-square`);
    for (var i = 0; i < allElement.length; i++) {
        products.push({
            ProductId: $(allElement[i]).data('id'),
            ViewTypeId: viewTypeId,
            OrderId: i,
            Status : 1
        });
    }
    $.ajax({
        type: "POST",
        url: '/api/Product/updateProductInView',
        data: {
            viewTypeId,
            products
        },
    }).done((data) => {
        console.log(data);
        if (data.success) {
            //Swal.fire("Cập nhật thành công!", "", "success")
        }
    }).fail(function (xhr, status, error) {
        console.log(xhr.responseJSON, status, error);
        Swal.fire("Lỗi khi cập nhật!", "", "error")
    });
}

const getAllProductByViewTypeId = async (typeId) => {
    $.get(`/api/product/productViewType/${typeId}`).done((data) => {
        productInView = JSON.parse(data.data);
        console.log(productInView)
        reloadAllProductViewType(productInView)
    })
}

const createLiProduct = (product) => {
    var sub_li = $(`<div class="grid-square" id="productView_${product.Id}" data-id="${product.Id}">`);
    let imgURL = product.Product_Media.length > 0 ? (product.Product_Media.sort((a, b) => a.OrderIndex - b.OrderIndex)[0].Media.Link) : "/assets/data/product-s3-850x1036.jpg"
    sub_li.html(`<div class="col">
                    <h4 class="cut-text" style="    width: min-content;">${product.Name}</h4>
                    <img src="${imgURL}" class="img-responsive" style="width:100px;height:100px;" />
                    <p>${intToPrice(product.Price)}</p>
                    <button class="btn-danger" onclick="removeProductFromView(${product.Id})">Xóa</button>
                </div>`);
    return sub_li;
}

const removeProductFromView = (productId) => {
    if ($("#listViewShow .grid-square").length >= 5) {
        $(`#listViewShow #productView_${productId}`).remove();
        updateProductViewType();
    }
}

const reloadAllProductViewType = async (data) => {
    listViewProduct.html('');
    for (var i = 0; i < data.length; i++) {
        let pro = await getProductById(data[i].ProductId)
        listViewProduct.append(createLiProduct(pro));
    }
}

$(document).ready(function () {
    productViewSelect = $("#productViewid");
    productViewSelect = productViewSelect.selectpicker({ liveSearch: true });
    //productViewSelect.on('changed.bs.select', function (e, clickedIndex, isSelected, previousValue) {
    //    // do something...
    //    console.log('------')
    //    console.log(e)
    //    console.log(clickedIndex)
    //    console.log(isSelected)
    //    console.log(previousValue)
    //});
    productViewSelect.on('rendered.bs.select', function (e, val) {
        // do something...
        console.log('------')
        console.log(productViewSelect.val())
        getAllProductByViewTypeId(productViewSelect.val())
    });


    listViewProduct = $("#listViewShow");
    listViewProduct.sortable({
        animation: 150,
        //ghostClass: 'blue-background-class',
    });
    listViewProduct.on("update", async function (event, ui) {
        updateProductViewType();
    });
    getAllProductByViewTypeId(productViewSelect.val())
})