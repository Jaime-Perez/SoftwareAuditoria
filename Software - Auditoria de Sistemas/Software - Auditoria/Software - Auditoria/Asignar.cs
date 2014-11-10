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
    public partial class Asignar : Form
    {
        public Asignar()
        {
            InitializeComponent();
        }



        DBConnect db = new DBConnect("auditoria");
        bool nuevo = false, editar = false;
        int id = 0;

        private void Asignar_Load(object sender, EventArgs e)
        {
            consulta();
        }

        private void barra1_click_nuevo_button()
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            nuevo = true;
            editar = false;
        }

        private void barra1_click_guardar_button()
        {
            string tabla = "usuarios";
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("nombre", textBox1.Text);
            d.Add("contrasena", textBox2.Text);
            consulta();
            limpiar();


            if (nuevo)
            {
                db.insertar(tabla, d);
                nuevo = false;
                consulta();
                limpiar();
            }

            if (editar)
            {
                db.actualizar(tabla, d, "id_emple_us");
                editar = false;
                consulta();
                limpiar();
            }
        }

        private void barra1_click_eliminar_button()
        {
            int k = usuario_dgw.CurrentRow.Index;
            id = Convert.ToInt32(usuario_dgw.Rows[k].Cells[0].Value);
            if (MessageBox.Show("Desea eliminar el registro", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                db.eliminar("usuarios", "id_emple_us=" + id);
                consulta();
            }
        }









             private void consulta()
        {
            string query = "select id_emple_us, id_emple_us as 'ID Empleado', nombre as 'Usuario', contrasena as 'Password' from usuarios";
            usuario_dgw.DataSource = db.consulta_DataGridView(query);
            usuario_dgw.Columns[0].Visible = true;
            usuario_dgw.Focus();
        }



        private void limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Enabled = false;
            textBox2.Enabled = false;
        }

        private void usuario_dgw_SelectionChanged(object sender, EventArgs e)
        {
            
        }




        
    }
}
