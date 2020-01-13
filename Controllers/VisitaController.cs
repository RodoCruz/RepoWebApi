using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using WepApi.Models;

namespace WepApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VisitaController : ApiController
    {
        [HttpGet]
        public IEnumerable<VisitaCLS> ListarVisitas()
        {
            using(VisitasDataContext bd = new VisitasDataContext())
            {
                IEnumerable<VisitaCLS> lista = (from visita in bd.Visitante
                                                join gafete in bd.Gafete
                                                on visita.idGafete equals gafete.idGafete
                                                join empleado in bd.Empleado
                                                on visita.idEmpleado equals empleado.idEmpleado
                                                join departamento in bd.Departamento
                                                on empleado.idDepartamento equals departamento.idDepartamento
                                                where visita.SalidaVis.Equals(null)
                                                select new VisitaCLS
                                                {
                                                    idVisitaCLS = (int)visita.idVisita,
                                                    nombreVisCLS = visita.nombreVis,
                                                    aPaternoVisCLS = visita.aPaternoVis,
                                                    aMaternoVisCLS = visita.aMaternoVis,
                                                    EntradaVisCLS = (DateTime)visita.EntradaVis,
                                                    nombreGafCLS = gafete.nombreGaf,
                                                    nombreEmpCLS = empleado.nombreEmp,
                                                    aParternoEmpCLS = empleado.aPaternoEmp,
                                                    nombreDepartamentoCLS = departamento.nombreDep
                                                }).ToList();
                return lista;
            }
        }
        [HttpPost]
        public int AgregarVisita(Visitante oVisitante)
        {
            int rpta = 0;
            try
            {
                using (VisitasDataContext bd = new VisitasDataContext())
                {
                    bd.Visitante.InsertOnSubmit(oVisitante);
                    bd.SubmitChanges();
                    rpta = 1;
                }
            }
            catch (Exception ex)
            {
                rpta = 0;
            }
            return rpta;
        }
        [HttpPut]
        public int SalidaVisita(int iidVisita, DateTime oSalidaVis)
        {
            int rpta = 0;
            try
            {
                using(VisitasDataContext bd = new VisitasDataContext())
                {
                    Visitante oVisita = bd.Visitante.Where(p => p.idVisita == iidVisita).First();
                    oVisita.SalidaVis = oSalidaVis;
                    bd.SubmitChanges();
                    rpta = 1;
                }
            }
            catch(Exception ex)
            {
                rpta = 0;
            }
            return rpta;
        }
    }
}
