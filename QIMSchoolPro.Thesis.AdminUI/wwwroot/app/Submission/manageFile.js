



$("#frmUpload").submit(function (e) {
    
    e.preventDefault();
   
	//var result = validateMarkEntry();
	//if (result) {
    UploadFile('/Version/Create', 'fileId');
	//}
});


function UploadFile(route, fileId) {
   
    
    //on();
    if (window.FormData !== undefined) {
        var nfile_count = document.getElementById(fileId);
        if (nfile_count.files.length > 0) {

            var nfile = document.getElementById(fileId).files[0];
            var fname = nfile.name;

           
            var allowedExtensions = ['txt', 'pdf'];
            var extension = fname.substr(fname.lastIndexOf('.') + 1).toLowerCase();
            if (allowedExtensions.indexOf(extension) === -1) {

                console.log("invalid ext");
                var msg = "File not supported. Only " + allowedExtensions.join(', ') + " are allowed";
                showNotificationMessage("File Upload", msg, "error", "", "");

            } else {

                var data = new FormData();
                data.append("File", nfile);
                data.append("DocumentId", $('#doc_id').val());
               
               

                var messages = "";

                $.ajax({
                    url: $('#base_url').text() + route,
                    type: 'post',
                    processData: false,
                    contentType: false,
                    data: data,
                    enctype: 'multipart/form-data',
                    success: function (response) {

                        if (response.isComplete) {

                            swal({
                                title: "Success",
                                icon: "success",
                                text: "Saved Successfully",
                                type: "success"
                            }).then(function () {
                                window.location.reload();
                            });


                        } else {
                            var errorMessage = response.message;
                            if (!errorMessage)
                                errorMessage = response.detailedMessage;

                            showNotificationMessage("Error", errorMessage, "error");
                        }
                    },
                    complete: function () {
                        //off();
                        //$('.indicator-progress').hide();
                       // $('#' + buttonId).attr('disabled', false);
                    },
                    //error: errorResponse
                });


            }
        } else {
            showNotificationMessage("File Upload", "File not selected", "error", "", "");
           // off();
            //$('.indicator-progress').hide();
           /* $('#' + buttonId).attr('disabled', false);*/
        } 
    }

}



