using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libreria.forms
{
    public partial class FrmAutor : Form
    {
        private Nullable<int> ID_Autor { get; set; }
        private static FrmAutor _form;
        private FrmAutor()
        {
            InitializeComponent();
            this.Disposed += DisposedObject;
        }

        private void DisposedObject(object sender, EventArgs e)
        {
            _form = null;
        }

        public static FrmAutor Instance
        {
            get
            {
                if (_form == null)
                    _form = new FrmAutor();
                return _form;
            }
        }

        private void RowCellClick(object sender, DataGridViewCellEventArgs e)
        {
            var CR = dgvAutores.CurrentRow;
            if ( CR != null)
            {
                txtApellidoNew.Clear();
                txtNombreNew.Clear();
                txtNameEdit.Text = CR.Cells["Nombre"].Value.ToString();
                txtApellidoEdit.Text = CR.Cells["Apellido"].Value.ToString();
                ID_Autor = (int)CR.Cells["Id"].Value;
                CargarDropDown();
                CargarListView();
                BtnShow(false);
            }
        }

        private void CargarListView()
        {
            listView1.Items.Clear();
            var Data = DatabaseCon.Instancia.GetData($"Select lb.ISBN as ISBN, lb.Titulo as Titulo from LibrosSet as lb inner join LibroAutorSet on AutorID = {ID_Autor}");
            foreach (DataRow item in Data.Rows)
            {
                ListViewItem itm = new ListViewItem(item.Field<string>("ISBN"));
                itm.SubItems.Add(new ListViewItem.ListViewSubItem(itm, item.Field<string>("Titulo")));
                listView1.Items.Add(itm);
            }
        }

        private void CargarDropDown()
        {

            //comboBox1.Items.Clear();
            comboBox1.DataSource = null;
            comboBox1.ValueMember = null ;
            comboBox1.DisplayMember = null;
            if (ID_Autor == null)
                return;
            string query = $"Select Distinct Lb.ISBN As ISBN, Lb.Titulo as Titulo from LibrosSet as Lb inner join (select * from LibroAutorSet where AutorId <> {ID_Autor}) as LaS on Lb.ISBN = LaS.LibroISBN";
            comboBox1.DataSource = DatabaseCon.Instancia.GetData(query);
            comboBox1.ValueMember = "ISBN";
            comboBox1.DisplayMember = "Titulo";
        }

        public void BtnShow(bool Value)
        {
            //if (txtFlag.Text != "") btnSeleccionar.Visible = !si;
            btnSaveNew.Visible = Value;
            btnClearNew.Visible = Value;
            btnDelete.Visible = !Value;
            btnModificar.Visible = !Value;
            btnCancel.Visible = !Value;
            btnADD.Visible = !Value;

            if (Value == true) this.ActiveControl = txtNombreNew;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtNameEdit.Clear();
            txtApellidoEdit.Clear();
            BtnShow(true);
        }

        private void FrmAutor_Load(object sender, EventArgs e)
        {
            CargarGrid();

        }

        private void CargarGrid()
        {
            string q = "Select A.Id, Nombre, Apellido, Count(lb.Id) as Total_Libros from AutoresSet as A left join LibroAutorSet as lb on A.Id = Lb.Id group by A.Id, Nombre, Apellido";
            var Data = DatabaseCon.Instancia.GetData(q);
            dgvAutores.DataSource = Data;

        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            string Name = txtNombreNew.Text.Trim();
            string LName = txtApellidoNew.Text.Trim();

            DatabaseCon.Instancia.ExecCommand($"Insert into AutoresSet values ( '{Name}', '{LName}')");

            txtApellidoNew.Clear();
            txtNombreNew.Clear();
            CargarGrid();
        }

        private void btnClearNew_Click(object sender, EventArgs e)
        {
            txtApellidoNew.Clear();
            txtNombreNew.Clear();
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count > 0)
            {
                string Val = comboBox1.SelectedValue.ToString();

                DatabaseCon.Instancia.ExecCommand($"Insert into LibroAutorSet values ( '{Val}', {ID_Autor})");
                CargarDropDown();
                CargarListView();
            }

        }
    }
}
