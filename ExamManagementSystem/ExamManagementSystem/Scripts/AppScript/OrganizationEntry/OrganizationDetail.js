
$(document).ready(function() {

    function makeid() {
        var text = "";
        var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        for (var i = 0; i < 4; i++)
            text += possible.charAt(Math.floor(Math.random() * possible.length));

        return text;
    }

    $.ajax({
        type: "POST",
        url: "../../Organization/MakeOrganizationCode",
        contentType: "application/JSON; charset=utf-8",

        success: function (rData) {
            if (rData > 0) {
                $("#OrganizationCode").empty();
                $("#OrganizationCode").val('ORG'+ makeid() + (rData + 1));
            } else {
                $("#OrganizationCode").val('ORG' + makeid() + (rData + 1));
            }
        }
    });



});










