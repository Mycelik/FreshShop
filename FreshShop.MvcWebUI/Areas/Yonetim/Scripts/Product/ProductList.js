$(document).ready(function () {
    $('#tblProducts').DataTable({
        "paging": true,
        "lengthChange": true,
        "searching": true,
        "ordering": true,
        "info": true,
        "autoWidth": false,
        "responsive": true,
        "language": {
            "sDecimal": ",",
            "sEmptyTable": "Tabloda herhangi bir veri mevcut değil",
            "sInfo": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
            "sInfoEmpty": "Kayıt yok",
            "sInfoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Sayfada _MENU_ kayıt göster",
            "sLoadingRecords": "Yükleniyor...",
            "sProcessing": "İşleniyor...",
            "sSearch": "Ara:",
            "sZeroRecords": "Eşleşen kayıt bulunamadı",
            "oPaginate": {
                "sFirst": "İlk",
                "sLast": "Son",
                "sNext": "Sonraki",
                "sPrevious": "Önceki"
            },
            "oAria": {
                "sSortAscending": ": artan sütun sıralamasını aktifleştir",
                "sSortDescending": ": azalan sütun sıralamasını aktifleştir"
            },
            "select": {
                "rows": {
                    "_": "%d kayıt seçildi",
                    "0": "",
                    "1": "1 kayıt seçildi"
                }
            }
        },
        "columnDefs": [{
            "targets": 0,
            "orderable": false
        },
        {
            "targets": 5,
            "orderable": false
        },
        {
            "targets": 6,
            "orderable": false
        }]
    });

    $(".btnpSil").click(function () {
        var productId = $(this).attr("prdctId");
        var tr = $(this).parent().parent();

        Swal.fire({
            title: 'Silmek İstediğinizden Emin Misiniz?',
            text: "Seçtiğiniz Admini Silme İşlemi Gerçekleşiyor.",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Evet',
            cancelButtonText: 'Hayır'
        }).then((result) => {
            if (result.value) {

                $.ajax({
                    url: "/Yonetim/Product/Delete/",
                    method: "post",
                    data: { id: productId },
                    dataType: "json",
                    success: function (response) {
                        if (response.Operation) {
                            Swal.fire(
                                'Silindi!',
                                response.Message,
                                'success'
                            )

                            $(tr).remove();
                        } 
                    }
                });

            }
            else {
                Swal.fire(
                    'Silinme İşlemi Yapılmadı!',
                    'Silme İşleminizi Gerçekleşmedi.',
                    'error')

            }
        });

    });

});


