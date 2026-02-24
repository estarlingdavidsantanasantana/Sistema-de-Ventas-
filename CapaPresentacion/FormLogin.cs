using CapaEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCategorias f1 = new FrmCategorias();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormularioProducto f2 = new FormularioProducto();
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Formularioventa f3 = new Formularioventa();
            f3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmFacturacion f4 = new FrmFacturacion();
            f4.Show();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGreen;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\santa\OneDrive\Escritorio\categoria.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; 

            


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile(@"C:\Users\santa\OneDrive\Escritorio\producto.png");
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = Image.FromFile(@"C:\Users\santa\OneDrive\Escritorio\ventas.jpg");
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox4.Image = Image.FromFile(@"C:\Users\santa\OneDrive\Escritorio\Facturacion.png");
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}




