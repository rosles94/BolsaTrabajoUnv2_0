$(document).ready(function () {


    //alert("Por favor, introduzca su RFC");
    //$("#editarDatos").hide();
    //$("#crearDatos").hide();
    //$("#datosEmpresa").hide();
    //$("#logotipoEmpresaUpload").hide();

    $('#informacionEmpresa').on('click', function (e) {
        e.preventDefault();
        $("#datosCont").tab('show');
    });

    $('#datosContacto').on('click', function (e) {
        e.preventDefault();
        $("#infoLog").tab('show');
    });
    $('#datosContactoRegresar').on('click', function (e) {
        e.preventDefault();
        $("#tabInfoEmpresa").tab('show');
    });
    $('#infoLogRegresar').on('click', function (e) {
        e.preventDefault();
        $("#datosCont").tab('show');
    });

});