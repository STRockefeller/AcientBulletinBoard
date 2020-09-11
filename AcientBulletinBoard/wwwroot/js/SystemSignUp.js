$(document).ready(function () {
    //$("#btnMBSubmit").click(function () {
    //    let data = new Object();
    //    data["inputAccount"] = $("#inputAccount").val().toString();
    //    data["inputPassword"] = $("#inputPassword").val().toString();
    //    data["inputConfirmPassword"] = $("#inputConfirmPassword").val().toString();
    //    data["inputEmailAddress"] = $("#inputEmailAddress").val().toString();
    //    data["inputName"] = $("#inputName").val().toString();
    //    data["inputCamp"] = $("#inputCamp").val().toString();
    //    data["inputCamp"] = "Normal";
    //    $.post("/ModelBindingSignUp", data)
    //        .done(() => {
    //            location.href = "/";
    //        })
    //        .fail((err) => {
    //        })
    //        ;
    //})
    $("#InpError").hide();
    $("#btnSubmit").click(function () {
        if (inputCheck()) {
            var data = new Object();
            data["account"] = $("#InpAccount").val().toString();
            data["password"] = $("#InpPassword").val().toString();
            data["emailAddress"] = $("#InpEmail").val().toString();
            data["name"] = $("#InpDisplayName").val().toString();
            data["camp"] = $("#InpCamp").val().toString();
            $.post("/SignUp", data)
                .done(function () {
                location.href = "/";
            })
                .fail(function (err) {
            });
        }
    });
    function inputCheck() {
        if ($("#InpPassword").val() !== $("#InpPasswordCheck").val()) {
            $("#InpError").val("Password check fail");
            $("#InpError").show();
            return false;
        }
        if ($("#InpPassword").val() === "" || $("#InpAccount").val() === "" || $("#InpPasswordCheck").val() === "" || $("#InpEmailAddress").val() === "" || $("#InpName").val() === "" || $("#InpCamp").val() === "") {
            $("#InpError").val("Empty value detected");
            $("#InpError").show();
            return false;
        }
        $("#InpError").hide();
        return true;
    }
});
//# sourceMappingURL=SystemSignUp.js.map