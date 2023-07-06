



$(document).ready(function () {
    $('.datatables-users').DataTable({
        dom: 't<"mt-5 me-4"p>',
        "ordering": false,
    });
    var table = $('.datatables-users').DataTable();
    $('#seaarchinput').on('keyup', function () {
        var val = $(this).val();
        var selval = $('#searchsele').val();
        if (selval) {
            table.column(selval).search(val).draw(false);
        } else {
            table.search(val).draw(false);
        }
    });


})


