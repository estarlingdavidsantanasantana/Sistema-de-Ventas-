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
    public class ProductoDAL
    {
        public void InsertarProducto(Producto p)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO producto (Nombre_producto, Precio_producto, Stock, ID_categoria) " +
                    "VALUES (@Nombre, @Precio, @Stock, @Categoria)", cn);

                cmd.Parameters.AddWithValue("@Nombre", p.Nombre_producto);
                cmd.Parameters.AddWithValue("@Precio", p.Precio_producto);
                cmd.Parameters.AddWithValue("@Stock", p.Stock);
                cmd.Parameters.AddWithValue("@Categoria", p.ID_categoria);

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ListarProductos()
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                cn.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM producto", cn);
                da.Fill(dt);
            }

            return dt;
        }
    }
}
