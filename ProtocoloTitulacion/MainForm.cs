/*
 * Created by SharpDevelop.
 * User: Angel
 * Date: 29/09/2015
 * Time: 08:08 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

using System.Configuration;

namespace ProtocoloTitulacion
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		//evento para terminar la aplicacion
		void Button2Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
		//evento para logearse 
		void Button1Click(object sender, EventArgs e)
		{
			string usuario = textBox1.Text.ToString();
			string pass = textBox2.Text.ToString();
            int auxiliar;
            usuario.ToLower();
            pass.ToLower();
            if (funciones.Security.login(usuario,pass)){

                #region Consulta usuario

                //--------
                //Conexion a la base de datos
                //--------
                //string conexion = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\Angel\\Documents\\SharpDevelop Projects\\ProtocoloTitulacion\\ProtocoloTitulacion\\ProcessofTitling.mdf; Integrated Security = True";
                //SqlConnection miconexion = new SqlConnection(conexion);
                SqlConnection miconexion = new SqlConnection();
                //miconexion.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\Angel\\Documents\\SharpDevelop Projects\\ProtocoloTitulacion\\ProtocoloTitulacion\\ProcessofTitling.mdf; Integrated Security = True";
                miconexion.ConnectionString = ConfigurationManager.ConnectionStrings["dbconexion"].ToString();
                miconexion.Open();

                //-----
                //Buscamos el id del usuario que se logeo
                //-----
                SqlCommand comando2 = new SqlCommand("select usr_ID from usuarios where usr_Nombre = '"+ usuario+"' ",miconexion);
                comando2.ExecuteNonQuery();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comando2);
                da.Fill(ds, "usuarios");
                DataRow DR;
                DR = ds.Tables["usuarios"].Rows[0];
                if (DR["usr_ID"].ToString() != null)
                    auxiliar = Int32.Parse(DR["usr_ID"].ToString());
                else
                    auxiliar = 0;
                #endregion

                #region Consulta ID de la sesion

                int valor=0;
                SqlCommand id = new SqlCommand("select TOP 1 ses_ID from sessiones ORDER BY ses_ID DESC",miconexion);
                id.ExecuteNonQuery();
                DataSet ds2 = new DataSet();
                SqlDataAdapter da2 = new SqlDataAdapter(id);
                da2.Fill(ds2,"sessiones");
                DataRow DR2;
                DR2 = ds2.Tables["sessiones"].Rows[0];
                if (DR2["ses_ID"].ToString() != null)
                {
                    valor = Int32.Parse(DR2["ses_ID"].ToString());
                    valor++;
                }
                else
                    valor = 1;

                #endregion

                //-------
                //Agregar el inicio de la session a la base de datos
                //-------
                DateTime fecha = DateTime.Now;
                SqlCommand comando = new SqlCommand("insert into sessiones values ("+valor+",'"+fecha.ToString()+"','"+fecha.ToString()+"',"+ auxiliar + ") ", miconexion);
                comando.ExecuteNonQuery();

                //--------
                //Mandamos llamar la ventana principal del proyecto
                //--------
                Main principal = new Main(valor);
				principal.Show();
				this.Visible=false;
                //---------
                //
                //---------
			}
			else{
				MessageBox.Show("Error el usuario y contraseña son incorrectos","Error Inicio de Session",MessageBoxButtons.OK,MessageBoxIcon.Error);
				textBox1.Text="";
				textBox2.Text="";
			
			}
		}

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}
