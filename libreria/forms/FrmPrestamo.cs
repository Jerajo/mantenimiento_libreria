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
    public partial class FrmPrestamo : Form
    {
        private static FrmPrestamo _instance = null;
        private int IDpres = 0;
        private string codLi = "";
        public static FrmPrestamo Instance
        {
            get {
                if (_instance == null)
                    _instance = new FrmPrestamo();
                return _instance;
            }
        }

        private FrmPrestamo()
        {
            InitializeComponent();
            this.Disposed += DisposeData;
        }

        private void DisposeData(object sender, EventArgs e)
        {
            _instance = null;
        }

        //private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        //{
        //    DateTime Now = (sender as DateTimePicker).Value;
        //    dtFin.MinDate = Now.AddDays(2);
        //    dtFin.Value = Now.AddDays(30);
        //}

        private void FrmPrestamo_Load(object sender, EventArgs e)
        {
            PutDatePicker(DateTime.Today);
            FillGrid();
            //FillCbLibros();
            FillCbCliente();

        }

        private void FillCbCliente()
        {
            cbCliente.DataSource = DatabaseCon.Instancia.GetData("select Identificacion as Id,CONCAT(Nombre, ' ', Apellido) as NombreCliente from ClientesSet");
            cbCliente.DisplayMember = "NombreCliente";
            cbCliente.ValueMember = "Id";
        }

        //private void FillCbLibros()
        //{
        //    cbLibros.DataSource = DatabaseCon.Instancia.GetData("select * from vwLibrosFaltantes");
        //    cbLibros.DisplayMember = "Titulo";
        //    cbLibros.ValueMember = "ISBN";
        //}

        private void FillGrid()
        {
            dgvList.DataSource = null;
            dgvList.Columns.Clear();
            var btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Accion";
            btn.Text = "Devolver";
            btn.Name = "btnCol";
            btn.UseColumnTextForButtonValue = true;
            
            string q = "select * from vwVerPrestamos where Estado = 'Pendiente'";
            dgvList.DataSource = DatabaseCon.Instancia.GetData(q);
            dgvList.Columns["Id"].Visible = false;
            dgvList.Columns["DNI"].Visible = false;
            
            dgvList.Columns.Add(btn);
        }

        private void PutDatePicker(DateTime Fecha)
        {
            lbFecha.Text = Fecha.ToShortDateString();
            dtFin.MinDate = Fecha.AddDays(2);
            dtFin.Value = Fecha.AddMonths(1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrnEst.Instance.ShowDialog();
            FillCbCliente();

        }

        private void cbLibros_SelectedIndexChanged(object sender, EventArgs e)
        {
            var val = (sender as ComboBox).SelectedValue.ToString();
            
            FillCbEjemplares(Value: val);

        }

        private void FillCbEjemplares(string Value)
        {
            string q = $"select * from fxTraeEjemplaresDisponibles('{Value}')";
            cbEjemplares.DataSource = DatabaseCon.Instancia.GetData(q);
            cbEjemplares.DisplayMember = "Numero";
            cbEjemplares.ValueMember = "Codigo";
            cbEjemplares.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var pList = new PopUp.LibroDis();
            DialogResult dr = pList.ShowDialog();
            if(dr == DialogResult.OK)
            {
                FillCbEjemplares(Value: pList.ISBNLibroSelected);
            }
            else
                cbEjemplares.Enabled = false;

            pList.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var prestamo = new entidades.Prestamo
            {
                Estado = EstadoP.Pendiente,
                CliDNI = cbCliente.SelectedValue.ToString(),
                CodigoL = cbEjemplares.SelectedValue.ToString(),
                Inicio = DateTime.Parse(lbFecha.Text),
                Fin = dtFin.Value
            };
            entidades.Prestamo.Save(prestamo);
            FillGrid();
            btnClear.PerformClick();
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            var prestamo = new entidades.Prestamo();

            prestamo.ID = IDpres;
            prestamo.CliDNI = cbCliente.SelectedValue.ToString();
            prestamo.CodigoL = codLi;
            prestamo.Inicio = DateTime.Parse(lbFecha.Text);
            prestamo.Fin = dtFin.Value;
                

            prestamo.Update();

            FillGrid();
            btnClear.PerformClick();
        }
        private void btnChanges(bool v)
        {
            
            btnUpd.Visible = v;
            btnGuardar.Visible = !v;

            btnUpd.Enabled = v;
            btnGuardar.Enabled = !v;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            btnChanges(false);
            IDpres = 0;
            cbEjemplares.DataSource = null;
        }

        private void RowClic(object sender, DataGridViewCellEventArgs e)
        {
           
            var cr = (sender as DataGridView).CurrentRow;
            IDpres = (int)cr.Cells["Id"].Value;
            if (e.ColumnIndex == dgvList.Columns["btnCol"].Index)
            {
                if (MessageBox.Show("Desea devolver este libro?", "Devolver Ejemplar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    DatabaseCon.Instancia.ExecCommand(
                        $"Update HistorialPrestamoSet set Estado = {0} where Id = {IDpres}"
                        );
                    FillGrid();
                    btnClear.PerformClick();
                }
            }
            else
            {

                string cod = cr.Cells["ISBN"].Value.ToString();
                codLi = cod + "#" + cr.Cells["Numero_Ejemplar"].Value;
                FillCbEjemplares(cod);
                btnChanges(true);
            }
        }

        private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

    }
}
