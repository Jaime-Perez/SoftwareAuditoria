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
    public partial class empresas : Form
    {
        public empresas()
        {
            InitializeComponent();
        }







        DBConnect db = new DBConnect("auditoria");
        bool editar = false, nuevo = false, cambio = false;
        int id = 0;











        private void limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
        }









        private void consulta()
        {
            string query = "select cod_empresa, nombre_empresa, direccion_empresa, telefono_empresa, correo_empresa, nombre_encargado from empresa";
            empresas_dgw.DataSource = db.consulta_DataGridView(query);
            empresas_dgw.Columns[0].Visible = true;
            empresas_dgw.Focus();
        }









        private void barra1_click_nuevo_button()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            nuevo = true;
        }








        private void barra1_click_guardar_button()
        {
            string tabla = "empresa";
            Dictionary<string, string> d = new Dictionary<string, string>();

            d.Add("nombre_empresa", textBox1.Text);
            d.Add("direccion_empresa", textBox2.Text);
            d.Add("telefono_empresa", textBox3.Text);
            d.Add("correo_empresa", textBox4.Text);
            d.Add("nombre_encargado", textBox5.Text);
            
            if (nuevo)
            {
                db.insertar(tabla, d);
                nuevo = false;
                consulta();
                limpiar();
            }
            if (editar)
            {
                db.actualizar(tabla, d, "cod_empresa=" + id);
                editar = false;
                consulta();
                limpiar();
            }
        }











        private void barra1_click_editar_button()
        {
            if (cambio)
            {
                nuevo = false;
                int k = empresas_dgw.CurrentRow.Index;
                id = Convert.ToInt32(empresas_dgw.Rows[k].Cells[0].Value);
                textBox1.Text = empresas_dgw.Rows[k].Cells[1].Value.ToString();
                textBox2.Text = empresas_dgw.Rows[k].Cells[2].Value.ToString();
                textBox3.Text = empresas_dgw.Rows[k].Cells[3].Value.ToString();
                textBox4.Text = empresas_dgw.Rows[k].Cells[4].Value.ToString();
                textBox5.Text = empresas_dgw.Rows[k].Cells[5].Value.ToString();
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;

                editar = true;
            }
        }










        private void barra1_click_eliminar_button()
        {
            if (cambio)
            {
                int k = empresas_dgw.CurrentRow.Index;
                id = Convert.ToInt32(empresas_dgw.Rows[k].Cells[0].Value);
                if (MessageBox.Show("Desea eliminar el registro", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    db.eliminar("empresa", "cod_empresa=" + id);
                    consulta();
                }
            }
        }











        private void empresas_dgw_SelectionChanged(object sender, EventArgs e)
        {
            cambio = true;
        }










        private void empresas_Load(object sender, EventArgs e)
        {
            consulta();
        }

        private void barra1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
