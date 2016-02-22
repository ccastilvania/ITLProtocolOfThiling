using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Data;
//librerias de office para manipular excel
using System.Data.OleDb;
using Microsoft.Office.Interop.Excel;

//librerias para manejo de sqlserver
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Sql;

namespace ProtocoloTitulacion.funciones
{
    class Importar
    {
        OleDbConnection conn;
        OleDbDataAdapter MyDataAdapter;
        System.Data.DataTable dt;
        /// <summary>
        /// metodo que importa el contenido de excel de la hoja uno
        /// </summary>
        /// <param name="dgv">componente datagridview</param>
        /// <param name="nombreHoja">hoja1 </param>
        public void importarExcel(DataGridView dgv, String nombreHoja)
        {
            String ruta = "";
            try
            {
                OpenFileDialog openfile1 = new OpenFileDialog();
                openfile1.Filter = "Excel Files |*.xlsx";
                openfile1.Title = "Seleccione el archivo de Excel";
                if (openfile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openfile1.FileName.Equals("") == false)
                    {
                        ruta = openfile1.FileName;
                    }
                }

                conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + ruta + ";Extended Properties='Excel 12.0 Xml;HDR=Yes'");
                MyDataAdapter = new OleDbDataAdapter("Select * from [" + nombreHoja + "$]", conn);
                dt = new System.Data.DataTable();
                MyDataAdapter.Fill(dt);
                dgv.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //Exporta Datagridview a Archivo de Excel
        public void ExportarExcel(DataGridView grd)
        {
            try
            {

                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                fichero.FileName = "ArchivoExportado";
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application aplicacion;
                    Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                    Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;

                    aplicacion = new Microsoft.Office.Interop.Excel.Application();
                    libros_trabajo = aplicacion.Workbooks.Add();
                    hoja_trabajo =
                        (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);

                    //Recorremos el DataGridView rellenando la hoja de trabajo
                    for (int i = 0; i < grd.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < grd.Columns.Count; j++)
                        {
                            if ((grd.Rows[i].Cells[j].Value == null) == false)
                            {
                                hoja_trabajo.Cells[i + 1, j + 1] = grd.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                    }
                    libros_trabajo.SaveAs(fichero.FileName,
                        Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libros_trabajo.Close(true);
                    aplicacion.Quit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar la informacion debido a: " + ex.ToString());
            }

        }

        //alta profesor al importar
        public void alta_profesor(string prof_num_tarjeta, string prof_ApePaterno, string prof_ApeMaterno, string prof_Nombre, string prof_Area,string prof_Horas)
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
                string cadena = "insert into profesores (prof_ID,prof_num_tarjeta,prof_Nombre,prof_Apepaterno,prof_ApeMaterno,prof_Horas) values ('" + id + "'," + "'" + prof_num_tarjeta + "','" + prof_ApePaterno+ "','" + prof_ApeMaterno + "','" + prof_Nombre + "','" + prof_Horas + "');";
                //MessageBox.Show(cadena);
                SqlCommand comando = new SqlCommand(cadena, miconexion);
                comando.ExecuteNonQuery();
                miconexion.Close();
            }
            catch
            {
                MessageBox.Show("Verifique que los datos sean correctos", "Error en los Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void alta_alumno(string NControl)
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
            SqlCommand comand_insertalu = new SqlCommand("insert into alumno(alu_NControl) values('" + NControl + "')", miconexion);
            comand_insertalu.ExecuteNonQuery();

            miconexion.Close();
        }

        /// <summary>
        /// metodo para traspasar datos a la base de datos
        /// </summary>
        public void importarDataBase(DataGridView dgv)
        {
            string tarjeta ="";
            string nombre ="";
            string paterno="";
            string materno="";
            string horas="";
            string control="";
            string asesor="";

            try
            {
                for (int i = 0; i < dgv.RowCount - 1; i++)
                {
                    //var++;
                    tarjeta = dgv[1, i].Value.ToString();
                    paterno = dgv[2, i].Value.ToString();
                    materno = dgv[3, i].Value.ToString();
                    nombre = dgv[4, i].Value.ToString();
                    horas = dgv[5, i].Value.ToString();

                    if (nombre != "") {
                       // MessageBox.Show("entro al if" + nombre);
                        alta_profesor(tarjeta, paterno, materno, nombre, "", horas);
                        control = dgv[6, i].Value.ToString();
                        alta_alumno(control);
                    }else if (tarjeta == "" && nombre =="")
                    {
                        //MessageBox.Show("entro al else if" + tarjeta);
                        control = dgv[6, i].Value.ToString();
                        alta_alumno(control);
                    }else if(control == "")
                    {}

            }
                MessageBox.Show("Se importaron corectamente todos los datos","Informacion",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
            catch (Exception exe)
            {
                MessageBox.Show("Error agregar prof");
                //MessageBox.Show("Se importaron corectamente todos los datos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // MessageBox.Show("Falla al importar los datos " + exe.Message, "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static System.Data.DataTable consulta(System.Data.DataTable profesor,System.Data.DataTable alumno)
        {
            //Result table
            System.Data.DataTable table = new System.Data.DataTable("Union");

            //Build new columns

            DataColumn[] newcolumns = new DataColumn[profesor.Columns.Count];

            for (int i = 0; i < profesor.Columns.Count; i++)

            {
                newcolumns[i] = new DataColumn(profesor.Columns[i].ColumnName, profesor.Columns[i].DataType);
            }

            //add new columns to result table

            table.Columns.AddRange(newcolumns);

            table.BeginLoadData();

            //Load data from first table

            foreach (DataRow row in profesor.Rows)
            {
                table.LoadDataRow(row.ItemArray, true);
            }

            //Load data from second table
            foreach (DataRow row in alumno.Rows)
            {
                table.LoadDataRow(row.ItemArray, true);
            }
            table.EndLoadData();

            return table;
        }

        ///<summary>
        /// Metodo para cargar la base de datos
        /// </summary>
        public void cargarDB(DataGridView dgv)
        {

        }
    }
}
