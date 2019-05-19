$(document).ready(function () {
    var json_path = $(".table-admin").attr('action');
    // getData(json_path);


    /// Load data to table
    function getData(json_path) {
        $.getJSON(json_path, function (data) {
            var row = "";
            $.each(data.data, function (i, f) {
                row = DrawHtmlUserInTable(f, row);
            });
            $(".table-content").append(row);
        });

    }
    function DrawHtmlUserInTable(f, row) {
        row += "<div class=\"row clear-margin-right\">"
            + "<div class=\"col-md-1 text-center border-cell\">"
            + f.No
            + "</div><div class=\"col-md-3 text-center border-cell\">"
            + f.FullName + "</div><div class=\"col-md-2 text-center border-cell\">"
            + f.PhoneNo
            + " </div><div class=\"col-md-3  border-cell wrap-text\">"
            + f.Email + "</div><div class=\"col-md-1 text-center border-cell\">" + f.Role + "</div><div class=\"col-md-2 border-cell\"><a class=\"btn fas fa-edit\" title=\"Chỉnh sửa\"></a><a class=\"btn fas fa-trash-alt\" title=\"Xóa\"></a></div></div></div>"
        return row;
    }

    /// Search

    $("#search-data").click(function (event) {
        json_path = $("#path-all-user").val();
        var text_search = $(".text-search").val();
        $.getJSON(json_path, function (data) {
            var row = "";
            $.each(data.Data, function (j, f) {
                if (text_search != null && f.FullName.toUpperCase().includes(text_search.toUpperCase())) {
                    row = DrawHtmlUserInTable(f, row);
                }
            });
            $(".table-content").html('').append(row);
        })
    });

    ///clear data
    clearData = function (element) {
        element.value = '';
    }

    //hide search condition list user in admin tool
    $('.nav-search-condition>a').click(function (event) {
        $('.search-condition-detail').toggleClass("hidden");
    })
    // get value page size page num for paging function
    function GetPageSize() {
        return parseInt($('#select-pagesize').val(), 10);
    }
    ShowUserDataPage = function (pageNum, element) {
        var pageSize = GetPageSize();
        var json_path = $(".table-admin").attr('action');
        $.getJSON(json_path, function (data) {
            var totalData = data.Total_Data;
            if (totalData > 0) {
                var row = "";
                var dataNumDel = pageSize * (pageNum - 1);

                var array;
                if (dataNumDel > 0)
                    array = data.Data.splice(0, dataNumDel)
                else {
                    if (totalData > pageSize)
                        array = data.Data.splice(pageSize)
                    else array = data.Data;
                }
                $.each(data.Data, function (j, _data) {
                    row = DrawHtmlUserInTable(_data, row);
                });
                $(".table-content").html('').append(row);
            }
        });
        //active class
        var list = $('.paging').children();
        $.each(list, function (j, e) {
            $(e).removeClass("actived");
        })
        if (element != $('.paging li:first-child')[0] && element != $('.paging li:last-child')[0]) {
            //  var list =  element.parentElement.children;
            $(element).addClass("actived");
        }
        else {
            if (element == $('.paging li:first-child')[0])
                $(list[1]).addClass("actived");
            else
                $(list[list.length - 2]).addClass("actived");
        }

    }


})