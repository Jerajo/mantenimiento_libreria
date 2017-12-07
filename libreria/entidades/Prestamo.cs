using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace libreria
{
    enum EstadoP
    {
        EnStock = 3,
        Pendiente = 1,
        Devuelto = 0,
        Damage = -1
    }
    static class enumExtension
    {
        public static string ValNombre(this EstadoP estado)
        {
            switch (estado)
            {
                case EstadoP.EnStock: return "En Stock";
                case EstadoP.Devuelto: return "Devuelto";
                case EstadoP.Pendiente: return "Pendiente";
                default: return "Dañado";
            }
        }
    }
}

namespace libreria.entidades
{
    
    class Prestamo
    {
        private const string storedP = "spH_Prestamos";
        public int ID { get; set; }
        public string CodigoL { get; set; }
        public string CliDNI { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public EstadoP Estado { get; set; }

        public Prestamo()
        {
            ID = 0;
            Estado = EstadoP.Pendiente;
        }
        public Prestamo(string cod, string dni, DateTime ini, DateTime end, EstadoP e =EstadoP.Pendiente, int id = 0)
        {
            ID = id;
            CodigoL = cod;
            CliDNI = dni;
            Inicio = ini;
            Fin = end;
            Estado = e;
        }
        public void Update()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(DatabaseCon.MakeParam("@Accion", System.Data.SqlDbType.VarChar, "U"));

            list.Add(DatabaseCon.MakeParam("@id", System.Data.SqlDbType.Int, ID));
            list.Add(DatabaseCon.MakeParam("@Cod", System.Data.SqlDbType.VarChar, CodigoL));
            list.Add(DatabaseCon.MakeParam("@Cli", System.Data.SqlDbType.VarChar, CliDNI));
            list.Add(DatabaseCon.MakeParam("@Fi", System.Data.SqlDbType.DateTime, Inicio.Date));
            list.Add(DatabaseCon.MakeParam("@FF", System.Data.SqlDbType.DateTime, Fin.Date));
            list.Add(DatabaseCon.MakeParam("@Est", System.Data.SqlDbType.Int, (int)Estado));
            DatabaseCon.Instancia.ExecProcedure(storedP, list);

        }

        public static void Save( Prestamo me)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(DatabaseCon.MakeParam("@Accion", System.Data.SqlDbType.VarChar, "I"));
            
            list.Add(DatabaseCon.MakeParam("@Cod", System.Data.SqlDbType.VarChar, me.CodigoL));
            list.Add(DatabaseCon.MakeParam("@Cli", System.Data.SqlDbType.VarChar, me.CliDNI));
            list.Add(DatabaseCon.MakeParam("@Fi", System.Data.SqlDbType.DateTime, me.Inicio.Date));
            list.Add(DatabaseCon.MakeParam("@FF", System.Data.SqlDbType.DateTime, me.Fin.Date));
            list.Add(DatabaseCon.MakeParam("@Est", System.Data.SqlDbType.Int, (int)me.Estado));
            DatabaseCon.Instancia.ExecProcedure(storedP, list);
        }
    }
}
