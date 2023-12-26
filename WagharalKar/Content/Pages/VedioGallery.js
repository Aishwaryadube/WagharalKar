$(document).ready(function () {
    debugger;
    getvlist();

});



var savevedio = function () {
    debugger;
    var id = $("#hdnId").val();
    var title = $("#txtTitle").val();
    var youtubeurl = $("#txtYouTubeUrl").val();
    var type = $("#txtType").val();
    var createdate = $("#txtCreateDate").val();
    var updatedate = $("#txtUpdateDate").val();
    var createdby = $("#txtCreatedBy").val();
    var updatedby = $("#txtUpdatedBy").val();

    var model = {Id:id, Title: title, YouTubeUrl: youtubeurl, Type: type, CreateDate: createdate, UpdateDate: updatedate, CreatedBy: createdby, UpdatedBy: updatedby };
    $.ajax({
        url: "/VedioGallery/SaveVedio",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (responce) {
            alert(responce.Message);
            getvlist();
        }
        //error: function (response) {
        //    alert(response.Message)

    });
};

var getvlist = function () {

    debugger;

    $.ajax({
        url: "/VedioGallery/getVediolist",
        method: "Post",

        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (responce) {
            var html = "";
            $("#tblVideoGallery tbody").empty();
            $.each(responce.model, function (Index, elementValue) {
                html += "<tr><td>" + elementValue.Id +
                    "</td ><td>" + elementValue.Title +
                    "</td><td>" + elementValue.YouTubeUrl +
                    "</td><td>" + elementValue.Type +
                    "</td><td>" + elementValue.CreateDate +
                    "</td ><td>" + elementValue.UpdateDate +
                    "</td><td>" + elementValue.CreatedBy +
                    "</td><td>" + elementValue.UpdatedBy + 
                    "</td><td> <input type='button' value='Delete' onClick='DeleteVideoGallery(" + elementValue.Id + ")'></td><td><input type='button' value='Edit' onClick='EditVideoGallery(" + elementValue.Id + ")' /></td></tr>";

            });
            $("#tblVideoGallery tbody").append(html);

        }

    })


};
var DeleteVideoGallery = function (Id) {
    debugger;
    model = {
        Id: Id
    },
        $.ajax({
            url: "/VedioGallery/DeleteVideoGallery",
            method: "post",
            data: JSON.stringify(model),
            dataType: "json",
            contentType: "application/json:charset=utf-8",
            success: function (response) {
                alert(response.model);
            }

        })
}
var EditVideoGallery = function (Id) {
    debugger;
    var model = { Id: Id };
    $.ajax({
        url: "/VedioGallery/EditVideoGallery",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            $("#hdnId").val(response.model.Id);
            $("#txtTitle").val(response.model.Title);
            $("#txtYoutubeUrl").val(response.model.YouTubeUrl);
            $("#txtType").val(response.model.Type);
            $("#txtCreateDate").val(response.model.CreateDate);
            $("#txtUpdateDate").val(response.method.UpdateDate);
            $("#txtCreatedBy").val(response.model.CreatedBy);
            $("#txtUpdatedBy").val(response.model.UpdatedBy);
        }

    })
}
