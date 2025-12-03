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
        private OpenFileDialog openFileDialog1 = new OpenFileDialog();
        private PictureBox pictureBoxProducto;

        public FrmProducto()
        {
            InitializeComponent();

            // Si pictureBoxProducto no está en el diseñador, inicialízalo manualmente:
            if (pictureBoxProducto == null)
            {
                pictureBoxProducto = new PictureBox
                {
                    Name = "pictureBoxProducto",
                    Size = new Size(120, 120),
                    Location = new Point(20, 20),
                    BorderStyle = BorderStyle.FixedSingle,
                    SizeMode = PictureBoxSizeMode.Zoom
                };
                this.Controls.Add(pictureBoxProducto);
            }

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
                if (dgvProductos.Columns.Contains("ID") &&
    dgvProductos.Rows[e.RowIndex].Cells["ID"].Value != null)
                {
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
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private bool isUpdatingPrecioVenta = false;
        private bool isUpdatingPrecioCompra = false;
        private bool isUpdatingStock = false;
        private bool isUpdatingCampos = false;

        private void NudPrecioCompra_ValueChanged(object sender, EventArgs e)
        {

            if (isUpdatingPrecioCompra) return;

            try
            {
                isUpdatingPrecioCompra = true;

                if (nudPrecioVenta.Value > 0 && nudPrecioCompra.Value > nudPrecioVenta.Value)
                {
                    MessageBox.Show("El precio de compra no puede ser mayor que el precio de venta.", "Error de Precio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudPrecioCompra.Value = 0;
                }
            }
            finally
            {
                isUpdatingPrecioCompra = false;
            }
        }

        private void nudPrecioVenta_ValueChanged(object sender, EventArgs e)
        {
            if (isUpdatingPrecioVenta) return;

            try
            {
                isUpdatingPrecioVenta = true;

                if (nudPrecioVenta.Value < nudPrecioCompra.Value && nudPrecioCompra.Value > 0)
                {
                    MessageBox.Show("El precio de venta no puede ser menor que el precio de compra.",
                                  "Error de Precio",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    nudPrecioVenta.Value = nudPrecioCompra.Value;
                }
            }
            finally
            {
                isUpdatingPrecioVenta = false;
            }
        }

        private void nudCantidadStock_ValueChanged(object sender, EventArgs e)
        {
            if (isUpdatingStock) return;

            try
            {
                isUpdatingStock = true;

                if (nudCantidadStock.Value < 0)
                {
                    MessageBox.Show("La cantidad en stock no puede ser negativa.",
                                  "Error de Cantidad",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    nudCantidadStock.Value = 0;
                }
                else if (nudCantidadStock.Value > 10000)
                {
                    MessageBox.Show("La cantidad en stock no puede exceder 10,000 unidades.",
                                  "Error de Cantidad",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    nudCantidadStock.Value = 10000;
                }
            }
            finally
            {
                isUpdatingStock = false;
            }
        }

        // Los demás eventos permanecen igual
        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbProveedor.Items.Clear();
            if (cmbCategoria.SelectedItem != null)
            {
                string categoriaSeleccionada = cmbCategoria.SelectedItem.ToString();

                if (categoriaSeleccionada == "Electrónica")
                {
                    cmbProveedor.Items.AddRange(new string[] { "Proveedor A", "Proveedor B" });
                }
                else if (categoriaSeleccionada == "Ropa")
                {
                    cmbProveedor.Items.AddRange(new string[] { "Proveedor C", "Proveedor D" });
                }
                else if (categoriaSeleccionada == "Alimentos")
                {
                    cmbProveedor.Items.AddRange(new string[] { "Proveedor E", "Proveedor F" });
                }
                cmbProveedor.SelectedIndex = -1;
            }
        }

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string proveedorSeleccionado = cmbProveedor.SelectedItem as string;
            if (proveedorSeleccionado != null)
            {
                // Lógica adicional según el proveedor
            }
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEstado.SelectedItem != null)
            {
                string estadoSeleccionado = cmbEstado.SelectedItem.ToString();
                // Puedes comentar este MessageBox si no lo necesitas cada vez
                // MessageBox.Show($"Estado seleccionado: {estadoSeleccionado}", 
                //                "Estado del Producto", 
                //                MessageBoxButtons.OK, 
                //                MessageBoxIcon.Information);
            }
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Aquí puedes agregar lógica para manejar el clic en celdas específicas
            }
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            if (txtDescripcion.Text.Length > 500)
            {
                MessageBox.Show("La descripción no puede exceder 500 caracteres.", "Error de Descripción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Text = txtDescripcion.Text.Substring(0, 500);
                txtDescripcion.SelectionStart = txtDescripcion.Text.Length; // Mover el cursor al final
            }

        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string rutaImagen = openFileDialog1.FileName;
                pictureBoxProducto.Image = Image.FromFile(rutaImagen);
            }
        }

        private void groupBoxi_Enter(object sender, EventArgs e)
        {

        }
    }

}
