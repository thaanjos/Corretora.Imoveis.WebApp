$(document).ready(() => {
  

});


$(document).ready(() => {
    $("#btnPesquisarImovel").on('click', buscarImovelClick);

    if (_excluded)
        $("#btnPesquisarImovel").click();

});


function buscarImovelClick(e) {
    var model = new Object();
    model.Tipo = $("#cmbConsultarTipo").val();
    //model.ValorDe = +$("#txtValorImovelFiltroImovel").val();
    //model.ValorAte = +$("#txtValorImovelFiltroImovel").val();

    util.ajax.post("../Imovel/Index", model, buscarImovelClickSuccesso, buscarImovelClickError);
}

function buscarImovelClickSuccesso(HTML) {

    if (HTML) {
        $("body").empty();
        $("body").html(HTML);
        
       
    } else {
        alert("Não foram encontrados registros para sua busca .");
    }


}
function buscarImovelClickError(error) {

    alert("Erro ao buscar Imovel !");
}



function onClickCarregarImagens(e) {


    $('#btnCarregarImagens').click();
}


function onChangeImagens(e) {

    var qtdAnexos = e.files.length;


    $("#lblQtdAnexos").text(`( ${qtdAnexos} )`);
}


function onClickSalvar(e) {

    var model = new Object();
    model.Anexos = new FormData();

    model.IdImovel = +$("#txtCodigo").val();
    model.Descricao = $("#txtDescricao").val();
    model.Tipo = $("#txtTipo").val();
    model.DataPlubicacao = $("#textDataPlubicacao").val();
    model.ValorImovel = $("#txtValorImovel").val();
    model.ValorEstimadoDocumentacao = $("#txtValorEstimadoDocumentacao").val();
    model.AceitaFinanciamento = $("#txtAceitaFinanciamento").val();
    model.Observacao = $("#txtObservacao").val();
    model.Quarto = $("#txtQuarto").val();
    model.Banheiro = $("#txtBanheiro").val();
    model.Garagem = $("#txtGaragem").val();
    model.AreaUtil = $("#txtAreaUtil").val();
    model.Cep = $("#txtCep").val();
    model.Logadouro = $("#txtLogadouro").val();
    model.Numero = $("#txtNumero").val();
    model.Bairro = $("#txtBairro").val();
    model.Cidade = $("#txtCidade").val();
    model.UF = $("#txtUF").val();


    var inputFiles = document.getElementById('btnCarregarImagens');


    if (inputFiles.files.length > 0) {
        for (var indice = 0; indice < inputFiles.files.length; indice++) {
            model.Anexos.append('files', inputFiles.files.item(indice));
        }
    }


    util.ajax.post("../Imovel/Salvarimovel", model,
        (data) => {
            console.log(data);
        },

        (error) => {
            console.log(error);
        });
}

$("#meuDinheiro").maskMoney();

   


