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
    public partial class responsables : Form
    {
        public responsables()
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
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }









        private void consulta()
        {
            string query = "select cod_responsable, nombre_responsable, telefono_responsable, correo_responsable, rol_responsable from responsables";
            encargados_dgw.DataSource = db.consulta_DataGridView(query);
            encargados_dgw.Columns[0].Visible = true;
            encargados_dgw.Focus();
        }






        private void barra1_click_nuevo_button()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox1.Enabled = true ;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            nuevo = true;
        }









        private void barra1_click_guardar_button()
        {
            string tabla = "responsables";
            Dictionary<string, string> d = new Dictionary<string, string>();

            d.Add("nombre_responsable", textBox1.Text);
            d.Add("telefono_responsable", textBox2.Text);
            d.Add("correo_responsable", textBox3.Text);
            d.Add("rol_responsable", textBox4.Text);

            if (nuevo)
            {
                db.insertar(tabla, d);
                nuevo = false;
                consulta();
                limpiar();
            }
            if (editar)
            {
                db.actualizar(tabla, d, "cod_responsable=" + id);
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
                int k = encargados_dgw.CurrentRow.Index;
                id = Convert.ToInt32(encargados_dgw.Rows[k].Cells[0].Value);
                textBox1.Text = encargados_dgw.Rows[k].Cells[1].Value.ToString();
                textBox2.Text = encargados_dgw.Rows[k].Cells[2].Value.ToString();
                textBox3.Text = encargados_dgw.Rows[k].Cells[3].Value.ToString();
                textBox4.Text = encargados_dgw.Rows[k].Cells[4].Value.ToString();
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;

                editar = true;
            }
        }






        private void barra1_click_eliminar_button()
        {
            if (cambio)
            {
                int k = encargados_dgw.CurrentRow.Index;
                id = Convert.ToInt32(encargados_dgw.Rows[k].Cells[0].Value);
                if (MessageBox.Show("Desea eliminar el registro", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    db.eliminar("responsables", "cod_responsable=" + id);
                    consulta();
                }
            }
        }








        private void encargados_dgw_SelectionChanged(object sender, EventArgs e)
        {
            cambio = true;
        }





        private void responsables_Load(object sender, EventArgs e)
        {
            consulta();
        }
    }
}
