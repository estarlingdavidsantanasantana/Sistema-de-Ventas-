using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public static class UIHelpers
    {
        /// <summary>
        /// Oculta columnas cuyo nombre contiene 'id' (case-insensitive) en el DataGridView.
        /// Útil para evitar mostrar columnas de clave primaria/foránea.
        /// </summary>
        public static void HideIdColumns(DataGridView dgv)
        {
            if (dgv == null) return;

            try
            {
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    if (col == null || col.Name == null) continue;

                    string name = col.Name.ToLowerInvariant();
                    // Considerar nombres habituales: id, id_, idproducto, id_producto, idcliente, id_venta, id_categoria, ID_...
                    if (name.Contains("id") && (name.Contains("id_") || name.StartsWith("id") || name.Contains("_id") || name == "id"))
                    {
                        col.Visible = false;
                        continue;
                    }

                    // También ocultar columnas que contienen 'id' dentro del nombre completo
                    if (name.Contains("id") && !col.Visible)
                    {
                        col.Visible = false;
                    }
                }
            }
            catch
            {
                // No lanzar excepciones de UI helpers
            }
        }
    }
}
