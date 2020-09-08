$(document).ready(function () {
    $("#btnSubmit").click(function () {
        let data: object = new Object();
        data["name"] = $("#InpName").val();
        data["comment"] = $("#InpComment").val();
        $.post("/login", data)
            .done(() => {
                location.href = "/PublicBulletinBoard";
            })
            .fail((err) => {
            })
            ;
    })
})