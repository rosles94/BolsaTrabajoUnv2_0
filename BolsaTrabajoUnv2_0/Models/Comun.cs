using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolsaTrabajoUnv2_0.Models
{
    public class Comun
    {
        public string Id { get; set; }
        public string Descripcion { get; set; }
        public string EtiquetaDos { get; set; }
        public string EtiquetaTres { get; set; }
        public string EtiquetaCuatro { get; set; }
        public string EtiquetaCinco { get; set; }

        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string Ejercicio { get; set; }
        public string Correo { get; set; }
    }

    public class ResultadoComun
    {
        public bool Error { get; set; }
        public string MensajeError { get; set; }
        public List<Comun> Resultado { get; set; }

    }
}