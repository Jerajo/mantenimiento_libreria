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



        public int ID = 0;
        private Generos()
        {
            InitializeComponent();
            this.Disposed += Generos_Disposed;
        }

        private void Generos_Disposed(object sender, EventArgs e)
        {
            _instance = null;         
        }

        private void Generos_Load(object sender, EventArgs e)
        {
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            Listado1.DataSource = DatabaseCon.Instancia.GetData("select * from vwGenerosLibrosCount");
            
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Listado1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var idd = Listado1.CurrentCell.RowIndex;
            var row = Listado1.Rows[idd].Cells[1].Value.ToString();
            //txtEdit.Text = Listado1.Rows[idd].Cells["Genero"].Value.ToString();
            txtEdit.Text = row;
            Int32.TryParse(Listado1.Rows[idd].Cells[0].Value.ToString(), out ID);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DatabaseCon.Instancia.ExecProcedure("spUpdateGenre", new List<SqlParameter>() {
                new SqlParameter(){ DbType = DbType.Int32 , Value = ID, ParameterName = "@id"},
                new SqlParameter(){ SqlDbType = SqlDbType.NVarChar , Value = txtEdit.Text.Trim(), ParameterName = "@Name"}
            });
            
            FillDataGrid();
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
        }

        private void Listado1_SelectionChanged(object sender, EventArgs e)
        {
            var idRow = (sender as DataGridView).CurrentRow.Index;
            string ss = Listado1.Rows[idRow].Cells["Genero"].Value.ToString();
            txtEdit.Text = ss;
            int.TryParse(Listado1.Rows[idRow].Cells["Id"].Value.ToString(), out ID);
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
    }
}
