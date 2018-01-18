"use restrict";

$(function () {

    var form = $("#frmContact");
    var email = $("#txtEmail");
    var id = $("#hdnId");
    form.validate();

    $("#btnEdit").click(function () {

        if (form.valid()) {

            var data = {
                id: id.val(),
                email: email.val()
            };

            $.ajax(
                {
                    type: "POST",
                    url: "/Contacts/Edit",
                    data: data,
                    datatype: "json",
                    cache: false,
                    success: function (result) {

                        if (result === "success") {
                            alert("Contact edited correctly");
                            window.location = "/Contacts";
                        }
                        else {
                            alert(`Something went wrong while trying to create the contact. Please try again.\n${result}`);
                        }
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        alert("Something went wrong while trying to create the contact. Please try again.");
                        console.log(jqXhr);
                        console.log(textStatus);
                        console.log(errorThrown);
                    }

                });
        }
    });
});