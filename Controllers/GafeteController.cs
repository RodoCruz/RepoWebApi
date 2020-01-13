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
    public class GafeteController : ApiController
    {
        [HttpGet]
        public IEnumerable<GafeteCLS> ListaGafete()
        {
            using (VisitasDataContext bd = new VisitasDataContext())
            {
                IEnumerable<GafeteCLS> lista = (from gafete in bd.Gafete
                                                select new GafeteCLS
                                                  {
                                                    idGafeteCLS = gafete.idGafete,
                                                    nombreGafCLS = gafete.nombreGaf,
                                                    libreCLS = (bool)gafete.libre
                                                }).ToList();
                return lista;
            }
        }

        [HttpGet]
        public IEnumerable<GafeteCLS> BuscarGafete(string letra)
        {
            using (VisitasDataContext bd = new VisitasDataContext())
            {
                IEnumerable<GafeteCLS> lista = (from gafete in bd.Gafete
                                                where gafete.nombreGaf.Substring(0, 1) == letra
                                                select new GafeteCLS
                                                {
                                                    idGafeteCLS = gafete.idGafete,
                                                    nombreGafCLS = gafete.nombreGaf,
                                                    libreCLS = (bool)gafete.libre
                                                }).ToList();
                return lista;
            }
        }
    }
}
