using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WAPIGET.Controllers
{
    public class conteoController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<ViewModel.conteoViewModel> lst = new List<ViewModel.conteoViewModel>();

            using (Models.DBAPIEntities dbase = new Models.DBAPIEntities())
            {
                lst = (from d in dbase.INVCONTEO
                       select new ViewModel.conteoViewModel
                       {
                           Id = d.IDINV,
                           Descripcion = d.DESCRIPCION,
                           Cantidad = d.CANTIDAD
                       }).ToList();
            }

            return Ok(lst);
        }
    }
}
