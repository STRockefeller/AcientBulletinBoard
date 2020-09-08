$(document).ready(function () {
    $("#btnLogin").click(function () {
        var data = new Object();
        data["account"] = $("#InpAccount").val();
        data["password"] = $("#InpPassword").val();
        $.post("/login", data)
            .done(function () {
            location.href = "/PublicBulletinBoard";
        })
            .fail(function (err) {
        });
    });
    $("#btnGuestLogin").click(function () {
        var data = new Object();
        data["account"] = "guest";
        data["password"] = "guest";
        $.post("/login", data)
            .done(function () {
            location.href = "/PublicBulletinBoard";
        })
            .fail(function (err) {
        });
    });
});
//# sourceMappingURL=HomeIndex.js.map