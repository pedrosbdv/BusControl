function abrirModalVeiculo() {
    document.getElementById("modalMotorista").classList.add("show");   
}

function fecharModalVeiculo() {
    document.getElementById("modalMotorista").classList.remove("show");
}

function cadastrarVeiculo() {

    let placaVeiculo = $("input[name='placaVeiculo']").val().trim();
    let nomeVeiculo = $("input[name='nomeVeiculo']").val().trim();
    let marcaVeiculo = $("input[name='marcaVeiculo']").val().trim();
    let Categoria = $("select[name='Categoria']").val();



    if (placaVeiculo === "" || nomeVeiculo === "" || marcaVeiculo === "" || Categoria === "") {

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
                url: '/Veiculo/CadastrarVeiculo',
                type: 'POST',
                data: $("#formVeiculo").serialize(),

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

                            fecharModalVeiculo();

                            $("#formVeiculo")[0].reset();

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
                        text: 'Erro ao cadastrar veiculo.'
                    });

                }

            });

        }

    });

}

function ExcluirVeiculo(id) {
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
                url: '/Veiculo/ExcluirVeiculo',
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