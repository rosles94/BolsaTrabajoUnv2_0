using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolsaTrabajoUnv2_0.Models
{
    public class Btu_Empresa
    {
        public string Actividad { get; set; }
        public string Giro { get; set; }
        public string Status { get; set; }
        public string Validado { get; set; }
        public string Contrasena { get; set; }
        public string Medio_Contacto { get; set; }
        public string Celular { get; set; }
        public string Contacto_Cargo { get; set; }
        public string Email { get; set; }
        public string Contacto { get; set; }
        public string Telefono { get; set; }
        public string Estado { get; set; }
        public string Ciudad { get; set; }
        public string Codigo_Postal { get; set; }
        public string Colonia { get; set; }
        public string Domicilio { get; set; }
        public string Nombre_Comercial { get; set; }
        public string Razon_Social { get; set; }
        public string Rfc { get; set; }
        public string Registrado { get; set; }
        public string Curp { get; set; }
        public string Tipo { get; set; }
        public string Id { get; set; }
        public string Ruta_Foto { get; set; }
        public string Existe { get; set; }
        public string Total { get; set; }
        public string Ruta_Documento { get; set; }
        public string Ruta_Img_Flayer { get; set; }
        public string Tipo_Persona { get; set; }
        public string Id_Empresa { get; set; }
        public string Motivo { get; set; }
        public string Vigente { get; set; }
        public string Total_Empresas { get; set; }
        public bool Administrador { get; set; }
    }

    public class ResultadoEmpresa
    {
        public bool Error { get; set; }
        public string MensajeError { get; set; }
        public List<Btu_Empresa> Resultado { get; set; }
    }
}