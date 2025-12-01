using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS__VENTA_ACTIVACIONES_LEYDI.CAPADATOS
{
    public class Conexion
    {
        // REEMPLAZAR CON LOS DATOS DE LA BASE DE DATOS
        private static string CadenaConexion =
            "Data Source=NOMBRE_DE_TU_SERVIDOR;" +
            "Initial Catalog=NOMBRE_DE_TU_BASE_DE_DATOS;" +
            "Integrated Security=True;";

        public static SqlConnection AbrirConexion()
        {
            SqlConnection cn = new SqlConnection(CadenaConexion);
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
