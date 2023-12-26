$(document).ready(function () {
    getActivitylist();

});
var savereg = function () {
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

    var model = { Title: title, Details: details, Image1: image1, Image2: image2, Type: type, Date: date, CreateDate: createdate, UpdateDate: updatedate, CreatedBy: createdby, UpdatedBy: updatedby };
    $.ajax({
        url: "/Activity/SaveReg",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (responce) {
            alert(responce.Message);
        }

    });
}
var getActivitylist = function () {

    debugger;
    var search = $("#txtsearch").val();
    var model = {
        Search:search
    }
    $.ajax(
        {
        url: "/Activity/getActivitylist",
        method: "Post",
            data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (responce)
        {
            var html = "";
            $("#tblActivity tbody").empty();
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
                    "</td><td> <input type='button' value='Delete' onClick='DeleteActivity(" + elementValue.Id + ")'</td><td><input type='button' value='Edit' onClick='EditActivity(" + elementValue.Id + ")' /></td ></tr > ";                 
            });
            $("#tblActivity tbody").append(html);

        }

    })


};
var DeleteActivity = function (Id) {
    debugger;
    model = {
        Id: Id
    },
        $.ajax({
            url: "/Activity/DeleteActivity",
            method: "post",
            data: JSON.stringify(model),
            dataType: "json",
            contentType: "application/json:charset=utf-8",
            success: function (response) {
                alert(response.model);
            }

        })
}
var EditActivity = function (Id) {
    debugger;
    var model = { Id: Id };
    $.ajax({
        url: "/Activity/EditActivity",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json:charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            $("#hdnid").val(response.model.Id);

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
