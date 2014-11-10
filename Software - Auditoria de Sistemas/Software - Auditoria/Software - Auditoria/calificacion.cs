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
    public partial class calificacion : Form
    {

        DBConnect db = new DBConnect("auditoria");

        public calificacion()
        {
            InitializeComponent();

            objetivo_combo.DataSource =  db.consulta_ComboBox("select cod_actividad,nombre_actividad from actividades");
            objetivo_combo.ValueMember = "cod_actividad";
            objetivo_combo.DisplayMember = "nombre_actividad";

            auditor_combo.DataSource = db.consulta_ComboBox("select cod_encargado, nombre_encargado from encargado");
            auditor_combo.ValueMember = "cod_encargado";
            auditor_combo.DisplayMember = "nombre_encargado";

            autor_combo.DataSource = db.consulta_ComboBox("select cod_responsable, nombre_responsable from responsables");
            autor_combo.ValueMember = "cod_responsable";
            autor_combo.DisplayMember = "nombre_responsable";

            empresa_combo.DataSource = db.consulta_ComboBox("select cod_empresa,nombre_empresa from empresa");
            empresa_combo.ValueMember = "cod_empresa";
            empresa_combo.DisplayMember = "nombre_empresa";

            textBox1.Focus();

            Consultar();
        }

        private void Consultar()
        {
            string query = "select e.nombre_empresa as 'Empresa', a.nombre_actividad as 'Actividad', r.nombre_responsable as 'Auditor', enc.nombre_encargado as 'Encargado', aud.ponderacion as 'Ponderacion'";
            query+=" from empresa e, actividades a, responsables r, encargado enc, auditoria aud";
            query+=" where aud.empresa_cod_empresa=e.cod_empresa and aud.actividades_cod_actividad=a.cod_actividad and aud.responsables_cod_responsa = r.cod_responsable and aud.encargado_cod=enc.cod_encargado";
            dgw_calificacion.DataSource = db.consulta_DataGridView(query);
            dgw_calificacion.Columns[0].Visible = true;
            dgw_calificacion.Focus();
        }
        

        private void calificacion_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void limpiar()
        {
            
        }

        private void barra1_Load(object sender, EventArgs e)
        {

        
          
        
        }

        private void barra1_click_nuevo_button()
        {
            objetivo_combo.Enabled = true;
        }

        private void barra1_click_guardar_button()
        {
            string tabla = "auditoria";
            Dictionary<string, string> d = new Dictionary<string, string>();

            d.Add("empresa_cod_empresa", empresa_combo.SelectedValue.ToString());
            d.Add("actividades_cod_actividad", objetivo_combo.SelectedValue.ToString());
            d.Add("responsables_cod_responsa", autor_combo.SelectedValue.ToString());
            d.Add("encargado_cod", auditor_combo.SelectedValue.ToString());
            d.Add("ponderacion", textBox1.Text);

            db.insertar(tabla, d);

            textBox1.Text = "";
        }

        private void barra1_click_editar_button()
        {
            
        }

        private void barra1_click_buscar_button()
        {
            Consultar();
        }


        
    }

}
