using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolsaTrabajoUnv2_0.Models
{
    public class Btu_Vacante
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Total { get; set; }
        public string Edad_Minima { get; set; }
        public string Edad_Maxima { get; set; }
        public string Estado_Civil { get; set; }
        public string Grado { get; set; }
        public string Experiencia { get; set; }
        public string Actividades { get; set; }
        public string Conocimientos { get; set; }
        public string Salario { get; set; }
        public string Frecuencia_Salario { get; set; }
        public string Prestaciones { get; set; }
        public string Ubicacion { get; set; }
        public string Licencia { get; set; }
        public string Vigencia_Inicio { get; set; }
        public string Vigencia_Fin { get; set; }
        public string Tipo { get; set; }
        public string Direccion_Entrevista { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Comentarios { get; set; }
        public string Responsable_Entrevista { get; set; }
        public string Especificaciones_Entrevista { get; set; }
        public string Id_Empresa { get; set; }
        public string Area_Conocimientos { get; set; }
        public string Rfc { get; set; }
        public string Logotipo { get; set; }
        public string Razon_social { get; set; }
        public string Tipo_salario { get; set; }
        public string Viajar { get; set; }
        public string Radicar { get; set; }
        public string Idioma { get; set; }
        public string Fecha_Inicio_Labores { get; set; }
        public string Genero { get; set; }
        public string Jornada_Laboral { get; set; }
        public string Flayer_Empresa { get; set; }
        public string Todas_Vacantes { get; set; }
        public string Total_Interesados { get; set; }
        public string Empresa_Vigente { get; set; }
        public string Id_Candidato { get; set; }
        public string Empresa { get; set; }

        public Btu_Vacantes_Candidatos objVacCand = new Btu_Vacantes_Candidatos();
    }

    public class ResultadoVacante
    {
        public bool Error { get; set; }
        public string MensajeError { get; set; }
        public List<Btu_Vacante> Resultado { get; set; }
    }
}