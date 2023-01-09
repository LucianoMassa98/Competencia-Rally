using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace Competencias___Valle_Fertil
{
    static class CrearPdf
    {

        static public void encabezadoPDF(string[] encabezados, ref PdfPTable table, ref Document doc)
        {

            iTextSharp.text.Font StandarFont = new iTextSharp.text.Font(
                iTextSharp.text.Font.FontFamily.HELVETICA,
                8,
                iTextSharp.text.Font.NORMAL,
                BaseColor.BLACK
                );
          

            foreach (string x in encabezados) {

                PdfPCell cell = new PdfPCell(new Phrase(x, StandarFont));
                cell.BorderWidth = 0;
                cell.BorderWidthBottom = 0.75f;
                table.AddCell(cell);
            }
            doc.Add(table);
        }
        static public void filaPDF(DataGridViewRow x, ref Document doc)
        {

            iTextSharp.text.Font StandarFont = new iTextSharp.text.Font(
                iTextSharp.text.Font.FontFamily.HELVETICA,
                8,
                iTextSharp.text.Font.NORMAL,
                BaseColor.BLACK
                );
            PdfPTable table = new PdfPTable(x.Cells.Count);
            table.WidthPercentage = 100;

            PdfPCell cell;
            for (int j =0;j<x.Cells.Count;j++) {
               
                    cell = new PdfPCell(new Phrase(x.Cells[j].Value.ToString(), StandarFont));
                    cell.BorderWidth = 0;
                    cell.BorderWidthTop = 0.75f;
                    table.AddCell(cell);
                }

         

            doc.Add(table);
           

        }
        static public void filaPDF(Participacion x, ref Document doc, ref int pos)
        {

            iTextSharp.text.Font StandarFont = new iTextSharp.text.Font(
                iTextSharp.text.Font.FontFamily.HELVETICA,
                8,
                iTextSharp.text.Font.NORMAL,
                BaseColor.BLACK
                );
            PdfPTable table = new PdfPTable(6);
            table.WidthPercentage = 100;
                
           PdfPCell posicion = new PdfPCell(new Phrase(pos.ToString(), StandarFont));
            posicion.BorderWidth = 0;
            posicion.BorderWidthTop = 0.75f;
            PdfPCell vehiculo = new PdfPCell(new Phrase(x.Vehiculo.ToString(), StandarFont));
            vehiculo.BorderWidth = 0;
            vehiculo.BorderWidthTop = 0.75f;
            PdfPCell piloto = new PdfPCell(new Phrase(x.PilotoX.NombreCompleto(), StandarFont));
            piloto.BorderWidth = 0;
            piloto.BorderWidthTop = 0.75f;
            PdfPCell penalizacion = new PdfPCell(new Phrase(x.TiempoMulta().ToString(), StandarFont));
            penalizacion.BorderWidth = 0;
            penalizacion.BorderWidthTop = 0.75f;
            PdfPCell neto = new PdfPCell(new Phrase(x.TiempoNeto().ToString(), StandarFont));
            neto.BorderWidth = 0;
            neto.BorderWidthTop = 0.75f;
            PdfPCell total = new PdfPCell(new Phrase(x.TiempoTotal().ToString(), StandarFont));
            total.BorderWidth = 0;
            total.BorderWidthTop = 0.75f;

            table.AddCell(posicion);
            table.AddCell(vehiculo);
            table.AddCell(piloto);
            table.AddCell(penalizacion);
            table.AddCell(neto);
            table.AddCell(total);
            pos++;

            doc.Add(table);


        }
        static public void filaDetallePDF(List<string> x, ref Document doc)
        {

            iTextSharp.text.Font StandarFont = new iTextSharp.text.Font(
                iTextSharp.text.Font.FontFamily.HELVETICA,
                8,
                iTextSharp.text.Font.NORMAL,
                BaseColor.BLACK
                );
            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 40;

            int ronda = 1;
            for (int j = 0; j < x.Count; j+=3)
            {
                
                PdfPCell cell = new PdfPCell(new Phrase(ronda.ToString(), StandarFont));
                cell.BorderWidth = 0;
               // cell.BorderWidthTop = 0.75f;
                PdfPCell cell2 = new PdfPCell(new Phrase(x[j + 2].ToString(), StandarFont));
                cell2.BorderWidth = 0;
                //cell2.BorderWidthTop = 0.75f;

                table.AddCell(cell);
                table.AddCell(cell2);
                ronda++;
            }
            doc.Add(table);


        }
        static public void filasManualPDF( ref Document doc, int cntRondas)
        {

            iTextSharp.text.Font StandarFont = new iTextSharp.text.Font(
                iTextSharp.text.Font.FontFamily.HELVETICA,
                8,
                iTextSharp.text.Font.NORMAL,
                BaseColor.BLACK
                );
            PdfPTable table = new PdfPTable(cntRondas);
            table.WidthPercentage = 20 * cntRondas;
        


            for (int i = 0; i < cntRondas; i ++)
            {
                PdfPCell cell = new PdfPCell(new Phrase((i + 1).ToString(), StandarFont));       
                cell.BorderWidth = 0;
                cell.BorderWidthTop = 0.75f;

                PdfPCell cell2 = new PdfPCell(new Phrase("", StandarFont));
                cell2.BorderWidth = 0;
                cell2.BorderWidthTop = 0.75f;

                PdfPCell cell3 = new PdfPCell(new Phrase("", StandarFont));
                cell3.BorderWidth = 0;
                cell3.BorderWidthTop = 0.75f;

                table.AddCell(cell);
                table.AddCell(cell2);
                table.AddCell(cell3);

            }
            doc.Add(table);


        }

        static public void PosicionesPDF(Carrera carrera, DataGridView x) {

            FileStream p = new FileStream(directions.Posiciones+carrera.Nombre+".pdf", FileMode.Create);
            Document doc = new Document(PageSize.LETTER, 5, 5, 7, 7);
            PdfWriter pw = PdfWriter.GetInstance(doc, p);
            doc.Open();
            //titulo y autor
            doc.AddTitle("Posiciones");
            doc.AddAuthor("Setigex.sj@hotmail.com");
            // define tipo de fuente (tipo,tamaño,forma,color)

            iTextSharp.text.Font StandarFont = new iTextSharp.text.Font(
                iTextSharp.text.Font.FontFamily.HELVETICA,
                8,
                iTextSharp.text.Font.NORMAL,
                BaseColor.BLACK
                );

            //escribir encabezado

            doc.Add(new Paragraph("Rally del Valle Fertil"));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase("Fecha: " + carrera.Fecha.ToString("dd/MM/yyyy hh:mm:ss"), StandarFont));
            doc.Add(Chunk.NEWLINE);


            //encabezado columnas
            PdfPTable table = new PdfPTable(8);
            table.WidthPercentage = 100;
            string[] enca = new string[] {"Posición", "Vehículo", "Piloto", "Penalización", "Neto", "Total", "Diferencia", "Promedio" }; 
            encabezadoPDF(enca,ref table,ref doc);
           
            //agregando datos
            for (int i = 0; i < x.RowCount; i++)
            {

                filaPDF(x.Rows[i],ref doc);
                enca = new string[] { "Ronda", "Tiempo"};
                table = new PdfPTable(2);
                table.WidthPercentage = 40;
                encabezadoPDF(enca, ref table,ref doc);
                Participacion newparti = ParticipacionService.findVehiculo(int.Parse(x.Rows[i].Cells[1].Value.ToString()));
                List<string> detalle = newparti.DetalleRondas();
                filaDetallePDF(detalle, ref doc);
                doc.Add(Chunk.NEWLINE);
            }
            
            doc.Close();
            pw.Close();

            MessageBox.Show("Documento generado existosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {
                var ph = new Process();
                ph.StartInfo = new ProcessStartInfo(directions.Posiciones + carrera.Nombre + ".pdf")
                {
                    UseShellExecute = true
                };
                ph.Start();
            }
            catch (Exception err) { MessageBox.Show(err.Message); }
        }
        static public void GeneralesPDF( DataGridView x)
        {

            FileStream p = new FileStream(directions.Posiciones + "Generales.pdf", FileMode.Create);
            Document doc = new Document(PageSize.LETTER, 5, 5, 7, 7);
            PdfWriter pw = PdfWriter.GetInstance(doc, p);
            doc.Open();
            //titulo y autor
            doc.AddTitle("Posiciones");
            doc.AddAuthor("Setigex.sj@hotmail.com");
            // define tipo de fuente (tipo,tamaño,forma,color)

            iTextSharp.text.Font StandarFont = new iTextSharp.text.Font(
                iTextSharp.text.Font.FontFamily.HELVETICA,
                8,
                iTextSharp.text.Font.NORMAL,
                BaseColor.BLACK
                );

            //escribir encabezado

            doc.Add(new Paragraph("Rally del Valle Fertil"));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), StandarFont));
            doc.Add(Chunk.NEWLINE);


            //encabezado columnas

            PdfPTable table = new PdfPTable(5);
            table.WidthPercentage = 100;
            string[] enca = new string[] { "Posición", "Vehículo", "Piloto", "Neto","Categoría" };
            encabezadoPDF(enca, ref table, ref doc);

            //agregando datos

            for (int i = 0; i < x.RowCount; i++)
            {
                if (x.Rows[i].Cells[3].Value.ToString()!="00:00:00")
                {
                    filaPDF(x.Rows[i], ref doc);
                    doc.Add(Chunk.NEWLINE);

                }
            }
            doc.Close();
            pw.Close();

            MessageBox.Show("Documento generado existosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {

                var ph = new Process();
                ph.StartInfo = new ProcessStartInfo(directions.Posiciones + "Generales.pdf")
                {
                    UseShellExecute = true
                };
                ph.Start();
            }
            catch (Exception err) { MessageBox.Show(err.Message); }
        }
        static public void PosicionesPorCategoria()
        {
            List<Carrera> listCar = CarreraService.findAll();
            FileStream p = new FileStream(directions.Posiciones + "Generales.pdf", FileMode.Create);
            Document doc = new Document(PageSize.LETTER, 5, 5, 7, 7);
            PdfWriter pw = PdfWriter.GetInstance(doc, p);
            doc.Open();
            //titulo y autor
            doc.AddTitle("Posiciones");
            doc.AddAuthor("Setigex.sj@hotmail.com");
            // define tipo de fuente (tipo,tamaño,forma,color)

            iTextSharp.text.Font StandarFont = new iTextSharp.text.Font(
                iTextSharp.text.Font.FontFamily.HELVETICA,
                8,
                iTextSharp.text.Font.NORMAL,
                BaseColor.BLACK
                );



            //escribir encabezado

            doc.Add(new Paragraph("Rally del Valle Fertil"));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), StandarFont));
            doc.Add(Chunk.NEWLINE);
            
            List<Participacion> lisOrd = new List<Participacion>();
            foreach(Carrera x in listCar) { 
            
            lisOrd = x.ListaPilotos.OrderBy(x => x.TiempoTotal()).ToList();

                
                if (x.ListaPilotos.Count > 0) { 
                    doc.Add(new Paragraph("Categoría: " + x.Nombre));
                    PdfPTable table = new PdfPTable(6);
                    table.WidthPercentage = 100;
                    string[] enca = new string[] { "Posición", "Vehículo", "Piloto", "Penalización", "Neto", "Total" };
                    encabezadoPDF(enca, ref table, ref doc);
                    int pos = 1;
                    for (int i = 0; i < lisOrd.Count(); i++)
                    {
                        if (lisOrd[i].TiempoTotal().ToString() != "00:00:00")
                        {
                            filaPDF(lisOrd[i], ref doc,ref pos);
                            Participacion newparti = ParticipacionService.findVehiculo(int.Parse(lisOrd[i].Vehiculo.ToString()));
                            enca = new string[] { "Ronda", "Tiempo" };
                            table = new PdfPTable(2);
                            table.WidthPercentage = 40;
                            encabezadoPDF(enca, ref table, ref doc);
                            List<string> detalle = newparti.DetalleRondas();
                            filaDetallePDF(detalle, ref doc);
                            doc.Add(Chunk.NEWLINE);

                        }


                    }
                }
                if (lisOrd.Count() > 0) { doc.Add(Chunk.NEWLINE); }
            }
            
            //agregando datos
            
            doc.Close();
            pw.Close();

            MessageBox.Show("Documento generado existosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {

                var ph = new Process();
                ph.StartInfo = new ProcessStartInfo(directions.Posiciones + "Generales.pdf")
                {
                    UseShellExecute = true
                };
                ph.Start();
            }
            catch (Exception err) { MessageBox.Show(err.Message); }
        }
        static public void PosicionesParaRadio()
        {
            List<Carrera> listCar = CarreraService.findAll();
            FileStream p = new FileStream(directions.Posiciones + "Generales.pdf", FileMode.Create);
            Document doc = new Document(PageSize.LETTER, 5, 5, 7, 7);
            PdfWriter pw = PdfWriter.GetInstance(doc, p);
            doc.Open();
            //titulo y autor
            doc.AddTitle("Posiciones");
            doc.AddAuthor("Setigex.sj@hotmail.com");
            // define tipo de fuente (tipo,tamaño,forma,color)

            iTextSharp.text.Font StandarFont = new iTextSharp.text.Font(
                iTextSharp.text.Font.FontFamily.HELVETICA,
                8,
                iTextSharp.text.Font.NORMAL,
                BaseColor.BLACK
                );



            //escribir encabezado

            doc.Add(new Paragraph("Rally del Valle Fertil"));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), StandarFont));
            doc.Add(Chunk.NEWLINE);

            List<Participacion> lisOrd = new List<Participacion>();
            foreach (Carrera x in listCar)
            {

                lisOrd = x.ListaPilotos.OrderBy(x => x.TiempoTotal()).ToList();


                if (x.ListaPilotos.Count > 0)
                {
                    doc.Add(new Paragraph("Categoría: " + x.Nombre));
                    PdfPTable table = new PdfPTable(6);
                    table.WidthPercentage = 100;
                    string[] enca = new string[] { "Posición", "Vehículo", "Piloto", "Penalización", "Neto", "Total" };
                    encabezadoPDF(enca, ref table, ref doc);
                    int pos = 1;
                    for (int i = 0; i < lisOrd.Count(); i++)
                    {
                        if (lisOrd[i].TiempoTotal().ToString() != "00:00:00")
                        {
                            filaPDF(lisOrd[i], ref doc, ref pos);
                      
                            doc.Add(Chunk.NEWLINE);

                        }


                    }
                }
                if (lisOrd.Count() > 0) { doc.Add(Chunk.NEWLINE); }
            }

            //agregando datos

            doc.Close();
            pw.Close();

            MessageBox.Show("Documento generado existosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {

                var ph = new Process();
                ph.StartInfo = new ProcessStartInfo(directions.Posiciones + "Generales.pdf")
                {
                    UseShellExecute = true
                };
                ph.Start();
            }
            catch (Exception err) { MessageBox.Show(err.Message); }
        }


        static public void CronometrajeManual()
        {
            List<Carrera> listCar = CarreraService.findAll();
            FileStream p = new FileStream(directions.Posiciones + "Generales.pdf", FileMode.Create);
            Document doc = new Document(PageSize.LETTER, 5, 5, 7, 7);
            PdfWriter pw = PdfWriter.GetInstance(doc, p);
            doc.Open();
            //titulo y autor
            doc.AddTitle("Posiciones");
            doc.AddAuthor("Setigex.sj@hotmail.com");
            // define tipo de fuente (tipo,tamaño,forma,color)

            iTextSharp.text.Font StandarFont = new iTextSharp.text.Font(
                iTextSharp.text.Font.FontFamily.HELVETICA,
                8,
                iTextSharp.text.Font.NORMAL,
                BaseColor.BLACK
                );



            //escribir encabezado

            doc.Add(new Paragraph("Rally del Valle Fertil"));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), StandarFont));
            doc.Add(Chunk.NEWLINE);

            List<Participacion> lisOrd = new List<Participacion>();
            foreach (Carrera x in listCar)
            {

                lisOrd = x.ListaPilotos.OrderBy(x => x.TiempoTotal()).ToList();


                if (x.ListaPilotos.Count > 0)
                {
                    doc.Add(new Paragraph("Categoría: " + x.Nombre));
                    PdfPTable table = new PdfPTable(6);
                    table.WidthPercentage = 100;
                    string[] enca = new string[] { "Posición", "Vehículo", "Piloto", "Penalización", "Neto", "Total" };
                    encabezadoPDF(enca, ref table, ref doc);
                    int pos = 1;
                    for (int i = 0; i < lisOrd.Count(); i++)
                    {
                        
                            filaPDF(lisOrd[i], ref doc, ref pos);
                            enca = new string[] { "Ronda", "largada", "llegada" };
                            table = new PdfPTable(3);
                            table.WidthPercentage = 60;
                            encabezadoPDF(enca, ref table, ref doc);

                            filasManualPDF(ref doc, 3);
                            doc.Add(Chunk.NEWLINE);
                    }
                }
                if (lisOrd.Count() > 0) { doc.Add(Chunk.NEWLINE); }
            }

            //agregando datos

            doc.Close();
            pw.Close();

            MessageBox.Show("Documento generado existosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {

                var ph = new Process();
                ph.StartInfo = new ProcessStartInfo(directions.Posiciones + "Generales.pdf")
                {
                    UseShellExecute = true
                };
                ph.Start();
            }
            catch (Exception err) { MessageBox.Show(err.Message); }
        }


        static public void InscripcionPDF(Participacion x) {

            FileStream p = new FileStream(directions.Inscripciones + x.PilotoX.Nombre+x.PilotoX.Apellido+".pdf", FileMode.Create);
            Document doc = new Document(PageSize.LETTER, 5, 5, 7, 7);
            PdfWriter pw = PdfWriter.GetInstance(doc, p);
            doc.Open();
            //titulo y autor
            doc.AddTitle("Inscripcion");
            doc.AddAuthor("Setigex.sj@hotmail.com");
            // define tipo de fuente (tipo,tamaño,forma,color)

            iTextSharp.text.Font StandarFont = new iTextSharp.text.Font(
                iTextSharp.text.Font.FontFamily.HELVETICA,
                8,
                iTextSharp.text.Font.NORMAL,
                BaseColor.BLACK
                );
            iTextSharp.text.Font StandarFont2 = new iTextSharp.text.Font(
               iTextSharp.text.Font.FontFamily.HELVETICA,
               14,
               iTextSharp.text.Font.NORMAL,
               BaseColor.BLACK
               );
            //escribir encabezado

            doc.Add(new Paragraph("FORMULARIO INSCRIPCIÓN MONOPLAZA"));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), StandarFont));
            doc.Add(Chunk.NEWLINE);

            DatosPiloto(doc,x);
            doc.Add(new Paragraph("	EN CASO DE EMERGENCIA LLAMAR:"));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase("Nombre y Apellido: ", StandarFont2));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase("Celular: ", StandarFont2));
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase(config.LeerBdBloque(directions.FormInscripcion), StandarFont));
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase("....................", StandarFont2));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase("Firma piloto", StandarFont2));
            doc.Close();
            pw.Close();
            MessageBox.Show("Documento generado existosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            try
            {
               
                var ph = new Process();
                ph.StartInfo = new ProcessStartInfo(directions.Inscripciones + x.PilotoX.Nombre + x.PilotoX.Apellido + ".pdf")
                {
                    UseShellExecute = true
                };
                ph.Start();
            } catch (Exception err) { MessageBox.Show(err.Message); }
        }
        static public void InscripcionPDF2(Participacion x)
        {

            FileStream p = new FileStream(directions.Inscripciones + x.PilotoX.Nombre + x.PilotoX.Apellido + ".pdf", FileMode.Create);
            Document doc = new Document(PageSize.LETTER, 5, 5, 7, 7);
            PdfWriter pw = PdfWriter.GetInstance(doc, p);
            doc.Open();
            //titulo y autor
            doc.AddTitle("Inscripcion");
            doc.AddAuthor("Setigex.sj@hotmail.com");
            // define tipo de fuente (tipo,tamaño,forma,color)

            iTextSharp.text.Font StandarFont = new iTextSharp.text.Font(
                iTextSharp.text.Font.FontFamily.HELVETICA,
                8,
                iTextSharp.text.Font.NORMAL,
                BaseColor.BLACK
                );
            iTextSharp.text.Font StandarFont2 = new iTextSharp.text.Font(
               iTextSharp.text.Font.FontFamily.HELVETICA,
               14,
               iTextSharp.text.Font.NORMAL,
               BaseColor.BLACK
               );
            //escribir encabezado

            doc.Add(new Paragraph("FORMULARIO INSCRIPCIÓN MONOPLAZA - KIDS"));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), StandarFont));
            doc.Add(Chunk.NEWLINE);

            DatosPiloto(doc,x);
            doc.Add(Chunk.NEWLINE);
            DatosResponsable(doc);
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase(config.LeerBdBloque(directions.FormInscripcion), StandarFont));
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase("....................", StandarFont2));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase("Firma piloto", StandarFont2));
            doc.Close();
            pw.Close();
            MessageBox.Show("Documento generado existosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            try
            {

                var ph = new Process();
                ph.StartInfo = new ProcessStartInfo(directions.Inscripciones + x.PilotoX.Nombre + x.PilotoX.Apellido + ".pdf")
                {
                    UseShellExecute = true
                };
                ph.Start();
            }
            catch (Exception err) { MessageBox.Show(err.Message); }
        }
        static public void InscripcionPDF3(Participacion x)
        {

            FileStream p = new FileStream(directions.Inscripciones + x.PilotoX.Nombre + x.PilotoX.Apellido + ".pdf", FileMode.Create);
            Document doc = new Document(PageSize.LETTER, 5, 5, 7, 7);
            PdfWriter pw = PdfWriter.GetInstance(doc, p);
            doc.Open();
            //titulo y autor
            doc.AddTitle("Inscripcion");
            doc.AddAuthor("Setigex.sj@hotmail.com");
            // define tipo de fuente (tipo,tamaño,forma,color)

            iTextSharp.text.Font StandarFont = new iTextSharp.text.Font(
                iTextSharp.text.Font.FontFamily.HELVETICA,
                8,
                iTextSharp.text.Font.NORMAL,
                BaseColor.BLACK
                );
            iTextSharp.text.Font StandarFont2 = new iTextSharp.text.Font(
               iTextSharp.text.Font.FontFamily.HELVETICA,
               14,
               iTextSharp.text.Font.NORMAL,
               BaseColor.BLACK
               );
            //escribir encabezado

            doc.Add(new Paragraph("FORMULARIO INSCRIPCIÓN MONOPLAZA"));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), StandarFont));
            doc.Add(Chunk.NEWLINE);
            DatosPiloto(doc,x);
            doc.Add(Chunk.NEWLINE);
            DatosCoPiloto(doc);
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("	EN CASO DE EMERGENCIA LLAMAR:"));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase("Nombre y Apellido: ", StandarFont2));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase("Celular: ", StandarFont2));
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase(config.LeerBdBloque(directions.FormInscripcion), StandarFont));
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase("....................", StandarFont2));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase("Firma piloto", StandarFont2));
            doc.Close();
            pw.Close();
            MessageBox.Show("Documento generado existosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            try
            {

                var ph = new Process();
                ph.StartInfo = new ProcessStartInfo(directions.Inscripciones + x.PilotoX.Nombre + x.PilotoX.Apellido + ".pdf")
                {
                    UseShellExecute = true
                };
                ph.Start();
            }
            catch (Exception err) { MessageBox.Show(err.Message); }
        }


        static public void DatosPiloto(Document doc, Participacion x) {


            iTextSharp.text.Font StandarFont = new iTextSharp.text.Font(
                iTextSharp.text.Font.FontFamily.HELVETICA,
                8,
                iTextSharp.text.Font.NORMAL,
                BaseColor.BLACK
                );
            iTextSharp.text.Font StandarFont2 = new iTextSharp.text.Font(
               iTextSharp.text.Font.FontFamily.HELVETICA,
               14,
               iTextSharp.text.Font.NORMAL,
               BaseColor.BLACK
               );

            //encabezado columnas

            PdfPTable tableEjemplo = new PdfPTable(2);
            tableEjemplo.WidthPercentage = 80;

            //configurando el titulo de las comunas
            PdfPCell piloto = new PdfPCell(new Phrase("Piloto", StandarFont2));
            piloto.BorderWidth = 0;
            piloto.BorderWidthBottom = 0.75f;

            PdfPCell info = new PdfPCell(new Phrase("información", StandarFont2));
            info.BorderWidth = 0;
            info.BorderWidthBottom = 0.75f;

            //añadir las columnas a la tabla

            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            //agregando datos

            piloto = new PdfPCell(new Phrase("Nombres", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase(x.PilotoX.Nombre, StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("Apellidos", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase(x.PilotoX.Apellido, StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("Nacionalidad", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase(x.PilotoX.Nacionalidad, StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("D.N.I", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase(x.PilotoX.Dni.ToString(), StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("Alergias", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase(x.PilotoX.Alergias, StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("Fecha nacimiento", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase(x.PilotoX.Nacimiento, StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("Edad", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase(x.PilotoX.Edad.ToString(), StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("Sexo", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase(x.PilotoX.Sexo, StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("Domicilio", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase(x.PilotoX.Domicilio, StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("Alergias", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase(x.PilotoX.Alergias, StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("E-Mail", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase(x.PilotoX.Email, StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("Celular", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase(x.PilotoX.Celular.ToString(), StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("Grupo Sanguineo", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase(x.PilotoX.Alojamiento, StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("Categoria", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase("", StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("Número Vehiculo", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase(x.Vehiculo.ToString(), StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            doc.Add(Chunk.NEWLINE);
            doc.Add(tableEjemplo);
            doc.Add(Chunk.NEWLINE);
        }
        static public void DatosResponsable(Document doc)
        {


            iTextSharp.text.Font StandarFont = new iTextSharp.text.Font(
                iTextSharp.text.Font.FontFamily.HELVETICA,
                8,
                iTextSharp.text.Font.NORMAL,
                BaseColor.BLACK
                );
            iTextSharp.text.Font StandarFont2 = new iTextSharp.text.Font(
               iTextSharp.text.Font.FontFamily.HELVETICA,
               14,
               iTextSharp.text.Font.NORMAL,
               BaseColor.BLACK
               );

            //encabezado columnas

            PdfPTable tableEjemplo = new PdfPTable(2);
            tableEjemplo.WidthPercentage = 80;

            //configurando el titulo de las comunas
            PdfPCell piloto = new PdfPCell(new Phrase("Responsable", StandarFont2));
            piloto.BorderWidth = 0;
            piloto.BorderWidthBottom = 0.75f;

            PdfPCell info = new PdfPCell(new Phrase("información", StandarFont2));
            info.BorderWidth = 0;
            info.BorderWidthBottom = 0.75f;

            //añadir las columnas a la tabla

            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            //agregando datos

            piloto = new PdfPCell(new Phrase("Nombres", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase("", StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("Apellidos", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase("", StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("Nacionalidad", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase("", StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("D.N.I", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase("", StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("Fecha nacimiento", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase("", StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("Edad", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase("", StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("Sexo", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase("", StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("Domicilio", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase("", StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("Alergias", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase("", StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("E-Mail", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase("", StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("Celular", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase("", StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("Grupo Sanguineo", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase("", StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            doc.Add(Chunk.NEWLINE);
            doc.Add(tableEjemplo);
            doc.Add(Chunk.NEWLINE);
        }
        static public void DatosCoPiloto(Document doc)
        {


            iTextSharp.text.Font StandarFont = new iTextSharp.text.Font(
                iTextSharp.text.Font.FontFamily.HELVETICA,
                8,
                iTextSharp.text.Font.NORMAL,
                BaseColor.BLACK
                );
            iTextSharp.text.Font StandarFont2 = new iTextSharp.text.Font(
               iTextSharp.text.Font.FontFamily.HELVETICA,
               14,
               iTextSharp.text.Font.NORMAL,
               BaseColor.BLACK
               );

            //encabezado columnas

            PdfPTable tableEjemplo = new PdfPTable(2);
            tableEjemplo.WidthPercentage = 80;

            //configurando el titulo de las comunas
            PdfPCell piloto = new PdfPCell(new Phrase("Responsable", StandarFont2));
            piloto.BorderWidth = 0;
            piloto.BorderWidthBottom = 0.75f;

            PdfPCell info = new PdfPCell(new Phrase("información", StandarFont2));
            info.BorderWidth = 0;
            info.BorderWidthBottom = 0.75f;

            //añadir las columnas a la tabla

            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            //agregando datos

            piloto = new PdfPCell(new Phrase("Nombres", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase("", StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("Apellidos", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase("", StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("Nacionalidad", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase("", StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("D.N.I", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase("", StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("Grupo Sanguineo", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase("", StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("Fecha nacimiento", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase("", StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("Edad", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase("", StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("Sexo", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase("", StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("Domicilio", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase("", StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("Alergias", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase("", StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("E-Mail", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase("", StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("Celular", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase("", StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            piloto = new PdfPCell(new Phrase("Grupo Sanguineo", StandarFont));
            piloto.BorderWidth = 0;
            info = new PdfPCell(new Phrase("", StandarFont));
            info.BorderWidth = 0;
            tableEjemplo.AddCell(piloto);
            tableEjemplo.AddCell(info);
            doc.Add(Chunk.NEWLINE);
            doc.Add(tableEjemplo);
            doc.Add(Chunk.NEWLINE);
        }
    }
}
