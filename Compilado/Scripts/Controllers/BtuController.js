/// <reference path="../Models/BtuModel.js"/>
/// <reference path="../global.js"/>

(function () {
    var app = angular.module('BtuWeb', []);
    app.controller('BtuController', ['$scope', '$compile', function ($scope, $compile) {

        var self = this;
        let existeEmpresa = "";
        let listEstados = "";
        let listMunicipios = "";
        let listTipoPersona = "";
        let listMedioContacto = "";
        let listCarreras = "";
        let listGradoEstudios = "";
        let listAreaConocimiento = "";
        let listNivelSoftware = "";
        let listNivelIdioma = "";
        let listTipoCurso = "";
        let listSesionUnach = "";
        let listDatosRegistroUnach = "";
        let listEstAcadGuardados = "";
        let listSoftware = "";
        let listIdioma = "";
        let listExperienciaProf = "";
        let listCursoTaller = "";
        let idCarreraPrincipal = "";
        let listDatosPanel = "";
        let listSesionEmpresa = "";
        let listDatosPanelEmpresa = "";
        let listDatosEmpresa = "";
        let listGenero = "";
        let listEdoCivil = "";
        let listTipoSalario = "";
        let listIdiomaExt = "";
        let listTipoVacante = "";
        let listVacantesEmpresa = "";
        let listDatosVacante = "";
        let listInteresadosVac = "";
        let listVacantesApliEmpresa = "";
        let listVacRegEmp = "";
        let listCandDispo = "";
        let idVacanteCandidato = "";
        let idCandInteresado = "";
        let correoCandidato = "";
        let nombreVacanteInteresado = "";
        let listTotalVac = "";
        let listStatusCand = "";
        let idCandidato = "";
        let listStatusAgrupados = "";
        let listVacantesXstatus = "";
        let statusVacanteCand = "";
        let idVacanteSeleccionada = "";
        let eMailCandidato = "";
        let eMailEmpresa = "";
        let nombreCandidato = "";
        let idVacCand = "";
        let listEmpresas_Status = "";
        let listCandidatos_Status = "";
        let listEmpresasRegistradas = "";
        let listaCandidatosRegistrados = "";
        let statusEmpresa = "";
        let rfcEmpresa = "";
        let motivoEmpresa = "";
        let matriculaCand = "";
        let listStatusVacanCand = "";
        let listDatosSesion = "";
        let statusCandidato = "";
        let listVacantesAdministrador = "";
        let listInteresadosVacAdmin = "";
        let listVacantesVencidas = "";
        let listCorreosCandidatos = "";

        let administrador = false;
        let datosPersonales = false;
        let datosAcademicos = false;
        let datosExpProfesional = false;
        let existeImagenPerfilCv = false;
        let datosPerfilVacante = false;
        let datosInfoEntrevista = false;


        //Funciones Vista Registrar Empresas

        this.CargarDatosPrincipalesEmpresa = () => {
            $('#buscandoEmpresa').show();
            ComboEstados();
            TipoPersona();
            ComboMedioContacto();
            CargarDatosEmpresa();
        };

        var CargarDatosEmpresa = () => {
            btuContext.ObtenerDatosEmpresa(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listDatosEmpresa = btuContext.listDatosEmpresa;
                        if (self.listDatosEmpresa.length > 0) {
                            self.RfcBuscarEmpresa = self.listDatosEmpresa[0].Rfc;
                            self.RazonSocial = self.listDatosEmpresa[0].Razon_Social;
                            self.NombreComercial = self.listDatosEmpresa[0].Nombre_Comercial;
                            self.TipoPersona = self.listDatosEmpresa[0].Tipo_Persona;
                            self.Actividad = self.listDatosEmpresa[0].Actividad;
                            self.CodigoPost = self.listDatosEmpresa[0].Codigo_Postal;
                            self.Estado = self.listDatosEmpresa[0].Estado;
                            comboMunicipios();
                            self.Municipio = self.listDatosEmpresa[0].Ciudad;
                            self.Colonia = self.listDatosEmpresa[0].Colonia;
                            self.Domicilio = self.listDatosEmpresa[0].Domicilio;
                            self.PersonaContacto = self.listDatosEmpresa[0].Contacto;
                            self.Cargo = self.listDatosEmpresa[0].Contacto_Cargo;
                            self.TelOficina = self.listDatosEmpresa[0].Telefono;
                            self.Celular = self.listDatosEmpresa[0].Celular;
                            self.Email = self.listDatosEmpresa[0].Email;
                            self.MedioContacto = self.listDatosEmpresa[0].Medio_Contacto;
                            self.Usuario = self.listDatosEmpresa[0].Rfc;
                            self.Contrasena = self.listDatosEmpresa[0].Contrasena;
                            self.Contrasena2 = self.listDatosEmpresa[0].Contrasena;
                            $("#formularioRegistro").show();
                            $("#razonSocial").prop('disabled', true);
                            $("#NombreComercial").prop('disabled', true);
                            $("#TipoPersona").prop('disabled', true);
                            $("#Actividad").prop('disabled', true);
                            $("#CodigoPost").prop('disabled', true);
                            $("#Estado").prop('disabled', true);
                            $("#Municipio").prop('disabled', true);
                            $("#Colonia").prop('disabled', true);
                            $("#Domicilio").prop('disabled', true);
                            $("#RfcEmpresa").prop('disabled', true);
                            $("#usuarioEmpresa").prop('disabled', true);                            
                            $("#globalInfoemp").css('background-color', 'green');
                            $("#globalDatosCont").css('background-color', 'green');
                            $("#globalSesion").css('background-color', 'green');
                            $("#guardarEmpresa").hide();
                            $("#editarEmpresa").show();
                            $("#regresarPanelEmpresa").show();
                        }
                        else {                            
                            $("#buscarRfc").show();
                            $("#cargandoEmpresa").hide();
                            $("#regresarPanelEmpresa").hide();
                            $('#avisoPrivacidad').modal('show');                            
                        }                            
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
                $('#buscandoEmpresa').hide();
            });
        };

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
            $('#buscandoEmpresa').modal('show');
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
                            $("#RfcEmpresa").prop("disabled", true);
                            $("#guardarEmpresa").show();
                            $("#editarEmpresa").hide();
                            alert("La empresa no existe, complete el siguiente formulario para registrarla.");
                        }
                        else
                            alert("La empresa ya ha sido registrada, comuniquese con el personal de BTU para más detalles.");
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $('#buscandoEmpresa').modal('toggle');
                $scope.$apply();
            });
        };

        this.RegistrarDatosEmpresa = () => {            
            if (self.Contrasena2 === self.Contrasena) {
                $('#buscandoEmpresa').modal('show');
                btuContext.RegistrarDatosEmpresa(self.RazonSocial, self.NombreComercial, self.Actividad, self.CodigoPost, self.Estado, self.Municipio, self.Colonia, self.Domicilio, self.Usuario,
                    self.PersonaContacto, self.Cargo, self.TelOficina, self.Celular, self.Email, self.MedioContacto, self.Contrasena, self.TipoPersona, function (resp) {
                        switch (resp.ressult) {
                            case "tgp":
                                $('#buscandoEmpresa').modal('toggle');
                                alert("Empresa registrada. \n Su empresa ha sido registrada satisfactoriamente, se le notificará a través del correo electrónico una vez que el personal de Bolsa de Trabajo le haya dado de alta en el sistema, o bien inicie sesión con su usuario y contraseña para saber su estatus. \n Teléfono: 61 13859 Ext 22 y 61 13478. Correo: btu@unach.mx");
                                setTimeout(window.location.assign(urlServer + "Btu/Btu"), 4500);
                                break;
                            case "notgp":
                                $('#buscandoEmpresa').modal('toggle');
                                alert(resp.message);
                                break;
                            default:
                                break;
                        }
                        $scope.$apply();
                    });
            }
            else
                alert("Las contraseñas no coinciden.");
        };

        var TipoPersona = () => {
            btuContext.ComboTipoPersona(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listTipoPersona = btuContext.listTipoPersona;
                        break;
                    case "notgp":
                        alert(resp.message);
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
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        this.EditarDatosEmpresa = () => {
            btuContext.EditarDatosEmpresa(self.RazonSocial, self.NombreComercial, self.Actividad, self.CodigoPost, self.Estado, self.Municipio, self.Colonia, self.Domicilio, self.Usuario,
                self.PersonaContacto, self.Cargo, self.TelOficina, self.Celular, self.Email, self.MedioContacto, self.Contrasena, self.TipoPersona, function (resp) {
                    switch (resp.ressult) {
                        case "tgp":
                            alert("Datos modificados correctamente.");
                            window.location.assign(urlServer + "Btu/PanelEmpresa");
                            break;
                        case "notgp":
                            alert(resp.message);
                            break;
                        default:
                            break;
                    }
                    $scope.$apply();
                });
        }

        this.RegresarPanelEmpresa = () => {
            btuContext.RegresarPanelEmpresa(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        window.location.assign(urlServer + "Btu/PanelEmpresa");
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });            
        };

        this.RechazarAviso = () => {
            window.location.href = "https://btu.unach.mx/Dsia";
            //window.location.assign(urlServer + "Btu");
        };

        this.AceptarAviso = () => {
            alert('Ingrese su RFC para verficar que su empresa aún no haya sido registrada.');
        };
        //Funciones Vista DatosCandidatos

        this.GlobalInfoPersonal = () => {
            let isSexM = $("#radioMale").is(':checked');
            let isSexF = $("#radioFemale").is(':checked');
            let genero = false;
            if (isSexM === true || isSexF === true)
                genero = true;
            if (self.Matricula !== undefined && self.NombreCandidato !== undefined && self.ApePatCandidato !== undefined && self.ApeMatCandidato !== undefined
                && self.FecNac !== undefined && self.Estado !== undefined && self.Municipio !== undefined && self.Domicilio !== undefined && self.TelCel !== undefined
                && self.TelAd !== undefined && self.Email !== undefined && self.AreaInt !== undefined && self.ObjPersonal !== undefined
                && self.Matricula !== "" && self.NombreCandidato !== "" && self.ApePatCandidato !== "" && self.ApeMatCandidato !== "" && self.FecNac !== ""
                && self.Estado !== "" && self.Municipio !== "" && self.Domicilio !== "" && self.TelCel !== "" && self.TelAd !== "" && self.Email !== ""
                && self.AreaInt !== "" && self.ObjPersonal !== "" && genero === true) {
                $("#infper1").show();
                $("#infper2").hide();
                $("#globalInfoPer").css('background-color', 'green');
            }
            else {
                $("#infper1").hide();
                $("#infper2").show();
                $("#globalInfoPer").css('background-color', 'yellow');
            }
        };

        this.GlobalInfoAcademica = () => {
            if (datosAcademicos !== false) {
                $("#estuacad1").show();
                $("#estuacad2").hide();
                $("#globalEstuAcd").css('background-color', 'green');
            }
            else {
                if (self.GradoEst !== undefined && self.NombEsc !== undefined && self.Carrera !== undefined && self.AreaConoc !== undefined && self.FechaIniCarrera !== undefined && self.FechaFinCarrera !== undefined &&
                    self.CarreraExt !== undefined && self.GradoEst !== '' && self.NombEsc !== '' && self.Carrera !== '' && self.AreaConoc !== '' && self.FechaIniCarrera !== '' && self.FechaFinCarrera !== '' && self.CarreraExt !== "") {
                    $("#estuacad1").show();
                    $("#estuacad2").hide();
                    $("#globalEstuAcd").css('background-color', 'green');
                }
                else {
                    $("#estuacad1").hide();
                    $("#estuacad2").show();
                    $("#globalEstuAcd").css('background-color', 'yellow');
                }
            }
        };

        this.GlobalExpProf = () => {
            if (datosExpProfesional !== false) {
                $("#expprof1").show();
                $("#expprof2").hide();
                $("#globalExpProf").css('background-color', 'green');
            }
            else {
                if (self.NombreEmpresa !== undefined && self.FechaIniExpProf !== undefined && self.FechaFinExpProf !== undefined && self.DescAct !== undefined && self.ReferenciaTrabajo !== undefined &&
                    self.NombreEmpresa !== '' && self.FechaIniExpProf !== '' && self.FechaFinExpProf !== '' && self.DescAct !== '' && self.ReferenciaTrabajo !== '') {
                    $("#expprof1").show();
                    $("#expprof2").hide();
                    $("#globalExpProf").css('background-color', 'green');
                }
                else {
                    $("#expprof1").hide();
                    $("#expprof2").show();
                    $("#globalExpProf").css('background-color', 'yellow');
                }
            }
        };

        this.GuardarIdCarrera = (id_Elemento, Carrera) => {
            idCarreraPrincipal = id_Elemento;
            self.CarreraPrincipal = Carrera;
        };

        this.EditarPrincipalEstAcad = () => {
            btuContext.EditarPrincipalEstAcad(idCarreraPrincipal, function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        $("#estudiosModal").modal('toggle');
                        self.listEstAcadGuardados = btuContext.listEstAcadGuardados;
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        this.CargarDatosPrincipales = () => {
            let DependenciaAlumno = "";
            let fechaNac = "";
            ComboEstados();
            ComboGradoEstudios();
            ComboCarreras();
            ComboAreaConocimiento();
            ComboNivelSoftware();
            ComboNivelIdioma();
            ComboTipoCurso();
            btuContext.DatosRegistroUnach(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        alert("Si tienes problemas para registrar tus datos intenta cerrar la sesión e ingresar de nuevo.");
                        self.listDatosRegistroUnach = btuContext.listDatosRegistroUnach;
                        self.DescCarrera = self.listDatosRegistroUnach[0].Carrera;
                        self.Matricula = self.listDatosRegistroUnach[0].Matricula;
                        self.NombreCandidato = self.listDatosRegistroUnach[0].Nombre;
                        self.ApePatCandidato = self.listDatosRegistroUnach[0].Paterno;
                        self.ApeMatCandidato = self.listDatosRegistroUnach[0].Materno;
                        fechaNac = self.listDatosRegistroUnach[0].FechaNacimiento;
                        self.Estado = self.listDatosRegistroUnach[0].Estado === "ESTADO" ? "" : self.listDatosRegistroUnach[0].Estado;
                        self.Municipio = self.listDatosRegistroUnach[0].Municipio === "MUNICIPIO" ? "" : self.listDatosRegistroUnach[0].Municipio;
                        self.Domicilio = self.listDatosRegistroUnach[0].Domicilio;
                        self.TelCel = self.listDatosRegistroUnach[0].Celular;
                        self.TelAd = self.listDatosRegistroUnach[0].Telefono;
                        self.Email = self.listDatosRegistroUnach[0].Correo;
                        self.Carrera = self.listDatosRegistroUnach[0].IdCarrera;
                        self.AreaInt = self.listDatosRegistroUnach[0].Intereses === null ? "" : self.listDatosRegistroUnach[0].Intereses;
                        self.ObjPersonal = self.listDatosRegistroUnach[0].Objetivo === null ? "" : self.listDatosRegistroUnach[0].Objetivo;
                        DependenciaAlumno = self.listDatosRegistroUnach[0].Dependencia;
                        if (self.listDatosRegistroUnach[0].Genero !== null && self.listDatosRegistroUnach[0].Genero !== "" && self.listDatosRegistroUnach[0].Genero !== undefined) {
                            if (self.listDatosRegistroUnach[0].Genero === "M")
                                $('#radioMale').prop('checked', true);
                            else
                                $('#radioFemale').prop('checked', true);
                        }
                        if (self.listDatosRegistroUnach[0].Ruta_Foto !== undefined && self.listDatosRegistroUnach[0].Ruta_Foto !== "" && self.listDatosRegistroUnach[0].Ruta_Foto !== null) {
                            $("#imgCadidato").attr("src", self.listDatosRegistroUnach[0].Ruta_Foto);
                            existeImagenPerfilCv = true;
                        }
                        else
                            obtFotoCandidato(self.Matricula, DependenciaAlumno);
                        if (self.Estado !== "ESTADO")
                            comboMunicipios();
                        $("#Matricula").prop("disabled", true);
                        $('#FecNac').val(fechaNac);
                        if (self.listDatosRegistroUnach[0].Registrado === "1") {
                            $("#editarDatosCandidato").show();
                            $("#guardarDatosCandidato").hide();
                            $("#infper1").show();
                            $("#infper2").hide();
                            $("#globalInfoPer").css('background-color', 'green');
                            $("#btnBackPanelCand").show();
                            ObtenerEstududiosAcademicos();
                        }
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        this.GuardarInformacionCandidato = () => {
            let isSexM = $("#radioMale").is(':checked');
            let isSexF = $("#radioFemale").is(':checked');
            let genero = false;
            let sexo = "";

            if (isSexM === true || isSexF === true) {
                genero = true;
                sexo = isSexM === true ? "M" : "F"; // sentencia que devuelve un valor
            }
            if (genero === true) {
                btuContext.GuardarInformacionCandidato(self.Matricula, self.NombreCandidato, self.ApePatCandidato, self.ApeMatCandidato, self.FecNac, self.Estado,
                    self.Municipio, self.Domicilio, self.TelCel, self.TelAd, self.Email, self.AreaInt, self.ObjPersonal, sexo, function (resp) {
                        switch (resp.ressult) {
                            case "tgp":
                                datosPersonales = true;
                                break;
                            case "notgp":
                                alert(resp.message);
                                break;
                            default:
                                break;
                        }
                        $scope.$apply();
                    });
            }
            else
                alert("No se ha seleccionado un sexo");
        };

        this.GuardarEstudiosAcademicos = () => {
            let Carrera = "";
            let Id_Carrera = "";
            let DescGradoEstu = $("#GradoEst option:selected").text();
            let FechaInicio = $("#FechaIniCarrera").val();
            let FechaFin = $("#FechaFinCarrera").val();

            let d1 = new Date(FechaInicio);
            let month = (d1.getMonth() + 1);
            let nuevomes = month >= 10 ? month : '0' + month;
            let day = d1.getDate();
            let year = d1.getFullYear();

            let d2 = new Date(FechaFin);
            let month1 = (d2.getMonth() + 1);
            let nuevomes1 = nuevomes = month1 >= 10 ? month : '0' + month;
            let day1 = d2.getDate();
            let year1 = d2.getFullYear();


            let date1 = day + '/' + nuevomes + '/' + year;
            let date2 = day1 + '/' + nuevomes1 + '/' + year1;

            Carrera = self.instExt === '001UN' ? $("#Carrera option:selected").text() : self.CarreraExt; // sentencia que devuelve un valor
            Id_Carrera = self.instExt === '001UN' ? self.Carrera : self.instExt;

            btuContext.GuardarEstudiosAcademicos(self.GradoEst, self.NombEsc, Id_Carrera, self.AreaConoc, date1, date2, Carrera, DescGradoEstu, function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listEstAcadGuardados = btuContext.listEstAcadGuardados;
                        self.GradoEst = "";
                        self.NombEsc = "";
                        self.Carrera = "";
                        self.AreaConoc = "";
                        self.FechaIniCarrera = "";
                        self.FechaFinCarrera = "";
                        datosAcademicos = true;
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        this.GuardarSoftware = () => {
            if (self.NivelSoftware !== undefined && self.NivelSoftware !== "" && self.Software !== "" && self.Software !== undefined) {
                btuContext.GuardarSoftware(self.Software, self.NivelSoftware, function (resp) {
                    switch (resp.ressult) {
                        case "tgp":
                            self.listSoftware = btuContext.listSoftware;
                            self.Software = "";
                            self.NivelSoftware = "";
                            break;
                        case "notgp":
                            alert(resp.message);
                            break;
                        default:
                            break;
                    }
                    $scope.$apply();
                });
            }
            else {
                alert("Seleccione un nivel de dominio del software o el nombre del software.");
            }
        };

        this.GuardarIdioma = () => {
            if (self.NivelIdioma !== undefined && self.NivelIdioma !== "" && self.Idioma !== undefined && self.Idioma !== "") {
                btuContext.GuardarIdioma(self.Idioma, self.NivelIdioma, function (resp) {
                    switch (resp.ressult) {
                        case "tgp":
                            self.listIdioma = btuContext.listIdioma;
                            self.Idioma = "";
                            self.NivelIdioma = "";
                            break;
                        case "notgp":
                            alert(resp.message);
                            break;
                        default:
                            break;
                    }
                    $scope.$apply();
                });
            }
            else {
                alert("Seleccione un nivel de dominio del idioma o ingrese el nombre del idioma.");
            }
        };

        this.GuardarExperienciaProfesional = () => {
            let d1 = new Date(self.FechaIniExpProf);
            let month = (d1.getMonth() + 1);
            let nuevomes = month >= 10 ? month : '0' + month;
            let day = d1.getDate();
            let year = d1.getFullYear();
            let date1 = day + '/' + nuevomes + '/' + year;

            let d2 = new Date(self.FechaFinExpProf);
            let month1 = (d2.getMonth() + 1);
            let nuevomes1 = month1 >= 10 ? month1 : '0' + month1;
            let day1 = d2.getDate();
            let year1 = d2.getFullYear();
            let date2 = day1 + '/' + nuevomes1 + '/' + year1;

            btuContext.GuardarExperienciaProfesional(self.NombreEmpresa, date1, date2, self.DescAct, self.ReferenciaTrabajo, function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listExperienciaProf = btuContext.listExperienciaProf;
                        self.NombreEmpresa = "";
                        self.FechaIniExpProf = "";
                        self.FechaFinExpProf = "";
                        self.DescAct = "";
                        self.ReferenciaTrabajo = "";
                        datosExpProfesional = true;
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        this.GuardarCursoTaller = () => {
            let d1 = new Date(self.FecIniCur);
            let month = (d1.getMonth() + 1);
            let nuevomes = month >= 10 ? month : '0' + month;
            let day = d1.getDate();
            let year = d1.getFullYear();
            let date1 = day + '/' + nuevomes + '/' + year;

            let d2 = new Date(self.FecFinCur);
            let month1 = (d2.getMonth() + 1);
            let nuevomes1 = month1 >= 10 ? month1 : '0' + month1;
            let day1 = d2.getDate();
            let year1 = d2.getFullYear();
            let date2 = day1 + '/' + nuevomes1 + '/' + year1;
            btuContext.GuardarCursoTaller(self.CursoTaller, self.TipoCurso, self.InstTaller, date1, date2, function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listCursoTaller = btuContext.listCursoTaller;
                        self.CursoTaller = "";
                        self.TipoCurso = "";
                        self.InstTaller = "";
                        self.FecIniCur = "";
                        self.FecFinCur = "";
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        this.GuardarDatosCandidato = () => {
            if (existeImagenPerfilCv !== false) {
                if (datosAcademicos !== false && datosExpProfesional !== false && datosPersonales !== false) {
                    btuContext.GuardarInfoGeneralCandidato(function (resp) {
                        switch (resp.ressult) {
                            case "tgp":
                                alert("Datos guardarados correctamente, revisa tu correo para más información.");
                                window.location.assign(urlServer + "Btu/Btu");
                                break;
                            case "notgp":
                                alert(resp.message);
                                break;
                            default:
                                break;
                        }
                        $scope.$apply();
                    });
                }
                else
                    alert("No se han completado los campos requeridos.");
            }
            else
                alert("¡Aún no hay imagen de perfil!");
        };

        this.EditarInfoGeneralCandidato = () => {
            if (existeImagenPerfilCv !== false) {
                if (datosAcademicos !== false && datosExpProfesional !== false && datosPersonales !== false) {
                    btuContext.EditarInfoGeneralCandidato(function (resp) {
                        switch (resp.ressult) {
                            case "tgp":
                                alert("Datos guardarados correctamente.");
                                window.location.assign(urlServer + "Btu/PanelCandidato");
                                break;
                            case "notgp":
                                alert(resp.message);
                                window.location.assign(urlServer + "Btu/PanelCandidato");
                                break;
                            default:
                                break;
                        }
                        $scope.$apply();
                    });
                }
                else
                    alert("No se han completado los campos requeridos.");
            }
            else
                alert("¡Aún no hay imagen de perfil!");
        }

        this.EliminarEstudioAcademico = (Posicion) => {
            let eliminar = confirm('¿Desea eliminar el elemento de la lista?')
            if (eliminar) {
                btuContext.EliminarEstudioAcademico(Posicion, function (resp) {
                    switch (resp.ressult) {
                        case "tgp":
                            self.listEstAcadGuardados = btuContext.listEstAcadGuardados;
                            if (self.listEstAcadGuardados.length === 0) {
                                datosAcademicos = false;
                                $("#globalEstuAcd").css('background-color', 'yellow');
                                $("#estuacad1").hide();
                                $("#estuacad2").show();
                            }
                            break;
                        case "notgp":
                            alert(resp.message);
                            break;
                        default:
                            break;
                    }
                    $scope.$apply();
                });
            }
        };

        this.EliminarSoftware = (Posicion) => {
            let eliminar = confirm('¿Desea eliminar el elemento de la lista?')
            if (eliminar) {
                btuContext.EliminarSoftware(Posicion, function (resp) {
                    switch (resp.ressult) {
                        case "tgp":
                            self.listSoftware = btuContext.listSoftware;
                            break;
                        case "notgp":
                            alert(resp.message);
                            break;
                        default:
                            break;
                    }
                    $scope.$apply();
                });
            }
        };

        this.EliminarIdioma = (Posicion) => {
            let eliminar = confirm('¿Desea eliminar el elemento de la lista?')
            if (eliminar) {
                btuContext.EliminarIdioma(Posicion, function (resp) {
                    switch (resp.ressult) {
                        case "tgp":
                            self.listIdioma = btuContext.listIdioma;
                            break;
                        case "notgp":
                            alert(resp.message);
                            break;
                        default:
                            break;
                    }
                    $scope.$apply();
                });
            }
        };

        this.EliminarExperienciaProfesional = (Posicion) => {
            let eliminar = confirm('¿Desea eliminar el elemento de la lista?')
            if (eliminar) {
                btuContext.EliminarExperienciaProfesional(Posicion, function (resp) {
                    switch (resp.ressult) {
                        case "tgp":
                            self.listExperienciaProf = btuContext.listExperienciaProf;
                            if (self.listExperienciaProf.length === 0) {
                                datosExpProfesional = false;
                                $("#globalExpProf").css('background-color', 'yellow');
                                $("#expprof1").hide();
                                $("#expprof2").show();
                            }
                            break;
                        case "notgp":
                            alert(resp.message);
                            break;
                        default:
                            break;
                    }
                    $scope.$apply();
                });
            }
        };

        this.EliminarCursoTaller = (Posicion) => {
            let eliminar = confirm('¿Desea eliminar el elemento de la lista?')
            if (eliminar) {
                btuContext.EliminarCursoTaller(Posicion, function (resp) {
                    switch (resp.ressult) {
                        case "tgp":
                            self.listCursoTaller = btuContext.listCursoTaller;
                            break;
                        case "notgp":
                            alert(resp.message);
                            break;
                        default:
                            break;
                    }
                    $scope.$apply();
                });
            }
        };

        var obtFotoCandidato = (matricula, dependencia) => {
            //$.getJSON('https://siae.unach.mx/jwt/fotos/?matricula=A150011&clave_dep=41101')
            $.getJSON('https://siae.unach.mx/jwt/fotos/?matricula=' + matricula + '&clave_dep=' + dependencia)
                .done(function (data, textStatus, jqXHR) {
                    if (data.num === 1) {
                        $("#imgCadidato").attr("src", data.url);
                    }
                    else
                        alert("Agrega una imagen a tu perfil.");
                })
                .fail(function (jqXHR, textStatus, errorThrown) {
                    if (console && console.log) {
                        alert("Algo ha fallado al cargar la imagen de perfil: " + textStatus);
                    }
                });
        };

        this.cargarFotoPerfilCv = () => {
            var fileUpload = $("#cargarFoto").get(0);
            var files = fileUpload.files;
            if (files.length <= 1) {
                // Create FormData object  
                var fileData = new FormData();
                // Looping over all files and add it to FormData object  
                for (var i = 0; i < files.length; i++) {
                    fileData.append(files[i].name, files[i]);
                }
                var nombreArchivo = files[0].name;
                // Adding one more key to FormData object  
                fileData.append('username', "UNACH-DSIA");
                $.ajax({
                    url: '../Btu/UploadFiles',
                    type: "POST",
                    contentType: false, // Not to set any content header  
                    processData: false, // Not to process data  
                    data: fileData,
                    success: function (result) {
                        if (result === "1") {
                            let nombreFoto = $("#Matricula").val();
                            let formatoFoto = nombreArchivo.slice((nombreArchivo.lastIndexOf(".") - 1 >>> 0) + 2);
                            alert("Archivos subidos correctamente.");
                            //var rutaImg = "../Imagenes/ImgProfileCv/" + nombreFoto + "." + formatoFoto; ruta local para cargar imagenes
                            var rutaImg = "../ImgProfileCv/" + nombreFoto + "." + formatoFoto; // ruta del servidor para cargar imagenes
                            $("#imgCadidato").attr("src", rutaImg);
                            //$("#btnVerDoc").show();
                            //$("#btnUploadDoc").hide();                            
                            var control = jQuery('#cargarFoto');
                            control.replaceWith(control = control.val('').clone(true));
                            existeImagenPerfilCv = true;
                        }
                        else if (result !== 0)
                            alert('Error al cargar el archivo.');

                    },
                    error: function (err) {
                        alert(err.statusText);
                    }
                });
            }
            else {
                alert("Solo se permite subir un archivo.");
            }
        };

        this.TipoInstitucionEducativa = () => {
            if (self.instExt === "001UN" && self.instExt !== undefined) {
                $("#estExt").hide();
                $("#estInt").show();
                self.CarreraExt = "0";
                self.Carrera = self.listDatosRegistroUnach[0].IdCarrera;;
            }
            else {
                $("#estExt").show();
                $("#estInt").hide();
                self.Carrera = "0";
                self.CarreraExt = "";
            }
        };

        var ObtenerEstududiosAcademicos = () => {
            btuContext.ObtenerEstududiosAcademicos(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listEstAcadGuardados = btuContext.listEstAcadGuardados;
                        if (self.listEstAcadGuardados.length > 0) {
                            datosAcademicos = true;
                            $("#estuacad1").show();
                            $("#estuacad2").hide();
                            $("#globalEstuAcd").css('background-color', 'green');
                        }
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
                ObtenerSoftware();
            });
        }

        var ObtenerSoftware = () => {
            btuContext.ObtenerSoftware(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listSoftware = btuContext.listSoftware;
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
                ObtenerIdioma();
            });
        };

        var ObtenerIdioma = () => {
            btuContext.ObtenerIdioma(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listIdioma = btuContext.listIdioma;
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
                ObtenerExpProf();
            });
        };

        var ObtenerExpProf = () => {
            btuContext.ObtenerExpProf(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listExperienciaProf = btuContext.listExperienciaProf;
                        datosExpProfesional = true;
                        $("#expprof1").show();
                        $("#expprof2").hide();
                        $("#globalExpProf").css('background-color', 'green');
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
                ObtenerCursoTaller();
            });
        };

        var ObtenerCursoTaller = () => {
            btuContext.ObtenerCursoTaller(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listCursoTaller = btuContext.listCursoTaller;
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        this.RegresarPanelCandidato = () => {
            window.location.assign(urlServer + "Btu/PanelCandidato");
        };

        //Funciones para cargar combos compartidos
        var ComboEstados = () => {
            btuContext.ComboEstados(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listEstados = btuContext.listEstados;
                        break;
                    case "notgp":
                        alert(resp.message);
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
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        var comboMunicipios = () => {
            btuContext.ComboMunicipios(self.Estado, function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listMunicipios = btuContext.listMunicipios;
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        var ComboGradoEstudios = () => {
            btuContext.ComboGradoEstudios(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listGradoEstudios = btuContext.listGradoEstudios;
                        self.GradoEst = self.listGradoEstudios[3].Id;
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        var ComboCarreras = () => {
            btuContext.ComboCarreras(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listCarreras = btuContext.listCarreras;
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        var ComboAreaConocimiento = () => {
            btuContext.ComboAreaConocimiento(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listAreaConocimiento = btuContext.listAreaConocimiento;
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        var ComboNivelSoftware = () => {
            btuContext.ComboNivelSoftware("SOFTWARE", function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listNivelSoftware = btuContext.listNvlSoft;
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        var ComboNivelIdioma = () => {
            btuContext.ComboNivelIdioma("IDIOMA", function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listNivelIdioma = btuContext.listNvlIdi;
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        var ComboTipoCurso = () => {
            btuContext.ComboTipoCurso(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listTipoCurso = btuContext.listTipoCurso;
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        var ComboVacantesEmpresa = () => {
            btuContext.ComboVacantesEmpresa(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listVacRegEmp = btuContext.listVacRegEmp;
                        self.Vacante = self.listVacRegEmp[0].Id;
                        ObtenerGridCandidatosDisponibles(self.listVacRegEmp[0].Id);
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        var ComboGenero = () => {
            btuContext.ComboGenero(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listGenero = btuContext.listGenero;
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        var ComboEdoCivil = () => {
            btuContext.ComboEdoCivil(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listEdoCivil = btuContext.listEdoCivil;
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        var ComboTipoSalario = () => {
            btuContext.ComboTipoSalario(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listTipoSalario = btuContext.listTipoSalario;
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        var ComboIdiomaExtra = () => {
            btuContext.ComboIdiomaExtra(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listIdiomaExt = btuContext.listIdiomaExt;
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        var ComboTipoVacante = () => {
            btuContext.ComboTipoVacante(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listTipoVacante = btuContext.listTipoVacante;
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        //Funciones para la vista Btu

        this.IniciarSesion = (Tipo) => {
            btuContext.IniciarSesion(self.UsuarioUnach, self.ContrasenaUnach, Tipo, function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listSesionUnach = btuContext.listSesionUnach;
                        if (self.listSesionUnach[0].Existe === "1" && self.listSesionUnach[0].Registrado === "0")
                            window.location.assign(urlServer + "Btu/DatosCandidato");
                        else if (self.listSesionUnach[0].Existe === "1" && self.listSesionUnach[0].Registrado === "1")
                            window.location.assign(urlServer + "Btu/PanelCandidato");
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        this.IniciarSesionEmpresa = (Tipo) => {
            let UsuarioEmpresa = self.UsuarioEmpresa.toUpperCase();
            btuContext.IniciarSesionEmpresa(UsuarioEmpresa, self.ContrasenaEmpresa, Tipo, function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listSesionEmpresa = btuContext.listSesionUnach;
                        if (self.listSesionEmpresa[0].Existe === "1")
                            window.location.assign(urlServer + "Btu/PanelEmpresa");
                        else
                            alert("Usuario o contraseña incorrectos");
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        this.IniciarSesionAdmin = () => {
            btuContext.IniciarSesionAdmin(self.UsuarioAdmin, self.ContrasenaAdmin, function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        window.location.assign(urlServer + "Btu/PanelAdministrador");
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        }

        this.CerrarSesion = () => {
            btuContext.CerrarSesion(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        window.location.assign(urlServer);
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        }

        this.DatosGeneralesSistema = () => {
            btuContext.ObtenerTotalVacantes(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listTotalVac = btuContext.listTotalVac;
                        self.Total = self.listTotalVac[0].Total_Vacantes;
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        //Funciones para la vista Panel Candidato

        this.DatosPanelCandidato = () => {
            CargarDatosPanelCV();
            ObtenerTotalVacantes();
            ObtenerDatosSesion();
            $('#totalVac').show();
            $('#statusCand').show();
        };

        var CargarDatosPanelCV = () => {
            btuContext.CargarDatosPanelCV(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listDatosPanel = btuContext.listDatosPanelCv;
                        self.IdUsuario = self.listDatosPanel[0].Id;
                        self.Matricula = self.listDatosPanel[0].Matricula;
                        self.Registrado = self.listDatosPanel[0].Registrado;
                        idCandidato = self.listDatosPanel[0].Id;
                        eMailCandidato = self.listDatosPanel[0].Email;
                        nombreCandidato = self.listDatosPanel[0].NombreCandidato;
                        administrador = self.listDatosPanel[0].Administrador;
                        if (self.listDatosPanel[0].Administrador === true)
                            $('#btnPanelAdmin').show();
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
                ObtenerStatusCandidato();
            });
        };        

        this.GuardarIdCv = function (IdCv, Matricula, Registrado) {
            btuContext.GuardarIdCv(IdCv, Matricula, Registrado, function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        window.location.assign(urlServer + "Btu/DatosCandidato");
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        var ObtenerTotalVacantes = () => {
            btuContext.ObtenerTotalVacantes(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listTotalVac = btuContext.listTotalVac;
                        self.TotalVac = self.listTotalVac[0].Total_Vacantes;
                        
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();                
            });
        };

        var ObtenerStatusCandidato = () => {
            btuContext.ObtenerStatusCandidato(idCandidato, function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listStatusCand = btuContext.listStatusCand;
                        self.StatusCand = self.listStatusCand[0].Status;     
                        statusCandidato = self.StatusCand;
                        if (statusCandidato !== 'Activo')
                            $('#totalVac').hide();
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
                ObtenerGridStatusAplicaciones();
            });
        };

        var ObtenerGridStatusAplicaciones = () => {
            btuContext.ObtenerGridStatusAplicaciones(idCandidato, function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listStatusAgrupados = btuContext.listStatusAgrupados;
                        for (let i = 0; i < self.listStatusAgrupados.length; i++){
                            if (self.listStatusAgrupados[i].Status === "S")
                                self.StatusInv = self.listStatusAgrupados[i].Observaciones !== "" ? self.listStatusAgrupados[i].Observaciones : '0';                                 
                            else if (self.listStatusAgrupados[i].Status === "I")
                                self.StatusInt = self.listStatusAgrupados[i].Observaciones !== "" ? self.listStatusAgrupados[i].Observaciones : '0';
                            else if (self.listStatusAgrupados[i].Status === "E")
                                self.StatusEnt = self.listStatusAgrupados[i].Observaciones !== "" ? self.listStatusAgrupados[i].Observaciones : '0';
                            else if (self.listStatusAgrupados[i].Status === "C")
                                self.StatusAcep = self.listStatusAgrupados[i].Observaciones !== "" ? self.listStatusAgrupados[i].Observaciones : '0';
                            else if (self.listStatusAgrupados[i].Status === "R")
                                self.StatusRec = self.listStatusAgrupados[i].Observaciones !== "" ? self.listStatusAgrupados[i].Observaciones : '0';
                        }
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        this.ObtenerVacantesXstatus = (id, status) => {
            btuContext.ObtenerVacantesXstatus(id,status, function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listVacantesXstatus = btuContext.listVacantesXstatus;         
                        idVacCand = self.listVacantesXstatus[0].Id_Vac_Cand;
                        statusVacanteCand = self.listVacantesXstatus[0].Status;
                        $('#VacantesXStatus').show();
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();                
            });
        }

        this.VerDetallesVac = (Id) => {
            alert(Id);
        };

        this.ObtenerGridVacantesCandidatos = (Id, Desde, Hasta) => {
            btuContext.ObtenerGridVacantesCandidatos(Id,Desde, Hasta, function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listVacantesXstatus = btuContext.listVacantesCandidato;
                        if (self.listVacantesXstatus.length === 0)
                            alert('No hay vacantes registradas');
                        else
                            $('#VacantesXStatus').show();
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        this.ObtenerDetalleVacante = (Id_Candidato, Id_Vacante, StatusVacante, Id_Vac_Cand) => {
            btuContext.ObtenerDatosVacante(Id_Candidato, Id_Vacante,function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listDatosVacante = btuContext.listDatosVacante;
                        self.DetalleLicencia = self.listDatosVacante[0].Licencia;
                        self.DetalleDipsRadicar = self.listDatosVacante[0].Radicar;
                        self.DetalleDispViajar = self.listDatosVacante[0].Viajar;
                        self.DetalleNombre = self.listDatosVacante[0].Nombre;
                        self.DetalleTotal = self.listDatosVacante[0].Total;
                        self.DetalleEdadMin = self.listDatosVacante[0].Edad_Minima;
                        self.DetalleEdadMax = self.listDatosVacante[0].Edad_Maxima;                                                
                        self.DetalleEstadoCivil = self.listDatosVacante[0].Estado_Civil;
                        self.DetalleGradoEstudios = self.listDatosVacante[0].Grado;
                        self.DetalleExperiencia = self.listDatosVacante[0].Experiencia;
                        self.DetalleActividades = self.listDatosVacante[0].Actividades;
                        self.DetalleConocimientos = self.listDatosVacante[0].Conocimientos;
                        //    self.HorioDiaLab = self.listDatosVacante[0].Jornada_Laboral;
                        self.DetalleFrecuenciaSalario = self.listDatosVacante[0].Frecuencia_Salario;
                        self.DetalleSalario = self.listDatosVacante[0].Salario;
                        self.DetallePrestaciones = self.listDatosVacante[0].Prestaciones;
                        self.DetalleUbicacion = self.listDatosVacante[0].Ubicacion;
                        //    self.IdiomaExtra = self.listDatosVacante[0].Idioma;
                        //    self.VigIniVac = self.listDatosVacante[0].Vigencia_Inicio;
                        //    self.VigFinVac = self.listDatosVacante[0].Vigencia_Fin;
                        self.DetalleTipo = self.listDatosVacante[0].Tipo;
                        self.DetalleResponsableEntrevista = self.listDatosVacante[0].Responsable_Entrevista;
                        self.DetalleEspecificaciones = self.listDatosVacante[0].Especificaciones_Entrevista;
                        //    self.DircEntre = self.listDatosVacante[0].Direccion_Entrevista;
                        //    self.TelOfc = self.listDatosVacante[0].Telefono;
                        eMailEmpresa = self.listDatosVacante[0].Correo;
                        self.DetalleComentarios = self.listDatosVacante[0].Comentarios;
                        if (self.listDatosVacante[0].Genero === 'I')
                            self.DetalleGenero = 'INDISTINTO';
                        else if (self.listDatosVacante[0].Genero === 'M')
                            self.DetalleGenero = 'MASCULINO';
                        else if (self.listDatosVacante[0].Genero === 'F')
                            self.DetalleGenero = 'FEMENINO';
                        statusVacanteCand = StatusVacante;
                        idVacanteSeleccionada = Id_Vacante;
                        idVacCand = Id_Vac_Cand;
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        this.AplicarVacante = (Id_Candidato, nombreVacante) => {
            let esInvitado = statusVacanteCand === 'INVITADO' ? "1" : "0";
            btuContext.AplicarVacante(idVacanteSeleccionada, Id_Candidato, esInvitado, eMailEmpresa, eMailCandidato, nombreCandidato, nombreVacante, idVacCand, function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        alert('¡Has aplicado a la vacante!');
                        break;
                    case "notgp":                        
                        if (resp.message === '1')
                            alert('¡Ya has aplicado a esta vacante!.');
                        else if (resp.message === '2')
                            alert('Tu usuario no está en estatus alta, por lo que no puedes aplicar a las vacantes.');
                        else
                            alert(resp.message);
                        break;
                    default:                        
                        break;
                }
                $scope.$apply();
            });
        };

        //Funciones para la vista Panel Empresa

        this.CargarDatosPanelEmpresa = () => {
            btuContext.CargarDatosPanelEmpresa(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listDatosPanelEmpresa = btuContext.listDatosPanelEmpresa;
                        administrador = self.listDatosPanelEmpresa[0].Administrador;
                        if (self.listDatosPanelEmpresa[0].Status === 'A') {
                            $('#infemp1').show();
                            $("#globalStatusEmpresa").css('background-color', 'green');
                            self.StatusEmpresa = 'Alta';
                        }
                        else if (self.listDatosPanelEmpresa[0].Status === 'B') {
                            $('#infemp2').show();
                            $("#globalStatusEmpresa").css('background-color', 'yellow');
                            self.StatusEmpresa = 'Baja Temporal';
                            $('#nuevaVacante').prop('disabled', true);
                        }
                        else {
                            $('#infemp2').show();
                            $("#globalStatusEmpresa").css('background-color', 'yellow');
                            self.StatusEmpresa = 'Pendiente Por Activar';
                            $('#nuevaVacante').prop('disabled', true);
                        }
                        $('#statusDesc').show();
                        if (self.listDatosPanelEmpresa[0].Administrador === true)
                            $('#btnPanelAdmin').show();
                        self.IdEmpresa = self.listDatosPanelEmpresa[0].Id_Empresa;
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
                ObtenerDatosSesion();
            });
        };        

        this.VerDatosEmpresa = () => {
            window.location.assign(urlServer + "Btu/RegistrarEmpresa");
        };

        this.VerVacantesEmpresa = () => {
            $('#tablaVacApliEmpresa').hide();
            $('#tablaCandDisp').hide();
            $('#verCandDisp').hide();
            if (self.listVacantesApliEmpresa !== undefined)
                $('#tablaVacApliEmpresa').DataTable().clear().destroy();          
            if (self.listVacantesEmpresa !== undefined)
                $('#tablaVacantesEmpresa').DataTable().clear().destroy();
            if (self.listCandDispo !== undefined)
                $('#tablaCandDisp').DataTable().clear().destroy();
            btuContext.ObtenerGridVacantes(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listVacantesEmpresa = btuContext.listVacantesEmpresa;
                        if (self.listVacantesEmpresa !== undefined && self.listVacantesEmpresa.length > 0) {
                            $('#cargarTabla').hide();
                            $('#tablaVacantesEmpresa').show();
                            $('#containerEmpresa').show();
                            table = $('#tablaVacantesEmpresa').DataTable({
                                language: {
                                    "decimal": "",
                                    "emptyTable": "No hay información",
                                    "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                                    "infoEmpty": "Mostrando 0 de 0 a 0 Entradas",
                                    "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                                    "infoPostFix": "",
                                    "thousands": ",",
                                    "lengthMenu": "Mostrar _MENU_ Entradas",
                                    "loadingRecords": "Cargando...",
                                    "processing": "Procesando...",
                                    "search": "Buscar:",
                                    "zeroRecords": "Sin resultados encontrados",
                                    "paginate": {
                                        "first": "Primero",
                                        "last": "Último",
                                        "next": "Siguiente",
                                        "previous": "Anterior"
                                    }
                                },
                                data: self.listVacantesEmpresa,
                                pageLength: 5,
                                columns: [
                                    {
                                        "className": 'details-control',                                        
                                        "orderable": false,
                                        "data": null,
                                        "defaultContent": '',
                                        "render": function () {
                                            return '<i class="fa fa-plus-square" aria-hidden="true"></i>';
                                        },
                                        width: "15px"
                                    },
                                    { data: "Nombre" },
                                    { data: "Total" },
                                    { data: "Edad_Minima" },
                                    { data: "Edad_Maxima" },
                                    { data: "Salario" },
                                    {
                                        data: "Id",
                                        "className": "text-center",
                                        render: function (data, type, row, meta) {
                                            return '<i data-toggle="tooltip"  title="Editar Vacante" class="fas fa-pencil-alt" ng-click="GuardarIdVacante(&quot;' + row.Id + '&quot;,&quot;' + row.RutaFoto + '&quot;)"></i>';
                                        }

                                    },
                                    {
                                        data: "Id",
                                        "className": "text-center",
                                        render: function (data, type, row, meta) {
                                            return '<i data-toggle="tooltip"  title="Eliminar Vacante" class="fas fa-trash" ng-click="EliminarVacante(&quot;' + row.Id + '&quot;,&quot;' + row.Correo + '&quot;,&quot;' + row.Nombre + '&quot;)"></i>';
                                        }

                                    }
                                ],
                                rowCallback: function (row) {
                                    if (!row.compiled) {
                                        $compile(angular.element(row))($scope);
                                        row.compiled = true;
                                    }
                                }
                            });
                        }
                        break;
                    case "notgp":
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        var VerVacantesEmpresa = () => {
            $('#tablaVacApliEmpresa').hide();
            $('#tablaCandDisp').hide();
            $('#verCandDisp').hide();
            if (self.listVacantesApliEmpresa !== undefined)
                $('#tablaVacApliEmpresa').DataTable().clear().destroy();
            if (self.listVacantesEmpresa !== undefined)
                $('#tablaVacantesEmpresa').DataTable().clear().destroy();
            if (self.listCandDispo !== undefined)
                $('#tablaCandDisp').DataTable().clear().destroy();
            btuContext.ObtenerGridVacantes(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listVacantesEmpresa = btuContext.listVacantesEmpresa;
                        if (self.listVacantesEmpresa !== undefined && self.listVacantesEmpresa.length > 0) {
                            $('#cargarTabla').hide();
                            $('#tablaVacantesEmpresa').show();
                            table = $('#tablaVacantesEmpresa').DataTable({
                                language: {
                                    "decimal": "",
                                    "emptyTable": "No hay información",
                                    "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                                    "infoEmpty": "Mostrando 0 de 0 a 0 Entradas",
                                    "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                                    "infoPostFix": "",
                                    "thousands": ",",
                                    "lengthMenu": "Mostrar _MENU_ Entradas",
                                    "loadingRecords": "Cargando...",
                                    "processing": "Procesando...",
                                    "search": "Buscar:",
                                    "zeroRecords": "Sin resultados encontrados",
                                    "paginate": {
                                        "first": "Primero",
                                        "last": "Último",
                                        "next": "Siguiente",
                                        "previous": "Anterior"
                                    }
                                },
                                data: self.listVacantesEmpresa,
                                pageLength: 5,
                                columns: [
                                    {
                                        "className": 'details-control',
                                        "orderable": false,
                                        "data": null,
                                        "defaultContent": '',
                                        "render": function () {
                                            return '<i class="fa fa-plus-square" aria-hidden="true"></i>';
                                        },
                                        width: "15px"
                                    },
                                    { data: "Nombre" },
                                    { data: "Total" },
                                    { data: "Edad_Minima" },
                                    { data: "Edad_Maxima" },
                                    { data: "Salario" },
                                    {
                                        data: "Id",
                                        "className": "text-center",
                                        render: function (data, type, row, meta) {
                                            return '<i data-toggle="tooltip"  title="Editar Vacante" class="fas fa-pencil-alt" ng-click="GuardarIdVacante(&quot;' + row.Id + '&quot;,&quot;' + row.RutaFoto + '&quot;)"></i>';
                                        }

                                    },
                                    {
                                        data: "Id",
                                        "className": "text-center",
                                        render: function (data, type, row, meta) {
                                            return '<i data-toggle="tooltip"  title="Eliminar Vacante" class="fas fa-trash" ng-click="EliminarVacante(&quot;' + row.Id + '&quot;,&quot;' + row.Correo + '&quot;,&quot;' + row.Nombre + '&quot;)"></i>';
                                        }

                                    }
                                ],
                                rowCallback: function (row) {
                                    if (!row.compiled) {
                                        $compile(angular.element(row))($scope);
                                        row.compiled = true;
                                    }
                                }
                            });
                        }
                        break;
                    case "notgp":
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        $scope.GuardarIdVacante = (Id) => {
            $('#cargarTabla').hide();
            btuContext.GuardarIdVacante(Id, function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        window.location.assign(urlServer + "Btu/Vacante");
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();                
            });
        };

        this.NuevaVacante = () => {
            window.location.assign(urlServer + "Btu/Vacante");
        };

        $scope.ObtenerGridInteresados = (Id, NombreVacante) => {
            nombreVacanteInteresado = NombreVacante;
            btuContext.ObtenerGridInteresados(Id, function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listInteresadosVac = btuContext.listInteresadosVac;                        
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        this.ObtenerGridVacantesAplicadasEmpresas = () => {
            $('#tablaVacantesEmpresa').hide();            
            $('#tablaCandDisp').hide();
            $('#verCandDisp').hide();
            if (self.listVacantesApliEmpresa !== undefined)
                $('#tablaVacApliEmpresa').DataTable().clear().destroy()
            if (self.listVacantesEmpresa !== undefined)
                $('#tablaVacantesEmpresa').DataTable().clear().destroy()
            if (self.listCandDispo !== undefined)
                $('#tablaCandDisp').DataTable().clear().destroy();
            btuContext.ObtenerGridVacantesAplicadasEmpresas(function (resp) {
                switch (resp.ressult) {
                    case "tgp":                        
                        self.listVacantesApliEmpresa = btuContext.listVacantesApliEmpresa;
                        if (self.listVacantesApliEmpresa !== undefined && self.listVacantesApliEmpresa.length > 0) {
                            $('#cargarTabla').hide();
                            $('#tablaVacApliEmpresa').show();
                            $('#containerEmpresa').show();
                            table = $('#tablaVacApliEmpresa').DataTable({
                                language: {
                                    "decimal": "",
                                    "emptyTable": "No hay información",
                                    "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                                    "infoEmpty": "Mostrando 0 de 0 a 0 Entradas",
                                    "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                                    "infoPostFix": "",
                                    "thousands": ",",
                                    "lengthMenu": "Mostrar _MENU_ Entradas",
                                    "loadingRecords": "Cargando...",
                                    "processing": "Procesando...",
                                    "search": "Buscar:",
                                    "zeroRecords": "Sin resultados encontrados",
                                    "paginate": {
                                        "first": "Primero",
                                        "last": "Último",
                                        "next": "Siguiente",
                                        "previous": "Anterior"
                                    }
                                },
                                data: self.listVacantesApliEmpresa,
                                pageLength: 5,
                                columns: [                                    
                                    { data: "Nombre" },
                                    { data: "Total" },
                                    { data: "Edad_Minima" },
                                    { data: "Edad_Maxima" },
                                    { data: "Salario" },
                                    { data: "Vigencia_Inicio" },
                                    { data: "Vigencia_Fin" },
                                    { data: "Total_Interesados" },
                                    {
                                        data: "Id",
                                        "className": "text-center",
                                        render: function (data, type, row, meta) {
                                            return '<p data-toggle="tooltip"  title="Ver Interesados" class"  ><i class="fas fa-user" data-toggle="modal" data-target="#modalIntVac" ng-click="ObtenerGridInteresados(&quot;' + row.Id + '&quot;,&quot;' + row.Nombre + '&quot;)"></i></p>';                                            
                                        }

                                    }
                                ],
                                rowCallback: function (row) {
                                    if (!row.compiled) {
                                        $compile(angular.element(row))($scope);
                                        row.compiled = true;
                                    }
                                }
                            });
                        }
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        var ObtenerGridCandidatosDisponibles = (Id) => {
            $('#tablaVacantesEmpresa').hide();
            $('#tablaVacApliEmpresa').hide();
            if (self.listVacantesApliEmpresa !== undefined)
                $('#tablaVacApliEmpresa').DataTable().clear().destroy()
            if (self.listVacantesEmpresa !== undefined)
                $('#tablaVacantesEmpresa').DataTable().clear().destroy()
            if (self.listCandDispo !== undefined)
                $('#tablaCandDisp').DataTable().clear().destroy();
            btuContext.ObtenerGridCandidatosDisponibles(Id, function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listCandDispo = btuContext.listCandDispo;
                        if (self.listCandDispo !== undefined && self.listCandDispo.length > 0) {
                            $('#cargarTabla').hide();
                            $('#tablaCandDisp').show();
                            table = $('#tablaCandDisp').DataTable({
                                language: {
                                    "decimal": "",
                                    "emptyTable": "No hay información",
                                    "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                                    "infoEmpty": "Mostrando 0 de 0 a 0 Entradas",
                                    "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                                    "infoPostFix": "",
                                    "thousands": ",",
                                    "lengthMenu": "Mostrar _MENU_ Entradas",
                                    "loadingRecords": "Cargando...",
                                    "processing": "Procesando...",
                                    "search": "Buscar:",
                                    "zeroRecords": "Sin resultados encontrados",
                                    "paginate": {
                                        "first": "Primero",
                                        "last": "Último",
                                        "next": "Siguiente",
                                        "previous": "Anterior"
                                    }
                                },
                                data: self.listCandDispo,
                                pageLength: 5,
                                columns: [                                    
                                    { data: "Nombre" },
                                    { data: "Genero" },
                                    { data: "Fecha_Nacimiento" },
                                    { data: "Carrera" },                                   
                                    {
                                        data: "Id",
                                        "className": "text-center",
                                        render: function (data, type, row, meta) {
                                            return '<i data-toggle="tooltip"  title="Ver Curriculum" class="fas fa-file-alt" ng-click="GuardarIdVacante(&quot;' + row.Id + '&quot;,&quot;' + row.RutaFoto + '&quot;)"></i>';
                                        }

                                    },
                                    {
                                        data: "Id",
                                        "className": "text-center",
                                        render: function (data, type, row, meta) {
                                            return '<i data-toggle="tooltip"  title="Invitar a Aplicar a la Vacante" class="fas fa-envelope" ng-click="InvitarCandidato(&quot;' + row.Id + '&quot;,&quot;' + row.Correo + '&quot;,&quot;' + row.Nombre + '&quot;)"></i>';
                                        }

                                    }
                                ],
                                rowCallback: function (row) {
                                    if (!row.compiled) {
                                        $compile(angular.element(row))($scope);
                                        row.compiled = true;
                                    }
                                }
                            });
                        }
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        this.ObtenerGridCandidatosDisponibles = () => {
            $('#tablaVacantesEmpresa').hide();
            $('#tablaVacApliEmpresa').hide();
            if (self.listVacantesApliEmpresa !== undefined)
                $('#tablaVacApliEmpresa').DataTable().clear().destroy()
            if (self.listVacantesEmpresa !== undefined)
                $('#tablaVacantesEmpresa').DataTable().clear().destroy()
            if (self.listCandDispo !== undefined)
                $('#tablaCandDisp').DataTable().clear().destroy();
            btuContext.ObtenerGridCandidatosDisponibles(self.Vacante, function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listCandDispo = btuContext.listCandDispo;
                        if (self.listCandDispo !== undefined && self.listCandDispo.length > 0) {
                            $('#cargarTabla').hide();
                            $('#tablaCandDisp').show();
                            table = $('#tablaCandDisp').DataTable({
                                language: {
                                    "decimal": "",
                                    "emptyTable": "No hay información",
                                    "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                                    "infoEmpty": "Mostrando 0 de 0 a 0 Entradas",
                                    "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                                    "infoPostFix": "",
                                    "thousands": ",",
                                    "lengthMenu": "Mostrar _MENU_ Entradas",
                                    "loadingRecords": "Cargando...",
                                    "processing": "Procesando...",
                                    "search": "Buscar:",
                                    "zeroRecords": "Sin resultados encontrados",
                                    "paginate": {
                                        "first": "Primero",
                                        "last": "Último",
                                        "next": "Siguiente",
                                        "previous": "Anterior"
                                    }
                                },
                                data: self.listCandDispo,
                                pageLength: 5,
                                columns: [
                                    { data: "Nombre" },
                                    { data: "Genero" },
                                    { data: "Fecha_Nacimiento" },
                                    { data: "Carrera" },
                                    {
                                        data: "Id",
                                        "className": "text-center",
                                        render: function (data, type, row, meta) {
                                            return '<i data-toggle="tooltip"  title="Ver Curriculum" class="fas fa-file-alt" ng-click="GuardarIdVacante(&quot;' + row.Id + '&quot;,&quot;' + row.RutaFoto + '&quot;)"></i>';
                                        }

                                    },
                                    {
                                        data: "Id",
                                        "className": "text-center",
                                        render: function (data, type, row, meta) {
                                            return '<i data-toggle="tooltip"  title="Invitar a Aplicar a la Vacante" class="fas fa-envelope" ng-click="InvitarCandidato(&quot;' + row.Id + '&quot;,&quot;' + row.Correo + '&quot;,&quot;' + row.Nombre + '&quot;)"></i>';
                                        }

                                    }
                                ],
                                rowCallback: function (row) {
                                    if (!row.compiled) {
                                        $compile(angular.element(row))($scope);
                                        row.compiled = true;
                                    }
                                }
                            });
                        }
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        $scope.EliminarVacante = (Id) => {
            let respuesta = confirm("¿Desea borrar la vacante?");
            if (respuesta) {
                btuContext.EliminarVacante(Id, function (resp) {
                    switch (resp.ressult) {
                        case "tgp":
                            alert("Vacante borrada.");
                            VerVacantesEmpresa();
                            break;
                        case "notgp":
                            alert(resp.message);
                            break;
                        default:
                            break;
                    }
                    $scope.$apply();
                });
            }
        };

        this.GuardarIdCandidatoInteresado = (idVacCand, idCandidato, emailCand) => {
            idVacanteCandidato = idVacCand;
            idCandInteresado = idCandidato;
            correoCandidato = emailCand;
        };

        this.EditarStatusInteresado = () => {
            let observacionesStatus = "";
            if (self.observacionesStatus === undefined || self.observacionesStatus === "")
                observacionesStatus = 'N/A';
            else
                observacionesStatus = self.observacionesStatus;
            if (self.statusCandidato !== undefined) {
                btuContext.EditarStatusInteresado(idVacanteCandidato, self.statusCandidato, observacionesStatus, idCandInteresado, nombreVacanteInteresado, correoCandidato, function (resp) {
                    switch (resp.ressult) {
                        case "tgp":
                            alert('Estatus modificado correctamente');
                            $('#modalStatusCandidato').modal('toggle');
                            $('#modalIntVac').modal('toggle');
                            break;
                        case "notgp":
                            alert(resp.message);
                            alert('Estatus modificado correctamente');
                            $('#modalStatusCandidato').modal('toggle');
                            $('#modalIntVac').modal('toggle');
                            break;
                        default:
                            alert('Estatus modificado correctamente');
                            $('#modalStatusCandidato').modal('toggle');
                            $('#modalIntVac').modal('toggle');
                            break;
                    }
                    $scope.$apply();
                });
            }
            else
                alert('Seleccione un estatus para el candidato');
        };

        $scope.InvitarCandidato = (Id_Interesado, CorreoCandidato, NombreCandidatoInv) => {               
            let invitar = confirm('¿Desea invitar al candidato a aplicar a la vacante?');
            if (invitar) {
                $('#modalCargandoSolicitud').modal('show');
                let IdVacante = self.Vacante;
                let nombreVacEmpresa = $("#Vacante option:selected").text();
                btuContext.InvitarCandidato(IdVacante, Id_Interesado, nombreVacEmpresa, NombreCandidatoInv, CorreoCandidato, function (resp) {
                    switch (resp.ressult) {
                        case "tgp":                            
                            $("#modalCargandoSolicitud").modal('toggle');
                            alert('Ha invitado al candidato a aplicar a la vacante: ' + nombreVacEmpresa);
                            ObtenerGridCandidatosDisponibles(self.listVacRegEmp[0].Id);

                            break;
                        case "notgp":
                            $("#modalCargandoSolicitud").modal('toggle');
                            alert(resp.message);
                            break;
                        default:
                            $("#modalCargandoSolicitud").modal('toggle');
                            break;
                    }
                    $scope.$apply();
                });
            }
        };

        // Funciones para la vista Panel Administrador

        this.CargarDatosPrincipalesPanelAdmin = () => {            
            ObtenerTotalEmpresas();
        };

        this.RegresarPanelAdministrador = () => {
            if (administrador === true)
                window.location.assign(urlServer + "Btu/PanelAdministrador");
        };

        var ObtenerTotalEmpresas = () => {
            btuContext.ObtenerTotalEmpresas(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        let TotalEmpresas = 0;
                        self.listEmpresas_Status = btuContext.listEmpresas_Status;
                        for (let i = 0; i < self.listEmpresas_Status.length; i++){
                            TotalEmpresas = TotalEmpresas + parseInt(self.listEmpresas_Status[i].Total);                           
                        }
                        self.TotalEmpresas = TotalEmpresas;
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
                ObtenerTotalCandidatos();
            });
        };

        var ObtenerTotalCandidatos = () => {
            btuContext.ObtenerTotalCandidatos(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        let TotalCandidatos = 0;
                        self.listCandidatos_Status = btuContext.listCandidatos_Status;
                        for (let i = 0; i < self.listCandidatos_Status.length; i++) {
                            TotalCandidatos = TotalCandidatos + parseInt(self.listCandidatos_Status[i].Total);
                        }
                        self.TotalCandReg = TotalCandidatos;
                        break;
                    case "notgp":
                        alert(resp.message);                        
                        break;
                    default:
                        break;
                }
                $scope.$apply();      
                ObtenerDatosSesion();
            });
        };

        var ObtenerDatosSesion = () => {
            btuContext.ObtenerDatosSesion(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listDatosSesion = btuContext.listDatosSesion;
                        self.lycorreo = self.listDatosSesion[0].Email;
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        this.ObtenerGridEmpresasRegistradas = () => {            
            btuContext.ObtenerGridEmpresasRegistradas(function (resp) {
                switch (resp.ressult) {
                    case "tgp":                        
                        if (self.listEmpresasRegistradas !== undefined)
                            $('#tablaEmpresas').DataTable().clear().destroy();
                        if (self.listaCandidatosRegistrados !== undefined) {
                            $('#tablaCandidatos').DataTable().clear().destroy();
                            $('#tablaCandidatos').hide();
                            $('#tablaCandidatosApl').hide();
                        }
                        self.listEmpresasRegistradas = btuContext.listEmpresasRegistradas;
                        if (self.listEmpresasRegistradas !== undefined && self.listEmpresasRegistradas.length > 0)
                        {
                            $('#containerTable').show();
                            table = $('#tablaEmpresas').DataTable({
                                language: {
                                    "decimal": "",
                                    "emptyTable": "No hay información",
                                    "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                                    "infoEmpty": "Mostrando 0 de 0 a 0 Entradas",
                                    "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                                    "infoPostFix": "",
                                    "thousands": ",",
                                    "lengthMenu": "Mostrar _MENU_ Entradas",
                                    "loadingRecords": "Cargando...",
                                    "processing": "Procesando...",
                                    "search": "Buscar:",
                                    "zeroRecords": "Sin resultados encontrados",
                                    "paginate": {
                                        "first": "Primero",
                                        "last": "Último",
                                        "next": "Siguiente",
                                        "previous": "Anterior"
                                    }
                                },
                                data: self.listEmpresasRegistradas,
                                pageLength: 5,
                                columns: [
                                    {
                                        "className": 'details-control',
                                        "orderable": false,
                                        "data": null,
                                        "defaultContent": '',
                                        "render": function () {
                                            return '<i class="fa fa-plus-square" aria-hidden="true"></i>';
                                        },
                                        width: "15px"
                                    },
                                    { data: "Razon_Social" },
                                    { data: "Nombre_Comercial" },
                                    { data: "Actividad" },
                                    { data: "Rfc" },
                                    { data: "Status" },
                                    {
                                        data: "Email",
                                        "className": "text-center",
                                        render: function (data, type, row, meta) {                                            
                                            return '<p data-toggle="tooltip"  title="Cambiar Status" class"  ><i class="fas fa-info-circle" data-toggle="modal" data-target="#modalStatusEmpresa" ng-click="EditStatus(&quot;' + row.Rfc + '&quot;,&quot;' + row.Email + '&quot;)"></i></p>';                                            
                                        }

                                    },
                                    {
                                        data: "Id",
                                        "className": "text-center",
                                        render: function (data, type, row, meta) {
                                            return '<i data-toggle="tooltip"  title="Ver Panel Empresa" class="fas fa-pencil-alt" ng-click="AlmacenarDatosEmpresa(&quot;' + row.Id + '&quot;,&quot;' + row.Rfc + '&quot;,&quot;' + row.Nombre_Comercial + '&quot;)"></i>';
                                        }

                                    },
                                    {
                                        data: "Id",
                                        "className": "text-center",
                                        render: function (data, type, row, meta) {
                                            return '<p data-toggle="tooltip"  title="Ver Vacantes de la Empresas" class"  ><i class="fas fa-eye" style=color:'+row.TieneVacantes+' data-toggle="modal" data-target="#modalVacantesEmpresa" ng-click="ObtenerGridVacantesPanelAdmin(&quot;' + row.Id + '&quot;)"></i></p>';
                                        }

                                    },
                                    {
                                        data: "Id",
                                        "className": "text-center",
                                        render: function (data, type, row, meta) {
                                            return '<i data-toggle="tooltip"  title="Eliminar Empresa" class="fas fa-trash" ng-click="EliminarEmpresa(&quot;' + row.Id + '&quot;)"></i>';
                                        }

                                    },
                                    {
                                        data: "Id",
                                        "className": "text-center",
                                        render: function (data, type, row, meta) {
                                            return '<i data-toggle="tooltip"  title="Ficha Empresa" class="far fa-file-pdf" ng-click="ReporteFichaEmpresa(&quot;' + row.Id + '&quot;)"></i>';
                                        }

                                    }
                                ],
                                rowCallback: function (row) {
                                    if (!row.compiled) {
                                        $compile(angular.element(row))($scope);
                                        row.compiled = true;
                                    }
                                }
                            });
                        }
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
                $('#tablaEmpresas').show();
            });
        };

        var ObtenerGridEmpresasRegistradas = () => {
            btuContext.ObtenerGridEmpresasRegistradas(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        if (self.listEmpresasRegistradas !== undefined)
                            $('#tablaEmpresas').DataTable().clear().destroy();
                        if (self.listaCandidatosRegistrados !== undefined) {
                            $('#tablaCandidatos').DataTable().clear().destroy();
                            $('#tablaCandidatos').hide();
                            $('#tablaCandidatosApl').hide();
                        }
                        self.listEmpresasRegistradas = btuContext.listEmpresasRegistradas;
                        if (self.listEmpresasRegistradas !== undefined && self.listEmpresasRegistradas.length > 0) {
                            table = $('#tablaEmpresas').DataTable({
                                language: {
                                    "decimal": "",
                                    "emptyTable": "No hay información",
                                    "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                                    "infoEmpty": "Mostrando 0 de 0 a 0 Entradas",
                                    "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                                    "infoPostFix": "",
                                    "thousands": ",",
                                    "lengthMenu": "Mostrar _MENU_ Entradas",
                                    "loadingRecords": "Cargando...",
                                    "processing": "Procesando...",
                                    "search": "Buscar:",
                                    "zeroRecords": "Sin resultados encontrados",
                                    "paginate": {
                                        "first": "Primero",
                                        "last": "Último",
                                        "next": "Siguiente",
                                        "previous": "Anterior"
                                    }
                                },
                                data: self.listEmpresasRegistradas,
                                pageLength: 5,
                                columns: [
                                    {
                                        "className": 'details-control',
                                        "orderable": false,
                                        "data": null,
                                        "defaultContent": '',
                                        "render": function () {
                                            return '<i class="fa fa-plus-square" aria-hidden="true"></i>';
                                        },
                                        width: "15px"
                                    },
                                    { data: "Razon_Social" },
                                    { data: "Nombre_Comercial" },
                                    { data: "Actividad" },
                                    { data: "Rfc" },
                                    { data: "Status" },
                                    {
                                        data: "Email",
                                        "className": "text-center",
                                        render: function (data, type, row, meta) {
                                            return '<p data-toggle="tooltip"  title="Cambiar Status" class"  ><i class="fas fa-info-circle" data-toggle="modal" data-target="#modalStatusEmpresa" ng-click="EditStatus(&quot;' + row.Rfc + '&quot;,&quot;' + row.Email + '&quot;)"></i></p>';
                                        }

                                    },
                                    {
                                        data: "Id",
                                        "className": "text-center",
                                        render: function (data, type, row, meta) {
                                            return '<i data-toggle="tooltip"  title="Ver Panel Empresa" class="fas fa-pencil-alt" ng-click="AlmacenarDatosEmpresa(&quot;' + row.Id + '&quot;,&quot;' + row.Rfc + '&quot;,&quot;' + row.Razon_Social + '&quot;)"></i>';
                                        }

                                    },
                                    {
                                        data: "Id",
                                        "className": "text-center",
                                        render: function (data, type, row, meta) {
                                            return '<p data-toggle="tooltip"  title="Ver Vacantes de la Empresas" class"  ><i class="fas fa-eye" style=color:' + row.TieneVacantes +' data-toggle="modal" data-target="#modalVacantesEmpresa" ng-click="ObtenerGridVacantesPanelAdmin(&quot;' + row.Id + '&quot;)"></i></p>';
                                        }

                                    },
                                    {
                                        data: "Id",
                                        "className": "text-center",
                                        render: function (data, type, row, meta) {
                                            return '<i data-toggle="tooltip"  title="Eliminar Vacante" class="fas fa-trash" ng-click="EliminarEmpresa(&quot;' + row.Id + '&quot;)"></i>';
                                        }

                                    },
                                    {
                                        data: "Id",
                                        "className": "text-center",
                                        render: function (data, type, row, meta) {
                                            return '<i data-toggle="tooltip"  title="Ficha Empresa" class="far fa-file-pdf" ng-click="ReporteFichaEmpresa(&quot;' + row.Id + '&quot;)"></i>';
                                        }

                                    }
                                ],
                                rowCallback: function (row) {
                                    if (!row.compiled) {
                                        $compile(angular.element(row))($scope);
                                        row.compiled = true;
                                    }
                                }
                            });
                        }
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
                $('#tablaEmpresas').show();
            });
        };

        this.ObtenerGridCandidatosRegistrados = () => {
            btuContext.ObtenerGridCandidatos(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        if (self.listEmpresasRegistradas !== undefined) {
                            $('#tablaEmpresas').DataTable().clear().destroy();
                            $('#tablaEmpresas').hide();                     
                            $('#tablaCandidatosApl').hide();
                        }
                        $('#tablaCandidatos').DataTable().clear().destroy();
                        self.listaCandidatosRegistrados = btuContext.listaCandidatosRegistrados;

                        if (self.listaCandidatosRegistrados !== undefined && self.listaCandidatosRegistrados.length > 0) {    
                            $('#containerTable').show();
                            table = $('#tablaCandidatos').DataTable({
                                language: {
                                    "decimal": "",
                                    "emptyTable": "No hay información",
                                    "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                                    "infoEmpty": "Mostrando 0 de 0 a 0 Entradas",
                                    "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                                    "infoPostFix": "",
                                    "thousands": ",",
                                    "lengthMenu": "Mostrar _MENU_ Entradas",
                                    "loadingRecords": "Cargando...",
                                    "processing": "Procesando...",
                                    "search": "Buscar:",
                                    "zeroRecords": "Sin resultados encontrados",
                                    "paginate": {
                                        "first": "Primero",
                                        "last": "Último",
                                        "next": "Siguiente",
                                        "previous": "Anterior"
                                    }
                                },
                                data: self.listaCandidatosRegistrados,
                                pageLength: 4,
                                columns: [
                                    {
                                        "className": 'details-control',
                                        "orderable": false,
                                        "data": null,
                                        "defaultContent": '',
                                        "render": function () {
                                            return '<i class="fa fa-plus-square" aria-hidden="true"></i>';
                                        },
                                        width: "15px"
                                    },
                                    { data: "Matricula" },
                                    { data: "Carrera" },
                                    { data: "Nombre" },
                                    { data: "Celular" },
                                    { data: "Status" },
                                    {
                                        data: "Id",
                                        "className": "text-center",
                                        render: function (data, type, row, meta) {
                                            return '<p data-toggle="tooltip"  title="Cambiar Status" class"  ><i class="fas fa-info-circle" data-toggle="modal" data-target="#modalStatusCandidato" ng-click="EditStatusCand(&quot;' + row.Matricula + '&quot;,&quot;' + row.Correo + '&quot;)"></i></p>';                                                                                        
                                        }

                                    },
                                    {
                                        data: "Id",
                                        "className": "text-center",
                                        render: function (data, type, row, meta) {
                                            return '<i data-toggle="tooltip"  title="Ver Panel Candidato" class="fas fa-pencil-alt" ng-click="AlmacenarDatosCandidato(&quot;' + row.Id + '&quot;,&quot;' + row.Matricula + '&quot;,&quot;' + row.Correo + '&quot;,&quot;' + row.Nombre + '&quot;)"></i>';
                                        }

                                    },
                                    {
                                        data: "Id",
                                        "className": "text-center",
                                        render: function (data, type, row, meta) {
                                            return '<i data-toggle="tooltip"  title="Ver Cv" class="far fa-file-pdf" ng-click="ReporteCurriculumAdmin(&quot;' + row.Id + '&quot;,&quot;' + row.Ruta_Foto + '&quot;,&quot;' + 'I' + '&quot;)"></i>';
                                        }

                                    },
                                    {
                                        data: "Id",
                                        "className": "text-center",
                                        render: function (data, type, row, meta) {
                                            return '<p data-toggle="tooltip"  title="Ver Estatus de las Vacantes"  ><i class="fas fa-user" data-toggle="modal" data-target="#modalStausVacantesCand" ng-click="ObtenerEstatusVacanCandidato(&quot;' + row.Id + '&quot;)"></i></p>';
                                        }

                                    }
                                ],
                                rowCallback: function (row) {
                                    if (!row.compiled) {
                                        $compile(angular.element(row))($scope);
                                        row.compiled = true;
                                    }
                                }
                            });
                        }

                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }                
                $scope.$apply();                
                $('#tablaCandidatos').show();
            });
        };

        var ObtenerGridCandidatosRegistrados = () => {
            btuContext.ObtenerGridCandidatos(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        if (self.listEmpresasRegistradas !== undefined) {
                            $('#tablaEmpresas').DataTable().clear().destroy();
                            $('#tablaEmpresas').hide();
                            $('#tablaCandidatosApl').hide();
                        }
                        $('#tablaCandidatos').DataTable().clear().destroy();
                        self.listaCandidatosRegistrados = btuContext.listaCandidatosRegistrados;

                        if (self.listaCandidatosRegistrados !== undefined && self.listaCandidatosRegistrados.length > 0) {
                            table = $('#tablaCandidatos').DataTable({
                                language: {
                                    "decimal": "",
                                    "emptyTable": "No hay información",
                                    "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                                    "infoEmpty": "Mostrando 0 de 0 a 0 Entradas",
                                    "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                                    "infoPostFix": "",
                                    "thousands": ",",
                                    "lengthMenu": "Mostrar _MENU_ Entradas",
                                    "loadingRecords": "Cargando...",
                                    "processing": "Procesando...",
                                    "search": "Buscar:",
                                    "zeroRecords": "Sin resultados encontrados",
                                    "paginate": {
                                        "first": "Primero",
                                        "last": "Último",
                                        "next": "Siguiente",
                                        "previous": "Anterior"
                                    }
                                },
                                data: self.listaCandidatosRegistrados,
                                pageLength: 4,
                                columns: [
                                    {
                                        "className": 'details-control',
                                        "orderable": false,
                                        "data": null,
                                        "defaultContent": '',
                                        "render": function () {
                                            return '<i class="fa fa-plus-square" aria-hidden="true"></i>';
                                        },
                                        width: "15px"
                                    },
                                    { data: "Matricula" },
                                    { data: "Nombre" },
                                    { data: "Celular" },
                                    { data: "Status" },
                                    {
                                        data: "Id",
                                        "className": "text-center",
                                        render: function (data, type, row, meta) {
                                            return '<p data-toggle="tooltip"  title="Cambiar Status" class"  ><i class="fas fa-info-circle" data-toggle="modal" data-target="#modalStatusCandidato" ng-click="EditStatusCand(&quot;' + row.Matricula + '&quot;,&quot;' + row.Correo + '&quot;)"></i></p>';                                                                                        
                                        }

                                    },
                                    {
                                        data: "Id",
                                        "className": "text-center",
                                        render: function (data, type, row, meta) {
                                            return '<i data-toggle="tooltip"  title="Ver Panel Candidato" class="fas fa-pencil-alt" ng-click="AlmacenarDatosCandidato(&quot;' + row.Id + '&quot;,&quot;' + row.Matricula + '&quot;,&quot;' + row.Correo + '&quot;,&quot;' + row.Nombre + '&quot;)"></i>';
                                        }

                                    },
                                    {
                                        data: "Id",
                                        "className": "text-center",
                                        render: function (data, type, row, meta) {
                                            return '<i data-toggle="tooltip"  title="Ver Cv" class="far fa-file-pdf" ng-click="ReporteCurriculumAdmin(&quot;' + row.Id + '&quot;,&quot;' + row.Ruta_Foto + '&quot;,&quot;' + 'I' + '&quot;)"></i>';
                                        }

                                    },
                                    {
                                        data: "Id",
                                        "className": "text-center",
                                        render: function (data, type, row, meta) {
                                            return '<p data-toggle="tooltip"  title="Ver Estatus de las Vacantes"  ><i class="fas fa-user" data-toggle="modal" data-target="#modalStausVacantesCand" ng-click="ObtenerEstatusVacanCandidato(&quot;' + row.Id + '&quot;)"></i></p>';
                                        }

                                    }
                                ],
                                rowCallback: function (row) {
                                    if (!row.compiled) {
                                        $compile(angular.element(row))($scope);
                                        row.compiled = true;
                                    }
                                }
                            });
                        }

                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
                $('#tablaCandidatos').show();
            });
        };

        $scope.EditStatus = (rfc, email) => {
            rfcEmpresa = rfc;
            eMailEmpresa = email;
        };

        $scope.AlmacenarDatosEmpresa = (Id, Rfc, NombreComercial) => {
            btuContext.AlmacenarDatosEmpresa(Id, Rfc, NombreComercial, function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        window.location.assign(urlServer + "Btu/PanelEmpresa");
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });            
        };

        this.EditarStatusEmpresa = () => {
            let confirmar = confirm('¿Desea cambiar el estatus de la empresa?');
            if (confirmar) {
                $('#modalStatusEmpresa').modal('toggle');
                $('#modalCargandoSolicitud').modal('show');
                btuContext.EditarStatusEmpresa(self.statusEmpresa, rfcEmpresa, self.observacionesStatus, eMailEmpresa, function (resp) {
                    switch (resp.ressult) {
                        case "tgp":
                            alert('Estatus modificado');
                            $('#modalCargandoSolicitud').modal('toggle');
                            ObtenerTotalEmpresas();
                            ObtenerGridEmpresasRegistradas();
                            break;
                        case "notgp":
                            $('#modalCargandoSolicitud').modal('toggle');
                            alert(resp.message);
                            break;
                        default:
                            $('#modalCargandoSolicitud').modal('toggle');
                            break;
                    }
                    $scope.$apply();
                });
            }
        };       

        $scope.EditStatusCand = (matricula, email) => {
            matriculaCand = matricula;
            eMailCandidato = email;
        };

        this.EditarStatusCandidato = () => {
            $('#modalStatusCandidato').modal('toggle');
            $('#modalCargandoSolicitud').modal('show');
            btuContext.EditarStatusCandidato(self.statusCandidato, matriculaCand, eMailCandidato, function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        $('#modalCargandoSolicitud').modal('toggle');
                        alert('Estatus modificado');                        
                        ObtenerTotalCandidatos();
                        ObtenerGridCandidatosRegistrados();
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        }; 

        $scope.AlmacenarDatosCandidato = (Id, Matricula, Email, NombreCandidato) => {
            btuContext.AlmacenarDatosCandidato(Id, Matricula, Email, NombreCandidato, function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        window.location.assign(urlServer + "Btu/PanelCandidato");
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        $scope.ObtenerGridVacantesPanelAdmin = (Id) => {
            $("#tablaVacantesEmpresa").focus();
            btuContext.ObtenerGridVacantesPanelAdmin(Id, function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listVacantesEmpresa = btuContext.listVacantesEmpresa;
                        if (self.listVacantesEmpresa.length === 0) {
                            self.listVacantesEmpresa.push({
                                Nombre : 'Sin Vacantes'
                            });
                        }

                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        $scope.EliminarEmpresa = (Id) => {
            let eliminar = confirm('¿Desea eliminar a la empresa?');
            if (eliminar) {
                btuContext.EliminarEmpresa(Id, function (resp) {
                    switch (resp.ressult) {
                        case "tgp":
                            alert('Empresa eliminada');
                            ObtenerGridEmpresasRegistradas();
                            break;
                        case "notgp":
                            alert(resp.message);
                            break;
                        default:
                            break;
                    }
                    $scope.$apply();
                });
            }
        };

        $scope.ObtenerEstatusVacanCandidato = (Id) => {
            btuContext.ObtenerEstatusVacanCandidato(Id, function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listStatusVacanCand = btuContext.listStatusVacanCand;
                        if (self.listStatusVacanCand.length === 0) {
                            self.listStatusVacanCand.push({
                                Nombre: 'Sin Vacantes'
                            });
                        }
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        this.ObtenerGridCandidatosAplicado = () => {
            $('#tablaCandidatosApl').modal('toggle');
            ComboVacantesAdministrador();
        }

        var ComboVacantesAdministrador = () => {
            btuContext.ComboVacantesAdministrador(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listVacantesAdministrador = btuContext.listVacantesAdministrador;
                        self.Vacante = self.listVacantesAdministrador[0].Id;
                        ObtenerGridInteresadosAdmin(self.Vacante)
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        var ObtenerGridInteresadosAdmin = (Id) => {            
            btuContext.ObtenerGridInteresados(Id, function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        if (btuContext.listInteresadosVac.length !== 0)
                            self.listInteresadosVacAdmin = btuContext.listInteresadosVac;
                        else
                            alert('Ningun candidato ha aplicado a esta vacante');
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        this.ObtenerGridInteresadosAdmin = () => {           
            btuContext.ObtenerGridInteresados(self.Vacante, function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        if (btuContext.listInteresadosVac.length !== 0)
                            self.listInteresadosVacAdmin = btuContext.listInteresadosVac;
                        else
                            alert('Ningun candidato ha aplicado a esta vacante');
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        this.ObtenerGridVacantesVencidas = () => {
            $('#tablaVacantesVencidas').modal('toggle');
            btuContext.ObtenerGridVacantesVencidas(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listVacantesVencidas = btuContext.listVacantesVencidas;
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        this.EnviarCorreoVacanteVencida = (correo, vacante) => {
            let resultado = confirm('¿Enviar correo a ' + correo + ' ?');
            if (resultado === true){
                btuContext.EnviarCorreoVacanteVencida(correo, vacante, function (resp) {
                    switch (resp.ressult) {
                        case "tgp":
                            alert('Correo enviado');
                            break;
                        case "notgp":
                            alert(resp.message);
                            break;
                        default:
                            break;
                    }
                    $scope.$apply();
                });
            }
        };

        this.GridCorreosCandidatos = () => {
            $('#tablaCorreosCandidatos').modal('toggle');
            ComboVacantesAdministrador();
        }

        var ComboVacantesAdministrador = () => {
            btuContext.ComboVacantesAdministrador(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listVacantesAdministrador = btuContext.listVacantesAdministrador;
                        self.Vacante = self.listVacantesAdministrador[0].Id;
                        ObtenerGridCorreosCandidatos();
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };       

        var ObtenerGridCorreosCandidatos = () => {            
            btuContext.ObtenerGridCorreosCandidatos(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listCorreosCandidatos = btuContext.listCorreosCandidatos;
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        }

        //Funciones para la vista Vacante

        this.GlobalInfovacante = () => {            
            let sViaja = $("#rSiViaja").is(':checked');
            let nViaja = $("#rNoViaja").is(':checked');
            let sRadica = $("#rSiRadica").is(':checked');
            let nRadica = $("#rNoRadica").is(':checked');
            let sLicencia = $("#rSiLicencia").is(':checked');
            let nLicencia = $("#rNoLicencia").is(':checked');
            let viaja = false;
            let radica = false;
            let licencia = false;

            if (sViaja === true || nViaja === true)
                viaja = true;
            if (sRadica === true || nRadica === true)
                radica = true;
            if (sLicencia === true || nLicencia == true)
                licencia = true
            
            if (self.NombreVacante !== "" && self.NumeroVacantes !== "" && self.EdadMin !== "" && self.EdadMax !== "" && self.Genero !== "" && self.EdoCivil !== "" && self.GradoEstu !== "" &&
                self.Expe !== "" && self.ActReal !== "" && self.ConoReq !== "" && self.HorioDiaLab !== "" && self.TipoSuedo !== "" && self.Salario !== "" && self.PrestacionesLab !== "" && self.UbicVacante !== "" &&
                self.IdiomaExtra != "" && self.VigIniVac !== "" && self.VigFinVac !== "" && self.TipoVacante !== "" && self.NombreVacante !== undefined && self.NumeroVacantes !== undefined &&
                self.EdadMin !== undefined && self.EdadMax !== undefined && self.Genero !== undefined && self.EdoCivil !== undefined && self.GradoEstu !== undefined && self.Expe !== undefined &&
                self.ActReal !== undefined && self.ConoReq !== undefined && self.HorioDiaLab !== undefined && self.TipoSuedo !== undefined && self.Salario !== undefined && self.PrestacionesLab !== undefined &&
                self.UbicVacante !== undefined && self.IdiomaExtra != undefined && self.VigIniVac !== undefined && self.VigFinVac !== undefined && self.TipoVacante !== undefined && viaja !== false && radica !== false &&
                licencia !== false) {
                $("#infPerfVac1").show();
                $("#infPerfVac2").hide();
                $("#globalPerfilVac").css('background-color', 'green');
                datosPerfilVacante = true;
            }
            else {
                $("#infPerfVac1").hide();
                $("#infPerfVac2").show();
                $("#globalPerfilVac").css('background-color', 'yellow');
                datosPerfilVacante = false;
            }
        };

        this.GlobalInfoEntrevista = () => {
            if (self.PersonaEntrevista !== "" && self.DiaHorarioEntre !== "" && self.DircEntre !== "" && self.TelOfc !== "" && self.Email !== "" &&
                self.PersonaEntrevista !== undefined && self.DiaHorarioEntre !== undefined && self.DircEntre !== undefined && self.TelOfc !== undefined && self.Email !== undefined) {
                $("#infoEntre1").show();
                $("#infoEntre2").hide();
                $("#globalInfoEntre").css('background-color', 'green');                
                datosInfoEntrevista = true;
            }
            else {
                $("#infoEntre1").hide();
                $("#infoEntre2").show();
                $("#globalInfoEntre").css('background-color', 'yellow');
                datosInfoEntrevista = false;
            }
        };

        this.CargarDatosPrincipalesVacante = () => {
            ComboGenero();
            ComboEdoCivil();
            ComboTipoSalario();
            ComboIdiomaExtra();
            ComboTipoVacante();
            ObtenerDatosVacante();
        };

        var ObtenerDatosVacante = () => {
            btuContext.ObtenerDatosVacante('', '',function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listDatosVacante = btuContext.listDatosVacante;
                        if (self.listDatosVacante.length > 0) {
                            let licencia = self.listDatosVacante[0].Licencia;
                            let radicar = self.listDatosVacante[0].Radicar;
                            let viajar = self.listDatosVacante[0].Viajar;
                            self.NombreVacante = self.listDatosVacante[0].Nombre;
                            self.NumeroVacantes = parseInt(self.listDatosVacante[0].Total);
                            self.EdadMin = self.listDatosVacante[0].Edad_Minima;
                            self.EdadMax = self.listDatosVacante[0].Edad_Maxima;
                            self.Genero = self.listDatosVacante[0].Genero;
                            self.EdoCivil = self.listDatosVacante[0].Estado_Civil;
                            self.GradoEstu = self.listDatosVacante[0].Grado;
                            self.Expe = self.listDatosVacante[0].Experiencia;
                            self.ActReal = self.listDatosVacante[0].Actividades;
                            self.ConoReq = self.listDatosVacante[0].Conocimientos;
                            self.HorioDiaLab = self.listDatosVacante[0].Jornada_Laboral;
                            self.TipoSuedo = self.listDatosVacante[0].Frecuencia_Salario;
                            self.Salario = self.listDatosVacante[0].Salario;
                            self.PrestacionesLab = self.listDatosVacante[0].Prestaciones;
                            self.UbicVacante = self.listDatosVacante[0].Ubicacion;
                            self.IdiomaExtra = self.listDatosVacante[0].Idioma;
                            self.VigIniVac = self.listDatosVacante[0].Vigencia_Inicio;
                            self.VigFinVac = self.listDatosVacante[0].Vigencia_Fin;
                            self.TipoVacante = self.listDatosVacante[0].Tipo;
                            self.PersonaEntrevista = self.listDatosVacante[0].Responsable_Entrevista;
                            self.DiaHorarioEntre = self.listDatosVacante[0].Especificaciones_Entrevista;
                            self.DircEntre = self.listDatosVacante[0].Direccion_Entrevista;
                            self.TelOfc = self.listDatosVacante[0].Telefono;
                            self.Email = self.listDatosVacante[0].Correo;
                            self.Comentarios = self.listDatosVacante[0].Comentarios;
                            if (licencia === "S")
                                $('#rSiLicencia').prop('checked', true);
                            else if (licencia == "N")
                                $('#rNoLicencia').prop('checked', true);
                            if (radicar === "S")
                                $('#rSiRadica').prop('checked', true);
                            else if (radicar == "N")
                                $('#rNoRadica').prop('checked', true);
                            if (viajar === "S")
                                $('#rSiViaja').prop('checked', true);
                            else if (viajar == "N")
                                $('#rNoViaja').prop('checked', true);
                            $("#datosContacto").hide();
                            $("#EditarVacante").show();
                            $("#infPerfVac1").show();
                            $("#infPerfVac2").hide();
                            $("#globalPerfilVac").css('background-color', 'green');
                            $("#infoEntre1").show();
                            $("#infoEntre2").hide();
                            $("#globalInfoEntre").css('background-color', 'green');

                        }
                        else {
                            $("#datosContacto").show();
                            $("#EditarVacante").hide();
                            self.Comentarios = "Sin Comentarios";
                        }
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        };

        this.GuardarVacante = () => {
            if (datosPerfilVacante === true && datosInfoEntrevista === true) {
                let sViaja = $("#rSiViaja").is(':checked');
                let nViaja = $("#rNoViaja").is(':checked');
                let sRadica = $("#rSiRadica").is(':checked');
                let nRadica = $("#rNoRadica").is(':checked');
                let sLicencia = $("#rSiLicencia").is(':checked');
                let nLicencia = $("#rNoLicencia").is(':checked');

                let viaja = false;
                let tipoViaja = "";
                let radica = false;
                let tipoRadica = "";
                let licencia = false;
                let tipoLicencia = "";

                if (sViaja === true || nViaja === true) {
                    viaja == true;
                    tipoViaja = sViaja === true ? "S" : "N"; // sentencia que devuelve un valor
                }
                if (sRadica === true || nRadica === true) {
                    viaja == true;
                    tipoRadica = sRadica === true ? "S" : "N"; // sentencia que devuelve un valor
                }
                if (sLicencia === true || nLicencia === true) {
                    viaja == true;
                    tipoLicencia = sLicencia === true ? "S" : "N"; // sentencia que devuelve un valor
                }
                btuContext.GuardarVacante(self.NombreVacante, self.NumeroVacantes, self.EdadMin, self.EdadMax, self.Genero, self.EdoCivil, self.GradoEstu, self.Expe, self.ActReal, self.ConoReq, self.HorioDiaLab,
                    self.TipoSuedo, self.Salario, self.PrestacionesLab, self.UbicVacante, self.IdiomaExtra, self.VigIniVac, self.VigFinVac, self.TipoVacante, self.PersonaEntrevista, self.DiaHorarioEntre,
                    self.DircEntre, self.TelOfc, self.Email, self.Comentarios, tipoViaja, tipoRadica, tipoLicencia, function (resp) {
                        switch (resp.ressult) {
                            case "tgp":
                                alert("Vacante agregada correctamente.");
                                window.location.assign(urlServer + "Btu/PanelEmpresa");
                                break;
                            case "notgp":
                                alert(resp.message);
                                break;
                            default:
                                break;
                        }
                        $scope.$apply();
                    });
            }
            else {
                alert('No se han completado todos los campos requeridos');
            }
        }

        this.EditarVacante = () => {
            let sViaja = $("#rSiViaja").is(':checked');
            let nViaja = $("#rNoViaja").is(':checked');
            let sRadica = $("#rSiRadica").is(':checked');
            let nRadica = $("#rNoRadica").is(':checked');
            let sLicencia = $("#rSiLicencia").is(':checked');
            let nLicencia = $("#rNoLicencia").is(':checked');

            let viaja = false;
            let tipoViaja = "";
            let radica = false;
            let tipoRadica = "";
            let licencia = false;
            let tipoLicencia = "";

            if (sViaja === true || nViaja === true) {
                viaja == true;
                tipoViaja = sViaja === true ? "S" : "N"; // sentencia que devuelve un valor
            }
            if (sRadica === true || nRadica === true) {
                viaja == true;
                tipoRadica = sRadica === true ? "S" : "N"; // sentencia que devuelve un valor
            }
            if (sLicencia === true || nLicencia === true) {
                viaja == true;
                tipoLicencia = sLicencia === true ? "S" : "N"; // sentencia que devuelve un valor
            }
            btuContext.EditarVacante(self.NombreVacante,
                self.NumeroVacantes, self.EdadMin, self.EdadMax, self.EdoCivil, self.GradoEstu, self.Expe, self.ActReal, self.ConoReq, self.Salario, self.TipoSuedo, self.PrestacionesLab, self.UbicVacante,
                tipoLicencia, self.VigIniVac, self.VigFinVac, self.TipoVacante, self.DircEntre, self.TelOfc, self.Email, self.Comentarios, self.PersonaEntrevista, self.DiaHorarioEntre, self.IdiomaExtra,
                tipoRadica, tipoViaja, self.Genero, self.HorioDiaLab,function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        alert("Vacante editada correctamente.");
                        window.location.assign(urlServer + "Btu/PanelEmpresa");
                        break;
                    case "notgp":
                        alert(resp.message);
                        break;
                    default:
                        break;
                }
                $scope.$apply();
            });
        }

        this.VerCandidatosDisponibles = () => {
            ComboVacantesEmpresa();
            ComboAreaConocimiento();
            $('#verCandDisp').show();
            $('#containerEmpresa').show();
        };        

        //Funciones para el detalle de las tablas
        function format(data) {
            // `d` is the original data object for the row
            if (data.Rfc !== null && data.Rfc !== "" && data.Rfc !== undefined) {
                correoStatusEmpresa = data.Email;
                return '<table cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">' +
                    '<tr>' +
                    '<th>Cargo</th>' +
                    '<th>Teléfono oficina</th>' +
                    '<th>Celular</th>' +
                    '<th>Correo electronico</th>' +
                    '<th>Usuario</th>' +
                    '<th>Contraseña</th>' +
                    '<th>Medio de contacto</th>' +
                    '<th>Código postal</th>' +
                    '<th>Persona de contacto</th>' +
                    '</tr>' +
                    '<tr>' +
                    '<td>' + data.Contacto_Cargo + '</td>' +
                    '<td>' + data.Telefono + '</td>' +
                    '<td>' + data.Celular + '</td>' +
                    '<td>' + data.Email + '</td>' +
                    '<td>' + data.Rfc + '</td>' +
                    '<td>' + data.Contrasena + '</td>' +
                    '<td>' + data.Medio_Contacto + '</td>' +
                    '<td>' + data.Codigo_Postal + '</td>' +
                    '<td>' + data.Contacto + '</td>' +
                    '</tr>' +
                    '</table>';
            }
            else if (data.Matricula !== null && data.Matricula !== "" && data.Matricula !== undefined) {
                return '<table cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">' +
                    '<tr>' +
                    '<th>Fecha de nacimiento</th>' +                    
                    '<th>Correo</th>' +
                    '<th>Contraseña</th>' +
                    '<th>Fecha de creación</th>' +                    
                    '</tr>' +
                    '<tr>' +
                    '<td>' + data.Fecha_Nacimiento + '</td>' +                    
                    '<td>' + data.Correo + '</td>' +
                    '<td>' + data.Contrasena + '</td>' +
                    '<td>' + data.Fecha_Creacion + '</td>' +
                    '</tr>' +
                    '</table>';
            }
            else if (data.Salario !== null && data.Salario !== "" && data.Salario !== undefined) {
                return '<table cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">' +
                    '<tr>' +
                    '<th>Dirección</th>' +
                    '<th>Teléfono</th>' +
                    '<th>Correo</th>' +
                    '<th>Actividades</th>' +
                    '</tr>' +
                    '<tr>' +
                    '<td>' + data.Direccion_Entrevista + '</td>' +
                    '<td>' + data.Telefono + '</td>' +
                    '<td>' + data.Correo + '</td>' +
                    '<td>' + data.Actividades + '</td>' +
                    '</tr>' +
                    '</table>';
            }
            else if (data.Carrera !== null && data.Carrera !== "" && data.Carrera !== undefined) {
                return '<table cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">' +
                    '<tr style="background-color:#89E4FF">' +
                    '<th>Fecha Inicio</th>' +
                    '<th>Fecha Egreso</th>' +
                    '</tr>' +
                    '<tr>' +
                    '<td>' + data.FechaInicio + '</td>' +
                    '<td>' + data.FechaFin + '</td>' +
                    '</tr>' +
                    '</table>';
            }
            //return 'Actividades : '+ data.Actividades + '\n  Salario: '+ data.Salario;
        }


        // Add event listener for opening and closing details
        $('#tablaVacantesEmpresa tbody').on('click', 'td.details-control', function () {
            var tr = $(this).closest('tr');
            var tdi = tr.find("i.fa");
            var row = table.row(tr);

            if (row.child.isShown()) {
                // This row is already open - close it
                row.child.hide();
                tr.removeClass('shown');
                tdi.first().removeClass('fa-minus-square');
                tdi.first().addClass('fa-plus-square');
            }
            else {
                // Open this row
                row.child(format(row.data())).show();
                tr.addClass('shown');
                tdi.first().removeClass('fa-plus-square');
                tdi.first().addClass('fa-minus-square');
            }
        });

        $('#tablaVacantesEmpresa').on('draw.dt', function () {
            $('[data-toggle="tooltip"]').tooltip();
        });

        // Add event listener for opening and closing details
        $('#tablaEmpresas tbody').on('click', 'td.details-control', function () {
            var tr = $(this).closest('tr');
            var tdi = tr.find("i.fa");
            var row = table.row(tr);

            if (row.child.isShown()) {
                // This row is already open - close it
                row.child.hide();
                tr.removeClass('shown');
                tdi.first().removeClass('fa-minus-square');
                tdi.first().addClass('fa-plus-square');
            }
            else {
                // Open this row
                row.child(format(row.data())).show();
                tr.addClass('shown');
                tdi.first().removeClass('fa-plus-square');
                tdi.first().addClass('fa-minus-square');
            }
        });

        $('#tablaEmpresas').on('draw.dt', function () {
            $('[data-toggle="tooltip"]').tooltip();
        });

        // Add event listener for opening and closing details
        $('#tablaCandidatos tbody').on('click', 'td.details-control', function () {
            var tr = $(this).closest('tr');
            var tdi = tr.find("i.fa");
            var row = table.row(tr);

            if (row.child.isShown()) {
                // This row is already open - close it
                row.child.hide();
                tr.removeClass('shown');
                tdi.first().removeClass('fa-minus-square');
                tdi.first().addClass('fa-plus-square');
            }
            else {
                // Open this row
                row.child(format(row.data())).show();
                tr.addClass('shown');
                tdi.first().removeClass('fa-plus-square');
                tdi.first().addClass('fa-minus-square');
            }
        });

        $('#tablaCandidatos').on('draw.dt', function () {
            $('[data-toggle="tooltip"]').tooltip();
        });
        // Add event listener for opening and closing details
        $('#tablaEstudiosAcademicos tbody').on('click', 'td.details-control', function () {
            var tr = $(this).closest('tr');
            var tdi = tr.find("i.fa");
            var row = table.row(tr);

            if (row.child.isShown()) {
                // This row is already open - close it
                row.child.hide();
                tr.removeClass('shown');
                tdi.first().removeClass('fa-minus-square');
                tdi.first().addClass('fa-plus-square');
            }
            else {
                // Open this row
                row.child(format(row.data())).show();
                tr.addClass('shown');
                tdi.first().removeClass('fa-plus-square');
                tdi.first().addClass('fa-minus-square');
            }
        });

        $('#tablaEstudiosAcademicos').on('draw.dt', function () {
            $('[data-toggle="tooltip"]').tooltip();
        });

        //Reportes PDF

        $scope.ReporteFichaEmpresa = function (Id, callback) {
            //abrirModal();
            var xhr = new XMLHttpRequest();
            var ruta = urlServer + 'Btu/ReporteFichaEmpresa';
            xhr.responseType = 'blob';
            xhr.open("POST", ruta, true);
            xhr.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
            xhr.onreadystatechange = function () {//Call a function when the state changes.
                if (xhr.readyState === 4 && xhr.status === 200) {
                    if (typeof window.navigator.msSaveBlob === 'function')
                        window.navigator.msSaveBlob(req.response, "PdfName-" + new Date().getTime() + ".pdf");
                    else {
                        var blob = new Blob([this.response], { type: 'application/pdf' });
                        var link = document.createElement('a');
                        link.href = window.URL.createObjectURL(blob);
                        //link.download = "report.pdf";
                        window.open(link);
                    }
                    //cerrarModal();
                }
            },
                xhr.send("IdEmpresa=" + Id);
        }; // SE EJECUTA EN EL PANEL ADMINISTRADOR

        this.ReporteVacante = function (Id) {
            //abrirModal();
            var xhr = new XMLHttpRequest();
            var ruta = urlServer + 'Btu/ReporteVacante';
            xhr.responseType = 'blob';
            xhr.open("POST", ruta, true);
            xhr.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
            xhr.onreadystatechange = function () {//Call a function when the state changes.
                if (xhr.readyState === 4 && xhr.status === 200) {
                    if (typeof window.navigator.msSaveBlob === 'function') {
                        window.navigator.msSaveBlob(req.response, "PdfName-" + new Date().getTime() + ".pdf");
                        //cerrarModal();
                    }
                    else {
                        //cerrarModal();
                        var blob = new Blob([this.response], { type: 'application/pdf' });
                        var link = document.createElement('a');
                        link.href = window.URL.createObjectURL(blob);
                        //link.download = "report.pdf";
                        window.open(link);
                    }
                }
            },

                xhr.send("Id=" + Id);
        }; // SE EJECUTA EN EL PANEL ADMINISTRADOR

        this.ReporteCurriculumEmpresa = function (Id, RutaFoto, DatosContacto, callback) {
            //abrirModal();
            var xhr = new XMLHttpRequest();
            var ruta = urlServer + 'Btu/ReporteCurriculum';
            let datosContacto = DatosContacto.charAt(0);
            xhr.responseType = 'blob';
            xhr.open("POST", ruta, true);
            xhr.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
            xhr.onreadystatechange = function () {//Call a function when the state changes.
                if (xhr.readyState === 4 && xhr.status === 200) {
                    if (typeof window.navigator.msSaveBlob === 'function') {
                        window.navigator.msSaveBlob(req.response, "PdfName-" + new Date().getTime() + ".pdf");
                        cerrarModal();
                    }
                    else {
                        var blob = new Blob([this.response], { type: 'application/pdf' });
                        var link = document.createElement('a');
                        link.href = window.URL.createObjectURL(blob);
                        //link.download = "report.pdf";
                        window.open(link);
                        cerrarModal();
                    }
                }
            },
                xhr.send("Id=" + Id + "&RutaFoto=" + RutaFoto + "&DatosContacto=" + datosContacto);
        };        

        $scope.ReporteCurriculumAdmin = function (Id, RutaFoto, DatosContacto, callback) {
            //abrirModal();
            var xhr = new XMLHttpRequest();
            var ruta = urlServer + 'Btu/ReporteCurriculum';
            xhr.responseType = 'blob';
            xhr.open("POST", ruta, true);
            xhr.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
            xhr.onreadystatechange = function () {//Call a function when the state changes.
                if (xhr.readyState === 4 && xhr.status === 200) {
                    if (typeof window.navigator.msSaveBlob === 'function') {
                        window.navigator.msSaveBlob(req.response, "PdfName-" + new Date().getTime() + ".pdf");
                        //cerrarModal();
                    }
                    else {
                        //cerrarModal();
                        var blob = new Blob([this.response], { type: 'application/pdf' });
                        var link = document.createElement('a');
                        link.href = window.URL.createObjectURL(blob);
                        //link.download = "report.pdf";
                        window.open(link);
                    }
                }
            },

                xhr.send("Id=" + Id + "&RutaFoto=" + RutaFoto + "&DatosContacto=" + DatosContacto);
        };

    }]);
})();