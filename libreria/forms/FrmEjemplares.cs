using libreria.conexión;
using libreria.entidades;
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
    public partial class FrmEjemplares : Form
    {
        private static DataTable dt = new DataTable();
        private static DataSet DS;
        private FrmEjemplares()
        {
            InitializeComponent();
            DS = DatabaseCon.Instancia.GetColumnNames("[dbo].[LibroEjemplarSet]");
        }

        private void Form_Load(object sender, EventArgs e)
        {
            UPDATE.State(this.Name, true);
            try
            {
                //carga los ejemplares al datagrivew
                string tabla = "[dbo].[LibroEjemplarSet]", campos = "Codigo, LibroISBN AS ISBN, Numero";                                
                dt = DatabaseCon.Instancia.GetData($"Select {campos} from {tabla}");
                dgvDBR.DataSource = dt;

                //carga los ISBN al combobox
                campos = "LibroISBN";
                DataTable d = DatabaseCon.Instancia.GetData($"Select {campos} AS ISBN from {tabla} group by {campos}");
                cbxISBN.DataSource = d;
                cbxISBN.DisplayMember = "ISBN";

                if (dt.Rows.Count > 0)
                {
                    dgvDBR.ForeColor = Color.Black;
                    dgvDBR.Columns["ISBN"].Width = 200;

                    lblDatosNoEncontrados.Visible = false;
                    dgvDBR_CellClick(null, null);
                }
                else lblDatosNoEncontrados.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            MostrarBotonesOcultos(false);
            verificarFilasSeleccionada();
        }

        private static FrmEjemplares _instancia = null;
        public static FrmEjemplares GetInstance()
        {
            if (_instancia == null) _instancia = new FrmEjemplares();
            return _instancia;
        }
        private void FrmEjemplares_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }        

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string sResultado = validarDatos();
                Ejemplares ej = new Ejemplares(txtCodigo.Text, cbxISBN.Text, nudNumero.Value);
                if (sResultado == "")
                {
                    if (dgvDBR.SelectedRows.Count > 0) //Actualizar registro
                    {
                        var oldN = System.Convert.ToInt32(dgvDBR.CurrentRow.Cells["Numero"].Value);
                        if (CEjemplares.Actualizar(ej, oldN) > 0)
                        {
                            MessageBox.Show("Datos Actualizados Correctamente");
                            UPDATE.AllForms(false);
                            Form_Load(null, null);
                        }
                        else MessageBox.Show("Datos no insertados");
                    }
                    else //Nuevo registro
                    {
                        if (CEjemplares.Insertar(ej) > 0)
                        {
                            MessageBox.Show("Datos Insertados Correctamente");
                            UPDATE.AllForms(false);
                            Form_Load(null, null);
                        }
                        else MessageBox.Show("Datos no insertados");
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

        private string validarDatos()
        {
            string resultado = "";
            bool found = false;
            if (txtCodigo.Text == "") resultado += "El campo: Codigo.\n";
            if (cbxISBN.Text == "") resultado += "El campo: ISBN.\n";
            string[] campos = { "Numero", "LibroISBN" };
            string[] valores = { nudNumero.Text, cbxISBN.Text };
            resultado += DatabaseCon.Instancia.VerificarSiExiste("[dbo].[LibroEjemplarSet]", campos, valores);
            foreach(DataRowView iten in cbxISBN.Items)
            {
                if (cbxISBN.Text != iten.Row[0].ToString()) continue;
                    //resultado += $"-{cbxISBN.Text} != {iten.Row[0].ToString()}-\n";
                found = true;
                break;
            }
            if (!found) resultado += "ISBN no encontrado.\n";
            return resultado;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MostrarBotonesOcultos(false);
            dgvDBR_CellClick(null, null);
            if (dgvDBR.SelectedRows.Count == 0) dgvDBR.Rows[0].Selected = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MostrarBotonesOcultos(true);
            cbxISBN.Text = "";
            txtCodigo.Clear();
            nudNumero.Refresh();
            cbxISBN.Enabled = true;
            //Disable DataGriView
            dgvDBR.ClearSelection();
            dgvDBR.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            MostrarBotonesOcultos(true);
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
            nudNumero.Enabled = si;
            if (cbxISBN.Enabled) cbxISBN.Enabled = false;
            if (si == true) this.ActiveControl = nudNumero;
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
                            string code = txtCodigo.Text;
                            string isbn = cbxISBN.Text;
                            DatabaseCon.Instancia.ExecCommand($"delete from [dbo].[LibroEjemplarSet] where Codigo='{code}'");
                            DatabaseCon.Instancia.ExecCommand($"update [dbo].[LibrosSet] set Stock=(Stock-1) where ISBN='{isbn}'");
                            MessageBox.Show("Registro Eliminado Correctamente");
                            UPDATE.AllForms(false); //froce others forms to update
                        }
                    }
                    Form_Load(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void verificarFilasSeleccionada()
        {
            bool value = false;
            foreach (DataGridViewRow rows in dgvDBR.Rows)
            {
                if (Convert.ToBoolean(rows.Cells["Eliminar"].Value))
                {
                    value = true;
                }
            }
            btnEliminar.Enabled = value;
            btnEditar.Enabled = btnNuevo.Enabled = !value;
            btnEliminar.BackColor = (value) ? Color.Red : Color.Gray;
            btnEditar.BackColor = (!value) ? Color.Turquoise : Color.Gray;
            btnNuevo.BackColor = (!value) ? Color.LawnGreen : Color.Gray;
        }

        private void dgvDBR_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDBR.CurrentRow != null) //Pasa los datos del datagriview a los textbox
            {
                txtCodigo.Text = dgvDBR.CurrentRow.Cells["Codigo"].Value.ToString();
                cbxISBN.Text = dgvDBR.CurrentRow.Cells["ISBN"].Value.ToString();                
                nudNumero.Text = dgvDBR.CurrentRow.Cells["Numero"].Value.ToString();
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
            verificarFilasSeleccionada();
        }

        private void generateCode(object sender, EventArgs e)
        {
            txtCodigo.Text =  String.Concat(cbxISBN.Text, '#', nudNumero.Value);
        }

        private void Form_Enter(object sender, EventArgs e)
        {
            if (!UPDATE.IsUpdated(this.Name)) Form_Load(null, null);
        }
    }
}
