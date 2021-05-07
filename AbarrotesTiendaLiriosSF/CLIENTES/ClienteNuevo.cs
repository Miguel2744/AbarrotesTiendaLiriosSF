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
    public partial class ClienteNuevo : Form
    {
        public ClienteNuevo()
        {
            InitializeComponent();
        }

        private void ClienteNuevo_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
                    }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                MySqlConnection Conexion = new MySqlConnection();
                String Cadenaconexion;
                //genero mis variables auxiliares para recibir los datos de los textbox
                String nombre = txtNombre.Text;
                String alias = txtAlias.Text;
                String telefono = txtTelefono.Text;
                Double saldo = Convert.ToDouble(txtSaldo.Text);
                String descripcion = txtDescripcion.Text;
                //especifico los datos sobre mi conexion y se los evnio al objeto conexion de mysql
                Cadenaconexion = "server=localhost;uid=root;pwd=root;database=Ab_Lirios";
                Conexion.ConnectionString = Cadenaconexion;

                //Creo un objeto comand el cual tendra el query de la instruccion de Insercion
                MySqlCommand comando1 = new MySqlCommand("INSERT INTO cliente(nombre,alias,telefono,saldo,descripcion) values (@nombre,@alias,@telefono,@saldo,@descripcion)");
                comando1.Connection = Conexion;
                //genero un objeto parametro y agrego al objeto lo que tiene el textbox(para eso utilizamos la variable aux nombre)
                //MySqlParameter parametro1 = new MySqlParameter();
                //int id = 2;
                //parametro4.ParameterName = "@id";
                //parametro4.Value = id;
                //comando1.Parameters.Add(parametro4);

                MySqlParameter parametro1 = new MySqlParameter();
                parametro1.ParameterName = "@nombre";
                parametro1.Value = nombre;

                comando1.Parameters.Add(parametro1);
                //recordar que APP es password, se cambio de apellido por que era nombre de campo incorrecto
                //mismo punto que el anterior
                MySqlParameter parametro2 = new MySqlParameter();
                parametro2.ParameterName = "@alias";
                parametro2.Value = alias;

                comando1.Parameters.Add(parametro2);

                MySqlParameter parametro3 = new MySqlParameter();
                parametro3.ParameterName = "@telefono";
                parametro3.Value = telefono;

                comando1.Parameters.Add(parametro3);

                MySqlParameter parametro4 = new MySqlParameter();
                parametro4.ParameterName = "@saldo";
                parametro4.Value = saldo;

                comando1.Parameters.Add(parametro4);

                MySqlParameter parametro5 = new MySqlParameter();
                parametro5.ParameterName = "@descripcion";
                parametro5.Value = descripcion;

                comando1.Parameters.Add(parametro5);

                //uso un try para abrir la conexion y ejecutar el query y el catch para cerrar la conexion

                try
                {
                    Conexion.Open();
                    comando1.ExecuteNonQuery();
                    MessageBox.Show("Bien echo ya insertamos datos!!!", "Conectado");
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
