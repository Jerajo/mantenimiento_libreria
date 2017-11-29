using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webLibreria.Mantenimientos
{
    public partial class Genero : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                FillDataGrid();
        }

        protected void Listado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FillDataGrid()
        {
            Listado.DataSource = DatabaseCon.Instancia.GetData("select * from vwGenerosLibrosCount");
            Listado.DataBind();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string Name = txtGenero.Text;
            if (string.IsNullOrEmpty(Name))
                return;

            DatabaseCon.Instancia.ExecProcedure(
                "spNewGenero",
                new List<SqlParameter>() { new SqlParameter() { SqlDbType = SqlDbType.NVarChar, ParameterName = "@Name", Value = Name } }
                );
            txtGenero.Text = string.Empty;
            FillDataGrid();
        }

        protected void Update(object sender, GridViewUpdateEventArgs e)
        {
            var rowD = Listado.Rows[e.RowIndex];
            string name = (rowD.FindControl("txtName") as TextBox).Text;
            int idValue = Convert.ToInt32(Listado.DataKeys[e.RowIndex].Values[0]);
            DatabaseCon.Instancia.ExecProcedure("spUpdateGenre", new List<SqlParameter>() {
                new SqlParameter(){ DbType = DbType.Int32 , Value = idValue, ParameterName = "@id"},
                new SqlParameter(){ SqlDbType = SqlDbType.NVarChar , Value = name, ParameterName = "@Name"}
            });
            Listado.EditIndex = -1;
            FillDataGrid();
        }

        protected void Listado_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Listado.EditIndex = e.NewEditIndex;
            this.FillDataGrid();
        }

        protected void Listado_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Listado.EditIndex = -1;
            FillDataGrid();
        }

        protected void Delete(object sender, GridViewDeleteEventArgs e)
        {

            int idValue = Convert.ToInt32(Listado.DataKeys[e.RowIndex].Values[0]);
            DatabaseCon.Instancia.ExecProcedure(
                "spDeleteGenero",
                new List<SqlParameter>() { new SqlParameter() { ParameterName = "@ID", SqlDbType = SqlDbType.Int, Value = idValue } }
                );
            FillDataGrid();
        }

        protected void Listado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != Listado.EditIndex)
            {
                (e.Row.Cells[3].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }
    }
}