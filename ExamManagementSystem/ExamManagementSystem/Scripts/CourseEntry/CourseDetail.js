
    function makeid() {
        var text = "";
        var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        for (var i = 0; i < 4; i++)
            text += possible.charAt(Math.floor(Math.random() * possible.length));

        return text;
    }


    $("#OrganizationId").change(function () {

        var crsId = $(this).val();

        if (crsId != "") {
            var params = { id: crsId }

            $.ajax({
                type: "POST",
                url: "../../Course/MakeCourseCode",
                contentType: "application/JSON; charset=utf-8",
                data: JSON.stringify(params),

                success: function (rData) {
                    if (rData > 0) {


                        $("#CourseId").empty();
                        $("#CourseId").val('CRS' + makeid() + (rData + 1));
                    } else {
                        $("#CourseId").val('CRS' + makeid() + (rData + 1));
                    }
                }
            });
        }

    });












