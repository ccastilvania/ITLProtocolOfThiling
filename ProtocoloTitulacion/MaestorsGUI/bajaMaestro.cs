using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProtocoloTitulacion.MaestorsGUI
{
    public partial class bajaMaestro : Form
    {
        public bajaMaestro()
        {
            InitializeComponent();
        }

        private void bajaMaestro_Load(object sender, EventArgs e)
        {
            new funciones.ABalumnos().mostrarProfesores(cbMaestro);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string valor3 = cbMaestro.SelectedValue.ToString();
                new funciones.ABalumnos().baja_profesor(valor3, cbMaestro);
            }
            catch (Exception ex)
            {
                MessageBox.Show("no hay alumnos");
            }
        }
    }
}
