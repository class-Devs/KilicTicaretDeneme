$(document).ready(function () {
    $("#searchInput").on("input", function () {
        var searchText = $(this).val().toLowerCase();

        $(".product-item").each(function () {
            var productName = $(this).find(".card-title").text().toLowerCase();
            if (productName.includes(searchText)) {
                $(this).show();
            } else {
                $(this).hide();
            }
        });
    });
});