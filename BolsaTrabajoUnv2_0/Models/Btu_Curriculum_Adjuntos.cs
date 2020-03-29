using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolsaTrabajoUnv2_0.Models
{
    public class Btu_Curriculum_Adjuntos
    {
        public string Id { get; set; }
        public string Id_Curriculum { get; set; }
        public string Tipo { get; set; }
        public string Ruta { get; set; }
    }

    
    public class ResultadoCurriculumAdjuntos
    {
        public bool Error { get; set; }
        public string MensajeError { get; set; }
        public List<Btu_Curriculum_Adjuntos> Resultado { get; set; }

    }
}