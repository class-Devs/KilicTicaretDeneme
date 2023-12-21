// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// wwwroot/js/site.js

$(document).ready(function () {
    $('.add-to-cart').on('click', function () {
        // Sepete ekleme işlemleri burada gerçekleştirilir
        // Örneğin, bir AJAX çağrısı ile server tarafında sepet güncellenir

        // Sayaç değerini güncelle
        updateCartCounter();
    });
});

function updateCartCounter() {
    // Sayaç değerini güncelleme mantığını buraya ekleyin
    // Örneğin, server tarafından alınan sepet adeti
    var cartItemCount = 5; // Örnek değer

    // Sayaç değerini güncelle
    $('.cart-icon .badge').text(cartItemCount);
}

