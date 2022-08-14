$(".largeModal").click(function () {
    $("#ModalDialog").css("width", "80%");
});
$(".smallModal").click(function () {
    $("#ModalDialog").css("width", "40%");
});

$("#btnCreateProduct").click(function () {
    $("#ModalContent").load('/Administration/Shop/Products/Create');
    $("#MainModal").modal('show');
});
function CreateGroup(parentId=null) {
    $("#ModalContent").load('/Administration/Shop/ProductGroups/Create?parentId='+parentId);
    $("#MainModal").modal('show');
}

function GetProductForEdit(productId) {
    $("#ModalContent").load('/Administration/Shop/Products/Edit?productId=' + productId);
    $("#MainModal").modal('show');
}


function GetProductForDelete(productId, productTitle) {
    $("#ModalContent").load('/Administration/Shop/Products/Delete?productId=' + productId);
    $("#MainModal").modal('show');
    $("#productTitle").text(productTitle);
}
$(document).on("submit", 'form[data-ajax="true"]',
    function (e) {
        var form = $(this);
        var isValidForm = form.valid();
        if (isValidForm) {
            e.preventDefault();
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
        }
        return false;
    });

function CallBackHandler(data, action, form) {
    switch (action) {
        case "Message":
            alert(data.Message);
            break;
        case "Refresh":
            if (data.isSucceeded == true) {
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

$("#IndexGroup").change(function () {
    $("#IndexPrimaryGroup").empty();
    $("#IndexSecondaryGroup").empty();
    $.getJSON("/Administration/Shop/Products/GetSubGroups?id=" + $("#IndexGroup :selected").val(),
        function (data) {

            $.each(data,
                function () {
                    $("#IndexPrimaryGroup").append('<option value=' + this.value + '>' + this.text + '</option>');

                });
        });
});
$("#IndexPrimaryGroup").change(function () {
    $("#IndexSecondaryGroup").empty();
    $.getJSON("/Administration/Shop/Products/GetSubGroups?id=" + $("#IndexPrimaryGroup :selected").val(),
        function (data) {

            $.each(data,
                function () {
                    $("#IndexSecondaryGroup").append('<option value=' + this.value + '>' + this.text + '</option>');

                });
        });
});