using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class FacturacionBL
    {
        FacturacionDAL dal = new FacturacionDAL();

        public DataTable ObtenerVentaConCliente(int idVenta)
        {
            return dal.ObtenerVentaConCliente(idVenta);
        }

        public DataTable ObtenerDetalleVenta(int idVenta)
        {
            return dal.ObtenerDetalleVenta(idVenta);
        }
    }
}
