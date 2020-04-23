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


        let datosPersonales = false;
        let datosAcademicos = false;
        let datosExpProfesional = false;
        let existeImagenPerfilCv = false;

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
                                alert("Los datos se han guardado correctamente.");
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
                    self.CarreraExt !== undefined && self.GradoEst !== '' && self.NombEsc !== '' && self.Carrera !== '' && self.AreaConoc !== '' && self.FechaIniCarrera !== '' && self.FechaFinCarrera !== '' && self.CarreraExt !== "" ) {
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
                        if (self.listDatosRegistroUnach[0].Ruta_Foto !== undefined && self.listDatosRegistroUnach[0].Ruta_Foto !== "" && self.listDatosRegistroUnach[0].Ruta_Foto !== null)
                            $("#imgCadidato").attr("src", self.listDatosRegistroUnach[0].Ruta_Foto);                            
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

                let d1 = new Date(self.FecNac);
                let month = (d1.getMonth() + 1);
                let nuevomes = month >= 10 ? month : '0' + month;
                let day = d1.getDate();
                let year = d1.getFullYear();
                let date1 = day + '/' + nuevomes + '/' + year;

                btuContext.GuardarInformacionCandidato(self.Matricula, self.NombreCandidato, self.ApePatCandidato, self.ApeMatCandidato, date1, self.Estado,
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
                }
                else
                    alert("No se han completado los campos requeridos.");
            }
            else
                alert("¡Aún no hay imagen de perfil!");
        };

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
                        alert("Algo ha fallado: " + textStatus);
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
                            var rutaImg = "../Imagenes/ImgProfileCv/" + nombreFoto  +"."+ formatoFoto;
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
            btuContext.ComboCarreras( function (resp) {
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

        //Funciones para la vista Btu

        this.IniciarSesion = (Tipo) =>{
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

        //Funciones para la vista Panel Candidato

        this.DatosPanelCandidato = () => {
            CargarDatosPanelCV();
            CargarInfoVacCand();
        };

        var CargarDatosPanelCV = () => {
            btuContext.CargarDatosPanelCV(function (resp) {
                switch (resp.ressult) {
                    case "tgp":
                        self.listDatosPanel = btuContext.listDatosPanelCv;
                        self.IdUsuario = self.listDatosPanel[0].Id;
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

        var CargarInfoVacCand = () => {

        };

        this.GuardarIdCv = function (IdCv) {
            btuContext.GuardarIdCv(IdCv, function (resp) {
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
                $scope.$apply;
            });
        };
    }]);
})();