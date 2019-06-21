function initProcessData(input) {    
    if (input===null) alert('Texto de entrada inválido')
    initAddressData(input);

}
function log_info(text) {
    console.log(text);
    if (document) {
        document.querySelector('#error').innerText = '';
        document.querySelector('#output').innerText += '';
        document.querySelector('#output').innerText += text + '\n';
    }
}

function initAddressData(dataArray) {
    $.ajax({
        type: "POST",
        url: 'Home/GetData',
        data: {
            dataAux: dataArray,
        }
    }).done(function (msg) {
        log_info(msg);
    }).error(function (msg) {
        log_info(msg);
    });
}