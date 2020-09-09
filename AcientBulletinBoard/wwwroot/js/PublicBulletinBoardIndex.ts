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
        data["target"] = "PublicBulletinBoard";
        $.post("/ClearBoard", data)
            .done(() => {
                location.reload();
            })
            .fail((err) => {
            })
            ;
    })
})