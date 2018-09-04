
    $(window).load(get_visitors());

    function get_visitors() {

        $.ajax({
            type: "GET",
            url: "/api/AjaxApi/" + userId,
            success:
            function (data) {

                $(".visitorList").empty();
                $.each(data, function (i, item) {

                    var li = '<li><a href="/Profile/UserProfile/' + item.Id + '" style="color: gold;">' + item.Firstname + " " + item.Lastname + '</a></li>'
                    $(".visitorList").append(li);
                })

            },
            error:
            function (data) {

                $.notify("Couldnt get latest visitors", {
                    className: "error"
                });
            }


        });
    }

