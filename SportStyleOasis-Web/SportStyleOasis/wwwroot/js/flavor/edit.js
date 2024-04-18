function deleteFlavor(proteinFlavorId) {
    const url = '/Flavor/DeleteProteinFlavor';

    if (confirm('Are you sure you want to remove this protein flavor ?')) {
        $.ajax({
            url: url,
            type: 'POST',
            data: { proteinFlavorId },
            success: function (result) {
                location.reload();
            },
            error: function (error) {
                alert('An error occurred while removing protein flavor. Please try again later.');
            }
        });
    }
}