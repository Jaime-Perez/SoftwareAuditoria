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
    public partial class areas : Form
    {
        public areas()
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
            string query = "select cod_area, nombre_area, descripcion_area from areas";
            areas_dgw.DataSource = db.consulta_DataGridView(query);
            areas_dgw.Columns[0].Visible = true;
            areas_dgw.Focus();
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
            string tabla = "areas";
            Dictionary<string, string> d = new Dictionary<string, string>();

            d.Add("nombre_area", textBox1.Text);
            d.Add("descripcion_area", textBox2.Text);

            if (nuevo)
            {
                db.insertar(tabla, d);
                nuevo = false;
                consulta();
                limpiar();
            }
            if (editar)
            {
                db.actualizar(tabla, d, "cod_area=" + id);
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
                textBox1.Text = areas_dgw.Rows[k].Cells[1].Value.ToString();
                textBox2.Text = areas_dgw.Rows[k].Cells[2].Value.ToString();
                textBox1.Enabled = true;
                textBox2.Enabled = true;

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
                    db.eliminar("areas", "cod_area=" + id);
                    consulta();
                }
            }
        }






        private void encargados_dgw_SelectionChanged(object sender, EventArgs e)
        {
            cambio = true;
        }




        private void herramientas_Load(object sender, EventArgs e)
        {
            consulta();
        }
    }
}
