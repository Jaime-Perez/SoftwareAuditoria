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
    public partial class actividades : Form
    {
        public actividades()
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
        }








        private void consulta()
        {
            string query = "select cod_actividad, nombre_actividad, descripcion_actividad, objetivos_cod_objetivo from actividades";
            auditoria_dgw.DataSource = db.consulta_DataGridView(query);
            auditoria_dgw.Columns[0].Visible = true;
            auditoria_dgw.Focus();
        }








        private void barra1_click_nuevo_button()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            comboBox1.Enabled = true;
            nuevo = true;
        }








        private void barra1_click_guardar_button()
        {
            string tabla = "actividades";
            Dictionary<string, string> d = new Dictionary<string, string>();

            d.Add("nombre_actividad", textBox1.Text);
            d.Add("descripcion_actividad", textBox2.Text);
            d.Add("objetivos_cod_objetivo", comboBox1.Text);

            if (nuevo)
            {
                db.insertar(tabla, d);
                nuevo = false;
                consulta();
                limpiar();
            }
            if (editar)
            {
                db.actualizar(tabla, d, "cod_actividad=" + id);
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
                int k = auditoria_dgw.CurrentRow.Index;
                id = Convert.ToInt32(auditoria_dgw.Rows[k].Cells[0].Value);
                textBox1.Text = auditoria_dgw.Rows[k].Cells[1].Value.ToString();
                textBox2.Text = auditoria_dgw.Rows[k].Cells[2].Value.ToString();
                comboBox1.Text = auditoria_dgw.Rows[k].Cells[3].Value.ToString();
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                comboBox1.Enabled = true;  

                editar = true;
            }
        }










        private void barra1_click_eliminar_button()
        {
            if (cambio)
            {
                int k = auditoria_dgw.CurrentRow.Index;
                id = Convert.ToInt32(auditoria_dgw.Rows[k].Cells[0].Value);
                if (MessageBox.Show("Desea eliminar el registro", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    db.eliminar("actividades", "cod_actividad=" + id);
                    consulta();
                }
            }
        }








        private void auditoria_dgw_SelectionChanged(object sender, EventArgs e)
        {
            cambio = true;
        }






        private void actividades_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = db.consulta_ComboBox("select cod_objetivo from objetivos");
            comboBox1.DisplayMember = "cod_objetivo";
            consulta();
        }
    }
}
