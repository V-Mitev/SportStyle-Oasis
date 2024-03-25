function setupEditForm(reviewContainer) {
    var reviewId = reviewContainer.data("review-id");
    var initialComment = reviewContainer.data("initial-comment");
    var initialRating = reviewContainer.data("initial-rating");

    var editForm = `
            <form class="edit-form" data-review-id="${reviewId}">
                <label>Edit Comment:</label>
                <input type="text" class="form-control mb-2" value="${initialComment}" name="editedComment"/>
                <label>Edit Rating:</label>
                <select class="form-control mb-2" name="editedRating" required>
                    <option value="1">1</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                    <option value="4">4</option>
                    <option value="5">5</option>
                </select>
                <button type="button" class="btn btn-primary save-btn" onclick="saveBtnClickHandler(this)">Save</button>
            </form>`;

    var editFormContainer = $('<div>').html(editForm);
    reviewContainer.html('').append(editFormContainer);
    editFormContainer.find("[name='editedComment']").val(initialComment);
    editFormContainer.find("[name='editedRating']").val(initialRating);
}

function editBtnClickHandler(element) {
    var reviewContainer = $(element).closest(".comment-content");
    setupEditForm(reviewContainer);
};

function saveBtnClickHandler(element) {
    var reviewContainer = $(element).closest(".comment-content");
    var reviewId = reviewContainer.data("review-id");
    var editedComment = reviewContainer.find("[name='editedComment']").val();
    var editedRating = reviewContainer.find("[name='editedRating']").val();

    reviewContainer.data("initial-comment", editedComment);
    reviewContainer.data("initial-rating", editedRating);

    $.ajax({
        type: 'POST',
        url: '/Review/EditReview',
        data: { reviewId, editedComment, editedRating },
        success: function (response) {
            var formattedCreatedAt = new Date(response.createdAt).toLocaleDateString('en-US');
            var editButton = `<button class="edit-btn btn btn-primary" onclick="editBtnClickHandler(this)">Edit</button>`;
            var deleteButton = `<button class="btn btn-danger space delete-btn" data-review-id="${reviewId}" onclick="deleteBtnClickHandler(this)">Delete</button>`;
            var updatedContent = `Rating: ${response.rating}, `;

            if (response.comment === null) {
                updatedContent += `CreatedAt: ${formattedCreatedAt}, User: ${response.userName} ${editButton} ${deleteButton}`;
            } else {
                updatedContent += `Comment: ${response.comment}, CreatedAt: ${formattedCreatedAt}, User: ${response.userName} ${editButton} ${deleteButton}`;
            }

            reviewContainer.find('.edit-form').remove();
            reviewContainer.append(updatedContent);
        },
        error: function (error) {
            console.error('Error updating comment:', error);
        }
    })
};

function deleteBtnClickHandler(element) {
    var reviewId = $(element).data("review-id");
    confirmDelete(reviewId);
};

function confirmDelete(reviewId) {
    const url = '/Review/DeleteReview';

    if (confirm('Are you sure you want to delete this review')) {
        $.ajax({
            url: url,
            type: 'POST',
            data: { reviewId },
            success: function (result) {
                location.reload();
            },
            error: function (error) {
                console.log(error);
            }
        });
    }
}

function setProteinFlavor() {
    // Get the selected value from the dropdown
    var selectedFlavor = document.getElementById('proteinFlavors').value;
    // Set the value of the hidden input field
    document.getElementById('proteinFlavor').value = selectedFlavor;
}

function addToCart(proteinId) {
    var form = document.getElementById('form');

    if (!form.checkValidity()) {
        form.reportValidity();
        return; // Stop further execution if validation fails
    }

    setProteinFlavor();
    var proteinFlavor = document.getElementById('proteinFlavor').value.split('|');
    var flavor = proteinFlavor[0];
    var quantity = document.getElementById('quantity').value;
    var availableQuantity = parseInt(proteinFlavor[1]);

    if (quantity > availableQuantity) {
        alert(`Quantity exceeds available quantity (${availableQuantity}). Please select a lower quantity.`);
        return;
    }

    $.ajax({
        url: '/ShoppingCart/AddProteinToCart',
        type: 'POST',
        data: { proteinId, flavor, quantity },
        success: function (response) {
            window.location.reload(); // Reload the page after successful addition
        },
        error: function (error) {
            alert("An error occurred while adding protein to the cart. Please try again later.");
        }
    });
}

function deleteProteinPowder(proteinPowderId, proteinPowderName) {
    const url = '/ProteinPowder/Delete';
    const userConfirmed = window.confirm(`Are you sure you want to delete this Protein Powder: ${proteinPowderName}`);
    if (userConfirmed) {
        $.ajax({
            url: url,
            type: 'POST',
            data: { proteinPowderId, proteinPowderName },
            success: function (result) {
                window.location.href = '/ProteinPowder/All';
            },
            error: function (error) {
                console.log(error);
            }
        });
    } else {
        location.reload();
    }
}