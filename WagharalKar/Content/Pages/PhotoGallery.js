
$(document).ready(function () {
    getPhotolist();

});
var savephoto = function () {
    debugger
    $formData = new FormData();
    var Image1 = document.getElementById('file1');
    var Image2 = document.getElementById('file2');

    if (Image1.files.length > 0)
    {
        for (var i = 0; i < Image1.files.length; i++)
        {
            $formData.append('file1-' + i, Image1.files[i]);

        }
    }
    if (Image2.files.length > 0)
    { 

        for (var j = 0; j < Image2.files.length; j++)
        {
            $formData.append('file2-' + j, Image2.files[j]);

        }
    }
    var id = $("#hdnId").val();
    var title = $("#txtTitle").val();
    var image1 = $("#file1").val();
    var image2 = $("#file2").val();
    var type = $("#txtType").val();
    var createdate = $("#txtCreateDate").val();
    var updatedate = $("#txtUpdateDate").val();
    var createdby = $("#txtCreatedBy").val();
    var updatedby = $("#txtUpdatedBy").val();

    $formData.append('Id', id);
    $formData.append('Title', title);
    $formData.append('Image1', image1);
    $formData.append('Image2', image2);
    $formData.append('Type', type);
    $formData.append('CreateDate', createdate);
    $formData.append('UpdateDate', updatedate);
    $formData.append('CreatedBy', createdby);
    $formData.append('UpdatedBy', updatedby);

    //var model = { Id: id, Title: title, Image1: image1, Image2: image2, Type: type, CreateDate: createdate, UpdateDate: updatedate, CreatedBy: createdby, UpdatedBy: updatedby };

    $.ajax({
        url: "/PhotoGallery/SavePhoto",
        method: "post",
        data: $formData,
        contentType: "application/json;charset=utf-8",
        contentType: false,
        processData: false,
        async: false,
        success: function (responce) {
            alert(responce.Message);
            getPhotolist();
        }
    });

}
var getPhotolist = function () {
    debugger
    var search = $("#txtserch").val();
    var model = {
        Search: search
    }

    $.ajax(
        {
            url: "/PhotoGallery/getPhotolist",
            method: "Post",
            data: JSON.stringify(model),
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            success: function (responce) {
                var html = "";
                $("#tblPhotoGallery tbody").empty();
                $.each(responce.model, function (Index, elementValue) {
                    html += "<tr><td>" + elementValue.Id +
                        "</td><td>" + elementValue.Title +
                        "</td><td><img src='../content/Img/" + elementValue.Image1 +"' style='max-width:100px;max-height:80px;'/>"+
                        "</td><td><img src='../content/Img/" + elementValue.Image2 + "' style='max-width:100px;max-height:80px;'/>" +
                        "</td><td>" + elementValue.Type +
                        "</td><td>" + elementValue.CreateDate +
                        "</td><td>" + elementValue.UpdateDate +
                        "</td><td>" + elementValue.CreatedBy +
                        "</td><td>" + elementValue.UpdatedBy +
                        "</td><td> <input type = 'button' value = 'Delete' onClick ='DeletePhotoGallery(" + elementValue.Id + ")'/></td><td><input type='button' value='Edit' onClick='EditPhotoGallery(" + elementValue.Id + ")' /></td></tr>";


                });
                $("#tblPhotoGallery tbody").append(html);
            }
        })

}

var DeletePhotoGallery = function (Id) {
    debugger;
    model = {
        Id:Id
    },
        $.ajax({
            url: "/PhotoGallery/DeletePhotoGallery",
            method: "post",
            data: JSON.stringify(model),
            dataType: "json",
            contentType: "application/json:charset=utf-8",
            success: function (response) {
                alert(response.model);
                getPhotolist();
            }

        })
}
var EditPhotoGallery = function (Id) {
    debugger;
    var model = { Id: Id };
    $.ajax({
        url: "/PhotoGallery/EditPhotoGallery",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json:charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            $("#txthid").val(response.model.Id);
            $("#txtTitle").val(response.model.Title);
            $("#file1").val(response.model.Image1);
            $("#file2").val(response.model.Image2);
            $("#txtType").val(response.model.Type);
            $("#txtCreateDate").val(response.model.CreateDate);
            $("#txtUpdateDate").val(response.model.UpdateDate);
            $("#txtCreatedBy").val(response.model.CreatedBy);
            $("#txtUpdatedBy").val(response.model.UpdatedBy);
            getPhotolist();
        }
    })

}
function img_pathUrl(input) {
    $('#img_url')[0].src = (window.URL ? URL : webkitURL).createObjectURL(input.files[0]);
}
function img_pathUrl1(input) {
    $('#img_url1')[0].src = (window.URL ? URL : webkitURL).createObjectURL(input.files[0]);
}
