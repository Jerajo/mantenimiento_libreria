using Sistema_de_punto_de_ventas.Entidades;
using SisVenttas.Datos;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Sistema_de_punto_de_ventas.Datos
{
    public class CLibro
    {
        public static DataSet GetAll(string procedure = "")
        {
            SqlParameter[] dbParams = new SqlParameter[]{};
            if (procedure != "")
                return FDBHelper.ExecuteDataSet(procedure, dbParams);
            return FDBHelper.ExecuteDataSet("usp_Data_CLibro_GetAll", dbParams);
        }

        public static DataSet GetColumnNames()
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                DatabaseCon.MakeParam("@tabla",SqlDbType.VarChar, "[dbo].[LibrosSet]")
            };
            return DatabaseCon.ExecuteDataSet("usp_Data_CCategoria_GetColumnNames", dbParams);
        }

        public static int Insertar(Libro libro)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    //, Titulo, Pais, Stock, Editorial, CategoriaId
                    DatabaseCon.MakeParam("@ISBN",SqlDbType.VarChar, libro.ISBN),
                    DatabaseCon.MakeParam("@Titulo",SqlDbType.VarChar, libro.Titulo),
                    DatabaseCon.MakeParam("@Pais",SqlDbType.VarChar, libro.Pais),
                    DatabaseCon.MakeParam("@Stock",SqlDbType.Int, libro.Stock),
                    DatabaseCon.MakeParam("@Editorial",SqlDbType.VarChar, libro.Editorial),
                    DatabaseCon.MakeParam("@CategoriaId",SqlDbType.Int, libro.CategoriaId),                
                };
            return Convert.ToInt32(DatabaseCon.ExecuteScalar("usp_Data_CLibro_Insertar", dbParams));
        }

        public static int Actualizar(Libro libro)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DatabaseCon.MakeParam("@ISBN",SqlDbType.VarChar, libro.ISBN),
                    DatabaseCon.MakeParam("@Titulo",SqlDbType.VarChar, libro.Titulo),
                    DatabaseCon.MakeParam("@Pais",SqlDbType.VarChar, libro.Pais),
                    DatabaseCon.MakeParam("@Stock",SqlDbType.Int, libro.Stock),
                    DatabaseCon.MakeParam("@Editorial",SqlDbType.VarChar, libro.Editorial),
                    DatabaseCon.MakeParam("@CategoriaId",SqlDbType.Int, libro.CategoriaId),
                };
            return Convert.ToInt32(DatabaseCon.ExecuteScalar("usp_Data_CLibro_Actualizar", dbParams));
        }

        public static int Eliminar(Libro libro)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DatabaseCon.MakeParam("@ISBN",SqlDbType.VarChar, libro.ISBN),
                };
            return Convert.ToInt32(DatabaseCon.ExecuteScalar("usp_Data_CLibro_Eliminar", dbParams));
        }

        public static int VerificarStock(decimal dni)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DatabaseCon.MakeParam("@Stock",SqlDbType.Int, dni),
                };
            return Convert.ToInt32(DatabaseCon.ExecuteScalar("usp_Data_CLibro_VerificarStock", dbParams));
        }

    } 
}
