using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Formularioventa : Form
    {
        VentaBL bL = new VentaBL();
        ProductoBL productoBL = new ProductoBL();
        DetalleVentaBL detalleBL = new DetalleVentaBL();

        // DataTable para detalle en memoria
        private DataTable dtDetalle;
        private bool enProgreso = false; // Nueva venta en progreso

        public Formularioventa()
        {
            InitializeComponent();
        }

        private void btnNuevoVenta_Click(object sender, EventArgs e)
        {
            // Iniciar nueva venta: limpiar detalle y permitir agregar
            enProgreso = true;
            dtDetalle?.Clear();
            CalcularTotal();
            comboBoxProducto.Enabled = true;
            numericUpDownCant.Enabled = true;
            button1.Enabled = true; // Agregar
            MessageBox.Show("Nueva venta iniciada. Agrega productos al detalle y luego guarda.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Limpiar: restablecer campos relevantes
            textBox3.Clear();
            comboBoxProducto.SelectedIndex = -1;
            numericUpDownCant.Value = 1;
            dtDetalle?.Clear();

            comboBoxProducto.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Listar button was removed from designer; keep method empty
            CargarVentas();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!enProgreso)
            {
                MessageBox.Show("Primero inicie una nueva venta con el botón 'Nuevo'.");
                return;
            }

            // Esta acción ahora será para agregar un producto al detalle
            AgregarDetalle();
        }

        private void Formularioventa_Load(object sender, EventArgs e)
        {
            CargarVentas();
            CargarProductos();
            InicializarDetalleTable();
            this.BackColor = Color.LightBlue;

            // Inicialmente no hay venta en progreso
            enProgreso = false;
            comboBoxProducto.Enabled = false;
            numericUpDownCant.Enabled = false;
            button1.Enabled = false;
        }

        private void CargarVentas()
        {
            // Sin DataGridView de ventas: método intencionalmente vacío.
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarProductos()
        {
            try
            {
                DataTable dt = productoBL.ListarProductos();
                // Usar DataTable para llenar ComboBox
                comboBoxProducto.DisplayMember = "Nombre_producto";
                comboBoxProducto.ValueMember = "ID_producto";
                comboBoxProducto.DataSource = dt;
                comboBoxProducto.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }

        private void InicializarDetalleTable()
        {
            dtDetalle = new DataTable();
            dtDetalle.Columns.Add("Id_producto", typeof(int));
            dtDetalle.Columns.Add("Nombre_producto", typeof(string));
            dtDetalle.Columns.Add("Cant", typeof(int));
            dtDetalle.Columns.Add("Precio", typeof(decimal));
            dtDetalle.Columns.Add("Subtotal", typeof(decimal), "Cant * Precio");

            dataGridViewDetalle.DataSource = dtDetalle;
            UIHelpers.HideIdColumns(dataGridViewDetalle);
           
        }

        private void AgregarDetalle()
        {
            if (comboBoxProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un producto");
                return;
            }

            int idProducto = Convert.ToInt32(comboBoxProducto.SelectedValue);
            string nombre = comboBoxProducto.Text;
            int cant = (int)numericUpDownCant.Value;

            // Obtener precio del producto desde la lista (DataTable)
            DataTable dtProd = (DataTable)comboBoxProducto.DataSource;
            DataRow[] rows = dtProd.Select("ID_producto = " + idProducto);
            decimal precio = 0;
            if (rows.Length > 0)
            {
                precio = Convert.ToDecimal(rows[0]["Precio_producto"]);
            }

            // Agregar a dtDetalle
            dtDetalle.Rows.Add(idProducto, nombre, cant, precio);

            CalcularTotal();
        }

        private void CalcularTotal()
        {
            decimal total = 0;
            foreach (DataRow r in dtDetalle.Rows)
            {
                total += Convert.ToDecimal(r["Subtotal"]);
            }

            textBox3.Text = total.ToString("F2"); // Mostrar total en el textbox correspondiente
            label3.Text = "Total: " + total.ToString("N2");
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            AgregarDetalle();
        }

        // Nuevo: al seleccionar producto, opcionalmente actualizar total por defecto
        private void comboBoxProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si no hay items en detalle, establecer total al precio del producto seleccionado
            if (comboBoxProducto.SelectedIndex != -1)
            {
                DataTable dtProd = (DataTable)comboBoxProducto.DataSource;
                int idProducto = Convert.ToInt32(comboBoxProducto.SelectedValue);
                DataRow[] rows = dtProd.Select("ID_producto = " + idProducto);
                if (rows.Length > 0 && (dtDetalle == null || dtDetalle.Rows.Count == 0))
                {
                    decimal precio = Convert.ToDecimal(rows[0]["Precio_producto"]);
                    textBox3.Text = precio.ToString("F2");
                    label3.Text = "Total: " + precio.ToString("N2");
                }
            }
        }

        private void buttonGuardarVentaCompleta_Click(object sender, EventArgs e)
        {
            try
            {
                if (!enProgreso)
                {
                    MessageBox.Show("No hay una venta iniciada. Haga clic en 'Nuevo' para comenzar una nueva venta.");
                    return;
                }

                // Usar fecha actual ya que se eliminó el control de fecha
                DateTime fechaVenta = DateTime.Now;

                // Asumir idCliente por defecto porque se eliminó el textbox de cliente.
                int idCliente = 0;

                if (dtDetalle == null || dtDetalle.Rows.Count == 0)
                {
                    MessageBox.Show("Agregue al menos un producto al detalle");
                    return;
                }

                if (!decimal.TryParse(textBox3.Text, out decimal totalGeneral))
                {
                    // Recalcular por seguridad
                    totalGeneral = 0;
                    foreach (DataRow r in dtDetalle.Rows)
                    {
                        totalGeneral += Convert.ToDecimal(r["Subtotal"]);
                    }
                }

                Venta v = new Venta();
                v.Fecha_venta = fechaVenta;
                v.Id_cliente = idCliente;
                v.Total_general = totalGeneral;
                v.Estado_venta = string.Empty;

                int idVenta = bL.GuardarVenta(v);

                // Guardar detalles
                foreach (DataRow r in dtDetalle.Rows)
                {
                    DetalleVenta dv = new DetalleVenta();
                    dv.Id_venta = idVenta;
                    dv.Id_producto = Convert.ToInt32(r["Id_producto"]);
                    dv.Cant = Convert.ToInt32(r["Cant"]);
                    dv.Precio = Convert.ToDecimal(r["Precio"]);

                    detalleBL.InsertarDetalle(dv);
                }

                MessageBox.Show("Venta y detalles guardados correctamente.");

                // Limpiar
                dtDetalle.Clear();
                CalcularTotal();
                CargarVentas();
                textBox3.Clear();
                comboBoxProducto.SelectedIndex = -1;
                numericUpDownCant.Value = 1;

                // Finalizar venta en progreso
                enProgreso = false;
                comboBoxProducto.Enabled = false;
                numericUpDownCant.Enabled = false;
                button1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar venta completa: " + ex.Message);
            }
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            FormLogin frm = new FormLogin();
            frm.Show();
            this.Hide();
        }

        private void dataGridViewDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}