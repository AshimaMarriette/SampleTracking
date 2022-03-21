
$(document).on('click', '.btnDelete', function (e) {
    e.preventDefault();
    var url = $(this).attr('href');

    var $row = $(this).parents('tr');

    swal({
        title: "Are you sure?",
        text: "",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#dc3545",
        confirmButtonText: "Yes",
        cancelButtonText: "No",
        closeOnConfirm: true,
        closeOnCancel: true
    }, function (isConfirm) {

        if (isConfirm) {
            //Ajax to delete

            $.ajax({
                url: url,
                data: $('#frmDelete').serialize(),
                method: "POST",
                success: function (data) {
                    if (data.result) {

                        toastr.options.positionClass = 'toast-top-center';
                        toastr.options.timeOut = 1000
                        toastr['success'](data.message);
                        $row.remove();
                    }
                    else {
                        toastr.options.positionClass = 'toast-top-center';
                        toastr.options.timeOut = 1000
                        toastr['error'](data.message);
                    }
                },
                error: function (error) {
                    swal("Failed!", "Unable to delete.", "error");
                },
                beforeSend: function () {
                    //Show loding

                },
                complete: function () {
                    //Hide loading
                }
            });

        } else {
            toastr.options.positionClass = 'toast-top-center';
            toastr.options.timeOut = 1000
            toastr['error']("Cancelled");
        }
    });
});


$(document).on('click', '.btnChangeStatus', function (e) {
    e.preventDefault();
    var url = $(this).attr('href');

    swal({
        title: url.endsWith("True") ? "Enable User" : "Disable User",
        text: url.endsWith("True") ? "Do you want to enable user?" : "Do you want to disable user?",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#dc3545",
        confirmButtonText: "Yes",
        cancelButtonText: "No",
        closeOnConfirm: true,
        closeOnCancel: true
    }, function (isConfirm) {

        if (isConfirm) {
            //Ajax to change status

            $.ajax({
                url: url,
                data: $('#frmChangeStatus').serialize(),
                method: "POST",
                success: function (data) {
                    if (data.result) {

                        toastr.options.positionClass = 'toast-top-center';
                        toastr.options.timeOut = 200
                        toastr.options.onHidden = () => {
                            location.reload();
                        }
                        toastr['success'](data.message);
                    }
                    else {
                        toastr.options.positionClass = 'toast-top-center';
                        toastr.options.timeOut = 1000
                        toastr['error'](data.message);
                    }
                },
                error: function (error) {
                    swal("Failed!", "Unable to change status.", "error");
                },
                beforeSend: function () {
                    //Show loding

                },
                complete: function () {
                    //Hide loading
                }
            });

        } else {
            toastr.options.positionClass = 'toast-top-center';
            toastr.options.timeOut = 1000
            toastr['error']("Cancelled");
        }
    });
});