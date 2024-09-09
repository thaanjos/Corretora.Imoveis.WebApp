$(document).ready(() => {



});



function onClickSalvar(e) {

    var model = new Object();
  
    model.IdConato = $("#txtCodigo").val();
    model.IdImovel = +$("#txtCodigo").val();
    model.Nome = $("#txtNome").val();
    model.Celular = $("#txtCelular").val();
    model.Email = $("#txtEmail").val();
    model.Messagem = $("#txtMessagem").val();
  


    util.ajax.post("../Contato/SalvarContato", model,
        (data) => {
            console.log(data);
        },

        (error) => {
            console.log(error);
        });
}