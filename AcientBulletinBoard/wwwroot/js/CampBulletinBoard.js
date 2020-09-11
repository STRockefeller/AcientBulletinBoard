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
        var target;
        switch ($("#InpCamp").val()) {
            case "Wei":
                target = "Wei";
                break;
            case "Shu":
                target = "Shu";
                break;
            case "Wu":
                target = "Wu";
                break;
            case "Foreign":
                target = "Foreign";
                break;
            case "God":
                target = "God";
                break;
        }
        data["target"] = target + "CampBulletinBoard";
        $.post("/ClearBoard", data)
            .done(function () {
            location.reload();
        })
            .fail(function (err) {
        });
    });
});
//# sourceMappingURL=CampBulletinBoard.js.map