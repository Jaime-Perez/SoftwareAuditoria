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
    public partial class encargados : Form
    {
        public encargados()
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
            string query = "select cod_encargado, nombre_encargado, telefono_encargado, correo_encargado, rol_encargado from encargado";
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
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            nuevo = true;
        }










        private void barra1_click_guardar_button()
        {
            string tabla = "encargado";
            Dictionary<string, string> d = new Dictionary<string, string>();

            d.Add("nombre_encargado", textBox1.Text);
            d.Add("telefono_encargado", textBox2.Text);
            d.Add("correo_encargado", textBox3.Text);
            d.Add("rol_encargado", textBox4.Text);

            if (nuevo)
            {
                db.insertar(tabla, d);
                nuevo = false;
                consulta();
                limpiar();
            }
            if (editar)
            {
                db.actualizar(tabla, d, "cod_encargado=" + id);
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
                    db.eliminar("encargado", "cod_encargado=" + id);
                    consulta();
                }
            }
        }






        private void encargados_dgw_SelectionChanged(object sender, EventArgs e)
        {
            cambio = true;
        }



        private void encargados_Load(object sender, EventArgs e)
        {
            consulta();
        }

        
    }
}
