
$("#OrganizationId").change(function () {

    var orgId = $(this).val();

    if (orgId != "") {
        var params = { id: orgId }

        $.ajax({
            type: "POST",
            url: "../../Batch/GetCourseByOrganizationId",
            contentType: "application/JSON; charset=utf-8",
            data: JSON.stringify(params),

            success: function(rData) {
                if (rData != undefined && rData != "") {
                    $("#courseListDD").empty();
                    $("#courseListDD").append("<option value=''>Select Course</option>");

                    $.each(rData,
                        function(k, v) {
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


$(document).ready(function() {
    $('.datepicker').datepicker();

});


