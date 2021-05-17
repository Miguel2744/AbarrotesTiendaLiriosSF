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
                Cadenaconexion = "server=localhost;uid=root;database=Ab_Lirios";
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
            Cadenaconexion = "server=localhost;uid=root;database=Ab_Lirios";
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

        private void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            MySqlConnection Conexion = new MySqlConnection();
            String Cadenaconexion;
            //genero mis variables auxiliares para recibir los datos de los textbox
            String nombre = txtNombre.Text;
            String rol = comboRol.Text;
            String password = txtPass.Text;
            String newPass = txtPassNueva.Text;
            String newNombre = txtNombreNuevo.Text;

            //especifico los datos sobre mi conexion y se los evnio al objeto conexion de mysql
            Cadenaconexion = "server=localhost;uid=root;database=Ab_Lirios";
            Conexion.ConnectionString = Cadenaconexion;

            //Creo un objeto comand el cual tendra el query de la instruccion de Insercion
            MySqlCommand comando1 = new MySqlCommand("update usuarios set nom_User=(@nombreNuevo), Pass=(@passNueva),tipo=(@tipo) where nom_User=(@nombre) and Pass=(@pass)");
            comando1.Connection = Conexion;
            //genero un objeto parametro y agrego al objeto lo que tiene el textbox(para eso utilizamos la variable aux nombre)


            MySqlParameter parametro1 = new MySqlParameter();
            parametro1.ParameterName = "@nombre";
            parametro1.Value = nombre;
            MySqlParameter parametro2 = new MySqlParameter();
            parametro2.ParameterName = "@pass";
            parametro2.Value = password;
            MySqlParameter parametro3 = new MySqlParameter();
            parametro3.ParameterName = "@tipo";
            parametro3.Value = rol;
            MySqlParameter parametro4 = new MySqlParameter();
            parametro4.ParameterName = "@passNueva";
            parametro4.Value = newPass;
            MySqlParameter parametro5 = new MySqlParameter();
            parametro5.ParameterName = "@nombreNuevo";
            parametro5.Value = newNombre;

            comando1.Parameters.Add(parametro1);
            comando1.Parameters.Add(parametro2);
            comando1.Parameters.Add(parametro3);
            comando1.Parameters.Add(parametro4);
            comando1.Parameters.Add(parametro5);

            try
            {
                Conexion.Open();
                comando1.ExecuteNonQuery();
                MessageBox.Show("Datos modificados con exito");
            }
            catch (Exception err)
            {
                MessageBox.Show("Se ha producido un error" + err + "");
            }
            Conexion.Close();
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("Estas seguro de eliminar los datos?", "Advertencia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (opcion == DialogResult.No)
            {
                MessageBox.Show("Datos no Eliminados");
            }
            MySqlConnection Conexion = new MySqlConnection();
            String Cadenaconexion;
            String nombre = txtNombre.Text;
            String password = txtPass.Text;
            
            Cadenaconexion = "server=localhost;uid=root;database=Ab_Lirios";
            Conexion.ConnectionString = Cadenaconexion;
            
            MySqlCommand comando1 = new MySqlCommand("delete from usuarios where nom_User=(@nombre) and Pass=(@pass)");
            comando1.Connection = Conexion;


            MySqlParameter parametro1 = new MySqlParameter();
            parametro1.ParameterName = "@nombre";
            parametro1.Value = nombre;
            MySqlParameter parametro2 = new MySqlParameter();
            parametro2.ParameterName = "@pass";
            parametro2.Value = password;
            comando1.Parameters.Add(parametro1);
            comando1.Parameters.Add(parametro2);


            if (opcion == DialogResult.Yes)
            //opciones que quieras realizar
            {
                try
                {
                    Conexion.Open();
                    comando1.ExecuteNonQuery();
                    MessageBox.Show("Datos de " + txtNombre.Text + " Eliminados!");

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
