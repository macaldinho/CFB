"use restrict";

$(function () {

    var form = $("#frmContact");
    var email = $("#txtEmail");
    form.validate();

    $("#btnCreate").click(function () {

        if (form.valid()) {

            var data = {
                email: email.val()
            };

            $.ajax(
                {
                    type: "POST",
                    url: "/Contacts/Create",
                    data: data,
                    datatype: "json",
                    cache: false,
                    success: function (result) {

                        if (result === "success") {
                            alert("Contact added correctly");
                            email.val("");
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