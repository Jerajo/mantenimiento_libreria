using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libreria.entidades
{
    public static class Usuarios
    {
        private static string _username;
        private static int _password;

        public static string Username { get => _username; set => _username = value; }
        public static int Password { get => _password; }
        public static void SetPassword(string value)
        {

        }
    }
}
