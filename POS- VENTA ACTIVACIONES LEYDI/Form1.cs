using POS__VENTA_ACTIVACIONES_LEYDI.CAPAENTIDADES;
using POS__VENTA_ACTIVACIONES_LEYDI.CAPANEGOCIO;
using POS__VENTA_ACTIVACIONES_LEYDI.CAPAPRESENTACION;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS__VENTA_ACTIVACIONES_LEYDI
{
    public partial class FrmPrincipal : Form
    {
        private bool isUpdatingPrecioVenta = false;
        private bool isUpdatingPrecioCompra = false;
        private bool isUpdatingStock = false;

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblBienvenida_Click(object sender, EventArgs e)
        {

        }

        private void Frmprincipal_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = $"Usuario: {SesionActual.NombreUsuario} - Rol: {SesionActual.Rol}";
            /// Control básico por rol
            //Con este codigo deshabilitamos un botón de prueba para el usuario cajero, por ejemplo que no pueda Registrar Cliente(ojo esto es solo prueba)
            switch (SesionActual.Rol)
            {
                case "Admin":
                    // todo habilitado
                    break;
                case "Cajero":
                    cLIENTESToolStripMenuItem.Enabled = false;
                    btnUsuarios.Enabled = false;
                    break;
                default:
                    cLIENTESToolStripMenuItem.Enabled = false;
                    btnUsuarios.Enabled = false;
                    break;


            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        //VENTAS
        private void vENTASToolStripMenuItem_Click(object sender, EventArgs e)
        {
             new FrmVentas().ShowDialog();
        }
        //CLIENTES
        private void cLIENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmClientes().ShowDialog();
        }
        //REPARACIONES
        private void rEPARACIONESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmReparaciones().ShowDialog();
        }
        //PRODUCTOS
        private void pRODUCTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmProducto().ShowDialog();
        }
        //ACTIVACIONES
        private void aCTIVACIONESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmInventario().ShowDialog();
        }
        //REPORTES
        private void rEPORTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
             new FrmInventario().ShowDialog();
        }
        //HERRAMIENTAS
        private void hERRAMIENTASToolStripMenuItem_Click(object sender, EventArgs e)
        {
           //new FrmHerramientas().ShowDialog();
        }
        //AYUDA
        private void aYUDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  new FrmAyuda().ShowDialog();
        }
        //Salir
        private void sALIRToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Salir?", "Confirmar", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FrmUsuarios frm = new FrmUsuarios();
            frm.ShowDialog();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FrmClientes frm = new FrmClientes();
            frm.ShowDialog();

        }
    }
}  