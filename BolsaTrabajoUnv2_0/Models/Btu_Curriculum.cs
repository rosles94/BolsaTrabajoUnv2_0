using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolsaTrabajoUnv2_0.Models
{
    public class Btu_Curriculum
    {
        public string Id { get; set; }
        public string Matricula { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string Fecha_Nacimiento { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public string Objetivo { get; set; }
        public string Intereses { get; set; }
        public string Contrasena { get; set; }
        public string Status { get; set; }
        public string Tipo { get; set; }
        public string Fecha_Creacion { get; set; }
        public string Fecha_Activacion { get; set; }
        public string Usuario_Creacion { get; set; }
        public string Usuario_Modificacion { get; set; }
        public string Genero { get; set; }
        public string Codigo_Postal { get; set; }
        public string Colonia { get; set; }
        public string Ruta_Foto { get; set; }
        public bool Edita { get; set; }
        public string Dependencia { get; set; }
    }


    public class ResultadoBtuCurriculum
    {
        public bool Error { get; set; }
        public string MensajeError { get; set; }
        public List<Btu_Curriculum> Resultado { get; set; }

    }
}