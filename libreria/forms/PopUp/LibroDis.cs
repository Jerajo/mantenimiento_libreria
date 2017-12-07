using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libreria.forms.PopUp
{
    public partial class LibroDis : Form
    {
        private string _isbn;
        private DataTable dt;

        public string ISBNLibroSelected
        {
            get { return _isbn; }
        }

        public LibroDis()
        {
            InitializeComponent();
        }

        private void LibroDis_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            dt = new DataTable();
            dt = DatabaseCon.Instancia.GetData("select * from vwLibrosFaltantes");
            dgvLista.DataSource = dt;
            dgvLista.Columns["ISBN"].Visible = false;
        }

        private void dgvLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = (sender as DataGridView).CurrentRow;
            _isbn = row.Cells["ISBN"].Value.ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataView dv = new DataView(dt.Copy())
                {
                    RowFilter = $" Titulo like '%{txtFiltro.Text}%'"
                };

                dgvLista.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
