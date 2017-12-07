namespace libreria.Mantenimientos
{
    partial class Generos
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
            this.Listado1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNew = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.GroupBox();
            this.txtEdit = new System.Windows.Forms.TextBox();
            this.t = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Listado1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.btnDel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Listado1
            // 
            this.Listado1.AllowUserToAddRows = false;
            this.Listado1.AllowUserToDeleteRows = false;
            this.Listado1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Listado1.Location = new System.Drawing.Point(36, 44);
            this.Listado1.MultiSelect = false;
            this.Listado1.Name = "Listado1";
            this.Listado1.ReadOnly = true;
            this.Listado1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Listado1.Size = new System.Drawing.Size(352, 150);
            this.Listado1.TabIndex = 2;
            this.Listado1.SelectionChanged += new System.EventHandler(this.Listado1_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lista de Generos";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNew);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(36, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 124);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nuevo";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtNew
            // 
            this.txtNew.Location = new System.Drawing.Point(24, 57);
            this.txtNew.Name = "txtNew";
            this.txtNew.Size = new System.Drawing.Size(177, 26);
            this.txtNew.TabIndex = 1;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(246, 57);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 33);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnDel
            // 
            this.btnDel.Controls.Add(this.txtEdit);
            this.btnDel.Controls.Add(this.t);
            this.btnDel.Controls.Add(this.btnEdit);
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(36, 330);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(352, 121);
            this.btnDel.TabIndex = 4;
            this.btnDel.TabStop = false;
            this.btnDel.Text = "Editar";
            // 
            // txtEdit
            // 
            this.txtEdit.Location = new System.Drawing.Point(96, 50);
            this.txtEdit.Name = "txtEdit";
            this.txtEdit.Size = new System.Drawing.Size(177, 26);
            this.txtEdit.TabIndex = 2;
            // 
            // t
            // 
            this.t.Location = new System.Drawing.Point(271, 82);
            this.t.Name = "t";
            this.t.Size = new System.Drawing.Size(75, 33);
            this.t.TabIndex = 2;
            this.t.Text = "Eliminar";
            this.t.UseVisualStyleBackColor = true;
            this.t.Click += new System.EventHandler(this.t_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(24, 82);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 33);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Editar";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // Generos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 463);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Listado1);
            this.Name = "Generos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generos";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Enter += new System.EventHandler(this.Form_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.Listado1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.btnDel.ResumeLayout(false);
            this.btnDel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView Listado1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox btnDel;
        private System.Windows.Forms.Button t;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtNew;
        private System.Windows.Forms.TextBox txtEdit;
    }
}