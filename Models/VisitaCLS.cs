using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WepApi.Models
{
    public class VisitaCLS
    {
        public int idVisitaCLS { get; set; }
        public string nombreVisCLS { get; set; }
        public string aPaternoVisCLS { get; set; }
        public string aMaternoVisCLS { get; set; }
        public DateTime EntradaVisCLS { get; set; }
        public string nombreGafCLS { get; set; }
        public string nombreEmpCLS { get; set; }
        public string aParternoEmpCLS { get; set; }
        public string nombreDepartamentoCLS { get; set; }
    }
}