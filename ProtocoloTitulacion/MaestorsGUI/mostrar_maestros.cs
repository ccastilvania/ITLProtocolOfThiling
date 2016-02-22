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
    public partial class mostrar_maestros : Form
    {
        public mostrar_maestros()
        {
            InitializeComponent();
        }

        private void mostrar_maestros_Load(object sender, EventArgs e)
        {
            new funciones.ABalumnos().cargarprofesores(dataGridView1);
        }
    }
}
