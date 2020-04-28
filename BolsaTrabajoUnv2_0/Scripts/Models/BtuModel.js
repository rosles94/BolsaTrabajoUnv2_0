﻿/// <reference path="../global.js"/>

var btuContext =
{
    listDatosExistEmpr: [],    
    listEstados: [],
    listMunicipios: [],
    listTipoPersona: [],
    listMedioContacto: [],
    listGradoEstudios: [],
    listCarreras: [],
    listAreaConocimiento: [],
    listNvlSoft: [],
    listNvlIdi: [],
    listTipoCurso: [],
    listSesionUnach: [],
    listDatosRegistroUnach: [],
    listEstAcadGuardados: [],
    listSoftware: [],
    listIdioma: [],
    listExperienciaProf: [],
    listCursoTaller: [],
    listDatosPanelCv: [],
    listDatosPanelEmpresa: [],
    listDatosEmpresa : [],


    BuscarEmpresa: function (Rfc, callBackResult) {
        let self = this;
        self.listDatosExistEmpr.length = 0;
        $.ajax({
            beforeSend: function () {
                $('#buscandoEmpresa').show()
            },
            type: "POST",            
            url: urlServer + "Btu/BuscarEmpresa",
            data: { Rfc },
            success: function (resp) {
                if (resp.Error === false) {
                    for (var i = 0; i < resp.Resultado.length; i++) {
                        self.listDatosExistEmpr.push({
                            Existe: resp.Resultado[i].Existe
                        });
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            complete: function () {
                $('#buscandoEmpresa').hide()
            }
        });
    },

    ComboEstados: function (callBackResult) {
        let self = this;
        self.listEstados.length = 0;
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/ComboEstados",
            data: {  },
            success: function (resp) {
                if (resp.Error === false) {
                    for (var i = 0; i < resp.Resultado.length; i++) {
                        self.listEstados.push({
                            Id: resp.Resultado[i].Id, Descripcion: resp.Resultado[i].Descripcion
                        });
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            }
        });
    },

    ComboMunicipios: function (Estado, callBackResult) {
        let self = this;
        self.listMunicipios.length = 0;
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/ComboMunicipios",
            data: { Estado },
            success: function (resp) {
                if (resp.Error === false) {
                    for (var i = 0; i < resp.Resultado.length; i++) {
                        self.listMunicipios.push({
                            Id: resp.Resultado[i].Id, Descripcion: resp.Resultado[i].Descripcion
                        });
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            }
        });
    },

    ComboTipoPersona: function (callBackResult) {
        let self = this;
        self.listTipoPersona.length = 0;
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/ComboTipoPersona",
            data: {  },
            success: function (resp) {
                if (resp.Error === false) {
                    for (var i = 0; i < resp.Resultado.length; i++) {
                        self.listTipoPersona.push({
                            Id: resp.Resultado[i].Id, Descripcion: resp.Resultado[i].Descripcion
                        });
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            }
        });
    },

    ComboMedioContacto: function (callBackResult) {
        let self = this;
        self.listMedioContacto.length = 0;
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/ComboMedioContacto",
            data: {},
            success: function (resp) {
                if (resp.Error === false) {
                    for (var i = 0; i < resp.Resultado.length; i++) {
                        self.listMedioContacto.push({
                            Id: resp.Resultado[i].Id, Descripcion: resp.Resultado[i].Descripcion
                        });
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            }
        });
    },

    RegistrarDatosEmpresa: function (RazonSocial, NombreComercial, Actividad, CodigoPostal, Estado, Ciudad, Colonia, Domicilio, Rfc,
        Contacto, ContactoCargo, Telefono, Celular, Email, MedioContacto, Contrasena, TipoPersona, callBackResult) {        
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/BuscarEmpresa",
            data: {
                RazonSocial, NombreComercial, Actividad, CodigoPostal, Estado, Ciudad, Colonia, Domicilio, Rfc,
                Contacto, ContactoCargo, Telefono, Celular, Email, MedioContacto, Contrasena, TipoPersona},
            success: function (resp) {
                if (resp.Error === false)                
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: ex });
            }
        });
    },

    GuardarInformacionCandidato: function (Matricula, NombreCandidato, ApePatCandidato, ApeMatCandidato, FecNac, Estado,
    Municipio, Domicilio, TelCel, TelAd, Email, AreaInt, ObjPersonal, Sexo, callBackResult) {
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/GuardarInformacionCandidato",
            data: {
                Matricula, NombreCandidato, ApePatCandidato, ApeMatCandidato, FecNac, Estado,
                Municipio, Domicilio, TelCel, TelAd, Email, AreaInt, ObjPersonal, Sexo
            },
            success: function (resp) {
                if (resp.Error === false)
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: ex });
            }
        });
    },

    GuardarEstudiosAcademicos: function (GradoEst, NombEsc, IdCarrera, AreaConoc, FechaIni, FechaFin, Carrera, DescGradoEstu, callBackResult) {
        let self = this;
        self.listEstAcadGuardados.length = 0;
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/GuardarEstudiosAcademicos",
            data: {
                GradoEst, NombEsc, IdCarrera, AreaConoc, FechaIni, FechaFin, Carrera, DescGradoEstu
            },
            success: function (resp) {
                if (resp.Error === false) {
                    for (var i = 0; i < resp.Resultado.length; i++) {
                        let IsPrincipal = resp.Resultado[i].Principal === "N" ? 'fas fa-check-square' : '';
                        self.listEstAcadGuardados.push({
                            Tipo: resp.Resultado[i].Tipo, Subtipo: resp.Resultado[i].Subtipo,
                            Institucion: resp.Resultado[i].Institucion, Id_Carrera: resp.Resultado[i].Id_Carrera,
                            Carrera: resp.Resultado[i].Carrera, Area: resp.Resultado[i].Area,
                            Fecha_Inicio: resp.Resultado[i].Fecha_Inicio, Fecha_Fin: resp.Resultado[i].Fecha_Fin,
                            Descripcion: resp.Resultado[i].Descripcion, Principal: resp.Resultado[i].Principal,
                            Contacto: resp.Resultado[i].Contacto, Posicion: i, IsPrincipal
                        });
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: ex });
            }
        });
    },

    ComboGradoEstudios: function (callBackResult) {
        let self = this;
        self.listGradoEstudios.length = 0;
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/ComboGradoEstudios",
            data: {},
            success: function (resp) {
                if (resp.Error === false) {
                    for (var i = 0; i < resp.Resultado.length; i++) {
                        self.listGradoEstudios.push({
                            Id: resp.Resultado[i].Id, Descripcion: resp.Resultado[i].Descripcion
                        });
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            }
        });
    },

    ComboCarreras: function (callBackResult) {
        let self = this;
        self.listCarreras.length = 0;
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/ComboCarreras",
            data: {},
            success: function (resp) {
                if (resp.Error === false) {
                    for (var i = 0; i < resp.Resultado.length; i++) {
                        self.listCarreras.push({
                            Id: resp.Resultado[i].Id, Descripcion: resp.Resultado[i].Descripcion
                        });
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            }
        });
    },

    ComboAreaConocimiento: function (callBackResult) {
        let self = this;
        self.listAreaConocimiento.length = 0;
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/ComboAreaConocimiento",
            data: {},
            success: function (resp) {
                if (resp.Error === false) {
                    for (var i = 0; i < resp.Resultado.length; i++) {
                        self.listAreaConocimiento.push({
                            Id: resp.Resultado[i].Id, Descripcion: resp.Resultado[i].Descripcion
                        });
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            }
        });
    },

    ComboNivelSoftware: function (Subtipo, callBackResult) {
        let self = this;        
        self.listNvlSoft.length = 0;
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/ComboSubtipos",
            data: { Subtipo},
            success: function (resp) {
                if (resp.Error === false) {
                    for (var i = 0; i < resp.Resultado.length; i++) {
                        self.listNvlSoft.push({
                            Id: resp.Resultado[i].Id, Descripcion: resp.Resultado[i].Descripcion
                        });
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            }
        });
    },

    ComboNivelIdioma: function (Subtipo, callBackResult) {
        let self = this;
        self.listNvlIdi.length = 0;
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/ComboSubtipos",
            data: { Subtipo },
            success: function (resp) {
                if (resp.Error === false) {
                    for (var i = 0; i < resp.Resultado.length; i++) {
                        self.listNvlIdi.push({
                            Id: resp.Resultado[i].Id, Descripcion: resp.Resultado[i].Descripcion
                        });
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            }
        });
    },

    ComboTipoCurso: function (callBackResult) {
        let self = this;
        self.listTipoCurso.length = 0;
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/ComboTipoCurso",
            data: { },
            success: function (resp) {
                if (resp.Error === false) {
                    for (var i = 0; i < resp.Resultado.length; i++) {
                        self.listTipoCurso.push({
                            Id: resp.Resultado[i].Id, Descripcion: resp.Resultado[i].Descripcion
                        });
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            }
        });
    },

    GuardarSoftware: function (Software, Nivel, callBackResult) {
        let self = this;
        self.listSoftware.length = 0;
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/GuardarSoftware",
            data: {
                Software, Nivel
            },
            success: function (resp) {
                if (resp.Error === false) {
                    for (var i = 0; i < resp.Resultado.length; i++) {
                        self.listSoftware.push({
                            Tipo: resp.Resultado[i].Tipo, Subtipo: resp.Resultado[i].Subtipo, Descripcion: resp.Resultado[i].Descripcion,
                            Principal: resp.Resultado[i].Principal, Fecha_Inicio: resp.Resultado[i].Fecha_Inicio, Fecha_Fin: resp.Resultado[i].Fecha_Fin,
                            Posicion: i
                        });
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: ex });
            }
        });
    },   

    GuardarIdioma: function (Idioma, Nivel, callBackResult) {
        let self = this;
        self.listIdioma.length = 0;
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/GuardarIdioma",
            data: {
                Idioma, Nivel
            },
            success: function (resp) {
                if (resp.Error === false) {
                    for (var i = 0; i < resp.Resultado.length; i++) {
                        self.listIdioma.push({
                            Tipo: resp.Resultado[i].Tipo, Subtipo: resp.Resultado[i].Subtipo, Descripcion: resp.Resultado[i].Descripcion,
                            Principal: resp.Resultado[i].Principal, Fecha_Inicio: resp.Resultado[i].Fecha_Inicio, Fecha_Fin: resp.Resultado[i].Fecha_Fin,
                            Posicion : i
                        });
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: ex });
            }
        });
    },

    GuardarExperienciaProfesional: function (NombreEmpresa, FechaIniExpProf, FechaFinExpProf, DescAct, ReferenciaTrabajo, callBackResult) {
        let self = this;
        self.listExperienciaProf.length = 0;
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/GuardarExpProfesional",
            data: {
                NombreEmpresa, FechaIniExpProf, FechaFinExpProf, DescAct, ReferenciaTrabajo
            },
            success: function (resp) {
                if (resp.Error === false) {
                    for (var i = 0; i < resp.Resultado.length; i++) {
                        self.listExperienciaProf.push({
                            Tipo: resp.Resultado[i].Tipo, Subtipo: resp.Resultado[i].Subtipo, Descripcion: resp.Resultado[i].Descripcion,
                            Principal: resp.Resultado[i].Principal, Fecha_Inicio: resp.Resultado[i].Fecha_Inicio, Fecha_Fin: resp.Resultado[i].Fecha_Fin,
                            Contacto: resp.Resultado[i].Contacto, Institucion: resp.Resultado[i].Institucion, Posicion: i
                        });
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: ex });
            }
        });
    },

    GuardarCursoTaller: function (CursoTaller, TipoCurso, InstTaller, FecIniCur, FecFinCur, callBackResult) {
        let self = this;
        self.listCursoTaller.length = 0;
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/GuardarCursoTaller",
            data: {
                CursoTaller, TipoCurso, InstTaller, FecIniCur, FecFinCur
            },
            success: function (resp) {
                if (resp.Error === false) {
                    for (var i = 0; i < resp.Resultado.length; i++) {
                        self.listCursoTaller.push({
                            Tipo: resp.Resultado[i].Tipo, Subtipo: resp.Resultado[i].Subtipo, Descripcion: resp.Resultado[i].Descripcion,
                            Principal: resp.Resultado[i].Principal, Fecha_Inicio: resp.Resultado[i].Fecha_Inicio, Fecha_Fin: resp.Resultado[i].Fecha_Fin,
                            Contacto: resp.Resultado[i].Contacto, Institucion: resp.Resultado[i].Institucion, Posicion: i
                        });
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: ex });
            }
        });
    },

    IniciarSesion: function (Usuario, Contrasena, Tipo, callBackResult) {
        let self = this;
        self.listSesionUnach.length = 0;
        $.ajax({
            beforeSend: function () {
                $("#cargandoDatos").show();
                $("#modalEmpresa").modal('toggle');
            },
            type: "POST",
            url: urlServer + "Btu/IniciarSesion",
            data: {
                Usuario, Contrasena, Tipo
            },
            success: function (resp) {
                if (resp.Error === false) {
                    for (var i = 0; i < resp.Resultado.length; i++) {
                        self.listSesionUnach.push({
                            Existe: resp.Resultado[i].Existe, Matricula: resp.Resultado[i].Matricula, Nombre: resp.Resultado[i].Nombre, Registrado: resp.Resultado[i].Registrado,
                            Id: resp.Resultado[i].Id, Email2: resp.Resultado[i].Email2
                        });
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }                    
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: ex });
            },
            complete: function () {
                $("#cargandoDatos").hide();
            }
        });
    },
    IniciarSesionEmpresa: function (Usuario, Contrasena, Tipo, callBackResult) {
        let self = this;
        self.listSesionUnach.length = 0;
        $.ajax({
            beforeSend: function () {
                $("#cargandoDatos").show();
                $("#modalEmpresa").modal('toggle');
            },
            type: "POST",
            url: urlServer + "Btu/IniciarSesionEmpresa",
            data: {
                Usuario, Contrasena, Tipo
            },
            success: function (resp) {
                if (resp.Error === false) {
                    for (var i = 0; i < resp.Resultado.length; i++) {
                        self.listSesionUnach.push({
                            Existe: resp.Resultado[i].Existe, Matricula: resp.Resultado[i].Matricula, Nombre: resp.Resultado[i].Nombre, Registrado: resp.Resultado[i].Registrado,
                            Id: resp.Resultado[i].Id, Email2: resp.Resultado[i].Email2
                        });
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: ex });
            },
            complete: function () {
                $("#cargandoDatos").hide();
            }
        });
    },
    IniciarSesionAdmin: function (Usuario, Contrasena, callBackResult) {        
        $.ajax({
            beforeSend: function () {
                $("#cargandoDatos").show();
                $("#modalAdministrador").modal('toggle');
            },
            type: "POST",
            url: urlServer + "Btu/IniciarSesionAdmin",
            data: {
                Usuario, Contrasena
            },
            success: function (resp) {
                if (resp.Error === false) {                    
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: ex });
            },
            complete: function () {
                $("#cargandoDatos").hide();
            }
        });
    },

    DatosRegistroUnach: function (callBackResult) {
        let self = this;
        self.listDatosRegistroUnach.length = 0;
        $.ajax({
            beforeSend: function () {
                $("#cargandoDatos").show();
            },
            type: "POST",
            url: urlServer + "Btu/DatosRegistroUnach",
            data: {                
            },
            success: function (resp) {
                if (resp.Error === false) {
                    for (var i = 0; i < resp.Resultado.length; i++) {
                        self.listDatosRegistroUnach.push({
                            Matricula: resp.Resultado[i].Matricula, Paterno: resp.Resultado[i].Paterno,
                            Materno: resp.Resultado[i].Materno, Nombre: resp.Resultado[i].Nombre,
                            Domicilio: resp.Resultado[i].Domicilio, Municipio: resp.Resultado[i].Municipio,
                            Estado: resp.Resultado[i].Estado, FechaNacimiento: resp.Resultado[i].Fecha_Nacimiento,
                            Telefono: resp.Resultado[i].Telefono, Celular: resp.Resultado[i].Celular,
                            Correo: resp.Resultado[i].Correo, Contrasena: resp.Resultado[i].Contrasena,
                            Genero: resp.Resultado[i].Genero, Dependencia: resp.Resultado[i].Dependencia,
                            Carrera: resp.Resultado[i].Carrera, IdCarrera: resp.Resultado[i].IdCarrera,
                            Id: resp.Resultado[i].Id, Ruta_Foto: resp.Resultado[i].Ruta_Foto, Objetivo: resp.Resultado[i].Objetivo,
                            Intereses: resp.Resultado[i].Intereses, Registrado : resp.Resultado[i].Registrado
                        });
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: ex });
            },
            complete: function () {
                $("#cargandoDatos").hide();
                $("#formularioDatos").show();
            }
        });
    },

    EliminarEstudioAcademico: function (Posicion, callBackResult) {
        let self = this;
        self.listEstAcadGuardados.length = 0;
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/EliminarEstudioAcademico",
            data: {
                Posicion
            },
            success: function (resp) {
                if (resp.Error === false) {
                    for (var i = 0; i < resp.Resultado.length; i++) {
                        let IsPrincipal = resp.Resultado[i].Principal === "N" ? 'fas fa-check-square' : '';
                        self.listEstAcadGuardados.push({
                            Tipo: resp.Resultado[i].Tipo, Subtipo: resp.Resultado[i].Subtipo,
                            Institucion: resp.Resultado[i].Institucion, Id_Carrera: resp.Resultado[i].Id_Carrera,
                            Carrera: resp.Resultado[i].Carrera, Area: resp.Resultado[i].Area,
                            Fecha_Inicio: resp.Resultado[i].Fecha_Inicio, Fecha_Fin: resp.Resultado[i].Fecha_Fin,
                            Descripcion: resp.Resultado[i].Descripcion, Principal: resp.Resultado[i].Principal,
                            Contacto: resp.Resultado[i].Contacto, Posicion: i, IsPrincipal
                        });
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: ex });
            }
        });
    },

    EliminarSoftware: function (Posicion, callBackResult) {
        let self = this;
        self.listSoftware.length = 0;
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/EliminarSoftware",
            data: {
                Posicion
            },
            success: function (resp) {
                if (resp.Error === false) {
                    for (var i = 0; i < resp.Resultado.length; i++) {
                        self.listSoftware.push({
                            Tipo: resp.Resultado[i].Tipo, Subtipo: resp.Resultado[i].Subtipo,
                            Institucion: resp.Resultado[i].Institucion, Id_Carrera: resp.Resultado[i].Id_Carrera,
                            Carrera: resp.Resultado[i].Carrera, Area: resp.Resultado[i].Area,
                            Fecha_Inicio: resp.Resultado[i].Fecha_Inicio, Fecha_Fin: resp.Resultado[i].Fecha_Fin,
                            Descripcion: resp.Resultado[i].Descripcion, Principal: resp.Resultado[i].Principal,
                            Contacto: resp.Resultado[i].Contacto, Posicion: i
                        });
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: ex });
            }
        });
    },

    EliminarIdioma: function (Posicion, callBackResult) {
        let self = this;
        self.listIdioma.length = 0;
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/EliminarIdioma",
            data: {
                Posicion
            },
            success: function (resp) {
                if (resp.Error === false) {
                    for (var i = 0; i < resp.Resultado.length; i++) {
                        self.listIdioma.push({
                            Tipo: resp.Resultado[i].Tipo, Subtipo: resp.Resultado[i].Subtipo,
                            Institucion: resp.Resultado[i].Institucion, Id_Carrera: resp.Resultado[i].Id_Carrera,
                            Carrera: resp.Resultado[i].Carrera, Area: resp.Resultado[i].Area,
                            Fecha_Inicio: resp.Resultado[i].Fecha_Inicio, Fecha_Fin: resp.Resultado[i].Fecha_Fin,
                            Descripcion: resp.Resultado[i].Descripcion, Principal: resp.Resultado[i].Principal,
                            Contacto: resp.Resultado[i].Contacto, Posicion: i
                        });
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: ex });
            }
        });
    },

    EliminarExperienciaProfesional: function (Posicion, callBackResult) {
        let self = this;
        self.listExperienciaProf.length = 0;
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/EliminarExperienciaProfesional",
            data: {
                Posicion
            },
            success: function (resp) {
                if (resp.Error === false) {
                    for (var i = 0; i < resp.Resultado.length; i++) {
                        self.listExperienciaProf.push({
                            Tipo: resp.Resultado[i].Tipo, Subtipo: resp.Resultado[i].Subtipo,
                            Institucion: resp.Resultado[i].Institucion, Id_Carrera: resp.Resultado[i].Id_Carrera,Carrera: resp.Resultado[i].Carrera, Area: resp.Resultado[i].Area,
                            Fecha_Inicio: resp.Resultado[i].Fecha_Inicio, Fecha_Fin: resp.Resultado[i].Fecha_Fin,Descripcion: resp.Resultado[i].Descripcion, Principal: resp.Resultado[i].Principal,
                            Contacto: resp.Resultado[i].Contacto, Posicion: i
                        });
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: ex });
            }
        });
    },

    EliminarCursoTaller: function (Posicion, callBackResult) {
        let self = this;
        self.listCursoTaller.length = 0;
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/EliminarCursotaller",
            data: {
                Posicion
            },
            success: function (resp) {
                if (resp.Error === false) {
                    for (var i = 0; i < resp.Resultado.length; i++) {
                        self.listCursoTaller.push({
                            Tipo: resp.Resultado[i].Tipo, Subtipo: resp.Resultado[i].Subtipo,
                            Institucion: resp.Resultado[i].Institucion, Id_Carrera: resp.Resultado[i].Id_Carrera, Carrera: resp.Resultado[i].Carrera, Area: resp.Resultado[i].Area,
                            Fecha_Inicio: resp.Resultado[i].Fecha_Inicio, Fecha_Fin: resp.Resultado[i].Fecha_Fin, Descripcion: resp.Resultado[i].Descripcion, Principal: resp.Resultado[i].Principal,
                            Contacto: resp.Resultado[i].Contacto, Posicion: i
                        });
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: ex });
            }
        });
    },

    GuardarInfoGeneralCandidato: function (callBackResult) {
        $.ajax({
            beforeSend: function () {
                $("#cargandoDatos").show();
            },
            type: "POST",
            url: urlServer + "Btu/GuardarInfoGeneralCandidato",
            data: {                
            },
            success: function (resp) {
                if (resp.Error === false) {                   
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: ex });
            },
            complete: function () {
                $('#buscandoEmpresa').hide()
            }
        });
    },

    EditarInfoGeneralCandidato: function (callBackResult) {
        $.ajax({
            beforeSend: function () {
                $("#cargandoDatos").show();
            },
            type: "POST",
            url: urlServer + "Btu/EditarInfoGeneralCandidato",
            data: {
            },
            success: function (resp) {
                if (resp.Error === false) {
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: ex });
                $("#cargandoDatos").hide();
            },
            complete: function () {
                $("#cargandoDatos").hide();
            }
        });
    },

    EditarPrincipalEstAcad: function (Posicion, callBackResult) {
        let self = this;
        self.listEstAcadGuardados.length = 0;
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/EditarPrincipalEstAcad",
            data: {
                Posicion
            },
            success: function (resp) {
                if (resp.Error === false) {
                    for (var i = 0; i < resp.Resultado.length; i++) {
                        let IsPrincipal = resp.Resultado[i].Principal === "N" ? 'fas fa-check-square' : '';
                        self.listEstAcadGuardados.push({
                            Tipo: resp.Resultado[i].Tipo, Subtipo: resp.Resultado[i].Subtipo,
                            Institucion: resp.Resultado[i].Institucion, Id_Carrera: resp.Resultado[i].Id_Carrera,
                            Carrera: resp.Resultado[i].Carrera, Area: resp.Resultado[i].Area,
                            Fecha_Inicio: resp.Resultado[i].Fecha_Inicio, Fecha_Fin: resp.Resultado[i].Fecha_Fin,
                            Descripcion: resp.Resultado[i].Descripcion, Principal: resp.Resultado[i].Principal,
                            Contacto: resp.Resultado[i].Contacto, Posicion: i, IsPrincipal
                        });
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: ex });
            }
        });
    },

    GuardarIdCv: function (Id, callBackResult) {        
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/GuardarIdCv",
            data: {
                Id
            },
            success: function (resp) {
                if (resp.Error === false) {                    
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: ex });
            }
        });
    },

    CargarDatosPanelCV: function (callBackResult) {
        let self = this;
        self.listDatosPanelCv.length = 0;
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/CargarDatosPanelCV",
            data: {
                
            },
            success: function (resp) {
                if (resp.Error === false) {
                    for (var i = 0; i < resp.Resultado.length; i++) {                        
                        self.listDatosPanelCv.push({
                            Id: resp.Resultado[i].Id
                        });
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: ex });
            }
        });
    },

    ObtenerEstududiosAcademicos: function (callBackResult) {
        let self = this;
        self.listEstAcadGuardados.length = 0;
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/ObtenerEstudiosAcademicos",
            data: {                
            },
            success: function (resp) {
                if (resp.Error === false) {
                    for (var i = 0; i < resp.Resultado.length; i++) {
                        let IsPrincipal = resp.Resultado[i].Principal === "N" ? 'fas fa-check-square' : '';
                        self.listEstAcadGuardados.push({
                            Tipo: resp.Resultado[i].Tipo, Subtipo: resp.Resultado[i].Subtipo,
                            Institucion: resp.Resultado[i].Institucion, Id_Carrera: resp.Resultado[i].Id_Carrera,
                            Carrera: resp.Resultado[i].Carrera, Area: resp.Resultado[i].Area,
                            Fecha_Inicio: resp.Resultado[i].Fecha_Inicio, Fecha_Fin: resp.Resultado[i].Fecha_Fin,
                            Descripcion: resp.Resultado[i].Descripcion, Principal: resp.Resultado[i].Principal,
                            Contacto: resp.Resultado[i].Contacto, Posicion: i, IsPrincipal
                        });
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: ex });
            }
        });
    },

    ObtenerSoftware: function (callBackResult) {
        let self = this;
        self.listSoftware.length = 0;
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/ObtenerSoftware",
            data: {
            },
            success: function (resp) {
                if (resp.Error === false) {
                    for (var i = 0; i < resp.Resultado.length; i++) {                        
                        self.listSoftware.push({
                            Tipo: resp.Resultado[i].Tipo, Subtipo: resp.Resultado[i].Subtipo,
                            Institucion: resp.Resultado[i].Institucion, Id_Carrera: resp.Resultado[i].Id_Carrera,
                            Carrera: resp.Resultado[i].Carrera, Area: resp.Resultado[i].Area,
                            Fecha_Inicio: resp.Resultado[i].Fecha_Inicio, Fecha_Fin: resp.Resultado[i].Fecha_Fin,
                            Descripcion: resp.Resultado[i].Descripcion, Principal: resp.Resultado[i].Principal,
                            Contacto: resp.Resultado[i].Contacto, Posicion: i
                        });
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: ex });
            }
        });
    },

    ObtenerIdioma: function (callBackResult) {
        let self = this;
        self.listIdioma.length = 0;
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/ObtenerIdioma",
            data: {
            },
            success: function (resp) {
                if (resp.Error === false) {
                    for (var i = 0; i < resp.Resultado.length; i++) {
                        self.listIdioma.push({
                            Tipo: resp.Resultado[i].Tipo, Subtipo: resp.Resultado[i].Subtipo,
                            Institucion: resp.Resultado[i].Institucion, Id_Carrera: resp.Resultado[i].Id_Carrera,
                            Carrera: resp.Resultado[i].Carrera, Area: resp.Resultado[i].Area,
                            Fecha_Inicio: resp.Resultado[i].Fecha_Inicio, Fecha_Fin: resp.Resultado[i].Fecha_Fin,
                            Descripcion: resp.Resultado[i].Descripcion, Principal: resp.Resultado[i].Principal,
                            Contacto: resp.Resultado[i].Contacto, Posicion: i
                        });
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: ex });
            }
        });
    },

    ObtenerExpProf: function (callBackResult) {
        let self = this;
        self.listExperienciaProf.length = 0;
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/ObtenerExpProf",
            data: {
            },
            success: function (resp) {
                if (resp.Error === false) {
                    for (var i = 0; i < resp.Resultado.length; i++) {
                        self.listExperienciaProf.push({
                            Tipo: resp.Resultado[i].Tipo, Subtipo: resp.Resultado[i].Subtipo,
                            Institucion: resp.Resultado[i].Institucion, Id_Carrera: resp.Resultado[i].Id_Carrera,
                            Carrera: resp.Resultado[i].Carrera, Area: resp.Resultado[i].Area,
                            Fecha_Inicio: resp.Resultado[i].Fecha_Inicio, Fecha_Fin: resp.Resultado[i].Fecha_Fin,
                            Descripcion: resp.Resultado[i].Descripcion, Principal: resp.Resultado[i].Principal,
                            Contacto: resp.Resultado[i].Contacto, Posicion: i
                        });
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: ex });
            }
        });
    },

    ObtenerCursoTaller: function (callBackResult) {
        let self = this;
        self.listCursoTaller.length = 0;
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/ObtenerCursoTaller",
            data: {
            },
            success: function (resp) {
                if (resp.Error === false) {
                    for (var i = 0; i < resp.Resultado.length; i++) {                        
                        self.listCursoTaller.push({
                            Tipo: resp.Resultado[i].Tipo, Subtipo: resp.Resultado[i].Subtipo,
                            Institucion: resp.Resultado[i].Institucion, Id_Carrera: resp.Resultado[i].Id_Carrera,
                            Carrera: resp.Resultado[i].Carrera, Area: resp.Resultado[i].Area,
                            Fecha_Inicio: resp.Resultado[i].Fecha_Inicio, Fecha_Fin: resp.Resultado[i].Fecha_Fin,
                            Descripcion: resp.Resultado[i].Descripcion, Principal: resp.Resultado[i].Principal,
                            Contacto: resp.Resultado[i].Contacto, Posicion: i
                        });
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: ex });
            }
        });
    },

    CargarDatosPanelEmpresa: function (callBackResult) {
        let self = this;
        self.listDatosPanelEmpresa.length = 0;
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/CargarDatosPanelEmpresa",
            data: {
            },
            success: function (resp) {
                if (resp.Error === false) {
                    for (var i = 0; i < resp.Resultado.length; i++) {
                        self.listDatosPanelEmpresa.push({
                            Id_Empresa: resp.Resultado[i].Id_Empresa
                        });
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: ex });
            }
        });
    },
    ObtenerDatosEmpresa: function (callBackResult) {
        let self = this;
        self.listDatosEmpresa.length = 0;
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/ObtenerDatosEmpresa",
            data: {                
            },
            success: function (resp) {
                if (resp.Error === false) {
                    if (resp.Resultado !== null) {
                        for (var i = 0; i < resp.Resultado.length; i++) {
                            self.listDatosEmpresa.push({
                                Actividad: resp.Resultado[i].Actividad,
                                Giro: resp.Resultado[i].Giro, Institucion: resp.Resultado[i].Institucion, Status: resp.Resultado[i].Status, Validado: resp.Resultado[i].Validado,
                                Contrasena: resp.Resultado[i].Contrasena, Medio_Contacto: resp.Resultado[i].Medio_Contacto, Celular: resp.Resultado[i].Celular,
                                Contacto_Cargo: resp.Resultado[i].Contacto_Cargo, Email: resp.Resultado[i].Email, Contacto: resp.Resultado[i].Contacto, Telefono: resp.Resultado[i].Telefono,
                                Estado: resp.Resultado[i].Estado, Ciudad: resp.Resultado[i].Ciudad, Codigo_Postal: resp.Resultado[i].Codigo_Postal, Colonia: resp.Resultado[i].Colonia,
                                Domicilio: resp.Resultado[i].Domicilio, Nombre_Comercial: resp.Resultado[i].Nombre_Comercial, Razon_Social: resp.Resultado[i].Razon_Social,
                                Ruta_Foto: resp.Resultado[i].Ruta_Foto, Tipo_Persona: resp.Resultado[i].Tipo_Persona, Id_Empresa: resp.Resultado[i].Id_Empresa, Rfc: resp.Resultado[i].Rfc
                            });
                        }
                    }
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                }
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: ex });
            }
        });
    },

    EditarDatosEmpresa: function (RazonSocial, NombreComercial, Actividad, CodigoPostal, Estado, Ciudad, Colonia, Domicilio, Rfc,
        Contacto, ContactoCargo, Telefono, Celular, Email, MedioContacto, Contrasena, TipoPersona, callBackResult) {
        $.ajax({
            beforeSend: function () {
                $("#cargandoDatos").show();
            },
            type: "POST",
            url: urlServer + "Btu/EditarDatosEmpresa",
            data: {
                RazonSocial, NombreComercial, Actividad, CodigoPostal, Estado, Ciudad, Colonia, Domicilio, Rfc,
                Contacto, ContactoCargo, Telefono, Celular, Email, MedioContacto, Contrasena, TipoPersona
            },
            success: function (resp) {
                if (resp.Error === false)
                    callBackResult({ ressult: 'tgp', message: resp.MensajeError });
                else
                    callBackResult({ ressult: 'notgp', message: resp.MensajeError });
            },
            error: function (ex) {
                callBackResult({ ressult: 'notgp', message: ex });
            },
            complete: function () {
                $("#cargandoDatos").hide();
            }
        });
    }


};



