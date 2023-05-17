using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WAPIGET.Controllers
{
    public class VehiculoController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<ViewModels.Vehiculo> list = new List<ViewModels.Vehiculo>();

            using (Models.DBVEHICULOSEntities1 dbase = new Models.DBVEHICULOSEntities1())
            {
                list = (from v in dbase.VEHICULOS
                       select new ViewModels.Vehiculo
                       {
                           ID = v.ID,
                           CONDICION = v.CONDICION,
                           ESTATUS = v.ESTATUS,
                           FOTO = v.FOTO,
                           MARCA = v.MARCA,
                           MODELO = v.MODELO,
                           NYEAR = v.NYEAR,
                           PRECIO = v.PRECIO
                       }).ToList();
            }

            return Ok(list);
        }

        [HttpPost]
        public IHttpActionResult Add(Models.Request.vehiculoRequest model)
        {
            using (Models.DBVEHICULOSEntities1 dbase = new Models.DBVEHICULOSEntities1())
            {
                var oVehiculo = new Models.VEHICULO();
                var oEstatus = new Models.vhESTATU();
                var dataList = dbase.vhESTATUS.ToList();
                if(dataList.Count() == 0)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                    {
                        Content = new StringContent("No existen Estatus, Crea uno primero"),
                        ReasonPhrase = "Error"
                    };
                    throw new HttpResponseException(response);
                }

                oVehiculo.PRECIO = model.PRECIO;
                oVehiculo.MODELO = model.MODELO;
                oVehiculo.NYEAR = model.NYEAR;
                oVehiculo.MARCA = model.MARCA;
                oVehiculo.CONDICION = model.CONDICION;
                oVehiculo.ESTATUS = model.ESTATUS;
                oVehiculo.FOTO = model.FOTO;
                dbase.VEHICULOS.Add(oVehiculo);
                dbase.SaveChanges();
            }

            return Ok("Registro agregado con un modelo");
        }

        [HttpPut]
        public IHttpActionResult Put(ViewModels.Vehiculo model)
        {
            using (var dbase = new Models.DBVEHICULOSEntities1())
            {
                var oVehiculo = dbase.VEHICULOS.Find(model.ID); // select * from invconteo where id = 1
                oVehiculo.MARCA = model.MARCA;
                oVehiculo.MODELO = model.MODELO;
                oVehiculo.NYEAR = model.NYEAR;
                oVehiculo.PRECIO = model.PRECIO;
                oVehiculo.FOTO = model.FOTO;
                oVehiculo.ESTATUS = model.ESTATUS;
                oVehiculo.CONDICION = model.CONDICION;
                dbase.Entry(oVehiculo).State = System.Data.Entity.EntityState.Modified;
                dbase.SaveChanges();
            }

            return Ok("Registro actualizado :");
        }

        [HttpDelete]
        public IHttpActionResult Del(int Id)
        {
            using (var dbase = new Models.DBVEHICULOSEntities1())
            {
                var oVehiculo = dbase.VEHICULOS.Find(Id);
                dbase.VEHICULOS.Remove(oVehiculo);
                dbase.SaveChanges();
            }

            return Ok("Registro borrado");
        }
    }
}