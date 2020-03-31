/// <reference path="../global.js"/>

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
    listTipoCurso : [],


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
    Municipio, Domicilio, TelCel, TelAd, Email, AreaInt, ObjPersonal, callBackResult) {
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/GuardarInformacionCandidato",
            data: {
                Matricula, NombreCandidato, ApePatCandidato, ApeMatCandidato, FecNac, Estado,
                Municipio, Domicilio, TelCel, TelAd, Email, AreaInt, ObjPersonal
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
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/GuardarEstudiosAcademicos",
            data: {
                GradoEst, NombEsc, IdCarrera, AreaConoc, FechaIni, FechaFin, Carrera, DescGradoEstu
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
            data: { Subtipo },
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
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/GuardarSoftware",
            data: {
                Software, Nivel
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

    GuardarIdioma: function (Idioma, Nivel, callBackResult) {
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/GuardarIdioma",
            data: {
                Idioma, Nivel
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

    GuardarExperienciaProfesional: function (GradoEst, NombEsc, IdCarrera, AreaConoc, FechaIni, FechaFin, Carrera, DescGradoEstu, callBackResult) {
        $.ajax({
            type: "POST",
            url: urlServer + "Btu/GuardarEstudiosAcademicos",
            data: {
                GradoEst, NombEsc, IdCarrera, AreaConoc, FechaIni, FechaFin, Carrera, DescGradoEstu
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
    }


    
};



