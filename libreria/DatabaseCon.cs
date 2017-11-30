using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

public class DatabaseCon
{
	
	private static DatabaseCon _Instance;
	private SqlConnection Connection;

	public static DatabaseCon Instancia
	{
		get {
			if (_Instance == null)
				_Instance = new DatabaseCon();
			return _Instance;
		}

	}


	private DatabaseCon()
	{
		Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LibreriaHCConnectionString"].ConnectionString);

	}

	/// <summary>
	/// Devuelte datos en forma de <see cref="DataTable"/> mediante una <paramref name="query"/>
	/// </summary>
	/// <param name="query">Comando de busqueda</param>
	/// <returns></returns>
	public DataTable GetData(string query)
	{

		DataTable result = new DataTable();
		SqlCommand comando = new SqlCommand(query, Connection);

		SqlDataAdapter filler = new SqlDataAdapter();
		filler.SelectCommand = comando;
		
		try
		{
			Connection.Open();
			filler.Fill(result);
			Connection.Close();
		}
		catch (Exception ex)
		{

			MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
		}

		return result;
	}

	/// <summary>
	/// Trae datos de la Base de datos mediante Parametros
	/// </summary>
	/// <param name="procedure">nombre del STORED PROCEDURE  </param>
	/// <param name="parametros"> Parametros opcionales</param>
	/// <returns></returns>
	public DataTable GetDataByProcedure(string procedure, ICollection parametros = null)
	{
		DataTable result = new DataTable();
		SqlCommand comando = new SqlCommand(procedure, Connection);
		
		SqlDataAdapter filler = new SqlDataAdapter();
		filler.SelectCommand = comando;
	   
		if((parametros is List<SqlParameter>) && parametros.Count != 0)
			foreach (var item in (parametros as List<SqlParameter>))
			{
				comando.Parameters.Add(item);
			}
		try
		{
			Connection.Open();
			filler.Fill(result);
			Connection.Close();
		}
		catch (Exception ex)
		{

			MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
		}

		return result;
	}

	public void ExecCommand(string query)
	{
		SqlCommand comando = new SqlCommand(query, Connection);
		try
			{
				Connection.Open();
				comando.ExecuteNonQuery();
				Connection.Close();
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
			}
	}

	public void ExecProcedure(string procedure, ICollection parametros = null)
	{
		SqlCommand comando = new SqlCommand(procedure, Connection);
		comando.CommandType = CommandType.StoredProcedure;

		if ((parametros is List<SqlParameter>) && parametros.Count != 0)
			foreach (var item in (parametros as List<SqlParameter>))
			{
				comando.Parameters.Add(item);
			}
		try
		{
			Connection.Open();
			comando.ExecuteNonQuery();
			Connection.Close();
		}
		catch (Exception ex)
		{

			MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
		}

	}
}
