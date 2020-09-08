$(document).ready(function () {
    $("#btnSubmit").click(function () {
        var data = new Object();
        data["name"] = $("#InpName").val();
        data["comment"] = $("#InpComment").val();
        $.post("/login", data)
            .done(function () {
            location.href = "/PublicBulletinBoard";
        })
            .fail(function (err) {
        });
    });
});
//# sourceMappingURL=PublicBulletinBoardIndex.js.map