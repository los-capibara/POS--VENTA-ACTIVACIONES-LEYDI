using POS__VENTA_ACTIVACIONES_LEYDI.CAPAENTIDADES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS__VENTA_ACTIVACIONES_LEYDI.CAPADATOS
{
    public class ProductoDAL
    {//  LISTAR PRODUCTOS 
        public List<Producto> Listar()
        {
            List<Producto> lista = new List<Producto>();
            using (SqlConnection cn = Conexion.AbrirConexion())
            {
                if (cn == null) return lista;
                string query = "SELECT ID, Nombre, Descripcion, Precio, PrecioVenta, Cantidad, CantidadSerie, Categoria, ProveedorId FROM Productos";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lista.Add(new Producto
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            Nombre = dr["Nombre"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            Precio = Convert.ToDecimal(dr["Precio"]),
                            PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            CantidadSerie = Convert.ToInt32(dr["CantidadSerie"]), // Nuevo campo
                            Categoria = dr["Categoria"].ToString(),
                            ProveedorId = dr["ProveedorId"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        //  INSERTAR PRODUCTO 
        public bool Insertar(Producto producto)
        {
            using (SqlConnection cn = Conexion.AbrirConexion())
            {
                if (cn == null) return false;
                using (SqlCommand cmd = new SqlCommand("sp_InsertarProducto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                    cmd.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                    cmd.Parameters.AddWithValue("@Cantidad", producto.Cantidad);
                    cmd.Parameters.AddWithValue("@CantidadSerie", producto.CantidadSerie); // Nuevo campo
                    cmd.Parameters.AddWithValue("@Categoria", producto.Categoria);
                    cmd.Parameters.AddWithValue("@ProveedorId", producto.ProveedorId);

                    try { cmd.ExecuteNonQuery(); return true; }
                    catch (Exception) { return false; }
                }
            }
        }

        //  ACTUALIZAR PRODUCTO 
        public bool Actualizar(Producto producto)
        {
            using (SqlConnection cn = Conexion.AbrirConexion())
            {
                if (cn == null) return false;
                using (SqlCommand cmd = new SqlCommand("sp_ActualizarProducto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", producto.ID);
                    cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                    cmd.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                    cmd.Parameters.AddWithValue("@Cantidad", producto.Cantidad);
                    cmd.Parameters.AddWithValue("@CantidadSerie", producto.CantidadSerie); // Nuevo campo
                    cmd.Parameters.AddWithValue("@Categoria", producto.Categoria);
                    cmd.Parameters.AddWithValue("@ProveedorId", producto.ProveedorId);

                    try { cmd.ExecuteNonQuery(); return true; }
                    catch (Exception) { return false; }
                }
            }
        }

        //  ELIMINAR PRODUCTO 
        public bool Eliminar(int idProducto)
        {
            using (SqlConnection cn = Conexion.AbrirConexion())
            {
                if (cn == null) return false;
                string query = "DELETE FROM Productos WHERE ID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", idProducto);

                    try { cmd.ExecuteNonQuery(); return true; }
                    catch (Exception) { return false; }
                }
            }
        }
    }
}
