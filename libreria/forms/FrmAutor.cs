using libreria.entidades;
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
            if (CR != null)
            {
                txtApellidoNew.Clear();
                txtNombreNew.Clear();
                txtNameEdit.Text = CR.Cells["Nombre"].Value.ToString();
                txtApellidoEdit.Text = CR.Cells["Apellido"].Value.ToString();
                ID_Autor = (int)CR.Cells["Id"].Value;

                CargarListView();
                BtnShow(false);
            }
        }

        private void CargarListView()
        {
            listView1.Items.Clear();
            var Data = DatabaseCon.Instancia.GetDataByProcedure("spGetLibrosPorAutor",
                new List<SqlParameter>() {
                    new SqlParameter() { ParameterName="@IdAutor", SqlDbType=SqlDbType.Int, Value=ID_Autor}
                });

            foreach (DataRow item in Data.Rows)
            {
                ListViewItem itm = new ListViewItem(item.Field<string>("ISBN"));
                itm.SubItems.Add(new ListViewItem.ListViewSubItem(itm, item.Field<string>("Titulo")));
                listView1.Items.Add(itm);
            }
            
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

        private void Form_Load(object sender, EventArgs e)
        {
            UPDATE.State(this.Name, true); //se the form stated to updated
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
            UPDATE.AllForms(false); //froce others forms to update
        }

        private void btnClearNew_Click(object sender, EventArgs e)
        {
            txtApellidoNew.Clear();
            txtNombreNew.Clear();
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            var Lb = new PopUp.LibroToAutor(ID_Autor);
            Lb.ShowDialog();

            CargarListView();

        }

        // update the form if isn't updated
        private void Form_Enter(object sender, EventArgs e)
        {
            if (!UPDATE.IsUpdated(this.Name)) Form_Load(null, null);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //UPDATE.AllForms(false); //froce others forms to update
        }
    }
}
