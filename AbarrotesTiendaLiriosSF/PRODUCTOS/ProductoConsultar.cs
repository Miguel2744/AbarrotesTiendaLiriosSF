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


namespace AbarrotesTiendaLiriosSF.PRODUCTOS
{
    public partial class ProductoConsultar : Form
    {
        public ProductoConsultar()
        {
            InitializeComponent();
        }

        private void ProductoConsultar_Load(object sender, EventArgs e)
        {
            MySqlConnection Conexion = new MySqlConnection();
            String Cadenaconexion;
            Cadenaconexion = "server=localhost;uid=root;database=Ab_Lirios";
            Conexion.ConnectionString = Cadenaconexion;


            MySqlCommand comando = new MySqlCommand("select nom_producto from producto", Conexion);
            Conexion.Open();
            MySqlDataReader registro = comando.ExecuteReader();
            while (registro.Read())
            {
                txtBuscar.Items.Add(registro["nom_producto"].ToString());
            }
            Conexion.Close();
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
             if (txtBuscar.Text != "")
            {

                txtNombre.Text = "";
                txtMarca.Text = "";
                txtTipoP.Text = "";
                txtDescripcion.Text = "";
                txtCosto.Text = "";
                txtExistencias.Text = "";

                MySqlConnection Conexion = new MySqlConnection();
                String Cadenaconexion;
                //genero mis variables auxiliares para recibir los datos de los textbox
                String nombre = txtBuscar.Text;
                //especifico los datos sobre mi conexion y se los evnio al objeto conexion de mysql
                Cadenaconexion = "server=localhost;uid=root;database=Ab_Lirios";
                Conexion.ConnectionString = Cadenaconexion;

                //Creo un objeto comand el cual tendra el query de la instruccion de Insercion
                MySqlCommand comando1 = new MySqlCommand("select nom_producto,marca,tipoP,descripcion,costo,existencias from Producto where nom_producto='"+ txtBuscar.Text + "';");
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
                            txtNombre.Text += myreader[0];
                            txtMarca.Text += myreader[1];
                            txtTipoP.Text += myreader[2];
                            txtDescripcion.Text += myreader[3];
                            txtCosto.Text += myreader[4];
                            txtExistencias.Text += myreader[5];
                            MessageBox.Show("Aqui estan los datos del producto que buscas");
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
    }

