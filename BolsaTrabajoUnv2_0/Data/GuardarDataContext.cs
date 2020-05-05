using BolsaTrabajoUnv2_0.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolsaTrabajoUnv2_0.Data
{
    public class GuardarDataContext
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
        public static Btu_Curriculum GuardarInformacionCandidatoBD(Btu_Curriculum objInfoCandidato, ref string Verificador)
        {            
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = {"p_matricula", "p_paterno", "p_materno",
                    "p_nombre", "p_domicilio", "p_municipio", "p_estado",
                    "p_nacimiento", "p_telefono", "p_celular", "p_correo",
                    "p_objetivo", "p_interes", "p_contrasena", "p_tipo", "p_usuario", "p_genero",
                    "p_ruta_foto", "p_codigo_pos", "p_colonia"};
                object[] Valores = { objInfoCandidato.Matricula, objInfoCandidato.Paterno, objInfoCandidato.Materno, objInfoCandidato.Nombre,
                objInfoCandidato.Domicilio, objInfoCandidato.Municipio, objInfoCandidato.Estado, objInfoCandidato.Fecha_Nacimiento, objInfoCandidato.Telefono,
                objInfoCandidato.Celular, objInfoCandidato.Correo, objInfoCandidato.Objetivo, objInfoCandidato.Intereses, objInfoCandidato.Contrasena, objInfoCandidato.Tipo,
                objInfoCandidato.Usuario_Modificacion, objInfoCandidato.Genero, objInfoCandidato.Ruta_Foto, objInfoCandidato.Codigo_Postal, objInfoCandidato.Colonia};
                string[] ParametrosOut = { "p_id", "P_BANDERA" };
                cmd = exeProc.GenerarOracleCommand("INS_BTU_CURRICULUM", ref Verificador, ref dr, Parametros, Valores, ParametrosOut);
                objInfoCandidato.Id = Convert.ToString(cmd.Parameters["p_id"].Value);                
            }            
            catch (Exception ex)
            {
                Verificador = ex.Message;
            }
            finally
            {
                exeProc.LimpiarOracleCommand(ref cmd);
            }

            return objInfoCandidato;
        }
        public static void GuardarCurriculumInformacionBD(Btu_Curriculum objId, List<Btu_Curriculum_Informacion> listInformacionCurriculum, ref string Verificador)
        {
            for (int i = 0; i < listInformacionCurriculum.Count; i++)
            {
                OracleCommand cmd = null;
                ExeProcedimiento exeProc = new ExeProcedimiento();
                try
                {
                    OracleDataReader dr = null;
                    string[] Parametros = {"p_id_curriculum", "p_tipo", "p_subtipo",
                    "p_institucion", "p_carrera", "p_area", "p_descripcion",
                    "p_principal", "p_fecha_inicio", "p_fecha_fin", "p_id_carrera", "p_contacto"};
                    object[] Valores = { objId.Id, listInformacionCurriculum[i].Tipo, listInformacionCurriculum[i].Subtipo,
                listInformacionCurriculum[i].Institucion, listInformacionCurriculum[i].Carrera, listInformacionCurriculum[i].Area, listInformacionCurriculum[i].Descripcion,
                listInformacionCurriculum[i].Principal, listInformacionCurriculum[i].Fecha_Inicio, listInformacionCurriculum[i].Fecha_Fin, listInformacionCurriculum[i].Id_Carrera,
                    listInformacionCurriculum[i].Contacto};
                    string[] ParametrosOut = { "P_BANDERA" };
                    cmd = exeProc.GenerarOracleCommand("INS_BTU_CURRICULUM_INFO", ref Verificador, ref dr, Parametros, Valores, ParametrosOut);
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
        public static void EliminarInformacionCurriculum(Btu_Curriculum_Informacion objInformacionCurriculum, ref string Verificador)
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { "p_tipo", "p_id_curriculum" };
                object[] Valores = { objInformacionCurriculum.Tipo, objInformacionCurriculum.Id_Curriculum };
                string[] ParametrosOut = { "P_BANDERA" };
                cmd = exeProc.GenerarOracleCommand("DEL_BTU_CURRICULUM_INFORMACION", ref Verificador, ref dr, Parametros, Valores, ParametrosOut);
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
        public static void EditarInformacionCandidatoBD(Btu_Curriculum objDatosCv, ref string Verificador)
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = {"p_matricula", "p_paterno", "p_materno","p_nombre", "p_domicilio", "p_municipio", "p_estado","p_nacimiento", "p_telefono", 
                    "p_celular", "p_correo", "p_objetivo", "p_interes","p_tipo",  "p_usuario", "p_genero","p_ruta_foto", "p_codigo_pos", "p_colonia"};
                object[] Valores = { objDatosCv.Matricula, objDatosCv.Paterno, objDatosCv.Materno,objDatosCv.Nombre, objDatosCv.Domicilio, objDatosCv.Municipio, objDatosCv.Estado,
                    objDatosCv.Fecha_Nacimiento, objDatosCv.Telefono, objDatosCv.Celular, objDatosCv.Correo, objDatosCv.Objetivo, objDatosCv.Intereses, objDatosCv.Tipo, objDatosCv.Usuario_Modificacion, 
                    objDatosCv.Genero, objDatosCv.Ruta_Foto, objDatosCv.Codigo_Postal, objDatosCv.Colonia};
                string[] ParametrosOut = { "p_id", "P_BANDERA" };
                cmd = exeProc.GenerarOracleCommand("UPD_BTU_CURRICULUM", ref Verificador, ref dr, Parametros, Valores, ParametrosOut);
                objDatosCv.Id = Convert.ToString(cmd.Parameters["p_id"].Value);
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
        public static void EditarDatosEmpresa(Btu_Empresa objEmpresa, ref string Verificador)
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = {"P_ID","P_RAZON_SOCIAL", "P_NOMBRE_COMERCIAL", "P_ACTIVIDAD", "P_CODIGO_POSTAL", "P_ESTADO",
                        "P_CIUDAD", "P_COLONIA", "P_DOMICILIO", "P_RFC", "P_CONTACTO", "P_CONTACTO_CARGO", "P_TELEFONO", "P_CELULAR",
                        "P_EMAIL", "P_MEDIO_CONTACTO", "P_CONTRASENIA" ,"P_LOGOTIPO", "P_TIPO_PERSONA" };
                object[] Valores = {objEmpresa.Id_Empresa, objEmpresa.Razon_Social, objEmpresa.Nombre_Comercial, objEmpresa.Actividad, objEmpresa.Codigo_Postal, objEmpresa.Estado,
                objEmpresa.Ciudad, objEmpresa.Colonia, objEmpresa.Domicilio,objEmpresa.Rfc, objEmpresa.Contacto, objEmpresa.Contacto_Cargo, objEmpresa.Telefono, objEmpresa.Celular,
                objEmpresa.Email, objEmpresa.Medio_Contacto, objEmpresa.Contrasena, objEmpresa.Ruta_Foto, objEmpresa.Tipo_Persona};
                string[] ParametrosOut = { "P_BANDERA" };
                cmd = exeProc.GenerarOracleCommand("UPD_DATOS_EMPRESA", ref Verificador, ref dr, Parametros, Valores, ParametrosOut);
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
        public static void GuardarVacante(Btu_Vacante objVacante, ref string Verificador)
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { "p_nombre", "p_total", "p_edad_minima", "p_edad_maxima", "p_estado_civil", "p_grado", "p_experiencia",
                    "p_actividades", "p_conocimientos", "p_salario", "p_frecuencia_salario",  "p_prestasiones", "p_ubicacion", "p_licencia",
                    "p_vigencia_inicio", "p_vigencia_fin", "p_tipo", "p_direccion_entrevista", "p_telefono", "p_correo", "p_comentarios",
                    "p_responsable_entrevista", "p_especificaciones_entrevista", "p_id_empresa", "p_rfc", "p_idioma", "p_radicar", "p_viajar", "p_flayer", "p_genero", "p_jornada"};
                object[] Valores = { objVacante.Nombre, objVacante.Total, objVacante.Edad_Minima, objVacante.Edad_Maxima, objVacante.Estado_Civil, objVacante.Grado, objVacante.Experiencia,
                objVacante.Actividades , objVacante.Conocimientos, objVacante.Salario, objVacante.Frecuencia_Salario ,objVacante.Prestaciones, objVacante.Ubicacion, objVacante.Licencia, objVacante.Vigencia_Inicio,
                objVacante.Vigencia_Fin, objVacante.Tipo, objVacante.Direccion_Entrevista, objVacante.Telefono, objVacante.Correo, objVacante.Comentarios, objVacante.Responsable_Entrevista, 
                objVacante.Especificaciones_Entrevista, objVacante.Id_Empresa, objVacante.Rfc, objVacante.Idioma, objVacante.Radicar, objVacante.Viajar, objVacante.Flayer_Empresa, objVacante.Genero, 
                objVacante.Jornada_Laboral};
                string[] ParametrosOut = { "P_BANDERA" };
                cmd = exeProc.GenerarOracleCommand("INS_BTU_VACANTE", ref Verificador, ref dr, Parametros, Valores, ParametrosOut);
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
        public static void EditarVacante(Btu_Vacante objVacante, ref string Verificador)
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { "p_id_vacante", "p_nombre", "p_total", "p_edad_minima", "p_edad_maxima", "p_estado_civil", "p_grado", "p_experiencia",
                    "p_actividades", "p_conocimientos", "p_salario", "p_frecuencia_salario",  "p_prestasiones", "p_ubicacion", "p_licencia",
                    "p_vigencia_inicio", "p_vigencia_fin", "p_tipo", "p_direccion_entrevista", "p_telefono", "p_correo", "p_comentarios",
                    "p_responsable_entrevista", "p_especificaciones_entrevista", "p_idioma", "p_radicar", "p_viajar", "p_flayer", "p_genero","p_jornada"};
                object[] Valores = {objVacante.Id, objVacante.Nombre, objVacante.Total, objVacante.Edad_Minima, objVacante.Edad_Maxima, objVacante.Estado_Civil, objVacante.Grado, objVacante.Experiencia,
                objVacante.Actividades , objVacante.Conocimientos, objVacante.Salario, objVacante.Frecuencia_Salario ,objVacante.Prestaciones, objVacante.Ubicacion, objVacante.Licencia,
                objVacante.Vigencia_Inicio, objVacante.Vigencia_Fin, objVacante.Tipo, objVacante.Direccion_Entrevista, objVacante.Telefono, objVacante.Correo, objVacante.Comentarios, 
                objVacante.Responsable_Entrevista, objVacante.Especificaciones_Entrevista,objVacante.Idioma, objVacante.Radicar, objVacante.Viajar, objVacante.Flayer_Empresa, objVacante.Genero, 
                objVacante.Jornada_Laboral
                };
                string[] ParametrosOut = { "P_BANDERA" };
                cmd = exeProc.GenerarOracleCommand("UPD_BTU_VACANTE", ref Verificador, ref dr, Parametros, Valores, ParametrosOut);
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
        public static void EliminarVacante(Btu_Vacante objVacante, ref string Verificador)
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { "P_ID" };
                object[] Valores = { objVacante.Id };
                string[] ParametrosOut = { "P_BANDERA" };
                cmd = exeProc.GenerarOracleCommand("DEL_BTU_VACANTE", ref Verificador, ref dr, Parametros, Valores, ParametrosOut);
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