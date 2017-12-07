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
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPrestar = new System.Windows.Forms.Button();
            this.btnFL = new System.Windows.Forms.PictureBox();
            this.btnFC = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtFin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtPicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cbEjemplares = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbLibros = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFC)).BeginInit();
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
            this.dgvList.RowTemplate.ReadOnly = true;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(805, 292);
            this.dgvList.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTitulo);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnDevolver);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnPrestar);
            this.groupBox1.Controls.Add(this.btnFL);
            this.groupBox1.Controls.Add(this.btnFC);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbCliente);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtFin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtPicker1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbEjemplares);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbLibros);
            this.groupBox1.Location = new System.Drawing.Point(24, 322);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(805, 161);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(22, 50);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(196, 26);
            this.txtTitulo.TabIndex = 12;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(695, 104);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 44);
            this.button2.TabIndex = 11;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.btnPrestar_Click);
            // 
            // btnDevolver
            // 
            this.btnDevolver.Location = new System.Drawing.Point(695, 104);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(87, 44);
            this.btnDevolver.TabIndex = 11;
            this.btnDevolver.Text = "Devolver";
            this.btnDevolver.UseVisualStyleBackColor = true;
            this.btnDevolver.Click += new System.EventHandler(this.btnPrestar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(573, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 44);
            this.button1.TabIndex = 11;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.btnPrestar_Click);
            // 
            // btnPrestar
            // 
            this.btnPrestar.Location = new System.Drawing.Point(573, 104);
            this.btnPrestar.Name = "btnPrestar";
            this.btnPrestar.Size = new System.Drawing.Size(87, 44);
            this.btnPrestar.TabIndex = 11;
            this.btnPrestar.Text = "Prestar";
            this.btnPrestar.UseVisualStyleBackColor = true;
            this.btnPrestar.Click += new System.EventHandler(this.btnPrestar_Click);
            // 
            // btnFL
            // 
            this.btnFL.Image = global::libreria.Properties.Resources.untitled14;
            this.btnFL.Location = new System.Drawing.Point(225, 50);
            this.btnFL.Name = "btnFL";
            this.btnFL.Size = new System.Drawing.Size(37, 28);
            this.btnFL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnFL.TabIndex = 10;
            this.btnFL.TabStop = false;
            this.btnFL.Click += new System.EventHandler(this.btnFL_Click);
            // 
            // btnFC
            // 
            this.btnFC.Image = global::libreria.Properties.Resources.untitled14;
            this.btnFC.Location = new System.Drawing.Point(745, 47);
            this.btnFC.Name = "btnFC";
            this.btnFC.Size = new System.Drawing.Size(37, 28);
            this.btnFC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnFC.TabIndex = 10;
            this.btnFC.TabStop = false;
            this.btnFC.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(569, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Clientes";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // cbCliente
            // 
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(573, 47);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(166, 28);
            this.cbCliente.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(309, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fecha de Prestamo";
            // 
            // dtFin
            // 
            this.dtFin.CustomFormat = "     dd MMM yyyy";
            this.dtFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFin.Location = new System.Drawing.Point(313, 125);
            this.dtFin.Name = "dtFin";
            this.dtFin.Size = new System.Drawing.Size(200, 26);
            this.dtFin.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(309, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fecha de Devolución";
            // 
            // dtPicker1
            // 
            this.dtPicker1.CustomFormat = "     dd MMM yyyy";
            this.dtPicker1.Enabled = false;
            this.dtPicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPicker1.Location = new System.Drawing.Point(313, 45);
            this.dtPicker1.Name = "dtPicker1";
            this.dtPicker1.Size = new System.Drawing.Size(200, 26);
            this.dtPicker1.TabIndex = 4;
            this.dtPicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
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
            this.cbEjemplares.Size = new System.Drawing.Size(193, 28);
            this.cbEjemplares.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Titulo del Libro";
            // 
            // cbLibros
            // 
            this.cbLibros.DropDownWidth = 230;
            this.cbLibros.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbLibros.FormattingEnabled = true;
            this.cbLibros.Location = new System.Drawing.Point(221, 123);
            this.cbLibros.Name = "cbLibros";
            this.cbLibros.Size = new System.Drawing.Size(41, 28);
            this.cbLibros.TabIndex = 0;
            this.cbLibros.Visible = false;
            this.cbLibros.SelectedIndexChanged += new System.EventHandler(this.cbLibros_SelectedIndexChanged);
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
            this.Load += new System.EventHandler(this.Form_Load);
            this.Enter += new System.EventHandler(this.Form_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbLibros;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbEjemplares;
        private System.Windows.Forms.DateTimePicker dtPicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtFin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.PictureBox btnFC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPrestar;
        private System.Windows.Forms.Button btnDevolver;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.PictureBox btnFL;
    }
}