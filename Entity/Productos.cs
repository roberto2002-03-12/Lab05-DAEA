using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Productos
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public double PrecioUnidad { get; set; }
        public int Suspendido { get; set; }
        //solo pongo esto para poder subirlo
    }
}
