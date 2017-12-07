using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libreria.forms
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ValLogin(textBox1.Text, textBox2.Text);
        }

        private void ValLogin(string User, string Pass)
        {
            bool valid = false;
            string user = textBox1.Text.Trim();
            string pass = textBox2.Text.Trim();
            var data = DatabaseCon.Instancia.GetData("Select * from CredencialesSet");
            foreach(DataRow row in data.Rows)
            {
                string uDb = Encriptador.Desencriptar(row.Field<String>("Codigo"), Encriptador.KEY);
                string pDb = Encriptador.Desencriptar(row.Field<String>("Password"), Encriptador.KEY);
                if( user.Equals(uDb) && pass.Equals(pDb))
                {
                    valid = true;
                }
            }

            if (valid)
            {
                var b = new Box();
                this.Hide();
                b.ShowDialog();
                this.Show();
                textBox1.Clear();
                textBox2.Clear();
            }
        }
    }
}
