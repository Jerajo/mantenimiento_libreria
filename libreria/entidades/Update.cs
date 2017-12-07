using libreria.forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libreria.entidades
{
    public static class UPDATE
    {
        private static Dictionary<string, bool> _formsList = new Dictionary<string, bool>();

        public static Dictionary<string, bool> FormsList
        {
            get => _formsList;
            set => _formsList = value;
        }
        
        public static bool IsUpdated(string key)
        {
            //MessageBox.Show($"El formulario {key} pregunta si esta actualizdo.");
            return _formsList[key];
        }

        public static void State(string key, bool value)
        {
            //MessageBox.Show($"El formulario {key} se ha actualizado.");
            _formsList[key] = value;
        }

        public static void AllForms(bool value)
        {
            //List<Form> forms = GetForms();            
            GetFormList(ref _formsList);            
            for (int index = 0; index < _formsList.Count; index++)
            {
                var state = _formsList.ElementAt(index);
                var Key = state.Key;
                _formsList[Key] = value;              
            }
        }

        private static void GetFormList(ref Dictionary<string, bool> lista)
        {                   
            lista["FrmLibros"]     = false;
            lista["Generos"]       = false;
            lista["SchLibros"]     = false;
            lista["FrmAutor"]      = false;
            lista["FrnEst"]        = false;
            lista["FrmEjemplares"] = false;
            lista["FrmPrestamo"]   = false;
            lista["Usuarios"] = false;
            //lista["hola"] = false;
        }

        public static List<Form> GetForms()
        {            
            List<Form> instancias = new List<Form>();
            instancias.Add(FrmLibros.GetInstance());            //Libros   
            instancias.Add(Mantenimientos.Generos.Instancia);   //Generos
            instancias.Add(Busquedas.SchLibros.Instancia);      //Buscar Libros            
            instancias.Add(FrmAutor.Instance);                  //Autores
            instancias.Add(FrnEst.Instance);                    //Estudiantes
            instancias.Add(FrmEjemplares.GetInstance());        //Ejemplares
            instancias.Add(FrmPrestamo.Instance);               //Prestamos
            //instancias.Add();
            return instancias;
        }
    }
}
