var Config = {
    DefaultJtree: function (txtjtree, txtId, defaultvalue, txtnameval, defaultname) {

        $('#' + txtjtree + '').jstree("deselect_all");
        $('#' + txtjtree + '').jstree("close_all");
        $('#' + txtId + '').val(defaultvalue);
        $('#' + txtnameval + '').val(defaultname);

    },
    RefreshJtree: function (txtjtree, txtId, defaultvalue, txtnameval, defaultname) {
        $('#' + txtjtree + '').jstree("deselect_all");
        $('#' + txtjtree + '').jstree("close_all");
        $('#' + txtId + '').val(defaultvalue);
        $('#' + txtnameval + '').val(defaultname);
    },
    SelectedWhenEventClick: function (txtjtree, txtId, txtParentId, txtShow, value) {
        $('#' + txtjtree + '').jstree("deselect_all"); // 
        $('#' + txtjtree + '').jstree("close_all");//
        $('#' + txtParentId + '').val(value.id);
        $('#' + txtId + '').val(value.text);
        //$('#' + txtjtree + '').focus();
        //$('#' + txtShow + '').show();
        $('#' + txtjtree + '').jstree('select_node', "s" + value);
        $('#' + txtjtree + '').jstree("search", value.text);


    },
    MouseupJtree: function (txtjtree, txtId) {
        // sự kiện trời chuột kích vào một nơi khác của jtree thì hide danh mục sổ xuống trong jtree
        $(document).mouseup(function (e) {
            var Categorys = $('#' + txtjtree + ''), txtCategorys = $('#' + txtId + '');
            if (!Categorys.is(e.target)
                && Categorys.has(e.target).length === 0 && !txtCategorys.is(e.target)) {
                Categorys.hide();
            }

        });
    },
    JtreeSearch: function (txtjtree, txtId) {
        $('#' + txtId + '').on('keyup', function () {
            // var to = false;
            //if (to) { clearTimeout(to); }
            setTimeout(function () {
                var v = $('#' + txtId + '').val();
                $('#' + txtjtree + '').jstree(true).search(v);
            }, 250);
        });
        $('#' + txtId + '').on('keypress', function (e) {
            if (e.which == 13) {
                e.preventDefault();
            }
        })
    },
    JTree: function (txtjtree, txtname, txtvalue, data) {
        $('#' + txtjtree + '').on('changed.jstree', function (e, data) {
            $('#Categorys-tree-T').hide();
            var i, j, r = [];
            for (i = 0, j = data.selected.length; i < j; i++) {
                $('#' + txtvalue + '').val(data.instance.get_node(data.selected[i]).id);
                $('#' + txtname + '').val(data.instance.get_node(data.selected[i]).text);
            }
        }).jstree({
            'core': {
                'data': data,
                "multiple": false,
                "animation": 0,
                "themes": {
                    "variant": "large"
                }
            },
            /* thêm check box */
            //"checkbox": {
            //    "keep_selected_style": true
            //},
            "search": {
                "case_insensitive": false, // cấu hình cho phần search tìm theo like 
                "show_only_matches": false  // khi tìm vẫn dữ nguyên các loại còn lại 
            },

            "plugins": [/* Thêm check box "checkbox"*/ "search", "wholerow", "types", "changed", "unique"],
            "types": {
                "default": {
                    "icon": "/Admin/images/Maps-Pin-Place-icon.png"
                }
            },
        });
    }
}

Config.DefaultJtree("Categorys-tree", 'ParentID', '0', "Categorys", 'Chọn loại yêu cầu ')
Config.JtreeSearch("Categorys-tree", "searchCategorys");
Config.MouseupJtree("Categorys-tree-T", "Categorys");

$('#Categorys-tree-T').hide();
$('#Categorys').click(function () {
    $('#Categorys-tree-T').toggle();
    $('#searchCategorys').focus();
});
$('#refreshCategorys').click(function () {
    Config.RefreshJtree("Categorys-tree", 'ParentID', '0', "Categorys", 'Chọn loại yêu cầu ');
});