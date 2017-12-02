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

namespace libreria.forms.PopUp
{
    public partial class LibroToAutor : Form
    {
        private int? Id_Autor;
        private LibroToAutor()
        {
        }

        public LibroToAutor(int? iD_Autor)
        {
            this.Id_Autor = iD_Autor;
            InitializeComponent();

        }

        private void LibroToAutor_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void PopulateGrid()
        {
            if (Id_Autor.HasValue)
            {
                listado.DataSource = DatabaseCon.Instancia.GetDataByProcedure("spGetLibrosSinAutor",
                    new List<SqlParameter>() {
                    new SqlParameter() {ParameterName="@IdAutor", SqlDbType=SqlDbType.Int, Value=Id_Autor }

                    });
                var total = listado.Width;
                listado.Columns["ISBN"].Width = 130;
                listado.Columns["Titulo"].Width = total - 170;

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ClickRow(object sender, DataGridViewCellEventArgs e)
        {
            var CR = listado.CurrentRow;
            if (CR != null)
            {
                btnAgregar.Visible = true;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (listado.SelectedRows.Count == 1)
            {
                var data = listado.CurrentRow.Cells["ISBN"].Value.ToString();

                DatabaseCon.Instancia.ExecCommand($"INSERT into LibroAutorSet values ('{data}',{Id_Autor})");

                this.Dispose();
            }
        }
    }
}
