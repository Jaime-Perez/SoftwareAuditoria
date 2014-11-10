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
    public partial class herramientas : Form
    {
        public herramientas()
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
        }





        private void consulta()
        {
            string query = "select cod_herramientas, nombre_herramientas, descripcion_herramientas from herramientas";
            herramientas_dgw.DataSource = db.consulta_DataGridView(query);
            herramientas_dgw.Columns[0].Visible = true;
            herramientas_dgw.Focus();
        }





        private void barra1_click_nuevo_button()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            nuevo = true;
        }








        private void barra1_click_guardar_button()
        {
            string tabla = "herramientas";
            Dictionary<string, string> d = new Dictionary<string, string>();

            d.Add("nombre_herramientas", textBox1.Text);
            d.Add("descripcion_herramientas", textBox2.Text);

            if (nuevo)
            {
                db.insertar(tabla, d);
                nuevo = false;
                consulta();
                limpiar();
            }
            if (editar)
            {
                db.actualizar(tabla, d, "cod_herramientas=" + id);
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
                int k = herramientas_dgw.CurrentRow.Index;
                id = Convert.ToInt32(herramientas_dgw.Rows[k].Cells[0].Value);
                textBox1.Text = herramientas_dgw.Rows[k].Cells[1].Value.ToString();
                textBox2.Text = herramientas_dgw.Rows[k].Cells[2].Value.ToString();
                textBox1.Enabled = true;
                textBox2.Enabled = true;

                editar = true;
            }
        }






        private void barra1_click_eliminar_button()
        {
            if (cambio)
            {
                int k = herramientas_dgw.CurrentRow.Index;
                id = Convert.ToInt32(herramientas_dgw.Rows[k].Cells[0].Value);
                if (MessageBox.Show("Desea eliminar el registro", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    db.eliminar("herramientas", "cod_herramientas=" + id);
                    consulta();
                }
            }
        }






        private void areas_dgw_SelectionChanged(object sender, EventArgs e)
        {
            cambio = true;
        }





        private void herramientas_Load(object sender, EventArgs e)
        {
            consulta();
        }
    }
}
