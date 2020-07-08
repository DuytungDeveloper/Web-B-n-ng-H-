
    var XFunction = {
        RenderMessage: function (type, message) {
            toastr.options = { "newestOnTop": true, "showMethod": "show", "hideMethod": "hide" };
            toastr[type]("<trong>" + message + "</strong>");
        }
    }
    var Validater = {
        number: function (value, callback) {
            if (value === 0)
                callback(true);
            else if (isNaN(value) || value === undefined || value === null || value === "")
                callback(false);
            else if (value < 0)
                callback(false);
            else
                callback(true);
        },
        checkBox: function (value, callback) {
            if (value !== true && value !== false) {
                callback(false);
            }
            else {
                callback(true);
            }
        },
        CheckUpLoadFileIMG: function checkFileUpload(f) {
            debugger
            var bool = true;
            var l_File_Size = f[0].size;
            if (l_File_Size > 10485760) {
                XFunction.RenderMessage('error', 'không đúng định dạng hình ảnh !'); return false;
                XFunction.RenderMessage('error', 'Chỉ cho upload file có dung lượng < 10MB ! (' + l_File_Size + ' bytes)');
                bool = false;
                return false;
            }
            var l_File_Name = f[0].name;
            var l_File_Name_Str = l_File_Name.replace('.', '');
            if (/^[\w ]*$/.test(l_File_Name_Str) == false) {
                XFunction.RenderMessage('error', 'Tên file phải không dấu, không khoảng trắng và không có kí tự đặc biệt !');
                bool = false;
                return false;
            }
            else {
                var inValid = /\s/;
                if (inValid.test(l_File_Name_Str)) {
                    XFunction.RenderMessage('error', 'Tên file không để khoảng trắng !');
                    bool = false;
                    return false;
                }
            }
            return bool;

        }, // File hình . đang dùng ko được xóa
        quantity: function (value, callback) {
            if (value === 0)
                callback(true);
            else if (isNaN(value) || value === undefined || value === null || value === "")
                callback(false);
            else if (value < 0)
                callback(false);
            else
                callback(true);
        },          //quantity >=0 and isnumber
        money: function (value, callback) {
            if (value === 0)
                callback(true);
            else if (isNaN(value) || value === undefined || value === null || value === "") {
                callback(false);
            }
            else if (value < 0)
                callback(false);
            else
                callback(true);
        },             // money >= 0 and is number
        dateGreaterNowDay: function (value, callback) {
            var newdate = value.split("/").reverse().join("/");
            var dateValue = new Date(newdate);
            if ((dateValue.getTime() >= new Date().getTime())) {
                callback(true);
            } else if (value === undefined || value === "") {
                callback(true);
            } else {
                callback(false);
            }
        }, // date > now
        endFile: function (name) {
            debugger;
            var extension = name.split('.').pop().toLowerCase();
            if ($.inArray(extension, ['jpg', 'png', 'gif', 'jpeg']) != -1) {        //file ảnh
                return 1;
            }
            else if ($.inArray(extension, ['xls', 'xlsx']) != -1) {                         //excel
                return 2;
            }
            else if ($.inArray(extension, ['rar', 'zip']) != -1) {                           // file nén
                return 3;
            }
            else if ($.inArray(extension, ['doc', 'docx', 'txt']) != -1) {           // file word. text
                return 4;
            }
            else if ($.inArray(extension, ['ppsx', 'ppsx']) != -1) {         // file powerpoint
                return 5;
            }
            else if ($.inArray(extension, ['pdf']) != -1) {                        //file pdf
                return 6;
            }
            else if ($.inArray(extension, ['bmp', 'csv']) != -1) {                        //file khác
                return 7;
            }
            else {
                return 0;
            }
        },                     //end file excel
        moneyString: function (value) {
            var number = value.replace(/,/g, '');
            if (isNaN(number)) {
                return false;
            } else {
                return true;
            }
        },                // money have ',' >=0
        RenderDataDayOfWeek: function () {
            for (i = 0; i < 6; i++) {
                var newdata = { label: 'Thứ ' + (i + 2), value: i + 2 };
                dayOfWeek.push(newdata);
            }
            dayOfWeek.push({ label: 'Chủ Nhật', value: 1 });
        },
        CheckUserName: function (value) {
            var inValid = /\s/; // check khoảng trắng
            var Check = inValid.test(value);
            if (/^[\w ]*$/.test(value) == false || Check == true || value.length > 100)
                return false;
            else return true;
            // alert('Cảnh báo: Tên file phải không dấu, không khoảng trắng và không có kí tự đặc biệt!');

        }
    };
