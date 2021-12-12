let removeRowClass = document.getElementByClassName("table-remove");

removeRowClass.click(function () {
    $(this).parents('tr').detach();
});