function copyFunction(value, event) {
    var input = document.createElement('input');
    document.body.appendChild(input);
    input.value = value;
    input.select();

    document.execCommand('copy', false);

    input.remove();

    alert('Вие копирахте успешно.');
};
