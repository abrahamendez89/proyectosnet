using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Sistema.Mantenimiento
{
	/// <summary>
	/// Summary description for frmResultado.
	/// </summary>
	public class frmResultado : System.Windows.Forms.Form
	{
		public System.Windows.Forms.TextBox txtResultado;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmResultado()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtResultado = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtResultado
			// 
			this.txtResultado.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtResultado.Location = new System.Drawing.Point(0, 0);
			this.txtResultado.Multiline = true;
			this.txtResultado.Name = "txtResultado";
			this.txtResultado.Size = new System.Drawing.Size(280, 157);
			this.txtResultado.TabIndex = 0;
			this.txtResultado.Text = "";
			// 
			// frmResultado
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(280, 157);
			this.Controls.Add(this.txtResultado);
			this.Name = "frmResultado";
			this.Text = "frmResultado";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
