using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace AbarrotesTiendaLiriosSF.USUARIOS
{
    public partial class IniciarSesion : Form
    {
        MySqlConnection Conexion = new MySqlConnection();
        String Cadenaconexion;
        internal static Boolean val;

        public IniciarSesion()
        {
            InitializeComponent();
        }

        private void IniciarSesion_Load(object sender, EventArgs e)
        {
        }
        
        private void button2_Click(object sender, EventArgs e)

        {


            String nombre = txtUsuario.Text;
            String clave = txtPass.Text;

            Cadenaconexion = "server=localhost;uid=root;pwd=root;database=Ab_Lirios";
            Conexion.ConnectionString = Cadenaconexion;
            MySqlCommand commandobus = new MySqlCommand("Select nom_User, Pass from usuarios where nom_User='" + nombre + "' and Pass='" + clave + "'");
            commandobus.Connection = Conexion;
            Conexion.Open();
            MySqlDataReader myreader = commandobus.ExecuteReader();
            
            try
            {
                if (myreader.Read())
                {
                    if (myreader.GetString(0)==nombre&&myreader.GetString(1)==clave)
                    {

                        MessageBox.Show("Datos correctos, Bienvenido " + ( txtUsuario.Text));
                       // USUARIOS.UsuariosModificar form = new USUARIOS.UsuariosModificar();
                        //VENTA.Vnta form = new VENTA.Vnta();
                        //form.Show();
                        this.Hide();
                         val = true;
                    }
                }
                else
                {
                    MessageBox.Show("Usuario y/o Contraseña Incorrectos");
                     val = false;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("se ha producido un error" + err + "");
               

            }
            Conexion.Close();


        }
    }
}
