using libreria.entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libreria.conexión
{
    class CEjemplares
    {
        public static DataSet GetAll()
        {
            SqlParameter[] dbParams = new SqlParameter[] { };
            return DatabaseCon.Instancia.ExecuteDataSet("usp_Data_CEjemplares_GetAll", dbParams);
        }

        public static DataSet GetColumnNames()
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                DatabaseCon.MakeParam("@tabla",SqlDbType.VarChar, "[dbo].[EjemplaressSet]")
            };
            return DatabaseCon.Instancia.ExecuteDataSet("usp_Data_CCategoria_GetColumnNames", dbParams);
        }

        public static int Insertar(Ejemplares ejemplares)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DatabaseCon.MakeParam("@ISBN",SqlDbType.VarChar, ejemplares.ISBN),
                    DatabaseCon.MakeParam("@Cod",SqlDbType.VarChar, ejemplares.Codigo),
                    DatabaseCon.MakeParam("@numero",SqlDbType.Int, ejemplares.Numero)
                };
            return Convert.ToInt32(DatabaseCon.Instancia.ExecuteScalar("usp_Data_Ejemplares_Insertar", dbParams));
        }

        public static int Actualizar(Ejemplares ejemplares, int oldN)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DatabaseCon.MakeParam("@ISBN",SqlDbType.VarChar, ejemplares.ISBN),
                    DatabaseCon.MakeParam("@Cod",SqlDbType.VarChar, ejemplares.Codigo),                    
                    DatabaseCon.MakeParam("@newN",SqlDbType.Int, ejemplares.Numero),
                    DatabaseCon.MakeParam("@oldN",SqlDbType.Int, oldN)
                };
            return Convert.ToInt32(DatabaseCon.Instancia.ExecuteScalar("usp_Data_Ejemplares_Actualizar", dbParams));
        }

        public static int Eliminar(Ejemplares ejemplares)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DatabaseCon.MakeParam("@ISBN",SqlDbType.VarChar, ejemplares.ISBN),
                };
            return Convert.ToInt32(DatabaseCon.Instancia.ExecuteScalar("usp_Data_CEjemplares_Eliminar", dbParams));
        }

        public static int VerificarStock(int dni)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DatabaseCon.MakeParam("@Stock",SqlDbType.Int, dni),
                };
            return Convert.ToInt32(DatabaseCon.Instancia.ExecuteScalar("usp_Data_CEjemplares_VerificarStock", dbParams));
        }
    }
}
