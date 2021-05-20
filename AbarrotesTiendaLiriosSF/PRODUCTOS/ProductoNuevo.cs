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
    public partial class ProductoNuevo : Form
    {
        public ProductoNuevo()
        {
            InitializeComponent();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            
            if (txtNombre.Text != "")
            {
                MySqlConnection Conexion = new MySqlConnection();
                String Cadenaconexion;
                //genero mis variables auxiliares para recibir los datos de los textbox
                String nom_producto = txtNombre.Text;
                String marca = txtMarca.Text;
                String tipoP = txtTipoP.Text;
                String descripcion = txtDescripcion.Text;
                Double costo = Convert.ToDouble(txtCosto.Text);
                int existencias = Convert.ToInt32(txtExistencias.Text);
                //especifico los datos sobre mi conexion y se los evnio al objeto conexion de mysql
                Cadenaconexion = "server=localhost;uid=root;database=Ab_Lirios";
                Conexion.ConnectionString = Cadenaconexion;

                //Creo un objeto comand el cual tendra el query de la instruccion de Insercion
                MySqlCommand comando1 = new MySqlCommand("INSERT INTO producto(nom_producto,marca,tipoP,descripcion,costo,existencias) values(@nom_producto,@marca,@tipoP,@descripcion,@costo,@existencias)");
                comando1.Connection = Conexion;
                //genero un objeto parametro y agrego al objeto lo que tiene el textbox(para eso utilizamos la variable aux nombre)
                //MySqlParameter parametro1 = new MySqlParameter();
                //int id = 2;
                //parametro4.ParameterName = "@id";
                //parametro4.Value = id;
                //comando1.Parameters.Add(parametro4);

                MySqlParameter parametro1 = new MySqlParameter();
                parametro1.ParameterName = "@nom_producto";
                parametro1.Value = nom_producto;

                comando1.Parameters.Add(parametro1);
                //recordar que APP es password, se cambio de apellido por que era nombre de campo incorrecto
                //mismo punto que el anterior
                MySqlParameter parametro2 = new MySqlParameter();
                parametro2.ParameterName = "@marca";
                parametro2.Value = marca;

                comando1.Parameters.Add(parametro2);

                MySqlParameter parametro3 = new MySqlParameter();
                parametro3.ParameterName = "@tipoP";
                parametro3.Value = tipoP;

                comando1.Parameters.Add(parametro3);
                
                 MySqlParameter parametro4 = new MySqlParameter();
                parametro4.ParameterName = "@descripcion";
                parametro4.Value = descripcion;

                comando1.Parameters.Add(parametro4);

                MySqlParameter parametro5 = new MySqlParameter();
                parametro5.ParameterName = "@costo";
                parametro5.Value = costo;

                comando1.Parameters.Add(parametro5);
                
                MySqlParameter parametro6 = new MySqlParameter();
                parametro6.ParameterName = "@existencias";
                parametro6.Value = existencias;

                comando1.Parameters.Add(parametro6);
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

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //condicion para solo números
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            //para tecla backspace
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            /*verifica que pueda ingresar punto y también que solo pueda 
           ingresar un punto*/
            else if ((e.KeyChar == '.') && (!txtCosto.Text.Contains(".")))
            {
                e.Handled = false;
            }
            //si no se cumple nada de lo anterior entonces que no lo deje pasar
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se admiten datos numéricos", "validación de  números", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtExistencias_KeyPress(object sender, KeyPressEventArgs e)
        {
            //condicion para solo números
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            //para tecla backspace
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            /*verifica que pueda ingresar punto y también que solo pueda 
           ingresar un punto*/
            else if ((e.KeyChar == '.') && (!txtExistencias.Text.Contains(".")))
            {
                e.Handled = false;
            }
            //si no se cumple nada de lo anterior entonces que no lo deje pasar
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se admiten datos numéricos", "validación de  números", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
    }

