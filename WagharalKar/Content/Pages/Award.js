$(document).ready(function () {
    getAwardlist();

});
var saveaward = function () {
    debugger;
    var id = $("#txthid").val();
    var title = $("#txtTitle").val();
    var details = $("#txtDetails").val();
    var image1 = $("#txtImage1").val();
    var image2 = $("#txtImage2").val();
    var type = $("#txtType").val();
    var date = $("#txtDate").val();
    var createdate = $("#txtCreateDate").val();
    var updatedate = $("#txtUpdateDate").val();
    var createdby = $("#txtCreatedBy").val();
    var updatedby = $("#txtUpdatedBy").val();

    var model = { Id:id,Title:title, Details: details, Image1: image1, Image2: image2, Type: type, Date: date, CreateDate: createdate, UpdateDate: updatedate, CreatedBy: createdby, UpdatedBy: updatedby };
    $.ajax({
        url: "/Award/SaveAward",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (responce) {
            alert(responce.Message);
            getAwardlist();
        },
        error: function (response) {
            alert(response.Message)
        }
    });
}

var getAwardlist = function () {

    $.ajax(
        {
            url: "/Award/getAwardlist",
            method: "Post",

            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            success: function (responce) {
                var html = "";
                $("#tblAward tbody").empty();
                $.each(responce.model, function (Index, elementValue) {
                    html += "<tr><td>" + elementValue.Id +
                        "</td><td>" + elementValue.Title +
                        "</td><td>" + elementValue.Details +
                        "</td><td>" + elementValue.Image1 +
                        "</td><td>" + elementValue.Image2 +
                        "</td><td>" + elementValue.Type +
                        "</td><td>" + elementValue.Date +
                        "</td><td>" + elementValue.CreateDate +
                        "</td><td>" + elementValue.UpdateDate +
                        "</td><td>" + elementValue.CreatedBy +
                        "</td><td>" + elementValue.UpdatedBy +
                        "</td><td> <input type='button' value='Delete' onClick='DeleteAward(" + elementValue.Id + ")' </td><td><input type='button' value='Edit' onClick='EditAward(" + elementValue.Id + ")' /></td></tr>";


                });

               
                $("#tblAward tbody").append(html);
            }
        })

}
var DeleteAward = function (Id) {
    debugger;
    model = {
        Id: Id
    },
        $.ajax({
            url: "/Award/DeleteAward",
            method: "post",
            data: JSON.stringify(model),
            dataType: "json",
            contentType: "application/json:charset=utf-8",
            success: function (response) {
                alert(response.model);
                getAwardlist();
            }

        })
}
var EditAward = function (Id) {
    debugger;
    var model = { Id: Id };
    $.ajax({
        url: "/Award/EditAward",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json:charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            $("#txthid").val(response.model.Id);
           
            $("#txtTitle").val(response.model.Title);
            $("#txtDetails").val(response.model.Details);
            $("#txtImage1").val(response.model.Image1);
            $("#txtImage2").val(response.model.Image2);
            $("#txtType").val(response.model.Type);
            $("#txtDate").val(response.model.Date);
            $("#txtCreateDate").val(response.model.CreateDate);
            $("#txtUpdateDate").val(response.model.UpdateDate);
            $("#txtCreatedBy").val(response.model.CreatedBy);
            $("#txtUpdatedBy").val(response.model.UpdatedBy);
        }
    })

}
