let nameCart = "GioHang";

/**Lấy danh sách đơn hàng hiện tại */
function getCart() {
    try {
        let stringData = localStorage.getItem(nameCart);
        return JSON.parse(stringData);
    } catch (e) {
        return [];
    }
}
/**
 * Cập nhật lại đơn hàng    
 * @param {any} listProduct danh sách sản phẩm trong giỏ
 */
function setCart(listProduct) {
    if (Array.isArray(listProduct)) {
        localStorage.setItem(nameCart, JSON.stringify(listProduct));
    }
}

/**
 * thêm sản phẩm vào giỏ
 * @param {any} linkPro link sản phẩm
 */
async function addProductToCart(linkPro, num = 1) {
    var rs = await getProduct(linkPro);
    if (rs.success) {
        let cart = getCart();
        if (cart == undefined || cart == null) {
            cart = [];
        }
        rs.data.qty = 1;
        let found = false;
        for (var i = 0; i < cart.length; i++) {
            if (cart[i].id == rs.data.id) {
                cart[i].qty = cart[i].qty != undefined && cart[i].qty != null ? (cart[i].qty + num) : num;
                found = true;
            }
        }
        if (!found)
            cart.push(rs.data);
        setCart(cart)
        refreshCart();
        toastr.options = {
            "closeButton": false,
            "debug": false,
            "newestOnTop": false,
            "progressBar": false,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "500",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
        toastr["info"](translateFunction("Thêm thành công!"));
    }
}
/**
 * Xóa sản phẩm ra khỏi giỏ
 * @param {any} id
 */
function removeProductFromCart(id) {
    let cart = getCart();
    for (var i = 0; i < cart.length; i++) {
        if (cart[i].id == id) {
            cart.splice(i, 1);
        }
    }
    setCart(cart);
    refreshCart();
}
function removeProductFromCart_2(id) {
    removeProductFromCart(id);
    location.href = location.pathname;
}
/**Hiển thị lại đơn hàng */
function refreshCart() {
    let cart = getCart();
    let lsHtml = [];
    let totalPrice = 0;
    let data = {
        AllProduct: []
    };
    if (cart != null)
        for (var i = 0; i < cart.length; i++) {
            let liProductCart = `<li class="product-info"><div class="p-left"><a onclick="removeProductFromCart(${cart[i].id})" class="remove_link"></a><a href="/${getLang()}/san-pham?link=${cart[i].url}.${cart[i].id}"><img class="img-responsive" src="${cart[i].product_Media[0].media.link}" alt="p10"></a></div><div class="p-right"><p class="p-name">${cart[i].name}</p><p class="p-rice">${intToPrice(cart[i].priceDiscount != null ? cart[i].priceDiscount : cart[i].price)}</p><p>${translateFunction("Số lượng")}: ${cart[i].qty}</p></div></li>`;
            //let liProductCart = `<li class="product-info">
            //                            <div class="p-left">
            //                                <a onclick="removeProductFromCart(${cart[i].id})" class="remove_link"></a>
            //                                <a href="/${getLang()}/san-pham?link=${cart[i].url}.${cart[i].id}">
            //                                    <img class="img-responsive" src="${cart[i].product_Media[0].media.link}"
            //                                         alt="p10">
            //                                </a>
            //                            </div>
            //                            <div class="p-right">
            //                                <p class="p-name">${cart[i].name}</p>
            //                                <p class="p-rice">${intToPrice(cart[i].priceDiscount != null ? cart[i].priceDiscount : cart[i].price)}</p>
            //                                <p>${translateFunction("Số lượng")}: ${cart[i].qty}</p>
            //                            </div>
            //                        </li>`;
            totalPrice += (cart[i].priceDiscount != null ? cart[i].priceDiscount : cart[i].price) * cart[i].qty;
            lsHtml.push(liProductCart);
            data.AllProduct.push({
                Qty: cart[i].qty,
                ProductId: cart[i].id
            });
        }
    else {
        cart = [];
    }
    $("#ul-ls-cart-product").html(lsHtml.join(""));
    $("#title-cart-2").text(`${cart.length} ` + translateFunction("sản phẩm trong giỏ hàng"))
    $("#number-product-cart").text(cart.length);
    $("#total-price").text(intToPrice(totalPrice));
    $("#title-cart").text(`${cart.length} ` + translateFunction("sản phẩm"))
    $("#lblCartCount").html(` ${cart.length} `)

    $.ajax({
        url: `/${getLang()}/don-hang/saveorder`,
        type: 'POST',
        data: data,
        success: function (rs) {
            console.log(rs);
        }
    });
}
refreshCart();



//$(function () { $('#rate-review-view').rateit({ max: 5, step: 0.1, backingfld: '#review-point' }); });
/**
 * Thêm reivew cho sản phẩm 
 * @param {any} e Formsubmit
 */
async function addReviewForProduct(e) {
    e.preventDefault();
    let idProduct = $("#id-product-review").val();
    let message = $("#comment-review-product").val();
    let point = parseFloat($("#review-point").val()).toString().replace(".", ",");
    let data = {
        ProductId: idProduct,
        Message: message,
        Point: point
    };
    console.log(data)
    //let response = await $.post(`/${getLang()}/tai-khoan/danh-gia-san-pham`, data);
    $.ajax({
        url: `/${getLang()}/product/danh-gia-san-pham`,
        type: 'POST',
        data: data,
        success: function (rs) {
            console.log(rs);
            if (rs.success) {
                toastr.options = {
                    "closeButton": false,
                    "debug": false,
                    "newestOnTop": false,
                    "progressBar": false,
                    "positionClass": "toast-top-right",
                    "preventDuplicates": false,
                    "onclick": null,
                    "showDuration": "1000",
                    "hideDuration": "1000",
                    "timeOut": "5000",
                    "extendedTimeOut": "1000",
                    "showEasing": "swing",
                    "hideEasing": "linear",
                    "showMethod": "fadeIn",
                    "hideMethod": "fadeOut"
                }
                toastr["info"](translateFunction("Đăng đánh giá thành công!"));
                $("#form-danh-gia").trigger("reset");
                //$('#rate-review-view').rateit('reset')
                $('#rate-review-view').rateit('value', 5);


                let reviewData = `<div class="product-comments-block-tab">
                                        <div class="comment row">
                                            <div class="col author">
                                                <div class="grade">
                                                    <span></span>
                                                    <input type="range" value="${rs.data.point}" step="0.1" id="rate-${rs.data.id}">
                                                    <div class="rateit" id="append-rate-${rs.data.id}" data-rateit-backingfld="#rate-${rs.data.id}" data-rateit-resetable="false" data-rateit-ispreset="true"
                                                         data-rateit-min="0" data-rateit-max="5" data-rateit-readonly="true">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="info-author">
                                                <span><strong>${rs.data.applicationUser.userName}</strong></span>
                                                <em>${new Date(rs.data.createDate)}</em>
                                            </div>
                                        </div>
                                        <div class="col-sm-9 commnet-dettail">
                                            ${rs.data.message}
                                        </div>
                                    </div>
                                    <br />`;
                $("#ls-reviews").append(reviewData);
                $(`#append-rate-${rs.data.id}`).rateit();
            } else {
                toastr.options = {
                    "closeButton": false,
                    "debug": false,
                    "newestOnTop": false,
                    "progressBar": false,
                    "positionClass": "toast-top-right",
                    "preventDuplicates": false,
                    "onclick": null,
                    "showDuration": "300",
                    "hideDuration": "1000",
                    "timeOut": "5000",
                    "extendedTimeOut": "1000",
                    "showEasing": "swing",
                    "hideEasing": "linear",
                    "showMethod": "fadeIn",
                    "hideMethod": "fadeOut"
                }
                toastr["error"](translateFunction(`Đăng đánh giá thất bại!`) + " " + rs.errorMessage);
            }
        }
    });
}

/**
 * Search trong trang tìm kiếm
 * @param {any} page
 */
function searchProduct(page = 0) {
    let Limit = $("#limit-search").val();
    let isDesc = $($("#order-search-desc i")[0]).attr('class').includes("desc");
    let orderBy = $("#order-search").val();

    let funcGetCheckName = (name) => {
        let rs = [];
        let inputMadeIns = $(`input[name=${name}]`);
        for (let i = 0; i < inputMadeIns.length; i++) {
            if ($(inputMadeIns[i]).is(":checked")) {
                rs.push(parseInt($(inputMadeIns[i]).val()))
            }
        }
        return rs;
    }
    let listIdMadeIn = funcGetCheckName('MadeIns');
    let listIdStraps = funcGetCheckName('Straps');
    let listIdMachines = funcGetCheckName('Machines');
    let listIdBands = funcGetCheckName('Bands');
    let listIdColorClockFaces = funcGetCheckName('ColorClockFaces');
    let listIdStyles = funcGetCheckName('Styles');
    let listIdWaterproofs = funcGetCheckName('Waterproofs');
    let listIdBrandProducts = funcGetCheckName('BrandProducts');
    let listIdCategory = funcGetCheckName('Category');
    let text = $("#search-text").val();
    let searchData = {
        SearchString: text,
        BrandNameId: listIdBrandProducts,
        MachineId: listIdMachines,
        BandId: listIdBands,
        StrapId: listIdStraps,
        ColorClockFaceId: listIdColorClockFaces,
        MadeInId: listIdMadeIn,
        StyleId: listIdStyles,
        WaterproofId: listIdWaterproofs,
        CategoryId: listIdCategory,
        PriceFrom: parseFloat($("#price-from").val()),
        PriceTo: parseFloat($("#price-to").val()),
        Page: page,
        Limit,
        isDesc,
        orderBy,
    };
    console.log(searchData)
    console.log($.param(searchData))
    console.log(location.pathname + "?" + $.param(searchData).replace(/%5B%5D/gi, ""));
    location.href = location.pathname + "?" + $.param(searchData).replace(/%5B%5D/gi, "");
}

/**
 * Thay đổi kiểu sắp xếp*/
function changeSortType() {
    let isDesc = $($("#order-search-desc i")[0]).attr('class').includes("desc");
    if (isDesc) {
        $("#order-search-desc").html(`<i class="fa fa-sort-alpha-asc" onclick="changeSortType()"></i>`);
    } else {
        $("#order-search-desc").html(`<i class="fa fa-sort-alpha-desc" onclick="changeSortType()"></i>`);
    }
}

// /**Format int thành tiền */
// function intToPrice(data) {
//     let currency = getLang() == "vi" ? "VND" : "USD";
//     var formatter = new Intl.NumberFormat(getLang(), {
//         style: 'currency',
//         currency: currency,
//     });
//     return formatter.format(data);
// }



//async function main() {
//    var abc = await getProduct("dong-ho-versace-nu-chinh-hang-vco-palazzo-empire.4705");
//    addProductToCart("dong-ho-versace-nu-chinh-hang-vco-palazzo-empire.4705");
//    //removeProductFromCart(4705);
//};


//main();