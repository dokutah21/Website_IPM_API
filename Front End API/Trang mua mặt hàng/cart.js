$(document).ready(function(){
    Haravan.onItemAdded = function(line_item) {
        console.log(line_item);
        var cart = null;

        jQuery.getJSON('/cart.js', function(cart, textStatus) {
            if(cart)
            {
                var total_line = 0;
                var total_line = line_item.quantity * line_item.price;
                if(line_item.image != null)
                    $('.layer_cart_img').html("<img src=" + Haravan.resizeImage(line_item.image,'medium') + ">");
                else
                    $('.layer_cart_img').html("<img src='//hstatic.net/0/0/global/noDefaultImage6_large.gif'>");
                vt = line_item.variant_options;
                if(vt.indexOf('Default Title') != -1)
                    vt = '';
                $('.item-title a').html(line_item.product_title + '<br><span>' + vt + '</span>').attr('href', line_item.url);
                $('.item-total').html(Haravan.formatMoney(cart.total_price, "")+"đ");	
                $('.item-price').html(Haravan.formatMoney(line_item.price, "")+"đ");
                $('.cart-count').html(cart.item_count);
                $('.layer_cart_img').attr('href', line_item.url);
                $('.item-quantity').html('<strong>Số lượng:</strong>'+line_item.quantity);
            }
        })
    }
});