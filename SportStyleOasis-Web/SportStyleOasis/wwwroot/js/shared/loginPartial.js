function goToShoppingCart(cartId) {
    $.ajax({
        url: '/ShoppingCart/ViewShoppingCart',
        type: 'GET',
        data: { cartId },
        success: function (response) {
            window.location.href = '/ShoppingCart/ViewShoppingCart?cartId=' + cartId;
        },
        error: function (error) {
            alert("An error occurred while processing your request. Please try again later.");
        }
    });
}