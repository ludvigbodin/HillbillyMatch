    function Serialize()
    {
        $.ajax({
            type: "GET",
            url: "/Profile/Serialize/",
            contentType: "application/json;charset=UTF-8",
            success: function (data)
            {
                $.notify("Your profile has been serialized to a XML file. See your desktop!", {
                    className: "success"
                })
            },
            error: function (data)
            {
                $.notify("Error, try again!", {
                    className: "error"
                })
            }
        });
    }