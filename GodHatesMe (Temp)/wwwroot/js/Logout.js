$(document).ready(function () {
    $('#SignoutButton').on('click', function () {
        $.ajax({
            url: '/User/Logout',
            type: 'POST',
            success: function (result) {
                window.location.href = '/User/Login';
            },
            error: function (xhr, status, error) {
                console.error(error);
            }
        });
    });
});
