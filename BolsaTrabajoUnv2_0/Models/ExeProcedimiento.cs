using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BolsaTrabajoUnv2_0.Models
{
    public class ExeProcedimiento
    {
        #region Variable
        private OracleConnection cn;
        private OracleTransaction trans;
        OracleCommand cmd = default(OracleCommand);

        Conexion objConexion = new Conexion();

        #endregion
        public ExeProcedimiento()
        {
            Conexion objConexion = new Conexion();
            cn = objConexion.getConexion();
        }
        public OracleCommand GenerarOracleCommandCursor(string SP, ref OracleDataReader dr, string[] Parametros, object[] Valores)
        {
            //try
            //{
            cmd = new OracleCommand(SP, cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            if (trans != null) cmd.Transaction = trans;
            if (trans == null) cn.Open();
            //OracleParameter par1 = new OracleParameter();
            if (Parametros != null)
                for (int i = 0; i <= Parametros.Length - 1; i++)
                    cmd.Parameters.Add(Parametros[i], OracleDbType.Varchar2).Value = Valores[i];

            cmd.Parameters.Add("p_registros", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            dr = cmd.ExecuteReader();
            return cmd;

        }

        //public OracleCommand GenerarOracleCommand(string SP, string[] ParametrosIn, object[] Valores, string[] ParametrosOut)
        //{

        //    OracleCommand cmd = new OracleCommand(SP, Cnn);
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //    for (int i = 0; i < ParametrosIn.Length; i++)
        //    {
        //        cmd.Parameters.Add(ParametrosIn[i], OracleDbType.Varchar2).Value = Valores[i];
        //    }

        //    for (int i = 0; i < ParametrosOut.Length; i++)
        //    {
        //        cmd.Parameters.Add(ParametrosOut[i], OracleDbType.Varchar2, 1024).Direction = ParameterDirection.Output;
        //    }


        //    try
        //    {
        //        if (trans != null) cmd.Transaction = trans;
        //        if (trans == null) Cnn.Open();
        //        cmd.ExecuteNonQuery();

        //        return cmd;
        //    }


        //    catch (Exception e)
        //    {

        //        throw new Exception(e.Message);
        //    }

        //}
        //public OracleCommand GenerarOracleCommandCursor(string SP, ref OracleDataReader dr, string[] Parametros, object[] Valores)
        //{
        //    try
        //    {

        //        Conexion objConexion = new Conexion();
        //        OracleConnection cn = objConexion.getConexion();
        //        cn.Open();
        //        OracleCommand cmd = cn.CreateCommand();
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        cmd.CommandText = SP;
        //        OracleParameter par1 = new OracleParameter();
        //        par1.OracleDbType = OracleDbType.RefCursor;
        //        par1.Direction = System.Data.ParameterDirection.Output;

        //        //if (Parametros != null)
        //        //    for (int i = 0; i <= Parametros.Length - 1; i++)
        //        //        cmd.Parameters.Add(Parametros[i], OracleDbType.Varchar2).Value = Valores[i];

        //        cmd.Parameters.Add(par1);
        //        cmd.ExecuteNonQuery();
        //        //OracleRefCursor cursor = (OracleRefCursor)par1.Value;
        //        //OracleDataReader dr = cursor.GetDataReader();
        //        return cmd;

        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }
        //}

        public OracleCommand GenerarOracleCommand_Exe(string SP, ref string Verificador, ref OracleDataReader dr, string[] ParametrosIn, object[] Valores, string[] ParametrosOut)
        {

            cmd = new OracleCommand(SP, cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            string valor = "";
            for (int i = 0; i <= ParametrosIn.Length - 1; i++)
            {
                valor = Valores[i].GetType().Name;
                if (valor == "Double")
                    cmd.Parameters.Add(ParametrosIn[i], OracleDbType.Double).Value = Valores[i];
                else if (valor == "Int32")
                    cmd.Parameters.Add(ParametrosIn[i], OracleDbType.Int32).Value = Valores[i];
                else
                    cmd.Parameters.Add(ParametrosIn[i], OracleDbType.Varchar2).Value = Valores[i];
            }
            for (int i = 0; i <= ParametrosOut.Length - 1; i++)
            {
                cmd.Parameters.Add(ParametrosOut[i], OracleDbType.Varchar2, 1024).Direction = ParameterDirection.Output;
            }
            try
            {

                if (trans != null) cmd.Transaction = trans;
                if (trans == null) cn.Open();
                cmd.ExecuteNonQuery();
                Verificador = cmd.Parameters["P_Bandera"].Value.ToString();
                return cmd;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static List<Comun> GenerarOracleCommandCursor(string SP)
        {
            Conexion objConexion = new Conexion();
            OracleConnection cn = objConexion.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = SP;
            OracleParameter par1 = new OracleParameter();
            par1.OracleDbType = OracleDbType.RefCursor;
            par1.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(par1);
            cmd.ExecuteNonQuery();
            OracleRefCursor cursor = (OracleRefCursor)par1.Value;
            OracleDataReader dr = cursor.GetDataReader();


            List<Comun> listarCombo = new List<Comun>();
            while (dr.Read())
            {
                Comun objCombo = new Comun();
                objCombo.Id = Convert.ToString(dr["Id"]);
                objCombo.Descripcion = Convert.ToString(dr["Descripcion"]);
                listarCombo.Add(objCombo);
            }
            cn.Close();
            par1.Dispose();
            cmd.Dispose();
            cn.Dispose();
            objConexion = null;
            return listarCombo;

        }
        public static List<Comun> GenerarOracleCommandCursor_Combo(string SP, string[] Parametros, object[] Valores)
        {
            Conexion objConexion = new Conexion();
            OracleConnection cn = objConexion.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.CommandText = SP;
            OracleParameter par1 = new OracleParameter();
            if (Parametros != null)
                for (int i = 0; i <= Parametros.Length - 1; i++)
                    cmd.Parameters.Add(Parametros[i], OracleDbType.Varchar2).Value = Valores[i];


            par1.OracleDbType = OracleDbType.RefCursor;
            par1.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(par1);


            cmd.ExecuteNonQuery();
            OracleRefCursor cursor = (OracleRefCursor)par1.Value;
            OracleDataReader dr = cursor.GetDataReader();


            List<Comun> listarCombo = new List<Comun>();
            while (dr.Read())
            {
                Comun objCombo = new Comun();
                objCombo.Id = Convert.ToString(dr[0]);
                objCombo.Descripcion = Convert.ToString(dr[1]);
                listarCombo.Add(objCombo);
            }
            cn.Close();
            par1.Dispose();
            cmd.Dispose();
            cn.Dispose();
            objConexion = null;
            return listarCombo;

        }
        public static List<Comun> GenerarOracleCommandCursor_Combo(string SP)
        {
            Conexion objConexion = new Conexion();
            OracleConnection cn = objConexion.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = SP;
            OracleParameter par1 = new OracleParameter();
            par1.OracleDbType = OracleDbType.RefCursor;
            par1.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(par1);
            cmd.ExecuteNonQuery();
            OracleRefCursor cursor = (OracleRefCursor)par1.Value;
            OracleDataReader dr = cursor.GetDataReader();


            List<Comun> listarCombo = new List<Comun>();
            while (dr.Read())
            {
                Comun objCombo = new Comun();
                objCombo.Id = Convert.ToString(dr["Id"]);
                objCombo.Descripcion = Convert.ToString(dr["Descripcion"]);
                listarCombo.Add(objCombo);
            }
            cn.Close();
            par1.Dispose();
            cmd.Dispose();
            cn.Dispose();
            objConexion = null;
            return listarCombo;

        }
        public OracleCommand GenerarOracleCommandCursor_Grid(string SP, ref OracleDataReader dr, string[] Parametros, object[] Valores)
        {
            //try
            //{
            cmd = new OracleCommand(SP, cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            if (trans != null) cmd.Transaction = trans;
            if (trans == null) cn.Open();
            //OracleParameter par1 = new OracleParameter();
            if (Parametros != null)
                for (int i = 0; i <= Parametros.Length - 1; i++)
                    cmd.Parameters.Add(Parametros[i], OracleDbType.Varchar2).Value = Valores[i];

            cmd.Parameters.Add("p_registros", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            dr = cmd.ExecuteReader();
            return cmd;
            //}
            //catch(Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
            //return cmd;
        }

        public OracleCommand GenerarOracleCommandCursor_Grid(string SP, ref OracleDataReader dr)
        {
            //try
            //{
            cmd = new OracleCommand(SP, cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            if (trans != null) cmd.Transaction = trans;
            if (trans == null) cn.Open();
            //OracleParameter par1 = new OracleParameter();     
            cmd.Parameters.Add("p_registros", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            dr = cmd.ExecuteReader();
            return cmd;
            //}
            //catch(Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
            //return cmd;
        }

        public OracleCommand GenerarOracleCommand(string SP, ref string Verificador, ref OracleDataReader dr, string[] ParametrosIn, object[] Valores, string[] ParametrosOut)
        {

            cmd = new OracleCommand(SP, cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            string Tipo = "";
            for (int i = 0; i <= ParametrosIn.Length - 1; i++)
            {
                Tipo = Valores[i].GetType().Name;
                if (Tipo == "Double")
                {
                    if (Valores[i] == null)
                        cmd.Parameters.Add(ParametrosIn[i], OracleDbType.Double).Value = 0;
                    else
                        cmd.Parameters.Add(ParametrosIn[i], OracleDbType.Double).Value = Valores[i];
                }
                else if (Tipo == "Int32")
                    if (Valores[i] == null)
                        cmd.Parameters.Add(ParametrosIn[i], OracleDbType.Int32).Value = 0;
                    else
                        cmd.Parameters.Add(ParametrosIn[i], OracleDbType.Int32).Value = Valores[i];
                else
                {
                    if (Valores[i] == null)
                        cmd.Parameters.Add(ParametrosIn[i], OracleDbType.Varchar2).Value = "";
                    else
                        cmd.Parameters.Add(ParametrosIn[i], OracleDbType.Varchar2).Value = Valores[i];
                }
            }
            for (int i = 0; i <= ParametrosOut.Length - 1; i++)
            {
                cmd.Parameters.Add(ParametrosOut[i], OracleDbType.Varchar2, 1024).Direction = ParameterDirection.Output;
            }
            try
            {

                if (trans != null) cmd.Transaction = trans;
                if (trans == null) cn.Open();
                cmd.ExecuteNonQuery();
                Verificador = cmd.Parameters["P_Bandera"].Value.ToString();
                return cmd;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void LimpiarOracleCommand(ref OracleCommand cmd)
        {
            try
            {
                if (cmd != null)
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    cmd.Dispose();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
            finally
            {
                if (cn.State != System.Data.ConnectionState.Closed)
                {
                    cn.Close();
                }
            }

        }

        public OracleCommand GenerarOracleCommandCursor(string SP, ref OracleDataReader dr)
        {
            cmd = new OracleCommand(SP, cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            if (trans != null) cmd.Transaction = trans;
            if (trans == null) cn.Open();
            cmd.Parameters.Add("p_registros", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            dr = cmd.ExecuteReader();
            return cmd;
        }
    }
}