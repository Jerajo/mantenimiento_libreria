using Sistema_de_punto_de_ventas.Entidades;
using libreria;
using SisVenttas.Datos;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Sistema_de_punto_de_ventas.Datos
{
    public class FEstudiante
    {
        public static DataSet GetAll()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {

                };
            return FDBHelper.ExecuteDataSet("usp_Data_FEstudiante_GetAll", dbParams);
        }


        public static int Insertar(Estudiante estudiante)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@Nombre",SqlDbType.VarChar, 0, estudiante.Nombre),
                    FDBHelper.MakeParam("@Apellido",SqlDbType.VarChar, 0, estudiante.Apellido),
                    FDBHelper.MakeParam("@DNI",SqlDbType.Int, 0, estudiante.DNI),
                    FDBHelper.MakeParam("@Direccion",SqlDbType.VarChar, 0, estudiante.GetDireccion.Calle),
                    FDBHelper.MakeParam("@Telefono",SqlDbType.VarChar, 0, estudiante.Telefono),                
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FEstudiante_Insertar", dbParams));
        }

        public static int Actualizar(Estudiante estudiante)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@ID",SqlDbType.Int, 0, estudiante.ID),
                    FDBHelper.MakeParam("@Nombre",SqlDbType.VarChar, 0, estudiante.Nombre),
                    FDBHelper.MakeParam("@Apellido",SqlDbType.VarChar, 0, estudiante.Apellido),
                    FDBHelper.MakeParam("@DNI",SqlDbType.Int, 0, estudiante.DNI),
                    FDBHelper.MakeParam("@Direccion",SqlDbType.VarChar, 0, estudiante.GetDireccion.Calle),
                    FDBHelper.MakeParam("@Telefono",SqlDbType.VarChar, 0, estudiante.Telefono),
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FEstudiante_Actualizar", dbParams));
        }

        public static int Eliminar(Estudiante estudiante)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@ID",SqlDbType.Int, 0, estudiante.ID),
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FEstudiante_Eliminar", dbParams));
        }

        public static int VerificarDNI(int dni)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@DNI",SqlDbType.Int, 0, dni),
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_FEstudiante_VerificarDNI", dbParams));
        }

    } 
}
