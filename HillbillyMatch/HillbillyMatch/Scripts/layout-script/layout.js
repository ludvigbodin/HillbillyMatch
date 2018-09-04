$(window).load(see_if_requests_exists());

function see_if_requests_exists()
{
    $.ajax({
        type: "GET",
        url: "/Profile/IfUserHasAnyRequests/",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {

            if (result) {
                $(".showRequests").css("color", "red");
            }
            else
            {
                $(".showRequests").css("color", "grey");
            }
        },
        error: function (data) {
            alert("error");
        }
    });
}

