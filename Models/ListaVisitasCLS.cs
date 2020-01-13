using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WepApi.Models
{
    public class ListaVisitasCLS
    {
        public string nombreVisCLS { get; set; }
        public string aPaternoVisCLS { get; set; }
        public string aMaternoVisCLS { get; set; }
        public DateTime EntradaVisCLS { get; set; }
        public DateTime SalidaVisCLS { get; set; }
        public string nombreDepCLS { get; set; }
        public string nombreEmpCLS { get; set; }
        public string aPaternoEmpCLS { get; set; }
        public string nombreGafCLS { get; set; }
    }
}