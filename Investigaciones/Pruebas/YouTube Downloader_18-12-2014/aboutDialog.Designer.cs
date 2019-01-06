namespace YouTube_Downloader
{
    partial class aboutDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(aboutDialog));
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.ok_Button = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.title_Label = new System.Windows.Forms.Label();
            this.author_Label = new System.Windows.Forms.Label();
            this.modified_Label = new System.Windows.Forms.Label();
            this.copyright_Label = new System.Windows.Forms.Label();
            this.version_Label = new System.Windows.Forms.Label();
            this.line1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.ok_Button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 296);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(363, 48);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.SystemColors.Highlight;
            this.linkLabel1.Image = global::YouTube_Downloader.Properties.Resources.Web_Image;
            this.linkLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.linkLabel1.Location = new System.Drawing.Point(12, 18);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(80, 16);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Home page";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // ok_Button
            // 
            this.ok_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ok_Button.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ok_Button.Location = new System.Drawing.Point(271, 13);
            this.ok_Button.Name = "ok_Button";
            this.ok_Button.Size = new System.Drawing.Size(80, 23);
            this.ok_Button.TabIndex = 2;
            this.ok_Button.Text = "OK";
            this.ok_Button.UseVisualStyleBackColor = true;
            this.ok_Button.Click += new System.EventHandler(this.ok_Button_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 149);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(339, 135);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Chocolate;
            this.label1.Location = new System.Drawing.Point(95, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Code Project Open License (CPOL)";
            // 
            // title_Label
            // 
            this.title_Label.Font = new System.Drawing.Font("Tahoma", 10F);
            this.title_Label.Location = new System.Drawing.Point(66, 9);
            this.title_Label.Name = "title_Label";
            this.title_Label.Size = new System.Drawing.Size(285, 18);
            this.title_Label.TabIndex = 6;
            this.title_Label.Text = "{Title}";
            // 
            // author_Label
            // 
            this.author_Label.Location = new System.Drawing.Point(66, 52);
            this.author_Label.Name = "author_Label";
            this.author_Label.Size = new System.Drawing.Size(285, 13);
            this.author_Label.TabIndex = 7;
            this.author_Label.Text = "{Author}";
            // 
            // modified_Label
            // 
            this.modified_Label.Location = new System.Drawing.Point(66, 69);
            this.modified_Label.Name = "modified_Label";
            this.modified_Label.Size = new System.Drawing.Size(285, 13);
            this.modified_Label.TabIndex = 8;
            this.modified_Label.Text = "{Modified}";
            // 
            // copyright_Label
            // 
            this.copyright_Label.Location = new System.Drawing.Point(66, 92);
            this.copyright_Label.Name = "copyright_Label";
            this.copyright_Label.Size = new System.Drawing.Size(285, 13);
            this.copyright_Label.TabIndex = 9;
            this.copyright_Label.Text = "{Copyright}";
            // 
            // version_Label
            // 
            this.version_Label.Location = new System.Drawing.Point(66, 35);
            this.version_Label.Name = "version_Label";
            this.version_Label.Size = new System.Drawing.Size(285, 13);
            this.version_Label.TabIndex = 7;
            this.version_Label.Text = "{Version}";
            // 
            // line1
            // 
            this.line1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.line1.BackColor = System.Drawing.Color.LightGray;
            this.line1.Location = new System.Drawing.Point(1, 135);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(361, 1);
            this.line1.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::YouTube_Downloader.Properties.Resources.About_Image;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // aboutDailog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(363, 344);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.copyright_Label);
            this.Controls.Add(this.modified_Label);
            this.Controls.Add(this.version_Label);
            this.Controls.Add(this.author_Label);
            this.Controls.Add(this.title_Label);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "aboutDailog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About {AppName}";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ok_Button;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label title_Label;
        private System.Windows.Forms.Label author_Label;
        private System.Windows.Forms.Label modified_Label;
        private System.Windows.Forms.Label copyright_Label;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label version_Label;
        private System.Windows.Forms.Label line1;
        private System.Windows.Forms.LinkLabel linkLabel1;

    }
}
