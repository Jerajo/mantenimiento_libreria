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
	public partial class PopUpDir : Form
	{
		private string DNI = "";
		private Direccion DirEst = null;
		//public PopUpDir()
		//{
		//    InitializeComponent();
		//}
		public PopUpDir(string DNI)
		{
			InitializeComponent();
			DirEst = Direccion.GetDir(DNI);
			this.DNI = DNI;
		}

		private void PopUpDir_Load(object sender, EventArgs e)
		{
			if(DirEst != null)
			{
				txtCalle.Text = DirEst.Calle;
				txtSec.Text = DirEst.Sector;
				txtPais.Text = DirEst.Pais;
				txtProv.Text = DirEst.Provincia;
				if(!(string.IsNullOrEmpty(txtCalle.Text) && string.IsNullOrEmpty(txtSec.Text) &&
					string.IsNullOrEmpty(txtPais.Text) && string.IsNullOrEmpty(txtProv.Text)))
				{
					btnActualizar.Visible = true;
					btnNuevo.Visible = false;

				}
			}
		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void btnNuevo_Click(object sender, EventArgs e)
		{
			ManageData("I");
		}

		private void ManageData(string v)
		{
			string Cal = txtCalle.Text;
			string Prov = txtProv.Text;
			string Set = txtSec.Text;
			string Pais = txtPais.Text;

			if (string.IsNullOrEmpty(Cal) && string.IsNullOrEmpty(Set) &&
				string.IsNullOrEmpty(Pais) && string.IsNullOrEmpty(Prov))
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
					DatabaseCon.MakeParam("@Calle",SqlDbType.VarChar, Cal),
					DatabaseCon.MakeParam("@Prov",SqlDbType.VarChar, Prov),
					DatabaseCon.MakeParam("@Sect",SqlDbType.VarChar, Set),
					DatabaseCon.MakeParam("@ClientID",SqlDbType.VarChar, DNI),
					DatabaseCon.MakeParam("@Pais",SqlDbType.VarChar, Pais),
				};
				if (v.Equals("I"))
					paramss.Add(DatabaseCon.MakeParam("@Accion", SqlDbType.VarChar, v));
				else if (v.Equals("U"))
					paramss.Add( DatabaseCon.MakeParam("@Accion", SqlDbType.VarChar, v));

				DatabaseCon.Instancia.ExecProcedure(
					"spDirecciones", 
					paramss);
				this.Close();
			}
		}

		private void btnActualizar_Click(object sender, EventArgs e)
		{
			ManageData("U");
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Dispose();
			this.Close();
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
