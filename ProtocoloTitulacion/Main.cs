/*
 * User: Angel
 * Date: 29/09/2015
 * Time: 08:16 a. m.
 * 
/*/
using System;
using System.Drawing;
using System.Windows.Forms;

/*Librerias para Abrir y Generar el pdf*/
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Data.SqlClient;
using System.Data.OleDb;


namespace ProtocoloTitulacion
{
	/// <summary>
	/// Description of Main.
	/// </summary>
	public partial class Main : Form
	{
        int GLOBAL_USR;
		public Main(int sessionID)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
            GLOBAL_USR = sessionID;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		void LogoutToolStripMenuItemClick(object sender, EventArgs e)
		{
            //--------
            //Conexion a la base de datos
            //--------
            string conexion = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\Angel\\Documents\\SharpDevelop Projects\\ProtocoloTitulacion\\ProtocoloTitulacion\\ProcessofTitling.mdf; Integrated Security = True";
            SqlConnection miconexion = new SqlConnection(conexion);
            miconexion.Open();

            //-------
            // Actualizacion de la tabla sesssiones en el campo de ses_logout
            //-------
            DateTime fecha_cierresession = DateTime.Now;
            SqlCommand comando = new SqlCommand("UPDATE sessiones SET ses_fin = '" + fecha_cierresession.ToString() +"' WHERE ses_ID = "+ GLOBAL_USR+" ",miconexion);
            comando.ExecuteNonQuery();
            //------
            //Cerramos la ventana activa y mandamos llamr la ventana de login
            //------
            this.Visible=false;
			MainForm login = new MainForm();
			login.Visible=true;

		}

		void MainFormClosed(object sender, FormClosedEventArgs e)
		{
			MessageBox.Show("Estas cerrando la aplicacion","Warning",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
			Application.Exit();				

		}

		void MaestrosToolStripMenuItemClick(object sender, EventArgs e)
		{
			
		}

		void GenerarOficioToolStripMenuItemClick(object sender, EventArgs e)
		{
            //objeto que manda llamar a la forma pdf
            GeneradorPdf pdf = new GeneradorPdf();
            pdf.Show();
		}

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            //--------
            //Conexion a la base de datos
            //--------
            string conexion = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\Angel\\Documents\\SharpDevelop Projects\\ProtocoloTitulacion\\ProtocoloTitulacion\\ProcessofTitling.mdf; Integrated Security = True";
            SqlConnection miconexion = new SqlConnection(conexion);
            miconexion.Open();

            //--------
            //Consultamos la base de datos y sacamos los registros
            //--------
            //SqlCommand comando = new SqlCommand("",miconexion);
            //comando.ExecuteNonQuery();
        }

        private void busquedaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Search busqueda = new Search();
            //busqueda.Show();
        }

        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        //Importar de Excel a DatagridView
        private void importarAExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new funciones.Importar().importarExcel(dataGridView1,"hoja1");
            new funciones.Importar().importarDataBase(dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void altasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            alumno alumno = new alumno();
            alumno.Show();
        }

        private void mostrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mostrar_alumnos mostrar = new mostrar_alumnos();
            mostrar.Show();
        }

        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new funciones.Importar().ExportarExcel(dataGridView1);
        }

        private void bajasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            alumnos.BajaAlumno bajaalumno = new alumnos.BajaAlumno();
            bajaalumno.Show();
                
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaestorsGUI.altaMaestro alta = new MaestorsGUI.altaMaestro();
            alta.Show();
        }

        private void bajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaestorsGUI.bajaMaestro baja = new MaestorsGUI.bajaMaestro();
            baja.Show();
            
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrosGUI.NuevoRegistro nuevo = new RegistrosGUI.NuevoRegistro();
            nuevo.Show();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrosGUI.BuscarRegistro buscar = new RegistrosGUI.BuscarRegistro();
            buscar.Show();
        }

        private void mostrarProfesoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaestorsGUI.mostrar_maestros mostrar = new MaestorsGUI.mostrar_maestros();
            mostrar.Show();
        }
    }
}
