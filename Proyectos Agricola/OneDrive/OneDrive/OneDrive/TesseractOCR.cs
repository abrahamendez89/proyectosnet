using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace OneDrive
{
    public class TesseractOCR
    {
        private string commandpath;
        private string outpath;
        private string tmppath;

        public TesseractOCR(string commandpath, string tempDir)
        {
            this.commandpath = commandpath;
            var guidImage = Guid.NewGuid();

            tmppath = tempDir + @"\" + guidImage + ".tif";
            outpath = tempDir + @"\" + guidImage + ".txt";
        }
        public string analyze(string filename)
        {
            var timeout = 1000 * 60;
            string args = filename + " " + outpath.Replace(".txt", "");


            string ret = "";



            using (Process process = new Process())
            {
                process.StartInfo.FileName = commandpath;
                process.StartInfo.Arguments = args;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;

                StringBuilder output = new StringBuilder();
                StringBuilder error = new StringBuilder();

                using (AutoResetEvent outputWaitHandle = new AutoResetEvent(false))
                using (AutoResetEvent errorWaitHandle = new AutoResetEvent(false))
                {
                    process.OutputDataReceived += (sender, e) =>
                    {
                        if (e.Data == null)
                        {
                            outputWaitHandle.Set();
                        }
                        else
                        {
                            output.AppendLine(e.Data);
                        }
                    };
                    process.ErrorDataReceived += (sender, e) =>
                    {
                        if (e.Data == null)
                        {
                            errorWaitHandle.Set();
                        }
                        else
                        {
                            error.AppendLine(e.Data);
                        }
                    };

                    process.Start();

                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();

                    if (process.WaitForExit(timeout) &&
                        outputWaitHandle.WaitOne(timeout) &&
                        errorWaitHandle.WaitOne(timeout))
                    {
                        using (StreamReader r = new StreamReader(outpath))
                        {
                            string content = r.ReadToEnd();
                            ret = content;
                        }
                        File.Delete(outpath);
                    }
                    else
                    {
                        throw new Exception("Time out" + error.ToString());
                    }
                }
            }
            return ret.Trim();
        }
        public string OCRFromBitmap(Bitmap bmp)
        {
            bmp.Save(tmppath, System.Drawing.Imaging.ImageFormat.Tiff);
            string ret = analyze(tmppath);
            File.Delete(tmppath);
            return ret;
        }
        public string OCRFromFile(string filename)
        {
            return analyze(filename);
        }
    }
}
