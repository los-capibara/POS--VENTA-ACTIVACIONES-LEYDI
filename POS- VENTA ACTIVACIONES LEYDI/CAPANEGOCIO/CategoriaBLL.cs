using POS__VENTA_ACTIVACIONES_LEYDI.CAPADATOS;
using POS__VENTA_ACTIVACIONES_LEYDI.CAPAENTIDADES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS__VENTA_ACTIVACIONES_LEYDI.CAPANEGOCIO
{
    public class CategoriaBLL
    {
        ClienteDAL dal = new ClienteDAL();
        // crea 

        public DataTable Listar()
        {
            return dal.Listar();
        }
        public int Guardar(Cliente2 c)
        {
            if (String.IsNullOrWhiteSpace(c.Nombre))
                throw new Exception("El nombre del cliente es obligatorio.");
            if (c.Id == 0)
            {
                return dal.Insertar(c);
            }
            else
            {
                dal.Actualizar(c);
                return c.Id;
            }

        }
        public void Eliminar(int id)
        {
            dal.Eliminar(id);
        }
        public DataTable Buscar(string nombre)
        {
            return dal.Buscar(nombre);
        }
    }
}
    

