﻿using System;
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
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }



        DBConnect db = new DBConnect("auditoria");

        private void button1_Click(object sender, EventArgs e)
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
                    Asignar ag = new Asignar();
                    ag.Show();
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
    }
}