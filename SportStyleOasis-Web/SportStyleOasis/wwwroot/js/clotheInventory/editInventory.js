function saveChanges() {
    // Load all available cloth sizes
    var clothSizes = loadClothSizes();
    var counter = 0;

    // Iterate over each cloth-quantity input field to update corresponding hidden fields
    $('.cloth-quantity').each(function () {
        var newValue = $(this).val(); // Correct way to get the value using jQuery

        if (counter < clothSizes.length) {
            // Use jQuery to find the input and set its value
            $('input[name="ClotheQuantityAndSize[' + clothSizes[counter] + ']"]').val(newValue);
            counter++;
        }
    });
}

// Function to load all available cloth sizes
function loadClothSizes() {
    var clothSizes = [];

    // Iterate over each cloth size input field and extract the cloth size from the name attribute
    $('input[name^="ClotheQuantityAndSize["]').each(function () {
        var clothSize = $(this).attr('name').split('[')[1].split(']')[0];
        clothSizes.push(clothSize);
    });

    return clothSizes;
}
