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
    public partial class auditoria : Form
    {
        public auditoria()
        {
            InitializeComponent();
        }








        DBConnect db = new DBConnect("auditoria");
        bool editar = false, nuevo = false, cambio = false;
        int id = 0;




        private void limpiar()
        {
            textBox1.Text = "";
            textBox1.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
        }








        private void consulta()
        {
            string query = "select cod_auditoria, empresa_cod_empresa, actividades_cod_actividad, responsables_cod_responsa, encargado_cod, ponderacion from auditoria";
            auditoria_dgw.DataSource = db.consulta_DataGridView(query);
            auditoria_dgw.Columns[0].Visible = true;
            auditoria_dgw.Focus();
        }








        private void barra1_click_nuevo_button()
        {
            textBox1.Text = "";
            textBox1.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            comboBox4.Enabled = true;
            nuevo = true;
        }







        private void barra1_click_guardar_button()
        {
            string tabla = "auditoria";
            Dictionary<string, string> d = new Dictionary<string, string>();

            d.Add("empresa_cod_empresa", comboBox1.Text);
            d.Add("actividades_cod_actividad", comboBox2.Text);
            d.Add("responsables_cod_responsa", comboBox3.Text);
            d.Add("encargado_cod", comboBox4.Text);
            d.Add("ponderacion", textBox1.Text);

            if (nuevo)
            {
                db.insertar(tabla, d);
                nuevo = false;
                consulta();
                limpiar();
            }
            if (editar)
            {
                db.actualizar(tabla, d, "cod_auditoria=" + id);
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
                comboBox1.Text = auditoria_dgw.Rows[k].Cells[1].Value.ToString();
                comboBox2.Text = auditoria_dgw.Rows[k].Cells[2].Value.ToString();
                comboBox3.Text = auditoria_dgw.Rows[k].Cells[3].Value.ToString();
                comboBox4.Text = auditoria_dgw.Rows[k].Cells[4].Value.ToString();
                textBox1.Text = auditoria_dgw.Rows[k].Cells[5].Value.ToString();
                textBox1.Enabled = true;
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox4.Enabled = true;

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
                    db.eliminar("auditoria", "cod_auditoria=" + id);
                    consulta();
                }
            }
        }







        private void auditoria_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = db.consulta_ComboBox("select cod_empresa from empresa");
            comboBox1.DisplayMember = "cod_empresa";

            comboBox2.DataSource = db.consulta_ComboBox("select cod_actividad from actividades");
            comboBox2.DisplayMember = "cod_actividad";

            comboBox3.DataSource = db.consulta_ComboBox("select cod_responsable from responsables");
            comboBox3.DisplayMember = "cod_responsable";

            comboBox4.DataSource = db.consulta_ComboBox("select cod_encargado from encargado");
            comboBox4.DisplayMember = "cod_encargado";
            consulta ();
        }





        private void auditoria_dgw_SelectionChanged(object sender, EventArgs e)
        {
            cambio = true ;
        }
    }
}
