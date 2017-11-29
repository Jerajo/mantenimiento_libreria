using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_punto_de_ventas.Entidades
{
    public class Libros
    {
        private int _id, _dni;
        private string _nombre, _apellido, _telefono, _direccion;

        public Libros() {}
        public Libros(int id, string nombre, string apellido, string dirrecion, string telefono, int dni)
        {
            this._id = id;
            this._nombre = nombre;
            this._apellido = apellido;
            this._direccion = dirrecion;
            this._telefono = telefono;
            this._dni = dni;
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public int DNI
        {
            get { return _dni; }
            set { _dni = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }
        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }
    }
}
