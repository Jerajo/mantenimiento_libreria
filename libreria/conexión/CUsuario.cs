using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libreria.conexión
{
    class CUsuario
    {
        private int _code;
        private string _nombre, _password;

        public CUsuario(){ }
        public CUsuario(int codigo, string nombre, string password)
        {
            this._code = codigo;
            this._nombre = nombre;
            //codigo encriptacion
            this._password = password;
        }

        public int Code { get => _code; set => _code = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        //codigo de encriptacion aqui...
        public string Password { get => _password; set => _password = value; }

        internal bool Actualizar()
        {
            try
            {
                if(Password != "")
                    DatabaseCon.Instancia.ExecCommand($"update [dbo].[CredencialesSet] set Nombre='{Nombre}', Password='{Password}' where Codigo={Code}");
                else
                    DatabaseCon.Instancia.ExecCommand($"update [dbo].[CredencialesSet] set Nombre='{Nombre}' where Codigo={Code}");
                return true;
            }
            catch (Exception) { return false; }
        }

        internal bool Insertar()
        {
            try
            {
                DatabaseCon.Instancia.ExecCommand($"Insert into [dbo].[CredencialesSet](Nombre, Password) values('{Nombre}', '{Password}')");
                return true;
            }
            catch (Exception) { return false; }            
        }

        internal string ValidarUsuario(int row)
        {
            int r;
            var resoult = "";
            if (row == 0)
            {
                r = DatabaseCon.Instancia.ExecuteQScalar($"Select Nombre where Nombre='{Nombre}'");
                if (r > 0) resoult = $"El usuario: '{Nombre}' Ya existe.\n";
            }                     
            return resoult;
        }
    }
}
