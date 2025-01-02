$(document).ready(function () {
    $("#LoginForm").on("submit", function (e) {
        e.preventDefault();

        const formData = $(this).serialize();
        toastr.options = {
            closeButton: true,
            progressBar: true,
            timeOut: 5000,
            positionClass: "toast-bottom-right"
        }

        $.ajax({
            url: $(this).attr("action"),
            method: "POST",
            data: formData,
            success: function (response) {
                if (response.success) {
                    toastr.success("Login successful! Redirecting...");

                    setTimeout(() => {
                        window.location.href = response.redirectUrl;
                    }, 1000)

                } else {
                    toastr.error(response.message || "Invalid login credentials.");
                }
            },
            error: function () {
                toastr.error("An unexpected error occurred. Please try again.");
            }
        })
    })

})