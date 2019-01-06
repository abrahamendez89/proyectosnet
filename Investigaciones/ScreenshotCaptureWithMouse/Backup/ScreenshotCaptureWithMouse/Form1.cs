using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ScreenshotCaptureWithMouse.ScreenCapture;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;


namespace ScreenshotCaptureWithMouse
{
    public partial class sswithMouseForm : Form
    {
        public sswithMouseForm()
        {
            InitializeComponent();
        }


        private void sswithMouseForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData  == Keys.S )
            {
                Display(CaptureScreen.CaptureDesktopWithCursor());
            }
            else if (e.KeyData == Keys.C)
            {
                ClearViewer();
            }
            else if (e.KeyData == Keys.E)
            {
                this.Close();
            }
        }

        private void Display(Bitmap desktop)
        {
            Graphics g;
            Rectangle r;
             if (desktop != null)
             {
                 r = new Rectangle(0,0,ssWithMouseViewer.Width, ssWithMouseViewer.Height);
                 g = ssWithMouseViewer.CreateGraphics();
                 g.DrawImage(desktop,r);
                 g.Flush();
             }
        }

        private void ClearViewer()
        {
            ssWithMouseViewer.Image = null;           
        }

    }
}