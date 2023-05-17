using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class Vehiculo
    {
        public int ID { get; set; }
        public string MARCA { get; set; }
        public string MODELO { get; set; }
        public int? NYEAR { get; set; }
        public string CONDICION { get; set; }
        public int? ESTATUS { get; set; }
        public double? PRECIO { get; set; }
        public string FOTO { get; set; }
    }
}
