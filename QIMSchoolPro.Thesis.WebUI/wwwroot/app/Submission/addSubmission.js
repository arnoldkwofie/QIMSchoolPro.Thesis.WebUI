



$("#frmSubmission").submit(function (e) {
    
    e.preventDefault();
   
	//var result = validateMarkEntry();
	//if (result) {
    PostMarksFilehandler('/Submission/Create', 'primaryFile', 'secondaryFile');
	//}
});


function PostMarksFilehandler(route, primaryFileId, secondaryFileId) {
   
    
    //on();
    if (window.FormData !== undefined) {
        var nfile_count = document.getElementById(primaryFileId);
        if (nfile_count.files.length > 0) {

            var nfile = document.getElementById(primaryFileId).files[0];
            var fname = nfile.name;

            var secfile = document.getElementById(secondaryFileId).files[0];
           
            var allowedExtensions = ['txt', 'pdf'];
            var extension = fname.substr(fname.lastIndexOf('.') + 1).toLowerCase();
            if (allowedExtensions.indexOf(extension) === -1) {

                console.log("invalid ext");
                var msg = "File not supported. Only " + allowedExtensions.join(', ') + " are allowed";
                showNotificationMessage("File Upload", msg, "error", "", "");

            } else {

                var data = new FormData();
                data.append("PrimaryFile", secfile);
                data.append("SecondaryFile", nfile);
                data.append("Title", $('#title').val());
                data.append("Abstract", $('#output').text());
               

                var messages = "";

                $.ajax({
                    url: $('#base_url').text() + route,
                    type: 'post',
                    processData: false,
                    contentType: false,
                    data: data,
                    enctype: 'multipart/form-data',
                    success: function (response) {

                        if (response) {

                            if (response.length > 0) {

                                $.each(response, function (index, value) {
                                    messages += value + "\n\n";
                                });

                                messages = messages.replace(/\n/g, "<br>");
                                console.log(messages);

                                Swal.fire({
                                    html: messages,
                                    icon: 'warning',

                                })
                            } else {
                                swal({
                                    title: "Success",
                                    icon: "success",
                                    text: "Saved Successfully",
                                    type: "success"
                                }).then(function () {
                                    window.location = $('#base_url').text() + "/ManageMark/UnpostedResult";
                                });

                            }


                        } else {
                            var errorMessage = response.message;
                            if (!errorMessage)
                                errorMessage = response.detailedMessage;

                            showNotificationMessage("Error", errorMessage, "error");
                        }
                    },
                    complete: function () {
                        //off();
                        $('.indicator-progress').hide();
                       // $('#' + buttonId).attr('disabled', false);
                    },
                    error: errorResponse
                });


            }
        } else {
            showNotificationMessage("File Upload", "File not selected", "error", "", "");
           // off();
            $('.indicator-progress').hide();
           /* $('#' + buttonId).attr('disabled', false);*/
        } 
    }

}



