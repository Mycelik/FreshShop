$(document).ready(function () {

    $("#txtDescription").summernote();

    $("#chkDiscount").change(function () {
        var isChecked = $(this).prop("checked");
        if (isChecked)
            $("#divDiscount").show();
        else
            $("#divDiscount").hide();
    });


    $("#btnSave").click(function () {

        var isFormValid = $("#frmNewProduct").valid();

        if (isFormValid) {
            var formData = new FormData();

            var files = $('#fuPhoto')[0].files;
            for (var i = 0; i < files.length; i++) {
                formData.append(i.toString(), files[i]);
            }

            var vm =
            {
                ProductName: $("#txtProductName").val(),
                CategoryId: $("#ddlCategories").val(),
                Description: $("#txtDescription").summernote('code'),
                UnitPrice: $("#txtUnitPrice").val(),
                Discount: $("#txtDiscount").val(),
                
            };


            $.ajax({
                url: "/Yonetim/Product/New",
                method: 'post',
                dataType: 'json',
                data: vm,
                success: function (resp) {
                    if (resp.Result) {
                        $.ajax({
                            url: "/Yonetim/Product/UploadPhoto/" + resp.ProductId,
                            method: 'post',
                            dataType: 'json',
                            data: formData,
                            processData: false,
                            contentType: false,
                            success: function (response) {
                                if (response.Result) {
                                    alert("Ürün Kaydedildi");
                                }
                                else {
                                    alert("Dosya yüklenirken bir hata oldu : " + response.Message);
                                }
                            }
                        });
                    }

                }
            });


        }

    });

    $("#ddlCategories").change(function () {

        var selectedCategoryId= $(this).val();

        $.ajax({
            url: "/Yonetim/Category/GetByMainCategoryId",
            method: 'post',
            dataType: 'json',
            data: { topCategoryId: selectedCategoryId},
            success: function (response) {
                if (response.Result) {
                    $("#Mustafa").remove();
                    var subCategories = response.Categories;
                    if (subCategories.length > 0) {
                        $(".lvl1").remove();

                        var html = "<div class='form-group lvl1'><label>Alt Kategorisi</label><select class='form-control level1'>";
                        for (var i = 0; i < subCategories.length; i++) {
                            html += "<option value='" + subCategories[i].Value + "'>" + subCategories[i].Text + "</option>";
                        }
                        html += "</select></div>";

                        $("#divMainCategories").after(html);
                    }
                }

            }
        });

    });

    $(document).on("change",".level1", function () {
        var selectedCategoryId = $(this).val();

        $.ajax({
            url: "/Yonetim/Category/GetByMainCategoryId",
            method: 'post',
            dataType: 'json',
            data: { topCategoryId: selectedCategoryId },
            success: function (response) {
                if (response.Result) {
                    $(".lvl2").remove();
                    var subCategories = response.Categories;
                    if (subCategories.length > 0) {
                        var html = "<div class='form-group lvl2'><label>Alt Kategorisi</label><select class='form-control level2'>";
                        for (var i = 0; i < subCategories.length; i++) {
                            html += "<option value='" + subCategories[i].Value + "'>" + subCategories[i].Text + "</option>";
                        }
                        html += "</select></div>";

                        $(".level1").after(html);
                        
                    }
                }

            }
        });
    });

});

