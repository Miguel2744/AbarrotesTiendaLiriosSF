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


namespace AbarrotesTiendaLiriosSF.USUARIOS
{
    public partial class UsuariosModificar : Form
    {
        public UsuariosModificar()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "")
            {

                txtNombre.Text = "";
                txtPass.Text = "";
                comboRol.Text = "";
               
                MySqlConnection Conexion = new MySqlConnection();
                String Cadenaconexion;
                //genero mis variables auxiliares para recibir los datos de los textbox
                String nombre = txtBuscar.Text;
                //especifico los datos sobre mi conexion y se los evnio al objeto conexion de mysql
                Cadenaconexion = "server=localhost;uid=root;pwd=root;database=Ab_Lirios";
                Conexion.ConnectionString = Cadenaconexion;

                //Creo un objeto comand el cual tendra el query de la instruccion de Insercion
                MySqlCommand comando1 = new MySqlCommand("select nom_User,Pass,tipo from usuarios where nom_User='" + txtBuscar.Text + "';");
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
                            txtPass.Text += myreader[1];
                            comboRol.Text += myreader[2];
                            MessageBox.Show("Aqui estan los datos del Usuario que buscas");
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

        private void UsuariosModificar_Load(object sender, EventArgs e)
        {
            MySqlConnection Conexion = new MySqlConnection();
            String Cadenaconexion;
            Cadenaconexion = "server=localhost;uid=root;pwd=root;database=Ab_Lirios";
            Conexion.ConnectionString = Cadenaconexion;


            MySqlCommand comando = new MySqlCommand("select nom_User from usuarios", Conexion);
            Conexion.Open();
            MySqlDataReader registro = comando.ExecuteReader();
            while (registro.Read())
            {
                txtBuscar.Items.Add(registro["nom_User"].ToString());
            }
            Conexion.Close();
        }
    }
}
