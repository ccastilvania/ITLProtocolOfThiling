using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProtocoloTitulacion
{
    public partial class alumno : Form
    {
        public alumno()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string num_control = textBox1.Text;
            string nombre = textBox2.Text;
            string apellido_paterno = textBox3.Text;
            string apellido_materno = textBox4.Text;
            string nom_projecto = textBox5.Text;
            string asesor = txtAsesor.Text;

           // MessageBox.Show(asesor);
            funciones.ABalumnos ab = new funciones.ABalumnos();
            ab.alta_alumno(num_control, nombre, apellido_paterno, apellido_materno, nom_projecto,asesor);
            limpiar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
            this.Visible = false;

        }

        public void limpiar()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            txtAsesor.Clear();

        }
        private void alumno_Load(object sender, EventArgs e)
        {

        }
    }
}
