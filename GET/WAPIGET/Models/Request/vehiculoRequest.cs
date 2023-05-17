using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAPIGET.Models.Request
{
    public class vehiculoRequest
    {
        public string MARCA { get; set; }
        public string MODELO { get; set; }
        public int NYEAR { get; set; }
        public string CONDICION { get; set; }
        public int ESTATUS { get; set; }
        public double PRECIO { get; set; }
        public string FOTO { get; set; }
    }
}