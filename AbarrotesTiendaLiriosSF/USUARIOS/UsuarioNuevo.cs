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
                try
                {

                    CONEXION.CONEXION.ObtenerConexion();

                    MySqlCommand comando1 = new MySqlCommand("INSERT INTO usuarios (idUser,nom_User,Pass,tipo) values (@idUser, @nom_User, @Pass, @tipo)");

                    comando1.Connection = CONEXION.CONEXION.ObtenerConexion();

                    MySqlParameter parametro1 = new MySqlParameter();
                    parametro1.ParameterName = "@idUser";
                    parametro1.Value = txtNombre.Text;
                    comando1.Parameters.Add(parametro1);

                    MySqlParameter parametro2 = new MySqlParameter();
                    parametro2.ParameterName = "@nom_User";
                    parametro2.Value = txtContraseña;

                    comando1.Parameters.Add(parametro2);


                    MySqlParameter parametro3 = new MySqlParameter();
                    parametro2.ParameterName = "@Pass";
                    parametro2.Value = txtVerificar;

                    comando1.Parameters.Add(parametro3);

                    MySqlParameter parametro4 = new MySqlParameter();
                    parametro2.ParameterName = "@tipo";
                    parametro2.Value = txtVerificar;

                    comando1.Parameters.Add(parametro4);

                    comando1.ExecuteNonQuery();
                    MessageBox.Show("Cliente Guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception err)
                {
                    MessageBox.Show("se ha producido un error" + err + "");
                }

                CONEXION.CONEXION.ObtenerConexion();







            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
