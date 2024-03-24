function removeClothe(element) {
    const url = '/ShoppingCart/RemoveClothFromCart';

    var shoppingCartId = $(element).data("cart-id");
    var clothId = $(element).data("cloth-id");
    var size = $(element).data("cloth-size");
    var clothName = $(element).data("cloth-name");

    if (confirm(`Are you sure you want to remove this ${clothName} ?`)) {
        $.ajax({
            url: url,
            type: 'POST',
            data: { shoppingCartId, clothId, size },
            success: function (result) {
                location.reload();
            },
            error: function (error) {
                alert(`An error occurred while removing ${clothName} from cart. Please try again later.`);
            }
        });
    }
};

function removeProtein(element) {
    const url = '/ShoppingCart/RemoveProteinFromCart';

    var shoppingCartId = $(element).data("cart-id");
    var proteinId = $(element).data("protein-id");
    var flavor = $(element).data("protein-flavor");
    var proteinName = $(element).data("protein-name");

    if (confirm(`Are you sure you want to remove this ${proteinName} ?`)) {
        $.ajax({
            url: url,
            type: 'POST',
            data: { shoppingCartId, proteinId, flavor },
            success: function (result) {
                location.reload();
            },
            error: function (error) {
                alert(`An error occurred while removing ${proteinName} from cart. Please try again later.`);
            }
        });
    }
};