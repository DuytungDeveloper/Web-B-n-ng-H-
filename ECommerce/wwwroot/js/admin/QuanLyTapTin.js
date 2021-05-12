let table = $("#table-tap-tin").DataTable({
    "processing": true,
    serverSide: true,
    responsive: true,
    ajax: {
        url: '/api/Media/search',
        "dataSrc": "data",
        "type": "POST"
    },
    "columns": [
        { "data": "id", "targets": 0 },
        { "data": "name", "targets": 1 },
        {
            "data": "dinhDang", "targets": 2,
            render: function (data, type, row) {
                //console.log(row)
                switch (data) {
                    case "Image":
                        return `<img src="${row.link}" class="img-responsive" style="max-width:100%;">`;
                        break;
                    case "Video":
                        return `<i class="fa fa-video-camera"></i>`;
                        break;
                    default:
                        return data;
                }
                
            }
        },
        { "data": "link", "targets": 3, },
        { "data": "linkServer", "targets": 4 },
        {
            "data": "ngayTao", "targets": 5,
            render: function (data, type, row) {
                return DateToString(new Date(data));
            },
        },
        {
            "data": "id", "targets": 6, "orderable": false,
            render: function (data, type, row) {
                return `<div class="dropdown">
                            <button class="btn btn-primary dropdown-toggle" type="button" id="dropdownMenu1" data-toggle="dropdown" aria-expanded="false">Thao tác <span class="caret"></span></button>
                            <ul class="dropdown-menu" role="menu" aria-labelledby="dropdownMenu1">
                                <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Xóa</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Sửa</a></li>
                            </ul>
                        </div>`;
            },
        },
    ]
});

let modalView = $("#modal_large");

function addFile() {

    modalView.modal('toggle');
    $("#modal_large").modal('toggle');
}

async function uploadFile(oFormElement) {
    console.log(oFormElement);
    var resultElement = oFormElement.elements.namedItem("result");
    const formData = new FormData(oFormElement);

    try {
        const response = await fetch(oFormElement.action, {
            method: 'POST',
            body: formData
        });

        //if (response.ok) {
        //    window.location.href = '/';
        //}

        resultElement.value = 'Result: ' + response.status + ' ' +
            response.statusText;
    } catch (error) {
        console.error('Error:', error);
    }
}