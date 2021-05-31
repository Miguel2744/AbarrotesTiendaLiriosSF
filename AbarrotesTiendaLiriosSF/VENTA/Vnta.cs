using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbarrotesTiendaLiriosSF.VENTA
{
    public partial class Vnta : Form
    {
      
        private double montoTotal=0;
        private int cantidad_productos;


        public Vnta()
        {
            InitializeComponent();
            cargarProductos();
            cargarCliente();
        }

        private void Vnta_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void cargarCliente()
        {
            txtrol.Items.Clear();
            //Iniciar conexion
            MySqlConnection Conexion = new MySqlConnection();
            //Variable de cadena de conexion
            String Cadenaconexion;
            //especifico los datos sobre mi conexion y se los evnio al objeto conexion de mysql
            Cadenaconexion = "server=localhost;uid=root;database=Ab_Lirios";
            Conexion.ConnectionString = Cadenaconexion;

            //Creo un objeto comand el cual tendra el query de la instruccion de Insercion
            MySqlCommand comando1 = new MySqlCommand("select idcliente,nombre,saldo from cliente;");
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

                        //Agregar productos al combobox txtBuscar
                        txtrol.Items.Add(new CLIENTES.Cliente(Convert.ToInt32(myreader[0]), Convert.ToString(myreader[1]), Convert.ToDouble(myreader[2])));
                    }
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Se ha producido un error" + err + "");
            }
            Conexion.Close();
        }
        private void cargarProductos()
        {
            txtBuscar.Items.Clear();
            txtBuscar.Text = "";
            //Iniciar conexion
            MySqlConnection Conexion = new MySqlConnection();
            //Variable de cadena de conexion
            String Cadenaconexion;
            //especifico los datos sobre mi conexion y se los evnio al objeto conexion de mysql
            Cadenaconexion = "server=localhost;uid=root;database=Ab_Lirios";
            Conexion.ConnectionString = Cadenaconexion;

            //Creo un objeto comand el cual tendra el query de la instruccion de Insercion
            MySqlCommand comando1 = new MySqlCommand("select idproducto,nom_producto,costo,existencias from Producto where existencias>0;");
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

                        //Agregar productos al combobox txtBuscar
                        txtBuscar.Items.Add(new producto(Convert.ToInt32(myreader[0]), Convert.ToString(myreader[1]), Convert.ToInt32(myreader[3]), Convert.ToDouble(myreader[2])));
                    }
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Se ha producido un error" + err + "");
            }
            Conexion.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Verificar que la cantidad de ese producto sea mayor o igual a la cantidad reuqerida
            if(numericUpDown2.Value<=(txtBuscar.SelectedItem as producto).existencias & numericUpDown2.Value!=0)
            {
                //Agregar a la lista
                dataGridView1.Rows.Add(numericUpDown2.Value, (txtBuscar.SelectedItem as producto).nombre, (txtBuscar.SelectedItem as producto).precio, ((txtBuscar.SelectedItem as producto).precio * Convert.ToDouble(numericUpDown2.Value)));
                //
                montoTotal += (txtBuscar.SelectedItem as producto).precio * Convert.ToDouble(numericUpDown2.Value);
                label6.Text = "$ "+montoTotal;


                //Quitar la cantidad de ese producto a la bd
                quitarProducto((txtBuscar.SelectedItem as producto).existencias-Convert.ToInt32(numericUpDown2.Value), (txtBuscar.SelectedItem as producto).id);

                cargarProductos();

                cantidad_productos += Convert.ToInt32(numericUpDown2.Value);


            }
            else
            {
                MessageBox.Show("No hay esa cantidad disponible de articulos");
            }

            //Agregar valores a la lista
        }

        private void quitarProducto(int cantidad, int id)
        {
            MySqlConnection Conexion = new MySqlConnection();

            String Cadenaconexion;

            Cadenaconexion = "server=localhost;uid=root;database=Ab_Lirios";
            Conexion.ConnectionString = Cadenaconexion;

            MySqlCommand comando1 = new MySqlCommand(
            "update producto set existencias=(@cantidad) where idproducto=(@id)");
            comando1.Connection = Conexion;

            MySqlParameter parametro1 = new MySqlParameter();
            parametro1.ParameterName = "@cantidad";
            parametro1.Value = cantidad;

            MySqlParameter parametro2 = new MySqlParameter();
            parametro2.ParameterName = "@id";
            parametro2.Value = id;

            comando1.Parameters.Add(parametro1);
            comando1.Parameters.Add(parametro2);

            try
            {
                Conexion.Open();
                comando1.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show("Se ha producido un error" + err + "");
            }
            Conexion.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Cargar venta a cliente
            if(txtrol.Text!= "Selecciona un cliente existente")
            {
                MySqlConnection Conexion = new MySqlConnection();

                String Cadenaconexion;

                Cadenaconexion = "server=localhost;uid=root;database=Ab_Lirios";
                Conexion.ConnectionString = Cadenaconexion;

                MySqlCommand comando1 = new MySqlCommand(
                "update cliente set saldo=(@saldo) where idcliente=(@id)");
                comando1.Connection = Conexion;

                MySqlParameter parametro1 = new MySqlParameter();
                parametro1.ParameterName = "@saldo";
                parametro1.Value = (txtrol.SelectedItem as CLIENTES.Cliente).saldo + montoTotal;

                MySqlParameter parametro2 = new MySqlParameter();
                parametro2.ParameterName = "@id";
                parametro2.Value = (txtrol.SelectedItem as CLIENTES.Cliente).id;

                comando1.Parameters.Add(parametro1);
                comando1.Parameters.Add(parametro2);


                registrarVenta();
                try
                {
                    Conexion.Open();
                    comando1.ExecuteNonQuery();
                }
                catch (Exception err)
                {
                    MessageBox.Show("Se ha producido un error" + err + "");
                }
                Conexion.Close();
            }
            else
            {
                MessageBox.Show("Selecciona a un cliente");
            }
            

        }

        private void registrarVenta()
        {
            MySqlConnection Conexion = new MySqlConnection();
            String Cadenaconexion;
            //genero mis variables auxiliares para recibir los datos de los textbox
            String fecha = DateTime.Now.ToString("yyyy-MM-dd");
            String hora = DateTime.Now.ToString("HH:mm:ss");
            int articulos = cantidad_productos;
            Double monto_venta = montoTotal;
            int idVenta =1;
            //especifico los datos sobre mi conexion y se los evnio al objeto conexion de mysql
            Cadenaconexion = "server=localhost;uid=root;database=Ab_Lirios";
            Conexion.ConnectionString = Cadenaconexion;

            //Creo un objeto comand el cual tendra el query de la instruccion de Insercion
            MySqlCommand comando1 = new MySqlCommand("INSERT INTO rep_venta(fecha,hora,articulos,monto_venta,idVenta) values (@fecha,@hora,@articulos,@monto_venta,@idVenta)");
            comando1.Connection = Conexion;

            MySqlParameter parametro1 = new MySqlParameter();
            parametro1.ParameterName = "@fecha";
            parametro1.Value = fecha;

            comando1.Parameters.Add(parametro1);
            //recordar que APP es password, se cambio de apellido por que era nombre de campo incorrecto
            //mismo punto que el anterior
            MySqlParameter parametro2 = new MySqlParameter();
            parametro2.ParameterName = "@hora";
            parametro2.Value = hora;

            comando1.Parameters.Add(parametro2);

            MySqlParameter parametro3 = new MySqlParameter();
            parametro3.ParameterName = "@articulos";
            parametro3.Value = articulos;

            comando1.Parameters.Add(parametro3);

            MySqlParameter parametro4 = new MySqlParameter();
            parametro4.ParameterName = "@monto_venta";
            parametro4.Value = monto_venta;

            comando1.Parameters.Add(parametro4);

            MySqlParameter parametro5 = new MySqlParameter();
            parametro5.ParameterName = "@idVenta";
            parametro5.Value = idVenta;

            comando1.Parameters.Add(parametro5);

            //uso un try para abrir la conexion y ejecutar el query y el catch para cerrar la conexion

            try
            {
                Conexion.Open();
                comando1.ExecuteNonQuery();


                //Recargar todo
                dataGridView1.Rows.Clear();
                numericUpDown2.Value = 0;
                cantidad_productos = 0;
                montoTotal = 0;
                label6.Text = "0.00";
                txtrol.Items.Clear();
                cargarCliente();
                cargarProductos();
                txtrol.Text = "Selecciona un cliente existente";

                MessageBox.Show("Venta regristrada existosamente");
            }
            catch (Exception err)
            {
                MessageBox.Show("Se ha producido un error" + err + "");
            }
            Conexion.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            registrarVenta();
        }
    }
}
