namespace libreria.forms
{
    partial class FrmEjemplares
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDatosNoEncontrados = new System.Windows.Forms.Label();
            this.dgvDBR = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cbxISBN = new System.Windows.Forms.ComboBox();
            this.nudNumero = new System.Windows.Forms.NumericUpDown();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDBR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumero)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudNumero);
            this.groupBox2.Controls.Add(this.cbxISBN);
            this.groupBox2.Controls.Add(this.btnEditar);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnNuevo);
            this.groupBox2.Controls.Add(this.btnEliminar);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnCancelar);
            this.groupBox2.Controls.Add(this.btnGuardar);
            this.groupBox2.Controls.Add(this.txtCodigo);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(10, 284);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox2.Size = new System.Drawing.Size(386, 227);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.Turquoise;
            this.btnEditar.Location = new System.Drawing.Point(138, 168);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(93, 53);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Numero";
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.LawnGreen;
            this.btnNuevo.Location = new System.Drawing.Point(13, 168);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(93, 53);
            this.btnNuevo.TabIndex = 4;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Red;
            this.btnEliminar.Location = new System.Drawing.Point(247, 145);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(121, 53);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Visible = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "ISBN";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Red;
            this.btnCancelar.Location = new System.Drawing.Point(138, 167);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(93, 53);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.LawnGreen;
            this.btnGuardar.Location = new System.Drawing.Point(13, 168);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(93, 53);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Visible = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(98, 31);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(279, 29);
            this.txtCodigo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Código";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(261, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mantenimiento de Ejemplares";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(174, 24);
            this.label10.TabIndex = 0;
            this.label10.Text = "Lista de Ejemplares";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.lblDatosNoEncontrados);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.dgvDBR);
            this.groupBox1.Location = new System.Drawing.Point(15, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(407, 523);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // lblDatosNoEncontrados
            // 
            this.lblDatosNoEncontrados.AutoSize = true;
            this.lblDatosNoEncontrados.BackColor = System.Drawing.Color.Black;
            this.lblDatosNoEncontrados.Location = new System.Drawing.Point(104, 133);
            this.lblDatosNoEncontrados.Name = "lblDatosNoEncontrados";
            this.lblDatosNoEncontrados.Size = new System.Drawing.Size(196, 24);
            this.lblDatosNoEncontrados.TabIndex = 7;
            this.lblDatosNoEncontrados.Text = "Datos no Encontrados";
            // 
            // dgvDBR
            // 
            this.dgvDBR.AllowUserToAddRows = false;
            this.dgvDBR.AllowUserToDeleteRows = false;
            this.dgvDBR.AllowUserToResizeRows = false;
            this.dgvDBR.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDBR.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvDBR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDBR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDBR.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eliminar});
            this.dgvDBR.Location = new System.Drawing.Point(10, 31);
            this.dgvDBR.Name = "dgvDBR";
            this.dgvDBR.ReadOnly = true;
            this.dgvDBR.RowHeadersVisible = false;
            this.dgvDBR.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDBR.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDBR.Size = new System.Drawing.Size(386, 244);
            this.dgvDBR.TabIndex = 5;
            this.dgvDBR.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDBR_CellClick);
            this.dgvDBR.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDBR_CellContentClick);
            // 
            // Eliminar
            // 
            this.Eliminar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.Width = 80;
            // 
            // cbxISBN
            // 
            this.cbxISBN.Enabled = false;
            this.cbxISBN.FormattingEnabled = true;
            this.cbxISBN.Location = new System.Drawing.Point(98, 78);
            this.cbxISBN.Name = "cbxISBN";
            this.cbxISBN.Size = new System.Drawing.Size(279, 32);
            this.cbxISBN.TabIndex = 8;
            this.cbxISBN.SelectedIndexChanged += new System.EventHandler(this.generateCode);
            // 
            // nudNumero
            // 
            this.nudNumero.Enabled = false;
            this.nudNumero.Location = new System.Drawing.Point(98, 129);
            this.nudNumero.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumero.Name = "nudNumero";
            this.nudNumero.Size = new System.Drawing.Size(133, 29);
            this.nudNumero.TabIndex = 9;
            this.nudNumero.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumero.ValueChanged += new System.EventHandler(this.generateCode);
            // 
            // FrmEjemplares
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(433, 553);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.Name = "FrmEjemplares";
            this.Text = "Mantenimiento Ejemplares";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEjemplares_FormClosing);
            this.Load += new System.EventHandler(this.Form_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDBR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumero)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDatosNoEncontrados;
        private System.Windows.Forms.DataGridView dgvDBR;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Eliminar;
        private System.Windows.Forms.NumericUpDown nudNumero;
        private System.Windows.Forms.ComboBox cbxISBN;
    }
}