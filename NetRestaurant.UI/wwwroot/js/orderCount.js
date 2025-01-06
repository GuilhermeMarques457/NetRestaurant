$(document).ready(function () {
    $.ajax({
        url: "/Order/GetOrderCount",
        method: "GET",
        success: function (response) {
            if (response.success) {
                $("#cart-count").text(response.itemCount)
            }
        },
        error: function () {
            //toastr.error("An error occurred while fetching order count.");
        }
    })
})