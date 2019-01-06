using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GeneradorPrototipos
{
    public partial class Editor : Form
    {
        Boolean moviendo;
        int offsetX;
        int offsetY;
        Control controlMoviendo;
        List<TabControl> tabControls = new List<TabControl>();

        public Editor()
        {
            InitializeComponent();
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            if (cmb_Controles.SelectedItem == null) return;

            Control control = null;
            if (cmb_Controles.SelectedItem.ToString().Equals("Botón"))
            {
                control = new Button();
                control.Text = "Botón";
            }
            else if (cmb_Controles.SelectedItem.ToString().Equals("TextBox"))
            {
                control = new TextBox();
                
            }
            else if (cmb_Controles.SelectedItem.ToString().Equals("ComboBox"))
            {
                control = new ComboBox();
                ((ComboBox)control).Items.Add("Elemento 1");
                ((ComboBox)control).Items.Add("Elemento 2");
                ((ComboBox)control).Items.Add("Elemento 3");
                ((ComboBox)control).DropDownStyle = ComboBoxStyle.DropDownList;
            }
            else if (cmb_Controles.SelectedItem.ToString().Equals("Lista"))
            {
                control = new ListBox();
                ((ListBox)control).Items.Add("Elemento 1");
                ((ListBox)control).Items.Add("Elemento 2");
                ((ListBox)control).Items.Add("Elemento 3");
            }
            else if (cmb_Controles.SelectedItem.ToString().Equals("Grid"))
            {
                control = new DataGrid();

                DataTable dt = new DataTable();

                dt.Columns.Add("Columna 1");
                dt.Columns.Add("Columna 2");
                dt.Columns.Add("Columna 3");
                ((DataGrid)control).Size = new Size(300, 200);
                ((DataGrid)control).DataSource = dt;
            }
            else if (cmb_Controles.SelectedItem.ToString().Equals("Imagen"))
            {
                control = new PictureBox();
                ((PictureBox)control).SizeMode = PictureBoxSizeMode.StretchImage;
                ((PictureBox)control).Image = new Bitmap("imagen.png");
                ((PictureBox)control).Size = new Size(100, 100);
            }
            else if (cmb_Controles.SelectedItem.ToString().Equals("Label"))
            {
                control = new Label();
                ((Label)control).Text = "Etiqueta";
                ((Label)control).Size = new Size(((Label)control).Text.Length * 7, 20);
            }
            else if (cmb_Controles.SelectedItem.ToString().Equals("TabControl"))
            {
                control = new TabControl();
                ((TabControl)control).TabPages.Add("Pestaña 1");
                ((TabControl)control).TabPages.Add("Pestaña 2");
                ((TabControl)control).TabPages.Add("Pestaña 3");
                ((TabControl)control).Size = new Size(400,400);
                tabControls.Add(((TabControl)control));
            }
            //Control control = new ListBox();


            control.MouseDown += control_MouseDown;
            control.MouseMove += control_MouseMove;
            control.MouseUp += control_MouseUp;
            control.MouseDoubleClick += control_MouseDoubleClick;

            this.pnl_Controles.MouseClick += Form1_MouseDoubleClick;

            pnl_Controles.Controls.Add(control);
        }

        void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            direccion = 0;
            this.Cursor = Cursors.Default;
            controlMoviendo = null;
        }

        void control_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //habilitar funcionamiento especial
        }
        Color anterior;
        private void control_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender == null) return;
            if (e.Button == MouseButtons.Left)
            {
                moviendo = true;
                offsetX = e.X;
                offsetY = e.Y;
                controlMoviendo = (Control)sender;
                anterior = controlMoviendo.BackColor;
                controlMoviendo.BackColor = Color.LightBlue;
            }
            if (e.Button == MouseButtons.Right)
            {
                controlMoviendo = (Control)sender;
                Point CurPos = e.Location;
                Point esquina = new Point(controlMoviendo.Width, controlMoviendo.Height);
                
                if (direccion == 0)
                {
                    if (CurPos.Y > esquina.Y - 10 && CurPos.Y < esquina.Y + 10)
                    {
                        direccion = 1;
                    }
                    else if (CurPos.X > esquina.X - 10 && CurPos.X < esquina.X + 10)
                    {
                        direccion = -1;
                    }
                    else
                        direccion = 0;
                }
            }
        }
        int direccion = 0;
        private void control_MouseMove(object sender, MouseEventArgs e)
        {
            Point CurPos = e.Location;


            Point esquina = new Point(((Control)sender).Width, ((Control)sender).Height);
            if (direccion == 0)
            {
                if (CurPos.Y > esquina.Y - 10 && CurPos.Y < esquina.Y + 10)
                {
                    this.Cursor = Cursors.SizeNS;
                }
                else if (CurPos.X > esquina.X - 10 && CurPos.X < esquina.X + 10)
                {
                    this.Cursor = Cursors.SizeWE;
                }
                else
                    this.Cursor = Cursors.Default;
            }
            if (controlMoviendo == null) return;
            if (direccion == 1)
            {
                controlMoviendo.Height = controlMoviendo.Height + CurPos.Y - esquina.Y;
            }
            else if (direccion == -1)
            {
                controlMoviendo.Width = controlMoviendo.Width + CurPos.X - esquina.X;
            }


            if (moviendo)
            {
                controlMoviendo.Left += e.X - offsetX;
                controlMoviendo.Top += e.Y - offsetY;
            }
        }
        private void control_MouseUp(object sender, MouseEventArgs e)
        {
            if (controlMoviendo == null) return;
            Point CurPos = e.Location;
            Point esquina = new Point(controlMoviendo.Width, controlMoviendo.Height);

            if (e.Button == MouseButtons.Left)
            {
                moviendo = false;
                controlMoviendo.BackColor = anterior;
                controlMoviendo.Update();// = null;

                //aqui verificar si esta sobre un tabControl
                foreach (TabControl tabControl in tabControls)
                {
                    if (controlMoviendo.Location.X > tabControl.Location.X && controlMoviendo.Location.X < tabControl.Location.X + tabControl.Location.X + tabControl.Width)
                    {
                        if (controlMoviendo.Location.Y > tabControl.Location.Y && controlMoviendo.Location.Y < tabControl.Location.Y + tabControl.Location.Y + tabControl.Height)
                        {
                            if (controlMoviendo.Parent.GetType() == typeof(Panel))
                            {
                                controlMoviendo.Parent = tabControl.SelectedTab;
                                controlMoviendo.Location = new Point(controlMoviendo.Location.X - tabControl.Location.X, controlMoviendo.Location.Y - tabControl.Location.Y);
                                tabControl.SelectedTab.Controls.Add(controlMoviendo);
                               
                            }
                            return;
                        }
                    }
                }
                if (controlMoviendo.Parent.GetType() == typeof(TabPage))
                {
                    Boolean salioDeTab = false;
                    if (controlMoviendo.Location.X < controlMoviendo.Parent.Location.X || controlMoviendo.Location.X > controlMoviendo.Parent.Location.X + controlMoviendo.Parent.Location.X + controlMoviendo.Parent.Width)
                    {
                        salioDeTab = true;
                    }
                    if (controlMoviendo.Location.Y < controlMoviendo.Parent.Location.Y || controlMoviendo.Location.Y > controlMoviendo.Parent.Location.Y + controlMoviendo.Parent.Location.Y + controlMoviendo.Parent.Height)
                    {
                        salioDeTab = true;
                    }
                    if (salioDeTab)
                    {
                        controlMoviendo.Location = new Point(controlMoviendo.Location.X + controlMoviendo.Parent.Parent.Location.X, controlMoviendo.Location.Y + controlMoviendo.Parent.Parent.Location.Y);
                        controlMoviendo.Parent = pnl_Controles;
                        pnl_Controles.Controls.Add(controlMoviendo);
                    }
                }
                

            }
            if (e.Button == MouseButtons.Right)
            {
                this.Cursor = Cursors.Default;
                direccion = 0;
                controlMoviendo = null;
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            pnl_Controles.Controls.Remove((Control)controlMoviendo);
        }

        private void btn_frente_Click(object sender, EventArgs e)
        {
            if (controlMoviendo == null) return;

            controlMoviendo.BringToFront();

        }

        private void btn_fondo_Click(object sender, EventArgs e)
        {
            if (controlMoviendo == null) return;

            controlMoviendo.SendToBack();
        }

    }
}
