using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Herramientas.ORM.Controles
{
    public partial class BuscadorCatalogo : Form
    {
        Type tipoObjetoABuscar;
        Boolean seAcepto = false;
        public ManejadorDB Manejador { get; set; }
        public String CriterioBusquedaInicial { get; set; }
        public BuscadorCatalogo(Type tipo)
        {
            InitializeComponent();
            Inicializar(tipo, false);
        }
        public BuscadorCatalogo(Type tipo, Boolean permiteMultipleSeleccion)
        {
            InitializeComponent();
            Inicializar(tipo, permiteMultipleSeleccion);
        }

        private void Inicializar(Type tipo, Boolean permiteMultipleSeleccion)
        {
            this.tipoObjetoABuscar = tipo;
            txt_busqueda.Text = CriterioBusquedaInicial;
            ObtenerDataTableDeObjeto();
            if (permiteMultipleSeleccion)
                chb_MasDeUno.Visible = true;
            else
                chb_MasDeUno.Visible = false;
        }

        DataTable Estructura;
        public List<ObjetoBase> ObtenerSeleccionados(Type tipo)
        {
            List<ObjetoBase> objetosSeleccionados = null;
            if (seAcepto)
            {
                objetosSeleccionados = new List<ObjetoBase>();
                for(int i = 0; i < dgr_InformacionObjetos.SelectedRows.Count; i++)
                {
                    long id = Convert.ToInt32(Herramientas.Forms.DataGridViewConf.ObtenerValorCelda(dgr_InformacionObjetos, i, "ID"));
                    ObjetoBase objeto = Manejador.Cargar(tipo, "select * from " + tipoObjetoABuscar.Name + " where id = @id", new List<object>() { id })[0];
                    objetosSeleccionados.Add(objeto);

                }
            }
            return objetosSeleccionados;
        }
        private DataTable ObtenerDataTableDeObjeto()
        {
            Estructura = new DataTable();
            FieldInfo[] atributos = tipoObjetoABuscar.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            foreach (FieldInfo atributo in atributos)
            {
                if (atributo.Name.StartsWith("_"))
                {
                    Estructura.Columns.Add(atributo.Name);
                    //cmb_atributos.Items.Add(atributo.Name);
                }
            }

            //cmb_atributos.Items.Add("Todos");


            return Estructura;
        }

        private void Buscar()
        {
            String campos = "";
            String query = "select id,* from " + tipoObjetoABuscar.Name + " where ";
            if ((Boolean)chb_mostrarDeshabilitados.Checked)
            {
                campos += "estaDeshabilitado, ";
            }
            foreach (DataColumn columna in Estructura.Columns)
            {
                campos += columna.ColumnName + ", ";
            }

            campos = campos.Substring(0, campos.Length - 2);
            query = query.Replace("*", campos);
            if (true) //buscar por todos los campos
            {
                foreach (DataColumn columna in Estructura.Columns)
                {
                    if (columna.ColumnName.StartsWith("_st_"))
                        query += columna + " like '%" + txt_busqueda.Text.Trim() + "%' or";
                    if (columna.ColumnName.StartsWith("_in_") || columna.ColumnName.StartsWith("_lo_"))
                        query += columna + " = " + txt_busqueda.Text.Trim() + " or";
                    if (columna.ColumnName.StartsWith("_dt_"))
                        query += columna + " = '" + txt_busqueda.Text.Trim() + "' or";
                }
                query = query.Substring(0, query.Length - 2);
            }
            //else
            //{
            //    query += cmb_atributos.SelectedItem.ToString() + " like '%" + txt_busqueda.Text.Trim() + "%'";
            //}

            if ((Boolean)chb_mostrarDeshabilitados.Checked)
            {
                query += " and (estaDeshabilitado = 0 or EstaDeshabilitado is null or estaDeshabilitado = '1')";
            }
            else
            {
                query += " and (estaDeshabilitado = 0 or EstaDeshabilitado is null)";
            }

            DataTable resultado = Manejador.EjecutarConsulta(query);

            foreach (DataColumn columnaPro in resultado.Columns)
            {
                columnaPro.ReadOnly = true;
            }
            dgr_InformacionObjetos.DataSource = resultado.DefaultView;
        }
        private void txt_busqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                Buscar();
            }

        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void BuscadorCatalogo_FormClosing(object sender, FormClosingEventArgs e)
        {
            seAcepto = false;
            e.Cancel = true;
            Hide();
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            seAcepto = true;
            Hide();
        }

        private void chb_MasDeUno_CheckedChanged(object sender, EventArgs e)
        {
            dgr_InformacionObjetos.MultiSelect = chb_MasDeUno.Checked;
        }

    }
}
