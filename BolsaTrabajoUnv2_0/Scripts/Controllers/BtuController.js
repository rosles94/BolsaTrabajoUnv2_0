/// <reference path="../Models/BtuModel.js"/>
/// <reference path="../global.js"/>
(function () {
    var app = angular.module('BtuWeb', []);
    app.controller('BtuController', ['$scope', function ($scope) {

        var self = this;
        let existeEmpresa = "";        
        let listEstados = "";
        let listMunicipios = "";
        let listTipoPersona = "";
        let listMedioContacto = "";


        //Funciones Vista Registrar Empresas

        this.GlobalInfoPer = () => {

            if (self.RazonSocial !== undefined && self.NombreComercial !== undefined && self.TipoPersona !== undefined && self.Actividad !== undefined && self.CodigoPost !== undefined &&
                self.Estado !== undefined && self.Municipio !== undefined && self.Colonia !== undefined && self.Domicilio != undefined &&
                self.RazonSocial !== '' && self.NombreComercial !== '' && self.TipoPersona !== '' && self.Actividad !== '' && self.CodigoPost !== '' &&
                self.Estado !== '' && self.Municipio !== '' && self.Colonia !== '' && self.Domicilio !== '') {
                $("#infemp1").show();
                $("#infemp2").hide();
                $("#globalInfoemp").css('background-color', 'green');
            }
            else {
                $("#infemp1").hide();
                $("#infemp2").show();
                $("#globalInfoemp").css('background-color', 'yellow');
            }
        };

        this.GlobalDatosContacto = () => {            
            if (self.PersonaContacto !== undefined && self.Cargo !== undefined && self.TelOficina !== undefined && self.Celular !== undefined && self.Email !== undefined && self.MedioContacto !== undefined &&
                self.PersonaContacto !== '' && self.Cargo !== '' && self.TelOficina !== '' && self.Celular !== '' && self.Email !== '' && self.MedioContacto !== '') {
                $("#datcont1").show();
                $("#datcont2").hide();
                $("#globalDatosCont").css('background-color', 'green');
            }
            else {
                $("#datcont1").hide();
                $("#datcont2").show();
                $("#globalDatosCont").css('background-color', 'yellow');
            }
        };

        this.GlobalDatosSesion = () => {
            if (self.Usuario !== undefined && self.Contrasena !== undefined && self.Contrasena2 !== undefined &&
                self.Usuario !== '' && self.Contrasena !== '' && self.Contrasena2 !== '') {
                $("#datossesion1").show();
                $("#datossesion2").hide();
                $("#globalSesion").css('background-color', 'green');
            }
            else {
                $("#datossesion1").hide();
                $("#datossesion2").show();
                $("#globalSesion").css('background-color', 'yellow');
            }
        };

        this.BuscarEmpresa = () => {    
            btuContext.BuscarEmpresa(self.RfcBuscarEmpresa, function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        existeEmpresa = btuContext.listDatosExistEmpr[0].Existe;
                        if (existeEmpresa !== "2") {
                            self.RazonSocial = "";
                            self.NombreComercial = "";
                            self.Actividad = "";
                            self.CodigoPost = "";
                            self.Estado = "";
                            self.Municipio = "";
                            self.Colonia = "";
                            self.Domicilio = "";
                            self.PersonaContacto = "";
                            self.Cargo = "";
                            self.TelOficina = "";
                            self.Celular = "";
                            self.Email = "";
                            self.MedioContacto = "";
                            self.Contrasena = "";
                            self.TipoPersona = "";
                            self.Usuario = self.RfcBuscarEmpresa;
                            $('#buscarRfc').show();                            
                            $("#globalInfoemp").css('background-color', 'yellow');
                            $("#globalDatosCont").css('background-color', 'yellow');
                            $("#globalSesion").css('background-color', 'yellow');
                            $("#formularioRegistro").show();
                            $("#usuarioEmpresa").prop("disabled", true);
                            alert("La empresa no existe, complete el siguiente formulario para registrarla");
                        }
                        else
                            alert("La empresa ya ha sido registrada, comuniquese con el personal de BTU para más detalles");
                        break;
                    case "notgp":
                        alert(resp.MensajeError);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
                ComboEstados();
                TipoPersona();
                ComboMedioContacto();
            });
            //$('#buscandoEmpresa').show();
            //if (self.RfcBuscarEmpresa !== "" && self.RfcBuscarEmpresa !== undefined) {
                
            //}
            //else {
            //    alert("Introduzca un RFC");
            //    //$('#buscandoEmpresa').modal("hide");
            //    $('#buscandoEmpresa').hide();
            //}
        };

        this.RegistrarDatosEmpresa = () => {
            if (self.Contrasena2 === self.Contrasena) {
                btuContext.RegistrarDatosEmpresa(self.RazonSocial, self.NombreComercial, self.Actividad, self.CodigoPost, self.Estado, self.Municipio, self.Colonia, self.Domicilio, self.Usuario,
                    self.PersonaContacto, self.Cargo, self.TelOficina, self.Celular, self.Email, self.MedioContacto, self.Contrasena, self.TipoPersona, function (resp) {
                        switch (resp.ressult) {
                            case "tgp":
                                alert("Los datos se han guardado correctamente");
                                break;
                            case "notgp":
                                alert(resp.MensajeError);
                                break;
                            default:
                                break;
                        }
                        $scope.$apply();
                    });
            }
            else
                alert("Las contraseñas no coinciden");
        };

        var TipoPersona = () => {
            btuContext.ComboTipoPersona(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listTipoPersona = btuContext.listTipoPersona;
                        break;
                    case "notgp":
                        alert(resp.MensajeError);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        }; 
        
        var ComboMedioContacto = () => {
            btuContext.ComboMedioContacto(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listMedioContacto = btuContext.listMedioContacto;
                        break;
                    case "notgp":
                        alert(resp.MensajeError);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        //Funciones Vista DatosCandidatos

        this.CargarDatosPrincipales = () => {
            ComboEstados();
        };

        this.GuardarInformacionCandidato = () => {
            btuContext.GuardarInformacionCandidato(self.Matricula, self.NombreCandidato, self.ApePatCandidato, self.ApeMatCandidato, self.FecNac, self.Estado,
                self.Municipio, self.Domicilio, self.TelCel, self.TelAd, self.Email, self.AreaInt, self.ObjPersonal, function (resp) {
                switch (resp.ressult) {
                    case "tgp":                        
                        break;
                    case "notgp":
                        alert(resp.MensajeError);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        this.GuardarEstudiosAcademicos = () => {
            btuContext.GuardarEstudiosAcademicos(self.GradoEst, self.NombEsc, self.Carrera, self.AreaConoc, self.FechaIni, self.FechaFin, function (resp) {
                    switch (resp.ressult) {
                        case "tgp":
                            break;
                        case "notgp":
                            alert(resp.MensajeError);
                            break;
                        default:
                            break;
                    }
                    $scope.$apply();
                });
        };



        //Funciones para cargar combos compartidos
        var ComboEstados = () => {
            btuContext.ComboEstados(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listEstados = btuContext.listEstados;
                        break;
                    case "notgp":
                        alert(resp.MensajeError);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        this.ComboMunicipios = () => {
            btuContext.ComboMunicipios(self.Estado, function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listMunicipios = btuContext.listMunicipios;
                        break;
                    case "notgp":
                        alert(resp.MensajeError);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };
    }]);
})();