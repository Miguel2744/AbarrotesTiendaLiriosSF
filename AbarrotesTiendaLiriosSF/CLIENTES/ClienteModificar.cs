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

namespace AbarrotesTiendaLiriosSF.CLIENTES
{
    public partial class ClienteModificar : Form
    {
        public ClienteModificar()
        {
            InitializeComponent();
        }

        private void ClienteModificar_Load(object sender, EventArgs e)
        {
            MySqlConnection Conexion = new MySqlConnection();
            String Cadenaconexion;
            Cadenaconexion = "server=localhost;uid=root;pwd=root;database=Ab_Lirios";
            Conexion.ConnectionString = Cadenaconexion;
            
            
            MySqlCommand comando = new MySqlCommand("select nombre from cliente", Conexion);
            Conexion.Open();
            MySqlDataReader registro = comando.ExecuteReader();
            while (registro.Read())
            {
                comboBuscar.Items.Add(registro["nombre"].ToString());
            }
            Conexion.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
             if (comboBuscar.Text != "")
            {

                txtNombre.Text = "";
                txtApodo.Text = "";
                txtTelefono.Text = "";
                txtDescripcion.Text = "";
                txtSaldo.Text = "";
                txtDescripcion.Text = "";

                MySqlConnection Conexion = new MySqlConnection();
                String Cadenaconexion;
                //genero mis variables auxiliares para recibir los datos de los textbox
                String nombre = comboBuscar.Text;
                //especifico los datos sobre mi conexion y se los evnio al objeto conexion de mysql
                Cadenaconexion = "server=localhost;uid=root;pwd=root;database=Ab_Lirios";
                Conexion.ConnectionString = Cadenaconexion;

                //Creo un objeto comand el cual tendra el query de la instruccion de Insercion
                MySqlCommand comando1 = new MySqlCommand("select nombre,alias,telefono,saldo,descripcion from cliente where nombre='"+ comboBuscar.Text + "';");
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
                            txtApodo.Text += myreader[1];
                            txtTelefono.Text += myreader[2];
                            txtSaldo.Text += myreader[3];
                            txtDescripcion.Text += myreader[4];
                            MessageBox.Show("Aqui estan los datos del cliente que buscas");
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
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

            Cadenaconexion = "server=localhost;uid=root;pwd=root;database=Ab_Lirios";
            Conexion.ConnectionString = Cadenaconexion;

            MySqlCommand comando1 = new MySqlCommand("delete from cliente where nombre=(@nombre)");
            comando1.Connection = Conexion;


            MySqlParameter parametro1 = new MySqlParameter();
            parametro1.ParameterName = "@nombre";
            parametro1.Value = nombre;
            comando1.Parameters.Add(parametro1);


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

        private void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            MySqlConnection Conexion = new MySqlConnection();
            String Cadenaconexion;
            String nombre = txtNombre.Text;
            String apodo = txtApodo.Text;
            String telefono = txtTelefono.Text;
            String saldo = txtSaldo.Text;
            String desc = txtDescripcion.Text;
            
            Cadenaconexion = "server=localhost;uid=root;pwd=root;database=Ab_Lirios";
            Conexion.ConnectionString = Cadenaconexion;
            
            MySqlCommand comando1 = new MySqlCommand(
            "update cliente set nombre=(@nombre), alias=(@apodo), telefono=(@tel), saldo=(@saldo), descripcion=(@desc) where nombre=(@nombre)");
            comando1.Connection = Conexion;

            MySqlParameter parametro1 = new MySqlParameter();
            parametro1.ParameterName = "@nombre";
            parametro1.Value = nombre;
            MySqlParameter parametro2 = new MySqlParameter();
            parametro2.ParameterName = "@apodo";
            parametro2.Value = apodo;
            MySqlParameter parametro3 = new MySqlParameter();
            parametro3.ParameterName = "@tel";
            parametro3.Value = telefono;
            MySqlParameter parametro4 = new MySqlParameter();
            parametro4.ParameterName = "@saldo";
            parametro4.Value = saldo;
            MySqlParameter parametro5 = new MySqlParameter();
            parametro5.ParameterName = "@desc";
            parametro5.Value = desc;

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
    }
}
