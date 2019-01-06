using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WebKitBrowserTest
{
    public partial class Monitoreo : Form
    {
        WebBrowserTabPage currentPage;
        public Monitoreo()
        {
            InitializeComponent();

            WebBrowserTabPage page = new WebBrowserTabPage();
            tabControl.TabPages.Add(page);
            currentPage = page;

            //RegisterBrowserEvents();

            currentPage.browser.Navigate("http://canal3.zz.mu/");
        }
    }
}
