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
	public partial class FrnEst : Form
	{
		private static FrnEst _form;


		private void DisposedObject(object sender, EventArgs e)
		{
			_form = null;
		}

		public static FrnEst Instance
		{
			get
			{
				if (_form == null)
					_form = new FrnEst();
				return _form;
			}
		}
		private FrnEst()
		{
			InitializeComponent();
			this.Disposed += DisposedObject;
		}

		private void FrnEst_Load(object sender, EventArgs e)
		{
			DataGridLoad();
		}

		private void DataGridLoad()
		{
			var d = DatabaseCon.Instancia.GetData("select * from ClientesSet");
			dgvData.DataSource = d;

		}

		private void btnDir_Click(object sender, EventArgs e)
		{
			var dni = txtIde.Text;
			var p = new PopUp.PopUpDir(dni);
			p.ShowDialog();

		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			btnChanges(false);
			txtIde.Text = string.Empty;
			txtName.Text = string.Empty;
			txtApe.Text = string.Empty;
			txtCor.Text = string.Empty;
			txtPhone.Text = string.Empty;
		}

		private void Actualizar(object sender, EventArgs e)
		{
			ManageData("U");
			DataGridLoad();
		}

		private void Guardar(object sender, EventArgs e)
		{

			ManageData("I");
			DataGridLoad();
		}

		private void SelectRow(object sender, DataGridViewCellEventArgs e)
		{
			if(dgvData.CurrentRow != null) { 
			btnChanges(true);
			var cr = dgvData.CurrentRow;
			txtIde.Text = cr.Cells["Identificacion"].Value.ToString();
			txtName.Text = cr.Cells["Nombre"].Value.ToString();
			txtApe.Text = cr.Cells["Apellido"].Value.ToString();
			txtCor.Text = cr.Cells["Correo"].Value.ToString();
			txtPhone.Text = cr.Cells["Telefono"].Value.ToString();
			}
		}

		/// <summary>
		/// Cambio de Estados
		/// </summary>
		/// <param name="v">Verdadero para Botones Secundarios</param>
		private void btnChanges(bool v)
		{
			txtIde.Enabled = !v;
			btnActualizar.Visible = v;
			btnDir.Visible = v;
			btnSave.Visible = !v;

			btnActualizar.Enabled = v;
			btnDir.Enabled = v;
			btnSave.Enabled = !v;
		}
		private void ManageData(string v)
		{
			string Id = txtIde.Text;
			string Nombre = txtName.Text;
			string Apel = txtApe.Text;
			string Tel = txtPhone.Text;
			string Cor = txtCor.Text;

			if (!Utiliy.IsValidEmail(Cor))
			{
				MessageBox.Show("Utilize un Correo Completo");
				return;
			}

			if (string.IsNullOrEmpty(Id) && string.IsNullOrEmpty(Apel) &&
				txtPhone.MaskFull && string.IsNullOrEmpty(Nombre) )
			{
				MessageBox.Show("Llene todo los Campos");
			}
			else
			{
				/*
				 * 	@Calle varchar(25) = '',
					@Prov varchar(25) = '',
					@Sect varchar(25) = '',
					@Pais varchar(25) = '',
					@ClientID varchar(25) = '',
					@Accion varchar(25) = 'I'
				 */
				List<SqlParameter> paramss = new List<SqlParameter>()
				{
					DatabaseCon.MakeParam("@IDE",SqlDbType.VarChar, Id),
					DatabaseCon.MakeParam("@Name",SqlDbType.VarChar, Nombre),
					DatabaseCon.MakeParam("@Ape",SqlDbType.VarChar, Apel),
					DatabaseCon.MakeParam("@Tel",SqlDbType.VarChar, Tel),
					DatabaseCon.MakeParam("@Cor",SqlDbType.VarChar, Cor),
				};
				if (v.Equals("I"))
					paramss.Add(DatabaseCon.MakeParam("@Accion", SqlDbType.VarChar, v));
				else if (v.Equals("U"))
					paramss.Add(DatabaseCon.MakeParam("@Accion", SqlDbType.VarChar, v));

				DatabaseCon.Instancia.ExecProcedure(
					"spEstudiantes",
					paramss);
			}
		}

	}
}
