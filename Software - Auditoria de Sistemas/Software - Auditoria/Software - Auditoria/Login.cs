using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ODBCConnect;


namespace Software___Auditoria
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        DBConnect db = new DBConnect("auditoria");
        private void Ingresar_Click(object sender, EventArgs e)
        {
            string usu = "";
            string pas = "";

            string query = ("select nombre, contrasena from usuarios where nombre = '" + textBox1.Text + "' and contrasena='" + textBox2.Text + "'");
            System.Collections.ArrayList array = db.consultar(query);
            foreach (Dictionary<string, string> dict in array)
            {
                usu = dict["nombre"];
                pas = dict["contrasena"];
            }

            if (!string.IsNullOrWhiteSpace(textBox1.Text) || !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                if (usu.Equals(textBox1.Text) && pas.Equals(textBox2.Text))
                {
                    this.Hide();
                    MDI mdi = new MDI();
                    mdi.Show();
                }
                else
                {
                    MessageBox.Show("Usuario y contraseña: INCORRECTO", "Inicio de session", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox1.Text = "";
                    textBox2.Text = "";
                }

            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos", "Error al iniciar session", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registro rg = new Registro();
            rg.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
