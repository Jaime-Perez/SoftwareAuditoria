using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software___Auditoria
{
    public partial class MDI : Form
    {
        public MDI()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Login lgg = new Login();
            lgg.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            empresas em = new empresas();
            em.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            normas nr = new normas();
            nr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            auditoria ad = new auditoria();
            ad.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            responsables rp = new responsables();
            rp.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            actividades at = new actividades();
            at.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            encargados ed = new encargados();
            ed.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            objetivos ob = new objetivos();
            ob.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            herramientas hm = new herramientas();
            hm.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            areas are = new areas();
            are.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            herramientas_asignadas ha = new herramientas_asignadas();
            ha.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            calificacion em = new calificacion();
            em.Show();
        }
    }
}
