$('#updateDiv').on("click", ".acceptRequest", accept_request)

$('.requestDiv').on("click", ".acceptRequest", accept_request)

function accept_request() {

    var requestId = this.getAttribute("data-post-id");

    $.ajax({
        type: "POST",
        url: "/Profile/AcceptRequest/" + requestId,
        contentType: "application/json;charset=UTF-8",
        success: function (data) {
            UpdateRequestPage();

            $.notify("A friend has been added!", {
                className: "success"
            });

        }, error: function () {
            alert("error");
        }
    });
};

function UpdateRequestPage() {

    var serviceUrl = "/Profile/MyFriendRequests/";
    var request = $.post(serviceUrl);
    request.done(function (data) {
        $("#updateDiv").html(data);
    }).fail(function () {
        console.log("does not complete");
    })
};

$('#updateDiv').on("click", ".declineRequest", decline_request)

function decline_request()
{
    var requestId = this.getAttribute("data-post-id");

    $.ajax({
        type: "DELETE",
        url: "/Profile/DeclineRequest/" + requestId,
        contentType: "application/json;charset=UTF-8",
        success: function (data) {
            UpdateRequestPage();

            $.notify("You have declined a request", {
                className: "info"
            });
            alert("You have decline a request");
        }, error: function () {
            alert("error");
        }
    });
}