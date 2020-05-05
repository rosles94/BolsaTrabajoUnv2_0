using BolsaTrabajoUnv2_0.Data;
using BolsaTrabajoUnv2_0.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Drawing.Printing;
using System.IO;
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
                if (Verificador == "0")
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
                GuardarDataContext.RegistrarDatosEmpresa(objEmpresa, ref Verificador);
                if (Verificador == "0")
                {
                    objResultado.Error = false;
                    objResultado.MensajeError = "";
                    objResultado.Resultado = null;
                }
                else
                {
                    objResultado.Error = true;
                    objResultado.MensajeError = Verificador;
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

        public JsonResult EditarDatosEmpresa(string RazonSocial, string NombreComercial, string Actividad, string CodigoPostal, string Estado, string Ciudad, string Colonia, string Domicilio, string Rfc,
            string Contacto, string ContactoCargo, string Telefono, string Celular, string Email, string MedioContacto, string Contrasena, string TipoPersona)
        {
            List<Btu_Sesion> list = new List<Btu_Sesion>();
            list = (List<Btu_Sesion>)System.Web.HttpContext.Current.Session["SessionInicioSesionEmpresa"];
            Btu_Empresa objEmpresa = new Btu_Empresa();
            ResultadoComun objResultado = new ResultadoComun();
            string Verificador = string.Empty;
            try
            {
                objEmpresa.Id_Empresa = list[0].Id;
                objEmpresa.Razon_Social = RazonSocial;
                objEmpresa.Nombre_Comercial = NombreComercial;
                objEmpresa.Actividad = Actividad;
                objEmpresa.Codigo_Postal = CodigoPostal;
                objEmpresa.Estado = Estado;
                objEmpresa.Ciudad = Ciudad;
                objEmpresa.Colonia = Colonia;
                objEmpresa.Domicilio = Domicilio;
                objEmpresa.Rfc = Rfc;
                objEmpresa.Contacto = Contacto;
                objEmpresa.Contacto_Cargo = ContactoCargo;
                objEmpresa.Telefono = Telefono;
                objEmpresa.Celular = Celular;
                objEmpresa.Email = Email;
                objEmpresa.Medio_Contacto = MedioContacto;
                objEmpresa.Contrasena = Contrasena;
                objEmpresa.Ruta_Foto = "";
                objEmpresa.Tipo_Persona = TipoPersona;
                GuardarDataContext.EditarDatosEmpresa(objEmpresa, ref Verificador);
                if (Verificador == "0")
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
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }
        //Metodos usados en la vista Datos Candidato
        public JsonResult GuardarInformacionCandidato(string Matricula, string NombreCandidato, string ApePatCandidato, string ApeMatCandidato, string FecNac, string Estado,
            string Municipio, string Domicilio, string TelCel, string TelAd, string Email, string AreaInt, string ObjPersonal, string Sexo)
        {
            List<Btu_Sesion> listSesion = new List<Btu_Sesion>();
            Btu_Curriculum objDatosCandidato = new Btu_Curriculum();
            ResultadoBtuCurriculum objResultado = new ResultadoBtuCurriculum();
            try
            {
                listSesion = (List<Btu_Sesion>)System.Web.HttpContext.Current.Session["SessionInicioSesionUnach"];

                if ((Btu_Curriculum)System.Web.HttpContext.Current.Session["SessionFotoCv"] != null)
                    objDatosCandidato = (Btu_Curriculum)System.Web.HttpContext.Current.Session["SessionFotoCv"];

                objDatosCandidato.Matricula = Matricula.ToUpper();
                objDatosCandidato.Nombre = NombreCandidato.ToUpper();
                objDatosCandidato.Materno = ApeMatCandidato.ToUpper();
                objDatosCandidato.Paterno = ApePatCandidato.ToUpper();
                objDatosCandidato.Fecha_Nacimiento = FecNac;
                objDatosCandidato.Estado = Estado;
                objDatosCandidato.Municipio = Municipio;
                objDatosCandidato.Domicilio = Domicilio.ToUpper();
                objDatosCandidato.Celular = TelCel;
                objDatosCandidato.Telefono = TelAd;
                objDatosCandidato.Correo = Email;
                objDatosCandidato.Intereses = AreaInt.ToUpper();
                objDatosCandidato.Objetivo = ObjPersonal.ToUpper();
                objDatosCandidato.Tipo = listSesion[0].Tipo;
                objDatosCandidato.Contrasena = listSesion[0].Password;
                objDatosCandidato.Usuario_Modificacion = NombreCandidato.ToUpper();
                objDatosCandidato.Codigo_Postal = "CDGPT";
                objDatosCandidato.Colonia = "COLONIA";
                objDatosCandidato.Genero = Sexo;
                System.Web.HttpContext.Current.Session["SessionInformacionPersonalCandidato"] = objDatosCandidato;
                objResultado.Error = false;
                objResultado.MensajeError = "";
                objResultado.Resultado = null;
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
                    objInformacionAcad.Institucion = NombEsc.ToUpper();
                    objInformacionAcad.Id_Carrera = IdCarrera;
                    objInformacionAcad.Carrera = Carrera.ToUpper();
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
                    if (list.Count == 0)
                        objInformacionAcad.Principal = "S";
                    else
                        objInformacionAcad.Principal = "N";
                    objInformacionAcad.Tipo = "ACADEMICO";
                    objInformacionAcad.Subtipo = GradoEst;
                    objInformacionAcad.Institucion = NombEsc.ToUpper();
                    objInformacionAcad.Id_Carrera = IdCarrera;
                    objInformacionAcad.Carrera = Carrera.ToUpper();
                    objInformacionAcad.Area = AreaConoc;

                    objInformacionAcad.Fecha_Inicio = FechaIni;
                    objInformacionAcad.Fecha_Fin = FechaFin;
                    objInformacionAcad.Descripcion = DescGradoEstu;
                    objInformacionAcad.Contacto = "";
                    list.Add(objInformacionAcad);
                    System.Web.HttpContext.Current.Session["SessionInformacionAcademicaCandidato"] = list;
                }
                objResultado.Error = false;
                objResultado.MensajeError = "";
                objResultado.Resultado = list;
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
                    objInfoSotware.Tipo = "SOFTWARE";
                    objInfoSotware.Subtipo = Nivel;
                    objInfoSotware.Descripcion = Software.ToUpper();
                    objInfoSotware.Principal = "N";
                    objInfoSotware.Fecha_Inicio = fechaActual;
                    objInfoSotware.Fecha_Fin = fechaActual;
                    objInfoSotware.Contacto = "";
                    objInfoSotware.Carrera = "";
                    objInfoSotware.Institucion = "";
                    objInfoSotware.Area = "";
                    objInfoSotware.Id_Carrera = "";
                    list.Add(objInfoSotware);
                    System.Web.HttpContext.Current.Session["SessionInformacionSoftwareCandidato"] = list;
                }
                else
                {
                    list = (List<Btu_Curriculum_Informacion>)System.Web.HttpContext.Current.Session["SessionInformacionSoftwareCandidato"];
                    objInfoSotware.Tipo = "SOFTWARE";
                    objInfoSotware.Subtipo = Nivel;
                    objInfoSotware.Descripcion = Software.ToUpper();
                    objInfoSotware.Principal = "N";
                    objInfoSotware.Fecha_Inicio = fechaActual;
                    objInfoSotware.Fecha_Fin = fechaActual;
                    objInfoSotware.Contacto = "";
                    objInfoSotware.Carrera = "";
                    objInfoSotware.Institucion = "";
                    objInfoSotware.Area = "";
                    objInfoSotware.Id_Carrera = "";
                    list.Add(objInfoSotware);
                    System.Web.HttpContext.Current.Session["SessionInformacionSoftwareCandidato"] = list;
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
                    objInfoIdioma.Carrera = "";
                    objInfoIdioma.Institucion = "";
                    objInfoIdioma.Area = "";
                    objInfoIdioma.Id_Carrera = "";
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
                    objInfoIdioma.Carrera = "";
                    objInfoIdioma.Institucion = "";
                    objInfoIdioma.Area = "";
                    objInfoIdioma.Id_Carrera = "";
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
        public JsonResult GuardarExpProfesional(string NombreEmpresa, string FechaIniExpProf, string FechaFinExpProf, string DescAct, string ReferenciaTrabajo)
        {
            Btu_Curriculum_Informacion objInformacion = new Btu_Curriculum_Informacion();
            List<Btu_Curriculum_Informacion> list = new List<Btu_Curriculum_Informacion>();
            ResultadoCurriculmInformacion objResultado = new ResultadoCurriculmInformacion();
            try
            {
                if (System.Web.HttpContext.Current.Session["SessionExperienciaProfCandidato"] == null)
                {
                    objInformacion.Tipo = "EXPERIENCIA";
                    objInformacion.Subtipo = "EXPERIENCIA";
                    objInformacion.Institucion = NombreEmpresa.ToUpper();
                    objInformacion.Descripcion = DescAct.ToUpper();
                    objInformacion.Fecha_Inicio = FechaIniExpProf;
                    objInformacion.Fecha_Fin = FechaFinExpProf;
                    objInformacion.Contacto = ReferenciaTrabajo.ToUpper();
                    objInformacion.Principal = "N";
                    objInformacion.Tiempo_Laborado = "";
                    objInformacion.Carrera = "";
                    objInformacion.Area = "";
                    objInformacion.Id_Carrera = "";
                    list.Add(objInformacion);
                    System.Web.HttpContext.Current.Session["SessionExperienciaProfCandidato"] = list;
                }
                else
                {
                    list = (List<Btu_Curriculum_Informacion>)System.Web.HttpContext.Current.Session["SessionExperienciaProfCandidato"];
                    objInformacion.Tipo = "EXPERIENCIA";
                    objInformacion.Subtipo = "EXPERIENCIA";
                    objInformacion.Institucion = NombreEmpresa.ToUpper();
                    objInformacion.Descripcion = DescAct.ToUpper();
                    objInformacion.Fecha_Inicio = FechaIniExpProf;
                    objInformacion.Fecha_Fin = FechaFinExpProf;
                    objInformacion.Contacto = ReferenciaTrabajo.ToUpper();
                    objInformacion.Principal = "N";
                    objInformacion.Tiempo_Laborado = "";
                    objInformacion.Carrera = "";
                    objInformacion.Area = "";
                    objInformacion.Id_Carrera = "";
                    list.Add(objInformacion);
                    System.Web.HttpContext.Current.Session["SessionExperienciaProfCandidato"] = list;
                }
                objResultado.Error = false;
                objResultado.MensajeError = "";
                objResultado.Resultado = list;
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
        public JsonResult GuardarCursoTaller(string CursoTaller, string TipoCurso, string InstTaller, string FecIniCur, string FecFinCur)
        {
            Btu_Curriculum_Informacion objDatosCurso = new Btu_Curriculum_Informacion();
            List<Btu_Curriculum_Informacion> list = new List<Btu_Curriculum_Informacion>();
            ResultadoCurriculmInformacion objResultado = new ResultadoCurriculmInformacion();
            try
            {
                if (System.Web.HttpContext.Current.Session["SessionCursoTallerCandidato"] == null)
                {
                    objDatosCurso.Tipo = "OTROS";
                    objDatosCurso.Subtipo = TipoCurso.ToUpper();
                    objDatosCurso.Institucion = InstTaller.ToUpper();
                    objDatosCurso.Descripcion = CursoTaller.ToUpper();
                    objDatosCurso.Fecha_Inicio = FecIniCur;
                    objDatosCurso.Fecha_Fin = FecFinCur;
                    objDatosCurso.Principal = "N";
                    objDatosCurso.Contacto = "";
                    objDatosCurso.Tiempo_Laborado = "";
                    objDatosCurso.Carrera = "";
                    objDatosCurso.Area = "";
                    objDatosCurso.Id_Carrera = "";
                    list.Add(objDatosCurso);
                    System.Web.HttpContext.Current.Session["SessionCursoTallerCandidato"] = list;
                }
                else
                {
                    list = (List<Btu_Curriculum_Informacion>)System.Web.HttpContext.Current.Session["SessionCursoTallerCandidato"];
                    objDatosCurso.Tipo = "OTROS";
                    objDatosCurso.Subtipo = TipoCurso.ToUpper();
                    objDatosCurso.Institucion = InstTaller.ToUpper();
                    objDatosCurso.Descripcion = CursoTaller.ToUpper();
                    objDatosCurso.Fecha_Inicio = FecIniCur;
                    objDatosCurso.Fecha_Fin = FecFinCur;
                    objDatosCurso.Principal = "N";
                    objDatosCurso.Contacto = "";
                    objDatosCurso.Tiempo_Laborado = "";
                    objDatosCurso.Carrera = "";
                    objDatosCurso.Area = "";
                    objDatosCurso.Id_Carrera = "";
                    list.Add(objDatosCurso);
                    System.Web.HttpContext.Current.Session["SessionCursoTallerCandidato"] = list;
                }
                objResultado.Error = false;
                objResultado.MensajeError = "";
                objResultado.Resultado = list;
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
        public JsonResult GuardarInfoGeneralCandidato()
        {
            ResultadoComun objResultado = new ResultadoComun();
            ResultadoBtuCurriculum objResultadoCv = new ResultadoBtuCurriculum();
            ResultadoCurriculmInformacion objResultadoInfoCv = new ResultadoCurriculmInformacion();
            Btu_Curriculum objResp = new Btu_Curriculum();
            try
            {
                objResultadoCv = GuardarInformacionCandidatoBD();
                if (objResultadoCv.Error == false)
                {
                    objResp = (Btu_Curriculum)System.Web.HttpContext.Current.Session["SessionRespInfoCandidato"];
                    objResultadoInfoCv = GuardarInfoAcademicaBD(objResp);
                    if (objResultadoInfoCv.Error == false)
                    {
                        objResultadoInfoCv = GuardarSoftwareBD(objResp);
                        if (objResultadoInfoCv.Error == false)
                        {
                            objResultadoInfoCv = GuardarIdiomaBD(objResp);
                            if (objResultadoInfoCv.Error == false)
                            {
                                objResultadoInfoCv = GuardarExpProfesionalBD(objResp);
                                if (objResultadoInfoCv.Error == false)
                                {
                                    objResultadoInfoCv = GuardarCursoTallerBD(objResp);
                                    if (objResultadoInfoCv.Error == false)
                                    {
                                        objResultado = CorreoAltaCandidato(objResp.Correo);
                                        if (objResultado.Error == false)
                                            return Json(objResultado, JsonRequestBehavior.AllowGet);
                                        else
                                            return Json(objResultado, JsonRequestBehavior.AllowGet);
                                    }
                                    else
                                    {
                                        return Json(objResultadoCv, JsonRequestBehavior.AllowGet);
                                    }
                                }
                                else
                                {
                                    return Json(objResultadoCv, JsonRequestBehavior.AllowGet);
                                }
                            }
                            else
                            {
                                return Json(objResultadoCv, JsonRequestBehavior.AllowGet);
                            }

                        }
                        else
                        {
                            return Json(objResultadoCv, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(objResultadoCv, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(objResultadoCv, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                objResultado.Resultado = null;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult EditarInfoGeneralCandidato ()
        {
            Btu_Curriculum objCv = new Btu_Curriculum();
            ResultadoComun objResultado = new ResultadoComun();
            ResultadoBtuCurriculum objResultadoCv = new ResultadoBtuCurriculum();
            ResultadoCurriculmInformacion objResultadoInfoCv = new ResultadoCurriculmInformacion();
            ResultadoComun objResultadoCm = new ResultadoComun();
            List<Btu_Sesion> list = new List<Btu_Sesion>();
            try
            {
                list = (List<Btu_Sesion>)System.Web.HttpContext.Current.Session["SessionInicioSesionUnach"];
                objCv.Id = list[0].Id;


                objResultado = EditarInformacionCandidato();
                if (objResultado.Error == false)
                {
                    objResultadoCm = EliminarEstudioAcademicoBD();
                    if (objResultadoCm.Error == false)
                    {
                        objResultadoInfoCv = GuardarInfoAcademicaBD(objCv);
                        if (objResultadoInfoCv.Error == false)
                        {
                            objResultadoCm = EliminarIdiomaBD();
                            if (objResultadoCm.Error == false)
                            {
                                objResultadoInfoCv = GuardarIdiomaBD(objCv);
                                if (objResultadoInfoCv.Error == false)
                                {
                                    objResultadoCm = EliminarSoftwareBD();
                                    if (objResultadoCm.Error == false)
                                    {
                                        objResultadoInfoCv = GuardarSoftwareBD(objCv);
                                        if (objResultadoInfoCv.Error == false)
                                        {
                                            objResultadoCm = EliminarExpProfesionalBD();
                                            if (objResultadoCm.Error == false)
                                            {
                                                objResultadoInfoCv =  GuardarExpProfesionalBD(objCv);
                                                if(objResultadoInfoCv.Error == false)
                                                {
                                                    objResultadoCm =  EliminarCursoTallerBD();
                                                    if (objResultadoCm.Error == false)
                                                    {
                                                        objResultadoInfoCv = GuardarCursoTallerBD(objCv);
                                                        if (objResultadoInfoCv.Error == false)
                                                            return Json(objResultadoInfoCv, JsonRequestBehavior.AllowGet);
                                                        else
                                                            return Json(objResultadoInfoCv, JsonRequestBehavior.AllowGet);
                                                    }
                                                    else
                                                        return Json(objResultadoCm, JsonRequestBehavior.AllowGet);
                                                }
                                                else
                                                {
                                                    return Json(objResultadoInfoCv, JsonRequestBehavior.AllowGet);
                                                }
                                            }
                                            else
                                                return Json(objResultadoCm, JsonRequestBehavior.AllowGet);
                                        }
                                        else
                                            return Json(objResultadoInfoCv, JsonRequestBehavior.AllowGet);
                                    }
                                    else
                                        return Json(objResultadoCm, JsonRequestBehavior.AllowGet);
                                }
                                else
                                    return Json(objResultadoInfoCv, JsonRequestBehavior.AllowGet);
                            }
                            else
                                return Json(objResultadoCm, JsonRequestBehavior.AllowGet);
                        }
                        else
                            return Json(objResultadoInfoCv, JsonRequestBehavior.AllowGet);
                    }
                    else
                        return Json(objResultadoCm, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(objResultadoCv, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }
        public ResultadoBtuCurriculum GuardarInformacionCandidatoBD ()
        {
            Btu_Curriculum objInfoCandidato = new Btu_Curriculum();
            Btu_Curriculum objFotoCv = new Btu_Curriculum();
            Btu_Curriculum objRespCandidato = new Btu_Curriculum();
            ResultadoBtuCurriculum objResultado = new ResultadoBtuCurriculum();
            string Verificador = string.Empty;
            try
            {
                objInfoCandidato = (Btu_Curriculum)System.Web.HttpContext.Current.Session["SessionInformacionPersonalCandidato"];
                objFotoCv = (Btu_Curriculum)System.Web.HttpContext.Current.Session["SessionFotoCv"];
                if (objInfoCandidato.Ruta_Foto == null || objInfoCandidato.Ruta_Foto == "")
                    if (objInfoCandidato.Ruta_Foto == null || objInfoCandidato.Ruta_Foto == "")
                        objInfoCandidato.Ruta_Foto = objFotoCv.Ruta_Foto;

                objRespCandidato = GuardarDataContext.GuardarInformacionCandidatoBD(objInfoCandidato, ref Verificador);
                if(Verificador == "0")
                {
                    objResultado.Error = false;
                    objResultado.MensajeError = Verificador;
                    System.Web.HttpContext.Current.Session["SessionRespInfoCandidato"] = objRespCandidato;
                }
                else
                {
                    objResultado.Error = true;
                    objResultado.MensajeError = Verificador;
                }
                return objResultado;
            }
            catch(Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return objResultado;
            }
            
        }
        public ResultadoCurriculmInformacion GuardarInfoAcademicaBD(Btu_Curriculum objRespId)
        {
            ResultadoCurriculmInformacion objResultado = new ResultadoCurriculmInformacion();
            string Verificador = string.Empty;
            try
            {
                List<Btu_Curriculum_Informacion> listInfoAcademica = new List<Btu_Curriculum_Informacion>();
                listInfoAcademica = (List<Btu_Curriculum_Informacion>)System.Web.HttpContext.Current.Session["SessionInformacionAcademicaCandidato"];
                GuardarDataContext.GuardarCurriculumInformacionBD(objRespId, listInfoAcademica, ref Verificador);
                if(Verificador == "0")
                {
                    objResultado.Error = false;
                    objResultado.MensajeError = "";
                    System.Web.HttpContext.Current.Session["SessionInformacionAcademicaCandidato"] = null;                    
                }
                else
                {
                    objResultado.Error = true;
                    objResultado.MensajeError = Verificador;                    
                }
                return objResultado;
            }
            catch(Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return objResultado;
            }            
        }
        public ResultadoCurriculmInformacion GuardarSoftwareBD(Btu_Curriculum objRespId)
        {
            List<Btu_Curriculum_Informacion> listSoftware = new List<Btu_Curriculum_Informacion>();
            ResultadoCurriculmInformacion objResultado = new ResultadoCurriculmInformacion();
            string Verificador = string.Empty;
            try
            {
                listSoftware = (List<Btu_Curriculum_Informacion>)System.Web.HttpContext.Current.Session["SessionInformacionSoftwareCandidato"];
                if (listSoftware != null)
                    if (listSoftware.Count != 0)
                        GuardarDataContext.GuardarCurriculumInformacionBD(objRespId, listSoftware, ref Verificador);
                    else
                        Verificador = "0";
                else
                    Verificador = "0";
                if(Verificador == "0")
                {
                    objResultado.Error = false;
                    objResultado.MensajeError = "";
                    System.Web.HttpContext.Current.Session["SessionInformacionSoftwareCandidato"] = null;
                }
                else
                {
                    objResultado.Error = true;
                    objResultado.MensajeError = Verificador;
                }
                return objResultado;
            }
            catch(Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return objResultado;
            }            
        }
        public ResultadoCurriculmInformacion GuardarIdiomaBD(Btu_Curriculum objRespId)
        {
            List<Btu_Curriculum_Informacion> listIdioma = new List<Btu_Curriculum_Informacion>();
            ResultadoCurriculmInformacion objResultado = new ResultadoCurriculmInformacion();
            string Verificador = string.Empty;
            try
            {
                listIdioma = (List<Btu_Curriculum_Informacion>)System.Web.HttpContext.Current.Session["SessionInformacionIdiomaCandidato"];
                if (listIdioma != null)
                    if (listIdioma.Count != 0)
                        GuardarDataContext.GuardarCurriculumInformacionBD(objRespId, listIdioma, ref Verificador);
                    else
                        Verificador = "0";
                else
                    Verificador = "0";
                if(Verificador == "0")
                {
                    objResultado.Error = false;
                    objResultado.MensajeError = "";
                    System.Web.HttpContext.Current.Session["SessionInformacionIdiomaCandidato"] = null;
                }
                else
                {
                    objResultado.Error = true;
                    objResultado.MensajeError = Verificador;
                }
                return objResultado;
            }
            catch(Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return objResultado;
            }            
        }
        public ResultadoCurriculmInformacion GuardarExpProfesionalBD(Btu_Curriculum objRespId)
        {
            List<Btu_Curriculum_Informacion> listExpProf = new List<Btu_Curriculum_Informacion>();
            ResultadoCurriculmInformacion objResultado = new ResultadoCurriculmInformacion();
            string Verificador = string.Empty;
            try
            {
                listExpProf = (List<Btu_Curriculum_Informacion>)System.Web.HttpContext.Current.Session["SessionExperienciaProfCandidato"];
                GuardarDataContext.GuardarCurriculumInformacionBD(objRespId, listExpProf, ref Verificador);
                if (Verificador == "0")
                {
                    objResultado.Error = false;
                    objResultado.MensajeError = "";
                    System.Web.HttpContext.Current.Session["SessionExperienciaProfCandidato"] = null;
                }
                else 
                {
                    objResultado.Error = true;
                    objResultado.MensajeError = Verificador;
                }
                return objResultado;
            }
            catch(Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return objResultado;
            }           
        }        
        public ResultadoCurriculmInformacion GuardarCursoTallerBD (Btu_Curriculum objRespId)
        {
            List<Btu_Curriculum_Informacion> listCursoTaller = new List<Btu_Curriculum_Informacion>();
            ResultadoCurriculmInformacion objResultado = new ResultadoCurriculmInformacion();
            string Verificador = string.Empty;
            try
            {
                listCursoTaller = (List<Btu_Curriculum_Informacion>)System.Web.HttpContext.Current.Session["SessionCursoTallerCandidato"];
                if (listCursoTaller != null)
                    if (listCursoTaller.Count != 0)
                        GuardarDataContext.GuardarCurriculumInformacionBD(objRespId, listCursoTaller, ref Verificador);
                    else
                        Verificador = "0";
                else
                    Verificador = "0";
                if (Verificador == "0")
                {
                    objResultado.Error = false;
                    objResultado.MensajeError = "";
                    System.Web.HttpContext.Current.Session["SessionCursoTallerCandidato"] = null;
                }
                else
                {
                    objResultado.Error = true;
                    objResultado.MensajeError = Verificador;
                }
                return objResultado;
            }
            catch(Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return objResultado;
            }            
        }
        public JsonResult DatosRegistroUnach()
        {
            Btu_Curriculum objDatosUnach = new Btu_Curriculum();
            Btu_Curriculum objFotoCv = new Btu_Curriculum();
            List<Btu_Sesion> list = new List<Btu_Sesion>();
            ResultadoBtuCurriculum objResultado = new ResultadoBtuCurriculum();
            list = (List<Btu_Sesion>)System.Web.HttpContext.Current.Session["SessionInicioSesionUnach"];
            string Verificador = string.Empty;
            try
            {
                objDatosUnach.Matricula = list[0].Matricula;
                if (list[0].Registrado == "1")
                    objResultado.Resultado = DataContext.ObtenerDatosCurriculumAlta(objDatosUnach, ref Verificador);
                else
                    objResultado.Resultado = DataContext.DatosRegistroUnach(objDatosUnach, ref Verificador);
                if(Verificador == "0")
                {
                    objFotoCv.Ruta_Foto = objResultado.Resultado[0].Ruta_Foto;
                    System.Web.HttpContext.Current.Session["SessionFotoCv"] = objFotoCv;
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
            catch(Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult EliminarEstudioAcademico(int Posicion)
        {
            List<Btu_Curriculum_Informacion> list = new List<Btu_Curriculum_Informacion>();
            ResultadoCurriculmInformacion objResultado = new ResultadoCurriculmInformacion();
            try
            {
                if(System.Web.HttpContext.Current.Session["SessionInformacionAcademicaCandidato"] != null)
                {
                    list = (List<Btu_Curriculum_Informacion>)System.Web.HttpContext.Current.Session["SessionInformacionAcademicaCandidato"];
                    list.RemoveAt(Posicion);
                    System.Web.HttpContext.Current.Session["SessionInformacionAcademicaCandidato"] = list;
                    objResultado.Resultado = list;
                    objResultado.Error = false;
                    objResultado.MensajeError = "";                    
                }
                else
                {
                    objResultado.Resultado = null;
                    objResultado.Error = true;
                    objResultado.MensajeError = "No hay elementos en la lista";
                }
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
        public JsonResult EliminarSoftware(int Posicion)
        {
            List<Btu_Curriculum_Informacion> list = new List<Btu_Curriculum_Informacion>();
            ResultadoCurriculmInformacion objResultado = new ResultadoCurriculmInformacion();
            try
            {
                if (System.Web.HttpContext.Current.Session["SessionInformacionSoftwareCandidato"] != null)
                {
                    list = (List<Btu_Curriculum_Informacion>)System.Web.HttpContext.Current.Session["SessionInformacionSoftwareCandidato"];
                    list.RemoveAt(Posicion);
                    System.Web.HttpContext.Current.Session["SessionInformacionSoftwareCandidato"] = list;
                    objResultado.Resultado = list;
                    objResultado.Error = false;
                    objResultado.MensajeError = "";
                }
                else
                {
                    objResultado.Resultado = null;
                    objResultado.Error = true;
                    objResultado.MensajeError = "No hay elementos en la lista";
                }
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
        public JsonResult EliminarIdioma(int Posicion)
        {
            List<Btu_Curriculum_Informacion> list = new List<Btu_Curriculum_Informacion>();
            ResultadoCurriculmInformacion objResultado = new ResultadoCurriculmInformacion();
            try
            {
                if (System.Web.HttpContext.Current.Session["SessionInformacionIdiomaCandidato"] != null)
                {
                    list = (List<Btu_Curriculum_Informacion>)System.Web.HttpContext.Current.Session["SessionInformacionIdiomaCandidato"];
                    list.RemoveAt(Posicion);
                    System.Web.HttpContext.Current.Session["SessionInformacionIdiomaCandidato"] = list;
                    objResultado.Resultado = list;
                    objResultado.Error = false;
                    objResultado.MensajeError = "";
                }
                else
                {
                    objResultado.Resultado = null;
                    objResultado.Error = true;
                    objResultado.MensajeError = "No hay elementos en la lista";
                }
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
        public JsonResult EliminarExperienciaProfesional(int Posicion)
        {
            List<Btu_Curriculum_Informacion> list = new List<Btu_Curriculum_Informacion>();
            ResultadoCurriculmInformacion objResultado = new ResultadoCurriculmInformacion();
            try
            {
                if (System.Web.HttpContext.Current.Session["SessionExperienciaProfCandidato"] != null)
                {
                    list = (List<Btu_Curriculum_Informacion>)System.Web.HttpContext.Current.Session["SessionExperienciaProfCandidato"];
                    list.RemoveAt(Posicion);
                    System.Web.HttpContext.Current.Session["SessionExperienciaProfCandidato"] = list;
                    objResultado.Resultado = list;
                    objResultado.Error = false;
                    objResultado.MensajeError = "";
                }
                else
                {
                    objResultado.Resultado = null;
                    objResultado.Error = true;
                    objResultado.MensajeError = "No hay elementos en la lista";
                }
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
        public JsonResult EliminarCursotaller(int Posicion)
        {
            List<Btu_Curriculum_Informacion> list = new List<Btu_Curriculum_Informacion>();
            ResultadoCurriculmInformacion objResultado = new ResultadoCurriculmInformacion();
            try
            {
                if (System.Web.HttpContext.Current.Session["SessionCursoTallerCandidato"] != null)
                {
                    list = (List<Btu_Curriculum_Informacion>)System.Web.HttpContext.Current.Session["SessionCursoTallerCandidato"];
                    list.RemoveAt(Posicion);
                    System.Web.HttpContext.Current.Session["SessionCursoTallerCandidato"] = list;
                    objResultado.Resultado = list;
                    objResultado.Error = false;
                    objResultado.MensajeError = "";
                }
                else
                {
                    objResultado.Resultado = null;
                    objResultado.Error = true;
                    objResultado.MensajeError = "No hay elementos en la lista";
                }
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
        public ResultadoComun EliminarEstudioAcademicoBD()
        {
            ResultadoComun objResultado = new ResultadoComun();
            List<Btu_Sesion> list = new List<Btu_Sesion>();
            Btu_Curriculum_Informacion objInfoCv = new Btu_Curriculum_Informacion();
            string Verificador = string.Empty;
            try
            {
                list = (List<Btu_Sesion>)System.Web.HttpContext.Current.Session["SessionInicioSesionUnach"];
                objInfoCv.Id_Curriculum = list[0].Id;
                objInfoCv.Tipo = "ACADEMICO";                
                GuardarDataContext.EliminarInformacionCurriculum(objInfoCv, ref Verificador);
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
                return objResultado;
            }
            catch(Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return objResultado;
            }
        }
        public ResultadoComun EliminarSoftwareBD()
        {
            ResultadoComun objResultado = new ResultadoComun();
            List<Btu_Sesion> list = new List<Btu_Sesion>();
            Btu_Curriculum_Informacion objInfoCv = new Btu_Curriculum_Informacion();
            string Verificador = string.Empty;
            try
            {
                list = (List<Btu_Sesion>)System.Web.HttpContext.Current.Session["SessionInicioSesionUnach"];
                objInfoCv.Id_Curriculum = list[0].Id;
                objInfoCv.Tipo = "SOFTWARE";                
                GuardarDataContext.EliminarInformacionCurriculum(objInfoCv, ref Verificador);
                if (Verificador == "0")
                {
                    objResultado.Error = false;
                    objResultado.MensajeError = "";
                }
                else
                {
                    objResultado.Error = true;
                    objResultado.MensajeError = Verificador;
                }
                return objResultado;
            }
            catch (Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return objResultado;
            }
        }
        public ResultadoComun EliminarIdiomaBD()
        {
            ResultadoComun objResultado = new ResultadoComun();
            List<Btu_Sesion> list = new List<Btu_Sesion>();
            Btu_Curriculum_Informacion objInfoCv = new Btu_Curriculum_Informacion();
            string Verificador = string.Empty;
            try
            {
                list = (List<Btu_Sesion>)System.Web.HttpContext.Current.Session["SessionInicioSesionUnach"];
                objInfoCv.Id_Curriculum = list[0].Id;
                objInfoCv.Tipo = "IDIOMA";
                GuardarDataContext.EliminarInformacionCurriculum(objInfoCv, ref Verificador);
                if (Verificador == "0")
                {
                    objResultado.Error = false;
                    objResultado.MensajeError = "";
                }
                else
                {
                    objResultado.Error = true;
                    objResultado.MensajeError = Verificador;
                }
                return objResultado;
            }
            catch (Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return objResultado;
            }
        }
        public ResultadoComun EliminarExpProfesionalBD()
        {
            ResultadoComun objResultado = new ResultadoComun();
            List<Btu_Sesion> list = new List<Btu_Sesion>();
            Btu_Curriculum_Informacion objInfoCv = new Btu_Curriculum_Informacion();
            string Verificador = string.Empty;
            try
            {
                list = (List<Btu_Sesion>)System.Web.HttpContext.Current.Session["SessionInicioSesionUnach"];
                objInfoCv.Id_Curriculum = list[0].Id;
                objInfoCv.Tipo = "EXPERIENCIA";
                GuardarDataContext.EliminarInformacionCurriculum(objInfoCv, ref Verificador);
                if (Verificador == "0")
                {
                    objResultado.Error = false;
                    objResultado.MensajeError = "";
                }
                else
                {
                    objResultado.Error = true;
                    objResultado.MensajeError = Verificador;
                }
                return objResultado;
            }
            catch (Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return objResultado;
            }
        }
        public ResultadoComun EliminarCursoTallerBD()
        {
            ResultadoComun objResultado = new ResultadoComun();
            List<Btu_Sesion> list = new List<Btu_Sesion>();
            Btu_Curriculum_Informacion objInfoCv = new Btu_Curriculum_Informacion();
            string Verificador = string.Empty;
            try
            {
                list = (List<Btu_Sesion>)System.Web.HttpContext.Current.Session["SessionInicioSesionUnach"];
                objInfoCv.Id_Curriculum = list[0].Id;
                objInfoCv.Tipo = "OTROS";
                GuardarDataContext.EliminarInformacionCurriculum(objInfoCv, ref Verificador);
                if (Verificador == "0")
                {
                    objResultado.Error = false;
                    objResultado.MensajeError = "";
                }
                else
                {
                    objResultado.Error = true;
                    objResultado.MensajeError = Verificador;
                }
                return objResultado;
            }
            catch (Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return objResultado;
            }
        }
        public JsonResult EditarPrincipalEstAcad (string Posicion)
        {
            List<Btu_Curriculum_Informacion> list = new List<Btu_Curriculum_Informacion>();
            Btu_Curriculum_Informacion objEstudios = new Btu_Curriculum_Informacion();
            ResultadoCurriculmInformacion objResultado = new ResultadoCurriculmInformacion();
            try
            {
                list = (List<Btu_Curriculum_Informacion>)System.Web.HttpContext.Current.Session["SessionInformacionAcademicaCandidato"];

                var consulta = from c in list
                              where (c.Principal == "S")
                              select c;

                foreach (Btu_Curriculum_Informacion info in consulta)
                    info.Principal = "N";

                var consulta2 = from c in list
                                where (c.Id_Carrera == Posicion)
                                select c;

                foreach (Btu_Curriculum_Informacion info in consulta2)
                    info.Principal = "S";

                objResultado.Error = false;
                objResultado.MensajeError = "";
                objResultado.Resultado = list;

                System.Web.HttpContext.Current.Session["SessionInformacionAcademicaCandidato"] = list;

                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult ObtenerEstudiosAcademicos()
        {
            Btu_Curriculum objInfoCv = new Btu_Curriculum();
            List<Btu_Sesion> list = new List<Btu_Sesion>();
            ResultadoCurriculmInformacion objResultado = new ResultadoCurriculmInformacion();
            try
            {
                list = (List<Btu_Sesion>)System.Web.HttpContext.Current.Session["SessionInicioSesionUnach"];
                objInfoCv.Id = list[0].Id;
                objInfoCv.Tipo = "ACADEMICO";                
                objResultado.Resultado = DataContext.ObtenerInfoCurriculum(objInfoCv);
                objResultado.Error = false;
                objResultado.MensajeError = "";
                System.Web.HttpContext.Current.Session["SessionInformacionAcademicaCandidato"] = objResultado.Resultado;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult ObtenerSoftware ()
        {
            Btu_Curriculum objInfoCv = new Btu_Curriculum();
            List<Btu_Sesion> list = new List<Btu_Sesion>();
            ResultadoCurriculmInformacion objResultado = new ResultadoCurriculmInformacion();
            try
            {
                list = (List<Btu_Sesion>)System.Web.HttpContext.Current.Session["SessionInicioSesionUnach"]; 
                objInfoCv.Id = list[0].Id;
                objInfoCv.Tipo = "SOFTWARE";
                objResultado.Resultado = DataContext.ObtenerInfoCurriculum(objInfoCv);
                objResultado.Error = false;
                objResultado.MensajeError = "";
                System.Web.HttpContext.Current.Session["SessionInformacionSoftwareCandidato"] = objResultado.Resultado;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult ObtenerIdioma()
        {
            Btu_Curriculum objInfoCv = new Btu_Curriculum();
            List<Btu_Sesion> list = new List<Btu_Sesion>();
            ResultadoCurriculmInformacion objResultado = new ResultadoCurriculmInformacion();
            try
            {
                list = (List<Btu_Sesion>)System.Web.HttpContext.Current.Session["SessionInicioSesionUnach"];
                objInfoCv.Id = list[0].Id;
                objInfoCv.Tipo = "IDIOMA";
                objResultado.Resultado = DataContext.ObtenerInfoCurriculum(objInfoCv);
                objResultado.Error = false;
                objResultado.MensajeError = "";
                System.Web.HttpContext.Current.Session["SessionInformacionIdiomaCandidato"] = objResultado.Resultado;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult ObtenerExpProf()
        {
            Btu_Curriculum objInfoCv = new Btu_Curriculum();
            List<Btu_Sesion> list = new List<Btu_Sesion>();
            ResultadoCurriculmInformacion objResultado = new ResultadoCurriculmInformacion();
            try
            {
                list = (List<Btu_Sesion>)System.Web.HttpContext.Current.Session["SessionInicioSesionUnach"];
                objInfoCv.Id = list[0].Id;
                objInfoCv.Tipo = "EXPERIENCIA";
                objResultado.Resultado = DataContext.ObtenerInfoCurriculum(objInfoCv);
                objResultado.Error = false;
                objResultado.MensajeError = "";
                System.Web.HttpContext.Current.Session["SessionExperienciaProfCandidato"] = objResultado.Resultado;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult ObtenerCursoTaller ()
        {
            Btu_Curriculum objInfoCv = new Btu_Curriculum();
            List<Btu_Sesion> list = new List<Btu_Sesion>();
            ResultadoCurriculmInformacion objResultado = new ResultadoCurriculmInformacion();
            try
            {
                list = (List<Btu_Sesion>)System.Web.HttpContext.Current.Session["SessionInicioSesionUnach"];
                objInfoCv.Id = list[0].Id;
                objInfoCv.Tipo = "OTROS";
                objResultado.Resultado = DataContext.ObtenerInfoCurriculum(objInfoCv);
                objResultado.Error = false;
                objResultado.MensajeError = "";
                System.Web.HttpContext.Current.Session["SessionCursoTallerCandidato"] = objResultado.Resultado;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }
        public ResultadoComun EditarInformacionCandidato()
        {
            string Verificador = string.Empty;
            Btu_Curriculum objDatosCv = new Btu_Curriculum();
            ResultadoComun objResultado = new ResultadoComun();
            try
            {
                objDatosCv = (Btu_Curriculum)System.Web.HttpContext.Current.Session["SessionInformacionPersonalCandidato"];
                GuardarDataContext.EditarInformacionCandidatoBD(objDatosCv, ref Verificador);
                if (Verificador == "0")
                {
                    objResultado.Error = false;
                    objResultado.MensajeError = "";
                    //System.Web.HttpContext.Current.Session["SessionInformacionPersonalCandidato"] = null;
                    return objResultado;
                }
                else
                {
                    objResultado.Error = true;
                    objResultado.MensajeError = Verificador;
                    return objResultado;
                }
            }
            catch (Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return objResultado;
            }
        }
        public ResultadoComun CorreoAltaCandidato(string Correo)
        {
            ResultadoComun objResultado = new ResultadoComun();

            string AsuntoCorreo = "Registro de usuario";
            string Contenido = "<img src='https://btu.unach.mx/Dsia/imagenes/encabezado_correo.png'>" +
                "<img src='https://btu.unach.mx/Dsia/imagenes/btu.png'>" +
                "<br /><div align=center><font size='4'><a href=\'" + "'>Notificación de registros de datos</a></font></div><br /><br />" +
                "<font size='2'>Tus datos han sido: Registrados y serán validados en los próximos días<br />" +
                "<br /><strong>DIRECCIÓN DE PERSONAL</strong><br />Teléfono - (961) 61 1 36 39, Ext.: 22/ (961) 61 1 34 78 Correo Electronico : btu@unach.mx<br /><br />";
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
            string MsjError = string.Empty;
            EnvioCorreo_Adjunto(ref mmsg, AsuntoCorreo, Contenido, Correo, ref MsjError);
            if (MsjError == "")
            {
                objResultado.Error = false;
                objResultado.MensajeError = "";
                return objResultado;
            }
                
            else
            {
                objResultado.Error = true;
                objResultado.MensajeError = MsjError;
                return objResultado;
            }
                
        }

        [HttpPost]
        public ActionResult UploadFiles()
        {
            string Respuesta = "";
            List<Btu_Sesion> lisInfoPersonal = new List<Btu_Sesion>();
            lisInfoPersonal = (List<Btu_Sesion>)System.Web.HttpContext.Current.Session["SessionInicioSesionUnach"];
            Btu_Curriculum objFotoCv = new Btu_Curriculum();
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];
                        string fname;
                        string extencion;

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }
                        extencion = Path.GetExtension(fname);
                        if (extencion != "pdf" || extencion != "PDF" || extencion != "js" || extencion != "gif")
                        {
                            // Get the complete folder path and store the file inside it.
                            //string fnameDoc = "../ImgProfileCv/" + fname;
                            string fnameDoc = "~/Imagenes/ImgProfileCv/" + lisInfoPersonal[0].Matricula + extencion;
                            objFotoCv.Ruta_Foto = "https://btu.unach.mx/Dsia/ImgProfileCv/" + lisInfoPersonal[0].Matricula + extencion;
                            System.Web.HttpContext.Current.Session["SessionFotoCv"] = objFotoCv;
                            fname = Server.MapPath(fnameDoc);
                            file.SaveAs(fname);
                            Respuesta = "1";
                        }
                        else
                        {
                            Respuesta = "0";
                        }
                    }
                    // Returns message that successfully uploaded  
                    return Json(Respuesta);
                }
                catch (Exception ex)
                {
                    return Json("Un error ha ocurrido. Error: " + ex.Message);
                }
            }
            else
            {
                return Json("No hay archivos seleccionados.");
            }
        }

        //Metodos para la vista Btu
        public JsonResult IniciarSesion(string Usuario, string Contrasena ,string Tipo)
        {
            ResultadoSesion objResultado = new ResultadoSesion();
            Btu_Sesion objSesion = new Btu_Sesion();
            string Verificador = string.Empty;
            try
            {
                objSesion.Email = Usuario;
                objSesion.Password = Contrasena;
                objSesion.Tipo = Tipo;
                objResultado.Resultado = DataContext.InciarSesion(objSesion, ref Verificador);
                System.Web.HttpContext.Current.Session["SessionInicioSesionUnach"] = objResultado.Resultado;
                if (Verificador == "0")
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
            catch(Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult IniciarSesionEmpresa(string Usuario, string Contrasena, string Tipo)
        {
            ResultadoSesion objResultado = new ResultadoSesion();
            Btu_Sesion objSesion = new Btu_Sesion();
            string Verificador = string.Empty;
            try
            {
                objSesion.Email = Usuario;
                objSesion.Password = Contrasena;
                objSesion.Tipo = Tipo;
                objResultado.Resultado = DataContext.InciarSesion(objSesion, ref Verificador);
                System.Web.HttpContext.Current.Session["SessionInicioSesionEmpresa"] = objResultado.Resultado;
                if (Verificador == "0")
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
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult IniciarSesionAdmin (string Usuario, string Contrasena)
        {
            ResultadoComun objResultado = new ResultadoComun();
            try
            {
                String uid = "cn=" + Usuario + ",dc=unach,dc=mx";

                // assign password
                String password = Contrasena;
                // define LDAP connection
                DirectoryEntry root = new DirectoryEntry("LDAP://ldaps.unach.mx", uid, password, AuthenticationTypes.None);

                // attempt to use LDAP connection
                object connected = root.NativeObject;
                objResultado.Error = false;
                objResultado.MensajeError = "";
                return Json(objResultado, JsonRequestBehavior.AllowGet);
                
            }
            catch (Exception ex)
            {
                // exception thrown, login failed
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
        public JsonResult ComboGenero()
        {
            Comun objComun = new Comun();
            ResultadoComun objResultado = new ResultadoComun();
            try
            {
                objResultado.Resultado = CursorDataContext.ComboGenero();
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
        public JsonResult ComboEdoCivil()
        {
            Comun objComun = new Comun();
            ResultadoComun objResultado = new ResultadoComun();
            try
            {
                objResultado.Resultado = CursorDataContext.ComboEdoCivil();
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
        public JsonResult ComboTipoSalario()
        {
            Comun objComun = new Comun();
            ResultadoComun objResultado = new ResultadoComun();
            try
            {
                objResultado.Resultado = CursorDataContext.ComboTipoSalario();
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
        public JsonResult ComboIdiomaExtra()
        {
            Comun objComun = new Comun();
            ResultadoComun objResultado = new ResultadoComun();
            try
            {
                objResultado.Resultado = CursorDataContext.ComboIdiomaExtra();
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
        public JsonResult ComboTipoVacante()
        {
            Comun objComun = new Comun();
            ResultadoComun objResultado = new ResultadoComun();
            try
            {
                objResultado.Resultado = CursorDataContext.ComboTipoVacante();
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
        public JsonResult ComboVacantesEmpresa(string Id)
        {
            List<Btu_Sesion> listSesion = new List<Btu_Sesion>();
            Btu_Empresa objEmpresa = new Btu_Empresa();
            Comun objComun = new Comun();
            ResultadoComun objResultado = new ResultadoComun();
            try
            {
                listSesion = (List<Btu_Sesion>)System.Web.HttpContext.Current.Session["SessionInicioSesionEmpresa"];
                objEmpresa.Id_Empresa = listSesion[0].Id;
                objResultado.Resultado = CursorDataContext.ComboVacantesEmpresa(objEmpresa);
                objResultado.Error = false;
                objResultado.MensajeError = "";
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }
        // Metodos para la vista Panel Candidato
        public JsonResult GuardarIdCv (string Id)
        {
            ResultadoComun objResultado = new ResultadoComun();
            Btu_Curriculum objCv = new Btu_Curriculum();
            try
            {
                objCv.Id = Id;
                System.Web.HttpContext.Current.Session["SessionIdCvEditar"] = objCv;
                objResultado.Error = false;
                objResultado.MensajeError = "";
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult CargarDatosPanelCV()
        {            
            ResultadoSesion objResultado = new ResultadoSesion();
            try
            {
                objResultado.Error = false;
                objResultado.MensajeError = "";
                objResultado.Resultado = (List<Btu_Sesion>)System.Web.HttpContext.Current.Session["SessionInicioSesionUnach"];
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                objResultado.Resultado = null;
                return Json (objResultado, JsonRequestBehavior.AllowGet);
            }
        }

        //Metodos para la vista Panel Empresa
        public JsonResult CargarDatosPanelEmpresa()
        {
            List<Btu_Sesion> listSesion = new List<Btu_Sesion>();
            List<Btu_Empresa> listEmpresa = new List<Btu_Empresa>();
            Btu_Empresa objEmpresa = new Btu_Empresa();
            ResultadoEmpresa objResultado = new ResultadoEmpresa();
            string Verificador = string.Empty;
            try
            {
                listSesion = (List<Btu_Sesion>)System.Web.HttpContext.Current.Session["SessionInicioSesionEmpresa"];
                objEmpresa.Id_Empresa = listSesion[0].Id;
                objResultado.Resultado = DataContext.ObtenerStatusEmpresa(objEmpresa, ref Verificador);
                objResultado.Error = false;
                objResultado.MensajeError = "";
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult ObtenerDatosEmpresa()
        {
            Btu_Empresa objEmpresa = new Btu_Empresa();
            List<Btu_Sesion> list = new List<Btu_Sesion>();
            ResultadoEmpresa objResultado = new ResultadoEmpresa();
            string Verificador = string.Empty;
            try
            {
                if (System.Web.HttpContext.Current.Session["SessionInicioSesionEmpresa"] != null) 
                { 
                    list = (List<Btu_Sesion>)System.Web.HttpContext.Current.Session["SessionInicioSesionEmpresa"];
                    objEmpresa.Rfc = list[0].Email;
                    objResultado.Resultado = DataContext.ObtenerDatosEmpresaRegistrada(objEmpresa, ref Verificador);
                    if (Verificador == "0")
                    {
                        objResultado.Error = false;
                        objResultado.MensajeError = "";
                    }
                    else
                    {
                        objResultado.Error = true;
                        objResultado.MensajeError = Verificador;
                    }
                }
                else
                {
                    objResultado.Error = false;
                    objResultado.MensajeError = "";
                    objResultado.Resultado = null;
                }
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult ObtenerGridVacantes()
        {
            ResultadoVacante objResultado = new ResultadoVacante();
            List<Btu_Sesion> list = new List<Btu_Sesion>();
            string IdEmpresa = "";
            if(System.Web.HttpContext.Current.Session["SessionInicioSesionEmpresa"] != null)
            {
                list = (List<Btu_Sesion>)System.Web.HttpContext.Current.Session["SessionInicioSesionEmpresa"];
                IdEmpresa = list[0].Id;
            }
            try
            {
                objResultado.Resultado = DataContext.ObtenerGridVacantes(IdEmpresa);
                objResultado.Error = false;
                objResultado.MensajeError = "";
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GuardarIdVacante (string Id)
        {
            Btu_Vacante objVacante = new Btu_Vacante();
            ResultadoComun objResultado = new ResultadoComun();
            try
            {
                objVacante.Id = Id;
                objVacante.Id_Candidato = "0";
                System.Web.HttpContext.Current.Session["SessionIdVacante"] = objVacante;
                objResultado.Error = false;
                objResultado.MensajeError = "";
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult ObtenerGridInteresados(string Id)
        {
            Btu_Vacante objVacante = new Btu_Vacante();
            ResultadoBtuCurriculum objResultado = new ResultadoBtuCurriculum();
            try
            {
                objVacante.Id = Id;
                objResultado.Resultado = DataContext.ObtenerGridInteresados(objVacante);
                objResultado.Error = false;
                objResultado.MensajeError = "";
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {                
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult ObtenerGridVacantesAplicadasEmpresas ()
        {
            ResultadoVacante objResultado = new ResultadoVacante();
            List<Btu_Sesion> listSesion = new List<Btu_Sesion>();
            Btu_Empresa objEmpresa = new Btu_Empresa();
            try
            {
                listSesion = (List<Btu_Sesion>)System.Web.HttpContext.Current.Session["SessionInicioSesionEmpresa"];
                objEmpresa.Id_Empresa = listSesion[0].Id;
                objResultado.Resultado = DataContext.ObtenerGridVacantesAplicadasEmpresas(objEmpresa);
                objResultado.Error = false;
                objResultado.MensajeError = "";
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult ObtenerGridCandidatosDisponibles(string Id)
        {
            Btu_Vacante objVacante = new Btu_Vacante();
            ResultadoBtuCurriculum objResultado = new ResultadoBtuCurriculum();
            List<Btu_Sesion> listSesion = new List<Btu_Sesion>();
            try
            {
                listSesion = (List<Btu_Sesion>)System.Web.HttpContext.Current.Session["SessionInicioSesionEmpresa"];
                objVacante.Id_Empresa = listSesion[0].Id;
                objVacante.Id = Id;
                objResultado.Resultado = DataContext.ObtenerGridCandidatosDisponibles(objVacante);
                objResultado.Error = false;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }



        //Metodos para la vista Vacantes
        public JsonResult GuardarVacante (string NombreVacante, string NumeroVacantes, string EdadMin, string EdadMax, string Genero, string EdoCivil, string GradoEstu, string Expe, string ActReal, string ConoReq,
            string HorioDiaLab, string TipoSuedo, string Salario, string PrestacionesLab, string UbicVacante, string IdiomaExtra, string VigIniVac, string VigFinVac, string TipoVacante, string PersonaEntrevista,
            string DiaHorarioEntre, string DircEntre, string TelOfc, string Email, string Comentarios, string Viaja, string Licencia, string Radica)
        {
            ResultadoComun objResultado = new ResultadoComun();
            Btu_Vacante objVacante = new Btu_Vacante();
            List<Btu_Sesion> list = new List<Btu_Sesion>();
            string Verificador = string.Empty;
            try
            {
                list = (List<Btu_Sesion>)System.Web.HttpContext.Current.Session["SessionInicioSesionEmpresa"];
                objVacante.Nombre = NombreVacante.ToUpper();
                objVacante.Total = NumeroVacantes;
                objVacante.Edad_Minima = EdadMin;
                objVacante.Edad_Maxima = EdadMax;
                objVacante.Genero = Genero.ToUpper();
                objVacante.Estado_Civil = EdoCivil.ToUpper();
                objVacante.Grado = GradoEstu.ToUpper();
                objVacante.Experiencia = Expe.ToUpper();
                objVacante.Actividades = ActReal.ToUpper();
                objVacante.Conocimientos = ConoReq.ToUpper();
                objVacante.Jornada_Laboral = HorioDiaLab.ToUpper();
                objVacante.Frecuencia_Salario = TipoSuedo;
                objVacante.Salario = Salario;
                objVacante.Prestaciones = PrestacionesLab.ToUpper();
                objVacante.Ubicacion = UbicVacante.ToUpper();
                objVacante.Idioma = IdiomaExtra;
                objVacante.Vigencia_Inicio = VigIniVac;
                objVacante.Vigencia_Fin = VigFinVac;
                objVacante.Tipo = TipoVacante;
                objVacante.Responsable_Entrevista = PersonaEntrevista.ToUpper();
                objVacante.Especificaciones_Entrevista = DiaHorarioEntre.ToUpper();
                objVacante.Direccion_Entrevista = DircEntre.ToUpper();
                objVacante.Telefono = TelOfc;
                objVacante.Correo = Email;
                objVacante.Comentarios = (Comentarios == null) ? "" : Comentarios.ToUpper();
                objVacante.Viajar = Viaja;
                objVacante.Licencia = Licencia;
                objVacante.Radicar = Radica;
                objVacante.Flayer_Empresa = "";
                objVacante.Id_Empresa = list[0].Id;
                objVacante.Rfc = list[0].Email;
                GuardarDataContext.GuardarVacante(objVacante, ref Verificador);
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
            catch(Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult EditarVacante(string Nombre, string Total, string Edad_Minima, string Edad_Maxima, string Estado_Civil, string Grado, string Experiencia,
                string Actividades , string Conocimientos, string Salario, string Frecuencia_Salario , string Prestaciones, string Ubicacion, string Licencia,
                string Vigencia_Inicio, string Vigencia_Fin, string Tipo, string Direccion_Entrevista, string Telefono, string Correo, string Comentarios,
                string Responsable_Entrevista, string Especificaciones_Entrevista, string Idioma, string Radicar, string Viajar, string Genero,
                string Jornada_Laboral)
        {
            ResultadoComun objResultado = new ResultadoComun();
            Btu_Vacante objVacante = new Btu_Vacante();
            string Verificador = string.Empty;
            try
            {
                objVacante = (Btu_Vacante)System.Web.HttpContext.Current.Session["SessionIdVacante"];                
                objVacante.Nombre = Nombre.ToUpper();
                objVacante.Total = Total;
                objVacante.Edad_Minima = Edad_Minima;
                objVacante.Edad_Maxima = Edad_Maxima;
                objVacante.Estado_Civil = Estado_Civil;
                objVacante.Grado = Grado.ToUpper();
                objVacante.Experiencia = Experiencia.ToUpper();
                objVacante.Actividades = Actividades.ToUpper();
                objVacante.Conocimientos = Conocimientos.ToUpper();
                objVacante.Salario = Salario;
                objVacante.Frecuencia_Salario = Frecuencia_Salario;
                objVacante.Prestaciones = Prestaciones.ToUpper();
                objVacante.Ubicacion = Ubicacion.ToUpper();
                objVacante.Licencia = Licencia;
                objVacante.Vigencia_Inicio = Vigencia_Inicio;
                objVacante.Vigencia_Fin = Vigencia_Fin;
                objVacante.Tipo = Tipo;
                objVacante.Direccion_Entrevista = Direccion_Entrevista.ToUpper();
                objVacante.Telefono = Telefono;
                objVacante.Correo = Correo;
                objVacante.Comentarios = Comentarios.ToUpper();
                objVacante.Responsable_Entrevista = Responsable_Entrevista.ToUpper();
                objVacante.Especificaciones_Entrevista = Especificaciones_Entrevista.ToUpper();
                objVacante.Idioma = Idioma;
                objVacante.Radicar = Radicar;
                objVacante.Viajar = Viajar;
                objVacante.Flayer_Empresa = ""; ;
                objVacante.Genero = Genero;
                objVacante.Jornada_Laboral = Jornada_Laboral.ToUpper();
                GuardarDataContext.EditarVacante(objVacante, ref Verificador);
                if (Verificador == "0")
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
            catch(Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ObtenerDatosVacante()
        {
            ResultadoVacante objResultado = new ResultadoVacante();
            Btu_Vacante objVacante = new Btu_Vacante();
            string Verificador = string.Empty;
            try
            {
                if (System.Web.HttpContext.Current.Session["SessionIdVacante"] != null) {
                    objVacante = (Btu_Vacante)System.Web.HttpContext.Current.Session["SessionIdVacante"];
                    objResultado.Resultado = DataContext.ObtenerDatosVacante(objVacante, ref Verificador);
                    if (Verificador == "0")
                    {
                        objResultado.Error = false;
                        objResultado.MensajeError = "";
                    }
                    else
                    {
                        objResultado.Error = true;
                        objResultado.MensajeError = Verificador;
                    }
                }
                else
                {
                    objResultado.Error = false;
                    objResultado.MensajeError = "";
                    objResultado.Resultado = null;
                }
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult RegresarPanelEmpresa()
        {
            ResultadoComun objResultado = new ResultadoComun();
            try
            {
                if (System.Web.HttpContext.Current.Session["SessionIdVacante"] != null)
                {
                    System.Web.HttpContext.Current.Session["SessionIdVacante"] = null;
                }
                objResultado.Error = false;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult EliminarVacante (string Id)
        {
            ResultadoComun objResultado = new ResultadoComun();
            string Verificador = string.Empty;
            try
            {
                Btu_Vacante objVacante = new Btu_Vacante();
                objVacante.Id = Id;
                GuardarDataContext.EliminarVacante(objVacante, ref Verificador);
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
            catch(Exception ex)
            {
                objResultado.Error = true;
                objResultado.MensajeError = ex.Message;            
                return Json(objResultado, JsonRequestBehavior.AllowGet);
            }
        }



        // Metodos compartidos por 2 o más vistas
        public static void EnvioCorreo_Adjunto(ref System.Net.Mail.MailMessage mmsg, string Asunto, string Contenido, string DirCorreo, ref string Error)
        {

            // Create a message and set up the recipients.
            //MailMessage message = new MailMessage(
            //   "sysweb@unach.mx",
            //   DirCorreo,
            //  Asunto,
            //  Contenido);

            mmsg.To.Add(DirCorreo); //Direccion de correo electronico a la que queremos enviar el mensaje


            //Asunto
            mmsg.Subject = Asunto;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Cuerpo del Mensaje
            mmsg.Body = Contenido;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress("btu@unach.mx");

            // Create  the file attachment for this e-mail message.

            //Attachment data = new Attachment(GetStreamFile(Ruta), Path.GetFileName(Ruta), "application/pdf");

            //ContentDisposition disposition = data.ContentDisposition;
            //disposition.CreationDate = System.IO.File.GetCreationTime(Ruta);
            //disposition.ModificationDate = System.IO.File.GetLastWriteTime(Ruta);
            //disposition.ReadDate = System.IO.File.GetLastAccessTime(Ruta);
            //// Add the file attachment to this e-mail message.
            //mmsg.Attachments.Add(data);


            //---------------------------------------
            //Send the message.
            //SmtpClient client = new SmtpClient(server);
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            //// Add credentials if the SMTP server requires them.
            //client.Credentials = CredentialCache.DefaultNetworkCredentials;

            client.Port = 587;
            client.EnableSsl = true;
            // client.Host = "montebello.unach.mx"; //Para Gmail "smtp.gmail.com"; descomentar
            client.Host = "smtp.gmail.com"; //Para Gmail "";
                                            //client.Credentials = new System.Net.NetworkCredential("sysweb@unach.mx", "dsia2014"); descomentar
            client.UseDefaultCredentials = false;
            //client.Credentials = new System.Net.NetworkCredential("sysweb@unach.mx", "Dsia890#");
            client.Credentials = new System.Net.NetworkCredential("btu@unach.mx", "Bolsa_2019");

            try
            {
                //Enviamos el mensaje      
                client.Send(mmsg);

                //System.IO.File.Delete(Ruta);

            }
            catch (System.Net.Mail.SmtpException ex)
            {
                //Aquí gestionamos los errores al intentar enviar el correo
                Error = (ex.Message);
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
        public ActionResult PanelEmpresa()
        {
            return View();
        }
        public ActionResult PanelCandidato()
        {
            return View();
        }
        public ActionResult PanelAdministrador()
        {
            return View();
        }
        public ActionResult Vacante()
        {
            return View();
        }
        public ActionResult Btu()
        {
            return View();
        }
    }
}