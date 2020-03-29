﻿using BolsaTrabajoUnv2_0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolsaTrabajoUnv2_0.Data
{
    public class CursorDataContext
    {
        public static List<Comun> TipoUsuario()
        {
            string[] Parametros = { };
            object[] Valores = { };
            var Lista = ExeProcedimiento.GenerarOracleCommandCursor_Combo("PKG_VINCULAR.Obt_Combo_Tipo_Usuario", Parametros, Valores);
            return Lista;
        }

        public static List<Comun> ComboSubtipos(string Tipo)
        {
            string[] Parametros = { "p_usuario" };
            object[] Valores = { Tipo };
            var Lista = ExeProcedimiento.GenerarOracleCommandCursor_Combo("PKG_VINCULAR.Obt_Combo_SubTipos", Parametros, Valores);
            return Lista;
        }

        public static List<Comun> ComboEstados()
        {
            string[] Parametros = { "p_pais", "parametro2" };
            object[] Valores = { "1", "" };
            var Lista = ExeProcedimiento.GenerarOracleCommandCursor_Combo("SIGA09.PKG_CONTRATOS.Obt_Combo_Estados", Parametros, Valores);
            return Lista;
        }

        public static List<Comun> ComboMunicipios(string Estado)
        {
            string[] Parametros = { "p_edo", "parametro2" };
            object[] Valores = { Estado, "" };
            var Lista = ExeProcedimiento.GenerarOracleCommandCursor_Combo("SIGA09.PKG_CONTRATOS.Obt_Combo_Municipios", Parametros, Valores);
            return Lista;
        }

        public static List<Comun> ComboCarreras() //string Dependencia
        {
            string[] Parametros = { }; //"p_dependencia"
            object[] Valores = { }; //Dependencia
            var Lista = ExeProcedimiento.GenerarOracleCommandCursor_Combo("PKG_VINCULAR.Obt_Combo_Carreras", Parametros, Valores);
            return Lista;
        }

        public static List<Comun> ComboGradoEstudios()
        {
            string[] Parametros = { };
            object[] Valores = { };
            var Lista = ExeProcedimiento.GenerarOracleCommandCursor_Combo("PKG_VINCULAR.Obt_Combo_Nivel_Estudios", Parametros, Valores);
            return Lista;
        }

        public static List<Comun> ComboTipoCurso()
        {
            string[] Parametros = { };
            object[] Valores = { };
            var Lista = ExeProcedimiento.GenerarOracleCommandCursor_Combo("PKG_VINCULAR.Obt_Combo_Tipo_Otros", Parametros, Valores);
            return Lista;
        }

        public static List<Comun> ComboVacantesEmpresa(String id_empresa)
        {
            string[] Parametros = { "p_id_empresa" };
            object[] Valores = { id_empresa };
            var Lista = ExeProcedimiento.GenerarOracleCommandCursor_Combo("PKG_VINCULAR.Obt_Combo_Vacantes_Empresa", Parametros, Valores);
            return Lista;
        }

        public static List<Comun> ComboTipoPersona()
        {
            string[] Parametros = {  };
            object[] Valores = {  };
            var Lista = ExeProcedimiento.GenerarOracleCommandCursor_Combo("PKG_VINCULAR.Obt_Combo_Tipo_Persona", Parametros, Valores);
            return Lista;
        }

        public static List<Comun> ComboMedioContacto()
        {
            string[] Parametros = { };
            object[] Valores = { };
            var Lista = ExeProcedimiento.GenerarOracleCommandCursor_Combo("PKG_VINCULAR.Obt_Combo_Medio_Contacto", Parametros, Valores);
            return Lista;
        }

    }
}
