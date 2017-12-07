using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libreria.entidades;

namespace libreria
{
    public partial class Box : Form
    {
        public Box()
        {
            InitializeComponent();
        }

        private void Box_Load(object sender, EventArgs e)
        {
            
            UPDATE.AllForms(true);
        }

        private void generosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Box = Mantenimientos.Generos.Instancia;
            Box.MdiParent = this;
            Box.Show();
            Box.BringToFront();
        }

        private void busquedasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void librosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Box = Busquedas.SchLibros.Instancia;
            Box.MdiParent = this;
            Box.Show();
            Box.BringToFront();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var Box = forms.FrmLibros.GetInstance();
            Box.MdiParent = this;
            Box.Show();
            Box.BringToFront();
        }

        private void autorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Box = forms.FrmAutor.Instance;
            Box.MdiParent = this;
            Box.Show();
            Box.BringToFront();
        }

        private void estudiantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Box = forms.FrnEst.Instance;
            Box.MdiParent = this;
            Box.Show();
            Box.BringToFront();
        }

        private void ejemplaresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Box = forms.FrmEjemplares.GetInstance();
            Box.MdiParent = this;
            Box.Show();
            Box.BringToFront();
        }

        private void mantenimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void prestamosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Box = forms.FrmPrestamo.Instance;
            Box.MdiParent = this;
            Box.Show();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new forms.PopUp.About();
            about.ShowDialog();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Box = forms.Usuarios.Instance;
            Box.MdiParent = this;
            Box.Show();
        }
    }
}
