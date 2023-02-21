using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolsaTrabajoUnv2_0.Models
{
    public class Btu_CandidatoExterno
    {
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Colonia { get; set; }
        public string Domicilio { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public string Curp { get; set; }
        public string Fecha_Nacimiento { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string Escuela { get; set; }
        public string Contrasenia_encriptada { get; set; }
    }

    public class ResultadoCandidatoExterno
    {
        public bool Error { get; set; }
        public string MensajeError { get; set; }
        public List<Btu_CandidatoExterno> Resultado { get; set; }

    }
}