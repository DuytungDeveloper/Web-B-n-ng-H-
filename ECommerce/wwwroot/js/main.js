let nameCart = "GioHang";
/**
 * Lấy cookie   
 * @param {string} cname tên cookie
 */
function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}
/**
 * Lấy ngôn ngữ hiện tại*/
function getLang() {
    try {
        let lang = getCookie("lang");
        if (lang == "") {
            return "vi";
        }
        return lang;
    } catch (error) {
        return "vi";
    }
}
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
 * Lấy thông tin sản phẩm
 * @param {any} link link sản phẩm
 */
async function getProduct(link) {
    //const promiseA = new Promise((resolutionFunc, rejectionFunc) => {
    //    $.get('/getProduct', { link }).done((data) => {
    //        resolutionFunc(data);
    //    })
    //});
    ////const urlParams = new URLSearchParams();
    ////let postResult = await Promise.resolve($.get('/getProduct', { link }).then());
    ////let postResult = await Promise.resolve($.get('/getProduct', { link })).then();
    ////$.get('/getProduct', { link }).done((data) => {
    ////    console.log(data);
    ////    console.log(cb);
    ////    cb(data)
    ////})
    let response = await fetch(`/getProduct?link=${link}`);
    let rs = await response.json();
    return rs;
    //let rs = await promiseA;
    //console.log(rs);
    //return rs;
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

/**
 * Formart lại số   
 * @param {any} priceNumber Float int gì cũng được
 */
function intToPrice(priceNumber) {
    let lang = getLang();
    let rs = "";
    switch (lang) {
        case "vi":
            rs = new Intl.NumberFormat('vi', { style: 'currency', currency: 'VND' }).format(priceNumber);
            break;
        case "en":
            rs = new Intl.NumberFormat('en', { style: 'currency', currency: 'USD' }).format(priceNumber);
            break;
        default:
            rs = new Intl.NumberFormat('vi', { style: 'currency', currency: 'VND' }).format(priceNumber);
            break;
    }
    return rs;
}

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
                                            <div class="col-sm-3 author">
                                                <div class="grade">
                                                    <span>Grade</span>
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
/**
 * Chuyển ngày thành nội dung ngày tháng dễ hiểu
 * @param {any} date
 */
function DateToString(date) {
    // var d = new Date(date)
    // var ye = new Intl.DateTimeFormat('vi-VN', { year: 'numeric' }).format(d)
    // var mo = new Intl.DateTimeFormat('vi-VN', { month: '2-digit' }).format(d)
    // var da = new Intl.DateTimeFormat('vi-VN', { day: '2-digit' }).format(d)
    // var hh = new Intl.DateTimeFormat('vi-VN', { hour: '2-digit' }).format(d)
    // var mm = new Intl.DateTimeFormat('vi-VN', { minute: '2-digit' }).format(d)
    // var ss = new Intl.DateTimeFormat('vi-VN', { second: '2-digit' }).format(d)
    // // console.log(`${da}/${mo}/${ye} ${hh}:${mm}:${ss < 10 ? '0' + ss : ss}`)
    // return `${da}/${mo}/${ye} ${hh}:${mm}:${ss < 10 ? '0' + ss : ss}`;
    var hour = date.getHours();
    hour = (hour < 10 ? "0" : "") + hour;

    var min = date.getMinutes();
    min = (min < 10 ? "0" : "") + min;

    var sec = date.getSeconds();
    sec = (sec < 10 ? "0" : "") + sec;

    var year = date.getFullYear();

    var month = date.getMonth() + 1;
    month = (month < 10 ? "0" : "") + month;

    var day = date.getDate();
    day = (day < 10 ? "0" : "") + day;

    return day + "/" + month + "/" + year + " " + hour + ":" + min + ":" + sec;
}

/**
 * Phiên dịch   
 * @param {any} value từ cần phiên dịch
 */
function translateFunction(value) {
    try {
        var allTranslate = {
            "Số lượng": { en: "Quantity" },
            "sản phẩm trong giỏ hàng": { en: "products in the cart" },
            "sản phẩm": { en: "product" },
            "Thêm thành công!": { en: "Add to cart success!" },
            "Đăng đánh giá thất bại!": { en: "Post failed review!" },
            "Đăng đánh giá thành công!": { en: "Post a successful review!" },
            "Vui lòng điền đầy đủ thông tin người nhận hàng!": { en: "Please complete the consignee information!" },
            "Chúng tôi cần đầy đủ thông tin để có thể phục vụ quý khách một cách tốt nhất!": { en: "We need enough information to be able to serve you the best way!" },
            "Vui lòng điền đầy đủ thông tin!": { en: "Please fill out the form!" },
            "Đang lên đơn hàng!": { en: "Ordering!" },
            "Vui lòng đợi trong giây lát, tiến trình có thể mất vài giây": { en: "Please wait a moment, the process may take a few seconds" },
            "Lên đơn hàng thành công": { en: "Order successfully" },
            "Chúng tôi sẽ sớm liên lạc với quý khách. Cám ơn đã tin dùng sản phẩm của chúng tôi!": { en: "We will contact you shortly. Thank you for trusting our products!" },
            // "Thêm": {en : "Add"},
            // "Thêm": {en : "Add"},
            // "Thêm": {en : "Add"},
            // "Thêm": {en : "Add"},

        };
        var lang = getCookie("lang");
        var keyValue = allTranslate[value];
        if (keyValue == undefined || keyValue == null) {
            return value;
        }
        if (keyValue[lang] == undefined || keyValue[lang] == null) {
            return value;
        }
        return keyValue[lang];
    } catch (error) {
        console.log("translate fail : ", error);
        return value;
    }
}


//async function main() {
//    var abc = await getProduct("dong-ho-versace-nu-chinh-hang-vco-palazzo-empire.4705");
//    addProductToCart("dong-ho-versace-nu-chinh-hang-vco-palazzo-empire.4705");
//    //removeProductFromCart(4705);
//};


//main();