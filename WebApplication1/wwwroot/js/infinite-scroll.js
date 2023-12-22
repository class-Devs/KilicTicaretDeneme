$(document).ready(function () {
    var currentPage = 1;
    var isLoading = false;

    var totalPagesString = document.getElementById('totalPages').getAttribute('data-totalPages');
    var totalPages = parseInt(totalPagesString, 10)

    $(window).scroll(function () {
        if ($(window).scrollTop() + $(window).height() >= $(document).height() - 100 && !isLoading && currentPage < totalPages) {
            isLoading = true;

            // Yükleniyor işaretini ekle
            $('.spinner-border').show();

            // 0.5 saniye gecikme sonunda AJAX isteğini gerçekleştir
            setTimeout(function () {
                currentPage++;

                $.ajax({
                    url: '/Index?handler=OnGet&pageIndex=' + currentPage,
                    type: 'GET',
                    headers: { "X-Requested-With": "XMLHttpRequest" },
                    success: function (data) {
                        if (data.length > 0) {
                            $('#product-container').append(data);
                            isLoading = false;

                            // Yükleniyor işaretini gizle
                            $('.spinner-border').hide();

                            if (currentPage >= totalPages) {
                                // Tüm sayfalar yüklendi, spinner'ı kaldır
                                $('.spinner-border').hide();
                            }
                        }
                    },
                    error: function () {
                        isLoading = false;

                        // Hata durumunda da yükleniyor işaretini gizle
                        $('.spinner-border').hide();
                    }
                });
            }, 750); // 0.5 saniye gecikme
        }
    });
});
