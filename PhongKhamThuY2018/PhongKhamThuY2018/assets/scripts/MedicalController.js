$('#btn-search-pet').click(function () {

        $.ajax({
            type: "POST",
            url: "/Medical/Create",
            success: function (pet) {

            
                $.notify("Tìm thấy " + tong + " thú cưng", { position: "top", autoHideDelay: 2000, className: "info" });
            },
            error: function (error) {
                alert("thua chọn pet" + error);
            }
        })


});