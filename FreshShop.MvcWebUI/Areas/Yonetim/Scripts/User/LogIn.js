$(document).ready(function () {
    $("#btnLogIn").click(function () {

        var token = $('input[name="__RequestVerificationToken]').val();
        var vm =
        {
            Email: $("#txtEmail").val(),
            Password: $("#txtPassword").val(),
            RememberMe: $("#remember").prop("checked")
        };

        $.ajax({
            url: "/Yonetim/User/LogIn",
            method: "post",
            datatype: "json",
            data: {
                vm: vm,
                __RequestVerificationToken: token
            },
            success: function (response) {
                if (response.Operation) {
                    window.location.href = "/Yonetim/Home/Index";
                }
                else
                    alert(response.Message);
            }
        });
    });
});