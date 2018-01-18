"use restrict";

$(function () {

    function loadContacts() {

        $.ajax(
            {
                method: "GET",
                url: "/Contacts/GetContacts",
                cache: false,
                datatype: "json",
                success: function (result) {

                    fillData(result);

                },
                error: function (jqXhr, textStatus, errorThrown) {
                    console.log(jqXhr);
                    console.log(textStatus);
                    console.log(errorThrown);
                }
            });
    }

    function fillData(contacts) {

        $("#tblContacts").DataTable(
            {
                data: contacts,
                order: [],
                columns:
                    [
                        { title: "Email", data: "Email" },
                        {
                            title: "Actions",
                            data: "Id",
                            className: "center",
                            render: function (data, type, row, meta) {
                                if (type === "display") {
                                    console.log(data);
                                    console.log(type);
                                    console.log(row);
                                    console.log(meta);
                                }
                                return type === "display" ?
                                    '<a href="/Contacts/Edit/'+data+'">Edit</a>'
                                    : data;
                            }
                        }
                    ]
            });
    }

    loadContacts();
});