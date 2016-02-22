using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace ProtocoloTitulacion.funciones
{
    class ABalumnos
    {

        /*
        
            new SqlCommand("DELETE Alumnos WHERE id=@IdAlumno",conexion)
            SqlCommand.CommandType = StoredProcedure.
            SqlComand.Parameters.AddWithValue("@IdAlumno",Textcodigo.Text) 
            */

        ///<summary>
        /// Metodo para dar de alta un alumno
        /// </summary>
        public void alta_alumno(string NControl, string nombre, string ApePaterno, string ApeMaterno, string NomProject,string asesor)
        {
            //--------
            //Conexion a la base de datos
            //--------
            string conexion = ConfigurationManager.ConnectionStrings["dbconexion"].ToString();
            //conexion = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\Angel\\Documents\\SharpDevelop Projects\\ProtocoloTitulacion\\ProtocoloTitulacion\\ProcessofTitling.mdf; Integrated Security = True";
            SqlConnection miconexion = new SqlConnection(conexion);
            miconexion.Open();

            //---
            //-Buscamos que el alumno no este registrado
            //---
            //---------
            //insertar alumno a la base de datos
            //---------
            SqlCommand comand_insertalu = new SqlCommand("insert into alumno values('" + NControl + "','" + nombre + "','" + ApePaterno + "','" + ApeMaterno + "','" + NomProject + "')", miconexion);
            comand_insertalu.ExecuteNonQuery();

            //-----
            //insertamos el nombre del asesor
            //-----
            string auxiliar;
            string consulta = "select prof_id from profesores where prof_Nombre = '"+asesor+"'";
            MessageBox.Show(consulta);
            SqlCommand comando = new SqlCommand(consulta,miconexion);
            comando.ExecuteNonQuery();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds, "profesores");
            DataRow DR;
            DR = ds.Tables["profesores"].Rows[0];
            if (DR["prof_id"].ToString() != null)
                auxiliar = DR["prof_id"].ToString();
            else
                auxiliar = "";

            int valor;
            string consultaid = "select top 1 aluProf_ID from alumnos_profesores Order by aluprof_ID Desc";
            SqlCommand id = new SqlCommand(consultaid,miconexion);
            id.ExecuteNonQuery();
            DataSet ds2 = new DataSet();
            SqlDataAdapter da2 = new SqlDataAdapter(id);
            da2.Fill(ds2, "alumnos_profesores");
            DataRow DR2;
            DR2 = ds2.Tables["alumnos_profesores"].Rows[0];
            if (DR2["aluProf_ID"].ToString() != null)
            {
                valor = Int32.Parse(DR2["aluProf_ID"].ToString());
                valor++;
            }
            else
                valor = 1;

            string insercion = "insert into alumnos_profesores values("+valor+","+auxiliar+",'"+NControl+"')";
            SqlCommand comand_insertarAsesor = new SqlCommand(insercion,miconexion);
            comand_insertarAsesor.ExecuteNonQuery();

            MessageBox.Show("Alumno agregado Correctamente");

            miconexion.Close();
        }

        ///<summary>
        /// Metodo para dar de baja un alumno
        /// </summary>
        /// <param name="alumno_baja">indice del alumno a dar de baja en el sistema</param>
        public void baja_alumno(string alumno_baja, ComboBox cb)
        {
            try
            {
                //--------
                //Conexion a la base de datos
                //--------
                string conexion = ConfigurationManager.ConnectionStrings["dbconexion"].ToString();
                //conexion = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\Angel\\Documents\\SharpDevelop Projects\\ProtocoloTitulacion\\ProtocoloTitulacion\\ProcessofTitling.mdf; Integrated Security = True";
                SqlConnection miconexion = new SqlConnection(conexion);
                miconexion.Open();
              //  MessageBox.Show(alumno_baja);
                //---------
                //eliminar alumno a la base de datos
                //---------
                //string consulta = "delete from alumno where alu_NControl ='123214'";
                SqlCommand delete = new SqlCommand("delete from alumno where alu_NControl ='"+alumno_baja+"'", miconexion);
                //SqlCommand delete = new SqlCommand(consulta,miconexion);
                delete.ExecuteNonQuery();
 
                cargaralumnos(cb);
                miconexion.Close();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.ToString());
            }
        }

        /// <summary>
        /// metodo para cargar unicamente los alumnos que se encuentran en la base de datos
        /// </summary>
        public void cargaralumnos(ComboBox cb)
        {
            
            //------------
            //Conexion a la base de datos
            //-----------
            string conexion = ConfigurationManager.ConnectionStrings["dbconexion"].ToString();
            // conexion = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\Angel\\Documents\\SharpDevelop Projects\\ProtocoloTitulacion\\ProtocoloTitulacion\\ProcessofTitling.mdf; Integrated Security = True";
            //SqlConnection miconexion = new SqlConnection(conexion);
            //miconexion.Open();
            SqlConnection conexion2 = new SqlConnection(conexion);
            conexion2.Open();
            //-------
            //Cargamos solo los alumnos de la base de datos
            //-------
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = "select alu_NControl from alumno";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

            }           
            try {
               
                SqlCommand comand_id = new SqlCommand("select TOP 1 alu_NControl from alumno", conexion2);
                comand_id.ExecuteNonQuery();
                DataSet ds2 = new DataSet();
                SqlDataAdapter da2 = new SqlDataAdapter(comand_id);
                da2.Fill(ds2, "alumno");
                DataRow DR2;

                DR2 = ds2.Tables["alumno"].Rows[0];
                cb.ValueMember = "alu_NControl";
                cb.DataSource = dt;
            }
            catch (Exception ex) { cb.Text = ""; }
        }

        ///<summary>
        /// Metodo para cargar tdos los alumnos
        /// </summary>
        public void mostrarAlumnos(DataGridView dgv)
        {
            //----------------
            //Conexion a la base de datos
            //----------------
            string conexion = ConfigurationManager.ConnectionStrings["dbconexion"].ToString();
            //conexion = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\Angel\\Documents\\SharpDevelop Projects\\ProtocoloTitulacion\\ProtocoloTitulacion\\ProcessofTitling.mdf; Integrated Security = True";
            SqlConnection miconexion = new SqlConnection(conexion);
            miconexion.Open();

            //----------
            //Consulta a la base de datos
            //----------
            SqlCommand cmd = new SqlCommand("Select * from alumno", miconexion);
            SqlDataAdapter datadapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            datadapter.Fill(ds);
            dgv.DataSource = ds.Tables[0];
            miconexion.Close();

        }

        ///<summary>
        /// metodo para dar de alta al profesor
        /// </summary>
        /// 
        public void alta_profesor(TextBox prof_num_tarjeta, TextBox prof_Nombre, TextBox prof_ApePaterno, TextBox prof_ApeMaterno,TextBox prof_Area/*,TextBox prof_Horas*/)
        {

            try
            {


                //--------
                //Conexion a la base de datos
                //--------
                string conexion;
                //conexion = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\Angel\\Documents\\SharpDevelop Projects\\ProtocoloTitulacion\\ProtocoloTitulacion\\ProcessofTitling.mdf; Integrated Security = True";
                conexion = ConfigurationManager.ConnectionStrings["dbconexion"].ToString();
                SqlConnection miconexion = new SqlConnection(conexion);
                miconexion.Open();

                //MessageBox.Show("conexion establecida");


                int id = 0;
                string consultaid = "select TOP 1 prof_ID from profesores ORDER BY prof_ID DESC";
                SqlCommand consulta_id = new SqlCommand(consultaid, miconexion);
                consulta_id.ExecuteNonQuery();
                //MessageBox.Show(consultaid);
                DataSet ds2 = new DataSet();
                SqlDataAdapter da2 = new SqlDataAdapter(consulta_id);
                da2.Fill(ds2, "profesores");
                DataRow DR2;
                DR2 = ds2.Tables["profesores"].Rows[0];
                if (DR2["prof_ID"].ToString() != null)
                {
                    id = Int32.Parse(DR2["prof_ID"].ToString());
                    id++;
                }
                else
                    id = 1;

                //---------
                //insertar alumno a la base de datos
                //---------

                //string cadena = "insert into profesores (prof_ID,prof_num_tarjeta,prof_Nombre,prof_Apepaterno,prof_ApeMaterno,prof_Area) values (1," + "'" + prof_num_tarjeta.Text + "','" + prof_Nombre.Text + "','" + prof_ApePaterno.Text + "','" + prof_ApeMaterno.Text + "','" + prof_Area.Text + "');";
                string cadena = "insert into profesores (prof_ID,prof_num_tarjeta,prof_Nombre,prof_Apepaterno,prof_ApeMaterno,prof_Horas) values ('"+id+"'," + "'" + prof_num_tarjeta.Text + "','" + prof_Nombre.Text + "','" + prof_ApePaterno.Text + "','" + prof_ApeMaterno.Text + "','" + prof_Area.Text + "');";
                //MessageBox.Show(cadena);
                SqlCommand comando = new SqlCommand(cadena,miconexion);
                comando.ExecuteNonQuery();
                miconexion.Close();
                MessageBox.Show("Profesor dado de alta exitosamente");

 
            }
            catch
            {
                MessageBox.Show("Verifique que los datos sean correctos", "Error en los Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                prof_num_tarjeta.Focus();
            }
        }

        ///<summary>
        /// metodo para dar de baja al profesor
        /// </summary>
        /// 
        public void baja_profesor(string maestro_baja, ComboBox cb)
        {

            try
            {
                //--------
                //Conexion a la base de datos
                //--------
                string conexion = ConfigurationManager.ConnectionStrings["dbconexion"].ToString();
                //conexion = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\Angel\\Documents\\SharpDevelop Projects\\ProtocoloTitulacion\\ProtocoloTitulacion\\ProcessofTitling.mdf; Integrated Security = True";
                SqlConnection miconexion = new SqlConnection(conexion);
                miconexion.Open();
                MessageBox.Show(maestro_baja);
                //---------
                //eliminar alumno a la base de datos
                //---------
                //string consulta = "delete from alumno where alu_NControl ='123214'";
                SqlCommand delete = new SqlCommand("delete from profesores where prof_num_tarjeta ='" + maestro_baja + "'", miconexion);
                //SqlCommand delete = new SqlCommand(consulta,miconexion);
                delete.ExecuteNonQuery();

                mostrarProfesores(cb);
                miconexion.Close();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.ToString());
            }

        }

        ///<summary>
        /// Cargar Maestros en un comboBox
        /// </summary>
        public void mostrarProfesores(ComboBox cb)
        {
            //------------
            //Conexion a la base de datos
            //-----------
            string conexion = ConfigurationManager.ConnectionStrings["dbconexion"].ToString();
            //conexion = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\Angel\\Documents\\SharpDevelop Projects\\ProtocoloTitulacion\\ProtocoloTitulacion\\ProcessofTitling.mdf; Integrated Security = True";

            SqlConnection conexion2 = new SqlConnection(conexion);
            conexion2.Open();
            //-------
            //Cargamos solo los alumnos de la base de datos
            //-------
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = "select prof_num_tarjeta from profesores";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

            }
            try
            {
                SqlCommand comand_id = new SqlCommand("select TOP 1 prof_num_tarjeta from profesores", conexion2);
                comand_id.ExecuteNonQuery();
                DataSet ds2 = new DataSet();
                SqlDataAdapter da2 = new SqlDataAdapter(comand_id);
                da2.Fill(ds2, "profesores");
                DataRow DR2;

                DR2 = ds2.Tables["profesores"].Rows[0];
                cb.ValueMember = "prof_num_tarjeta";
                cb.DataSource = dt;
            }
            catch (Exception ex) { cb.Text = ""; }
        }

        /// <summary>
        /// metodo para cargar todos los profesores en un componente DataGridView
        /// </summary>
        /// <param name="dgv">Contenedor</param>
        public void cargarprofesores(DataGridView dgv)
        {
            //----------------
            //Conexion a la base de datos
            //----------------
            string conexion;
            //conexion = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\Angel\\Documents\\SharpDevelop Projects\\ProtocoloTitulacion\\ProtocoloTitulacion\\ProcessofTitling.mdf; Integrated Security = True";
            conexion  = ConfigurationManager.ConnectionStrings["dbconexion"].ToString();
            SqlConnection miconexion = new SqlConnection(conexion);
            miconexion.Open();

            //----------
            //Consulta a la base de datos
            //----------
            SqlCommand cmd = new SqlCommand("Select * from profesores", miconexion);
            SqlDataAdapter datadapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            datadapter.Fill(ds);
            dgv.DataSource = ds.Tables[0];
            miconexion.Close();
        }

    }
}
