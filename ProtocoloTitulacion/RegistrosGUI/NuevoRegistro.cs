using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace ProtocoloTitulacion.RegistrosGUI
{
    public partial class NuevoRegistro : Form
    {
        public NuevoRegistro()
        {
            InitializeComponent();
        }

        //Boton de cancelar
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        //Boton de agreagr
        private void button1_Click(object sender, EventArgs e)
        {
            string secretario = cb_secretario.SelectedValue.ToString();
            string vocal = cb_vocal.SelectedValue.ToString();
            string suplente = cb_suplente.SelectedValue.ToString();
            string asesor = cb_Asesor.SelectedValue.ToString();
            string num_contrl = cb_Alumno.SelectedValue.ToString();
            if (secretario != vocal && secretario != asesor && secretario != suplente && vocal != secretario && vocal!=suplente && vocal!= asesor 
                && suplente != vocal && suplente !=secretario && suplente != asesor)
            {
                //if (new funciones.busquedas().Comision(num_contrl)) {
                    MessageBox.Show("Alumno ya cuenta con una comision revisora");
                //}
                //else {
                    new funciones.busquedas().agregarregistro_secretario(secretario, num_contrl);
                    new funciones.busquedas().agregarregistro_suplente(suplente, num_contrl);
                    new funciones.busquedas().agregarregistro_vocal(vocal, num_contrl);
                    MessageBox.Show("Comision Agregada correcta mente", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
            else
            {
                MessageBox.Show("Verifique que los valores no esten duplicados","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conexion = ConfigurationManager.ConnectionStrings["dbconexion"].ToString();
            
            SqlConnection conexion2 = new SqlConnection(conexion);
            conexion2.Open();
            
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = "select prof_Nombre from profesores where prof_ID  in (select aluProf_PROFESOR from alumnos_profesores where aluProf_ALUMNO = '"+ cb_Alumno.SelectedValue.ToString()+"');";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

            }
            try
            {

                SqlCommand comand_id = new SqlCommand("select prof_Nombre from profesores where prof_ID  in (select aluProf_PROFESOR from alumnos_profesores where aluProf_ALUMNO = '"+ cb_Alumno.SelectedValue.ToString()+"');", conexion2);
                comand_id.ExecuteNonQuery();
                DataSet ds2 = new DataSet();
                SqlDataAdapter da2 = new SqlDataAdapter(comand_id);
                da2.Fill(ds2, "prof_Nombre");
                DataRow DR2;

                DR2 = ds2.Tables["prof_Nombre"].Rows[0];
                cb_Asesor.ValueMember = "prof_Nombre";
                cb_Asesor.DataSource = dt;
            }
            catch (Exception ex) { MessageBox.Show("al alumno "+cb_Alumno.SelectedValue.ToString()+" no tiene asignado ningun asesor","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning); }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NuevoRegistro_Load(object sender, EventArgs e)
        {

            funcionesllenaralu();
            //----- inicio consulta Secretario
            llenarcampos();
            /*new funciones.busquedas().cargarmaestros(cb_secretario);
            new funciones.busquedas().cargarmaestros(cb_vocal);
            new funciones.busquedas().cargarmaestros(cb_suplente);*/

        }

        /// <summary>
        /// metodo para llenar el combobox para los numeros de control de los alumnos
        /// </summary>
        public void funcionesllenaralu()
        {
            string conexion = ConfigurationManager.ConnectionStrings["dbconexion"].ToString();

            SqlConnection conexion2 = new SqlConnection(conexion);
            conexion2.Open();

            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = "select alu_NControl from alumno";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

            }
            try
            {

                SqlCommand comand_id = new SqlCommand("select TOP 1 alu_NControl from alumno", conexion2);
                comand_id.ExecuteNonQuery();
                DataSet ds2 = new DataSet();
                SqlDataAdapter da2 = new SqlDataAdapter(comand_id);
                da2.Fill(ds2, "alumno");
                DataRow DR2;

                DR2 = ds2.Tables["alumno"].Rows[0];
                cb_Alumno.ValueMember = "alu_NControl";
                cb_Alumno.DataSource = dt;
            }
            catch (Exception ex) { cb_Asesor.Text = ""; }
        }

        /// <summary>
        /// metodo para llenar los combobox 
        /// </summary>
        public void llenarcampos()
        {
            try {
                
                new funciones.busquedas().cargarmaestros(cb_secretario);
                new funciones.busquedas().cargarmaestros(cb_vocal);
                new funciones.busquedas().cargarmaestros(cb_suplente);
            }catch(Exception e)    {
                MessageBox.Show("el alumno no cuenta con un asesor");
            }
        }

        private void cb_secretario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
