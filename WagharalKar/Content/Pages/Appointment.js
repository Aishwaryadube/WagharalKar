
$(document).ready(function () {
    getAppointmentlist();

});
var saveappointment = function () {
    debugger;
    var id = $("#hdnId").val();
    var name = $("#txtName").val();
    var email = $("#txtEmail").val();
    var city = $("#ddlCity").val();
    var mobile = $("#txtMobile").val();
    var appointmentdate = $("#txtAppointment").val();
    var gender = $("#ddlGender").val();
    var message = $("#txtMessage").val();
    var updatedate = $("#txtUpdateDate").val();
    var createdby = $("#txtCreatedBy").val();
    var updatedby = $("#txtUpdatedBy").val();
    var createdate = $("#txtCreateDate").val();

    var model = { Id:id,Name: name, Email: email, City: city, MobileNo: mobile, AppointmentDate: appointmentdate, Gender: gender, Message: message, UpdateDate: updatedate, CreatedBy: createdby, UpdatedBy: updatedby, CreateDate: createdate };
    debugger;
    $.ajax({

        url: "/Appintment/SaveAppointment",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (responce) {
            debugger;
            /*console.log(responce);*/
            alert(responce.Message);
            getAppointmentlist();
        },
        Error: function (responce) {
            console.log(responce);
        }

    });
}
      
var getAppointmentlist = function () {

    $.ajax(
        {
            url: "/Appintment/getAppointmentlist",
            method: "Post",

            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            success: function (responce) {
                var html = "";
                $("#tblAppoinment tbody").empty();
                $.each(responce.model, function (Index, elementValue) {
                    html += "<tr><td>" + elementValue.Id +
                        "</td><td>" + elementValue.Name +
                        "</td><td>" + elementValue.Email +
                        "</td><td>" + elementValue.City +
                        "</td><td>" + elementValue.MobileNo +
                        "</td><td>" + elementValue.AppointmentDate +
                        "</td><td>" + elementValue.Gender +
                        "</td><td>" + elementValue.Message +
                        "</td><td>" + elementValue.CreateDate +
                        "</td><td>" + elementValue.UpdateDate +
                        "</td><td>" + elementValue.CreatedBy +
                        "</td><td>" + elementValue.UpdatedBy +
                        "</td><td> <input type='button' value='Delete' onClick='DeleteAppointment(" + elementValue.Id + ")'</td><td><input type='button' value='Edit' onClick='EditAppointment(" + elementValue.Id + ")' /></td ></tr > ";
                });


                $("#tblAppoinment tbody").append(html);
            }
        })

}
var DeleteAppointment = function (Id) {
    debugger;
    model = {
        Id: Id
    },
        $.ajax({
            url: "/Appintment/DeleteAppointment",
            method: "post",
            data: JSON.stringify(model),
            dataType: "json",
            contentType: "application/json:charset=utf-8",
            success: function (response) {
                alert(response.model);
                getAppointmentlist();
            }

        })
}
var EditAppointment = function (Id) {
    debugger;
    var model = { Id: Id };
    $.ajax({
        url: "/Appintment/EditAppointment",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json:charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            $("#hdnId").val(response.model.Id);

            $("#txtName").val(response.model.Name);
            $("#txtEmail").val(response.model.Email);
            $("#ddlCity").val(response.model.City);
            $("#txtMobile").val(response.model.MobileNo);
            $("#txtAppointment").val(response.model.AppointmentDate);
            $("#ddlGender").val(response.model.Gender);
            $("#txtMessage").val(response.model.Message);
            $("#txtCreateDate").val(response.model.CreateDate);
            $("#txtUpdateDate").val(response.model.UpdateDate);
            $("#txtCreatedBy").val(response.model.CreatedBy);
            $("#txtUpdatedBy").val(response.model.UpdatedBy);
        }
    })

}
