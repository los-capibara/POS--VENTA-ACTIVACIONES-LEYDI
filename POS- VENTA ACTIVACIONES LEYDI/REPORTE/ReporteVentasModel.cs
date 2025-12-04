
using System;
using System.Data;

namespace POS__VENTA_ACTIVACIONES_LEYDI.REPORTE

{
    public class ReporteVentasModel
    {

        // Tabla con la información de ventas (producto, cantidad, etc.)
        public DataTable Tabla { get; }

        // Fechas de inicio y fin del período consultado
        public DateTime Inicio { get; }

        public DateTime Fin { get; }

        // Constructor que recibe los valores y los asigna
        public ReporteVentasModel(DataTable tabla, DateTime inicio, DateTime fin)
        {
            Tabla = tabla;   // Datos del DataTable
            Inicio = inicio; // Fecha inicial
            Fin = fin;       // Fecha final
        }
    }
}