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
    public partial class UsuarioNuevo : Form
    {

       // MySqlConnection Conexion = new MySqlConnection();
       // String Cadenaconexion;

        public UsuarioNuevo()
        {
            InitializeComponent();
        }
       // public ProductoConsultar()
        //{
          //  InitializeComponent();
       // }
        public static void Solonumeros(KeyPressEventArgs pe)
        {
            if (char.IsDigit(pe.KeyChar))
            {
                pe.Handled = false;

            }
            else
            {
                pe.Handled = true;

            }
        }
        public static void Sololetras(KeyPressEventArgs pe)
        {
            if (char.IsLetter(pe.KeyChar))
            {
                pe.Handled = false;

            }
            else if (char.IsControl(pe.KeyChar))
            {
                pe.Handled = false;
            }
            else
            {
                pe.Handled = true;
            }
        }

        private void UsuarioNuevo_Load(object sender, EventArgs e)
        {

        }

        private void txtVerificar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                MySqlConnection Conexion = new MySqlConnection();
                String Cadenaconexion;
                //genero mis variables auxiliares para recibir los datos de los textbox
                String nombre = txtNombre.Text;
                String password = txtContraseña.Text;
                String verificar = txtVerificar.Text;
                String tipo = txtrol.Text;

                //especifico los datos sobre mi conexion y se los evnio al objeto conexion de mysql
                Cadenaconexion = "server=localhost;uid=root;pwd=root;database=Ab_Lirios";
                Conexion.ConnectionString = Cadenaconexion;

                //Creo un objeto comand el cual tendra el query de la instruccion de Insercion
                MySqlCommand comando1 = new MySqlCommand("INSERT INTO usuarios(nom_User,Pass,tipo) values(@nombre,@pass,@tipo)");
                comando1.Connection = Conexion;
                //genero un objeto parametro y agrego al objeto lo que tiene el textbox(para eso utilizamos la variable aux nombre)
                MySqlParameter parametro4 = new MySqlParameter();
                int id = 2;
                parametro4.ParameterName = "@id";
                parametro4.Value = id;
                comando1.Parameters.Add(parametro4);

                MySqlParameter parametro1 = new MySqlParameter();
                parametro1.ParameterName = "@nombre";
                parametro1.Value = nombre;

                comando1.Parameters.Add(parametro1);
                //recordar que APP es password, se cambio de apellido por que era nombre de campo incorrecto
                //mismo punto que el anterior
                MySqlParameter parametro2 = new MySqlParameter();
                parametro2.ParameterName = "@pass";
                parametro2.Value = password;

                comando1.Parameters.Add(parametro2);

                MySqlParameter parametro3 = new MySqlParameter();
                parametro3.ParameterName = "@tipo";
                parametro3.Value = tipo;

                comando1.Parameters.Add(parametro3);
                
                //uso un try para abrir la conexion y ejecutar el query y el catch para cerrar la conexion

                try
                {
                    Conexion.Open();
                    comando1.ExecuteNonQuery();
                    MessageBox.Show("Bien echo ya insertamos datos!!!", "Conectado");


                    txtNombre.Clear();
                    txtContraseña.Clear();
                    txtVerificar.Clear();
                    
                }
                catch (Exception err)
                {
                    MessageBox.Show("Se ha producido un error" + err + "");
                }
                Conexion.Close();



            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            //condicion para solo números
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            //para backspace
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            //para que admita tecla de espacio
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            //si no cumple nada de lo anterior que no lo deje pasar
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se admiten letras", "validación de texto",
               MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

           
        }
    }
}
