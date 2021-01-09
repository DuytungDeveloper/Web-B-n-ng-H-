//let table_orderDetail = $("#table-san-pham").DataTable();
let table_orderDetail = $("#table-san-pham").DataTable({
    "processing": true,
    serverSide: true,
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
                return `<img src="${data}" class="img-responsive"  style="    width: 100px;" />`;
            },
            "orderable": false
        },
        { "data": "name", "targets": 2 },
        {
            "data": "price", "targets": 3,
            render: function (data, type, row) {
                return intToPrice(data);
            }
        },
        {
            "data": "priceDiscount", "targets": 4,
            render: function (data, type, row) {
                return intToPrice(data);
            }
        },
        { "data": "point", "targets": 5,  },
        { "data": "status", "targets": 6},
        {
            "data": "id", "targets": 7, "orderable": false,
            render: function (data, type, row) {
                return `<button class="btn btn-info">Xem chi tiết</button>`;
            },},
    ]
});