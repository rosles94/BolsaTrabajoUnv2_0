/// <reference path="../global.js"/>

var btuContext =
{
    listDatosExistEmpr: [],    
    listEstados: [],
    listMunicipios: [],
    listTipoPersona: [],
    listMedioContacto: [],


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
    }

    
};



