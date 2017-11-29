using Sistema_de_punto_de_ventas.Datos;
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
    public partial class FrmLibros : Form
    {
        private static DataTable dt = new DataTable();
        public FrmLibros()
        {
            InitializeComponent();
        }

        private void Libros_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = CLibros.GetAll();
                dt = ds.Tables[0];
                dgvDBR.DataSource = dt;                

                //Oculta algunos controles al empleado
                //if (txtFlag.Text == "") btnSeleccionar.Visible = false;

                if (dt.Rows.Count > 0) //Muesta u oculta el label de la grilla
                {
                    dgvDBR.ForeColor = Color.Black;
                    dgvDBR.Columns["ISBN"].Width = 200;
                    dgvDBR.Columns["Titulo"].Width = 300;
                    dgvDBR.Columns["Categoria_Id"].Visible = false;

                    lblDatosNoEncontrados.Visible = false;
                    dgvDBR_CellClick(null, null);
                }
                else lblDatosNoEncontrados.Visible = true;

                MostrarBotonesOcultos(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aceptar");
            MostrarBotonesOcultos(false);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nuevo");
            MostrarBotonesOcultos(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Editar");
            MostrarBotonesOcultos(true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cancelar");
            MostrarBotonesOcultos(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Eliminar");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Buscar");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Agregar");
        }

        public void MostrarBotonesOcultos(bool si)
        {
            //if (txtFlag.Text != "") btnSeleccionar.Visible = !si;
            btnGuardar.Visible = si;
            btnCancelar.Visible = si;
            btnNuevo.Visible = !si;
            dgvDBR.Enabled = !si;
            btnEliminar.Visible = !si;
            //Revertir cambios
            txtTitulo.Enabled = si;
            txtEditorial.Enabled = si;
            txtIdCategoria.Enabled = si;
            cbxGenero.Enabled = si;
            txtPais.Enabled = si;
            txtStock.Enabled = si;

            if (si == true) this.ActiveControl = txtTitulo;
        }

        private void dgvDBR_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDBR.CurrentRow != null) //Pasa los datos del datagriview a los textbox
            {
                txtISBN.Text = dgvDBR.CurrentRow.Cells["ISBN"].Value.ToString();
                txtTitulo.Text = dgvDBR.CurrentRow.Cells["Titulo"].Value.ToString();
                txtIdCategoria.Text = dgvDBR.CurrentRow.Cells["Categoria_Id"].Value.ToString();
                cbxGenero.Text = dgvDBR.CurrentRow.Cells["Genero"].Value.ToString();
                txtEditorial.Text = dgvDBR.CurrentRow.Cells["Editorial"].Value.ToString();         
                txtPais.Text = dgvDBR.CurrentRow.Cells["Pais"].Value.ToString();
                txtStock.Text = dgvDBR.CurrentRow.Cells["Stock"].Value.ToString();
            }
        }
    }
}
