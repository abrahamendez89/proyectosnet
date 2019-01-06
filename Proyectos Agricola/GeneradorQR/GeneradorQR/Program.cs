using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThoughtWorks.QRCode;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
using System.Drawing;

namespace GeneradorQR
{
    class Program
    {

        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                String contenido = "";
                foreach (String s in args)
                    contenido += s + " ";
                contenido = contenido.Substring(0, contenido.Length - 1);
                Bitmap imagenQR = Codificar(contenido);
                Console.WriteLine("Código QR generado para: " + contenido);
                Console.ReadLine();
            }
        }

        private static Bitmap Codificar(String contenido)
        {
            QRCodeEncoder codificador = new QRCodeEncoder();
            codificador.QRCodeBackgroundColor = Color.White;
            codificador.QRCodeForegroundColor = Color.Black;
            codificador.QRCodeScale = 3;
            codificador.QRCodeVersion = 0;
            codificador.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            Bitmap imagenQR = null;
            try
            {
                string winpath = System.Environment.SystemDirectory;
                String unidadWin = winpath.Substring(0, 1);
                imagenQR = codificador.Encode(contenido, Encoding.UTF8);
                imagenQR.Save(unidadWin+":\\crop\\imagenQR.jpg",System.Drawing.Imaging.ImageFormat.Jpeg);
                //imagenQR.Save("imagenQR.jpeg");

            }
            catch(Exception ex) { Console.WriteLine("Error: "+ex.Message); }
            return imagenQR;
        }

        private static String Decodificar(Bitmap imagenQR)
        {
            QRCodeDecoder decodificador = new QRCodeDecoder();
            QRCodeBitmapImage cbi = new QRCodeBitmapImage(imagenQR);
            String contenido = decodificador.decode(cbi);
            return contenido;
        }
    }
}
