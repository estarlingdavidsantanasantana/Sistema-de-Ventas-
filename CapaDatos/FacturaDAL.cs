using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaDatos
{
    public class FacturacionDAL
    {
        public DataTable ObtenerVentaConCliente(int idVenta)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                string sql = @"sp_BuscarVentaPorId";

                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Venta", idVenta);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                
            }

            return tabla;
        }

       
        public DataTable ObtenerDetalleVenta(int idVenta)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                string sql = @"sp_ListarDetalleVenta";

                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Venta", idVenta);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
            }

            return tabla;
        }
    }
}
