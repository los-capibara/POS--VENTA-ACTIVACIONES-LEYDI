using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS__VENTA_ACTIVACIONES_LEYDI.CAPADATOS
{
    public static class Conexion
    {

       /* public static string Cadena { get; set; } =
           @"Data Source = ALEXIS\SQLEXPRESS;
                                      Initial Catalog = POSLeydi;
                                     Integrated Security = True;";*/

       public static string Cadena { get; set; } =
   @"Data Source = DESKTOP-I5KBNK0\SQLEXPRESS;
                                      Initial Catalog = POSLeydi;
                                     Integrated Security = True;";

        public static SqlConnection AbrirConexion()
        {
            SqlConnection cn = new SqlConnection(Cadena);
            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception)
            {
                // La Capa de Negocio manejará el mensaje de error.
                return null;
            }
        }
    }
}
