//General js function for posting form with serialization
function postFormHandler(route, formId, action) {
    //$("#kt_Add_Registration").modal('hide');
    //$('#_registrationDatatable').load(document.URL + ' #_registrationDatatable');
    on();
    const data = $('#'+formId).serialize();

    $.ajax({
        url: $('#base_url').text() + route,
        type: 'post',
        data: data,
        success: function (response) {
            if (response.isComplete) {
                showNotificationMessage("Success", response.message, "success", action, formId);
            } else {
                var errorMessage = response.message;
                if (!errorMessage)
                    errorMessage = response.detailedMessage;

                showNotificationMessage("Error", errorMessage, "error", "", "");
            }
        },
        complete: function () {
            off();
        },
        error: errorResponse
    });
}



//General js function for posting custom data (No serialization)
function postCustomDataHandler(route, data) {
    $.ajax({
        url: $('#base_url').text() + route,
        type: 'post',
        data: data,
        success: commandResponse,
        error: errorResponse
    });
}

//General js function for posting images
function PostImagehandler(route,imageId,idNumber) {
    if (window.FormData !== undefined) {
        var nfile_count = document.getElementById(imageId);
        if (nfile_count.files.length > 0) {

            var nfile = document.getElementById(imageId).files[0];
            var fname = nfile.name;
            var allowedExtensions = ['jpg', 'png', 'jpeg'];
            var extension = fname.substr(fname.lastIndexOf('.') + 1).toLowerCase();
            if (allowedExtensions.indexOf(extension) === -1) {

                console.log("invalid ext");
                var msg = "File not supported.Only " + allowedExtensions.join(', ') + " are allowed";

                showNotificationMessage("File Upload", msg, "error", "", "");

            } else {

                var data = new FormData();
                data.append("File", nfile);
                data.append("IdNumber", idNumber);


                $.ajax({
                    url: $('#base_url').text() + route,
                    type: 'post',
                    processData: false,
                    contentType: false,
                    data: data,
                    enctype: 'multipart/form-data',
                    success: commandResponse,
                    error: errorResponse
                });


            }
        }
    }

}

//General js function for posting files
function PostFilehandler(route, fileId, idNumber) {
    if (window.FormData !== undefined) {
        var nfile_count = document.getElementById(fileId);
        if (nfile_count.files.length > 0) {

            var nfile = document.getElementById(fileId).files[0];
            var fname = nfile.name;
            var allowedExtensions = ['pdf', 'xls', 'xlxs', 'csv'];
            var extension = fname.substr(fname.lastIndexOf('.') + 1).toLowerCase();
            if (allowedExtensions.indexOf(extension) === -1) {

                console.log("invalid ext");
                var msg = "File not supported. Only " + allowedExtensions.join(', ') + " are allowed";

                showNotificationMessage("File Upload", msg, "error", "", "");

            } else {

                var data = new FormData();
                data.append("File", nfile);
                data.append("IdNumber", idNumber);


                $.ajax({
                    url: $('#base_url').text() + route,
                    type: 'post',
                    processData: false,
                    contentType: false,
                    data: data,
                    enctype: 'multipart/form-data',
                    success: commandResponse,
                    error: errorResponse
                });


            }
        }
    }

}


//General js function for success response
 function commandResponse (response) {
    if (response.isComplete) {
        showNotificationMessage("Success", response.message, "success", "", "");
    } else {
        var errorMessage = response.message;
        if (!errorMessage)
            errorMessage = response.detailedMessage;

        showNotificationMessage("Error", errorMessage, "error", "", "");
    }
}

//General js function for error response
var errorResponse = function (xhr) {

    showNotificationMessage("Error", xhr, "error", "", "");
}


$(document).ready(function () {
    $('.indicator-progress').hide();
});


//General js function for downloading Reports
function postReportHandler(route, formId, buttonId) {
    on();
    //$('.indicator-progress').show();
    $('#' + buttonId).attr('disabled', true);
    const data = $('#'+formId).serialize();
   // console.log(data);

    $.ajax({
        url: $('#base_url').text() + route,
        type: 'post',
        data: data,
        success: function(response) {
            if (response != "") {
                var filePath = response;
                $('<form></form>').attr('action', filePath).appendTo('body').submit().remove();
            } else {
                showNotificationMessage("Error", "Student has no corresponding data", "error", "", "");
            }
            off();
        },
        complete: function () {
            //$('.indicator-progress').hide();
            $('#' + buttonId).attr('disabled', false);
            off();
        },
        error: errorResponse
    });
}



function on() {
    document.getElementById("overlay").style.display = "block";
}

function off() {
    document.getElementById("overlay").style.display = "none";
}

//General js function for deleting request
function deleteRequest(id, route) {

    Swal.fire({
        text: 'Are you sure you want to delete row?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes',
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#ff726f'
    }).then((result) => {
        if (result.isConfirmed) {
            on();
            $.ajax({
                url: $('#base_url').text() + route,
                type: 'post',
                data: {
                    'id': id
                },
                success: function(response) {
                    if (response.isComplete) {

                        showNotificationMessage("Deleted", response.message, "warning", "reload", "");

                    } else {
                        var errorMessage = response.message;
                        if (!errorMessage)
                            errorMessage = response.detailedMessage;
                        showNotificationMessage("Error", errorMessage, "error", "", "");
                    }
                },
                complete: function() {
                    off();

                },
                error: errorResponse
            });
        }
    });
}


function showNotificationMessage(title, text, icon, action, formId) {
    Swal.fire({
        title: title,
        text: text,
        icon: icon,
    }).then((result) => {
        if (result.isConfirmed) {
            if (action === 'reload') {
                location.reload();
            }
            if (action === 'clearForm') {
                $('#' + formId).trigger("reset");
            }

        }
    });
}



$(document).ready(function () {
    $('#th').hide();
    $('#loader').hide();

});