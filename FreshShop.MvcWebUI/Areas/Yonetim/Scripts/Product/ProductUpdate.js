
$(document).ready(function () {
    $("#txtDescription").summernote();
    $("#btnUpdate").click(function () {
        
        
        var vm =
        {
            id: $("#txtProductId").val(),
            ProductName : $("#txtProductName").val(),
            UnitPrice :$("#txtUnitPrice").val(),
            Discount :$("#txtDiscount").val(),
            Description: $("#txtDescription").summernote('code'),

        };

        $.ajax({
            url: "/Yonetim/Product/ProductUpdateJson",
            method: "post",
            datatype: "json",
            data: { vm: vm },
            success: function (response) {
                if (response.Operation) {
                    Swal.fire({
                        type: 'success',
                        title: 'Üyelik Güncellendi',
                        text :'Üyelik Başarıyla Güncellendi',
                    })
                }
                else
                    alert(response.Message);
            }
        });

    });
});


