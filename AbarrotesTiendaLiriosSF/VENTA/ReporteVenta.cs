using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AbarrotesTiendaLiriosSF.VENTA
{
    public partial class ReporteVenta : Form
    {
        public ReporteVenta()
        {
            InitializeComponent();

            //Iniciar conexion
            MySqlConnection Conexion = new MySqlConnection();
            //Variable de cadena de conexion
            String Cadenaconexion;
            //especifico los datos sobre mi conexion y se los evnio al objeto conexion de mysql
            Cadenaconexion = "server=localhost;uid=root;password=root;database=Ab_Lirios";
            Conexion.ConnectionString = Cadenaconexion;

            //Creo un objeto comand el cual tendra el query de la instruccion de Insercion
            MySqlCommand comando1 = new MySqlCommand("select idRVenta,fecha,hora,articulos,monto_Venta,idVenta from rep_venta ;");
            comando1.Connection = Conexion;
            Conexion.Open();

            MySqlDataReader myreader = comando1.ExecuteReader();
            System.Text.Encoding decrio = System.Text.Encoding.ASCII;


        /*    MySqlCommand comando2 = new MySqlCommand("select SUM(monto_Venta) from rep_venta;");
            comando2.Connection = Conexion;
            Conexion.Open();

            MySqlDataReader myreader2 = comando2.ExecuteReader();
            System.Text.Encoding decrio2 = System.Text.Encoding.ASCII;*/

            //uso un try para abrir la conexion y ejecutar el query y el catch para cerrar la conexion

            try
            {
                if (myreader.HasRows)
                {
                    while (myreader.Read())
                    {
                        tb_RepVenta.Rows.Add(myreader[0], myreader[1], myreader[2], myreader[3], myreader[4], myreader[5]);
                       // int var = Convert.ToInt32(comando2.ExecuteScalar);
                    }
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Se ha producido un error" + err + "");
            }
            Conexion.Close();


        }

        private void ReporteVenta_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void VTotal_Click(object sender, EventArgs e)
        {

        }
    }
}
