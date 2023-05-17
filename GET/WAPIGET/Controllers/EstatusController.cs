using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WAPIGET.Controllers
{
    public class EstatusController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<ViewModels.mESTATUS> list = new List<ViewModels.mESTATUS>();

            using (Models.DBVEHICULOSEntities1 dbase = new Models.DBVEHICULOSEntities1())
            {
                list = (from v in dbase.vhESTATUS
                       select new ViewModels.mESTATUS
                       {
                           DESCRIPCION= v.DESCRIPCION,
                           ESTATUS = v.ESTATUS,
                       }).ToList();
            }

            return Ok(list);
        }

        [HttpPost]
        public IHttpActionResult Add(Models.Request.estatusRequest model)
        {
            using (Models.DBVEHICULOSEntities1 dbase = new Models.DBVEHICULOSEntities1())
            {
                var oEstatus = new Models.vhESTATU();
                oEstatus.DESCRIPCION = model.DESCRIPCION;
                dbase.vhESTATUS.Add(oEstatus);
                dbase.SaveChanges();
            }

            return Ok("Registro agregado con un modelo");
        }

        [HttpPut]
        public IHttpActionResult Put(ViewModels.mESTATUS model)
        {
            using (var dbase = new Models.DBVEHICULOSEntities1())
            {
                var oEstatus = dbase.vhESTATUS.Find(model.ESTATUS); // select * from invconteo where id = 1
                oEstatus.DESCRIPCION = model.DESCRIPCION;
                dbase.Entry(oEstatus).State = System.Data.Entity.EntityState.Modified;
                dbase.SaveChanges();
            }

            return Ok("Registro actualizado :");
        }

        [HttpDelete]
        public IHttpActionResult Del(int Id)
        {
            using (var dbase = new Models.DBVEHICULOSEntities1())
            {
                var oEstatus = dbase.vhESTATUS.Find(Id);
                dbase.vhESTATUS.Remove(oEstatus);
                dbase.SaveChanges();
            }

            return Ok("Registro borrado");
        }
    }
}