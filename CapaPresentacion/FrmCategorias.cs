using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace CapaPresentacion
{
    public partial class FrmCategorias : Form
    {
        public FrmCategorias()
        {
            InitializeComponent();

        }

        private void ListarCategorias()
        {
            SqlConnection cn = new SqlConnection("Data Source=StarlingDavid;Initial Catalog=categoria;Integrated Security=True;TrustServerCertificate=True;");

            try
            {
                cn.Open();
                MessageBox.Show("Conexión abierta correctamente");

                SqlDataAdapter da = new SqlDataAdapter("sp_ListarCategoria", cn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                MessageBox.Show("Filas cargadas: " + dt.Rows.Count);

                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Columns["ID_categoria"].Visible = false;
                dataGridView1.Columns["Estado"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }



        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.LightBlue;
        }
    

      
        
        private CategoriaBL bl = new CategoriaBL();
        private void Listar()
        {
            
        }

      
     
       
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" )
            {
                MessageBox.Show("Debe llenar Ingresar Nombre y Ingresar Estado.");
                return;
            }

            SqlConnection cn = new SqlConnection("Data Source=STARLINGDAVID;Initial Catalog=categoria;Integrated Security=True;TrustServerCertificate=True;");

            try
            {
                cn.Open();
               
                SqlCommand cmd = new SqlCommand("INSERT INTO Categoria (Nombre_categoria) VALUES (@nombre)", cn);
                cmd.Parameters.AddWithValue("@nombre", textBox3.Text);
                cmd.ExecuteNonQuery();



                MessageBox.Show("Nombre agregado correctamente.");

                ListarCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar nombre: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }




        private void button4_Click(object sender, EventArgs e)
        {
            {
                SqlConnection cn = new SqlConnection("Data Source=STARLINGDAVID;Initial Catalog=categoria;Integrated Security=True;TrustServerCertificate=True;");

                try
                {
                    if (TextBox1.Text == "")
                    {
                        MessageBox.Show("Debe escribir el nombre de la categoría.");
                        return;
                    }

                    DialogResult r = MessageBox.Show("¿Seguro que desea eliminar esta categoría?", "Confirmar", MessageBoxButtons.YesNo);

                    if (r == DialogResult.No)
                        return;

                    cn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM Categoria WHERE Nombre_categoria=@nombre", cn);
                    cmd.Parameters.AddWithValue("@nombre", TextBox1.Text);

                    int filas = cmd.ExecuteNonQuery();

                    if (filas > 0)
                        MessageBox.Show("Categoría eliminada correctamente.");
                    else
                        MessageBox.Show("No se encontró la categoría para eliminar.");

                    ListarCategorias();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message);
                }
                finally
                {
                    cn.Close();
                }
            }

        }






        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

       
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("Data Source=STARLINGDAVID;Initial Catalog=categoria;Integrated Security=True;TrustServerCertificate=True;");

            try
            {
                if (TextBox1.Text == "" )
                {
                    MessageBox.Show("Debe llenar todos los campos.");
                    return;
                }

                cn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Categoria (Nombre_categoria, Estado) VALUES (@nombre, @estado)", cn);
                cmd.Parameters.AddWithValue("@nombre", TextBox1.Text);
               

                cmd.ExecuteNonQuery();

                MessageBox.Show("Categoría guardada correctamente.");

                ListarCategorias();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            {
                SqlConnection cn = new SqlConnection("Data Source=STARLINGDAVID;Initial Catalog=categoria;Integrated Security=True;TrustServerCertificate=True;");

                try
                {
                    if (TextBox1.Text == "" )
                    {
                        MessageBox.Show("Debe llenar Nombre ");
                        return;
                    }

                    cn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE Categoria SET Estado=@estado WHERE Nombre_categoria=@nombre", cn);
                    cmd.Parameters.AddWithValue("@nombre", TextBox1.Text);
                   

                    int filas = cmd.ExecuteNonQuery();

                    if (filas > 0)
                        MessageBox.Show("Categoría actualizada correctamente.");
                    else
                        MessageBox.Show("No se encontró la categoría para actualizar.");

                    ListarCategorias();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar: " + ex.Message);
                }
                finally
                {
                    cn.Close();
                }
            }
        }




        private void button6_Click(object sender, EventArgs e)
        {
            {
                TextBox1.Text = "";
                

                textBox3.Text = "";
                

                TextBox1.Focus();
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Debe llenar Ingresar Nombre y Ingresar Estado.");
                return;
            }

            SqlConnection cn = new SqlConnection("Data Source=STARLINGDAVID;Initial Catalog=categoria;Integrated Security=True;TrustServerCertificate=True;");

            try
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Categoria (Nombre_categoria, Estado) VALUES (@nombre, 1)", cn);
                cmd.Parameters.AddWithValue("@nombre", textBox3.Text);
                cmd.ExecuteNonQuery();



                cmd.ExecuteNonQuery();

                MessageBox.Show("Estado agregado correctamente.");

                ListarCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar estado: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}




