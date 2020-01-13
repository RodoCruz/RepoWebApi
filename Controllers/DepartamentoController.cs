using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WepApi.Models;
using System.Web.Http.Cors;

namespace WepApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DepartamentoController : ApiController
    {
        [HttpGet]
        public IEnumerable<DepartamentoCLS> ListaDepartamento()
        {
            using (VisitasDataContext bd = new VisitasDataContext())
            {
                IEnumerable<DepartamentoCLS> lista = (from departamento in bd.Departamento
                                                      select new DepartamentoCLS
                                                      {
                                                          idDepartamentoCLS = departamento.idDepartamento,
                                                          nombreDepartamentoCLS = departamento.nombreDep
                                                      }).ToList();
                return lista;
            }
        }
    }
}
