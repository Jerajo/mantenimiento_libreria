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
    public partial class Usuarios : Form
    {
        private static Usuarios _instance = null;
        private static DataTable dt = new DataTable();
        public Usuarios()
        {
            InitializeComponent();
        }

        public static Usuarios Instance
        {
            get
            {
                if (_instance == null) _instance = new Usuarios();
                return _instance;
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                //carga los usuarios al datagrivew
                dt = DatabaseCon.Instancia.GetData($"Select * from [dbo].[CredencialesSet]");
                dgvDBR.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    dgvDBR.ForeColor = Color.Black;
                    dgvDBR.Columns["Codigo"].Visible = false;
                    dgvDBR.Columns["Password"].Visible = false;                    
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

        private void Usuarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {                
                CUsuario usr = new CUsuario(Convert.ToInt32(txtCodigo.Text), txtNombre.Text,
                    txtNPassword1.Text);
                string sResultado = validarDatos(usr);
                if (sResultado == "")
                {
                    if (dgvDBR.SelectedRows.Count > 0) //Actualizar registro
                    {
                        var oldN = System.Convert.ToInt32(dgvDBR.CurrentRow.Cells["Numero"].Value);
                        if (usr.Actualizar())
                        {
                            MessageBox.Show("Datos Actualizados Correctamente");
                            Form_Load(null, null);
                        }
                        else MessageBox.Show("Datos no insertados");
                    }
                    else //Nuevo registro
                    {
                        if (usr.Insertar())
                        {
                            MessageBox.Show("Datos Insertados Correctamente");
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

        private string validarDatos(CUsuario urs)
        {
            string resultado = "";
            if (txtNombre.Text == "") resultado += "El campo: Nombre.\n";
            if (txtOPassword.Text == "") resultado += "El campo: Old Password.\n";
            if (txtNPassword1.Text == "") resultado += "El campo: New Password 1.\n";
            if (txtNPassword2.Text == "") resultado += "El campo: New Password 2.\n";
            if (txtNPassword1.Text != txtNPassword2.Text) resultado += "Contraseñas no coinsiden.\n";
            resultado += urs.ValidarUsuario();
            return resultado;
        }

        private void MostrarBotonesOcultos(bool si)
        {            
            btnGuardar.Visible = si;
            btnCancelar.Visible = si;
            btnNuevo.Visible = !si;
            btnEditar.Visible = !si;
            dgvDBR.Enabled = !si;
            //Revertir cambios            
            txtNombre.Enabled = si;
            txtOPassword.Enabled = si;
            txtNPassword1.Enabled = si;
            txtNPassword2.Enabled = si;
            if (si == true) this.ActiveControl = txtNombre;
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
            txtNombre.Clear();
            txtOPassword.Clear();
            txtNPassword1.Clear();
            txtNPassword2.Clear();
            //Disable DataGriView
            dgvDBR.ClearSelection();
            dgvDBR.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            MostrarBotonesOcultos(true);
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
                            DatabaseCon.Instancia.ExecCommand($"delete from [dbo].[CredencialesSet] where Codigo='{code}'");                            
                            MessageBox.Show("Registro Eliminado Correctamente");
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
                txtNombre.Text = dgvDBR.CurrentRow.Cells["Nombre"].Value.ToString();
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
    }
}
