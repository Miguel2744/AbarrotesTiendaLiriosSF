using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbarrotesTiendaLiriosSF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void AbrirFormEnPanel(object formhija)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void aGREGARUSUARIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new USUARIOS.UsuarioNuevo());
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new USUARIOS.IniciarSesion());
        }

        private void cONSULTARMODIFICARELIMINARUSUARIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new USUARIOS.UsuariosModificar());
        }

        private void aGREGARPRODUCTONUEVOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new PRODUCTOS.ProductoNuevo());
        }

        private void cONSULTARMODIFICARELIMINARToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AbrirFormEnPanel(new PRODUCTOS.ProductoConsultar());
        }

        private void pRODUCTOSEXISTENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new PRODUCTOS.PtoductosDisponibles());
        }

        private void pRODUCTOSAGOTADOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new PRODUCTOS.ProductosAgotados());
        }

        private void rEALIZARVENTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new VENTA.Vnta());
        }

        private void uSUARIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hISTORIALDEVENTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new VENTA.ReporteVenta());
        }

        private void aGREGARCLIENTEToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AbrirFormEnPanel(new CLIENTES.ClienteNuevo());

        }

        private void cONSULTARMODIFICARELIMINARCLIENTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new CLIENTES.ClienteModificar());

        }

        private void vENTAToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //AbrirFormEnPanel(new Modulos.ejemploconexion());
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
