



function loadData() {
    $.ajax({
        url: "/ItemUom/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            var counter = 0;
            $.each(result, function (key, item) {
                counter += 1;
                html += '<tr>';
                html += '<td>' + counter + '</td>';
                html += '<td>' + item.ItemID + '</td>';
                html += '<td>' + item.items.UoMID + '</td>';
                //html += '<td>' + item.items.description + '</td>';

                //html += '<td>';
                //html += '<div class="dropdown">';
                //html += '<button type = "button" class="btn dropdown-toggle hide-arrow p-0" data-bs-toggle="dropdown">';
                //html += '<i class="bx bx-dots-vertical-rounded"></i>';
                //html += '</button >';
                //html += '<div class="dropdown-menu">';
                
                //html += '<a class="dropdown-item" href="#" data-bs-toggle="offcanvas" data-bs-target="#offcanvasAddprimaryWerehouse" onclick="return getbyID(' + item.id + ')">';
                //html += '<i class="bx bx-edit-alt me-1"></i>تعديل</a>';
                //html += '<a class="dropdown-item" href="#" onclick="warehouseDelele(' + item.id + ')">';
                //html += '<i class="bx bx-trash me-1"></i> حذف</a>';
                //html += '</div>';
                //html += '</div>';
                //html += '</td>';


                html += '</tr>';
            });
            $('#tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}




