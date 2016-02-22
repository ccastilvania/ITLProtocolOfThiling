using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProtocoloTitulacion.RegistrosGUI
{
    public partial class BuscarRegistro : Form
    {
        public BuscarRegistro()
        {
            InitializeComponent();
        }

        private void BuscarRegistro_Load(object sender, EventArgs e)
        {
            new funciones.busquedas().llenarcombo(cbControl);
        }

        /// <summary>
        /// boton para buscar un alumno en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            string NControl = txtControl.Text ;
            string nombr = txtnombre.Text;
            string aPaterno = txtpaterno.Text;
            string aMaterno = txtmaterno.Text;
            string asesor = txtasesor.Text;
            string secretario = txtsecretario.Text;
            string vocal = txtvocal.Text;
            string suplente =txtsuplente.Text;


            string valor = cbControl.SelectedValue.ToString();
            new funciones.busquedas().buscar_alumnos(valor,txtControl,txtnombre,txtpaterno,txtmaterno,txtasesor,txtsecretario,txtvocal,txtsuplente, txtproyecto,button2);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtControl_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// metodo para atualizar los datos de la tabla de aumnos 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click_1(object sender, EventArgs e)
        {
            string valor = cbControl.SelectedValue.ToString();
            new funciones.busquedas().actualizarAlumnos(valor, txtControl, txtnombre, txtpaterno, txtmaterno, txtproyecto, button2,txtasesor);
        }
    }
}
