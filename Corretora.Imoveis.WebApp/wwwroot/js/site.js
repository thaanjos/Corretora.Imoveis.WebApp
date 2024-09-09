//const mascaraMoeda = (input, inputAspFor) => {
//    let value = input.value;

//     Remove any non-digit character except for the decimal point
//    value = value.replace(/[^\d,.]/g, '');

//     Replace comma by period for decimal
//    value = value.replace(',', '.');

//     Convert to a number and format as currency
//    let numberValue = parseFloat(value);
//    if (isNaN(numberValue)) {
//        input.value = '';
//        return;
//    }

//     Format the number as currency
//    let formattedValue = new Intl.NumberFormat('pt-BR', {
//        style: 'currency',
//        currency: 'BRL'
//    }).format(numberValue);

//     Set the formatted value back to the input
//    input.value = formattedValue;

//    var valueSemFormatacao = `${formattedValue.replace('/R$ /g', '').replace(',', '.')}`;
//    $(`#${inputAspFor}`).val(valueSemFormatacao);
//}

//function onReplace(value, valueTo, isAllReplace) {
//    var str = "";
//    if (isAllReplace) {
//        str = value.replace(/`${value}`/g, `${valueTo}`);
//    } else {
//        str = value.replace(`${value}`, `${valueTo}`);  
//    }
//    return str;
//}

//document.getElementById('formattedInput').addEventListener('input', function (e) {
//    var value = e.target.value;
//    value = value.replace(/[^0-9.]/g, ''); // Remove caracteres não numéricos, exceto o ponto
//    if (value) {
//        var parts = value.split('.');
//        parts[0] = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ','); // Adiciona vírgulas como separadores de milhar
//        if (parts.length > 1) {
//            parts[1] = parts[1].substring(0, 2); // Limita a parte decimal a duas casas
//        }
//        value = parts.join('.');
//    }
//    e.target.value = value;
//});


function onClickCarregarImagens(e) {


    $('#btnCarregarImagens').click();
}


function onChangeImagens(e) {

    var qtdAnexos = e.files.length;


    $("#lblQtdAnexos").text(`( ${qtdAnexos} )`);
}


function onGotToBack() {
    history.back();
}
