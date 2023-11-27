function getCartView() {
    jQuery.getJSON('/cart.js', function(cart, textStatus) {
        $('.ajax_cart_quantity').html(cart.item_count);
        $('.cart_quantity').html(cart.item_count);
        $('#view-cart .text-mini-cart').remove();
        $('#view-cart .cart-check-mini').remove();
        $('#view-cart').append(
            "<div class='text-mini-cart'><span class='text-left'>Tổng tiền:</span><span class='cart_block_total'>" + Haravan.formatMoney(cart.total_price,'{{amount}}₫') + "</span></div><div class='cart-check-mini'><a class='button-small' href='/checkout'><span>Thanh toán <i class='fa fa-chevron-right'></i></span></a></div>"
        );
        $.each(cart.items,function(i,item){
            clone_item(item);
        });
    });
};

function clone_item(product){
    var item_product = $('#clone-item .item_2');
    item_product.find('img').attr('src',product.image);
    item_product.find('a:not(.remove-cart)').attr('href', product.url);
    item_product.find('.text_cart > h4 > a').html(product.title);
    var variant = '';
    $.each(product.variant_options,function(i,v){
        variant = variant + ' ' + v;
    });
    item_product.find('.remove-cart').attr('data-id',product.variant_id);
    item_product.find('.variant').html(variant);
    item_product.find('.price-line .new-price').html(Haravan.formatMoney(product.price,"{{amount}}₫") + "<span class='down-case'> x " + product.quantity + "</span>");
    item_product.clone().removeClass('hidden').prependTo('#view-cart');
}

$(document).on("click",".remove-cart",function(){
    var index_view_cart = $(this).parents('.item-cart').index() - 1;
    $(this).parents('.item-cart').remove();
    var variant_id = $(this).attr('data-id');
    var params = {
        type: 'POST',
        url: '/cart/change.js',
        data:  'quantity=0&id='+variant_id,
        dataType: 'json',
        async:false,
        success: function(cart) { 	
            if ( cart.item_count > 0 ) {
                $('.ajax_cart_quantity').html(cart.item_count);
                $('.cart_quantity').html(cart.item_count);
                if ( window.location.pathname == '/cart' ){
                    $('#total-carts').html(Haravan.formatMoney(cart.total_price, "{{amount}}₫"));
                    $('#cartformpage tr.list-carts').eq(index_view_cart).remove();
                };
                $('.cart_block_total').html(Haravan.formatMoney(cart.total_price, "{{amount}}₫"));
            } else {
                if ( window.location.pathname == '/cart' ){
                    $('#cartformpage').remove();
                    $('#layout-page').append("<p class='text-center'>Không có sản phẩm nào trong giỏ hàng!</p><p class='text-center'><a href='/collections/all'><i class='fa fa-reply'></i> Tiếp tục mua hàng</a></p>");
                }
                $('.ajax_cart_quantity').html(cart.item_count);
                $('.cart_quantity').html(cart.item_count);
                $('#view-cart > div:not(#clone-item)').remove();
                $('#view-cart').append("<div style='padding:0 20px;'> <p style='margin:0' class='text-center'>Giỏ hàng của bạn đang trống</p><p class='text-center'><a href='https://ipm.vn'>Tiếp tục mua hàng</a></p></div>");
            }

            setTimeout(function(){
                $.each($(".products.sale_6k_item"),function(){
                    var t = cart.total_price;
                    var t2 = parseFloat($(this).attr("data-pricesale"));
                    var t3 = t;

                    console.log(t3)
                    if(t3 > t2){
                        $(this).removeClass("not_available");
                    }else{
                        $(this).addClass("not_available");
                    }

                })
            },300)
            if ( window.location.pathname == '/cart' ){
                location.reload()
            }



        },
        error: function(XMLHttpRequest, textStatus) {
            Haravan.onError(XMLHttpRequest, textStatus);
        }
    };
    jQuery.ajax(params);

});

