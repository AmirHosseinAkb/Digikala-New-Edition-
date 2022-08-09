$("#btnCreateProduct").click(function () {
    $("#ModalContent").load('/Administration/Shop/Products/Create');
    $("#MainModal").modal('show');
});