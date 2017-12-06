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
    public partial class FrmPrestamo : Form
    {
        private static FrmPrestamo _instance = null;

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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime Now = (sender as DateTimePicker).Value;
            dtFin.MinDate = Now.AddDays(2);
            dtFin.Value = Now.AddDays(30);
        }

        private void FrmPrestamo_Load(object sender, EventArgs e)
        {
            PutDatePicker(DateTime.Today);
            FillGrid();
            FillCbLibros();
            FillCbCliente();

        }

        private void FillCbCliente()
        {
            cbCliente.Items.Insert(0, new { id = 0, NombreCliente = "Default" });
            cbCliente.DataSource = DatabaseCon.Instancia.GetData("select Identificacion as Id,CONCAT(Nombre, ' ', Apellido) as NombreCliente from ClientesSet");
            cbCliente.DisplayMember = "NombreCliente";
            cbCliente.ValueMember = "Id";
            cbCliente.SelectedIndex = 0;
        }

        private void FillCbLibros()
        {
            cbLibros.DataSource = DatabaseCon.Instancia.GetData("select * from vwLibrosFaltantes");
            cbLibros.DisplayMember = "Titulo";
            cbLibros.ValueMember = "ISBN";
        }

        private void FillGrid()
        {
            string q = "select * from vwVerPrestamos ";
            dgvList.DataSource = DatabaseCon.Instancia.GetData(q);
            dgvList.Columns["Id"].Visible = false;
        }

        private void PutDatePicker(DateTime Fecha)
        {
            dtPicker1.MinDate = Fecha.AddMonths(-1);
            dtFin.MinDate = Fecha.AddDays(2);
            dtFin.Value = Fecha.AddDays(30);
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
    }
}
