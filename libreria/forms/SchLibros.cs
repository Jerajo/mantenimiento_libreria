using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libreria.Busquedas
{

    public partial class SchLibros : Form
    {
        private GroupBox groupBox1;
        private TextBox txtFiltro;
        private RadioButton rbGen;
        private RadioButton rbName;
        private DataGridView dataGridView1;
        private IContainer components;
        private DataGridViewTextBoxColumn iSBNDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tituloDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn generoDataGridViewTextBoxColumn;
        private static SchLibros _instance;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private Button button1;
        private GroupBox gbRB;
        private RadioButton Todos;
        private RadioButton NDisponibles;
        private RadioButton Disponibles;
        private DataTable dt;
        public static SchLibros Instancia

        {
            get
            {
                if (_instance == null)
                    _instance = new SchLibros();

                return _instance;
            }
        }
        private SchLibros()
        {
            InitializeComponent();
            this.Disposed += Search_Disposed;
        }

        private void Search_Disposed(object sender, EventArgs e)
        {
            _instance = null;
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.rbGen = new System.Windows.Forms.RadioButton();
            this.rbName = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.gbRB = new System.Windows.Forms.GroupBox();
            this.Todos = new System.Windows.Forms.RadioButton();
            this.NDisponibles = new System.Windows.Forms.RadioButton();
            this.Disponibles = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbRB.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFiltro);
            this.groupBox1.Controls.Add(this.rbGen);
            this.groupBox1.Controls.Add(this.rbName);
            this.groupBox1.Location = new System.Drawing.Point(27, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(689, 98);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar libros";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltro.Location = new System.Drawing.Point(50, 28);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(568, 26);
            this.txtFiltro.TabIndex = 3;
            this.txtFiltro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFiltro.TextChanged += new System.EventHandler(this.Texto);
            // 
            // rbGen
            // 
            this.rbGen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbGen.AutoSize = true;
            this.rbGen.Location = new System.Drawing.Point(289, 64);
            this.rbGen.Name = "rbGen";
            this.rbGen.Size = new System.Drawing.Size(81, 24);
            this.rbGen.TabIndex = 1;
            this.rbGen.TabStop = true;
            this.rbGen.Text = "Genero";
            this.rbGen.UseVisualStyleBackColor = true;
            this.rbGen.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rbName
            // 
            this.rbName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbName.AutoSize = true;
            this.rbName.Location = new System.Drawing.Point(50, 64);
            this.rbName.Name = "rbName";
            this.rbName.Size = new System.Drawing.Size(83, 24);
            this.rbName.TabIndex = 0;
            this.rbName.TabStop = true;
            this.rbName.Text = "Nombre";
            this.rbName.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 154);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(520, 255);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RowClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.Location = new System.Drawing.Point(567, 157);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(158, 251);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Autores";
            this.columnHeader1.Width = 141;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(567, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 42);
            this.button1.TabIndex = 3;
            this.button1.Text = "Ver Estado";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gbRB
            // 
            this.gbRB.Controls.Add(this.Todos);
            this.gbRB.Controls.Add(this.NDisponibles);
            this.gbRB.Controls.Add(this.Disponibles);
            this.gbRB.Location = new System.Drawing.Point(27, 415);
            this.gbRB.Name = "gbRB";
            this.gbRB.Size = new System.Drawing.Size(409, 72);
            this.gbRB.TabIndex = 10;
            this.gbRB.TabStop = false;
            this.gbRB.Text = "Mostrar libros";
            // 
            // Todos
            // 
            this.Todos.AutoSize = true;
            this.Todos.Checked = true;
            this.Todos.Location = new System.Drawing.Point(317, 25);
            this.Todos.Name = "Todos";
            this.Todos.Size = new System.Drawing.Size(71, 24);
            this.Todos.TabIndex = 8;
            this.Todos.TabStop = true;
            this.Todos.Text = "Todos";
            this.Todos.UseVisualStyleBackColor = true;
            this.Todos.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // NDisponibles
            // 
            this.NDisponibles.AutoSize = true;
            this.NDisponibles.Location = new System.Drawing.Point(148, 25);
            this.NDisponibles.Name = "NDisponibles";
            this.NDisponibles.Size = new System.Drawing.Size(133, 24);
            this.NDisponibles.TabIndex = 8;
            this.NDisponibles.Text = "No Disponibles";
            this.NDisponibles.UseVisualStyleBackColor = true;
            this.NDisponibles.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // Disponibles
            // 
            this.Disponibles.AutoSize = true;
            this.Disponibles.Location = new System.Drawing.Point(16, 26);
            this.Disponibles.Name = "Disponibles";
            this.Disponibles.Size = new System.Drawing.Size(109, 24);
            this.Disponibles.TabIndex = 8;
            this.Disponibles.Text = "Disponibles";
            this.Disponibles.UseVisualStyleBackColor = true;
            this.Disponibles.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // SchLibros
            // 
            this.ClientSize = new System.Drawing.Size(754, 490);
            this.Controls.Add(this.gbRB);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SchLibros";
            this.Load += new System.EventHandler(this.SchLibros_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbRB.ResumeLayout(false);
            this.gbRB.PerformLayout();
            this.ResumeLayout(false);

        }

        private void SchLibros_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'libreriaHCDataSet.vwListadoLibrosNormal' table. You can move, or remove it, as needed.
            dt = new DataTable();
            CheckedChanged(null, null);
            dataGridView1.Columns["Titulo"].Width = 400;
            dataGridView1.Columns["ISBN"].Visible = false;
        }

        private void Texto(object sender, EventArgs e)
        {
            try
            {
                DataView dv = new DataView(dt.Copy());
                if (rbName.Checked)
                {
                    dv.RowFilter = $" Titulo like '%{txtFiltro.Text}%'";
                }
                else if(rbGen.Checked)
                {
                    dv.RowFilter = $" Genero like '%{txtFiltro.Text}%'";
                }
                dataGridView1.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RowClick(object sender, DataGridViewCellEventArgs e)
        {
            var nm = dataGridView1.CurrentRow.Cells["ISBN"].Value.ToString();
            listView1.Items.Clear();
            var Data = DatabaseCon.Instancia.GetData("select Concat(Nombre, ' ', Apellido) as FullName from AutoresSet inner join LibroAutorSet on AutoresSet.Id = AutorId");
            foreach (DataRow item in Data.Rows)
            {
                ListViewItem itm = new ListViewItem(item.Field<string>("FullName"));
                listView1.Items.Add(itm);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {

            }
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            var checkedButton = gbRB.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            switch (checkedButton.Name)
            {
                case "Disponibles":
                    dt = DatabaseCon.Instancia.GetData("select * from vwListadoLibrosNormal where Stock > 0");
                    break;
                case "NDisponibles":
                    dt = DatabaseCon.Instancia.GetData("select * from vwListadoLibrosNormal where Stock < 1");
                    break;
                case "Todos":
                default:
                    dt = DatabaseCon.Instancia.GetData("select * from vwListadoLibrosNormal");
                    break;
            }
            dataGridView1.DataSource = dt;
        }

    }
}
