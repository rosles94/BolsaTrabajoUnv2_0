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
    }
}