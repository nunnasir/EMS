

function makeid() {
    var text = "";
    var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    for (var i = 0; i < 4; i++)
        text += possible.charAt(Math.floor(Math.random() * possible.length));

    return text;
}



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


$("#ExamTypeId").change(function () {

    var examId = $(this).val();

    if (examId != "") {
        var params = { id: examId }

        $.ajax({
            type: "POST",
            url: "../../Exam/MakeExamCode",
            contentType: "application/JSON; charset=utf-8",
            data: JSON.stringify(params),

            success: function (rData) {
                if (rData > 0) {


                    $("#ExamCode").empty();
                    $("#ExamCode").val('EXM-' + makeid() + (rData + 1));
                } else {
                    $("#ExamCode").val('EXM' + makeid() + (rData + 1));
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
        url: "../../Exam/GetCourseByOrganizationId",
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







