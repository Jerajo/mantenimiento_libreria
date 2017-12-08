using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libreria.entidades
{
    public static class Usuarios
    {
        private static string _username, _password = string.Empty;

        public static string Username { get => _username; set => _username = value; }
        public static string Password => _password; 
        public static void SetPassword(string value)
        {
            _password = Encriptador.Encriptar(value, Encriptador.KEY);
        }
    }
}
