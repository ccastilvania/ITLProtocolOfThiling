/*
 * Created by SharpDevelop.
 * User: Angel
 * Date: 29/09/2015
 * Time: 10:15 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace ProtocoloTitulacion.funciones
{
	/// <summary>
	/// Description of Security.
	/// </summary>
	public class Security
	{
		public Security()
		{
			
		}
		///<summary>
		/// Metodo para validar el usuario de inicio de session
		/// </summary>
		/// <param name="user">Nombre del usuario</param>
		/// <param name="password">contraseña del usuario</param>
		public static Boolean login(string user,string password){
            Boolean result = true;
            try {
                string conexion = ConfigurationManager.ConnectionStrings["dbconexion"].ToString(); 
                //string conexion = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\Angel\\Documents\\SharpDevelop Projects\\ProtocoloTitulacion\\ProtocoloTitulacion\\ProcessofTitling.mdf; Integrated Security = True";
                //creamos la conexion
                SqlConnection miconexion = new SqlConnection(conexion);
                //abrimos la conexion
                miconexion.Open();
                SqlCommand comando = new SqlCommand("select usr_Nombre,usr_pwd from usuarios where usr_Nombre = '" + user + "' and usr_pwd = '" + password + "' ", miconexion);
                //ejecutamos la instruccion de sql devolviendo el numero de las filas afectadas
                comando.ExecuteNonQuery();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comando);

                //llenamos el dataAdapter
                da.Fill(ds, "usuarios");
                //utilizado para representar una fila de la tabla q necesitas en este caso usuario
                DataRow DR;
                DR = ds.Tables["usuarios"].Rows[0];

                //evaluando que la contraseña y usuarios sean correctos
                if ((user == DR["usr_Nombre"].ToString()) || (password == DR["usr_pwd"].ToString()))
                {
                    //instanciando el formulario principal
                   result = true;
                }
            }
            catch
            {
                //retornamos el valor de la 
                MessageBox.Show("Error en la conexion hacia la base de datos","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                 result = false;
            }
            return result;
		}
	}
}
