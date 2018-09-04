$('#updateDiv').on("click", ".deleteFriend", delete_friend);

function delete_friend() {

    var id = this.getAttribute("data-post-id");

    $.ajax({
        type: "DELETE",
        url: "/Profile/DeleteFriend/" + id,
        contentType: "application/json;charset=UTF-8",
        success: function (data) {
            UpdateRequestPage();

            $.notify("A friend has been removed!", {
                className: "success"
            });

        }, error: function () {
            alert("error");
        }
    });
};

function UpdateRequestPage() {

    var serviceUrl = "/Profile/MyFriends/";
    var request = $.post(serviceUrl);
    request.done(function (data) {
        $("#updateDiv").html(data);
    }).fail(function () {
        console.log("does not complete");
    })
};


$('#updateDiv').on("click", ".favoriteTag", favorite_friend);

function favorite_friend()
{
    var id = this.getAttribute("data-post-id");

    $.ajax({
        type: "PUT",
        url: "/Profile/FavoriteTag/" + id,
        contentType: "application/json;charset=UTF-8",
        success: function (data) {
            UpdateRequestPage();

        }, error: function () {
            alert("error");
        }
    })
}
