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
        public static void AllForms(bool value)
        {
            List<Form> forms = GetForms();
            string names = "";
            foreach(Form fr in forms)
            {
                names += $" {fr.Name},";
            }
            MessageBox.Show(names);
        }

        public static List<Form> GetForms()
        {
            //Form[] instancias = new Form[10];
            //instancias[0] = FrmLibros.GetInstance();
            List<Form> instancias = new List<Form>();
            instancias.Add(FrmLibros.GetInstance());            //Libros   
            instancias.Add(Mantenimientos.Generos.Instancia);   //Generos
            instancias.Add(Busquedas.SchLibros.Instancia);      //Buscar Libros            
            instancias.Add(FrmAutor.Instance);                  //Autores
            instancias.Add(FrnEst.Instance);                    //Estudiantes
            instancias.Add(FrmEjemplares.GetInstance());        //Ejemplares
            instancias.Add(FrmPrestamo.Instance);               //Prestamos
            //instancias.Add();
            //instancias.Add();
            //instancias.Add();
            //instancias.Add();
            return instancias;
        }
    }
}
