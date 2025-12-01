using POS__VENTA_ACTIVACIONES_LEYDI.CAPADATOS;
using POS__VENTA_ACTIVACIONES_LEYDI.CAPAENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS__VENTA_ACTIVACIONES_LEYDI.CAPANEGOCIO
{
    public class ProductoBLL
    {
        private ProductoDAL productoDAL = new ProductoDAL();

        //  GUARDAR PRODUCTO (Insertar o Actualizar) 
        public string GuardarProducto(Producto producto)
        {
            // --- Validaciones ---
            if (string.IsNullOrWhiteSpace(producto.Nombre))
            {
                return "El nombre del producto es obligatorio.";
            }
            if (producto.Precio <= 0 || producto.PrecioVenta <= 0)
            {
                return "Los precios deben ser mayores a cero.";
            }

            // --- Lógica de CRUD ---
            if (producto.ID == 0) // INSERTAR
            {
                if (productoDAL.Insertar(producto))
                {
                    return " Producto guardado (INSERTADO) exitosamente.";
                }
                else
                {
                    return " Error: La inserción falló o la conexión falló.";
                }
            }
            else // ACTUALIZAR
            {
                if (productoDAL.Actualizar(producto))
                {
                    return "Producto actualizado (MODIFICADO) exitosamente.";
                }
                else
                {
                    return "Error: La actualización falló o la conexión falló.";
                }
            }
        }

        //  ELIMINAR PRODUCTO 
        public string EliminarProducto(int idProducto)
        {
            if (idProducto <= 0)
            {
                return " ID de producto inválido para eliminar.";
            }

            if (productoDAL.Eliminar(idProducto))
            {
                return " Producto eliminado exitosamente.";
            }
            else
            {
                return " Error: No se pudo eliminar el producto.";
            }
        }

        //  LISTAR PRODUCTOS 
        public List<Producto> ListarProductos()
        {
            return productoDAL.Listar();
        }
    }
}
