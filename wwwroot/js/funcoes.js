$(document).ready(function () {

    $('.somenteNumero').on('input', function () {


        this.value = this.value.replace(/\D/g, '');

    });

    $('.dinheiro').maskMoney({
        allowNegative: false,
        thousands: '.',
        decimal: ',',
        affixesStay: true
    });

});

