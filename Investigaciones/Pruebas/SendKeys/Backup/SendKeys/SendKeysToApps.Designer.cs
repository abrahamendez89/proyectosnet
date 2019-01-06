namespace SendKeys
{
    partial class SendKeysToApps
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.btnSendKeys = new System.Windows.Forms.Button();
            this.lbAllKeys = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDone = new System.Windows.Forms.Button();
            this.lbKeys = new System.Windows.Forms.ListView();
            this.numUpDown = new System.Windows.Forms.NumericUpDown();
            this.cboWindows = new System.Windows.Forms.ComboBox();
            this.rbManual = new System.Windows.Forms.RadioButton();
            this.rbAuto = new System.Windows.Forms.RadioButton();
            this.lnkReplicate = new System.Windows.Forms.LinkLabel();
            this.lnkDelete = new System.Windows.Forms.LinkLabel();
            this.lnkLoad = new System.Windows.Forms.LinkLabel();
            this.lnkSave = new System.Windows.Forms.LinkLabel();
            this.lnkAdd = new System.Windows.Forms.LinkLabel();
            this.rtFilename = new System.Windows.Forms.RichTextBox();
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDlg = new System.Windows.Forms.SaveFileDialog();
            this.lnkRefresh = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(32, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Windows Title:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(35, 41);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(502, 20);
            this.txtTitle.TabIndex = 1;
            // 
            // btnSendKeys
            // 
            this.btnSendKeys.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnSendKeys.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSendKeys.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.btnSendKeys.ForeColor = System.Drawing.Color.Blue;
            this.btnSendKeys.Location = new System.Drawing.Point(313, 401);
            this.btnSendKeys.Name = "btnSendKeys";
            this.btnSendKeys.Size = new System.Drawing.Size(99, 27);
            this.btnSendKeys.TabIndex = 2;
            this.btnSendKeys.Text = "Send Keys";
            this.btnSendKeys.UseVisualStyleBackColor = false;
            this.btnSendKeys.Click += new System.EventHandler(this.btnSendKeys_Click);
            // 
            // lbAllKeys
            // 
            this.lbAllKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbAllKeys.HideSelection = false;
            this.lbAllKeys.Location = new System.Drawing.Point(35, 91);
            this.lbAllKeys.Name = "lbAllKeys";
            this.lbAllKeys.Size = new System.Drawing.Size(502, 95);
            this.lbAllKeys.TabIndex = 4;
            this.lbAllKeys.TileSize = new System.Drawing.Size(168, 34);
            this.lbAllKeys.UseCompatibleStateImageBehavior = false;
            this.lbAllKeys.View = System.Windows.Forms.View.List;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(32, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "All Keys";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(32, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "Keys To Send";
            // 
            // btnDone
            // 
            this.btnDone.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDone.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.btnDone.ForeColor = System.Drawing.Color.Blue;
            this.btnDone.Location = new System.Drawing.Point(438, 401);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(99, 27);
            this.btnDone.TabIndex = 7;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = false;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // lbKeys
            // 
            this.lbKeys.HideSelection = false;
            this.lbKeys.Location = new System.Drawing.Point(35, 230);
            this.lbKeys.Name = "lbKeys";
            this.lbKeys.Size = new System.Drawing.Size(502, 95);
            this.lbKeys.TabIndex = 8;
            this.lbKeys.UseCompatibleStateImageBehavior = false;
            this.lbKeys.View = System.Windows.Forms.View.List;
            // 
            // numUpDown
            // 
            this.numUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numUpDown.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.numUpDown.Location = new System.Drawing.Point(469, 328);
            this.numUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUpDown.Name = "numUpDown";
            this.numUpDown.Size = new System.Drawing.Size(68, 22);
            this.numUpDown.TabIndex = 12;
            this.numUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cboWindows
            // 
            this.cboWindows.FormattingEnabled = true;
            this.cboWindows.Location = new System.Drawing.Point(35, 41);
            this.cboWindows.Name = "cboWindows";
            this.cboWindows.Size = new System.Drawing.Size(502, 21);
            this.cboWindows.TabIndex = 13;
            this.cboWindows.SelectedIndexChanged += new System.EventHandler(this.OptionSelection);
            // 
            // rbManual
            // 
            this.rbManual.AutoSize = true;
            this.rbManual.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.rbManual.Location = new System.Drawing.Point(312, 18);
            this.rbManual.Name = "rbManual";
            this.rbManual.Size = new System.Drawing.Size(72, 18);
            this.rbManual.TabIndex = 14;
            this.rbManual.Text = "Manual";
            this.rbManual.UseVisualStyleBackColor = true;
            this.rbManual.Click += new System.EventHandler(this.OptionSelection);
            // 
            // rbAuto
            // 
            this.rbAuto.AutoSize = true;
            this.rbAuto.Checked = true;
            this.rbAuto.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.rbAuto.Location = new System.Drawing.Point(209, 18);
            this.rbAuto.Name = "rbAuto";
            this.rbAuto.Size = new System.Drawing.Size(55, 18);
            this.rbAuto.TabIndex = 15;
            this.rbAuto.TabStop = true;
            this.rbAuto.Text = "Auto";
            this.rbAuto.UseVisualStyleBackColor = true;
            this.rbAuto.Click += new System.EventHandler(this.OptionSelection);
            // 
            // lnkReplicate
            // 
            this.lnkReplicate.AutoSize = true;
            this.lnkReplicate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkReplicate.Location = new System.Drawing.Point(393, 330);
            this.lnkReplicate.Name = "lnkReplicate";
            this.lnkReplicate.Size = new System.Drawing.Size(68, 14);
            this.lnkReplicate.TabIndex = 16;
            this.lnkReplicate.TabStop = true;
            this.lnkReplicate.Text = "Replicate";
            this.lnkReplicate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReplicate_LinkClicked);
            // 
            // lnkDelete
            // 
            this.lnkDelete.AutoSize = true;
            this.lnkDelete.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.lnkDelete.Location = new System.Drawing.Point(288, 330);
            this.lnkDelete.Name = "lnkDelete";
            this.lnkDelete.Size = new System.Drawing.Size(50, 14);
            this.lnkDelete.TabIndex = 17;
            this.lnkDelete.TabStop = true;
            this.lnkDelete.Text = "Delete";
            this.lnkDelete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDelete_LinkClicked);
            // 
            // lnkLoad
            // 
            this.lnkLoad.AutoSize = true;
            this.lnkLoad.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.lnkLoad.Location = new System.Drawing.Point(35, 330);
            this.lnkLoad.Name = "lnkLoad";
            this.lnkLoad.Size = new System.Drawing.Size(71, 14);
            this.lnkLoad.TabIndex = 18;
            this.lnkLoad.TabStop = true;
            this.lnkLoad.Text = "LoadKeys";
            this.lnkLoad.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLoad_LinkClicked);
            // 
            // lnkSave
            // 
            this.lnkSave.AutoSize = true;
            this.lnkSave.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.lnkSave.Location = new System.Drawing.Point(161, 330);
            this.lnkSave.Name = "lnkSave";
            this.lnkSave.Size = new System.Drawing.Size(72, 14);
            this.lnkSave.TabIndex = 19;
            this.lnkSave.TabStop = true;
            this.lnkSave.Text = "SaveKeys";
            this.lnkSave.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSave_LinkClicked);
            // 
            // lnkAdd
            // 
            this.lnkAdd.AutoSize = true;
            this.lnkAdd.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.lnkAdd.Location = new System.Drawing.Point(267, 199);
            this.lnkAdd.Name = "lnkAdd";
            this.lnkAdd.Size = new System.Drawing.Size(32, 14);
            this.lnkAdd.TabIndex = 20;
            this.lnkAdd.TabStop = true;
            this.lnkAdd.Text = "Add";
            this.lnkAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAdd_LinkClicked);
            // 
            // rtFilename
            // 
            this.rtFilename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtFilename.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.rtFilename.ForeColor = System.Drawing.Color.Maroon;
            this.rtFilename.Location = new System.Drawing.Point(35, 356);
            this.rtFilename.Multiline = false;
            this.rtFilename.Name = "rtFilename";
            this.rtFilename.ReadOnly = true;
            this.rtFilename.Size = new System.Drawing.Size(502, 22);
            this.rtFilename.TabIndex = 21;
            this.rtFilename.Text = "";
            // 
            // openFileDlg
            // 
            this.openFileDlg.Filter = "SendKeys Files (*.sky)|*.sky";
            // 
            // saveFileDlg
            // 
            this.saveFileDlg.DefaultExt = "sky";
            this.saveFileDlg.Filter = "SendKeys Files (*.sky)|*.sky";
            // 
            // lnkRefresh
            // 
            this.lnkRefresh.AutoSize = true;
            this.lnkRefresh.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.lnkRefresh.Location = new System.Drawing.Point(479, 22);
            this.lnkRefresh.Name = "lnkRefresh";
            this.lnkRefresh.Size = new System.Drawing.Size(58, 14);
            this.lnkRefresh.TabIndex = 22;
            this.lnkRefresh.TabStop = true;
            this.lnkRefresh.Text = "Refresh";
            this.lnkRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRefresh_LinkClicked);
            // 
            // SendKeysToApps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 453);
            this.Controls.Add(this.lnkRefresh);
            this.Controls.Add(this.rtFilename);
            this.Controls.Add(this.lnkAdd);
            this.Controls.Add(this.lnkSave);
            this.Controls.Add(this.lnkLoad);
            this.Controls.Add(this.lnkDelete);
            this.Controls.Add(this.lnkReplicate);
            this.Controls.Add(this.rbAuto);
            this.Controls.Add(this.rbManual);
            this.Controls.Add(this.cboWindows);
            this.Controls.Add(this.numUpDown);
            this.Controls.Add(this.lbKeys);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbAllKeys);
            this.Controls.Add(this.btnSendKeys);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SendKeysToApps";
            this.Text = "Send Keys to Application";
            this.Load += new System.EventHandler(this.SendKeysToApps_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Button btnSendKeys;
        private System.Windows.Forms.ListView lbAllKeys;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.ListView lbKeys;
        private System.Windows.Forms.NumericUpDown numUpDown;
        private System.Windows.Forms.ComboBox cboWindows;
        private System.Windows.Forms.RadioButton rbManual;
        private System.Windows.Forms.RadioButton rbAuto;
        private System.Windows.Forms.LinkLabel lnkReplicate;
        private System.Windows.Forms.LinkLabel lnkDelete;
        private System.Windows.Forms.LinkLabel lnkLoad;
        private System.Windows.Forms.LinkLabel lnkSave;
        private System.Windows.Forms.LinkLabel lnkAdd;
        private System.Windows.Forms.RichTextBox rtFilename;
        private System.Windows.Forms.OpenFileDialog openFileDlg;
        private System.Windows.Forms.SaveFileDialog saveFileDlg;
        private System.Windows.Forms.LinkLabel lnkRefresh;
    }
}

