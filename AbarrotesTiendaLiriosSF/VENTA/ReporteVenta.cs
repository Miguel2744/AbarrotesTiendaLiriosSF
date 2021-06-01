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
        MySqlConnection Conexion = new MySqlConnection();
        String Cadenaconexion;

        public ReporteVenta()
        {
            InitializeComponent();
            Cadenaconexion = "server=localhost;uid=root;pwd=root;database=Ab_Lirios";
            Conexion.ConnectionString = Cadenaconexion;

            MySqlCommand commandobus = new MySqlCommand("select idRVenta,fecha,hora,articulos,monto_Venta,idVenta from rep_venta ;");
            commandobus.Connection = Conexion;
            Conexion.Open();
            MySqlDataReader myreader = commandobus.ExecuteReader();
            

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
            commandobus = null;
            myreader = null;
            //------------------------------------------------
           /* Cadenaconexion = "server=localhost;uid=root;password=root;database=Ab_Lirios";
            Conexion.ConnectionString = Cadenaconexion;

             commandobus = new MySqlCommand("select SUM(monto_Venta) from rep_venta;");
            commandobus.Connection = Conexion;
            Conexion.Open();
             myreader = commandobus.ExecuteReader();*/
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

        private void label4_Click(object sender, EventArgs e)
        {
          /*  Sqlcommand comando = new Sqlcommand("select SUM(monto_Venta) from rep_venta;", conexion);
            conexion.Open();
            SqlDataReader valor = comando.ExecuteReader();*/
            Cadenaconexion = "server=localhost;uid=root;pwd=root;database=Ab_Lirios";
            Conexion.ConnectionString = Cadenaconexion;

            MySqlCommand commandobus = new MySqlCommand("select SUM(monto_Venta) from rep_venta;");
            commandobus.Connection = Conexion;
            Conexion.Open();
            MySqlDataReader myreader = commandobus.ExecuteReader();


            try
            {
                if (myreader.HasRows)
                {
                    while (myreader.Read())
                    {
                    txt_Total.Text = myreader["SUM(monto_Venta)"].ToString();
                        //tb_RepVenta.Rows.Add(myreader[0], myreader[1], myreader[2], myreader[3], myreader[4], myreader[5]);
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
    }
}
