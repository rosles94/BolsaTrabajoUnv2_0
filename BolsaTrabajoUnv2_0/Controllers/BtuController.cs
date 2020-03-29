using BolsaTrabajoUnv2_0.Data;
using BolsaTrabajoUnv2_0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolsaTrabajoUnv2_0.Controllers
{
    public class BtuController : Controller
    {
     
        //Metodos usados en la vista Registrar Empresa
        public JsonResult BuscarEmpresa(string Rfc)
        {
            Btu_Empresa objEmpresa = new Btu_Empresa();
            ResultadoEmpresa objResultado = new ResultadoEmpresa();
            string Verificador = string.Empty;
            try
            {
                objResultado.Resultado = DataContext.BuscarEmpresa(Rfc, ref Verificador);
                if(Verificador == "0")
                {
                    objResultado.Error = false;
                    objResultado.MensajeError = "";                    
                }
                else
                {
                    objResultado.Error = true;
                    objResultado.MensajeError = Verificador;
                }

                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                objResultado.Resultado = null;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult RegistrarDatosEmpresa(string RazonSocial, string NombreComercial, string Actividad, string CodigoPostal, string Estado, string Ciudad, string Colonia, string Domicilio, string Rfc,
            string Contacto, string ContactoCargo, string Telefono, string Celular, string Email, string MedioContacto, string Contrasena, string RutaFoto, string TipoPersona)
        {
            Btu_Empresa objEmpresa = new Btu_Empresa();
            ResultadoEmpresa objResultado = new ResultadoEmpresa();
            string Verificador = string.Empty;
            try
            {
                objEmpresa.Razon_Social = RazonSocial.ToUpper();
                objEmpresa.Nombre_Comercial = NombreComercial.ToUpper();
                objEmpresa.Actividad = Actividad.ToUpper();
                objEmpresa.Codigo_Postal = CodigoPostal;
                objEmpresa.Estado = Estado;
                objEmpresa.Ciudad = Ciudad;
                objEmpresa.Colonia = Colonia.ToUpper();
                objEmpresa.Domicilio = Domicilio.ToUpper();
                objEmpresa.Rfc = Rfc.ToUpper();
                objEmpresa.Contacto = Contacto.ToUpper();
                objEmpresa.Contacto_Cargo = ContactoCargo.ToUpper();
                objEmpresa.Telefono = Telefono;
                objEmpresa.Celular = Celular;
                objEmpresa.Email = Email;
                objEmpresa.Medio_Contacto = MedioContacto;
                objEmpresa.Contrasena = Contrasena;
                objEmpresa.Ruta_Foto = "";
                objEmpresa.Tipo_Persona = TipoPersona;
                GuardarDartaContext.RegistrarDatosEmpresa(objEmpresa, ref Verificador);
                if (Verificador == "0")
                {
                    objResultado.Error = false;
                    objResultado.MensajeError = "";
                    objResultado.Resultado = null;
                }
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                objResultado.Resultado = null;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }



        //Combos
        public JsonResult ComboEstados() //Se utiliza en la vista Registrar Empresa,
        {
            Comun objComun = new Comun();
            ResultadoComun objResultado = new ResultadoComun();
            try
            {
                objResultado.Resultado = CursorDataContext.ComboEstados();
                objResultado.Error = false;
                objResultado.MensajeError = "";
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {                
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                objResultado.Resultado = null;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ComboMunicipios(string Estado)//Se utiliza en la vista Registrar Empresa,
        {
            Comun objComun = new Comun();
            ResultadoComun objResultado = new ResultadoComun();
            try
            {
                objResultado.Resultado = CursorDataContext.ComboMunicipios(Estado);
                objResultado.Error = false;
                objResultado.MensajeError = "";
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                objResultado.Resultado = null;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult TipoUsuario()//Se utiliza en la vista Registrar Empresa,
        {
            Comun objComun = new Comun();
            ResultadoComun objResultado = new ResultadoComun();
            try
            {
                objResultado.Resultado = CursorDataContext.TipoUsuario();
                objResultado.Error = false;
                objResultado.MensajeError = "";
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                objResultado.Resultado = null;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ComboMedioContacto()//Se utiliza en la vista Registrar Empresa,
        {
            Comun objComun = new Comun();
            ResultadoComun objResultado = new ResultadoComun();
            try
            {
                objResultado.Resultado = CursorDataContext.ComboMedioContacto();
                objResultado.Error = false;
                objResultado.MensajeError = "";
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                objResultado.Resultado = null;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ComboTipoPersona()//Se utiliza en la vista Registrar Empresa,
        {
            Comun objComun = new Comun();
            ResultadoComun objResultado = new ResultadoComun();
            try
            {
                objResultado.Resultado = CursorDataContext.ComboTipoPersona();
                objResultado.Error = false;
                objResultado.MensajeError = "";
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                objResultado.Resultado = null;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Btu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegistrarEmpresa ()
        {
            return View();
        }
    }
}