function confirmDelete(userId, userFullName) {
    const url = '/Admin/User/Delete';

    if (confirm(`Are you sure you want to delete ${userFullName} ?`)) {
        $.ajax({
            url: url,
            type: 'POST',
            data: { userId, userFullName },
            success: function (result) {
                location.reload();
            },
            error: function (error) {
                alert('An error occurred while removing user. Please try again later.');
            }
        });
    } else {
        location.reload();
    }
}