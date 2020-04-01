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

        //Metodos usados en la vista Datos Candidato
        public JsonResult GuardarInformacionCandidato(string Matricula, string NombreCandidato, string ApePatCandidato, string ApeMatCandidato, string FecNac, string Estado,
            string Municipio, string Domicilio, string TelCel, string TelAd, string Email, string AreaInt, string ObjPersonal)
        {
            Btu_Curriculum objDatosCandidato = new Btu_Curriculum();
            ResultadoBtuCurriculum objResultado = new ResultadoBtuCurriculum();
            try
            {
                objDatosCandidato.Matricula = Matricula.ToUpper();
                objDatosCandidato.Nombre = NombreCandidato.ToUpper();
                objDatosCandidato.Materno = ApeMatCandidato.ToUpper();
                objDatosCandidato.Paterno = ApePatCandidato.ToUpper();
                objDatosCandidato.Fecha_Nacimiento = FecNac;
                objDatosCandidato.Estado = Estado;
                objDatosCandidato.Municipio = Municipio;
                objDatosCandidato.Domicilio = Domicilio;
                objDatosCandidato.Celular = TelCel;
                objDatosCandidato.Telefono = TelAd;
                objDatosCandidato.Correo = Email;
                objDatosCandidato.Intereses = AreaInt;
                objDatosCandidato.Objetivo = ObjPersonal;
                System.Web.HttpContext.Current.Session["SessionInformacionPersonalCandidato"] = objDatosCandidato;
                objResultado.Error = false;
                objResultado.MensajeError = "";
                objResultado.Resultado = null;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                objResultado.Error = false;
                objResultado.MensajeError = ex.Message;
                objResultado.Resultado = null;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GuardarEstudiosAcademicos(string GradoEst, string NombEsc, string IdCarrera, string AreaConoc, string FechaIni, string FechaFin, string Carrera, string DescGradoEstu)
        {
            List<Btu_Curriculum_Informacion> list = new List<Btu_Curriculum_Informacion>();
            Btu_Curriculum_Informacion objInformacionAcad = new Btu_Curriculum_Informacion();
            ResultadoCurriculmInformacion objResultado = new ResultadoCurriculmInformacion();
            try
            {
                if (System.Web.HttpContext.Current.Session["SessionInformacionAcademicaCandidato"] == null)
                {
                    objInformacionAcad.Tipo = "ACADEMICO";
                    objInformacionAcad.Subtipo = GradoEst;
                    objInformacionAcad.Institucion = NombEsc.ToUpper(); ;
                    objInformacionAcad.Id_Carrera = IdCarrera;
                    objInformacionAcad.Carrera = Carrera;
                    objInformacionAcad.Area = AreaConoc;
                    objInformacionAcad.Fecha_Inicio = FechaIni;
                    objInformacionAcad.Fecha_Fin = FechaFin;
                    objInformacionAcad.Descripcion = DescGradoEstu;
                    objInformacionAcad.Principal = "S";
                    objInformacionAcad.Contacto = "";
                    list.Add(objInformacionAcad);
                    System.Web.HttpContext.Current.Session["SessionInformacionAcademicaCandidato"] = list;                    
                }
                else
                {
                    list = (List<Btu_Curriculum_Informacion>)System.Web.HttpContext.Current.Session["SessionInformacionAcademicaCandidato"];
                    objInformacionAcad.Tipo = "ACADEMICO";
                    objInformacionAcad.Subtipo = GradoEst;
                    objInformacionAcad.Institucion = NombEsc.ToUpper(); ;
                    objInformacionAcad.Id_Carrera = IdCarrera;
                    objInformacionAcad.Carrera = Carrera;
                    objInformacionAcad.Area = AreaConoc;
                    objInformacionAcad.Fecha_Inicio = FechaIni;
                    objInformacionAcad.Fecha_Fin = FechaFin;
                    objInformacionAcad.Descripcion = DescGradoEstu;
                    objInformacionAcad.Principal = "N";
                    objInformacionAcad.Contacto = "";
                    list.Add(objInformacionAcad);
                    System.Web.HttpContext.Current.Session["SessionInformacionAcademicaCandidato"] = list;                    
                }
                objResultado.Error = false;
                objResultado.MensajeError = "";
                objResultado.Resultado = null;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex )
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                objResultado.Resultado = null;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GuardarSoftware(string Software, string Nivel)
        {
            Btu_Curriculum_Informacion objInfoSotware = new Btu_Curriculum_Informacion();
            List<Btu_Curriculum_Informacion> list = new List<Btu_Curriculum_Informacion>();
            ResultadoCurriculmInformacion objResultado = new ResultadoCurriculmInformacion();
            string fechaActual = DateTime.Now.ToString("dd/MM/yyyy");
            try
            {
                if (System.Web.HttpContext.Current.Session["SessionInformacionSoftwareCandidato"] == null)
                {
                    objInfoSotware.Tipo = "SOFWTARE";
                    objInfoSotware.Subtipo = Nivel;
                    objInfoSotware.Descripcion = Software.ToUpper();
                    objInfoSotware.Principal = "N";
                    objInfoSotware.Fecha_Inicio = fechaActual;
                    objInfoSotware.Fecha_Fin = fechaActual;
                    objInfoSotware.Contacto = "";
                    list.Add(objInfoSotware);
                    System.Web.HttpContext.Current.Session["SessionInformacionSoftwareCandidato"] = list;                    
                }
                else
                {
                    list = (List<Btu_Curriculum_Informacion>)System.Web.HttpContext.Current.Session["SessionInformacionSoftwareCandidato"];
                    objInfoSotware.Tipo = "SOFWTARE";
                    objInfoSotware.Subtipo = Nivel;
                    objInfoSotware.Descripcion = Software.ToUpper();
                    objInfoSotware.Principal = "N";
                    objInfoSotware.Fecha_Inicio = fechaActual;
                    objInfoSotware.Fecha_Fin = fechaActual;
                    objInfoSotware.Contacto = "";
                    list.Add(objInfoSotware);
                    System.Web.HttpContext.Current.Session["SessionInformacionSoftwareCandidato"] = list;                    
                }
                objResultado.Resultado = list;
                objResultado.Error = false;
                objResultado.MensajeError = "";
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                objResultado.Resultado = null;
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GuardarIdioma(string Idioma, string Nivel)
        {
            Btu_Curriculum_Informacion objInfoIdioma = new Btu_Curriculum_Informacion();
            List<Btu_Curriculum_Informacion> list = new List<Btu_Curriculum_Informacion>();
            ResultadoCurriculmInformacion objResultado = new ResultadoCurriculmInformacion();
            string fechaActual = DateTime.Now.ToString("dd/MM/yyyy");
            try
            {
                if (System.Web.HttpContext.Current.Session["SessionInformacionIdiomaCandidato"] == null)
                {
                    objInfoIdioma.Tipo = "IDIOMA";
                    objInfoIdioma.Subtipo = Nivel;
                    objInfoIdioma.Descripcion = Idioma.ToUpper();
                    objInfoIdioma.Principal = "N";
                    objInfoIdioma.Fecha_Inicio = fechaActual;
                    objInfoIdioma.Fecha_Fin = fechaActual;
                    objInfoIdioma.Contacto = "";
                    list.Add(objInfoIdioma);
                    System.Web.HttpContext.Current.Session["SessionInformacionIdiomaCandidato"] = list;
                }
                else
                {
                    list = (List<Btu_Curriculum_Informacion>)System.Web.HttpContext.Current.Session["SessionInformacionIdiomaCandidato"];
                    objInfoIdioma.Tipo = "IDIOMA";
                    objInfoIdioma.Subtipo = Nivel;
                    objInfoIdioma.Descripcion = Idioma.ToUpper();
                    objInfoIdioma.Principal = "N";
                    objInfoIdioma.Fecha_Inicio = fechaActual;
                    objInfoIdioma.Fecha_Fin = fechaActual;
                    objInfoIdioma.Contacto = "";
                    list.Add(objInfoIdioma);
                    System.Web.HttpContext.Current.Session["SessionInformacionIdiomaCandidato"] = list;
                }
                objResultado.Resultado = list;
                objResultado.Error = false;
                objResultado.MensajeError = "";
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                objResultado.Resultado = null;
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
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

        public JsonResult ComboGradoEstudios()
        {
            Comun objComun = new Comun();
            ResultadoComun objResultado = new ResultadoComun();
            try
            {
                objResultado.Resultado = CursorDataContext.ComboGradoEstudios();
                objResultado.Error = false;
                objResultado.MensajeError = "";
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                objResultado.Resultado = null;
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ComboCarreras()
        {
            Comun objComun = new Comun();
            ResultadoComun objResultado = new ResultadoComun();
            try
            {
                objResultado.Resultado = CursorDataContext.ComboCarreras();
                objResultado.Error = false;
                objResultado.MensajeError = "";
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                objResultado.Resultado = null;
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ComboAreaConocimiento()
        {
            Comun objComun = new Comun();
            ResultadoComun objResultado = new ResultadoComun();
            try
            {
                objResultado.Resultado = CursorDataContext.ComboAreaConocimiento();
                objResultado.Error = false;
                objResultado.MensajeError = "";
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                objResultado.Resultado = null;
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ComboSubtipos(string Subtipo)
        {
            Comun objComun = new Comun();
            ResultadoComun objResultado = new ResultadoComun();
            try
            {
                objResultado.Resultado = CursorDataContext.ComboSubtipos(Subtipo);
                objResultado.Error = false;
                objResultado.MensajeError = "";
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                objResultado.Resultado = null;
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ComboTipoCurso()
        {
            Comun objComun = new Comun();
            ResultadoComun objResultado = new ResultadoComun();
            try
            {
                objResultado.Resultado = CursorDataContext.ComboTipoCurso();
                objResultado.Error = false;
                objResultado.MensajeError = "";
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                objResultado.Resultado = null;
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
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

        public ActionResult DatosCandidato()
        {
            return View();
        }

        public ActionResult PanelEmpresas()
        {
            return View();
        }
    }
}