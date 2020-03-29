using BolsaTrabajoUnv2_0.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolsaTrabajoUnv2_0.Data
{
    public class GuardarDartaContext
    {
        public static void RegistrarDatosEmpresa(Btu_Empresa objDatosEmpresa, ref string Verificador)
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = {"P_RAZON_SOCIAL", "P_NOMBRE_COMERCIAL", "P_ACTIVIDAD", "P_CODIGO_POSTAL", "P_ESTADO",
                    "P_CIUDAD", "P_COLONIA", "P_DOMICILIO", "P_RFC", "P_CONTACTO", "P_CONTACTO_CARGO", "P_TELEFONO", "P_CELULAR",
                    "P_EMAIL", "P_MEDIO_CONTACTO", "P_CONTRASENIA", "P_LOGOTIPO", "P_TIPO_PERSONA"};
                object[] Valores = { objDatosEmpresa.Razon_Social, objDatosEmpresa.Nombre_Comercial, objDatosEmpresa.Actividad, objDatosEmpresa.Codigo_Postal, objDatosEmpresa.Estado,
                objDatosEmpresa.Ciudad, objDatosEmpresa.Colonia, objDatosEmpresa.Domicilio, objDatosEmpresa.Rfc, objDatosEmpresa.Contacto, objDatosEmpresa.Contacto_Cargo, objDatosEmpresa.Telefono, objDatosEmpresa.Celular,
                objDatosEmpresa.Email, objDatosEmpresa.Medio_Contacto, objDatosEmpresa.Contrasena, objDatosEmpresa.Ruta_Foto, objDatosEmpresa.Tipo_Persona};
                string[] ParametrosOut = { "P_BANDERA" };
                cmd = exeProc.GenerarOracleCommand("INS_DATOS_EMPRESA", ref Verificador, ref dr, Parametros, Valores, ParametrosOut);
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
            }
            finally
            {
                exeProc.LimpiarOracleCommand(ref cmd);
            }
        }
    }
}