using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbarrotesTiendaLiriosSF.CLIENTES
{
    class Cliente
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public double saldo { get; set; }

        public Cliente(int id, String nombre, double saldo)
        {
            this.id = id;
            this.nombre = nombre;
            this.saldo = saldo;
        }

        public override String ToString()
        {

            return nombre;
        }
    }
}
