using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Herramientas.Archivos
{
    public class CSV
    {
        public static void EscribirDataGridViewACSV(String rutaArchivoCSV, DataGridView dgv)
        {
            int cols;
            //open file 
            StreamWriter wr = new StreamWriter(rutaArchivoCSV);

            //determine the number of columns and write columns to file 
            cols = dgv.Columns.Count;
            for (int i = 0; i < cols - 1; i++)
            {
                wr.Write(dgv.Columns[i].Name.ToString().ToUpper() + ",");
            }
            wr.WriteLine();

            //write rows to excel file
            for (int i = 0; i < (dgv.Rows.Count - 1); i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (dgv.Rows[i].Cells[j].Value != null)
                    {
                        wr.Write(dgv.Rows[i].Cells[j].Value + ",");
                    }
                    else
                    {
                        wr.Write(",");
                    }
                }

                wr.WriteLine();
            }

            //close file
            wr.Close();
        }
    }
}
