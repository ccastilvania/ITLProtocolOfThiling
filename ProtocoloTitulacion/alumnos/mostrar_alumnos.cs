using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProtocoloTitulacion
{
    public partial class mostrar_alumnos : Form
    {
        public mostrar_alumnos()
        {
            InitializeComponent();
        }

        private void mostrar_alumnos_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        public void cargarDatos()
        {
            new funciones.ABalumnos().mostrarAlumnos(dataGridView1);
        }
    }
}
