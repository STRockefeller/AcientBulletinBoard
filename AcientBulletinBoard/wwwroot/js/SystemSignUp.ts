$(document).ready(function () {
    $("#InpError").hide();
    $("#btnSubmit").click(function () {
        if (inputCheck()) {
            let data: object = new Object();
            data["account"] = $("#InpAccount").val().toString();
            data["password"] = $("#InpPassword").val().toString();
            data["emailAddress"] = $("#emailAddress").val().toString();
            data["name"] = $("#name").val().toString();
            data["camp"] = $("#camp").val().toString();
            $.post("/SignUp", data)
                .done(() => {
                    location.href = "/";
                })
                .fail((err) => {
                })
                ;
        }
    })
    function inputCheck(): boolean {
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