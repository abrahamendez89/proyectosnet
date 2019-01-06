using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Herramientas.Archivos
{
    public class PDF
    {
        public static void ExportarDataGridViewToPDF(List<DataGridView> dgGrids, String rutaArchivoPDF, List<String> Encabezados, Boolean usarNumeroPagina, List<String> TitulosGrids)
        {
            //Creating iTextSharp Table from the DataTable data

            Font fontH1 = new Font(iTextSharp.text.Font.COURIER, 7, Font.NORMAL);
            BaseFont bf = BaseFont.CreateFont(
                        BaseFont.TIMES_ROMAN,
                        BaseFont.CP1252,
                        BaseFont.EMBEDDED);
            Font font = new Font(bf, 8);

            List<PdfPTable> tablasPDF = new List<PdfPTable>();
            foreach (DataGridView dgv in dgGrids)
            {

                PdfPTable pdfTable = new PdfPTable(dgv.ColumnCount);
                pdfTable.DefaultCell.Padding = 3;
                pdfTable.DefaultCell.Phrase = new Phrase() { Font = fontH1 };

                List<float> anchos = new List<float>();
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    anchos.Add((float)column.Width * (float)2);
                }

                pdfTable.WidthPercentage = 100;
                pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfTable.DefaultCell.BorderWidth = 1;
                pdfTable.SetWidths(anchos.ToArray());

                //Adding Header row
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, font));
                    cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                    anchos.Add((float)column.Width * 2);
                    cell.FixedHeight = 22;
                    pdfTable.AddCell(cell);
                }
                //Adding DataRow
                foreach (DataGridViewRow row in dgv.Rows)
                {

                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Style.ForeColor == System.Drawing.Color.White)
                        {

                        }

                        BaseFont bf2 = BaseFont.CreateFont(
                        BaseFont.TIMES_ROMAN,
                        BaseFont.CP1252,
                        BaseFont.EMBEDDED);
                        Font font2 = new Font(bf, 8, Font.NORMAL, new Color(cell.Style.ForeColor));

                        Font temp = font;
                        temp.Color = new iTextSharp.text.Color(cell.Style.ForeColor);
                        PdfPCell cell2 = new PdfPCell(new Phrase(cell.Value.ToString(), font2));
                        System.Drawing.Color colorCelda = System.Drawing.Color.White;
                        if(!cell.Style.BackColor.IsEmpty)
                            colorCelda = cell.Style.BackColor;

                        cell2.BackgroundColor = new iTextSharp.text.Color(colorCelda);
                        
                        //cell2.FixedHeight = 50;

                        pdfTable.AddCell(cell2);
                    }
                }
                tablasPDF.Add(pdfTable);
            }

            using (FileStream stream = new FileStream(rutaArchivoPDF, FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4, 15f, 15f, 40f, 40f);
                PdfWriter.GetInstance(pdfDoc, stream);

                

                String encs = "";

                if (Encabezados != null)
                {
                    foreach (String encabezado in Encabezados)
                        encs += encabezado + "\n";

                    encs = encs.Substring(0, encs.Length - 1);
                    HeaderFooter header = new HeaderFooter(new Phrase(encs,font), false) { Border = Rectangle.NO_BORDER, Alignment = Element.ALIGN_CENTER };
                    pdfDoc.Header = header;
                }
                if (usarNumeroPagina)
                {
                    HeaderFooter footer = new HeaderFooter(new Phrase("Página: ", font), true) { Border = Rectangle.NO_BORDER, Alignment = Element.ALIGN_CENTER };
                    pdfDoc.Footer = footer;
                }

                pdfDoc.Open();
                for(int i = 0; i < tablasPDF.Count; i++)
                {
                    PdfPTable pdfTabla = tablasPDF[i];
                    pdfDoc.Add(new Paragraph(TitulosGrids[i],font));
                    pdfDoc.Add(new Paragraph("        ", font));
                    pdfDoc.Add(pdfTabla);
                }
                pdfDoc.Close();
                stream.Close();
            }
        }

    }
}
