$(document).ready(function () {
    $("#btnLogin").click(function () {
        let data: object = new Object();
        data["account"] = $("#InpAccount").val();
        data["password"] = $("#InpPassword").val();
        $.post("/login", data)
            .done(() => {
                location.href = "/PublicBulletinBoard";
            })
            .fail((err) => {
            })
            ;
    })
    $("#btnGuestLogin").click(function () {
        let data: object = new Object();
        data["account"] = "guest";
        data["password"] = "guest";
        $.post("/login", data)
            .done(() => {
                location.href = "/PublicBulletinBoard";
            })
            .fail((err) => {
            })
            ;
    })
})