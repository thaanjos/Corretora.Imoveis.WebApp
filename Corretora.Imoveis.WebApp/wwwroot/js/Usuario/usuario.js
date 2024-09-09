$(document).ready(() => {



});

function onClickSalvar(e) {

    var model = new Object();
    model.Anexos = new FormData();

    model.Id_CadastroUsuario = +$("#txtCodigo").val();
    model.Nome = $("#txtNome").val();
    model.normalizedNome = $("#txtnormalizedNome").val();
    model.Password = $("#txtSenha").val();   
    model.Celular = $("#txtCelular").val();
    model.Email = $("#txtEmail").val();


    var inputFiles = document.getElementById('btnCarregarImagens');


    if (inputFiles.files.length > 0) {
        for (var indice = 0; indice < inputFiles.files.length; indice++) {
            model.Anexos.append('files', inputFiles.files.item(indice));
        }
    }


    util.ajax.post("../Usuario/Salvarusuario", model,
        (data) => {
            console.log(data);
        },

        (error) => {
            console.log(error);
        });
}