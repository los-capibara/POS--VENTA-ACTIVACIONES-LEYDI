using POS__VENTA_ACTIVACIONES_LEYDI.CAPAENTIDADES;
using POS__VENTA_ACTIVACIONES_LEYDI.CAPANEGOCIO;
using System;
using System.Windows.Forms;

namespace POS__VENTA_ACTIVACIONES_LEYDI.CAPAPRESENTACION
{
    public partial class FrmCategoria : Form
    {
        private CategoriaBLL bll = new CategoriaBLL();
        private int categoriaID = 0;
        public FrmCategoria()
        {
            InitializeComponent();
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            CargarDatos();
            HabilitarBotones();
        }

        //METODO PARA HABILITAR BOTONES EDITAR Y ELIMINAR
        void HabilitarBotones()
        {
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            dgvCategoria.ClearSelection();
            dgvCategoria.SelectionChanged += (s, e) =>
            {
                bool filaSeleccionada = dgvCategoria.SelectedRows.Count > 0;
                btnEditar.Enabled = filaSeleccionada;
                btnEliminar.Enabled = filaSeleccionada;
            };
            CargarDatos();
            HabilitarBotones();
        }
        void CargarDatos()
        {
            dgvCategoria.DataSource = bll.Listar();
            dgvCategoria.ClearSelection();
            categoriaID = 0;   // Reiniciar ID seleccionado

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dgvCategoria.DataSource = bll.Buscar(txtBuscar.Text);
        }

        private void dgvCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                categoriaID = Convert.ToInt32(dgvCategoria.Rows[e.RowIndex].Cells["id"].Value);
            }


        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmCategoriaGestion frm = new FrmCategoriaGestion();

            // MODO CREAR NUEVA CATEGORIA
            frm.Modo = "Nuevo";
            frm.Id = 0;

            frm.ShowDialog(); 
            CargarDatos();   

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (categoriaID == 0)
            {
                MessageBox.Show("Seleccione una categoría",
                   "Información",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                return;
            }
            FrmCategoriaGestion frm = new FrmCategoriaGestion();
            // MODO EDITAR
            frm.Modo = "Editar";
            frm.Id = categoriaID;

            // Pasar información desde el DGV
            frm.Nombre = dgvCategoria.CurrentRow.Cells["Nombre"].Value.ToString();
            frm.Descripcion = dgvCategoria.CurrentRow.Cells["Descripcion"].Value.ToString();

            frm.ShowDialog();
            CargarDatos();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (categoriaID == 0)
            {
                MessageBox.Show("Seleccione una categoría",
                   "Información",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                return;

            }
            // Abrir formulario de eliminación
            FrmCategoriaEliminar frm = new FrmCategoriaEliminar();

            frm.Id = categoriaID;
            frm.Nombre = dgvCategoria.CurrentRow.Cells["Nombre"].Value.ToString();
            frm.Descripcion = dgvCategoria.CurrentRow.Cells["Descripcion"].Value.ToString();

            frm.ShowDialog();
            CargarDatos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
