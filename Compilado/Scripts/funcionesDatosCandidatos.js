$(document).ready(function () {
    //$("#btnGuardarDatos").hide();
    //$("#btnEditarDatos").hide();


    

    $('#btnDatosContactoRegrear').on('click', function (e) {
        e.preventDefault();
        $("#infoPersonal-tab").tab('show');
    });

    $('#btnDatosContactoContinuar').on('click', function (e) {
        e.preventDefault();
        $("#softIdio-tab").tab('show');
    });

    $('#btnInfoSotIdioRegresar').on('click', function (e) {
        e.preventDefault();
        $("#estuAcad-tab").tab('show');
    });

    $('#btninfoSoftIdioContinuar').on('click', function (e) {
        e.preventDefault();
        $("#expProf-tab").tab('show');
    });

    $('#btninfoExpProfRegrear').on('click', function (e) {
        e.preventDefault();
        $("#softIdio-tab").tab('show');
    });

    $('#btninfoExpProfContinuar').on('click', function (e) {
        e.preventDefault();
        $("#curTall-tab").tab('show');
    });

    $('#btninfoCursosRegresar').on('click', function (e) {
        e.preventDefault();
        $("#expProf-tab").tab('show');
    });    

});