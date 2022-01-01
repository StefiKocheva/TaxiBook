function DeleteRowFunction(cell) {
    var tableRow = cell.parentNode.parentNode;
    tableRow.parentNode.removeChild(tableRow);
};
