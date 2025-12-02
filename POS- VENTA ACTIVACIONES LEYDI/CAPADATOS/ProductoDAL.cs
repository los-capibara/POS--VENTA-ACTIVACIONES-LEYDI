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
    {
        // -------------------------------------------------------------
        // 1. LISTAR PRODUCTOS
        // -------------------------------------------------------------
        public List<Producto> Listar()
        {
            List<Producto> lista = new List<Producto>();
            using (SqlConnection cn = Conexion.AbrirConexion())
            {
                if (cn == null) return lista;

                // QUERY: Mapeo SQL (ProductoID, NombreProducto, PrecioCompra, Stock) a C#
                string query = "SELECT ProductoID, NombreProducto, Descripcion, PrecioCompra, PrecioVenta, Stock, CategoriaID, ProveedorID FROM Productos WHERE Activo = 1";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lista.Add(new Producto
                        {
                            ID = Convert.ToInt32(dr["ProductoID"]),
                            Nombre = dr["NombreProducto"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),

                            // Precio de C# (Compra) mapeado a PrecioCompra de SQL
                            Precio = Convert.ToDecimal(dr["PrecioCompra"]),

                            // PrecioVenta: Mapeado a decimal.
                            PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),

                            // Cantidad de C# mapeado a Stock de SQL
                            Cantidad = Convert.ToInt32(dr["Stock"]),

                            // Campo CantidadSerie inicializado a 0 (No existe en la DB Productos)
                            CantidadSerie = 0,

                            // Mapeo de IDs foráneos (INT en SQL) a String de C#
                            Categoria = dr["CategoriaID"].ToString(),
                            ProveedorId = dr["ProveedorID"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        // -------------------------------------------------------------
        // 2. INSERTAR PRODUCTO (Comando SQL Directo)
        // -------------------------------------------------------------
        public bool Insertar(Producto producto)
        {
            using (SqlConnection cn = Conexion.AbrirConexion())
            {
                if (cn == null) return false;

                // INSERT INTO: Los nombres de columna deben coincidir con tu tabla Productos
                string query = @"INSERT INTO Productos (NombreProducto, Descripcion, PrecioCompra, PrecioVenta, Stock, CategoriaID, ProveedorID, Activo, FechaCreacion)
                                 VALUES (@NombreProducto, @Descripcion, @PrecioCompra, @PrecioVenta, @Stock, @CategoriaID, @ProveedorID, 1, GETDATE())";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.CommandType = CommandType.Text;

                    // Parámetros usando los nombres de columna de SQL
                    cmd.Parameters.AddWithValue("@NombreProducto", producto.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@PrecioCompra", producto.Precio);
                    cmd.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                    cmd.Parameters.AddWithValue("@Stock", producto.Cantidad);
                    cmd.Parameters.AddWithValue("@CategoriaID", Convert.ToInt32(producto.Categoria));
                    cmd.Parameters.AddWithValue("@ProveedorID", Convert.ToInt32(producto.ProveedorId));

                    try
                    {
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }

        // -------------------------------------------------------------
        // 3. ACTUALIZAR PRODUCTO (Comando SQL Directo)
        // -------------------------------------------------------------
        public bool Actualizar(Producto producto)
        {
            using (SqlConnection cn = Conexion.AbrirConexion())
            {
                if (cn == null) return false;

                // UPDATE: Los nombres de columna deben coincidir con tu tabla Productos
                string query = @"UPDATE Productos
                                 SET NombreProducto = @NombreProducto,
                                     Descripcion = @Descripcion,
                                     PrecioCompra = @PrecioCompra,
                                     PrecioVenta = @PrecioVenta,
                                     Stock = @Stock,
                                     CategoriaID = @CategoriaID,
                                     ProveedorID = @ProveedorID,
                                     FechaModificacion = GETDATE()
                                 WHERE ProductoID = @ProductoID";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.CommandType = CommandType.Text;

                    // Parámetros usando los nombres de columna de SQL
                    cmd.Parameters.AddWithValue("@ProductoID", producto.ID);
                    cmd.Parameters.AddWithValue("@NombreProducto", producto.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@PrecioCompra", producto.Precio);
                    cmd.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                    cmd.Parameters.AddWithValue("@Stock", producto.Cantidad);
                    cmd.Parameters.AddWithValue("@CategoriaID", Convert.ToInt32(producto.Categoria));
                    cmd.Parameters.AddWithValue("@ProveedorID", Convert.ToInt32(producto.ProveedorId));

                    try
                    {
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }

        // -------------------------------------------------------------
        // 4. ELIMINAR PRODUCTO (Eliminación Lógica)
        // -------------------------------------------------------------
        public bool Eliminar(int idProducto)
        {
            using (SqlConnection cn = Conexion.AbrirConexion())
            {
                if (cn == null) return false;

                // Eliminación Lógica: Cambia el campo Activo a 0
                string query = "UPDATE Productos SET Activo = 0, FechaModificacion = GETDATE() WHERE ProductoID = @ProductoID";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ProductoID", idProducto);

                    try
                    {
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }
    }
}