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
    public partial class herramientas_asignadas : Form
    {

        public herramientas_asignadas()
        {
            InitializeComponent();
        }






        DBConnect db = new DBConnect("auditoria");
        bool editar = false, nuevo = false, cambio = false;
        int id = 0;








        private void limpiar()
        {
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
        }








        private void consulta()
        {
            string query = "select cod_herramientas_asignadas, herramientas_cod_herramienta, actividades_cod_actividad from herramientas_asignadas";
            areas_dgw.DataSource = db.consulta_DataGridView(query);
            areas_dgw.Columns[0].Visible = true;
            areas_dgw.Focus();
        }








        private void barra1_click_nuevo_button()
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            nuevo = true;
        }






        private void barra1_click_guardar_button()
        {
            string tabla = "herramientas_asignadas";
            Dictionary<string, string> d = new Dictionary<string, string>();

            d.Add("herramientas_cod_herramienta", comboBox1.Text);
            d.Add("actividades_cod_actividad", comboBox2.Text);

            if (nuevo)
            {
                db.insertar(tabla, d);
                nuevo = false;
                consulta();
                limpiar();
            }
            if (editar)
            {
                db.actualizar(tabla, d, "cod_herramientas_asignadas=" + id);
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
                int k = areas_dgw.CurrentRow.Index;
                id = Convert.ToInt32(areas_dgw.Rows[k].Cells[0].Value);
                comboBox1.Text = areas_dgw.Rows[k].Cells[1].Value.ToString();
                comboBox2.Text = areas_dgw.Rows[k].Cells[2].Value.ToString();
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;

                editar = true;
            }
        }





        private void barra1_click_eliminar_button()
        {
            if (cambio)
            {
                int k = areas_dgw.CurrentRow.Index;
                id = Convert.ToInt32(areas_dgw.Rows[k].Cells[0].Value);
                if (MessageBox.Show("Desea eliminar el registro", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    db.eliminar("herramientas_asignadas", "cod_herramientas_asignadas=" + id);
                    consulta();
                }
            }
        }

        private void areas_dgw_SelectionChanged(object sender, EventArgs e)
        {
            cambio = true;
        }

        private void herramientas_asignadas_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = db.consulta_ComboBox("select cod_herramientas from herramientas");
            comboBox1.DisplayMember = "cod_herramientas";

            comboBox2.DataSource = db.consulta_ComboBox("select cod_actividad from actividades");
            comboBox2.DisplayMember = "cod_actividad";
            consulta();
        }
    }
}
