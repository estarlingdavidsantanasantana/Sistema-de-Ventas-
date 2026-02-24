using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaEntidades
{
    public class DetalleVenta
    {
        public int Id_detalle { get; set; }
        public int Id_venta { get; set; }
        public int Id_producto { get; set; }
        public int Cant { get; set; }
        public decimal Precio { get; set; }
    }
}
