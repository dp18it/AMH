
$(document).ready(function () {

    var CompanyId = 0;
    debugger
    if (location.pathname != null && location.pathname != undefined) {
        var parts = location.href.split('/');
        CompanyId = parts.pop();
        GetOrganization(CompanyId);
        $('#CompanyId').val(CompanyId);
    }
});

function SaveOrganization() {

    var OrganizationDataObj = {
        CompanyId: $("#CompanyId").val(),
        UserId: $("#UserId").val(),
        CompanyName: $("#CompanyName").val(),
        Address: $("#Address").val(),
        Name: $("#Name").val(),
        Email: $("#Email").val(),
        Password: $("#Password").val(),
        Phone: $("#Phone").val(),
        UAddress: $("#customerAddress").val()
    };

    $.ajax({
        type: "POST",
        url: '/Organization/SaveOrganizationData',
        data: OrganizationDataObj,
        dataType: 'json',
        async: false,
        success: function (response) {

            if (response.Code != 200) {
                setTimeout(alert(response.Message), 2000);
            } else {
                setTimeout(alert(response.Message), 2000);
                window.location.href = "/Organization/Index";
            }
        },
        error: function (error) {

        }
    });
}

function GetOrganization(id) {
    debugger
    if (id > 0) {
        $.ajax({
            type: "POST",
            url: '/Organization/GetOrganizationData',
            data: { OrganizationId: id },
            dataType: 'json',
            async: false,
            success: function (response) {
                if (response.Code == 200) {
                    $("#CompanyId").val(response.Item.CompanyId);
                    $("#UserId").val(response.Item.UserId);
                    $("#CompanyName").val(response.Item.CompanyName);
                    $("#Address").val(response.Item.Address);
                    $("#Name").val(response.Item.Name);
                    $("#Email").val(response.Item.Email);
                    $("#customerAddress").val(response.Item.UAddress);
                    $("#Phone").val(response.Item.Phone);
                   // $("#Password").val(response.Item.Password);
                }
            },
            error: function (error) {
            }
        });
    }
}

$('.updateOrganization').click(function () {
    OpenPopup($('#CompanyId').val());
})
function isPasswordPresent() {
    debugger
    if ($('#CompanyId').val() == "Create") {
        return true;
    } else {
        return $('#Password').val().length > 0;
    }
    //return $('#Password').val().length > 0;
}
function OpenPopup(id = '0') {

    id = parseInt(id);
    $("#frmOrganization").validate({
        rules: {
            CompanyName: "required",
            Address: "required",
            Name: "required",
            Email: {
                required: true,
                email: true
            },
            Password: {
                required: isPasswordPresent,
                minlength: {
                    depends: isPasswordPresent,
                    param: 8
                }
            },
            ConfirmPassword: {
                required: isPasswordPresent,
                minlength: {
                    depends: isPasswordPresent,
                    param: 8
                },
                equalTo: {
                    depends: isPasswordPresent,
                    param: "#Password"
                }

            },
            Phone: {
                required: true,
                number: true,
                maxlength: 10,
                minlength: 10
            }
        },
        messages: {
            Phone: {
                minlength: "Please Enter 10 digit Phone Number",
                maxlength: "Please Enter 10 digit Phone Number"
            },
            Password: {
                minlength: "Please Enter 8 digit Password",
            },
            ConfirmPassword: {
                minlength: "Please Enter 8 digit Confirm Password",
                equalTo: "Password & Confirm Password Does Not Match!",
            }
        },
        errorPlacement: function (error, element) {

            if (element.is(":radio")) {
                error.appendTo(element.parents(".form-group"));
            } else {
                // This is the default behavior
                error.insertAfter(element);
            }
        },
        submitHandler: function (form) {

            SaveOrganization();
        }
    });
}