$("#btnCreateProduct").click(function () {
    $("#ModalContent").load('/Administration/Shop/Products/Create');
    $("#MainModal").modal('show');
});

$(document).on("submit", 'form[data-ajax="true"]',
    function (e) {
        e.preventDefault();
        var form = $(this);
        const method = form.attr("method").toLocaleLowerCase();
        const url = form.attr("action");
        var action = form.attr("data-action");

        if (method === "get") {
            const data = form.serializeArray();
            $.get(url,
                data,
                function (data) {
                    CallBackHandler(data, action, form);
                });
        } else {
            var formData = new FormData(this);
            $.ajax({
                url: url,
                type: "post",
                data: formData,
                enctype: "multipart/form-data",
                dataType: "json",
                processData: false,
                contentType: false,
                beforeSend: function (xhr) { xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val()); },
                success: function (data) {
                    CallBackHandler(data, action, form);
                },
                error: function (data) {
                    alert("خطایی رخ داده است. لطفا با مدیر سیستم تماس بگیرید.");
                }
            });
        }
        return false;
    });

function CallBackHandler(data, action, form) {
    switch (action) {
        case "Message":
            alert(data.Message);
            break;
        case "Refresh":
            if (data.IsSucceeded) {
                window.location.reload();
            } else {
                alert(data.message);
            }
            break;
        case "RefereshList":
            {
                hideModal();
                const refereshUrl = form.attr("data-refereshurl");
                const refereshDiv = form.attr("data-refereshdiv");
                get(refereshUrl, refereshDiv);
            }
            break;
        case "setValue":
            {
                const element = form.data("element");
                $(`#${element}`).html(data);
            }
            break;
        default:
    }
}

