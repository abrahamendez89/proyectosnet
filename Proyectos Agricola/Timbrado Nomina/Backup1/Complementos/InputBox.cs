using System;
using System.Windows.Forms;
using System.Data;

namespace Sistema
{
	///<summary>
	/// Clase equivalente InputBox de Visual Basic.
	/// </summary>

	public class InputBox : System.Windows.Forms.Form
	{
		#region Atributos 
		private System.Windows.Forms.Label lblInfo;
		private System.Windows.Forms.TextBox txtTexto;
		private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Button btnTodos;
		
		private System.ComponentModel.Container components = null;
		#endregion

		#region Constructor/InitializeComponent/Dispose 
		private InputBox()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Limpia los recursos del objeto
		/// </summary>
		/// <param name="disposing">.</param>
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

		private void InitializeComponent()
		{
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnTodos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTexto
            // 
            this.txtTexto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTexto.Location = new System.Drawing.Point(6, 112);
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(306, 22);
            this.txtTexto.TabIndex = 0;
            this.txtTexto.TextChanged += new System.EventHandler(this.txtTexto_TextChanged);
            // 
            // lblInfo
            // 
            this.lblInfo.BackColor = System.Drawing.Color.Gainsboro;
            this.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblInfo.Location = new System.Drawing.Point(6, 8);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(226, 96);
            this.lblInfo.TabIndex = 1;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAceptar.Location = new System.Drawing.Point(8, 144);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(94, 28);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Location = new System.Drawing.Point(216, 144);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(94, 28);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnTodos
            // 
            this.btnTodos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTodos.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.btnTodos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTodos.Location = new System.Drawing.Point(112, 144);
            this.btnTodos.Name = "btnTodos";
            this.btnTodos.Size = new System.Drawing.Size(94, 28);
            this.btnTodos.TabIndex = 2;
            this.btnTodos.Text = "&Todos";
            this.btnTodos.UseVisualStyleBackColor = false;
            this.btnTodos.Visible = false;
            // 
            // InputBox
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.BackColor = System.Drawing.Color.LightGray;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(314, 178);
            this.ControlBox = false;
            this.Controls.Add(this.btnTodos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.txtTexto);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InputBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Access - Input";
            this.Load += new System.EventHandler(this.InputBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
 
		#endregion
 
		/// <summary>
		/// Ejecuta InputBox.
		/// </summary>
		/// <param name="prompt">Cadena de pregunta del InputBox.</param>
		/// <returns>Devuelve cadena introducida por el usuario si DialgoResult es OK.</returns>

		public  static string ShowInputBox(string prompt)
		{
			InputBox box = new InputBox();			
			box.lblInfo.Text = prompt;
			box.txtTexto.Text = "";
			box.ShowDialog();

			if (box.DialogResult == DialogResult.OK)
				return box.txtTexto.Text;
			else
				return "*";
		}

		private void txtTexto_TextChanged(object sender, System.EventArgs e)
		{
			if (txtTexto.Text!="")
			{
				btnAceptar.Enabled =true;
			}
			else
			{
				btnAceptar.Enabled =false;
			}
		}

		private void InputBox_Load(object sender, System.EventArgs e)
		{
			btnAceptar.Enabled=false; 
		}

		/// <summary>
		/// Ejecuta InputBox.
		/// </summary>
		/// <param name="prompt">Cadena de pregunta del InputBox.</param>
		/// <param name="title">Titulo del InputBox.</param>
		/// <param name="defaultValue">Valor por defecto en la casilla de entra de texto.</param>
		/// <returns>Devuelve cadena introducida por el usuario si DialgoResult es OK.</returns>

		public static string ShowInputBox(string prompt, string title, string defaultValue ,int maxLength)
		{
			InputBox box = new InputBox();
			box.Text = title;
			box.lblInfo.Text = prompt;
			box.txtTexto.Text = defaultValue;
            box.txtTexto.MaxLength = maxLength;
			box.ShowDialog();

			if (box.DialogResult == DialogResult.OK)
				return box.txtTexto.Text;
			else
				return "*";
		}   
  
        
		/// <summary>
		/// Ejecuta InputBox.
		/// </summary>
		/// <param name="prompt">Cadena de pregunta del InputBox.</param>
		/// <param name="title">Titulo del InputBox.</param>
		/// <param name="defaultValue">Valor por defecto en la casilla de entra de texto.</param>
		/// <param name="mostrarOpcionTodos">Muestra un boton para poder elegir la opcion de todos.</param>
		/// <returns>Devuelve cadena introducida por el usuario si DialgoResult es OK.</returns>
		public static string ShowInputBox(string prompt, string title, string defaultValue ,bool mostrarOpcionTodos)
		{
			InputBox box = new InputBox();
			box.Text = title;
			box.lblInfo.Text = prompt;
			box.txtTexto.Text = defaultValue;
			box.btnTodos.Visible = mostrarOpcionTodos;
			box.ShowDialog();

			if (box.DialogResult == DialogResult.OK)
				return box.txtTexto.Text;
			else
			{
				if (box.DialogResult == DialogResult.Ignore)
					return "@";
				else
					return "*";
			}
		}   

		/// <summary>
		/// Ejecuta InputBox.
		/// </summary>
		/// <param name="prompt">Cadena de pregunta del InputBox.</param>
		/// <param name="title">Titulo del InputBox.</param>
		/// <param name="defaultValue">Valor por defecto en la casilla de entra de texto.</param>
		/// <param name="XPos">Posiciona el InputBox en la coordenada X horizontal.</param>
		/// <param name="YPos">Posiciona el InputBox en la coordenada Y vertical.</param>
		/// <returns>Devuelve cadena introducida por el usuario si DialgoResult es OK.</returns>

		public  static string ShowInputBox(string prompt, string title, string defaultValue, int XPos, int YPos)
		{
			InputBox box = new InputBox();
			box.Text = title;
			box.lblInfo.Text = prompt;
			box.txtTexto.Text = defaultValue;
			box.Location = new System.Drawing.Point(XPos,YPos);			
			box.ShowDialog();

			if (box.DialogResult == DialogResult.OK)
				return box.txtTexto.Text;
			else
				return "*";
		}

	}


}