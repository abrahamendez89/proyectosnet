using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.IO;

namespace SendKeys
{
    public partial class SendKeysToApps : Form
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public SendKeysToApps()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Send keystrokes to application after finding it with its windows title and activating it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendKeys_Click(object sender, EventArgs e)
        {
            int iHandle = NativeWin32.FindWindow(null, txtTitle.Text);
            
            NativeWin32.SetForegroundWindow(iHandle);
            
            string keys = "";
            string space = " ";
            

            for (int i = 0; i < lbKeys.Items.Count; i++)
            {
                if (lbKeys.Items[i].Text.ToString() == "{SPACE}")
                {
                    keys += space;
                }
                else
                {
                    keys += lbKeys.Items[i].Text.ToString();
                }
            }

            System.Windows.Forms.SendKeys.Send(keys);
            
        }

        /// <summary>
        /// Find all the top leve windows running and add supported keys in the 'All Keys' listbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendKeysToApps_Load(object sender, EventArgs e)
        {
            //Getting windows titles of all top level application
            RefreshWindows();

            //Adding capital alphbets in the 'All Keys' listbox
            for (int i = 65; i < 91; i++)
            {
                lbAllKeys.Items.Add(Convert.ToChar(i).ToString());
            }

            //Adding all SendKeys class supported keys in the 'All Keys' listbox
            lbAllKeys.Items.Add("{BS}");
            lbAllKeys.Items.Add("{BREAK}");
            lbAllKeys.Items.Add("{CAPSLOCK}");
            lbAllKeys.Items.Add("{DEL}");
            lbAllKeys.Items.Add("{DOWN}");
            lbAllKeys.Items.Add("{END}");
            lbAllKeys.Items.Add("{ENTER}");
            lbAllKeys.Items.Add("{ESC}");
            lbAllKeys.Items.Add("{HELP}");
            lbAllKeys.Items.Add("{HOME}");
            lbAllKeys.Items.Add("{INSERT}");
            lbAllKeys.Items.Add("{LEFT}");
            lbAllKeys.Items.Add("{NUMLOCK}");
            lbAllKeys.Items.Add("PGDN}");
            lbAllKeys.Items.Add("{PGUP}");
            lbAllKeys.Items.Add("{PRTSC}");
            lbAllKeys.Items.Add("{RIGHT}");
            lbAllKeys.Items.Add("{SCROLLLOCK}");
            lbAllKeys.Items.Add("{SPACE}");
            lbAllKeys.Items.Add("{TAB}");
            lbAllKeys.Items.Add("{UP}");
            lbAllKeys.Items.Add("{F1}");
            lbAllKeys.Items.Add("{F2}");
            lbAllKeys.Items.Add("{F3}");
            lbAllKeys.Items.Add("{F4}");
            lbAllKeys.Items.Add("{F5}");
            lbAllKeys.Items.Add("{F6}");
            lbAllKeys.Items.Add("{F7}");
            lbAllKeys.Items.Add("{F8}");
            lbAllKeys.Items.Add("{F9}");
            lbAllKeys.Items.Add("{F10}");
            lbAllKeys.Items.Add("{F11}");
            lbAllKeys.Items.Add("{F12}");
            lbAllKeys.Items.Add("{F13}");
            lbAllKeys.Items.Add("{F14}");
            lbAllKeys.Items.Add("{F15}");
            lbAllKeys.Items.Add("{F16}");
            lbAllKeys.Items.Add("{ADD}");
            lbAllKeys.Items.Add("{SUBTRACT}");
            lbAllKeys.Items.Add("{MULTIPLY}");
            lbAllKeys.Items.Add("{DIVIDE}");

            lbAllKeys.Items.Add("SHIFT (+)");
            lbAllKeys.Items.Add("CTRL (^)");
            lbAllKeys.Items.Add("ALT (%)");

            //Adding number keys in the 'All Keys' listbox
            for (int i = 0; i < 10; i++)
                lbAllKeys.Items.Add(Convert.ToString(i));

        }

        /// <summary>
        /// Closing the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDone_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Refresh the combobox list with all the top level windows running on desktop.
        /// </summary>
        private void RefreshWindows()
        {
            cboWindows.Items.Clear();
            GetTaskWindows();
        }
        
        /// <summary>
        /// Allows combobox and textbox switching on selection of Auto and Manual.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptionSelection(object sender, EventArgs e)
        {
            if (rbAuto.Checked == true)
            {
                cboWindows.Visible = true;
                txtTitle.Text = cboWindows.Text;
                txtTitle.Visible = false;
            }
            else
            {
                cboWindows.Visible = false;
                txtTitle.Text = cboWindows.Text;
                txtTitle.Visible = true;
            }
        }

        /// <summary>
        /// Replicate the selected keys from 'Keys to Send' listbox into 'Keys to Send' listbox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkReplicate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int replication = Convert.ToInt32(numUpDown.Value.ToString());
            for (int t = 1; t <= replication; t++)
            {
                foreach (ListViewItem item in lbKeys.Items)
                {
                    if (item.Selected == true)
                        lbKeys.Items.Add(item.Text.ToString());
                }
            }
        }

        /// <summary>
        /// Delete the selected keys from 'Keys to Send' listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (ListViewItem item in lbKeys.Items)
            {
                if (item.Selected == true)
                    item.Remove();
            }
        }

        /// <summary>
        /// Add selected keys from 'All Keys' listbox to 'Keys to Send' listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (ListViewItem item in lbAllKeys.Items)
            {
                if (item.Selected == true)
                {
                    if (item.Text.IndexOf("(") != -1)
                    {
                        string s = item.Text.Substring(item.Text.IndexOf("(") + 1, 1);
                        lbKeys.Items.Add(s);
                    }
                    else
                        lbKeys.Items.Add(item.Text);
                }
            }
        }

        #region Serialization Services
        /// <summary>
        /// Load the keys from a text file into the 'Keys to Send' listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkLoad_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                rtFilename.Text = openFileDlg.FileName.ToString();

                StreamReader sr = new StreamReader(rtFilename.Text.ToString());
                string keystring = sr.ReadToEnd();
                sr.Close();

                string []keys = keystring.Substring(0,keystring.LastIndexOf(',')).Split(',');
                lbKeys.Items.Clear();
                foreach (string key in keys)
                {
                    lbKeys.Items.Add(key.ToString());
                }
            }

        }

        /// <summary>
        /// Save all the keys from 'Keys to Send' listbox into a text file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkSave_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (saveFileDlg.ShowDialog() == DialogResult.OK)
            {
                rtFilename.Text = saveFileDlg.FileName.ToString();
                StringBuilder sbKeys = new StringBuilder();

                foreach (ListViewItem item in lbKeys.Items)
                {
                    sbKeys.Append(item.Text);
                    sbKeys.Append(",");
                }


                StreamWriter sw = new StreamWriter(rtFilename.Text.ToString());
                sw.Write(sbKeys.ToString());
                sw.Flush();
                sw.Close();
                
            }
        }

        #endregion
        /// <summary>
        /// Refill the combobox with the currently running top level windows applications.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RefreshWindows();
        }
        /// <summary>
        /// Get all the top level visible windows
        /// </summary>
        private void GetTaskWindows()
        {
            // Get the desktopwindow handle
            int nDeshWndHandle = NativeWin32.GetDesktopWindow();
            // Get the first child window
            int nChildHandle = NativeWin32.GetWindow(nDeshWndHandle, NativeWin32.GW_CHILD);
                    	
            while (nChildHandle != 0)
	        {
                //If the child window is this (SendKeys) application then ignore it.
		        if (nChildHandle == this.Handle.ToInt32())
                {
                    nChildHandle = NativeWin32.GetWindow(nChildHandle, NativeWin32.GW_HWNDNEXT);
                }

                // Get only visible windows
                if (NativeWin32.IsWindowVisible(nChildHandle) != 0)
                {
                    StringBuilder sbTitle = new StringBuilder(1024);
                    // Read the Title bar text on the windows to put in combobox
                    NativeWin32.GetWindowText(nChildHandle, sbTitle, sbTitle.Capacity);
                    String sWinTitle = sbTitle.ToString();
                    {
                        if (sWinTitle.Length > 0)
                        {
                            cboWindows.Items.Add(sWinTitle);
                        }
                    }
                }
                // Look for the next child.
                nChildHandle = NativeWin32.GetWindow(nChildHandle, NativeWin32.GW_HWNDNEXT);
	        }
        }
    }
}