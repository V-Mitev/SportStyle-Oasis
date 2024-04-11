const step = 1;
const minimumQuantityForOrder = 1;

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

function findInputField(element) {
    return element.closest('.quantity-form').querySelector('input');
}

function decreaseQuantity(element) {
    const quantityField = findInputField(element);
    var currentValue = parseInt(quantityField.value);

    if (currentValue > minimumQuantityForOrder) {
        quantityField.value = currentValue - step;
    } else {
        alert('The minimin quantity for order is 1.');
    }
}

function increaseQuantity(element, availableQuantity, clothInventoryId) {
    const quantityField = findInputField(element);
    var currentValue = parseInt(quantityField.value) + step;

    if (currentValue > availableQuantity) {
        alert(`The available quantity of this product is ${availableQuantity}.`);
    } else {
        quantityField.value = currentValue;
    }

    updateClothOrderedQuantity(clothInventoryId, currentValue);
}

function checkValue(inputField, maxQuantity, inventoryId, type) {
    var currentValue = parseInt(inputField.value);
    var isNan = isNaN(currentValue);

    if (currentValue < minimumQuantityForOrder || isNan) {
        alert('Quantity cannot be less than 1 or empty.');

        inputField.value = minimumQuantityForOrder;
    } else if (currentValue > maxQuantity) {
        alert('Quantity cannot exceed available stock.');

        inputField.value = maxQuantity;
    }

    if (type == 'cloth') {
        updateClothOrderedQuantity(inventoryId, currentValue);
    } else {
        updateProteinOrderedQuantity(inventoryId, currentValue);
    }
}

function updateClothOrderedQuantity(clothInventoryId, orderedQuantity) {
    const url = '/ShoppingCart/UpdateClothInventory';

    $.ajax({
        url: url,
        type: 'POST',
        data: { clothInventoryId, orderedQuantity },
        success: function (result) {
            location.reload();
        },
        error: function (error) {
            alert(`An error occurred while updating the ordered quantity. Please try again later.`);
        }
    });
}

function updateProteinOrderedQuantity(proteinOrderedQuantityId, orderedQuantity) {

}

function notEnoughQuantity() {
    const className = '';
}