using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbarrotesTiendaLiriosSF.PRODUCTOS
{
    public partial class PtoductosDisponibles : Form
    {
        public PtoductosDisponibles()
        {
            InitializeComponent();
       
            //Iniciar conexion
            MySqlConnection Conexion = new MySqlConnection();
            //Variable de cadena de conexion
            String Cadenaconexion;
            //especifico los datos sobre mi conexion y se los evnio al objeto conexion de mysql
            Cadenaconexion = "server=localhost;uid=root;database=Ab_Lirios";
            Conexion.ConnectionString = Cadenaconexion;

            //Creo un objeto comand el cual tendra el query de la instruccion de Insercion
            MySqlCommand comando1 = new MySqlCommand("select nom_producto,marca,tipoP,costo,existencias from Producto where existencias>0;");
            comando1.Connection = Conexion;
            Conexion.Open();

            MySqlDataReader myreader = comando1.ExecuteReader();
            System.Text.Encoding decrio = System.Text.Encoding.ASCII;

            //uso un try para abrir la conexion y ejecutar el query y el catch para cerrar la conexion

            try
            {
                if (myreader.HasRows)
                {
                    while (myreader.Read())
                    {
                        dgvProdDisp.Rows.Add(myreader[0],myreader[1],myreader[2],myreader[3],myreader[4]);
                    }
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Se ha producido un error" + err + "");
            }
            Conexion.Close();




            


        }

        private void PtoductosDisponibles_Load(object sender, EventArgs e)
        {
        
        }
    }
}
