const step = 1;
const minimumQuantityForOrder = 1;
var debounceTimer;

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

function decreaseQuantity(element, inventoryId, type) {
    const quantityField = findInputField(element);
    var decreasedValue = parseInt(quantityField.value) - step;

    if (decreasedValue >= minimumQuantityForOrder) {
        quantityField.value = decreasedValue;

        if (type == 'cloth') {
            updateClothOrderedQuantity(inventoryId, decreasedValue);
        } else {
            updateProteinOrderedQuantity(inventoryId, decreasedValue);
        }
    } else {
        alert('The minimin quantity for order is 1.');
    }
}

function increaseQuantity(element, availableQuantity, inventoryId, type) {
    const quantityField = findInputField(element);
    var increasedValue = parseInt(quantityField.value) + step;

    if (increasedValue > availableQuantity) {
        alert(`The available quantity of this product is ${availableQuantity}.`);
    } else {
        quantityField.value = increasedValue;

        if (type == 'cloth') {
            updateClothOrderedQuantity(inventoryId, increasedValue);
        } else {
            updateProteinOrderedQuantity(inventoryId, increasedValue);
        }
    }
}

function checkValueDebounced(inputField, maxQuantity, inventoryId, type) {
    // Clear the previous timer
    clearTimeout(debounceTimer);

    // Set a new timer to run the validation function after a delay
    debounceTimer = setTimeout(function () {
        checkValue(inputField, maxQuantity, inventoryId, type);
    }, 600); // Adjust the delay as needed (e.g., 600 milliseconds)
}

function checkValue(inputField, maxQuantity, inventoryId, type) {
    var currentValue = inputField.value;

    // Check for empty string because when user delete with backspace cath check for quantity can't be less than 1.
    // And pop up alert for this if input is empty i didn't update db quantity and give to user this option.
    if (currentValue != '') {
        var currentValueAsInt = parseInt(currentValue);

        if (currentValueAsInt < minimumQuantityForOrder) {
            alert('Quantity cannot be less than 1.');

            inputField.value = minimumQuantityForOrder;
            return;
        } else if (currentValueAsInt > maxQuantity) {
            alert(`Availble stock quantity is ${maxQuantity}`);

            inputField.value = maxQuantity;
            return;
        }

        if (type == 'cloth') {
            updateClothOrderedQuantity(inventoryId, currentValueAsInt);
        } else {
            updateProteinOrderedQuantity(inventoryId, currentValueAsInt);
        }
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
    const url = '/ShoppingCart/UpdateProteinPowderInventory';

    $.ajax({
        url: url,
        type: 'POST',
        data: { proteinOrderedQuantityId, orderedQuantity },
        success: function (result) {
            location.reload();
        },
        error: function (error) {
            alert(`An error occurred while updating the ordered quantity. Please try again later.`);
        }
    });
}

function checkQuantity(clothId, availableQuantity, orderedQuantity) {
    var div = document.getElementById(clothId);
    var label = document.createElement('span');
    var button = document.getElementById('finishOrderBtn');

    if (availableQuantity === 0) {
        label.textContent = 'Out of stock';
        button.disabled = true;
    } else if (availableQuantity < orderedQuantity) {
        label.textContent = 'Not enough quantity';
    } else {
        return;
    }

    button.disabled = true;
    label.classList.add('stock-issue-label');

    div.appendChild(label);
}