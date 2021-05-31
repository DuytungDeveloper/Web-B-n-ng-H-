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
    } catch (e) {
        switch (lang) {
            case "vi":
                {
                    rs = new Intl.NumberFormat('vi', { style: 'currency', currency: 'VND' }).format(0);
                    break;
                }
            case "en":
                {
                    rs = new Intl.NumberFormat('en', { style: 'currency', currency: 'USD' }).format(0);
                    break;
                }
            default:
                {
                    rs = new Intl.NumberFormat('vi', { style: 'currency', currency: 'VND' }).format(0);
                    break;
                }
        }
        return rs;
    }

}

/**
 * Format date thành chuỗi
 * @param {any} date
 * @param {any} options
 */
function DateToString(date, options = {}) {
    let defaultOption = {
        type: "vn",
        commas: "-",
        full: true
    };
    options.type = options.type ? options.type : defaultOption.type;
    options.commas = options.commas ? options.commas : defaultOption.commas;
    options.full = options.full ? options.full : defaultOption.full;
    //options = { ...defaultOption, ...options };

    date = new Date(date);
    var hour = date.getHours();
    // hour = (hour < 10 ? "0" : "") + hour;
    hour = hour.toString().padStart(2, "0");

    var min = date.getMinutes();
    // min = (min < 10 ? "0" : "") + min;
    min = min.toString().padStart(2, "0");

    var sec = date.getSeconds();
    // sec = (sec < 10 ? "0" : "") + sec;
    sec = sec.toString().padStart(2, "0");

    var year = date.getFullYear();

    var month = date.getMonth() + 1;
    // month = (month < 10 ? "0" : "") + month;
    month = month.toString().padStart(2, "0");

    var day = date.getDate();
    // day = (day < 10 ? "0" : "") + day;
    day = day.toString().padStart(2, "0");

    let final = "";

    // return day + "/" + month + "/" + year + " " + hour + ":" + min + ":" + sec;
    switch (options.type) {
        case "us": {
            {
                if (options.full) {
                    final = `${year}${options.commas}${month}${options.commas}${day} ${hour}:${min}:${sec}`;
                } else {
                    final = `${year}${options.commas}${month}${options.commas}${day}`;
                }
                break;
            }
        }
        default: {
            {
                if (options.full) {
                    final = `${day}${options.commas}${month}${options.commas}${year} ${hour}:${min}:${sec}`;
                } else {
                    final = `${day}${options.commas}${month}${options.commas}${year}`;
                }
                break;
            }
        }
    }

    return final;
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

/**
 * Hiển thị  màn hình Loading (Cả web)*/
const showLoadingScreen = () => {
    //var elem = document.querySelector('body');
    ////document.body.innerHTML += '<div id="loadingScreen"></div>';
    //var child = document.createElement('<div id="loadingScreen"></div>');
    var elem = document.createElement('div');
    elem.id = "loadingScreen";
    document.body.appendChild(elem);
}

/**
 * Ẩn  màn hình Loading (Cả web)*/
const hideLoadingScreen = () => {
    var elem = document.querySelector('#loadingScreen');
    elem.parentNode.removeChild(elem);
}


const removeVNCharacter = (alias) => {
    var str = alias;
    str = str.toLowerCase();
    str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
    str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
    str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
    str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
    str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
    str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
    str = str.replace(/đ/g, "d");
    str = str.replace(/!|@|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\;|\'|\"|\&|\#|\[|\]|~|\$|_|`|-|{|}|\||\\/g, " ");
    str = str.replace(/ + /g, " ");
    str = str.trim();
    return str;
}
const nameToURL = (name) => {
    let removeVN = removeVNCharacter(name).replace(/[^a-zA-Z ]/g, "");
    removeVN = removeVN.replace(/\s+/gi, "-");
    return removeVN;
}