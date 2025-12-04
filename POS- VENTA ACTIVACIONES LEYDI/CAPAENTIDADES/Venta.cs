using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS__VENTA_ACTIVACIONES_LEYDI.CAPAENTIDADES
{
    public class Venta
    {
        public int Id { get; set; } // Agregar esta propiedad para solucionar CS1061
        public DateTime Fecha { get; set; }
        public decimal MontoTotal { get; set; }
        public int Id_TipoPago { get; set; }
        public int Id_Cliente { get; set; }

    }
}
    

