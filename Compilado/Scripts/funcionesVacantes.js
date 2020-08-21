$(document).ready(function () {

    $('#informacionVacante').on('click', function (e) {
        e.preventDefault();
        $("#infoEntre-tab").tab('show');
    });
    $('#datosContactoRegresar').on('click', function (e) {
        e.preventDefault();
        $("#infoVacan-tab").tab('show');
    });
}); 