$(() => {
    $("#confirmButton").on('click', function () {
        $.post("/Home/Confirm", { id: $(this).data("id") }, function () {
            updateStatus();
        });
    });
    $("#declineButton").on('click', function () {
        $.post("/Home/Decline", { id: $(this).data("id") }, function () {
            updateStatus();
        });
    });
    function updateStatus() {
        $.get("/home/updateStatus", function (status) {
            $("#PendingCount").text(status.Pending);
            $("#ConfirmedCount").text(status.Confirmed);
            $("#DeclinedCount").text(status.Declined);
        });
        $("#confirmButton").hide();
        $("#declineButton").hide();
    }
});