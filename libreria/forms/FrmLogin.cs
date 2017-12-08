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
                string uDb = row.Field<String>("Nombre");
                if (user.Equals(uDb))
                {
                    string pDb = Encriptador.Desencriptar(row.Field<String>("Password"), Encriptador.KEY);
                    if (pass.Equals(pDb))
                    {
                        valid = true;
                    } 
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
            else MessageBox.Show("Usuario o Contraseña incorrectos.");
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.ActiveControl = button1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "USUARIO")
            {
                textBox1.Clear();
                textBox1.ForeColor = Color.Black;
            }          
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "CONTRASEÑA")
            {
                textBox2.Clear();
                textBox2.ForeColor = Color.Black;
                textBox2.UseSystemPasswordChar = true;
            }            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "USUARIO";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "CONTRASEÑA";
                textBox2.ForeColor = Color.Gray;
                textBox2.UseSystemPasswordChar = false;
            }            
        }
    }
}
