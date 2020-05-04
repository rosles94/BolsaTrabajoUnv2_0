using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace BolsaTrabajoUnv2_0.Models
{
    public class Btu_Vacantes_Candidatos
    {
        public string Id { get; set; }
        public string Id_Vacante { get; set; }
        public string Id_Interesado { get; set; }
        public string Status { get; set; }
        public string Observaciones { get; set; }
        public string Fecha_Captura { get; set; }
    }

    public class ResultadoVacantesCandidatos
    {
        public bool Error { get; set; }
        public string Mensaje_Error { get; set; }
        public List<Btu_Vacantes_Candidatos> Resultado { get; set; }
    }
}