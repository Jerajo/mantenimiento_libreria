namespace libreria.forms
{
    partial class FrmPrestamo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUpd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.lbFecha = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtFin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbEjemplares = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(24, 20);
            this.dgvList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvList.RowTemplate.Height = 25;
            this.dgvList.RowTemplate.ReadOnly = true;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(805, 292);
            this.dgvList.TabIndex = 0;
            this.dgvList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RowClic);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUpd);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.lbFecha);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbCliente);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtFin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbEjemplares);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 322);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(805, 161);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // btnUpd
            // 
            this.btnUpd.Location = new System.Drawing.Point(460, 118);
            this.btnUpd.Name = "btnUpd";
            this.btnUpd.Size = new System.Drawing.Size(96, 35);
            this.btnUpd.TabIndex = 15;
            this.btnUpd.Text = "Actualizar";
            this.btnUpd.UseVisualStyleBackColor = true;
            this.btnUpd.Click += new System.EventHandler(this.btnUpd_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(608, 118);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(96, 35);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Limpiar";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(460, 118);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(96, 35);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(22, 53);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(149, 35);
            this.btnSelect.TabIndex = 12;
            this.btnSelect.Text = "Seleccionar Libro";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbFecha
            // 
            this.lbFecha.AutoSize = true;
            this.lbFecha.Location = new System.Drawing.Point(213, 53);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(0, 20);
            this.lbFecha.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::libreria.Properties.Resources.untitled14;
            this.pictureBox1.Location = new System.Drawing.Point(608, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(428, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Clientes";
            // 
            // cbCliente
            // 
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(432, 45);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(173, 28);
            this.cbCliente.TabIndex = 8;
            this.cbCliente.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fecha de Entrega";
            // 
            // dtFin
            // 
            this.dtFin.CustomFormat = "     dd MMM yyyy";
            this.dtFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFin.Location = new System.Drawing.Point(217, 127);
            this.dtFin.Name = "dtFin";
            this.dtFin.Size = new System.Drawing.Size(200, 26);
            this.dtFin.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fecha Inicio";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ejemplares disponibles";
            // 
            // cbEjemplares
            // 
            this.cbEjemplares.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEjemplares.FormattingEnabled = true;
            this.cbEjemplares.Location = new System.Drawing.Point(22, 125);
            this.cbEjemplares.Name = "cbEjemplares";
            this.cbEjemplares.Size = new System.Drawing.Size(149, 28);
            this.cbEjemplares.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Libros disponibles";
            // 
            // FrmPrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 497);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvList);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmPrestamo";
            this.Text = "FrmPrestamo";
            this.Load += new System.EventHandler(this.FrmPrestamo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbEjemplares;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtFin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbFecha;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnUpd;
    }
}