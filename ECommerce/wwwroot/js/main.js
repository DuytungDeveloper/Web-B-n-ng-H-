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
/**Hiển thị lại đơn hàng */
function refreshCart() {
    let cart = getCart();
    let lsHtml = [];
    let totalPrice = 0;
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
    }
    $("#ul-ls-cart-product").html(lsHtml.join(""));
    $("#title-cart-2").text(`${cart.length} ` + translateFunction("sản phẩm trong giỏ hàng"))
    $("#number-product-cart").text(cart.length);
    $("#total-price").text(intToPrice(totalPrice));
    $("#title-cart").text(`${cart.length} ` + translateFunction("sản phẩm"))
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