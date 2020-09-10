$(document).ready(function () {
    $("#btnLogin").click(function () {
        var _a;
        var data = (_a = {}, _a["account"] = "", _a["password"] = "", _a);
        //let data: object = new Object();
        data["account"] = $("#InpAccount").val().toString();
        data["password"] = $("#InpPassword").val().toString();
        $.post("/login", data)
            .done(function () {
            location.href = "/PublicBulletinBoard";
        })
            .fail(function (err) {
        });
    });
    $("#btnGuestLogin").click(function () {
        var _a;
        var data = (_a = {}, _a["account"] = "", _a["password"] = "", _a);
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