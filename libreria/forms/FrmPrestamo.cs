using libreria.Busquedas;
using libreria.entidades;
using libreria.Mantenimientos;
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
        private string[] _dataLibro = new string[2];

        public static FrmPrestamo Instance
        {
            get {
                if (_instance == null)
                    _instance = new FrmPrestamo();
                return _instance;
            }
        }

        public string[] DataLibro
        {
            get => _dataLibro;
            set {
                _dataLibro = value;
                FillCbEjemplares(_dataLibro[0]);
                txtTitulo.Text = _dataLibro[1];
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

        private void Form_Load(object sender, EventArgs e)
        {
            PutDatePicker(DateTime.Today);
            FillGrid();
            FillCbLibros();
            FillCbCliente();
            UPDATE.State(this.Name, true); //se the form stated to updated
        }

        public void FillCbCliente()
        {
            //cbCliente.Items.Insert(0, new { id = 0, NombreCliente = "Default" });
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrnEst.Instance.ShowDialog();
            FillCbCliente();
        }

        private void btnFL_Click(object sender, EventArgs e)
        {
            var fbl = SchLibros.Instancia;
            fbl.Flag = true;
            fbl.ShowDialog();
        }

        private void cbLibros_SelectedIndexChanged(object sender, EventArgs e)
        {
            var val = (sender as ComboBox).SelectedValue.ToString();            
            FillCbEjemplares(Value: val);
        }

        private void FillCbEjemplares(string Value)
        {
            //string q = $"select * from fxTraeEjemplaresDisponibles('{Value}')";
            string q = $"select * from [dbo].[LibroEjemplarSet] where LibroISBN='{Value}'";
            cbEjemplares.DataSource = DatabaseCon.Instancia.GetData(q);
            cbEjemplares.DisplayMember = "Numero";
            cbEjemplares.ValueMember = "Codigo";
            cbEjemplares.Enabled = true;
        }

        // update the form if isn't updated
        private void Form_Enter(object sender, EventArgs e)
        {
            if (!UPDATE.IsUpdated(this.Name)) Form_Load(null, null);
        }

        private void btnPrestar_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
