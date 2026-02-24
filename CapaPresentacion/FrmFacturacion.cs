using System;
using System.Data;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmFacturacion : Form
    {
        VentaBL ventaBL = new VentaBL();

        public FrmFacturacion()
        {
            InitializeComponent();

        }

        private void FrmFacturacion_Load(object sender, EventArgs e)
        {
            try
            {
                ReloadVentas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ventas: " + ex.Message);
                

            }
        }

        public void ReloadVentas()
        {
            DataTable dt = ventaBL.ListarVentas();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = dt;

            // Ocultar la columna Estado_venta si existe
            if (dataGridView1.Columns.Contains("Estado_venta"))
                dataGridView1.Columns["Estado_venta"].Visible = false;

            // Ensure common Venta columns are visible and formatted
            if (dataGridView1.Columns.Contains("Id_venta"))
                dataGridView1.Columns["Id_venta"].Visible = true;

            if (dataGridView1.Columns.Contains("Fecha_venta"))
            {
                dataGridView1.Columns["Fecha_venta"].Visible = true;
                dataGridView1.Columns["Fecha_venta"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dataGridView1.Columns.Contains("Id_cliente"))
                dataGridView1.Columns["Id_cliente"].Visible = true;

            if (dataGridView1.Columns.Contains("Total_general"))
                dataGridView1.Columns["Total_general"].Visible = true;

            // Hide any internal ID columns if UIHelpers provides that behavior
            try { UIHelpers.HideIdColumns(dataGridView1); } catch { }

            dataGridView1.AutoResizeColumns();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormLogin frm = new FormLogin(); 
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una venta primero");
                return;
            }

            int idVenta = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            // Abrir formulario de reporte y pasar idVenta
            FrmReporteFacturacion frm = new FrmReporteFacturacion();

            // Llamar método público para cargar el reporte
            frm.LoadReport(idVenta);

            frm.ShowDialog();
        }
    }
}

