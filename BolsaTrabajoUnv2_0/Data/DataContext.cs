using BolsaTrabajoUnv2_0.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolsaTrabajoUnv2_0.Data
{
    public class DataContext
    {
        public static List<Btu_Empresa> BuscarEmpresa(string Rfc, ref string Verificador)
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            List<Btu_Empresa> list = new List<Btu_Empresa>();
            Btu_Empresa objEmpresa = new Btu_Empresa();
            try
            {

                OracleDataReader dr = null;
                string[] Parametros = { "p_rfc" };
                object[] Valores = { Rfc };
                string[] ParametrosOut = {"p_actividad", "p_giro", "p_status", "p_valido", "p_contrasenia",
                "p_medio_contacto", "p_celular", "p_contacto_cargo", "p_email", "p_contacto", "p_telefono", "p_estado",
                "p_ciudad", "p_codigo_postal", "p_colonia", "p_domicilio", "p_nombre_comercial", "p_razon_social", "p_existe","p_bandera" };
                cmd = exeProc.GenerarOracleCommand("OBT_DATOS_EMPRESA", ref Verificador, ref dr, Parametros, Valores, ParametrosOut);

                if (Verificador == "0")
                {
                    objEmpresa.Existe = Convert.ToString(cmd.Parameters["p_existe"].Value);
                    if (objEmpresa.Existe != "0" && objEmpresa.Existe != "2")
                    {
                        objEmpresa.Actividad = Convert.ToString(cmd.Parameters["p_actividad"].Value);
                        objEmpresa.Giro = Convert.ToString(cmd.Parameters["p_giro"].Value);
                        objEmpresa.Status = Convert.ToString(cmd.Parameters["p_status"].Value);
                        objEmpresa.Validado = Convert.ToString(cmd.Parameters["p_valido"].Value);
                        objEmpresa.Contrasena = Convert.ToString(cmd.Parameters["p_contrasenia"].Value);
                        objEmpresa.Medio_Contacto = Convert.ToString(cmd.Parameters["p_medio_contacto"].Value);
                        objEmpresa.Celular = Convert.ToString(cmd.Parameters["p_celular"].Value);
                        objEmpresa.Contacto_Cargo = Convert.ToString(cmd.Parameters["p_contacto_cargo"].Value);
                        objEmpresa.Email = Convert.ToString(cmd.Parameters["p_email"].Value);
                        objEmpresa.Contacto = Convert.ToString(cmd.Parameters["p_contacto"].Value);
                        objEmpresa.Telefono = Convert.ToString(cmd.Parameters["p_telefono"].Value);
                        objEmpresa.Estado = Convert.ToString(cmd.Parameters["p_estado"].Value);
                        objEmpresa.Codigo_Postal = Convert.ToString(cmd.Parameters["p_codigo_postal"].Value);
                        objEmpresa.Colonia = Convert.ToString(cmd.Parameters["p_colonia"].Value);
                        objEmpresa.Domicilio = Convert.ToString(cmd.Parameters["p_domicilio"].Value);
                        objEmpresa.Nombre_Comercial = Convert.ToString(cmd.Parameters["p_nombre_comercial"].Value);
                        objEmpresa.Razon_Social = Convert.ToString(cmd.Parameters["p_razon_social"].Value);
                    }
                    list.Add(objEmpresa);
                }
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
            }
            finally
            {
                exeProc.LimpiarOracleCommand(ref cmd);
            }
            return list;
            //return registroAgregado;
        }
        public static List<Btu_Sesion> InciarSesion(Btu_Sesion objSesion, ref string Verificador)
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            List<Btu_Sesion> list = new List<Btu_Sesion>();
            Btu_Sesion objDatosSesion = new Btu_Sesion();
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { "P_TIPO", "P_EMAIL", "P_PASSWORD" };
                object[] Valores = { objSesion.Tipo, objSesion.Email, objSesion.Password };
                string[] ParametrosOut = { "P_EXISTE", "P_MATRICULA", "P_NOMBRE", "P_REGISTRADO", "P_ID", "P_EMAIL_2", "p_bandera" };
                cmd = exeProc.GenerarOracleCommand("VAL_USUARIO", ref Verificador, ref dr, Parametros, Valores, ParametrosOut);

                if (Verificador == "0")
                {
                    objDatosSesion.Tipo = objSesion.Tipo;
                    objDatosSesion.Email = objSesion.Email;
                    objDatosSesion.Password = objSesion.Password;
                    objDatosSesion.Existe = Convert.ToString(cmd.Parameters["P_EXISTE"].Value);
                    objDatosSesion.Matricula = Convert.ToString(cmd.Parameters["P_MATRICULA"].Value);
                    objDatosSesion.Nombre = Convert.ToString(cmd.Parameters["P_NOMBRE"].Value);
                    objDatosSesion.Registrado = Convert.ToString(cmd.Parameters["P_REGISTRADO"].Value);
                    objDatosSesion.Id = Convert.ToString(cmd.Parameters["P_ID"].Value);
                    objDatosSesion.Email2 = Convert.ToString(cmd.Parameters["P_EMAIL_2"].Value);
                }
                list.Add(objDatosSesion);
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
            }
            finally
            {
                exeProc.LimpiarOracleCommand(ref cmd);
            }
            return list;
        }
        public static List<Btu_Curriculum> DatosRegistroUnach(Btu_Curriculum objSesion, ref string Verificador)
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            List<Btu_Curriculum> list = new List<Btu_Curriculum>();
            Btu_Curriculum objDatosUnach = new Btu_Curriculum();
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { "p_matricula" };
                object[] Valores = { objSesion.Matricula };
                string[] ParametrosOut = { "p_paterno", "p_materno", "p_nombre", "p_domicilio", "p_municipio", "p_estado","p_nacimiento", "p_telefono", "p_celular","p_correo",
                    "p_contrasena", "p_genero", "p_dep", "p_carrera", "p_id_carrera","p_id_registrado", "p_bandera" };
                cmd = exeProc.GenerarOracleCommand("SEL_ALUMNO_UNACH", ref Verificador, ref dr, Parametros, Valores, ParametrosOut);

                if (Verificador == "0")
                {
                    objDatosUnach.Matricula = objSesion.Matricula;
                    objDatosUnach.Paterno = Convert.ToString(cmd.Parameters["p_paterno"].Value);
                    objDatosUnach.Materno = Convert.ToString(cmd.Parameters["p_materno"].Value);
                    objDatosUnach.Nombre = Convert.ToString(cmd.Parameters["p_nombre"].Value);
                    objDatosUnach.Domicilio = Convert.ToString(cmd.Parameters["p_domicilio"].Value);
                    objDatosUnach.Municipio = Convert.ToString(cmd.Parameters["p_municipio"].Value);
                    objDatosUnach.Estado = Convert.ToString(cmd.Parameters["p_estado"].Value);
                    objDatosUnach.Fecha_Nacimiento = Convert.ToString(cmd.Parameters["p_nacimiento"].Value);
                    objDatosUnach.Telefono = Convert.ToString(cmd.Parameters["p_telefono"].Value);
                    objDatosUnach.Celular = Convert.ToString(cmd.Parameters["p_celular"].Value);
                    objDatosUnach.Correo = Convert.ToString(cmd.Parameters["p_correo"].Value);
                    objDatosUnach.Contrasena = Convert.ToString(cmd.Parameters["p_contrasena"].Value);
                    objDatosUnach.Genero = Convert.ToString(cmd.Parameters["p_genero"].Value);
                    objDatosUnach.Dependencia = Convert.ToString(cmd.Parameters["p_dep"].Value);
                    objDatosUnach.Carrera = Convert.ToString(cmd.Parameters["p_carrera"].Value);
                    objDatosUnach.IdCarrera = Convert.ToString(cmd.Parameters["p_id_carrera"].Value);
                    objDatosUnach.Id = Convert.ToString(cmd.Parameters["p_id_registrado"].Value);
                    objDatosUnach.Ruta_Foto = null;
                    objDatosUnach.Registrado = "0";
                }
                list.Add(objDatosUnach);
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
            }
            finally
            {
                exeProc.LimpiarOracleCommand(ref cmd);
            }
            return list;
        }
        public static List<Btu_Curriculum> ObtenerDatosCurriculumAlta(Btu_Curriculum objUsuarioAlta, ref string Verificador)
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            string NombreCompleto = string.Empty;
            List<Btu_Curriculum> listDatosCuentaAlta = new List<Btu_Curriculum>();

            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { "p_matricula" };
                object[] Valores = { objUsuarioAlta.Matricula };    
                string[] ParametrosOut = {"p_id", "p_paterno", "p_materno", "p_nombre", "p_domicilio", "p_municipio", "p_estado","p_nacimiento",
                "p_telefono","p_celular","p_correo", "p_objetivo", "p_interes", "p_tipo", "p_genero", "p_ruta_fotografia", "p_codigo_postal",
                    "p_colonia", "p_carrera", "p_bandera" };
                cmd = exeProc.GenerarOracleCommand_Exe("OBT_BTU_CURRICULUM", ref Verificador, ref dr, Parametros, Valores, ParametrosOut);

                if (Verificador == "0")
                {
                    objUsuarioAlta.Id = Convert.ToString(cmd.Parameters["p_id"].Value);
                    objUsuarioAlta.Materno = Convert.ToString(cmd.Parameters["p_materno"].Value);
                    objUsuarioAlta.Paterno = Convert.ToString(cmd.Parameters["p_paterno"].Value);
                    objUsuarioAlta.Nombre = Convert.ToString(cmd.Parameters["P_NOMBRE"].Value);
                    objUsuarioAlta.Domicilio = Convert.ToString(cmd.Parameters["p_domicilio"].Value);
                    objUsuarioAlta.Municipio = Convert.ToString(cmd.Parameters["p_municipio"].Value);
                    objUsuarioAlta.Estado = Convert.ToString(cmd.Parameters["p_estado"].Value);
                    objUsuarioAlta.Fecha_Nacimiento = Convert.ToString(cmd.Parameters["p_nacimiento"].Value);
                    objUsuarioAlta.Telefono = Convert.ToString(cmd.Parameters["p_telefono"].Value);
                    objUsuarioAlta.Celular = Convert.ToString(cmd.Parameters["p_celular"].Value);
                    objUsuarioAlta.Correo = Convert.ToString(cmd.Parameters["p_correo"].Value);
                    objUsuarioAlta.Objetivo = Convert.ToString(cmd.Parameters["p_objetivo"].Value);
                    objUsuarioAlta.Intereses = Convert.ToString(cmd.Parameters["p_interes"].Value);
                    objUsuarioAlta.Tipo = Convert.ToString(cmd.Parameters["p_tipo"].Value);
                    objUsuarioAlta.Genero = Convert.ToString(cmd.Parameters["p_genero"].Value);
                    objUsuarioAlta.Ruta_Foto = Convert.ToString(cmd.Parameters["p_ruta_fotografia"].Value);
                    objUsuarioAlta.Codigo_Postal = Convert.ToString(cmd.Parameters["p_codigo_postal"].Value);
                    objUsuarioAlta.Colonia = Convert.ToString(cmd.Parameters["p_colonia"].Value);
                    objUsuarioAlta.Carrera = Convert.ToString(cmd.Parameters["p_carrera"].Value);
                    objUsuarioAlta.Registrado = "1";
                    //System.Web.HttpContext.Current.Session["SessionFotoCv"] = objUsuarioAlta;
                    listDatosCuentaAlta.Add(objUsuarioAlta);
                }
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
            }
            finally
            {
                exeProc.LimpiarOracleCommand(ref cmd);
            }
            return listDatosCuentaAlta;
        }
        public static List<Btu_Curriculum_Informacion> ObtenerInfoCurriculum(Btu_Curriculum objUsuario)
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            try
            {
                //    int Dias = 0;
                //    int años = 0;
                //    int meses = 0;
                //    int mesesTotales = 0;
                OracleDataReader dr = null;
                string[] Parametros = { "p_id_curriculum", "p_tipo" };
                object[] Valores = { objUsuario.Id, objUsuario.Tipo };
                cmd = exeProc.GenerarOracleCommandCursor_Grid("PKG_VINCULAR.Obt_Btu_Curriculum_Info", ref dr, Parametros, Valores);
                List<Btu_Curriculum_Informacion> listInfoCurriculum = new List<Btu_Curriculum_Informacion>();
                while (dr.Read())
                {
                    Btu_Curriculum_Informacion objInfoCurriculum = new Btu_Curriculum_Informacion();
                    objInfoCurriculum.Id = Convert.ToString(dr[0]);
                    objInfoCurriculum.Tipo = Convert.ToString(dr[1]);
                    objInfoCurriculum.Subtipo = Convert.ToString(dr[2]);
                    objInfoCurriculum.Institucion = Convert.ToString(dr[3]);
                    objInfoCurriculum.Carrera = Convert.ToString(dr[4]);
                    objInfoCurriculum.Area = Convert.ToString(dr[5]);
                    objInfoCurriculum.Descripcion = Convert.ToString(dr[6]);
                    objInfoCurriculum.Principal = Convert.ToString(dr[7]);
                    objInfoCurriculum.Fecha_Inicio = Convert.ToString(dr[8]);
                    objInfoCurriculum.Fecha_Fin = Convert.ToString(dr[9]);
                    objInfoCurriculum.Id_Carrera = Convert.ToString(dr[10]);
                    objInfoCurriculum.Contacto = Convert.ToString(dr[11]);
                    //DateTime fechaInicio = DateTime.ParseExact(objInfoCurriculum.FECHA_INICIO, "dd/MM/yyyy", null);
                    //DateTime fechaFin = DateTime.ParseExact(objInfoCurriculum.FECHA_FIN, "dd/MM/yyyy", null);
                    //TimeSpan fechaTotal = fechaFin - fechaInicio;
                    //Dias = fechaTotal.Days;
                    //años = Convert.ToInt32(Dias / 365);
                    //meses = Dias % 365;
                    //mesesTotales = meses / 30;
                    //objInfoCurriculum.TIEMPO_LABORADO = años + " Año(s) con " + mesesTotales + " meses";
                    listInfoCurriculum.Add(objInfoCurriculum);
                }
                return listInfoCurriculum;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                exeProc.LimpiarOracleCommand(ref cmd);
            }
        }
        public static List<Btu_Empresa> ObtenerDatosEmpresaRegistrada(Btu_Empresa objEmpresa, ref string Verificador)
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            Btu_Empresa objFotoEmpresa = new Btu_Empresa();
            string NombreCompleto = string.Empty;
            List<Btu_Empresa> list = new List<Btu_Empresa>();
            List<string> lista = new List<string>();

            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { "p_rfc" };
                object[] Valores = { objEmpresa.Rfc };
                string[] ParametrosOut = {"p_actividad", "p_giro", "p_status", "p_valido", "p_contrasenia",
              "p_medio_contacto", "p_celular", "p_contacto_cargo", "p_email", "p_contacto", "p_telefono", "p_estado",
              "p_ciudad", "p_codigo_postal", "p_colonia", "p_domicilio", "p_nombre_comercial", "p_razon_social","p_logotipo",
                    "p_tipo_persona","p_id_empresa", "p_bandera" };
                cmd = exeProc.GenerarOracleCommand_Exe("OBT_DATOS_EMPRESA_REGISTRADA", ref Verificador, ref dr, Parametros, Valores, ParametrosOut);

                if (Verificador == "0")
                {
                    objEmpresa.Actividad = Convert.ToString(cmd.Parameters["p_actividad"].Value);
                    objEmpresa.Giro = Convert.ToString(cmd.Parameters["p_giro"].Value);
                    objEmpresa.Status = Convert.ToString(cmd.Parameters["p_status"].Value);
                    objEmpresa.Validado = Convert.ToString(cmd.Parameters["p_valido"].Value);
                    objEmpresa.Contrasena = Convert.ToString(cmd.Parameters["p_contrasenia"].Value);
                    objEmpresa.Medio_Contacto = Convert.ToString(cmd.Parameters["p_medio_contacto"].Value);
                    objEmpresa.Celular = Convert.ToString(cmd.Parameters["p_celular"].Value);
                    objEmpresa.Contacto_Cargo = Convert.ToString(cmd.Parameters["p_contacto_cargo"].Value);
                    objEmpresa.Email = Convert.ToString(cmd.Parameters["p_email"].Value);
                    objEmpresa.Contacto = Convert.ToString(cmd.Parameters["p_contacto"].Value);
                    objEmpresa.Telefono = Convert.ToString(cmd.Parameters["p_telefono"].Value);
                    objEmpresa.Estado = Convert.ToString(cmd.Parameters["p_estado"].Value);
                    objEmpresa.Ciudad = Convert.ToString(cmd.Parameters["p_ciudad"].Value);
                    objEmpresa.Codigo_Postal = Convert.ToString(cmd.Parameters["p_codigo_postal"].Value);
                    objEmpresa.Colonia = Convert.ToString(cmd.Parameters["p_colonia"].Value);
                    objEmpresa.Domicilio = Convert.ToString(cmd.Parameters["p_domicilio"].Value);
                    objEmpresa.Nombre_Comercial = Convert.ToString(cmd.Parameters["p_nombre_comercial"].Value);
                    objEmpresa.Razon_Social = Convert.ToString(cmd.Parameters["p_razon_social"].Value);
                    objEmpresa.Ruta_Foto = Convert.ToString(cmd.Parameters["p_logotipo"].Value);
                    objEmpresa.Tipo_Persona = Convert.ToString(cmd.Parameters["p_tipo_persona"].Value);
                    objEmpresa.Id_Empresa = Convert.ToString(cmd.Parameters["p_id_empresa"].Value);
                    System.Web.HttpContext.Current.Session["SessionRutaImagenEmpresa"] = objEmpresa;
                    list.Add(objEmpresa);
                }
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
            }
            finally
            {
                exeProc.LimpiarOracleCommand(ref cmd);
            }
            return list;
        }
        public static List<Btu_Curriculum> ObtenerGridAlumnosRegistrados()
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { };
                object[] Valores = { };
                cmd = exeProc.GenerarOracleCommandCursor_Grid("PKG_VINCULAR.Obt_Grid_Candidatos", ref dr, Parametros, Valores);
                List<Btu_Curriculum> list = new List<Btu_Curriculum>();
                while (dr.Read())
                {
                    Btu_Curriculum objCv = new Btu_Curriculum();
                    objCv.Matricula = Convert.ToString(dr[0]);
                    objCv.Nombre = Convert.ToString(dr[1]);
                    objCv.Domicilio = Convert.ToString(dr[2]);
                    objCv.Fecha_Nacimiento = Convert.ToString(dr[3]);
                    objCv.Telefono = Convert.ToString(dr[4]);
                    objCv.Celular = Convert.ToString(dr[5]);
                    objCv.Correo = Convert.ToString(dr[6]);
                    objCv.Contrasena = Convert.ToString(dr[7]);
                    objCv.Status = Convert.ToString(dr[8]);
                    objCv.Fecha_Creacion = Convert.ToString(dr[9]);
                    objCv.Id = Convert.ToString(dr[10]);
                    objCv.Ruta_Foto = Convert.ToString(dr[11]);
                    list.Add(objCv);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                exeProc.LimpiarOracleCommand(ref cmd);
            }
        }
        public static List<Btu_Vacante> ObtenerGridVacantes(string IdEmpresa)
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            List<Btu_Vacante> list = new List<Btu_Vacante>();
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { "p_id" };
                object[] Valores = { IdEmpresa };
                cmd = exeProc.GenerarOracleCommandCursor_Grid("PKG_VINCULAR.Obt_Grid_Vacantes", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    Btu_Vacante objVacante = new Btu_Vacante();
                    objVacante.Nombre = Convert.ToString(dr[0]);
                    objVacante.Total = Convert.ToString(dr[1]);
                    objVacante.Edad_Minima = Convert.ToString(dr[2]);
                    objVacante.Edad_Maxima = Convert.ToString(dr[3]);
                    objVacante.Salario = Convert.ToString(dr[4]);
                    objVacante.Vigencia_Inicio = Convert.ToString(dr[5]);
                    objVacante.Vigencia_Fin = Convert.ToString(dr[6]);
                    objVacante.Direccion_Entrevista = Convert.ToString(dr[7]);
                    objVacante.Telefono = Convert.ToString(dr[8]);
                    objVacante.Correo = Convert.ToString(dr[9]);
                    objVacante.Grado = Convert.ToString(dr[10]);
                    objVacante.Id = Convert.ToString(dr[11]);
                    objVacante.Actividades = Convert.ToString(dr[12]);
                    objVacante.Flayer_Empresa = Convert.ToString(dr[13]);
                    list.Add(objVacante);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                exeProc.LimpiarOracleCommand(ref cmd);
            }
        }
        public static List<Btu_Vacante> ObtenerDatosVacante(Btu_Vacante objVacante, ref string Verificador)
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            string NombreCompleto = string.Empty;
            List<Btu_Vacante> list = new List<Btu_Vacante>();
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { "P_ID_VACANTE", "P_ID_CANDIDATO" };
                object[] Valores = { objVacante.Id, objVacante.Id_Candidato };
                string[] ParametrosOut = {"P_NOMBRE", "P_TOTAL", "P_EDAD_MINIMA", "P_EDAD_MAXIMA", "P_ESTADO_CIVIL",
              "P_GRADO", "P_EXPERIENCIA", "P_ACTIVIDADES", "P_CONOCIMIENTOS", "P_SALARIO", "P_FRECUENCIA_SALARIO", "P_PRESTACIONES",
              "P_UBICACION", "P_LICENCIA", "P_VIGENCIA_INICIO", "P_VIGENCIA_FIN", "P_TIPO", "P_DIRECCION_ENTREVISTA",
                    "P_TELEFONO", "P_CORREO", "P_COMENTARIOS", "P_RESPONSABLE_ENTREVISTA", "P_ESPECIFICACIONES_ENTREVISTA", "P_IDIOMA", "P_GENERO",
                    "P_JORNADA_LABORAL", "P_FEC_INICIO_LABORES", "P_FLAYER_EMPRESA","P_RADICAR_FUERA", "P_DIS_VIAJAR","P_ID_VACANTE_CANDIDATO", "p_bandera" };
                cmd = exeProc.GenerarOracleCommand_Exe("OBT_BTU_VACANTE", ref Verificador, ref dr, Parametros, Valores, ParametrosOut);

                if (Verificador == "0")
                {
                    objVacante.Nombre = Convert.ToString(cmd.Parameters["P_NOMBRE"].Value);
                    objVacante.Total = Convert.ToString(cmd.Parameters["P_TOTAL"].Value);
                    objVacante.Edad_Minima = Convert.ToString(cmd.Parameters["P_EDAD_MINIMA"].Value);
                    objVacante.Edad_Maxima = Convert.ToString(cmd.Parameters["P_EDAD_MAXIMA"].Value);
                    objVacante.Estado_Civil = Convert.ToString(cmd.Parameters["P_ESTADO_CIVIL"].Value);
                    objVacante.Grado = Convert.ToString(cmd.Parameters["P_GRADO"].Value);
                    objVacante.Experiencia = Convert.ToString(cmd.Parameters["P_EXPERIENCIA"].Value);
                    objVacante.Actividades = Convert.ToString(cmd.Parameters["P_ACTIVIDADES"].Value);
                    objVacante.Conocimientos = Convert.ToString(cmd.Parameters["P_CONOCIMIENTOS"].Value);
                    objVacante.Salario = Convert.ToString(cmd.Parameters["P_SALARIO"].Value);
                    objVacante.Frecuencia_Salario = Convert.ToString(cmd.Parameters["P_FRECUENCIA_SALARIO"].Value);
                    objVacante.Prestaciones = Convert.ToString(cmd.Parameters["P_PRESTACIONES"].Value);
                    objVacante.Ubicacion = Convert.ToString(cmd.Parameters["P_UBICACION"].Value);
                    objVacante.Licencia = Convert.ToString(cmd.Parameters["P_LICENCIA"].Value);
                    objVacante.Vigencia_Inicio = Convert.ToString(cmd.Parameters["P_VIGENCIA_INICIO"].Value);
                    objVacante.Vigencia_Fin = Convert.ToString(cmd.Parameters["P_VIGENCIA_FIN"].Value);
                    objVacante.Tipo = Convert.ToString(cmd.Parameters["P_TIPO"].Value);
                    objVacante.Direccion_Entrevista = Convert.ToString(cmd.Parameters["P_DIRECCION_ENTREVISTA"].Value);
                    objVacante.Telefono = Convert.ToString(cmd.Parameters["P_TELEFONO"].Value);
                    objVacante.Correo = Convert.ToString(cmd.Parameters["P_CORREO"].Value);
                    objVacante.Comentarios = Convert.ToString(cmd.Parameters["P_COMENTARIOS"].Value);
                    objVacante.Responsable_Entrevista = Convert.ToString(cmd.Parameters["P_RESPONSABLE_ENTREVISTA"].Value);
                    objVacante.Especificaciones_Entrevista = Convert.ToString(cmd.Parameters["P_ESPECIFICACIONES_ENTREVISTA"].Value);
                    objVacante.Idioma = Convert.ToString(cmd.Parameters["P_IDIOMA"].Value);
                    objVacante.Genero = Convert.ToString(cmd.Parameters["P_GENERO"].Value);
                    objVacante.Jornada_Laboral = Convert.ToString(cmd.Parameters["P_JORNADA_LABORAL"].Value);
                    objVacante.Fecha_Inicio_Labores = Convert.ToString(cmd.Parameters["P_FEC_INICIO_LABORES"].Value);
                    objVacante.Flayer_Empresa = Convert.ToString(cmd.Parameters["P_FLAYER_EMPRESA"].Value);
                    objVacante.Radicar = Convert.ToString(cmd.Parameters["P_RADICAR_FUERA"].Value);
                    objVacante.Viajar = Convert.ToString(cmd.Parameters["P_DIS_VIAJAR"].Value);
                    objVacante.Id_Candidato = Convert.ToString(cmd.Parameters["P_ID_VACANTE_CANDIDATO"].Value);
                    list.Add(objVacante);
                }
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
            }
            finally
            {
                exeProc.LimpiarOracleCommand(ref cmd);
            }
            return list;
        }
        public static List<Btu_Curriculum> ObtenerGridInteresados(Btu_Vacante objVacante)
        {
            DateTime fechanac;
            DateTime moment = DateTime.Now;
            int year = moment.Year;
            int month = moment.Month;
            int day = moment.Day;
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { "p_id_vacante" };
                object[] Valores = { objVacante.Id };
                cmd = exeProc.GenerarOracleCommandCursor_Grid("PKG_VINCULAR.Obt_Grid_Interesados", ref dr, Parametros, Valores);
                List<Btu_Curriculum> list = new List<Btu_Curriculum>();
                while (dr.Read())
                {
                    Btu_Curriculum objInteresados = new Btu_Curriculum();
                    objInteresados.Nombre = Convert.ToString(dr[0]);
                    objInteresados.objVacantesCandidatos.Id = Convert.ToString(dr[1]);
                    objInteresados.Id = Convert.ToString(dr[2]);
                    objInteresados.objVacantesCandidatos.Status = Convert.ToString(dr[3]);
                    objInteresados.Correo = Convert.ToString(dr[4]);
                    objInteresados.Genero = Convert.ToString(dr[5]);
                    fechanac = Convert.ToDateTime(dr[6]);
                    objInteresados.Ruta_Foto = Convert.ToString(dr[7]);
                    int año = fechanac.Year;
                    int mes = fechanac.Month;
                    int dia = fechanac.Day;

                    int Edad = (year - año);
                    if (month < mes)
                        Edad = Edad - 1;
                    objInteresados.Fecha_Nacimiento = Convert.ToString(Edad);
                    list.Add(objInteresados);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                exeProc.LimpiarOracleCommand(ref cmd);
            }
        }
        public static List<Btu_Vacante> ObtenerGridVacantesAplicadasEmpresas(Btu_Empresa objEmpresa)
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { "p_id" };
                object[] Valores = { objEmpresa.Id_Empresa };
                cmd = exeProc.GenerarOracleCommandCursor_Grid("PKG_VINCULAR.Obt_Grid_Vac_Apli_Empresas", ref dr, Parametros, Valores);
                List<Btu_Vacante> list = new List<Btu_Vacante>();
                while (dr.Read())
                {
                    //DateTime fechanac;
                    //DateTime moment = DateTime.Now;
                    //int year = moment.Year;
                    //int month = moment.Month;
                    //int day = moment.Day;


                    Btu_Vacante objVacante = new Btu_Vacante();
                    objVacante.Nombre = Convert.ToString(dr[0]);
                    objVacante.Total = Convert.ToString(dr[1]);
                    objVacante.Edad_Minima = Convert.ToString(dr[2]);
                    objVacante.Edad_Maxima = Convert.ToString(dr[3]);
                    objVacante.Salario = Convert.ToString(dr[4]);
                    objVacante.Vigencia_Inicio = Convert.ToString(dr[5]);
                    objVacante.Vigencia_Fin = Convert.ToString(dr[6]);
                    objVacante.Direccion_Entrevista = Convert.ToString(dr[7]);
                    objVacante.Telefono = Convert.ToString(dr[8]);
                    objVacante.Correo = Convert.ToString(dr[9]);
                    objVacante.Area_Conocimientos = Convert.ToString(dr[10]);
                    objVacante.Id = Convert.ToString(dr[11]);
                    objVacante.Actividades = Convert.ToString(dr[12]);
                    objVacante.Flayer_Empresa = Convert.ToString(dr[13]);
                    objVacante.Total_Interesados = Convert.ToString(dr[14]);

                    //fechanac = Convert.ToDateTime(dr[7]);
                    //int año = fechanac.Year;
                    //int mes = fechanac.Month;
                    //int dia = fechanac.Day;

                    //int Edad =( year - año);
                    //if (month < mes)
                    //    Edad = Edad - 1;
                    //objGridVacantes.FECHA_NACIMIENTO = Convert.ToString(Edad);
                    list.Add(objVacante);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                exeProc.LimpiarOracleCommand(ref cmd);
            }
        }
        public static List<Btu_Empresa> ObtenerStatusEmpresa(Btu_Empresa objEmpresa, ref string Verificador)
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            string NombreCompleto = string.Empty;
            List<Btu_Empresa> list = new List<Btu_Empresa>();
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { "P_ID_EMPRESA" };
                object[] Valores = { objEmpresa.Id_Empresa };
                string[] ParametrosOut = { "P_STATUS", "p_bandera" };
                cmd = exeProc.GenerarOracleCommand_Exe("OBT_STATUS_EMPRESA", ref Verificador, ref dr, Parametros, Valores, ParametrosOut);

                if (Verificador == "0")
                {
                    objEmpresa.Status = Convert.ToString(cmd.Parameters["P_STATUS"].Value);
                    list.Add(objEmpresa);
                }
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
            }
            finally
            {
                exeProc.LimpiarOracleCommand(ref cmd);
            }
            return list;
        }
        public static List<Btu_Curriculum> ObtenerGridCandidatosDisponibles(Btu_Vacante objVacante)
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            try
            {
                DateTime fechanac;
                DateTime moment = DateTime.Now;
                int year = moment.Year;
                int month = moment.Month;
                int day = moment.Day;


                OracleDataReader dr = null;
                string[] Parametros = { "p_id_vacante", "p_id_empresa" };
                object[] Valores = { objVacante.Id, objVacante.Id_Empresa };
                cmd = exeProc.GenerarOracleCommandCursor_Grid("PKG_VINCULAR.Obt_Grid_CandidatosDisponibles", ref dr, Parametros, Valores);
                List<Btu_Curriculum> lisCandidatos = new List<Btu_Curriculum>();
                while (dr.Read())
                {


                    Btu_Curriculum objCandidato = new Btu_Curriculum();
                    objCandidato.Id = Convert.ToString(dr[0]);
                    objCandidato.Nombre = (Convert.ToString(dr[0]) == "0") ? "ACTUALIZE EL ESTATUS DE LOS CANDIDATOS ENTREVISTADOS" : Convert.ToString(dr[1]);
                    fechanac = Convert.ToDateTime(dr[2]);
                    objCandidato.Celular = Convert.ToString(dr[3]);
                    objCandidato.Correo = Convert.ToString(dr[4]);
                    objCandidato.Genero = Convert.ToString(dr[5]);
                    objCandidato.Ruta_Foto = Convert.ToString(dr[6]);
                    objCandidato.Carrera = Convert.ToString(dr[7]);
                    int año = fechanac.Year;
                    int mes = fechanac.Month;
                    int dia = fechanac.Day;
                    int Edad = (year - año);
                    if (month < mes)
                        Edad = Edad - 1;
                    if (Edad == 0)
                        objCandidato.Fecha_Nacimiento = Convert.ToString("");
                    else
                        objCandidato.Fecha_Nacimiento = Convert.ToString(Edad);

                    lisCandidatos.Add(objCandidato);
                }
                return lisCandidatos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                exeProc.LimpiarOracleCommand(ref cmd);
            }
        }
        public static List<Btu_Vacantes_Candidatos> ObtenerTotalVacantes(ref string Verificador)
        {
            Btu_Vacantes_Candidatos objVacante = new Btu_Vacantes_Candidatos();
            List<Btu_Vacantes_Candidatos> list = new List<Btu_Vacantes_Candidatos>();
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { };
                object[] Valores = { };
                string[] ParametrosOut = { "P_TOTAL_VACANTES", "P_BANDERA" };
                cmd = exeProc.GenerarOracleCommand_Exe("OBT_TODAS_VACANTES", ref Verificador, ref dr, Parametros, Valores, ParametrosOut);

                if (Verificador == "0")
                {
                    objVacante.Total_Vacantes = Convert.ToString(cmd.Parameters["P_TOTAL_VACANTES"].Value);
                }
                list.Add(objVacante);
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
            }
            finally
            {
                exeProc.LimpiarOracleCommand(ref cmd);
            }
            return list;
        }
        public static List<Btu_Curriculum> ObtenerStatusCandidato(Btu_Curriculum objCv, ref string Verificador)
        {
            List<Btu_Curriculum> list = new List<Btu_Curriculum>();
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { "P_ID" };
                object[] Valores = { objCv.Id };
                string[] ParametrosOut = { "P_STATUS", "P_BANDERA" };
                cmd = exeProc.GenerarOracleCommand_Exe("OBT_STATUS_CANDIDATO", ref Verificador, ref dr, Parametros, Valores, ParametrosOut);

                if (Verificador == "0")
                {
                    objCv.Status = Convert.ToString(cmd.Parameters["P_STATUS"].Value);
                }
                list.Add(objCv);
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
            }
            finally
            {
                exeProc.LimpiarOracleCommand(ref cmd);
            }
            return list;
        }
        public static List<Btu_Vacantes_Candidatos> ObtenerGridStatusAplicaciones(Btu_Curriculum objCv)
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { "p_id" };
                object[] Valores = { objCv.Id };
                cmd = exeProc.GenerarOracleCommandCursor_Grid("PKG_VINCULAR.Obt_Grid_Status_Aplicaciones", ref dr, Parametros, Valores);
                List<Btu_Vacantes_Candidatos> list = new List<Btu_Vacantes_Candidatos>();
                while (dr.Read())
                {
                    Btu_Vacantes_Candidatos objVacCand = new Btu_Vacantes_Candidatos();
                    objVacCand.Status = Convert.ToString(dr[0]);
                    objVacCand.Observaciones = Convert.ToString(dr[1]);
                    //objVacCand.btuBasicos.TIPO = Convert.ToString(dr[2]);
                    list.Add(objVacCand);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                exeProc.LimpiarOracleCommand(ref cmd);
            }
        }
        public static List<Btu_Vacante> ObtenerVacantesXstatus(Btu_Vacantes_Candidatos objVacante)
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { "p_id_candidato", "p_status" };
                object[] Valores = { objVacante.Id_Interesado, objVacante.Status };
                cmd = exeProc.GenerarOracleCommandCursor_Grid("PKG_VINCULAR.Obt_Grid_Vacantes_Status", ref dr, Parametros, Valores);
                List<Btu_Vacante> list = new List<Btu_Vacante>();
                while (dr.Read())
                {
                    Btu_Vacante objVac = new Btu_Vacante();
                    objVac.Nombre = Convert.ToString(dr[0]);
                    objVac.Id = Convert.ToString(dr[1]);
                    objVac.Empresa = Convert.ToString(dr[2]);
                    objVac.objVacCand.Id = Convert.ToString(dr[3]);
                    objVac.objVacCand.Status = Convert.ToString(dr[4]);
                    //objVacCand.btuBasicos.TIPO = Convert.ToString(dr[2]);
                    list.Add(objVac);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                exeProc.LimpiarOracleCommand(ref cmd);
            }
        }
        public static List<Btu_Vacante> ObtenerGridVacantesCandidatos(Btu_Curriculum objCv, string from, string until)
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { "p_id", "p_from", "p_until" };
                object[] Valores = { objCv.Id, from, until };
                cmd = exeProc.GenerarOracleCommandCursor_Grid("PKG_VINCULAR.Obt_Grid_Vacantes_Candidatos", ref dr, Parametros, Valores);
                List<Btu_Vacante> list = new List<Btu_Vacante>();
                while (dr.Read())
                {
                    Btu_Vacante objVacante = new Btu_Vacante();
                    objVacante.Nombre = Convert.ToString(dr[1]);
                    objVacante.Total = Convert.ToString(dr[2]);
                    objVacante.Edad_Minima = Convert.ToString(dr[3]);
                    objVacante.Edad_Maxima = Convert.ToString(dr[4]);
                    objVacante.Salario = Convert.ToString(dr[5]);
                    objVacante.Area_Conocimientos = Convert.ToString(dr[6]);
                    objVacante.Id = Convert.ToString(dr[7]);
                    objVacante.Actividades = Convert.ToString(dr[8]);
                    objVacante.Logotipo = Convert.ToString(dr[9]);
                    objVacante.Razon_social = Convert.ToString(dr[10]);
                    objVacante.Ubicacion = Convert.ToString(dr[11]);
                    objVacante.objVacCand.Status = Convert.ToString(dr[12]);
                    objVacante.objVacCand.Observaciones = Convert.ToString(dr[13]);
                    objVacante.objVacCand.Id = Convert.ToString(dr[14]);

                    list.Add(objVacante);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                exeProc.LimpiarOracleCommand(ref cmd);
            }
        }
        public static List<Btu_Empresa> ObtenerTotalEmpresas()
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { };
                object[] Valores = { };
                cmd = exeProc.GenerarOracleCommandCursor_Grid("PKG_VINCULAR.Obt_Grid_Todas_Empresas", ref dr, Parametros, Valores);
                List<Btu_Empresa> list = new List<Btu_Empresa>();
                while (dr.Read())
                {
                    Btu_Empresa objEmpresa = new Btu_Empresa();
                    objEmpresa.Total_Empresas = Convert.ToString(dr[0]);
                    objEmpresa.Status = Convert.ToString(dr[1]);                    
                    list.Add(objEmpresa);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                exeProc.LimpiarOracleCommand(ref cmd);
            }

        }
        public static List<Btu_Curriculum> ObtenerTotalCandidatos()
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { };
                object[] Valores = { };
                cmd = exeProc.GenerarOracleCommandCursor_Grid("PKG_VINCULAR.Obt_Grid_Todos_Candidatos", ref dr, Parametros, Valores);
                List<Btu_Curriculum> list = new List<Btu_Curriculum>();
                while (dr.Read())
                {
                    Btu_Curriculum objCandidato = new Btu_Curriculum();
                    objCandidato.Total_Candidatos = Convert.ToString(dr[0]);
                    objCandidato.Status = Convert.ToString(dr[1]);
                    list.Add(objCandidato);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                exeProc.LimpiarOracleCommand(ref cmd);
            }

        }
        public static List<Btu_Empresa> ObtenerGridEmpresasRegistradas()
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { };
                object[] Valores = { };
                cmd = exeProc.GenerarOracleCommandCursor_Grid("PKG_VINCULAR.Obt_Grid_Empresas", ref dr, Parametros, Valores);
                List<Btu_Empresa> listGridEmpresas = new List<Btu_Empresa>();
                while (dr.Read())
                {
                    Btu_Empresa objGridEmpresa = new Btu_Empresa();
                    objGridEmpresa.Razon_Social = Convert.ToString(dr[0]);
                    objGridEmpresa.Nombre_Comercial = Convert.ToString(dr[1]);
                    objGridEmpresa.Actividad = Convert.ToString(dr[2]);
                    objGridEmpresa.Codigo_Postal = Convert.ToString(dr[3]);
                    objGridEmpresa.Status = Convert.ToString(dr[4]);
                    objGridEmpresa.Contacto = Convert.ToString(dr[5]);
                    objGridEmpresa.Contacto_Cargo = Convert.ToString(dr[6]);
                    objGridEmpresa.Telefono = Convert.ToString(dr[7]);
                    objGridEmpresa.Celular = Convert.ToString(dr[8]);
                    objGridEmpresa.Email = Convert.ToString(dr[9]);
                    objGridEmpresa.Contrasena = Convert.ToString(dr[10]);
                    objGridEmpresa.Medio_Contacto = Convert.ToString(dr[11]);
                    objGridEmpresa.Rfc = Convert.ToString(dr[12]);
                    objGridEmpresa.Id = Convert.ToString(dr[13]);
                    objGridEmpresa.Total = Convert.ToString(dr[14]);
                    objGridEmpresa.Motivo = Convert.ToString(dr[15]);
                    listGridEmpresas.Add(objGridEmpresa);
                }
                return listGridEmpresas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                exeProc.LimpiarOracleCommand(ref cmd);
            }
        }
        public static List<Btu_Curriculum> ObtenerGridCandidatos()
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { };
                object[] Valores = { };
                cmd = exeProc.GenerarOracleCommandCursor_Grid("PKG_VINCULAR.Obt_Grid_Candidatos", ref dr, Parametros, Valores);
                List<Btu_Curriculum> list = new List<Btu_Curriculum>();
                while (dr.Read())
                {
                    Btu_Curriculum objCandidato = new Btu_Curriculum();
                    objCandidato.Matricula = Convert.ToString(dr[0]);
                    objCandidato.Nombre = Convert.ToString(dr[1]);
                    objCandidato.Domicilio = Convert.ToString(dr[2]);
                    objCandidato.Fecha_Nacimiento = Convert.ToString(dr[3]);
                    objCandidato.Telefono = Convert.ToString(dr[4]);
                    objCandidato.Celular = Convert.ToString(dr[5]);
                    objCandidato.Correo = Convert.ToString(dr[6]);
                    objCandidato.Contrasena = Convert.ToString(dr[7]);
                    objCandidato.Status = Convert.ToString(dr[8]);
                    objCandidato.Fecha_Creacion = Convert.ToString(dr[9]);
                    objCandidato.Id = Convert.ToString(dr[10]);
                    objCandidato.Ruta_Foto = Convert.ToString(dr[11]);
                    objCandidato.Carrera = Convert.ToString(dr[12]);
                    list.Add(objCandidato);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                exeProc.LimpiarOracleCommand(ref cmd);
            }
        }
        public static List<Btu_Vacante> ObtenerEstatusVacanCandidato(Btu_Vacante objVacante)
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { "p_id_candidato" };
                object[] Valores = { objVacante.Id };
                cmd = exeProc.GenerarOracleCommandCursor_Grid("PKG_VINCULAR.Obt_Grid_Status_Candidato", ref dr, Parametros, Valores);
                List<Btu_Vacante> listVacante = new List<Btu_Vacante>();

                while (dr.Read())
                {
                    Btu_Vacante objVacantes = new Btu_Vacante();
                    objVacantes.objVacCand.Status = Convert.ToString(dr[0]);
                    objVacantes.Nombre = Convert.ToString(dr[1]);
                    objVacantes.Razon_social = Convert.ToString(dr[2]);

                    listVacante.Add(objVacantes);
                }
                return listVacante;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                exeProc.LimpiarOracleCommand(ref cmd);
            }
        }
        public static List<Btu_Vacante> ObtenerGridVacantesVencidas()
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { };
                object[] Valores = { };
                cmd = exeProc.GenerarOracleCommandCursor_Grid("PKG_VINCULAR.Obt_Grid_Vacantes_Vencidas", ref dr, Parametros, Valores);
                List<Btu_Vacante> list = new List<Btu_Vacante>();
                while (dr.Read())
                {
                    Btu_Vacante objVacante = new Btu_Vacante();
                    objVacante.Id = Convert.ToString(dr[0]);
                    objVacante.Nombre = Convert.ToString(dr[1]);
                    objVacante.Empresa = Convert.ToString(dr[2]);
                    objVacante.Vigencia_Fin = Convert.ToString(dr[3]);
                    objVacante.Correo = Convert.ToString(dr[4]);
                    list.Add(objVacante);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                exeProc.LimpiarOracleCommand(ref cmd);
            }
        }
        public static List<Btu_Curriculum> ObtenerGridCorreosCandidatos()
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { };
                object[] Valores = { };
                cmd = exeProc.GenerarOracleCommandCursor_Grid("PKG_VINCULAR.Obt_Grid_Inf_Candidatos", ref dr, Parametros, Valores);
                List<Btu_Curriculum> list = new List<Btu_Curriculum>();
                while (dr.Read())
                {
                    Btu_Curriculum objCandidato = new Btu_Curriculum();
                    objCandidato.Correo = Convert.ToString(dr[0]);
                    objCandidato.Nombre = Convert.ToString(dr[1]);
                    objCandidato.Carrera = Convert.ToString(dr[2]);                    
                    list.Add(objCandidato);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                exeProc.LimpiarOracleCommand(ref cmd);
            }
        }


        public static MENU ObtenerMenu(string Valor)
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();

            try
            {

                OracleDataReader dr = null;
                string[] Parametros = { "p_tipo" };
                object[] Valores = { Valor };
                cmd = exeProc.GenerarOracleCommandCursor("PKG_VINCULAR.Obt_Menu_Usuario", ref dr, Parametros, Valores);
                List<MENU> listMenu = new List<MENU>();
                List<MENU> listMenu2 = new List<MENU>();
                List<MENU> list = new List<MENU>();
                //List<MENUPADRE> listMenuPadre = new List<MENUPADRE>();
                List<SUBMENU> listSubMenu = new List<SUBMENU>();
                MENU objMenu = new MENU();
                MENU objMenu2 = new MENU();
                while (dr.Read())
                {
                    objMenu.MENUPADRE.Add(new MENUPADRE(Convert.ToInt32(dr[0]), Convert.ToString(dr[1]), Convert.ToString(dr[2]), Convert.ToString(dr[3]), Convert.ToInt32(dr[4])));
                    listMenu.Add(objMenu);
                    listMenu2.Add(objMenu);
                }

                var listMenuPadre = from c in listMenu[0].MENUPADRE
                                    where (c.ID_PADRE == 15808)
                                    select c;

                //foreach (MENU mnu in listMenu)
                //{
                foreach (MENUPADRE mnuPadre in listMenuPadre)//mnu.MENUPADRE)
                {
                    if (mnuPadre.PADRE == "")
                    {
                        listSubMenu = SubMenu(listMenu2, mnuPadre.ID);
                        objMenu2.MENUPADRE.Add(new MENUPADRE(mnuPadre.ID, mnuPadre.NOMBRE, mnuPadre.CLAVE, mnuPadre.PADRE, 0, listSubMenu));
                    }
                }
                //}

                //var list = from c in listMenu[0].MENUPADRE
                //           where (c.ID_PADRE==10)
                //           select c;
                //list.Add(objMenu2);
                return objMenu2;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                exeProc.LimpiarOracleCommand(ref cmd);
            }

        }

        public static List<SUBMENU> SubMenu(List<MENU> ListMenu, int IdMenu)
        {
            try
            {
                List<SUBMENU> listarSubMenu = new List<SUBMENU>();
                var list = from c in ListMenu[0].MENUPADRE
                           where (c.ID_PADRE == IdMenu)
                           select c;
                foreach (MENUPADRE mnuPadre in list)
                {
                    listarSubMenu.Add(new SUBMENU(mnuPadre.ID, mnuPadre.NOMBRE, mnuPadre.CLAVE));
                }

                return listarSubMenu;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}