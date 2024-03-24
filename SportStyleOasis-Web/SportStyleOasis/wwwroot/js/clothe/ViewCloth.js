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

function editBtnClickHandler(button) {
    var reviewContainer = $(button).closest(".full-review");
    setupEditForm(reviewContainer);
}

function saveBtnClickHandler(element) {
    var reviewContainer = $(element).closest(".full-review");
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
            var editButton = `<button class="btn btn-primary ms-2 me-2" onclick="editBtnClickHandler(this)">Edit</button>`;
            var deleteButton = `<button class="btn btn-danger space delete-btn" data-review-id="${reviewId}" onclick="deleteBtnClickHandler(this)">Delete</button>`;
            var updatedContent = `Rating: ${response.rating}, `;

            if (response.comment === null) {
                updatedContent += `CreatedAt: ${formattedCreatedAt}, User: ${response.userName} ${editButton} ${deleteButton}`;
            } else {
                updatedContent += `Comment: ${response.comment}, CreatedAt: ${formattedCreatedAt}, User: ${response.userName} ${editButton} ${deleteButton}`;
            }

            reviewContainer.find('.edit-form').remove();
            reviewContainer.html(updatedContent);
        },
        error: function (error) {
            console.error('Error updating comment:', error);
        }
    });
}

function deleteBtnClickHandler(button) {
    var reviewId = $(button).data("review-id");
    confirmDelete(reviewId);
}

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

function setClothSize() {
    var selectedOption = document.getElementById('garmentSize').value;
    document.getElementById('clothSize').value = selectedOption;
}

function addToCart(clothId) {
    var form = document.getElementById('form');

    if (!form.checkValidity()) {
        form.reportValidity();
        return;
    }

    setClothSize();
    var sizeAndQuantity = document.getElementById('clothSize').value.split('|');
    var size = sizeAndQuantity[0];
    var quantity = document.getElementById('quantity').value;
    var availableQuantity = parseInt(sizeAndQuantity[1]);

    if (quantity > availableQuantity) {
        alert(`Quantity exceeds available quantity (${availableQuantity}). Please select a lower quantity.`);
        return;
    }

    $.ajax({
        url: '/ShoppingCart/AddClotheToCart',
        type: 'POST',
        data: { clothId, size, quantity },
        success: function (response) {
            window.location.reload();
        },
        error: function (error) {
            alert("An error occurred while adding clothes to the cart. Please try again later.");
        }
    });
}

function colorOption(element) {
    $(".color-option").removeClass("selected");
    $(element).addClass("selected");

    var clothId = $(element).data("cloth-id");
    var url = '/Clothes/ViewCloth/' + clothId;

    window.location.href = url;
}