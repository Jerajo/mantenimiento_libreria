using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libreria.Controles
{
    public class ccLibro {
        public string ISBN { get; set; }
        public string Stock { get; set; }
        public string Titulo { get; set; }
        public string Editorial { get; set; }
        public string Genero { get; set; }
        public string Pais  { get; set; }

    }


    public partial class Libro : UserControl
    {
        public Libro()
        {
            InitializeComponent();
        }

        public Libro(ccLibro libroV)
        {
            InitializeComponent();
            lblTitulo.Text = libroV.Titulo;
            lblStock.Text = libroV.Stock;
            lblEdit.Text = libroV.Editorial;
            lblGenero.Text = libroV.Genero;
            lblPais.Text = libroV.Pais;
            lblISBN.Text = libroV.ISBN;
        }

        private void Libro_Load(object sender, EventArgs e)
        {

        }

    }
}
