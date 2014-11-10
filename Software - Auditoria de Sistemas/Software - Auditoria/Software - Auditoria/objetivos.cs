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
    public partial class objetivos : Form
    {
        public objetivos()
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
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
        }








        private void consulta()
        {
            string query = "select cod_objetivo, nombre_objetivo, objetivoscol, normas_cod_norma,areas_cod_area from objetivos";
            objetivos_dgw.DataSource = db.consulta_DataGridView(query);
            objetivos_dgw.Columns[0].Visible = true;
            objetivos_dgw.Focus();
        }





        

        private void barra1_click_nuevo_button()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            nuevo = true;
        }





        private void barra1_click_guardar_button()
        {
            string tabla = "objetivos";
            Dictionary<string, string> d = new Dictionary<string, string>();

            d.Add("nombre_objetivo", textBox1.Text);
            d.Add("objetivoscol", textBox2.Text);
            d.Add("normas_cod_norma", comboBox1.Text);
            d.Add("areas_cod_area", comboBox2.Text);

            if (nuevo)
            {
                db.insertar(tabla, d);
                nuevo = false;
                consulta();
                limpiar();
            }
            if (editar)
            {
                db.actualizar(tabla, d, "cod_objetivo=" + id);
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
                int k = objetivos_dgw.CurrentRow.Index;
                id = Convert.ToInt32(objetivos_dgw.Rows[k].Cells[0].Value);
                textBox1.Text = objetivos_dgw.Rows[k].Cells[1].Value.ToString();
                textBox2.Text = objetivos_dgw.Rows[k].Cells[2].Value.ToString();
                comboBox1.Text = objetivos_dgw.Rows[k].Cells[3].Value.ToString();
                comboBox2.Text = objetivos_dgw.Rows[k].Cells[4].Value.ToString();
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;

                editar = true;
            }
        }







        private void barra1_click_eliminar_button()
        {
            if (cambio)
            {
                int k = objetivos_dgw.CurrentRow.Index;
                id = Convert.ToInt32(objetivos_dgw.Rows[k].Cells[0].Value);
                if (MessageBox.Show("Desea eliminar el registro", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    db.eliminar("objetivos", "cod_objetivo=" + id);
                    consulta();
                }
            }
        }






        private void objetivos_dgw_SelectionChanged(object sender, EventArgs e)
        {
            cambio = true;
        }




        private void objetivos_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = db.consulta_ComboBox("select cod_norma from normas");
            comboBox1.DisplayMember = "cod_norma";

            comboBox2.DataSource = db.consulta_ComboBox("select cod_area from areas");
            comboBox2.DisplayMember = "cod_area";
            
            consulta();
        }

        

    }
}
