using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libreria
{
    public class Direccion
    {
        private string _client;

        public string Cliente
        {
            get { return _client; }
        }

        public int ID { get; set; }
        
        public string Sector   { get; set; }
        private string _pais;

        public string Pais
        {
            get { return _pais; }
            set { _pais = value; }
        }

        private string _calle;

        public string Calle
        {
            get { return _calle; }
            set { _calle = value; }
        }
        private string _prov;

        public string Provincia
        {
            get { return _prov; }
            set { _prov = value; }
        }
        private Direccion()
        {

        }
        public Direccion(string cl)
        {
            _client = cl;
            var D = GetDir(cl);
            Calle = D.Calle;
            ID = D.ID;
            Sector = D.Sector;
            Pais = D.Pais;
            Provincia = D.Provincia;
        }

        public static Direccion GetDir(string DNI)
        {
            Direccion dir = new Direccion();
            var data = DatabaseCon.Instancia.GetData($"select * from DireccionSet where ClienteID = '{DNI}'");
            if (data.Rows.Count > 0)
            {
                dir.Calle = data.Rows[0]["Calle"].ToString();
                dir.Sector = data.Rows[0]["Sector"].ToString();
                dir.Pais = data.Rows[0]["Pais"].ToString();
                dir.Provincia = data.Rows[0]["Provincia"].ToString();
                dir.ID = (int)data.Rows[0]["Id"]; 
            }
            return dir;
        }
    }

    public class Estudiante
    {
        public int ID { get; set; }
        private string _dni;
        private string _nombre, _apellido, _telefono, _correo;

        public Estudiante() { }
        public Estudiante(string DNI) {

            var E = GetEstudiante(DNI);
            this._nombre = E.Nombre;
            this._apellido = E.Apellido;
            this._correo = E.Correo;
            this._telefono = E.Telefono;
            this._dni = E.DNI;

        }
        public Estudiante( string nombre, string apellido, string correo, string telefono, string dni)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._correo = correo;
            this._telefono = telefono;
            this._dni = dni;
        }
        
        public string DNI
        {
            get { return _dni; }
            private set { _dni = value; }
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
        public string Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }
        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public static Estudiante GetEstudiante(string ID)
        {
            Estudiante est = new Estudiante();
            var Data = DatabaseCon.Instancia.GetData($"select * from Clientes where Identificacion = '{ID}'");
            if(Data.Rows.Count == 1)
            {
                est.Nombre = Data.Rows[0]["Nombre"].ToString();
                est.Apellido = Data.Rows[0]["Apellido"].ToString();
                est.Telefono = Data.Rows[0]["Telefono"].ToString();
                est.Correo = Data.Rows[0]["Correo"].ToString();
                est.DNI = Data.Rows[0]["Identificacion"].ToString();

            }

            return est;
        }
        public Direccion GetDireccion => Direccion.GetDir(DNI);

        public void Update()
        {

        }
       
    }
}
