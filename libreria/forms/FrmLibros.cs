using Sistema_de_punto_de_ventas.Datos;
using Sistema_de_punto_de_ventas.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        private void From_Load(object sender, EventArgs e)
        {
            try
            {
                //Carga los libros de la db
                DataSet ds = CLibro.GetAll();                
                dt = ds.Tables[0];
                dgvDBR.DataSource = dt;

                //Carga los nombres de las colugnas de la db
                ds = CLibro.GetColumnNames();
                DataView dv = ds.Tables[0].DefaultView;
                cbxFiltrar.DataSource = dv;
                cbxFiltrar.DisplayMember = "Names";

                //Carga las categorias de la db
                ds = CCategoria.GetAll();
                dv = ds.Tables[0].DefaultView;
                cbxGenero.DataSource = dv;
                cbxGenero.ValueMember = "Id";
                cbxGenero.DisplayMember = "Genero";
                

                //Oculta algunos controles al empleado
                //if (txtFlag.Text == "") btnSeleccionar.Visible = false;

                if (dt.Rows.Count > 0) //Muesta u oculta el label de la grilla
                {
                    dgvDBR.ForeColor = Color.Black;
                    dgvDBR.Columns["ISBN"].Width = 200;
                    dgvDBR.Columns["Titulo"].Width = 300;
                    dgvDBR.Columns["CategoriaId"].Visible = false;

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
            try
            {
                string sResultado = validarDatos();
                if (sResultado == "")
                {
                    if (dgvDBR.SelectedRows.Count > 0) //Actualizar registro
                    {//*                        
                        Libro libro = new Libro();
                        libro.ISBN = txtISBN.Text;
                        libro.Titulo = txtTitulo.Text;
                        libro.Editorial = txtEditorial.Text;
                        libro.CategoriaId = Convert.ToInt32(txtIdCategoria.Text);
                        libro.Pais = txtPais.Text;
                        libro.Stock = Convert.ToInt32(txtStock.Text);
                        
                        if (CLibro.Actualizar(libro) > 0)
                        {
                            MessageBox.Show("Datos Actualizados Correctamente");
                            From_Load(null, null);
                        }//*/MessageBox.Show("Actualizado " + dgvDBR.CurrentRow);
                    }
                    else //Nuevo registro
                    {//*                        
                        Libro libro = new Libro();
                        libro.ISBN = txtISBN.Text;
                        libro.Titulo = txtTitulo.Text;
                        libro.Editorial = txtEditorial.Text;
                        libro.CategoriaId = Convert.ToInt32(txtIdCategoria.Text);
                        libro.Pais = txtPais.Text;
                        libro.Stock = Convert.ToInt32(txtStock.Text);

                        int n = CLibro.Insertar(libro);
                        MessageBox.Show("Resultado: " + System.Convert.ToString(n));
                        if (n > 0)
                        {
                            MessageBox.Show("Datos Insertados Correctamente");
                            From_Load(null, null);
                        }//*/MessageBox.Show("Insertado");
                    }
                }
                else
                {
                    MessageBox.Show("Faltan datos en: \n" + sResultado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public string validarDatos()
        {
            string resultado = "";
            if (txtTitulo.Text == "") resultado += "El campo: Titulo.\n";
            if (txtEditorial.Text == "") resultado += "El campo: Editorial.\n";
            if (txtIdCategoria.Text == "") resultado += "El campo: Categoria.\n";
            if (txtPais.Text == "") resultado += "El campo: Pais.\n";
            else if ((txtStock.Text == "" || txtStock.Text == "0") &&
                txtStock.Text != dgvDBR.CurrentRow.Cells["Stock"].Value.ToString())
            {
                if (CLibro.VerificarStock(Convert.ToInt32(txtStock.Text)) > 0)
                    resultado += "El campo: Stock,\n (Stock ya existe) \n";
            }
            return resultado;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MostrarBotonesOcultos(true);
            txtISBN.Text = "";
            txtTitulo.Text = "";
            txtEditorial.Text = "";
            txtIdCategoria.Text = "";
            cbxGenero.Text = "";
            txtPais.Text = "";
            txtStock.Text = "";
            //Disable DataGriView
            dgvDBR.ClearSelection();
            dgvDBR.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            MostrarBotonesOcultos(true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MostrarBotonesOcultos(false);
            dgvDBR_CellClick(null, null);
            if (dgvDBR.SelectedRows.Count == 0) dgvDBR.Rows[0].Selected = true;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            dgvDBR_CellContentDoubleClick(null, null);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add Categoria");
        }

        private void cbxGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdCategoria.Text = cbxGenero.SelectedValue.ToString();
        }

        public void MostrarBotonesOcultos(bool si)
        {
            //if (txtFlag.Text != "") btnSeleccionar.Visible = !si;
            btnGuardar.Visible = si;
            btnCancelar.Visible = si;
            btnNuevo.Visible = !si;
            btnEditar.Visible = !si;
            dgvDBR.Enabled = !si;
            //Revertir cambios
            txtISBN.Enabled = si;
            txtTitulo.Enabled = si;
            txtEditorial.Enabled = si;
            cbxGenero.Enabled = si;
            txtPais.Enabled = si;
            txtStock.Enabled = si;

            if (si == true) this.ActiveControl = txtISBN;
        }

        private void dgvDBR_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDBR.CurrentRow != null) //Pasa los datos del datagriview a los textbox
            {
                txtISBN.Text = dgvDBR.CurrentRow.Cells["ISBN"].Value.ToString();
                txtTitulo.Text = dgvDBR.CurrentRow.Cells["Titulo"].Value.ToString();
                txtIdCategoria.Text = dgvDBR.CurrentRow.Cells["CategoriaId"].Value.ToString();
                cbxGenero.Text = dgvDBR.CurrentRow.Cells["Genero"].Value.ToString();
                txtEditorial.Text = dgvDBR.CurrentRow.Cells["Editorial"].Value.ToString();         
                txtPais.Text = dgvDBR.CurrentRow.Cells["Pais"].Value.ToString();
                txtStock.Text = dgvDBR.CurrentRow.Cells["Stock"].Value.ToString();
            }
        }

        private void dgvDBR_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDBR.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar =
                    (DataGridViewCheckBoxCell)dgvDBR.Rows[e.RowIndex].Cells["Eliminar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);                
            }
            btnEliminar.Visible = verificarFilasSeleccionada();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Desea eliminar los registros seleccionados?", "Eliminacion de Libro",
                   MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    foreach (DataGridViewRow row in dgvDBR.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Eliminar"].Value))
                        {
                            Libro libro = new Libro();
                            libro.ISBN = Convert.ToString(row.Cells["ISBN"].Value);
                            if (CLibro.Eliminar(libro) != 1)
                            {
                                MessageBox.Show("EL cliene no pudo ser eliminado", "Eliminacion de Libro",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    From_Load(null, null);
                }
                else if (!verificarFilasSeleccionada()) MessageBox.Show("Debe selecionar un Registro primero",
                  "Eliminacion de Registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private bool verificarFilasSeleccionada()
        {
            foreach (DataGridViewRow rows in dgvDBR.Rows)
            {
                if (Convert.ToBoolean(rows.Cells["Eliminar"].Value))
                {
                    return true;
                }
            }
            return false;
        }

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataView dv = new DataView(dt.Copy());
                if (cbxFiltrar.Text != "Stock" && cbxFiltrar.Text != "CategoriaId")
                {
                    dv.RowFilter = cbxFiltrar.Text + " LIKE '" + txtFiltrar.Text + "%'";
                }
                else if (txtFiltrar.Text != "")
                {
                    dv.RowFilter = cbxFiltrar.Text + " >= " + txtFiltrar.Text;
                }
                dgvDBR.DataSource = dv;
                lblDatosNoEncontrados.Visible = (dv.Count == 0) ? true : false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dgvDBR_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            /*if (ActiveControl is TextBox)
            {
                switch (this.ActiveControl.Name)
                {
                    case "txtNombre":
                        if (this.ActiveControl.Text == "") lblNombre.Visible = true;
                        else lblNombre.Visible = false;
                        break;
                    case "txtApellido":
                        if (this.ActiveControl.Text == "") lblApellido.Visible = true;
                        else lblApellido.Visible = false;
                        break;
                    case "txtDNI":
                        if (this.ActiveControl.Text == "") lblDNI.Visible = true;
                        else lblDNI.Visible = false;
                        break;
                }
            }*/
        }

        private void txt_KeyPress_Only_Numbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void txt_KeyPress_Direcciones(object sender, KeyPressEventArgs e)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ()-_.,#]*$");
            if (!regexItem.IsMatch(Convert.ToString(e.KeyChar)) && !(e.KeyChar == '\b')) e.Handled = true;
        }        
    }
}
