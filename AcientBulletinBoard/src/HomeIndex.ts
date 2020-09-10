$(document).ready(function () {
    $("#btnLogin").click(function () {
        const data: { ["account"]: string, ["password"]: string } = { ["account"]: "", ["password"]: ""}
        //let data: object = new Object();
        data["account"] = $("#InpAccount").val().toString();
        data["password"] = $("#InpPassword").val().toString();
        $.post("/login", data)
            .done(() => {
                location.href = "/PublicBulletinBoard";
            })
            .fail((err) => {
            })
            ;
    })
    $("#btnGuestLogin").click(function () {
        const data: { ["account"]: string, ["password"]: string } = { ["account"]: "", ["password"]: "" }
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