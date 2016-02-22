using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data.SqlClient;

namespace ProtocoloTitulacion
{

    /// <summary>
    /// Descripcion this class
    /// </summary>
    public partial class GeneradorPdf : Form
    {
        public GeneradorPdf()
        {
            InitializeComponent();
            button1.Enabled = false;
        }

        private void GeneradorPdf_Load(object sender, EventArgs e)
        {
            //cargarDatos();
            new funciones.ABalumnos().cargaralumnos(comboBox1);
        }


        public void cargarDatos()
        {
            //Conexion a la base de datos
            //--------
            string conexion = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\Angel\\Documents\\SharpDevelop Projects\\ProtocoloTitulacion\\ProtocoloTitulacion\\ProcessofTitling.mdf; Integrated Security = True";
            SqlConnection miconexion = new SqlConnection(conexion);
            miconexion.Open();

            SqlCommand comando_consulta = new SqlCommand("SELECT alu_NControl FROM alumno",miconexion);
            comando_consulta.ExecuteNonQuery();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comando_consulta);
            da.Fill(ds, "alumno");
            DataRow DR;
            DR = ds.Tables["alumno"].Rows[0];
            comboBox1.Items.Add(DR["alu_NControl"].ToString());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string asesor = textBox1.Text;
            string secretario = textBox2.Text;
            string vocal = textBox3.Text;
            string Suplente = textBox4.Text;
            string NC = comboBox1.SelectedValue.ToString();
            string nombre = funciones.busquedas.getnombre(NC);
            new funciones.pdf().generarPDF(NC,asesor,secretario,vocal,Suplente,nombre);  
        }

        private void comboBox1_ValueMemberChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_VisibleChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// /////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            new funciones.busquedas().limpiar(label1,label2,label3,label4);
            string valor = comboBox1.SelectedValue.ToString();
            //new funciones.busquedas().buscarDatos(valor,label1,label2,label3,label4);
            new funciones.busquedas().buscarDatos(valor, textBox1, textBox2, textBox3, textBox4,button1);
        }
    }
}
