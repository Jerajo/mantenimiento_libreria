﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        }

        private void generosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Box = Mantenimientos.Generos.Instancia;
            Box.MdiParent = this;
            Box.Show();
        }

        private void busquedasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void librosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Box = Busquedas.SchLibros.Instancia;
            Box.MdiParent = this;
            Box.Show();
        }
    }
}