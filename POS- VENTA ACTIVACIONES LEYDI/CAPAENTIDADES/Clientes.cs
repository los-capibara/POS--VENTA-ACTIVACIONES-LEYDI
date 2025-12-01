using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS__VENTA_ACTIVACIONES_LEYDI.CAPAENTIDADES
{
    public class Clientes
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        
        public string Dui { get; set; }

        public string Tipo { get; set; }

    }
}
