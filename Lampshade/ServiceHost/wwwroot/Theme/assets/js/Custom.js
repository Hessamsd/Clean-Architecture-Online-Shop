﻿const cookieName = "cart-items";
function addToCart(id, name, price, picture) {
    //debugger;
    let products = $.cookie(cookieName);
    if (products === undefined) {
        products = [];
    } else {
        products = JSON.parse(products);
    }

    const count = $("#productCount").val();
    const currentProduct = products.find(x => x.id === id);
    if (currentProduct !== undefined) {
        products.find(x => x.id === id).count = parseInt(currentProduct.count) + parseInt(count);
    } else {
        const product = {
            id,
            name,
            unitPrice: price,
            picture,
            count
        }

        products.push(product);
    }

    $.cookie(cookieName, JSON.stringify(products), { expires: 2, path: "/" });
    updateCart();

}


function updateCart() {

    let products = $.cookie(cookieName);
    products = JSON.parse(products);
    $("#cart_items_count").text(products.length);

}



