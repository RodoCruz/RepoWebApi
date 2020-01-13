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
    public class ListaVisitasController : ApiController
    {
        [HttpGet]
        public IEnumerable<ListaVisitasCLS> Listado()
        {
            using (VisitasDataContext bd = new VisitasDataContext())
            {
                IEnumerable<ListaVisitasCLS> lista = (from visitante in bd.Visitante
                                                      join empleado in bd.Empleado
                                                      on visitante.idEmpleado equals empleado.idEmpleado
                                                      join gafete in bd.Gafete
                                                      on visitante.idGafete equals gafete.idGafete
                                                      join departamento in bd.Departamento
                                                      on empleado.idDepartamento equals departamento.idDepartamento
                                                      where visitante.SalidaVis != null
                                                      select new ListaVisitasCLS
                                                      {
                                                          nombreVisCLS = visitante.nombreVis,
                                                          aPaternoVisCLS = visitante.aPaternoVis,
                                                          aMaternoVisCLS = visitante.aMaternoVis,
                                                          EntradaVisCLS = (DateTime)visitante.EntradaVis,
                                                          SalidaVisCLS = (DateTime)visitante.SalidaVis,
                                                          nombreDepCLS = departamento.nombreDep,
                                                          nombreEmpCLS = empleado.nombreEmp,
                                                          aPaternoEmpCLS = empleado.aPaternoEmp,
                                                          nombreGafCLS = gafete.nombreGaf
                                                      }).ToList();
                return lista;
            }
        }
    }
}
