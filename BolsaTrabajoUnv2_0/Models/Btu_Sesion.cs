using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolsaTrabajoUnv2_0.Models
{
    public class Btu_Sesion
    {
        public string Tipo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Existe { get; set; }
        public string Matricula { get; set; }
        public string Nombre { get; set; }
        public string Registrado { get; set; }
        public string Id { get; set; }
        public string Email2 { get; set; }        
    }

    public class ResultadoSesion
    {
        public bool Error { get; set; }
        public string MensajeError { get; set; }
        public List<Btu_Sesion> Resultado { get; set; }

        public Btu_Sesion resultado { get; set; }

    }
}