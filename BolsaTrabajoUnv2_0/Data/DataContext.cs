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
    }
}