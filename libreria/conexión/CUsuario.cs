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
            this._password = password;
        }

        public int Code { get => _code; set => _code = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        //codigo de encriptacion aqui...
        public string Password { get => _password; set => _password = value; }

        internal bool Actualizar()
        {
            throw new NotImplementedException();
        }

        internal bool Insertar()
        {
            throw new NotImplementedException();
        }

        internal string ValidarUsuario()
        {
            throw new NotImplementedException();
        }
    }
}
