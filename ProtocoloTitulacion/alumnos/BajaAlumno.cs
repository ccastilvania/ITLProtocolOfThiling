using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProtocoloTitulacion.alumnos
{
    public partial class BajaAlumno : Form
    {
        public BajaAlumno()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                string valor3 = cbAlumnos.SelectedValue.ToString();
                //MessageBox.Show(valor3.ToString());
                new funciones.ABalumnos().baja_alumno(valor3, cbAlumnos);
                new funciones.ABalumnos().cargaralumnos(cbAlumnos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("no hay alumnos");
            }
        }

        private void BajaAlumno_Load(object sender, EventArgs e)
        {

            new funciones.ABalumnos().cargaralumnos(cbAlumnos);
        }
    }
}
