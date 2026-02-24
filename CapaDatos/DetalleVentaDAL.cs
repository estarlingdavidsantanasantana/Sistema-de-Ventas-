using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaDatos
{
    public class DetalleVentaDAL
    {
        public void InsertarDetalle(DetalleVenta dv)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = "sp_InsertarDetalleVenta";
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@venta", dv.Id_venta);
                    cmd.Parameters.AddWithValue("@producto", dv.Id_producto);
                    cmd.Parameters.AddWithValue("@cant", dv.Cant);
                    cmd.Parameters.AddWithValue("@precio", dv.Precio);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
