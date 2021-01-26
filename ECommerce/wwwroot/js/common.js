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
 * Formart lại số   
 * @param {any} priceNumber Float int gì cũng được
 */
function intToPrice(priceNumber) {
    let lang = getLang();
    let rs = "";
    try {
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
    } catch {
        switch (lang) {
            case "vi":
                rs = new Intl.NumberFormat('vi', { style: 'currency', currency: 'VND' }).format(0);
                break;
            case "en":
                rs = new Intl.NumberFormat('en', { style: 'currency', currency: 'USD' }).format(0);
                break;
            default:
                rs = new Intl.NumberFormat('vi', { style: 'currency', currency: 'VND' }).format(0);
                break;
        }
        return rs;
    }

}
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


/**
 * Lấy trạng thái đơn
 */
async function getOrderStatusAll() {
    const promiseA = new Promise((resolve, reject) => {
        $.get(`/api/OrderStatus`).done((data) => {
            resolve(JSON.parse(data.data));
        })
    });
    let response = await promiseA;
    return response;
    //let rs = await promiseA;
    //console.log(rs);
    //return rs;
}