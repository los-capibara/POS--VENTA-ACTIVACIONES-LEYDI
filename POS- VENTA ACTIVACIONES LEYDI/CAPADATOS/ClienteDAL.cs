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
    public class ClienteDAL
    {
        public DataTable Listar()
        {
            DataTable dt = new DataTable(); // tabla en memoria
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            // sqconnetin crea una conexion con una db de sqserver ussando
            // la cadena de conexion
            {
                String sql = "SELECT Id , Nombre, Dui,  Telefono, Correo, Estado FROM Cliente";
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                // sqlcommand perpara el comando sql que se enviara a al servidor 
                {
                    cn.Open(); // abre la conexion
                    new SqlDataAdapter(cmd).Fill(dt);
                }
            }
            return dt; // retorna la tabla de los datos
        }
        public int Insertar(Cliente2 c)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                string sql = @"INSERT INTO Cliente(Nombre, Dui, Telefono, Correo, Estado) VALUES (@Nombre, @Dui,  @Telefono, @Correo, @Estado); SELECT SCOPE_IDENTITY();";
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
                    cmd.Parameters.AddWithValue("@Dui", c.Dui);
                    cmd.Parameters.AddWithValue("@Telefono", c.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", c.Correo);
                    cmd.Parameters.AddWithValue("@Estado", c.Estado);
                    cn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar()); // ejecuta el comando
                }
            }

        }
        public bool Actualizar(Cliente2 c)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))



            {
                string sql = @"UPDATE Cliente SET Nombre = @Nombre, Dui = @Dui,  Telefono = @Telefono, Correo = @Correo, Estado = @Estado WHERE Id=@id";
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {

                    cmd.Parameters.AddWithValue("@Id", c.Id);
                    cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
                    cmd.Parameters.AddWithValue("@Dui", c.Dui);
                    cmd.Parameters.AddWithValue("@Telefono", c.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", c.Correo);
                    cmd.Parameters.AddWithValue("@Estado", c.Estado);
                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }

            }
        }

        public bool Eliminar(int Id)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                string sql = "DELETE FROM Cliente WHERE Id=@Id";
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                    // Elimina y devuelve true si se elimina almneos una fila
                }
            }
        }
        public DataTable Buscar(String filtro)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                String sql = @"SELECT Id, Nombre, Dui,  Telefono, Correo, Estado FROM Cliente WHERE Nombre LIKE @filtro OR Telefono LIKE @filtro";
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                    cn.Open();
                    new SqlDataAdapter(cmd).Fill(dt);

                }

            }
            return dt;
        }
        // Este método sirve para llenar el ComboBox de clientes.
        public static List<Cliente2> ListarActivos()
        {
            List<Cliente2> lista = new List<Cliente2>();

            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                string sql = "SELECT * FROM Cliente WHERE Estado = 1";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Cliente2
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Nombre = dr["Nombre"].ToString(),
                                Dui = dr["Dui"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"])
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}

