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
                    FDBHelper.MakeParam("@Nombre",SqlDbType.VarChar, 0, libros.Nombre),
                    FDBHelper.MakeParam("@Apellido",SqlDbType.VarChar, 0, libros.Apellido),
                    FDBHelper.MakeParam("@DNI",SqlDbType.Int, 0, libros.DNI),
                    FDBHelper.MakeParam("@Direccion",SqlDbType.VarChar, 0, libros.Direccion),
                    FDBHelper.MakeParam("@Telefono",SqlDbType.VarChar, 0, libros.Telefono),                
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FLibros_Insertar", dbParams));
        }

        public static int Actualizar(Libros libros)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@ID",SqlDbType.Int, 0, libros.ID),
                    FDBHelper.MakeParam("@Nombre",SqlDbType.VarChar, 0, libros.Nombre),
                    FDBHelper.MakeParam("@Apellido",SqlDbType.VarChar, 0, libros.Apellido),
                    FDBHelper.MakeParam("@DNI",SqlDbType.Int, 0, libros.DNI),
                    FDBHelper.MakeParam("@Direccion",SqlDbType.VarChar, 0, libros.Direccion),
                    FDBHelper.MakeParam("@Telefono",SqlDbType.VarChar, 0, libros.Telefono),
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FLibros_Actualizar", dbParams));
        }

        public static int Eliminar(Libros libros)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@ID",SqlDbType.Int, 0, libros.ID),
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FLibros_Eliminar", dbParams));
        }

        public static int VerificarDNI(int dni)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@DNI",SqlDbType.Int, 0, dni),
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FLibros_VerificarDNI", dbParams));
        }

    } 
}
