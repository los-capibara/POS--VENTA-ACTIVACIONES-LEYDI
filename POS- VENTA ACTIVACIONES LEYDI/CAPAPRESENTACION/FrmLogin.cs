using POS__VENTA_ACTIVACIONES_LEYDI.CAPAENTIDADES;
using POS__VENTA_ACTIVACIONES_LEYDI.CAPANEGOCIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS__VENTA_ACTIVACIONES_LEYDI.CAPAPRESENTACION
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario u = UsuarioBLL.Login(txtUsuario.Text.Trim(), txtClave.Text.Trim());

                if (u == null)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Guardar sesión
                SesionActual.IdUsuario = u.IdUsuario;
                SesionActual.NombreUsuario = u.NombreUsuario;
                SesionActual.Rol = u.Rol;

                // Abrir principal
                FrmPrincipal main = new FrmPrincipal();
                main.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cambiarClaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCambiarClave frm = new FrmCambiarClave();
            frm.ShowDialog();

        }
    }
}
