
$(document).ready(function () {
    
    $("#btnUserUpdate").click(function () {

        var vm =
        {
            Id: $("#txtUserId").val(),
            FullName: $("#txtFullName").val(),
            Email: $("#txtEmail").val(),
            RePassword: $("txtRePassword").val(),
            Password: $("#txtPassword").val(),
           
            

        };

        $.ajax({
            url: "/Yonetim/User/UserUpdateJson",
            method: "post",
            datatype: "json",
            data: { vm: vm },
            success: function (response) {
                if (response.Operation) {
                    Swal.fire({
                        type: 'success',
                        title: 'Üyelik Güncellendi',
                        text: 'Üyelik Başarıyla Güncellendi',
                    })
                }
                else
                    alert(response.Message);
            }
        });

    });

    $(document).on("click", "#yetkiAta", async function () {
        var select = '<select id="yetkiId">' +
            '<option value="2">SubAdmin</option>' +
            '<option value="3">CategoryAdmin</option>' +
            '<option value="4">ProductAdmin</option>' + '</select>';


        const { value: formValues } = await Swal.fire({
            title:"Yetki Düzenleme",
            html: select
        })

        var userId = $(this).attr("data-id");
        var yetkiId = $("#yetkiId").val();
        var yetkiAd = $("#yetkiId option:selected").text();
        var button = $(this);

        $.ajax({
            url: "/Yonetim/User/UserRoleUpdateJson",
            method: "post",
            datatype: "json",
            data: { 'yetkiId': yetkiId, 'userId': userId },
            success: function (response) {

                if (response.Operation) {
                    button.text(yetkiAd);
                    Swal.fire({
                        type: 'success',
                        title: 'Yetki Güncellendi',
                        text: 'Yetki Başarıyla Güncellendi',
                    })
                }
                else
                    alert(response.Message);
            }
        });

    });
});