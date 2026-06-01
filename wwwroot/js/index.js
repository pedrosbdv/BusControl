

    
    $(document).ready(function () {

        $('.btnExcluir').click(function () {

            let id = $(this).data('id');

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
                        url: '/Viagens/ExcluirConfirmado',
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

        });

    });
