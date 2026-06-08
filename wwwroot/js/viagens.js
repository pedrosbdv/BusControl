function abrirModalViagem() {
    document.getElementById("modalViagens").classList.add("show");
}

function fecharModalViagens() {
    document.getElementById("modalViagens").classList.remove("show");
}

function cadastrarViagens() {

    
    let destino = $('#destino').val().trim();
    let motorista = $("select[name='motoristaId']").val();
    let veiculo = $("select[name='veiculoId']").val();
    
    let quantidadePassageiros = $("input[name='quantidadePassageiros']").val().trim();
    let quantidadeParadas = $("input[name='quantidadeParadas']").val().trim();
    let valorViagem = $("input[name='valorViagem']").val().trim();



    if (destino === "" || motorista === "" || veiculo === "" || quantidadePassageiros === "" || quantidadeParadas == "" || valorViagem == "") {

        Swal.fire({
            icon: 'warning',
            title: 'Campos obrigatórios',
            text: 'Preencha todos os campos antes de continuar.'
        });

        return;
    }

    

    Swal.fire({
        title: 'Cadastrar viagem?',
        text: 'Deseja realmente cadastrar a viagem?',
        icon: 'question',
        showCancelButton: true,
        confirmButtonText: 'Sim, cadastrar',
        cancelButtonText: 'Cancelar'
    }).then((result) => {

        if (result.isConfirmed) {

            $.ajax({
                url: '/Viagens/CadastrarViagem',
                type: 'POST',
                data: $('#formViagens').serialize(),

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

                            fecharModalViagens();

                            $("#formViagens")[0].reset();

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
                        text: 'Erro ao cadastrar viagem.'
                    });

                }

            });

        }

    });

}

function excluirViagen(id) {

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
                    url: '/Viagens/ExcluirViagem',
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
