using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_punto_de_ventas.Entidades
{
    public class Categoria
    {
        private int _id;
        private string _genero;
        public Categoria() {}
        public Categoria(int id, string genero)
        {
            this._id = id;
            this._genero = genero;
        }
        public int Id { get => _id; set => _id = value; }
        public string Genero { get => _genero; set => _genero = value; }        
    }
}
