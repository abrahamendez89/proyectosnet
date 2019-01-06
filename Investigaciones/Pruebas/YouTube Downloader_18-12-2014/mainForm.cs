//Copy rights are reserved for Akram kamal qassas
//Email me, Akramnet4u@hotmail.com
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace YouTube_Downloader
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void down_Button_Click(object sender, EventArgs e)
        {
            try
            {
                YouTubeVideoQuality tempItem = quality_ComboBox.SelectedItem as YouTubeVideoQuality;
                saveFileDialog1.Filter = String.Format("{0} Files|*.{1}", tempItem.Extention.ToUpper(), tempItem.Extention.ToLower());
                saveFileDialog1.FileName = FormatTitle(tempItem.VideoTitle);

                if (DialogResult.OK != saveFileDialog1.ShowDialog(this)) return;
                new frmFileDownloader(tempItem.DownloadUrl, saveFileDialog1.FileName).Show(this);
            }
            catch (Exception ex) { MessageBox.Show(this, ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = YouTubeDownloader.GetYouTubeVideoUrls(e.Argument + "");
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                UseWaitCursor = false;
                if (e.Error != null)
                    throw e.Error;

                List<YouTubeVideoQuality> urls = e.Result as List<YouTubeVideoQuality>;
                quality_ComboBox.DataSource = urls;
                TimeSpan videoLength = TimeSpan.FromSeconds(urls[0].Length);
                if (videoLength.Hours > 0)
                    drawVideoLenght(String.Format("{0}:{1}:{2}", videoLength.Hours, videoLength.Minutes, videoLength.Seconds));
                else drawVideoLenght(String.Format("{0}:{1}", videoLength.Minutes, videoLength.Seconds));

                name_Label2.Text = urls.Count > 0 ? FormatTitle(urls[0].VideoTitle) : "";
                quality_ComboBox.Enabled = url_TextBox.Enabled = urls.Count>0;
                progressBar1.Visible = false;

            }
            catch (Exception ex)
            {
                ex = ex.InnerException??ex;
                MessageBox.Show(this, ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                url_TextBox.Enabled = true;
                progressBar1.Hide();
            }
        }

  

        public static string FormatTitle(string title)
        {
            return title.Replace(@"\", "").Replace("&#39;", "'").Replace("&quot;", "'").Replace("&lt;", "(").Replace("&gt;", ")").Replace("+", " ").Replace(":", "-");
        }

        private void get_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Helper.isValidUrl(url_TextBox.Text) || !url_TextBox.Text.ToLower().Contains("www.youtube.com/watch?"))
                    MessageBox.Show(this, "You enter invalid YouTube URL, Please correct it.\r\n\nNote: URL should start with:\r\nhttp://www.youtube.com/watch?",
                        "Invalid URL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    get_Button.Enabled = url_TextBox.Enabled = false;
                    progressBar1.Visible = true;
                    video_PictureBox.ImageLocation = string.Format("http://i3.ytimg.com/vi/{0}/default.jpg", Helper.GetVideoIDFromUrl(url_TextBox.Text));
                    backgroundWorker1.RunWorkerAsync(url_TextBox.Text);
                }
            }
            catch (Exception ex) { MessageBox.Show(this, ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void copy_Button_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText((quality_ComboBox.SelectedItem as YouTubeVideoQuality).DownloadUrl);
                MessageBox.Show(this, "URL copied to clipboard", "YouTube Downloader", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show(this, ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void textBoxUrl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                get_Button_Click(null, null);
            }
        }

        private void url_TextBox_TextChanged(object sender, EventArgs e)
        {
            get_Button.Enabled = !String.IsNullOrEmpty(url_TextBox.Text);

            video_PictureBox.Image = null;
            quality_ComboBox.DataSource = null ;
            quality_ComboBox.Enabled = false;
            name_Label2.Text = "--";
        }

        private void quality_ComboBox_EnabledChanged(object sender, EventArgs e)
        {
            down_Button.Enabled = quality_ComboBox.Enabled;
            copy_Button.Enabled = quality_ComboBox.Enabled;
        }

        private void paste_Button_Click(object sender, EventArgs e)
        {
            url_TextBox.Clear();
            url_TextBox.Text = Clipboard.GetText().Trim();
        }

        private void exit_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new aboutDialog().ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            paste_Button.Enabled =!backgroundWorker1.IsBusy&& !String.IsNullOrEmpty(Clipboard.GetText());
        }

        private void grop_Panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.Gainsboro), new Rectangle(0, 0, grop_Panel1.Width - 1, grop_Panel1.Height - 1));
            e.Graphics.DrawRectangle(new Pen(Color.White), new Rectangle(1, 1, grop_Panel1.Width - 3, grop_Panel1.Height - 3));
        }

        private void grop_Panel2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.Gainsboro), new Rectangle(0, 0, grop_Panel2.Width - 1, grop_Panel2.Height - 1));
            e.Graphics.DrawRectangle(new Pen(Color.White), new Rectangle(1, 1, grop_Panel2.Width - 3, grop_Panel2.Height - 3));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.DrawLine(new Pen(Color.Silver, 2), new Point(0, 1), new Point(panel1.Width, 1));
            //Rectangle Rec1 = new Rectangle(0, 0, panel1.Width, panel1.Height);
            //Brush LGBrush = new System.Drawing.Drawing2D.LinearGradientBrush(Rec1, Color.WhiteSmoke, Color.Gainsboro, 90);
            //e.Graphics.FillRectangle(LGBrush, Rec1);
            e.Graphics.DrawLine(new Pen(Color.Silver, 2), new Point(0, 1), new Point(panel1.Width, 1));
            //e.Graphics.DrawLine(new Pen(Color.White), new Point(0, 1), new Point(panel1.Width, 1));
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            //Rectangle Rec1 = new Rectangle(0, 0, panel2.Width, panel2.Height);
            //Brush LGBrush = new System.Drawing.Drawing2D.LinearGradientBrush(Rec1, Color.WhiteSmoke, Color.Gainsboro, 90);
            //e.Graphics.FillRectangle(LGBrush, Rec1);
            e.Graphics.DrawLine(new Pen(Color.DarkRed), new Point(0, panel2.Height - 1), new Point(panel2.Width, panel2.Height - 1));
            //e.Graphics.DrawLine(new Pen(Color.FromArgb(100, Color.White)), new Point(0, panel2.Height - 2), new Point(panel2.Width, panel2.Height - 2));
        }
        private void drawVideoLenght(string lenght)
        {
            //video_PictureBox.Update();
            video_PictureBox.Refresh();

            Graphics e = video_PictureBox.CreateGraphics();
            Font mFont = new Font(this.Font.Name, 10.0F, FontStyle.Bold, GraphicsUnit.Point);
            SizeF mSize = e.MeasureString(lenght, mFont);
            Rectangle mRec = new Rectangle((int)(video_PictureBox.Width - mSize.Width - 6),
                                           (int)(video_PictureBox.Height - mSize.Height - 6),
                                           (int)(mSize.Width + 2),
                                           (int)(mSize.Height + 2));

            e.FillRectangle(new SolidBrush(Color.FromArgb(200, Color.Black)), mRec);
            e.DrawString(lenght, mFont, new SolidBrush(Color.Gainsboro), new PointF((video_PictureBox.Width - mSize.Width - 5),
                                                                                (video_PictureBox.Height - mSize.Height - 5)));
            e.Dispose();
        }
    }
}
