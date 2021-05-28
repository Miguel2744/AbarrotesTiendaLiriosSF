using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbarrotesTiendaLiriosSF.VENTA
{
    class producto
    {
        public int id { get; set; }
            public int existencias { get; set; }
        public String nombre { get; set; }
        public double precio { get; set; }

        public producto(int id, String nombre, int existencias, double precio)
        {
            this.id = id;
            this.nombre = nombre;
            this.existencias = existencias;
            this.precio = precio;
        }

        public override String ToString()
        {

            return nombre;
        }
    }
}
