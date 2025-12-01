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

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        //VENTAS
        private void vENTASToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // new FrmVentas().ShowDialog();
        }
        //CLIENTES
        private void cLIENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new FrmClientes().ShowDialog();
        }
        //REPARACIONES
        private void rEPARACIONESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new FrmReparaciones().ShowDialog();
        }
        //PRODUCTOS
        private void pRODUCTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new FrmProductos().ShowDialog();
        }
        //ACTIVACIONES
        private void aCTIVACIONESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new FrmInventario().ShowDialog();
        }
        //REPORTES
        private void rEPORTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
         //   new FrmInventario().ShowDialog();
        }
        //HERRAMIENTAS
        private void hERRAMIENTASToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // new FrmHeeramientas().ShowDialog();
        }
        //AYUDA
        private void aYUDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
        //    new FrmAyuda().ShowDialog();
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
    }
    }
    
    

