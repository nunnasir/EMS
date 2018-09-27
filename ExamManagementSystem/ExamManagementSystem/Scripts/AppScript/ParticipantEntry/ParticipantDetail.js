
$(document).ready(function() {

    //Get Course By Organization (First Time With Page Load)
    var orgId = $("#OrganizationId").val();
    if (orgId != "" && orgId != undefined) {
        loadCourseByOrgId(orgId);
    }

    //Get Courses By Change Organization
    $("#OrganizationId").change(function () {

        var orgId = $(this).val();

        if (orgId != "" && orgId != undefined) {
            loadCourseByOrgId(orgId);
        }

    });

    //Get City By Country (First Time With Page Load)
    var countryId = $("#CountryId").val();
    if (countryId != "" && countryId != undefined) {
        loadCityByCountryId(countryId);
    }

    //Get Courses By Change Organization
    $("#CountryId").change(function () {

        var countryId = $(this).val();

        if (countryId != "" && countryId != undefined) {
            loadCityByCountryId(countryId);
        }

    });


});



//Get Batch By Course
$("#courseListDD").change(function () {

    var crsId = $(this).val();

    if (crsId != "") {
        var params = { id: crsId }

        $.ajax({
            type: "POST",
            url: "../../Participant/GetBatchByCourseId",
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


//Load Organization (jQuery Function)
function loadCourseByOrgId(orgId) {
    var params = { id: orgId };
    $.ajax({
        type: "POST",
        url: "../../Participant/GetCourseByOrganizationId",
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

//Load city (jQuery Function)
function loadCityByCountryId(countryId) {
    var params = { id: countryId };
    $.ajax({
        type: "POST",
        url: "../../Participant/GetCitiesByCountry",
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








