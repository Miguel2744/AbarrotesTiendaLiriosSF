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

        private void btnEliminarProducto_Click(object sender, EventArgs e)
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

            Cadenaconexion = "server=localhost;uid=root;database=Ab_Lirios";
            Conexion.ConnectionString = Cadenaconexion;

            MySqlCommand comando1 = new MySqlCommand("delete from producto where nom_producto=(@nombre)");
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

        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            MySqlConnection Conexion = new MySqlConnection();
            String Cadenaconexion;
            //genero mis variables auxiliares para recibir los datos de los textbox
            String nombre = txtNombre.Text;
            String marca = txtMarca.Text;
            String tipo = txtTipoP.Text;
            String descripcion = txtDescripcion.Text;
            String costo = txtCosto.Text;
            String existencias = txtExistencias.Text;

            //especifico los datos sobre mi conexion y se los evnio al objeto conexion de mysql
            Cadenaconexion = "server=localhost;uid=root;database=Ab_Lirios";
            Conexion.ConnectionString = Cadenaconexion;

            //Creo un objeto comand el cual tendra el query de la instruccion de Insercion
            MySqlCommand comando1 = new MySqlCommand(
            "update producto set nom_producto=(@nombre), marca=(@marca), tipoP=(@tipo), descripcion=(@descripcion), costo=(@costo), existencias=(@existencias) where nom_producto=(@nombre)");
            comando1.Connection = Conexion;
            //genero un objeto parametro y agrego al objeto lo que tiene el textbox(para eso utilizamos la variable aux nombre)


            MySqlParameter parametro1 = new MySqlParameter();
            parametro1.ParameterName = "@nombre";
            parametro1.Value = nombre;
            MySqlParameter parametro2 = new MySqlParameter();
            parametro2.ParameterName = "@marca";
            parametro2.Value = marca;
            MySqlParameter parametro3 = new MySqlParameter();
            parametro3.ParameterName = "@tipo";
            parametro3.Value = tipo;
            MySqlParameter parametro4 = new MySqlParameter();
            parametro4.ParameterName = "@descripcion";
            parametro4.Value = descripcion;
            MySqlParameter parametro5 = new MySqlParameter();
            parametro5.ParameterName = "@costo";
            parametro5.Value = costo;
            MySqlParameter parametro6 = new MySqlParameter();
            parametro6.ParameterName = "@existencias";
            parametro6.Value = existencias;

            comando1.Parameters.Add(parametro1);
            comando1.Parameters.Add(parametro2);
            comando1.Parameters.Add(parametro3);
            comando1.Parameters.Add(parametro4);
            comando1.Parameters.Add(parametro5);
            comando1.Parameters.Add(parametro6);

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

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProductoConsultar.Sololetras(e);
        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProductoConsultar.Sololetras(e);
        }

        private void txtTipoP_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProductoConsultar.Sololetras(e);
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProductoConsultar.Solonumeros(e);
        }

        private void txtExistencias_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProductoConsultar.Solonumeros(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProductoConsultar.Sololetras(e);
        }
    }
    }

