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
    public class VentaBL
    {
        VentaDAL Dal = new VentaDAL();

        public int GuardarVenta(Venta v)
        {
            return Dal.InsertarVenta(v);
        }

        public DataTable ListarVentas()
        {
            return Dal.ListarVentas();
        }
    }
}
