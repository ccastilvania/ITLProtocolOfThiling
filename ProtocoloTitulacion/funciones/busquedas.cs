using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;


namespace ProtocoloTitulacion.funciones
{
    /// <summary>
    /// Esta clase provee de funciones de busqueda
    /// para identificar maestros y alumnos
    /// </summary>
    class busquedas
    {

        

        public void buscarDatos(string valor, TextBox asesor, TextBox secretario, TextBox Suplente, TextBox Vocal,Button btnGenerar)
        {
            try {
                //---------
                //Conexion a la base de datos
                //---------
                string conexion = ConfigurationManager.ConnectionStrings["dbconexion"].ToString();
                SqlConnection miconexion = new SqlConnection(conexion);
                miconexion.Open();

                //------
                //Realizamos las consultas
                //-------

                //----
                // consulta asesor
                //----
                string auxiliar;
                string consultaAsesor = "select prof_Nombre from profesores where prof_ID  in (select aluProf_PROFESOR from alumnos_profesores where aluProf_ALUMNO = '" + valor + "')";
                SqlCommand comadnoAsesor = new SqlCommand(consultaAsesor, miconexion);
                comadnoAsesor.ExecuteNonQuery();
                DataSet dsAsesor = new DataSet();
                SqlDataAdapter daAsesor = new SqlDataAdapter(comadnoAsesor);
                daAsesor.Fill(dsAsesor, "profesores");
                DataRow DR;
                DR = dsAsesor.Tables["profesores"].Rows[0];
                if (DR["prof_Nombre"].ToString() != null)
                    auxiliar = DR["prof_Nombre"].ToString();
                //auxiliar = Int32.Parse(DR["usr_ID"].ToString());
                else
                    auxiliar = "";
                asesor.Text = auxiliar;
                //----
                //consulta suplente
                //----
                string consultaSuplente = "select prof_Nombre from profesores where prof_ID  in (select fk_ProfesoresID from profesorSuplente where fk_alumnoID = '" + valor + "')";
                SqlCommand comandoSuplente = new SqlCommand(consultaSuplente, miconexion);
                comandoSuplente.ExecuteNonQuery();
                DataSet dsSuplente = new DataSet();
                SqlDataAdapter daSuplente = new SqlDataAdapter(comandoSuplente);
                daSuplente.Fill(dsSuplente, "profesores");
                DataRow DRSuplente;
                DRSuplente = dsSuplente.Tables["profesores"].Rows[0];
                if (DRSuplente["prof_Nombre"].ToString() != null)
                    auxiliar = DRSuplente["prof_Nombre"].ToString();
                //auxiliar = Int32.Parse(DR["usr_ID"].ToString());
                else
                    auxiliar = "";
                Suplente.Text = auxiliar;
                //----
                //consulta secretario
                //----
                string consultaSecretario = "select prof_Nombre from profesores where prof_ID  in (select fk_ProfesoresID from profesorSecretario where fk_alumnoID = '" + valor + "')";
                SqlCommand comandoSecretario = new SqlCommand(consultaSecretario, miconexion);
                comandoSecretario.ExecuteNonQuery();
                DataSet dsSecretario = new DataSet();
                SqlDataAdapter daSecretario = new SqlDataAdapter(comandoSecretario);
                daSecretario.Fill(dsSecretario, "profesores");
                DataRow DRSecretario;
                DRSecretario = dsSecretario.Tables["profesores"].Rows[0];
                if (DRSecretario["prof_Nombre"].ToString() != null)
                    auxiliar = DRSecretario["prof_Nombre"].ToString();
                //auxiliar = Int32.Parse(DR["usr_ID"].ToString());
                else
                    auxiliar = "";
                secretario.Text = auxiliar;
                //----
                //consulta vocal
                //----
                string consultaVocal = "select prof_Nombre from profesores where prof_ID  in (select fk_ProfesoresID from profesorVocal where fk_alumnoID = '" + valor + "')";
                SqlCommand comandoVocal = new SqlCommand(consultaVocal, miconexion);
                comandoVocal.ExecuteNonQuery();
                DataSet dsVocal = new DataSet();
                SqlDataAdapter daVocal = new SqlDataAdapter(comandoVocal);
                daVocal.Fill(dsVocal, "profesores");
                DataRow DRVocal;
                DRVocal = dsVocal.Tables["profesores"].Rows[0];
                if (DRVocal["prof_Nombre"].ToString() != null)
                    auxiliar = DRVocal["prof_Nombre"].ToString();
                //auxiliar = Int32.Parse(DR["usr_ID"].ToString());
                else
                    auxiliar = "";
                Vocal.Text = auxiliar;

                miconexion.Close();
                btnGenerar.Enabled = true;
            }catch(Exception exe)  {
                MessageBox.Show("Error el alumno con el numero de control "+valor+" aun no tiene asignada su comision revisora","warning",MessageBoxButtons.OK,MessageBoxIcon.Error);
                btnGenerar.Enabled = false;
                asesor.Text = String.Empty;
                secretario.Text = String.Empty;
                Vocal.Text = String.Empty;
                Suplente.Text = String.Empty;
            }
        }


        ///<summary>
        /// metodo para restablecer el valor por default
        /// </summary>
        public void limpiar(Label asesor, Label secretario, Label Suplente, Label Vocal)
        {
            asesor.Text = "Presidente :";
            secretario.Text = "Secretario :";
            Suplente.Text = "Suplente :";
            Vocal.Text = "Vocal :";
        }

        ///<summary>
        /// Metodo para buscar datos de un alumno en especifico
        /// </summary>
        public void buscar_alumnos(string alumno,TextBox NControl, TextBox nombr, TextBox aPaterno, TextBox aMaterno, TextBox asesor, TextBox secretario, TextBox vocal, TextBox suplente,TextBox txtproyecto,Button actualizar)
        {
            try {

                string conexion = ConfigurationManager.ConnectionStrings["dbconexion"].ToString();
                SqlConnection miconexion = new SqlConnection(conexion);
                miconexion.Open();
                #region consultaalumno

                //---------
                //----
                // consulta asesor
                //----
                string auxcontrol;
                string auxnombre1;
                string auxpaterno1;
                string auxmaterno1;
                string auxproyecto;

                string consulta_alumno = "select * from alumno where alu_NControl = '"+alumno+"'";
                SqlCommand comandoalumno = new SqlCommand(consulta_alumno, miconexion);
                comandoalumno.ExecuteNonQuery();
                DataSet dsalumno = new DataSet();
                SqlDataAdapter daalumno = new SqlDataAdapter(comandoalumno);
                daalumno.Fill(dsalumno, "alumno");
                DataRow DRalumno;
                DRalumno = dsalumno.Tables["alumno"].Rows[0];
                if (DRalumno["alu_NControl"].ToString() != null)
                {
                    auxcontrol = DRalumno["alu_NControl"].ToString();
                    auxnombre1 = DRalumno["alu_Nombre"].ToString();
                    auxmaterno1 = DRalumno["Alu_ApeMAterno"].ToString();
                    auxpaterno1 = DRalumno["alu_ApePaterno"].ToString();
                    auxproyecto = DRalumno["alu_NomProyecto"].ToString();

                }
                else
                {
                    auxcontrol = "";
                    auxmaterno1 = "";
                    auxpaterno1 = "";
                    auxnombre1 = "";
                    auxproyecto = "";
                }

                NControl.Text = auxcontrol;
                nombr.Text = auxnombre1;
                aPaterno.Text = auxpaterno1;
                aMaterno.Text = auxmaterno1;
                txtproyecto.Text = auxproyecto;
                
                if(auxnombre1 == "")
                {
                    nombr.ReadOnly = false;
                    aPaterno.ReadOnly = false;
                    aMaterno.ReadOnly = false;
                    txtproyecto.ReadOnly = false;
                    asesor.ReadOnly = false;
                    actualizar.Enabled = true;
                    return;
                }
                else
                {
                    nombr.ReadOnly = true;
                    aPaterno.ReadOnly = true;
                    aMaterno.ReadOnly = true;
                    txtproyecto.ReadOnly = true;
                    asesor.ReadOnly = true;
                    actualizar.Enabled = false;   
                }
                #endregion

                #region comision revisora
                //---------
                //----
                // consulta asesor
                //----
                string auxiliar;
                string consulta_asesor = "select prof_Nombre from profesores where prof_ID  in (select aluProf_PROFESOR from alumnos_profesores where aluProf_ALUMNO = '"+alumno+"');";
                SqlCommand comadnoAsesor = new SqlCommand(consulta_asesor, miconexion);
                comadnoAsesor.ExecuteNonQuery();
                DataSet dsAsesor = new DataSet();
                SqlDataAdapter daAsesor = new SqlDataAdapter(comadnoAsesor);
                daAsesor.Fill(dsAsesor, "profesores");
                DataRow DR;
                DR = dsAsesor.Tables["profesores"].Rows[0];
                if (DR["prof_Nombre"].ToString() != null)
                    auxiliar = DR["prof_Nombre"].ToString();
                else
                    auxiliar = "";
                asesor.Text = auxiliar;

                //---------
                //----
                // consulta secretario
                //----
                string auxiliar2;
                string consulta_secretario = "select prof_Nombre from profesores where prof_ID  in (select fk_ProfesoresID from profesorSecretario where fk_alumnoID = '"+alumno+"');";
                SqlCommand comadnosecretario = new SqlCommand(consulta_secretario, miconexion);
                comadnoAsesor.ExecuteNonQuery();
                DataSet dssecretario = new DataSet();
                SqlDataAdapter dasecretario = new SqlDataAdapter(comadnosecretario);
                dasecretario.Fill(dssecretario, "profesores");
                DataRow DR2;
                DR2 = dssecretario.Tables["profesores"].Rows[0];
                if (DR2["prof_Nombre"].ToString() != null)
                    auxiliar2 = DR2["prof_Nombre"].ToString();
                else
                    auxiliar2= "";
                secretario.Text = auxiliar2;

                //---------
                //----
                // consulta vocal
                //----
                string auxiliar3;
                string consulta_vocal = "select prof_Nombre from profesores where prof_ID  in (select fk_ProfesoresID from profesorVocal where fk_alumnoID = '"+alumno+"')";
                SqlCommand comadnovocal = new SqlCommand(consulta_vocal, miconexion);
                comadnovocal.ExecuteNonQuery();
                DataSet dsvocal = new DataSet();
                SqlDataAdapter davocal = new SqlDataAdapter(comadnovocal);
                davocal.Fill(dsvocal, "profesores");
                DataRow DR3;
                DR3 = dsvocal.Tables["profesores"].Rows[0];
                if (DR3["prof_Nombre"].ToString() != null)
                    auxiliar3 = DR["prof_Nombre"].ToString();
                else
                    auxiliar3 = "";
                vocal.Text = auxiliar3;

                //---------
                //----
                // consulta suplente
                //----
                string auxiliar4;
                string consulta_suplente = "select prof_Nombre from profesores where prof_ID  in (select fk_ProfesoresID from profesorSuplente where fk_alumnoID = '"+alumno+"')";
                SqlCommand comadnosuplente = new SqlCommand(consulta_suplente, miconexion);
                comadnosuplente.ExecuteNonQuery();
                DataSet dssuplente = new DataSet();
                SqlDataAdapter dasuplente = new SqlDataAdapter(comadnosuplente);
                dasuplente.Fill(dssuplente, "profesores");
                DataRow DR4;
                DR4 = dssuplente.Tables["profesores"].Rows[0];
                if (DR4["prof_Nombre"].ToString() != null)
                    auxiliar4 = DR4["prof_Nombre"].ToString();
                else
                    auxiliar4 = "";
                suplente.Text = auxiliar4;

            } catch (Exception exe) { MessageBox.Show(exe.Message,"error"); };

            #endregion
        }

        public void actualizarAlumnos(string alumno, TextBox NControl, TextBox nombr, TextBox aPaterno, TextBox aMaterno, TextBox txtproyecto, Button actualizar)
        {
            string conexion = ConfigurationManager.ConnectionStrings["dbconexion"].ToString();
            SqlConnection miconexion = new SqlConnection(conexion);
            miconexion.Open();

            /*Actualizamos la tabla de alumnos*/
            string consulta_alumno = "update alumno set alu_Nombre = '"+nombr.Text+"',alu_ApePaterno='"+aPaterno.Text+"',alu_ApeMAterno = '"+aMaterno.Text+"',alu_NomProyecto = '"+txtproyecto.Text+"' where alu_NControl = '"+alumno+"'";
            SqlCommand comandoalumno = new SqlCommand(consulta_alumno, miconexion);
            comandoalumno.ExecuteNonQuery();

            MessageBox.Show("Alumno actualizado correctamente","Informacion",MessageBoxButtons.OK,MessageBoxIcon.Information);
            miconexion.Close();
        }

        /// <summary>
        /// metodo sobrecargado para alta de un alumno y un asesor a la bd
        /// </summary>
        /// <param name="alumno"></param>
        /// <param name="NControl"></param>
        /// <param name="nombr"></param>
        /// <param name="aPaterno"></param>
        /// <param name="aMaterno"></param>
        /// <param name="txtproyecto"></param>
        /// <param name="actualizar"></param>
        /// <param name="asesor"></param>
        public void actualizarAlumnos(string alumno, TextBox NControl, TextBox nombr, TextBox aPaterno, TextBox aMaterno, TextBox txtproyecto, Button actualizar,TextBox asesor)
        {
            string conexion = ConfigurationManager.ConnectionStrings["dbconexion"].ToString();
            SqlConnection miconexion = new SqlConnection(conexion);
            miconexion.Open();

            /*Actualizamos la tabla de alumnos*/
            string consulta_alumno = "update alumno set alu_Nombre = '" + nombr.Text + "',alu_ApePaterno='" + aPaterno.Text + "',alu_ApeMAterno = '" + aMaterno.Text + "',alu_NomProyecto = '" + txtproyecto.Text + "' where alu_NControl = '" + alumno + "'";
            SqlCommand comandoalumno = new SqlCommand(consulta_alumno, miconexion);
            comandoalumno.ExecuteNonQuery();

            /*actualizamos la tabla de alumnos_profesores*/
            //-----
            //insertamos el nombre del asesor
            //-----
            try {
                string auxiliar;
                string consulta = "select prof_id from profesores where prof_Nombre = '" + asesor.Text + "'";
                SqlCommand comando = new SqlCommand(consulta, miconexion);
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
            SqlCommand id = new SqlCommand(consultaid, miconexion);
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

            string insercion = "insert into alumnos_profesores values(" + valor + "," + auxiliar + ",'" + alumno + "')";
            SqlCommand comand_insertarAsesor = new SqlCommand(insercion, miconexion);
            comand_insertarAsesor.ExecuteNonQuery();

            }
            catch (Exception exe)
            {
                MessageBox.Show("El profesor que esta introduciendo no existe en la base de datos","Error de campos",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Alumno actualizado correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            miconexion.Close();
        }


        /// <summary>
        /// metodo que devuelve el nombre del alumno
        /// </summary>
        /// <param name="NControl">numero de control del alumno</param>
        public static string getnombre(string NControl)
        {
            string Nombre="";

            //Conexion a la base de datos
            string conexion = ConfigurationManager.ConnectionStrings["dbconexion"].ToString();
            SqlConnection miconexion = new SqlConnection(conexion);
            miconexion.Open();

            //consulta sql
            string auxiliar;
            string consultaAsesor = "select alu_Nombre from alumno where alu_NControl   = '" + NControl + "'";
            SqlCommand comadnoAsesor = new SqlCommand(consultaAsesor, miconexion);
            comadnoAsesor.ExecuteNonQuery();
            DataSet dsAsesor = new DataSet();
            SqlDataAdapter daAsesor = new SqlDataAdapter(comadnoAsesor);
            daAsesor.Fill(dsAsesor, "alumno");
            DataRow DR;
            DR = dsAsesor.Tables["alumno"].Rows[0];
            if (DR["alu_Nombre"].ToString() != null)
                auxiliar = DR["alu_Nombre"].ToString();
            //auxiliar = Int32.Parse(DR["usr_ID"].ToString());
            else
                auxiliar = "";
            Nombre = auxiliar;

            return Nombre;
        }

        /// <summary>
        /// metodo sobrecargado que devuelve una lista de profesores
        /// </summary>
        /// <param name="cb">componente comboBox para almacenar la lista</param>
        /// <param name="nom_prof">nombre del profesor  asesor</param>
        /// <param name="aux2"></param>
        /// <param name="aux3"></param>
        public void cargarmaestros(ComboBox cb, string nom_prof,string aux2,string aux3)
        {
            //------------
            //Conexion a la base de datos
            //-----------
            string conexion = ConfigurationManager.ConnectionStrings["dbconexion"].ToString();
            SqlConnection conexion2 = new SqlConnection(conexion);
            conexion2.Open();
            DataTable dt = new DataTable();
            
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                // string query = "SELECT TOP 5 prof_Nombre, (SELECT COUNT(*) FROM alumnos_profesores A WHERE A.aluProf_PROFESOR = S.prof_id ) as contador FROM profesores S ORDER BY contador asc;";
                string query = "SELECT  TOP 5 prof_Nombre,(SELECT COUNT(*) FROM alumnos_profesores A WHERE A.aluProf_PROFESOR = S.prof_id)as contador FROM profesores S where prof_Nombre <> '"+nom_prof+ "' and prof_Nombre <> '"+aux2+"'  and prof_Nombre <> '"+aux3+"' ORDER BY contador asc";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

            }
            try
            {

                SqlCommand comand_id = new SqlCommand("SELECT  TOP 5 prof_Nombre, (SELECT COUNT(*) FROM alumnos_profesores A WHERE A.aluProf_PROFESOR = S.prof_id) as contador FROM profesores S where prof_Nombre <> '"+nom_prof+"' ORDER BY contador asc", conexion2);
                comand_id.ExecuteNonQuery();
                DataSet ds2 = new DataSet();
                SqlDataAdapter da2 = new SqlDataAdapter(comand_id);
                da2.Fill(ds2, "alumnos_profesores");
                DataRow DR2;

                DR2 = ds2.Tables["alumnos_profesores"].Rows[0];
                cb.ValueMember = "prof_Nombre";

                cb.DataSource = dt;
            }
            catch (Exception ex) { cb.Text = ""; }
        }

        /// <summary>
        /// metodo sobrecargado que devuelve una lista de profesores
        /// </summary>
        /// <param name="cb">componente comboBox para almacenar la lista</param>
        public void cargarmaestros(ComboBox cb)
        {
            //------------
            //Conexion a la base de datos
            //-----------
            string conexion = ConfigurationManager.ConnectionStrings["dbconexion"].ToString();
            SqlConnection conexion2 = new SqlConnection(conexion);
            conexion2.Open();
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(conexion))
            {
                // string query = "SELECT TOP 5 prof_Nombre, (SELECT COUNT(*) FROM alumnos_profesores A WHERE A.aluProf_PROFESOR = S.prof_id ) as contador FROM profesores S ORDER BY contador asc;";
                string query = "SELECT  TOP 5 prof_Nombre,(SELECT COUNT(*) FROM alumnos_profesores A WHERE A.aluProf_PROFESOR = S.prof_id)as contador FROM profesores S ORDER BY contador asc";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

            }
            try
            {

                SqlCommand comand_id = new SqlCommand("SELECT  TOP 5 prof_Nombre,(SELECT COUNT(*) FROM alumnos_profesores A WHERE A.aluProf_PROFESOR = S.prof_id)as contador FROM profesores S ORDER BY contador asc", conexion2);
                comand_id.ExecuteNonQuery();
                DataSet ds2 = new DataSet();
                SqlDataAdapter da2 = new SqlDataAdapter(comand_id);
                da2.Fill(ds2, "alumnos_profesores");
                DataRow DR2;

                DR2 = ds2.Tables["alumnos_profesores"].Rows[0];
                cb.ValueMember = "prof_Nombre";

                cb.DataSource = dt;
            }
            catch (Exception ex) { cb.Text = ""; }
        }


        public bool Comision(string alumno)
        {
            bool var = false;


                var = false;

            return var;
        }
        /*comision*/
        
        public void cargarSecretarios(ComboBox cb, string nom_asesor)    {
            //------------
            //Conexion a la base de datos
            //-----------
            string conexion = ConfigurationManager.ConnectionStrings["dbconexion"].ToString();
            SqlConnection conexion2 = new SqlConnection(conexion);
            conexion2.Open();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                // string query = "SELECT TOP 5 prof_Nombre, (SELECT COUNT(*) FROM alumnos_profesores A WHERE A.aluProf_PROFESOR = S.prof_id ) as contador FROM profesores S ORDER BY contador asc;";
                string query = "SELECT  TOP 5 prof_Nombre,(SELECT COUNT(*) FROM profesorSecretario A WHERE A.fk_ProfesoresID = S.prof_id)as "+
                    "contador FROM profesores S where prof_Nombre <> '" + nom_asesor + "' ORDER BY contador asc";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

            }
            try
            {

                SqlCommand comand_id = new SqlCommand("SELECT  TOP 5 prof_Nombre,(SELECT COUNT(*) FROM profesorSecretario A WHERE A.fk_ProfesoresID = S.prof_id)as " +
                    "contador FROM profesores S where prof_Nombre <> '" + nom_asesor + "' ORDER BY contador asc", conexion2);
                comand_id.ExecuteNonQuery();
                DataSet ds2 = new DataSet();
                SqlDataAdapter da2 = new SqlDataAdapter(comand_id);
                da2.Fill(ds2, "alumnos_profesores");
                DataRow DR2;

                DR2 = ds2.Tables["alumnos_profesores"].Rows[0];
                cb.ValueMember = "prof_Nombre";

                cb.DataSource = dt;
            }
            catch (Exception ex) {  }
        }

        public void cargarvocal(ComboBox cb, string nom_asesor,string nom_secretario)  {
            //------------
            //Conexion a la base de datos
            //-----------
            string conexion = ConfigurationManager.ConnectionStrings["dbconexion"].ToString();
            SqlConnection conexion2 = new SqlConnection(conexion);
            conexion2.Open();
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(conexion))
            {
                // string query = "SELECT TOP 5 prof_Nombre, (SELECT COUNT(*) FROM alumnos_profesores A WHERE A.aluProf_PROFESOR = S.prof_id ) as contador FROM profesores S ORDER BY contador asc;";
                string query = "SELECT  TOP 5 prof_Nombre,(SELECT COUNT(*) FROM alumnos_profesores A WHERE A.aluProf_PROFESOR = S.prof_id)as contador FROM profesores S where prof_Nombre <> '" + nom_asesor + "' and prof_Nombre <> '" + nom_secretario + "' ORDER BY contador asc";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

            }
            try
            {

                SqlCommand comand_id = new SqlCommand("SELECT  TOP 5 prof_Nombre,(SELECT COUNT(*) FROM alumnos_profesores A WHERE A.aluProf_PROFESOR = S.prof_id)as contador FROM profesores S where prof_Nombre <> '" + nom_asesor + "' and prof_Nombre <> '" + nom_secretario + "' ORDER BY contador asc", conexion2);
                comand_id.ExecuteNonQuery();
                DataSet ds2 = new DataSet();
                SqlDataAdapter da2 = new SqlDataAdapter(comand_id);
                da2.Fill(ds2, "alumnos_profesores");
                DataRow DR2;

                DR2 = ds2.Tables["alumnos_profesores"].Rows[0];
                cb.ValueMember = "prof_Nombre";

                cb.DataSource = dt;
            }
            catch (Exception ex) { cb.Text = ""; }
        }

        public void cargarSuplente(ComboBox cb,string nom_asesor,string nom_secretario,string nom_vocal) {
            //------------
            //Conexion a la base de datos
            //-----------
            string conexion = ConfigurationManager.ConnectionStrings["dbconexion"].ToString();
            SqlConnection conexion2 = new SqlConnection(conexion);
            conexion2.Open();
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(conexion))
            {
                // string query = "SELECT TOP 5 prof_Nombre, (SELECT COUNT(*) FROM alumnos_profesores A WHERE A.aluProf_PROFESOR = S.prof_id ) as contador FROM profesores S ORDER BY contador asc;";
                string query = "SELECT  TOP 5 prof_Nombre,(SELECT COUNT(*) FROM alumnos_profesores A WHERE A.aluProf_PROFESOR = S.prof_id)as contador FROM profesores S where prof_Nombre <> '" + nom_asesor + "' and prof_Nombre <> '" + nom_secretario + "'  and prof_Nombre <> '" + nom_vocal + "' ORDER BY contador asc";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

            }
            try
            {

                SqlCommand comand_id = new SqlCommand("SELECT  TOP 5 prof_Nombre,(SELECT COUNT(*) FROM alumnos_profesores A WHERE A.aluProf_PROFESOR = S.prof_id)as contador FROM profesores S where prof_Nombre <> '" + nom_asesor + "' and prof_Nombre <> '" + nom_secretario + "'  and prof_Nombre <> '" + nom_vocal + "' ORDER BY contador asc", conexion2);
                comand_id.ExecuteNonQuery();
                DataSet ds2 = new DataSet();
                SqlDataAdapter da2 = new SqlDataAdapter(comand_id);
                da2.Fill(ds2, "alumnos_profesores");
                DataRow DR2;

                DR2 = ds2.Tables["alumnos_profesores"].Rows[0];
                cb.ValueMember = "prof_Nombre";

                cb.DataSource = dt;
            }
            catch (Exception ex) { cb.Text = ""; }
        }

        /*fin comision*/
        public void agregarregistro_secretario(string secretario, string num_contrl)
        {
            string conexion = ConfigurationManager.ConnectionStrings["dbconexion"].ToString();
            //conexion = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\Angel\\Documents\\SharpDevelop Projects\\ProtocoloTitulacion\\ProtocoloTitulacion\\ProcessofTitling.mdf; Integrated Security = True";
            SqlConnection miconexion = new SqlConnection(conexion);
            miconexion.Open();
            //----
            // secretario

            string auxiliar;
            string consulta = "select prof_ID from profesores where prof_Nombre = '"+secretario+"'";
            SqlCommand comando = new SqlCommand(consulta, miconexion);
            comando.ExecuteNonQuery();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds, "profesores");
            DataRow DR;
            DR = ds.Tables["profesores"].Rows[0];
            if (DR["prof_ID"].ToString() != null)
                auxiliar = DR["prof_ID"].ToString();
            else
                auxiliar = "";

            int valor;
            string consultaid = "select top 1 profSecretario_ID from profesorSecretario Order by profSecretario_ID Desc";
            SqlCommand id = new SqlCommand(consultaid, miconexion);
            id.ExecuteNonQuery();
            DataSet ds2 = new DataSet();
            SqlDataAdapter da2 = new SqlDataAdapter(id);
            da2.Fill(ds2, "profesorSecretario");
            DataRow DR2;
            DR2 = ds2.Tables["profesorSecretario"].Rows[0];
            if (DR2["profSecretario_ID"].ToString() != null)
            {
                valor = Int32.Parse(DR2["profSecretario_ID"].ToString());
                valor++;
            }
            else
                valor = 1;

            string insercion = "insert into profesorSecretario values(" + valor + "," + auxiliar + ",'" + num_contrl + "')";
            SqlCommand comand_insertarAsesor = new SqlCommand(insercion, miconexion);
            comand_insertarAsesor.ExecuteNonQuery();
        }

        public void agregarregistro_vocal(string vocal, string num_contrl)
        {
            string conexion = ConfigurationManager.ConnectionStrings["dbconexion"].ToString();
            //conexion = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\Angel\\Documents\\SharpDevelop Projects\\ProtocoloTitulacion\\ProtocoloTitulacion\\ProcessofTitling.mdf; Integrated Security = True";
            SqlConnection miconexion = new SqlConnection(conexion);
            miconexion.Open();
            //----
            // secretario
            string auxiliar;
            string consulta = "select prof_ID from profesores where prof_Nombre = '" + vocal + "'";
            SqlCommand comando = new SqlCommand(consulta, miconexion);
            comando.ExecuteNonQuery();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds, "profesores");
            DataRow DR;
            DR = ds.Tables["profesores"].Rows[0];
            if (DR["prof_ID"].ToString() != null)
                auxiliar = DR["prof_ID"].ToString();
            else
                auxiliar = "";

            int valor;
            string consultaid = "select top 1 profVocal_ID from profesorVocal Order by profVocal_ID Desc";
            SqlCommand id = new SqlCommand(consultaid, miconexion);
            id.ExecuteNonQuery();
            DataSet ds2 = new DataSet();
            SqlDataAdapter da2 = new SqlDataAdapter(id);
            da2.Fill(ds2, "profesorVocal");
            DataRow DR2;
            DR2 = ds2.Tables["profesorVocal"].Rows[0];
            if (DR2["profVocal_ID"].ToString() != null)
            {
                valor = Int32.Parse(DR2["profVocal_ID"].ToString());
                valor++;
            }
            else
                valor = 1;

            string insercion = "insert into profesorVocal values(" + valor + "," + auxiliar + ",'" + num_contrl + "')";
            SqlCommand comand_insertarAsesor = new SqlCommand(insercion, miconexion);
            comand_insertarAsesor.ExecuteNonQuery();
        }

        public void agregarregistro_suplente(string suplente, string num_contrl)
        {
            string conexion = ConfigurationManager.ConnectionStrings["dbconexion"].ToString();
            //conexion = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\Angel\\Documents\\SharpDevelop Projects\\ProtocoloTitulacion\\ProtocoloTitulacion\\ProcessofTitling.mdf; Integrated Security = True";
            SqlConnection miconexion = new SqlConnection(conexion);
            miconexion.Open();
            //----
            // secretario

            string auxiliar;
            string consulta = "select prof_ID from profesores where prof_Nombre = '" + suplente + "'";
            SqlCommand comando = new SqlCommand(consulta, miconexion);
            comando.ExecuteNonQuery();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds, "profesores");
            DataRow DR;
            DR = ds.Tables["profesores"].Rows[0];
            if (DR["prof_ID"].ToString() != null)
                auxiliar = DR["prof_ID"].ToString();
            else
                auxiliar = "";

            int valor;
            string consultaid = "select top 1 prof_SuplenteID from profesorSuplente Order by prof_SuplenteID Desc";
            SqlCommand id = new SqlCommand(consultaid, miconexion);
            id.ExecuteNonQuery();
            DataSet ds2 = new DataSet();
            SqlDataAdapter da2 = new SqlDataAdapter(id);
            da2.Fill(ds2, "profesorSuplente");
            DataRow DR2;
            DR2 = ds2.Tables["profesorSuplente"].Rows[0];
            if (DR2["prof_SuplenteID"].ToString() != null)
            {
                valor = Int32.Parse(DR2["prof_SuplenteID"].ToString());
                valor++;
            }
            else
                valor = 1;

            string insercion = "insert into profesorSuplente values(" + valor + "," + auxiliar + ",'" + num_contrl + "')";
            SqlCommand comand_insertarAsesor = new SqlCommand(insercion, miconexion);
            comand_insertarAsesor.ExecuteNonQuery();
        }

    }
}
