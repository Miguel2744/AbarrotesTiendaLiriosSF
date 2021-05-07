using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AbarrotesTiendaLiriosSF.CONEXION
{
    class CONEXION
    {

        public static MySqlConnection ObtenerConexion()
        {

            MySqlConnection conectar = new MySqlConnection("Server=127.0.0.1; uid=root; pwd=root; Database=Ab_Lirios;");

            conectar.Open();

            return conectar;
        }
    }
}
