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
    public partial class FrmVentas : Form
    {
        // Instancias de la capa de negocio
        private VentaBLL ventaBLL = new VentaBLL();
        private ProductoBLL productoBLL = new ProductoBLL();

        // Carrito: La lista temporal de productos a vender (DetalleVenta)
        private List<DetalleVenta> carrito = new List<DetalleVenta>();
        private decimal totalVenta = 0;

        public FrmVentas()
        {
            InitializeComponent();
            ConfigurarDataGridView(); // Llamada al método de configuración
            LimpiarFormulario();
        }
                
        // --- MÉTODOS AUXILIARES ---

        private void ConfigurarDataGridView()
        {
            dgvDetalleVenta.AutoGenerateColumns = true;
            dgvDetalleVenta.ReadOnly = true;
            dgvDetalleVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalleVenta.MultiSelect = false;
        }

        private void CargarDetallesVenta()
        {
            totalVenta = carrito.Sum(d => d.Cantidad * d.PrecioUnitario);
            // lblTotalVenta.Text = totalVenta.ToString("C"); // 'C' para formato de moneda
            dgvDetalleVenta.DataSource = null;
            dgvDetalleVenta.DataSource = carrito;
            btnGuardar.Enabled = carrito.Count > 0;
            btnEliminar.Enabled = carrito.Count > 0;
            btnEditar.Enabled = carrito.Count > 0;
        }

        private void LimpiarFormulario()
        {
            carrito.Clear();
            totalVenta = 0;
            txtNumeroVenta.Clear();
            txtIdCliente.Clear();
            txtIdProducto.Clear();
            // dtpFecha.Value = DateTime.Now; // Opcional: poner la fecha actual
            CargarDetallesVenta();
            txtNumeroVenta.Text = "AUTO"; // o el ID que genere la BD
            btnGuardar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            // btnNuevo.Enabled = true;
        }

        // --- EVENTOS DE BOTONES (CRUD y Carrito) ---

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (carrito.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto para guardar la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(txtIdCliente.Text, out int idCliente) || idCliente <= 0)
            {
                MessageBox.Show("Debe ingresar un ID de Cliente válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Venta nuevaVenta = new Venta
            {
                Fecha = dtpFecha.Value,
                MontoTotal = totalVenta,
                Id_Cliente = idCliente,
                Id_TipoPago = 1,
            };

            var resultado = ventaBLL.RegistrarVenta(nuevaVenta, carrito);

            MessageBox.Show(resultado.Mensaje, "Registro de Venta", MessageBoxButtons.OK, resultado.Exito ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (resultado.Exito)
            {
                txtNumeroVenta.Text = nuevaVenta.Id.ToString();
                LimpiarFormulario();
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtIdProducto.Text, out int idProducto))
            {
                MessageBox.Show("Ingrese un ID de Producto válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Producto producto = productoBLL.BuscarPorId(idProducto);

            if (producto != null)
            {
                DetalleVenta nuevoDetalle = new DetalleVenta
                {
                    Id_Producto = producto.ID, // <-- Corrección aquí
                    Cantidad = 1,
                    PrecioUnitario = producto.PrecioVenta,
                    SubTotal = 1 * producto.PrecioVenta,
                };

                carrito.Add(nuevoDetalle);
                CargarDetallesVenta();
                txtIdProducto.Clear();
            }
            else
            {
                MessageBox.Show("Producto no encontrado.", "Error de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDetalleVenta.SelectedRows.Count > 0)
            {
                int rowIndex = dgvDetalleVenta.SelectedRows[0].Index;
                carrito.RemoveAt(rowIndex);
                CargarDetallesVenta();
                MessageBox.Show("Línea de venta eliminada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Seleccione una fila del detalle para eliminar.", "Advertencia");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDetalleVenta.SelectedRows.Count > 0)
            {
                MessageBox.Show("Funcionalidad de Edición en Detalle de Venta no implementada. Aquí se abriría un diálogo para cambiar Cantidad/Precio.", "Nota");
                // Ejemplo de edición comentado
                /*
                int rowIndex = dgvDetalleVenta.SelectedRows[0].Index;
                DetalleVenta detalleAEditar = carrito[rowIndex];
                detalleAEditar.Cantidad = 2;
                detalleAEditar.SubTotal = detalleAEditar.Cantidad * detalleAEditar.PrecioUnitario;
                CargarDetallesVenta();
                */
            }
            else
            {
                MessageBox.Show("Seleccione una fila del detalle para editar.", "Advertencia");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarDetallesVenta();
            MessageBox.Show("Datos de la venta actualizados y totales recalculados.", "Actualización");
        }
    }
}
