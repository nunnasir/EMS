
//Get Courses By Organization
$("#OrganizationId").change(function () {

    var orgId = $(this).val();

    if (orgId != "") {
        var params = { id: orgId }

        $.ajax({
            type: "POST",
            url: "../../Trainer/GetCourseByOrganizationId",
            contentType: "application/JSON; charset=utf-8",
            data: JSON.stringify(params),

            success: function (rData) {
                if (rData != undefined && rData != "") {
                    $("#courseListDD").empty();
                    $("#courseListDD").append("<option value=''>Select Course</option>");

                    $.each(rData,
                        function (k, v) {
                            var option = "<option value='" + v.Id + "'>" + v.Name + "</option>";
                            $("#courseListDD").append(option);
                        });
                } else {
                    $("#courseListDD").empty();
                    $("#courseListDD").append("<option value=''>Select Course</option>");
                }
            }
        });
    }

});


//Get Batch By Course
$("#courseListDD").change(function () {

    var crsId = $(this).val();

    if (crsId != "") {
        var params = { id: crsId }

        $.ajax({
            type: "POST",
            url: "../../Trainer/GetBatchByCourseId",
            contentType: "application/JSON; charset=utf-8",
            data: JSON.stringify(params),

            success: function (rData) {
                if (rData != undefined && rData != "") {
                    $("#batchListDD").empty();
                    $("#batchListDD").append("<option value=''>Select Batch</option>");

                    $.each(rData,
                        function (k, v) {
                            var option = "<option value='" + v.Id + "'>" + v.Name + "</option>";
                            $("#batchListDD").append(option);
                        });
                } else {
                    $("#batchListDD").empty();
                    $("#batchListDD").append("<option value=''>Select Course</option>");
                }
            }
        });
    }

});


//Get City By Country
$("#CountryId").change(function () {

    var countryId = $(this).val();

    if (countryId != "") {
        var params = { id: countryId }

        $.ajax({
            type: "POST",
            url: "../../Trainer/GetCitiesByCountry",
            contentType: "application/JSON; charset=utf-8",
            data: JSON.stringify(params),

            success: function (rData) {
                if (rData != undefined && rData != "") {
                    $("#cityListDD").empty();
                    $("#cityListDD").append("<option value=''>Select City</option>");

                    $.each(rData,
                        function (k, v) {
                            var option = "<option value='" + v.Id + "'>" + v.Name + "</option>";
                            $("#cityListDD").append(option);
                        });
                } else {
                    $("#cityListDD").empty();
                    $("#cityListDD").append("<option value=''>Select city</option>");
                }
            }
        });
    }

});



