namespace CapaPresentacion
{
    partial class Formularioventa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        
        /// <para name="disposing">
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblCerrar = new System.Windows.Forms.Button();
            this.comboBoxProducto = new System.Windows.Forms.ComboBox();
            this.dataGridViewDetalle = new System.Windows.Forms.DataGridView();
            this.numericUpDownCant = new System.Windows.Forms.NumericUpDown();
            this.btnNuevoVenta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCant)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(72, 141);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 26);
            this.textBox3.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(273, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 47);
            this.button1.TabIndex = 9;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(445, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 43);
            this.button2.TabIndex = 10;
            this.button2.Text = "Limpiar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblCerrar
            // 
            this.lblCerrar.Location = new System.Drawing.Point(619, 20);
            this.lblCerrar.Name = "lblCerrar";
            this.lblCerrar.Size = new System.Drawing.Size(86, 49);
            this.lblCerrar.TabIndex = 12;
            this.lblCerrar.Text = "Cerrar";
            this.lblCerrar.UseVisualStyleBackColor = true;
            this.lblCerrar.Click += new System.EventHandler(this.lblCerrar_Click);
            // 
            // comboBoxProducto
            // 
            this.comboBoxProducto.FormattingEnabled = true;
            this.comboBoxProducto.Location = new System.Drawing.Point(29, 59);
            this.comboBoxProducto.Name = "comboBoxProducto";
            this.comboBoxProducto.Size = new System.Drawing.Size(150, 28);
            this.comboBoxProducto.TabIndex = 13;
            this.comboBoxProducto.SelectedIndexChanged += new System.EventHandler(this.comboBoxProducto_SelectedIndexChanged);
            // 
            // dataGridViewDetalle
            // 
            this.dataGridViewDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetalle.Location = new System.Drawing.Point(47, 276);
            this.dataGridViewDetalle.Name = "dataGridViewDetalle";
            this.dataGridViewDetalle.RowHeadersWidth = 62;
            this.dataGridViewDetalle.RowTemplate.Height = 28;
            this.dataGridViewDetalle.Size = new System.Drawing.Size(735, 310);
            this.dataGridViewDetalle.TabIndex = 14;
            // 
            // numericUpDownCant
            // 
            this.numericUpDownCant.Location = new System.Drawing.Point(29, 93);
            this.numericUpDownCant.Name = "numericUpDownCant";
            this.numericUpDownCant.Size = new System.Drawing.Size(120, 26);
            this.numericUpDownCant.TabIndex = 15;
            this.numericUpDownCant.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnNuevoVenta
            // 
            this.btnNuevoVenta.Location = new System.Drawing.Point(31, 195);
            this.btnNuevoVenta.Name = "btnNuevoVenta";
            this.btnNuevoVenta.Size = new System.Drawing.Size(118, 37);
            this.btnNuevoVenta.TabIndex = 16;
            this.btnNuevoVenta.Text = "Nuevo";
            this.btnNuevoVenta.UseVisualStyleBackColor = true;
            this.btnNuevoVenta.Click += new System.EventHandler(this.btnNuevoVenta_Click);
            // 
            // Formularioventa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 610);
            this.Controls.Add(this.btnNuevoVenta);
            this.Controls.Add(this.numericUpDownCant);
            this.Controls.Add(this.dataGridViewDetalle);
            this.Controls.Add(this.comboBoxProducto);
            this.Controls.Add(this.lblCerrar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Name = "Formularioventa";
            this.Text = "Formularioventa";
            this.Load += new System.EventHandler(this.Formularioventa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCant)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button lblCerrar;
        private System.Windows.Forms.ComboBox comboBoxProducto;
        private System.Windows.Forms.DataGridView dataGridViewDetalle;
        private System.Windows.Forms.NumericUpDown numericUpDownCant;
        private System.Windows.Forms.Button btnNuevoVenta;
    }
}