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