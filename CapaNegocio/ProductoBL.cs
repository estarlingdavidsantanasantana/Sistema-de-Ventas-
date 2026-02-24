using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class ProductoBL
    {
        ProductoDAL dal = new ProductoDAL();

        public void InsertarProducto(Producto p)
        {
            dal.InsertarProducto(p);
        }

        public DataTable ListarProductos()
        {
            return dal.ListarProductos();
        }
    }
}
