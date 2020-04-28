$(document).ready(function () {
    //alert("Por favor, introduzca su RFC");
    //$("#editarDatos").hide();
    //$("#crearDatos").hide();
    //$("#datosEmpresa").hide();
    //$("#logotipoEmpresaUpload").hide();

    $('#informacionEmpresa').on('click', function (e) {
        e.preventDefault();
        $("#datosCotacto-tab").tab('show');
    });

    $('#datosContacto').on('click', function (e) {
        e.preventDefault();
        $("#infoLogin-tab").tab('show');
    });
    $('#datosContactoRegresar').on('click', function (e) {
        e.preventDefault();
        $("#infoEmpresa-tab").tab('show');
    });
    $('#infoLogRegresar').on('click', function (e) {
        e.preventDefault();
        $("#datosCotacto-tab").tab('show');
    });

});