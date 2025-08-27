using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appWeb._3.Dominio.Entidad
{
    public class Herramienta
    {
        public string idHer { get; set; }
        public string desHer { get; set; }
        public string medHer { get; set; }
        public int idcategoria { get; set; }
        public string Nombrecategoria { get; set; }
        public decimal preUni { get; set; }
        public int stock { get; set; }
    }
}