using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolsaTrabajoUnv2_0.Models
{
    public class MENU
    {
        public MENU()
        {
            MENUPADRE = new HashSet<MENUPADRE>();
        }
        public ICollection<MENUPADRE> MENUPADRE { get; private set; }
    }

    public class MENUPADRE
    {
        public MENUPADRE(int Id, string Nombre, string Cve, string CvePadre, int IdPadre) /*ICollection<SUBMENU> Submenu)*/
        //public MENUPADRE(int Id, string Nombre, ICollection<SUBMENU> Submenu)
        {
            this.ID = Id;
            this.NOMBRE = Nombre;
            this.CLAVE = Cve;
            this.PADRE = CvePadre;
            this.ID_PADRE = IdPadre;
            //this.SUBMENU = Submenu;
        }

        public MENUPADRE(int Id, string Nombre, string Cve, string CvePadre, int IdPadre, ICollection<SUBMENU> Submenu)
        {
            this.ID = Id;
            this.NOMBRE = Nombre;
            this.CLAVE = Cve;
            this.PADRE = CvePadre;
            this.ID_PADRE = IdPadre;
            this.SUBMENU = Submenu;
        }


        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string CLAVE { get; set; }
        public string PADRE { get; set; }
        public int ID_PADRE { get; set; }
        public string ACTION_NOMBRE { get; set; }
        public string CONTROL_NOMBRE { get; set; }
        public ICollection<SUBMENU> SUBMENU { get; private set; }
    }

    public class SUBMENU
    {
        public SUBMENU(int IdSubmenu, string Nombre, string ControlNombre)
        {
            this.ID_SUBMENU = IdSubmenu;
            this.NOMBRE = Nombre;
            this.CONTROL_NOMBRE = ControlNombre;
        }
        public int ID_PADRE { get; set; }
        public int ID_SUBMENU { get; set; }
        public string NOMBRE { get; set; }
        public string CONTROL_NOMBRE { get; set; }
        //public MENU PARENTMENU { get; set; }
    }
}