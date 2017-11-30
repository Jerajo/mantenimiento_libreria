using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_punto_de_ventas.Entidades
{
    public class Libro
    {
        private int _stock, _categoriaId;
        private string _ISBN, _titulo, _pais, _editorial;
        public Libro() {}
        public Libro(string ISBN, string titulo, int stock, string pais, string editorial, int categoriaId)
        {
            this._ISBN = ISBN;         
            this._titulo = titulo;
            this._pais = pais;
            this._stock = stock;
            this._editorial = editorial;
            this._categoriaId = categoriaId;
        }

        public int Stock { get => _stock; set => _stock = value; }
        public int CategoriaId { get => _categoriaId; set => _categoriaId = value; }
        public string ISBN { get => _ISBN; set => _ISBN = value; }
        public string Titulo { get => _titulo; set => _titulo = value; }
        public string Pais { get => _pais; set => _pais = value; }
        public string Editorial { get => _editorial; set => _editorial = value; }
    }
}
