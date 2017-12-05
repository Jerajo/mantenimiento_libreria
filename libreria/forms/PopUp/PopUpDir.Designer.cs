namespace libreria.forms.PopUp
{
    partial class PopUpDir
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.txtSec = new System.Windows.Forms.TextBox();
            this.txtPais = new System.Windows.Forms.TextBox();
            this.txtProv = new System.Windows.Forms.TextBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Calle";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sector";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Pais";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Provincia";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(57, 288);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(126, 44);
            this.btnActualizar.TabIndex = 5;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Visible = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(139, 44);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(220, 26);
            this.txtCalle.TabIndex = 7;
            this.txtCalle.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txtSec
            // 
            this.txtSec.Location = new System.Drawing.Point(139, 93);
            this.txtSec.Name = "txtSec";
            this.txtSec.Size = new System.Drawing.Size(220, 26);
            this.txtSec.TabIndex = 8;
            // 
            // txtPais
            // 
            this.txtPais.Location = new System.Drawing.Point(139, 143);
            this.txtPais.Name = "txtPais";
            this.txtPais.Size = new System.Drawing.Size(220, 26);
            this.txtPais.TabIndex = 9;
            // 
            // txtProv
            // 
            this.txtProv.Location = new System.Drawing.Point(139, 189);
            this.txtProv.Name = "txtProv";
            this.txtProv.Size = new System.Drawing.Size(220, 26);
            this.txtProv.TabIndex = 10;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(57, 288);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(126, 44);
            this.btnNuevo.TabIndex = 11;
            this.btnNuevo.Text = "Guardar";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(220, 288);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 44);
            this.button1.TabIndex = 12;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PopUpDir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 342);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.txtProv);
            this.Controls.Add(this.txtPais);
            this.Controls.Add(this.txtSec);
            this.Controls.Add(this.txtCalle);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PopUpDir";
            this.Text = "Direccion";
            this.Load += new System.EventHandler(this.PopUpDir_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.TextBox txtSec;
        private System.Windows.Forms.TextBox txtPais;
        private System.Windows.Forms.TextBox txtProv;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button button1;
    }
}