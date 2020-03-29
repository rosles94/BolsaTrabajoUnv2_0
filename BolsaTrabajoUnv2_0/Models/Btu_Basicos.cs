using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolsaTrabajoUnv2_0.Models
{
    public class Btu_Basicos
    {
        public string Tipo { get; set; }
        public string SubTipo { get; set; }
        public string Descripcion { get; set; }

    }

    public class ResultadoBtuBasicos
    {
        public bool Error { get; set; }
        public string MensajeError { get; set; }
        public List<Btu_Basicos> Resultado { get; set; }

    }
}