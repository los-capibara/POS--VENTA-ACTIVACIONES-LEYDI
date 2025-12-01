using POS__VENTA_ACTIVACIONES_LEYDI.CAPAENTIDADES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS__VENTA_ACTIVACIONES_LEYDI.CAPANEGOCIO
{
    public partial class FrmProducto : Form
    {
        private ProductoBLL _productoBLL = new ProductoBLL(); // Variable para acceder a la Capa de Negocio
        private int _idProductoSeleccionado = 0;             // Variable para saber qué ID actualizar/eliminar
        public FrmProducto()
        {
            InitializeComponent();
            CargarProductos();
            LimpiarCampos();
        }

        // Auxiliar: Cargar DataGridView
        private void CargarProductos()
        {
            try
            {
                dgvProductos.DataSource = _productoBLL.ListarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message, "Error de Lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Auxiliar: Llenar Entidad con datos del formulario
        private Producto ObtenerDatosFormulario()
        {
            // TryParse para manejar el PrecioVenta (decimal)
            return new Producto
            {
                ID = _idProductoSeleccionado,
                Nombre = txtNombreProducto.Text,
                Descripcion = txtDescripcion.Text,
                Precio = nudPrecioCompra.Value, 

                // Asignar directamente el valor decimal de NumericUpDown
                PrecioVenta = nudPrecioVenta.Value,

                Cantidad = (int)nudCantidadStock.Value,
                CantidadSerie = 0,

                Categoria = cmbCategoria.Text,
                ProveedorId = cmbProveedor.Text,
            };
        }

        // Auxiliar: Limpiar Campos (Asignado a btnLimpiar y usado después de Guardar/Actualizar)
        private void LimpiarCampos()
        {
            _idProductoSeleccionado = 0;
            txtCodigoProducto.Clear();
            txtNombreProducto.Clear();
            txtDescripcion.Clear();

            // Resetear NumericUpDowns
            nudPrecioCompra.Value = 0;
            nudPrecioVenta.Value = 0;
            nudCantidadStock.Value = 0;

            // Resetear ComboBoxes
            cmbCategoria.SelectedIndex = -1;
            cmbProveedor.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;

            // Configuración de botones: Listo para un nuevo registro
            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        // - Eventos de Botones
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Producto producto = ObtenerDatosFormulario();
            string resultado = _productoBLL.GuardarProducto(producto);

            MessageBox.Show(resultado);
            CargarProductos();
            LimpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (_idProductoSeleccionado == 0)
            {
                MessageBox.Show("Debe seleccionar un producto de la lista para actualizar.");
                return;
            }

            Producto producto = ObtenerDatosFormulario();
            producto.ID = _idProductoSeleccionado;

            string resultado = _productoBLL.GuardarProducto(producto);

            MessageBox.Show(resultado);
            CargarProductos();
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idProductoSeleccionado == 0)
            {
                MessageBox.Show("Debe seleccionar un producto para eliminar.");
                return;
            }

            DialogResult confirmacion = MessageBox.Show("¿Está seguro de eliminar este producto?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                string resultado = _productoBLL.EliminarProducto(_idProductoSeleccionado);
                MessageBox.Show(resultado);
                CargarProductos();
                LimpiarCampos();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Almacenar el ID y el Código
                _idProductoSeleccionado = Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells["ID"].Value);
                txtCodigoProducto.Text = dgvProductos.Rows[e.RowIndex].Cells["ID"].Value.ToString();

                // Cargar datos a los controles
                txtNombreProducto.Text = dgvProductos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtDescripcion.Text = dgvProductos.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();

                // Números y Decimales
                nudPrecioCompra.Value = Convert.ToDecimal(dgvProductos.Rows[e.RowIndex].Cells["Precio"].Value);
                nudPrecioVenta.Value = Convert.ToDecimal(dgvProductos.Rows[e.RowIndex].Cells["PrecioVenta"].Value);
                nudCantidadStock.Value = Convert.ToDecimal(dgvProductos.Rows[e.RowIndex].Cells["Cantidad"].Value);

                // ComboBoxes 
                cmbCategoria.Text = dgvProductos.Rows[e.RowIndex].Cells["Categoria"].Value.ToString();
                cmbProveedor.Text = dgvProductos.Rows[e.RowIndex].Cells["ProveedorId"].Value.ToString();
                //  Configurar botones para edición
                btnGuardar.Enabled = false;
                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
                        LimpiarCampos();
        }
    }
}
