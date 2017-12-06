using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libreria.entidades
{
    class Ejemplares
    {
        string _codigo, _isbn;
        decimal _numero;

        public Ejemplares(string codigo, string isbn, decimal numero)
        {
            this._codigo = codigo;
            this._isbn = isbn;
            this._numero = numero;
        }

        public string Codigo { get => _codigo; set => _codigo = value; }
        public decimal Numero { get => _numero; set => _numero = value; }
        public string ISBN { get => _isbn; set => _isbn = value; }
    }
}
