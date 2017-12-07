using libreria.entidades;
using libreria.forms;
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

namespace libreria.Mantenimientos
{
    public partial class Generos : Form
    {
        private static Generos _instance;

        public static Generos Instancia

        {
            get {
                if (_instance == null)
                    _instance = new Generos();

                return _instance;
            }
        }

        public bool Flag { get => _flag; set => _flag = value; }

        public int ID = 0;
        private static bool _flag = false;

        private Generos()
        {
            InitializeComponent();
            this.Disposed += Generos_Disposed;
        }

        private void Generos_Disposed(object sender, EventArgs e)
        {
            _instance = null;         
        }

        private void Form_Load(object sender, EventArgs e)
        {
            FillDataGrid();
            UPDATE.State(this.Name, true); //se the form stated to updated
        }

        private void FillDataGrid()
        {
            Listado1.DataSource = DatabaseCon.Instancia.GetData("select * from vwGenerosLibrosCount");
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DatabaseCon.Instancia.ExecProcedure("spUpdateGenre", new List<SqlParameter>() {
                new SqlParameter(){ DbType = DbType.Int32 , Value = ID, ParameterName = "@id"},
                new SqlParameter(){ SqlDbType = SqlDbType.NVarChar , Value = txtEdit.Text.Trim(), ParameterName = "@Name"}
            });
            
            FillDataGrid();
            UPDATE.AllForms(false); //froce others forms to update
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var text = txtNew.Text.Trim();
            if (string.IsNullOrEmpty(text))
                return;

            DatabaseCon.Instancia.ExecProcedure(
                "spNewGenero",
                new List<SqlParameter>() { new SqlParameter() { SqlDbType = SqlDbType.NVarChar, ParameterName = "@Name", Value = text } }
                );
            txtNew.Clear();
            FillDataGrid();
            UPDATE.AllForms(false); //froce others forms to update
        }        

        private void t_Click(object sender, EventArgs e)
        {
            var text = t.Text.Trim();
            if (string.IsNullOrEmpty(text))
                return;

            DatabaseCon.Instancia.ExecProcedure(
                "spDeleteGenero",
                new List<SqlParameter>() { new SqlParameter() { ParameterName = "@ID", SqlDbType = SqlDbType.Int, Value = ID } }
                );
            txtEdit.Clear();
            FillDataGrid();
        }

        // update the form if isn't updated
        private void Form_Enter(object sender, EventArgs e)
        {
            if (!UPDATE.IsUpdated(this.Name)) Form_Load(null, null);
        }

        private void Listado1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Flag)
            {
                var fl = FrmLibros.GetInstance();
                if (Listado1.CurrentRow != null)
                {
                    string genero = Listado1.CurrentRow.Cells["Genero"].Value.ToString();
                    fl.RefreshData();
                    fl.SetGenero(genero);
                    Close();
                }
            }
        }

        private void Listado1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var idd = Listado1.CurrentCell.RowIndex;
            var row = Listado1.Rows[idd].Cells[1].Value.ToString();
            //txtEdit.Text = Listado1.Rows[idd].Cells["Genero"].Value.ToString();
            txtEdit.Text = row;
            Int32.TryParse(Listado1.Rows[idd].Cells[0].Value.ToString(), out ID);
        }

        private void Listado1_SelectionChanged(object sender, EventArgs e)
        {
            var idRow = (sender as DataGridView).CurrentRow.Index;
            string ss = Listado1.Rows[idRow].Cells["Genero"].Value.ToString();
            txtEdit.Text = ss;
            int.TryParse(Listado1.Rows[idRow].Cells["Id"].Value.ToString(), out ID);
        }

        private void Generos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Flag = false;
        }
    }
}
