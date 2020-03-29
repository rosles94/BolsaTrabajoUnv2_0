using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolsaTrabajoUnv2_0.Models
{
    public class Btu_Bitacora_Candidatos
    {
        public string Status { get; set; }
        public string Fecha_Captura { get; set; }
        public string Observaciones { get; set; }
        public string Id_Candidato { get; set; }
        public string Id { get; set; }

    }

    public class ResultadoBtuBitacoraCandidatos
    {
        public bool Error { get; set; }
        public string MensajeError { get; set; }
        public List<Btu_Bitacora_Candidatos> Resultado { get; set; }
    }
}