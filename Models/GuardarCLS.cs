using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WepApi.Models
{
    public class GuardarCLS
    {
        public string nombreVis { get; set; }
        public string aPaternoVis { get; set; }
        public string aMaternoVis { get; set; }
        public int idEmpleado { get; set; }
        public int idGafete { get; set; }
        public DateTime EntradaVis { get; set; }
    }
}