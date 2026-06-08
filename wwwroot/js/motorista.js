function abrirModalMotorista() {
    document
        .getElementById("modalMotorista")
        .classList.add("show");
}

function fecharModalMotorista() {
    document
        .getElementById("modalMotorista")
        .classList.remove("show");
}

function cadastrarMotorista() {

    let nome = $("input[name='Nome']").val().trim();
    let email = $("input[name='Email']").val().trim();
    let dataNascimento = $("input[name='DataNascimento']").val().trim();
    let status = $("select[name='Status']").val();

    

    if (nome === "" || email === "" || dataNascimento === "" || status === "") {

        Swal.fire({
            icon: 'warning',
            title: 'Campos obrigatórios',
            text: 'Preencha todos os campos antes de continuar.'
        });

        return;
    }

    

    Swal.fire({
        title: 'Cadastrar motorista?',
        text: 'Deseja realmente cadastrar este motorista?',
        icon: 'question',
        showCancelButton: true,
        confirmButtonText: 'Sim, cadastrar',
        cancelButtonText: 'Cancelar'
    }).then((result) => {

        if (result.isConfirmed) {

            $.ajax({
                url: '/Motorista/CadastrarMotorista',
                type: 'POST',
                data: $("#formMotorista").serialize(),

                beforeSend: function () {

                    Swal.fire({
                        title: 'Salvando...',
                        text: 'Aguarde',
                        allowOutsideClick: false,
                        didOpen: () => {
                            Swal.showLoading();
                        }
                    });

                },

                success: function (response) {

                    if (response.sucesso) {
                        
                        Swal.fire({
                            icon: 'success',
                            title: 'Sucesso!',
                            text: response.mensagem
                        }).then(() => {

                            fecharModalMotorista();

                            $("#formMotorista")[0].reset();

                            location.reload();

                        });

                    } else {

                        Swal.fire({
                            icon: 'error',
                            title: 'Erro',
                            text: response.mensagem
                        });

                    }

                },

                error: function () {
                    alert('aqui')
                    Swal.fire({
                        icon: 'error',
                        title: 'Erro',
                        text: 'Erro ao cadastrar motorista.'
                    });

                }

            });

        }

    });

}

function ExcluirMotorista(id) {
    Swal.fire({
        title: 'Deseja excluir?',
        text: 'Esta ação não poderá ser desfeita.',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Sim',
        cancelButtonText: 'Não'
    }).then((result) => {

        if (result.isConfirmed) {

            $.ajax({
                url: '/Motorista/Excluir',
                type: 'POST',
                data: {
                    id: id
                },

                success: function (response) {

                    if (response.sucesso) {

                        Swal.fire({
                            icon: 'success',
                            title: 'Sucesso',
                            text: response.mensagem
                        }).then(() => {

                            location.reload();

                        });

                    } else {

                        Swal.fire({
                            icon: 'error',
                            title: 'Erro',
                            text: response.mensagem
                        });

                    }

                },

                error: function () {

                    Swal.fire({
                        icon: 'error',
                        title: 'Erro',
                        text: 'Erro ao excluir o registro.'
                    });

                }
            });

        }

    });
}