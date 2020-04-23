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

                if(Verificador == "0")
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
                string[] Parametros = { "P_TIPO", "P_EMAIL", "P_PASSWORD"};
                object[] Valores = { objSesion.Tipo, objSesion.Email, objSesion.Password };
                string[] ParametrosOut = {"P_EXISTE", "P_MATRICULA", "P_NOMBRE", "P_REGISTRADO", "P_ID", "P_EMAIL_2", "p_bandera" };
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
                object[] Valores = { objSesion.Matricula};
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
    }
}