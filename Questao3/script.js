 

$("#botaoEnviarCodigo").attr("disabled", true);


$('#cpf').mask('000.000.000-00', { reverse: true });

$("#botaoAvancar").click(function () {
    var prosseguir = true;

    var cpf = $('#cpf').val();
    var password = $('#password').val();
    
    if (cpf == '') {
        $('#cpf').addClass('is-invalid');
        toastr.error("O campo CPF deve ser preenchido.");
        prosseguir = false;
    }
    else {
        $('#cpf').removeClass('is-invalid');
    }

    if (password == '') {
        $('#password').addClass('is-invalid');
        toastr.error("O campo Senha deve ser preenchido.");
        prosseguir = false;
    }
    else {
        $('#password').removeClass('is-invalid');
    }

    if (prosseguir) {
        showProgressMessage();
    }
});


