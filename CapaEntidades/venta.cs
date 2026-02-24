using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaEntidades
{
    public class Venta
    {
        public int Id_venta { get; set; }
        public DateTime Fecha_venta { get; set; }
        public int Id_cliente { get; set; }
        public decimal Total_general { get; set; }
        public string Estado_venta { get; set; }
    }
}
