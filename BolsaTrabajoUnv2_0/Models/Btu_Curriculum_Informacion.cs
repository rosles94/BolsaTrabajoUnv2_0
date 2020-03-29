using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolsaTrabajoUnv2_0.Models
{
    public class Btu_Curriculum_Informacion
    {
        public string Id { get; set; }
        public string Id_Curriculum { get; set; }
        public string Tipo { get; set; }
        public string Subtipo { get; set; }
        public string Institucion { get; set; }
        public string Carrera { get; set; }
        public string Area { get; set; }
        public string Descripcion { get; set; }
        public string Principal { get; set; }
        public string Fecha_Inicio { get; set; }
        public string Fecha_Fi { get; set; }
        public string Contacto { get; set; }
        public string Tiempo_Laborado { get; set; }
        public string Id_Local { get; set; }
        public string Id_Carrera { get; set; }
    }


    public class ResultadoCurriculmInformacion
    {
        public bool Error { get; set; }
        public string MensajeError { get; set; }
        public List<Btu_Curriculum_Informacion> Resultado { get; set; }

    }
}