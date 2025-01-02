$(document).ready(function () {
    $(".order-now").on("click", function (e) {
        e.preventDefault();

        const dishId = $(this).data("id");
        toastr.options = {
            closeButton: true,
            progressBar: true,
            timeOut: 5000,
            positionClass: "toast-bottom-right"
        }

        $.ajax({
            url: "/Order/AddItem",
            method: "POST",
            data: { dishId : dishId },
            success: function (response) {
                if (response.success) {
                    $("#cart-count").text(response.itemCount);
                    toastr.success("Dish added to your order!");
                } else {
                    toastr.error(response.message);
                }
            },
            error: function () {
                toastr.error("An unexpected error occurred. Please try again.");
            }
        })
    });
})