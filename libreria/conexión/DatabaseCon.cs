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
    private static DatabaseCon _Instance = null;
    private  SqlConnection Connection;

    public static DatabaseCon Instancia
    {
        get
        {
            if (_Instance == null) _Instance = new DatabaseCon();
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
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
        }
        finally
        {
            Connection.Close();
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

        if ((parametros is List<SqlParameter>) && parametros.Count != 0)
            foreach (var item in (parametros as List<SqlParameter>))
            {
                comando.Parameters.Add(item);
            }
        comando.CommandType = CommandType.StoredProcedure;
        try
        {
            Connection.Open();
            filler.Fill(result);
        }
        catch (Exception ex)
        {

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
        }
        finally
        {
            Connection.Close();
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
        }
        catch (Exception ex)
        {

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
        }
        finally
        {
            Connection.Close();
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
        }
        catch (Exception ex)
        {

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
        }
        finally
        {
            Connection.Close();
        }
    }

    public static SqlParameter MakeParam(string paramName, SqlDbType dbType,  object objValue)
    {
        SqlParameter param;

        param = new SqlParameter(paramName, dbType);

        param.Value = objValue;

        return param;
    }

    public static SqlParameter MakeParamOutput(string paramName, SqlDbType dbType)
    {
        SqlParameter param;

        param = new SqlParameter(paramName, dbType);

        param.Direction = ParameterDirection.Output;

        return param;
    }

    public  DataSet ExecuteDataSet(string sqlSpName, SqlParameter[] dbParams)
    {
        DataSet ds = null;
        ds = new DataSet();
        SqlCommand cmd = new SqlCommand(sqlSpName, Connection);
        cmd.CommandTimeout = 600;

        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);

        if (dbParams != null)
        {
            foreach (SqlParameter dbParam in dbParams)
            {
                da.SelectCommand.Parameters.Add(dbParam);
            }
        }
        da.Fill(ds);
        return ds;
    }

    public  object ExecuteScalar(string sqlSpName, SqlParameter[] dbParams)
    {
        object retVal = null;
        SqlCommand cmd = new SqlCommand(sqlSpName, Connection);
        cmd.CommandTimeout = Convert.ToInt16(ConfigurationManager.AppSettings.Get("connectionCommandTimeout"));
        cmd.CommandType = CommandType.StoredProcedure;
        if (dbParams != null)
        {
            foreach (SqlParameter dbParam in dbParams)
            {
                cmd.Parameters.Add(dbParam);
            }
        }        
        try
        {
            Connection.Open();
            retVal = cmd.ExecuteScalar();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            if (null != Connection) Connection.Close();
        }
        return retVal;
    }

    public  int ExecuteQScalar(string query)
    {
        SqlCommand comando = new SqlCommand(query, Connection);
        Int32 count = 0;
        try
        {
            Connection.Open();
            count = (Int32) comando.ExecuteScalar();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
        }
        finally
        {
            Connection.Close();
        }
        return count;
    }

    internal  DataSet GetColumnNames(string colunmName)
    {
        SqlParameter[] dbParams = new SqlParameter[]
            {
                MakeParam("@tabla",SqlDbType.VarChar, "[dbo].[LibrosSet]")
            };
        return ExecuteDataSet("usp_Data_GetColumnNames", dbParams);
    }

    public  string VerificarSiExiste(string tabla, string[] campo, string[] value)
    {
        string q = $"SELECT COUNT({campo[0]}) FROM {tabla} WHERE {campo[0]}='{value[0]}'";
        if (campo.Length > 1)
        {
            for(int i=1; i<campo.Length; i++) q += $" and {campo[i]}='{value[i]}'";
        }
        int count = ExecuteQScalar(q);
        return (count > 0) ? $"En el campo: {campo[0]} | Ya existe un valor {value[0]}.\n" : "";
    }
}
