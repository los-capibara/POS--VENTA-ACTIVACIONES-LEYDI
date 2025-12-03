using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS__VENTA_ACTIVACIONES_LEYDI.CAPAENTIDADES
{
    public class Cliente2
    {
        public int Id { get; set; }
        public String Nombre { get; set; }

        public String Dui { get; set; }
        public String Telefono { get; set; }
        public String Correo { get; set; }
        public bool Estado { get; set; }
    }
}
