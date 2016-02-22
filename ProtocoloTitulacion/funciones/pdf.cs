/*
 * Created by SharpDevelop.
 * User: Angel
 * Date: 29/09/2015
 * Time: 10:46 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows.Forms;
using System.IO;
using System.Resources;
using ProtocoloTitulacion.Properties;
using System.Drawing;

namespace ProtocoloTitulacion.funciones
{
	/// <summary>
	/// Description of pdf.
	/// </summary>
	public class pdf
	{
		public pdf()
		{

		}


        #region saber si un folder existe
        public void folder()
        {
            string yourDirectory = "C:\\CartasAsignacion"; 
            
            if (!Directory.Exists(yourDirectory))
                    Directory.CreateDirectory(yourDirectory);
        }
        #endregion

        public void generarPDF(string NC,string asesor,string secretario,string vocal,string suplente,string nombre)
        {
            folder();
            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            // Indicamos donde vamos a guardar el documento
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(@"C:\\CartasAsignacion\\" + (NC.ToString())+".pdf", FileMode.Create));
            //new FileStream(@"C:\Users\Angel\Documents\OficioTitulacion.pdf", FileMode.Create));


            //string image = "C:\\Users\\Angel\\Documents\\SharpDevelop Projects\\ProtocoloTitulacion\\ProtocoloTitulacion\\Recursos\\tec laguna.png";
            //ResourceManager rm = Resources.ResourceManager;
            //Bitmap myImage2 = (Bitmap)rm.GetObject("logo_pdf.png");
            //string image = myImage2.ToString() ;
            //Add the meta information
            document.AddAuthor("ITL Sistem Departament");
            document.AddCreator("Sistem Asignacion de Revisores");
            document.AddKeywords("PDF");
            document.AddTitle("The document title - Asignacion de Comisión Revisora");
            
            //open the document to enable you to wirte to the document
            document.Open();

            #region logo
            string patimagen = Path.Combine(Application.StartupPath, "..\\..\\Recursos\\logo_pdf.png");
            iTextSharp.text.Image myImage = iTextSharp.text.Image.GetInstance(patimagen);
            //iTextSharp.text.Image myImage = iTextSharp.text.Image.GetInstance(image);
            myImage.ScaleToFit(400, 233f);
            myImage.SpacingBefore = 50f;
            myImage.SpacingAfter = 10f;
            myImage.Alignment = Element.ALIGN_RIGHT;

            #endregion

            #region cabecera
            //estilos
            iTextSharp.text.Font title = FontFactory.GetFont("georgia",20f);
            Paragraph titulo = new Paragraph("Instituto Tecnológico de la Laguna", title);
            titulo.Alignment = Element.ALIGN_CENTER;
            //document.Add(titulo);
            document.Add(myImage);
            document.Add(Chunk.NEWLINE);
            //Indicamos la fecha de sistema
            string Date = DateTime.Today.Date.ToString();
            string aux="";
            for (int i = 0; i < 10; i++) {
                    aux += Date[i].ToString();
            }

            Paragraph fecha = new Paragraph("Torreon,Coah.," + aux);
            fecha.Alignment = Element.ALIGN_RIGHT;
            document.Add(fecha);
            //Fin de la fecha
            document.Add(Chunk.NEWLINE);
            Paragraph Asunto = new Paragraph("Asunto: Asignacion de comisión revisora ");
            Asunto.Alignment = Element.ALIGN_CENTER;
            document.Add(Asunto);

            #endregion

            document.Add(new Paragraph("COORDINADOR(A) DE "));
            document.Add(Chunk.NEWLINE);
            document.Add(new Paragraph("Por medio del presente informo a usted la asignacion de los integrantes de la comision"));
            document.Add(Chunk.NEWLINE);
            String texto = "revisora del trabajo de titulacion, del trabajo de titulacion de (la) C."+nombre+" " ;
            document.Add(new Paragraph(texto));
            document.Add(Chunk.NEWLINE);
            document.Add(new Paragraph("cuya opcion es : "));
            document.Add(Chunk.NEWLINE);
            document.Add(new Paragraph("Egresado(a) del instituto Tecnologico de la Laguna, con número de control " + NC +" pasante de la Carrera de Ingenieria en Sistemas"));

            #region Comision

            document.Add(Chunk.NEWLINE);
            string comision = "Presidente(a): " + asesor +
                               "\nSecretario(a): " + secretario +
                               "\nVocal : " + vocal +
                               "\nVocal Suplente : " + suplente;
            Paragraph textoComision = new Paragraph(comision);
            textoComision.Alignment = Element.ALIGN_MIDDLE;
            /*string presidente = "Presidente(a): " + asesor;
            document.Add(new Paragraph(presidente));
            string secretariodoc = "Secretario(a): " + secretario;
            document.Add(new Paragraph(secretariodoc));
            string vocaldoc = "Vocal: " + vocal;
            document.Add(new Paragraph(vocaldoc));
            string suplentedoc = "Vocal Suplente: "+suplente;
            document.Add(new Paragraph(suplentedoc));*/
            document.Add(textoComision);
            document.Add(Chunk.NEWLINE);
            document.Add(new Paragraph("Agradezco su atención al presente y envío un cordial saludo"));
            document.Add(Chunk.NEWLINE);

            #endregion


            iTextSharp.text.Font ateFont = FontFactory.GetFont("georgia", 10);
            ateFont.IsBold();
            Paragraph Ate = new Paragraph("Atentamente",ateFont);
            Ate.Alignment = Element.ALIGN_CENTER;
            document.Add(Ate);
            document.Add(Chunk.NEWLINE);
            document.Add(Chunk.NEWLINE);
            document.Add(Chunk.NEWLINE);
            Paragraph linea = new Paragraph("-------------------------------------------");
            linea.Alignment = Element.ALIGN_CENTER;
            document.Add(linea);
            document.Add(Chunk.NEWLINE);
            Paragraph jefatura = new Paragraph("Jefatura del Departamento de Sistemas Computacionales");
            jefatura.Alignment = Element.ALIGN_CENTER;
            document.Add(jefatura);
            //Close the document
            document.Close();
            //close the writer instance
            writer.Close();
            MessageBox.Show("Oficio creado satisfactoriamente");

        }

	}
}
