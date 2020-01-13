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
    public class EmpleadoController : ApiController
    {
        [HttpGet]
        public IEnumerable<EmpleadoCLS> ListaEmpleados()
        {
            using (VisitasDataContext bd = new VisitasDataContext())
            {
                IEnumerable<EmpleadoCLS> lista = (from empleado in bd.Empleado
                                                      select new EmpleadoCLS
                                                      {
                                                          idEmpleadoCLS = empleado.idEmpleado,
                                                          nombreEmpCLS = empleado.nombreEmp,
                                                          aParternoEmpCLS = empleado.aPaternoEmp,
                                                          idDepartamento = (int)empleado.idDepartamento
                                                      }).ToList();
                return lista;
            }
        }

        [HttpGet]
        public IEnumerable<EmpleadoCLS> RecuperaEmpleados(int iidDepartamento)
        {
            using (VisitasDataContext bd = new VisitasDataContext())
            {
                IEnumerable<EmpleadoCLS> lista = (from empleado in bd.Empleado
                                                  where empleado.idDepartamento == iidDepartamento
                                                  select new EmpleadoCLS
                                                  {
                                                      idEmpleadoCLS = empleado.idEmpleado,
                                                      nombreEmpCLS = empleado.nombreEmp,
                                                      aParternoEmpCLS = empleado.aPaternoEmp,
                                                      idDepartamento = (int)empleado.idDepartamento
                                                  }).ToList();
                return lista;
            }
        }
    }
}
