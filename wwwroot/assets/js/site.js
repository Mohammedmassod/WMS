// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.





//@section Scripts
//{

//    <script>

ShowInAside = (url, title) => {
    $.ajax({
        type: "Get",
        url: url,
        success: function (res) {
            $("#offcanvasAddeclient .offcanvas-body").html(res);
            $("#offcanvasAddeclient .offcanvas-header").html(title);
            $("#offcanvasAddeclient").model('Show');
        }
    })
}


jQueryAjaxPost = form => {
    try {
        $.ajax({
            type: "Post",
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#view-all').html(res.html)
                    $('#offcanvasAddeclient .offcanvas-body').html('');
                    $('#offcanvasAddeclient .offcanvas-header').html('');
                    $('#offcanvasAddeclient').modal('hide');
                    //Swal.fire({
                    //    title: 'تم الحفظ بنجاح',
                    //    confirmButtonText: 'موافق',
                    //    icon: 'success',
                    //    customClass: {
                    //        confirmButton: 'btn btn-success',

                    //    },
                    //    buttonsStyling: false
                    //});

                }
                else {
                    $('#view-all').html(res.html)
                    $('#offcanvasAddeclient .offcanvas-body').html('');
                    $('#offcanvasAddeclient .offcanvas-header').html('');
                    $('#offcanvasAddeclient').modal('hide');
                }
            },
            error: function (err) {
                console.log(err)
            }
        })
        //to prevent default form submit event
        return false;
    } catch (ex) {
        console.log(ex)
    }
}


iconSuccess.onclick = function () {
    Swal.fire({
        title: 'تم الحفظ بنجاح',
        confirmButtonText: 'موافق',
        icon: 'success',
        customClass: {
            confirmButton: 'btn btn-success',

        },
        buttonsStyling: false
    });
};
