using Sistema_de_punto_de_ventas.Entidades;
using SisVenttas.Datos;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Sistema_de_punto_de_ventas.Datos
{
    public class CLibros
    {
        public static DataSet GetAll()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {

                };
            return FDBHelper.ExecuteDataSet("usp_Data_FLibros_GetAll", dbParams);
        }


        public static int Insertar(Libros libros)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    //, Titulo, Pais, Stock, Editorial, CategoriaId
                    FDBHelper.MakeParam("@ISBN",SqlDbType.VarChar, 0, libros.ISBN),
                    FDBHelper.MakeParam("@Pais",SqlDbType.VarChar, 0, libros.Pais),
                    FDBHelper.MakeParam("@Stock",SqlDbType.Int, 0, libros.Stock),
                    FDBHelper.MakeParam("@Editorial",SqlDbType.VarChar, 0, libros.Editorial),
                    FDBHelper.MakeParam("@CategoriaId",SqlDbType.Int, 0, libros.CategoriaId),                
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FLibros_Insertar", dbParams));
        }

        public static int Actualizar(Libros libros)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@ISBN",SqlDbType.VarChar, 0, libros.ISBN),
                    FDBHelper.MakeParam("@Pais",SqlDbType.VarChar, 0, libros.Pais),
                    FDBHelper.MakeParam("@Stock",SqlDbType.Int, 0, libros.Stock),
                    FDBHelper.MakeParam("@Editorial",SqlDbType.VarChar, 0, libros.Editorial),
                    FDBHelper.MakeParam("@CategoriaId",SqlDbType.Int, 0, libros.CategoriaId),
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FLibros_Actualizar", dbParams));
        }

        public static int Eliminar(Libros libros)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@ISBN",SqlDbType.VarChar, 0, libros.ISBN),
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FLibros_Eliminar", dbParams));
        }

        public static int VerificarStock(int dni)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@Stock",SqlDbType.Int, 0, dni),
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FLibros_VerificarStock", dbParams));
        }

    } 
}
