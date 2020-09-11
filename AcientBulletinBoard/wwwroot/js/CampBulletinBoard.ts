$(document).ready(function () {
    $("#btnSubmit").click(function () {
        let data: object = new Object();
        data["target"] = "PublicBulletinBoard";
        data["name"] = $("#inpName").val();
        data["comment"] = $("#inpComment").val();
        $.post("/CommentSubmit", data)
            .done(() => {
                location.reload();
            })
            .fail((err) => {
            })
            ;
    })
    $("#btnClearBoard").click(function () {
        let data: object = new Object();
        var target: string;
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
        data["target"] = target+"CampBulletinBoard";
        $.post("/ClearBoard", data)
            .done(() => {
                location.reload();
            })
            .fail((err) => {
            })
            ;
    })
})