using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS__VENTA_ACTIVACIONES_LEYDI.CAPAENTIDADES
{
    public class Producto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public int CantidadSerie { get; set; }
        public string Categoria { get; set; }
        public string ProveedorId { get; set; } = string.Empty;
        public decimal PrecioVenta { get; set; }
       public int Stock { get; set; }
    }
}
