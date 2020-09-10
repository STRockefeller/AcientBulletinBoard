"use strict";
$(document).ready(function () {
    $("#btnSubmit").click(function () {
        var data = new Object();
        data["target"] = "PublicBulletinBoard";
        data["name"] = $("#inpName").val();
        data["comment"] = $("#inpComment").val();
        $.post("/CommentSubmit", data)
            .done(function () {
            location.reload();
        })
            .fail(function (err) {
        });
    });
    $("#btnClearBoard").click(function () {
        var data = new Object();
        data["target"] = "PublicBulletinBoard";
        $.post("/ClearBoard", data)
            .done(function () {
            location.reload();
        })
            .fail(function (err) {
        });
    });
});
//# sourceMappingURL=PublicBulletinBoardIndex.js.map