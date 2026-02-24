using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class DetalleVentaBL
    {
        DetalleVentaDAL dal = new DetalleVentaDAL();

        public void InsertarDetalle(DetalleVenta dv)
        {
            dal.InsertarDetalle(dv);
        }
    }
}
