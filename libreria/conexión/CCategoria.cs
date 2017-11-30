using Sistema_de_punto_de_ventas.Entidades;
using SisVenttas.Datos;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Sistema_de_punto_de_ventas.Datos
{
    public class CCategoria
    {
        public static DataSet GetAll()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {

                };
            return FDBHelper.ExecuteDataSet("usp_Data_CCategoria_GetAll", dbParams);
        }


        public static int Insertar(Libro libro)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    //, Titulo, Pais, Stock, Editorial, CategoriaId
                    FDBHelper.MakeParam("@ISBN",SqlDbType.VarChar, 0, libro.ISBN),
                    FDBHelper.MakeParam("@Titulo",SqlDbType.VarChar, 0, libro.Titulo),
                    FDBHelper.MakeParam("@Pais",SqlDbType.VarChar, 0, libro.Pais),
                    FDBHelper.MakeParam("@Stock",SqlDbType.Int, 0, libro.Stock),
                    FDBHelper.MakeParam("@Editorial",SqlDbType.VarChar, 0, libro.Editorial),
                    FDBHelper.MakeParam("@CategoriaId",SqlDbType.Int, 0, libro.CategoriaId),                
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_CCategoria_Insertar", dbParams));
        }

        public static int Actualizar(Libro libro)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@ISBN",SqlDbType.VarChar, 0, libro.ISBN),
                    FDBHelper.MakeParam("@Pais",SqlDbType.VarChar, 0, libro.Pais),
                    FDBHelper.MakeParam("@Stock",SqlDbType.Int, 0, libro.Stock),
                    FDBHelper.MakeParam("@Editorial",SqlDbType.VarChar, 0, libro.Editorial),
                    FDBHelper.MakeParam("@CategoriaId",SqlDbType.Int, 0, libro.CategoriaId),
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_CCategoria_Actualizar", dbParams));
        }

        public static int Eliminar(Libro libro)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@ISBN",SqlDbType.VarChar, 0, libro.ISBN),
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_CCategoria_Eliminar", dbParams));
        }
    } 
}
