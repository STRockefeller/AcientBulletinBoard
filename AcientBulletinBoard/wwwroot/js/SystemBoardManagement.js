$(document).ready(function () {
    $(".btnDeleteComment").attr("style", "width : 350px");
    function deleteComment(target) {
        var data = new Object();
        data["target"] = target;
        $.post("/ClearBoard", data)
            .done(function () {
            location.reload();
        })
            .fail(function (err) {
        });
    }
    $("#btnDeleteCommentsAll").click(function () {
        deleteComment("PublicBulletinBoard");
        deleteComment("WeiCampBulletinBoard");
        deleteComment("ShuCampBulletinBoard");
        deleteComment("WuCampBulletinBoard");
        deleteComment("NeutralCampBulletinBoard");
        deleteComment("ForeignCampBulletinBoard");
        deleteComment("GodCampBulletinBoard");
    });
    //$("#btnDeleteCommentsPublic").click(this.deleteComment("PublicBulletinBoard"));
    //$("#btnDeleteCommentsWei").click(this.deleteComment("WeiCampBulletinBoard"));
    //$("#btnDeleteCommentsShu").click(this.deleteComment("ShuCampBulletinBoard"));
    //$("#btnDeleteCommentsWu").click(this.deleteComment("WuCampBulletinBoard"));
    //$("#btnDeleteCommentsNeutral").click(this.deleteComment("NeutralCampBulletinBoard"));
    //$("#btnDeleteCommentsForeign").click(this.deleteComment("ForeignCampBulletinBoard"));
    //$("#btnDeleteCommentsGod").click(this.deleteComment("GodCampBulletinBoard"));
    $("#btnDeleteCommentsPublic").click(function () {
        deleteComment("PublicBulletinBoard");
    });
    $("#btnDeleteCommentsWei").click(function () {
        deleteComment("WeiCampBulletinBoard");
    });
    $("#btnDeleteCommentsShu").click(function () {
        deleteComment("ShuCampBulletinBoard");
    });
    $("#btnDeleteCommentsWu").click(function () {
        deleteComment("WuCampBulletinBoard");
    });
    $("#btnDeleteCommentsNeutral").click(function () {
        deleteComment("NeutralCampBulletinBoard");
    });
    $("#btnDeleteCommentsForeign").click(function () {
        deleteComment("ForeignCampBulletinBoard");
    });
    $("#btnDeleteCommentsGod").click(function () {
        deleteComment("GodCampBulletinBoard");
    });
});
//# sourceMappingURL=SystemBoardManagement.js.map