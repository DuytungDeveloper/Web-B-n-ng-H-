/**
 * Lấy thông tin sản phẩm
 * @param {number} id mã sản phẩm
 */
async function getProductById(id) {
    const promiseA = new Promise((resolve, reject) => {
        $.get(`/api/product/${id}`, { id }).done((data) => {
            resolve(JSON.parse(data.data));
        })
    });
    let response = await promiseA;
    return response;
    //let rs = await promiseA;
    //console.log(rs);
    //return rs;
}

/**
 * Cập nhật thông tin Order
 * @param {number} id mã order
 * @param {object} data thông tin update
 */
async function updateOrder(id, data) {
    const promiseA = new Promise((resolve, reject) => {
        let bodySend = {
            Id: id,
            ...data
        };
        $.ajax({
            url: '/api/Order',
            type: 'PUT',
            data: JSON.stringify(bodySend),
            contentType: 'application/json',
            success: function (data) {
                resolve(data);
            }
        });
    });
    let response = await promiseA;
    return response;
    //let rs = await promiseA;
    //console.log(rs);
    //return rs;
}

//let main = async () => {
//    let a = await updateOrder(10002, { OrderStatusId: 1 });
//    console.log(a)
//}
//main();