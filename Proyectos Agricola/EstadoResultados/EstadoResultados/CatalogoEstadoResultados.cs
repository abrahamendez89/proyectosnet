using Herramientas.SQL;
using Herramientas.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EstadoResultados
{
    public partial class CatalogoEstadoResultados : Form
    {
        ImageList imgList = new ImageList();
        DBAcceso dbAcceso;
        List<ConceptoEstadoFinanciero> conceptos = new List<ConceptoEstadoFinanciero>();
        Boolean esModoDesarrollador;
        public CatalogoEstadoResultados(Boolean esModoDesarrollador)
        {
            InitializeComponent();
            ConfigurarIniciales();
            tv_conceptosEstadoResultados.Nodes.Add("principal", "Estado de resultados", "principal");
            dbAcceso = DBAcceso.ObtenerInstancia();
            CargarConceptosBD();
            this.FormClosing += CatalogoEstadoResultados_FormClosing;
            txt_query.TextChanged += txt_query_TextChanged;
            this.esModoDesarrollador = esModoDesarrollador;
            if (esModoDesarrollador)
            {
                lbl_query.Visible = true;
                txt_query.Visible = true;
            }
            //tv_conceptosEstadoResultados.AllowDrop = true;
            //tv_conceptosEstadoResultados.MouseDown += tree_MouseDown;
            //tv_conceptosEstadoResultados.DragOver += tree_DragOver;
            //tv_conceptosEstadoResultados.DragDrop += tree_DragDrop;

            tv_conceptosEstadoResultados.MouseDoubleClick += tv_conceptosEstadoResultados_MouseDoubleClick;
            CargarBeneficios();
        }

        private void CargarBeneficios()
        {
            cmb_beneficios.Items.Clear();
            String queryBeneficios = "select * from tb_beneficios";
            DataTable dt = dbAcceso.EjecutarConsulta(queryBeneficios);

            foreach (DataRow dr in dt.Rows)
            {
                cmb_beneficios.Items.Add(dr["id"] + " - " + dr["cNombreBeneficio"]);
            }
        }

        void tv_conceptosEstadoResultados_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ModificarConcepto();
        }

        void txt_query_TextChanged(object sender, EventArgs e)
        {
        }
















        #region eventos drag and drop
        private void tree_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            TreeView tree = (TreeView)sender;
            TreeNode node = tree.GetNodeAt(e.X, e.Y);
            tree.SelectedNode = node;

            if (node != null)
            {
                tree.DoDragDrop(node, DragDropEffects.Move);
            }
        }
        private void tree_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            TreeView tree = (TreeView)sender;

            e.Effect = DragDropEffects.Move;

            TreeNode nodeSource = (TreeNode)e.Data.GetData(typeof(TreeNode));
            if (nodeSource != null)
            {
                if (nodeSource.TreeView != tree)
                {
                    Point pt = new Point(e.X, e.Y);
                    pt = tree.PointToClient(pt);
                    TreeNode nodeTarget = tree.GetNodeAt(pt);
                    if (nodeTarget != null)
                    {
                        e.Effect = DragDropEffects.Move;
                        tree.SelectedNode = nodeTarget;
                    }
                }
            }
        }
        private void tree_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {

            if (Mensajes.PreguntaAdvertenciaSIoNO("¿Está seguro de continuar con el movimiento de conceptos?"))
            {

                TreeView tree = (TreeView)sender;
                Point pt = new Point(e.X, e.Y);
                pt = tree.PointToClient(pt);

                TreeNode nodeTarget = tree.GetNodeAt(pt);
                TreeNode nodeSource = (TreeNode)e.Data.GetData(typeof(TreeNode));

                if (nodeTarget == nodeSource || nodeSource.Text.Equals("Estado de resultados")) return;

                nodeSource.Parent.Nodes.Remove(nodeSource);
                TreeNode Clonado = (TreeNode)nodeSource.Clone();

                nodeTarget.Nodes.Add(Clonado);
                nodeTarget.Expand();
            }

        }
        #endregion















        DataTable dt;
        List<int> idsRecorridos = new List<int>();
        private void CargarConceptosBD()
        {
            dt = dbAcceso.EjecutarConsulta("select est.id, est.nombre_concepto, det.esIndirecto, det.query_origen, est.orden from CuentasEstadoResultados est inner join CuentasEstadoResultadosDetalle det on est.id = det.id_cuentaEstadoRes order by est.orden");

            DataTable dtPadres = dbAcceso.EjecutarConsulta("select est.id, est.nombre_concepto, det.esIndirecto, det.query_origen, est.orden from CuentasEstadoResultados est inner join CuentasEstadoResultadosDetalle det on est.id = det.id_cuentaEstadoRes where det.id_cuentaPadre = 0 order by est.orden");
            
            TreeNode tnPrincipal = tv_conceptosEstadoResultados.Nodes[0];

            foreach (DataRow dr in dtPadres.Rows)
            {
                if (idsRecorridos.Contains(Convert.ToInt32(dr["id"])))
                {
                    continue;
                }
                TreeNode nodo = new TreeNode();
                nodo.ImageKey = "hoja";
                nodo.SelectedImageKey = "hoja";
               
                ConceptoEstadoFinanciero cPadre = new ConceptoEstadoFinanciero();
                cPadre.ID = Convert.ToInt32(dr["id"]);
                cPadre.NombreConcepto = dr["nombre_concepto"].ToString();
                cPadre.EsIndirecto = Convert.ToBoolean(dr["esIndirecto"]);
                cPadre.Query = dr["query_origen"].ToString();
                if (cPadre.ID > consecutivo)
                    consecutivo = cPadre.ID;
                nodo.Tag = cPadre;
                nodo.Text = "["+cPadre.ID+"] - "+cPadre.NombreConcepto;
                cPadre.NodoAsociado = nodo;
                nodo.ToolTipText = cPadre.ID.ToString();
                tnPrincipal.Nodes.Add(nodo);

                CargarConceptosRecursivo(cPadre, nodo);
                conceptos.Add(cPadre);
            }
            tnPrincipal.Expand();
            SetIconos();
        }

        private void CargarConceptosRecursivo(ConceptoEstadoFinanciero cPadre, TreeNode nodo)
        {
            if (idsRecorridos.Contains(cPadre.ID))
            {
                return;
            }
            idsRecorridos.Add(cPadre.ID);
            DataTable dtDet = dbAcceso.EjecutarConsulta("select id_cuentaEstadoRes, enc.orden from CuentasEstadoResultadosDetalle det inner join CuentasEstadoResultados enc on det.id_cuentaEstadoRes = enc.id where id_cuentaPadre = @id order by enc.orden", new List<object> { cPadre.ID });

            foreach (DataRow drDet in dtDet.Rows)
            {
                int idHijo = Convert.ToInt32(drDet["id_cuentaEstadoRes"]);

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    DataRow dr = dt.Rows[j];
                    if (Convert.ToInt32(dr["id"]) == idHijo)
                    {
                        TreeNode nodoHijo = new TreeNode();

                        nodoHijo.ImageKey = "hoja";
                        nodoHijo.SelectedImageKey = "hoja";
                        ConceptoEstadoFinanciero cHijo = new ConceptoEstadoFinanciero();
                        cHijo.ID = Convert.ToInt32(dr["id"]);
                        cHijo.NombreConcepto = dr["nombre_concepto"].ToString();
                        cHijo.EsIndirecto = Convert.ToBoolean(dr["esIndirecto"]);
                        cHijo.Query = dr["query_origen"].ToString();
                        if (cPadre.ConceptosHijos == null) cPadre.ConceptosHijos = new List<ConceptoEstadoFinanciero>();
                        cPadre.ConceptosHijos.Add(cHijo);
                        if (cHijo.ID > consecutivo)
                            consecutivo = cHijo.ID;
                        //idsRecorridos.Add(cHijo.ID);
                        cHijo.NodoAsociado = nodoHijo;
                        nodoHijo.Tag = cHijo;
                        nodoHijo.Text = cHijo.NombreConcepto;
                        nodoHijo.Text = "[" + cHijo.ID + "] - " + cHijo.NombreConcepto;
                        nodo.Nodes.Add(nodoHijo);

                        CargarConceptosRecursivo(cHijo, nodoHijo);
                        break;
                    }
                }
            }

        }
        static int consecutivo = 1;
        private void Recorrer(TreeNode nodo, int idPadre, int indiceNodo)
        {
            int idNodoActual = 0;
            ConceptoEstadoFinanciero concepto = (ConceptoEstadoFinanciero)nodo.Tag;
            if (concepto != null)
            {
                String query = "insert into CuentasEstadoResultados(id, nombre_concepto, orden, idBeneficio) values (@id, @nombre_concepto, @orden, @idBeneficio)";
                String queryDet = "insert into CuentasEstadoResultadosDetalle(id_cuentaEstadoRes, id_cuentaPadre, query_origen, esIndirecto) values (@id_cuentaEstadoRes, @id_cuentaPadre,@query_origen, @esIndirecto)";
                idNodoActual = concepto.ID;
                dbAcceso.EjecutarConsulta(query, new List<object> { idNodoActual, concepto.NombreConcepto, indiceNodo , concepto.IDBeneficio });
                dbAcceso.EjecutarConsulta(queryDet, new List<object> { idNodoActual, idPadre, concepto.Query, concepto.EsIndirecto });
            }
            else
            {
                if (idPadre != 0)
                {
                    dbAcceso.DeshacerTransaccion();
                    Mensajes.Error("El nodo se encuentra sin datos la transacción se cerro.");
                    return;
                }
            }
            int indiceNodoTemp = 1;
            foreach (TreeNode hijo in nodo.Nodes)
            {
                Recorrer(hijo, idNodoActual, indiceNodoTemp++);
            }
        }
        Boolean estaGuardando;
        private void GuardarConceptos()
        {

            dbAcceso.IniciarTransaccion();
            dbAcceso.EjecutarConsulta("delete CuentasEstadoResultados");
            dbAcceso.EjecutarConsulta("delete CuentasEstadoResultadosDetalle");
            //TreeNode padre = tv_conceptosEstadoResultados.TopNode;
            TreeNode padre = null;
            foreach(TreeNode nodo in tv_conceptosEstadoResultados.Nodes)
                if (nodo.Text.Equals("Estado de resultados"))
                {
                    padre = nodo;
                }
            if (padre == null)
            {
                dbAcceso.DeshacerTransaccion();
                return;
            }
            Recorrer(padre, 0, 0);
            dbAcceso.TerminarTransaccion();
        }
        void CatalogoEstadoResultados_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (agregando)
            {
                e.Cancel = true;
                Mensajes.Exclamacion("Termine el guardado del concepto que está editando.");
                return;
            }

        }
        private void ActualizarEstadoResultadosEnBD()
        {
            GuardarConceptos();
            //ConstruirCatalogoColumnas();
        }
        private void SetIconos()
        {
            TreeNode tnPrincipal = tv_conceptosEstadoResultados.Nodes[0];
            tnPrincipal.ImageKey = "principal";
            tnPrincipal.SelectedImageKey = "principal";
            foreach (TreeNode hijos in tnPrincipal.Nodes)
                RecorrerIcono(hijos);
        }
        private void RecorrerIcono(TreeNode nodo)
        {
            if (nodo.Nodes.Count == 0)
            {
                nodo.ImageKey = "hoja";
                nodo.SelectedImageKey = "hoja";
            }
            else
            {
                nodo.ImageKey = "rama";
                nodo.SelectedImageKey = "rama";
            }
            foreach (TreeNode nod in nodo.Nodes)
            {
                RecorrerIcono(nod);
            }
        }

        private void ConfigurarIniciales()
        {

            imgList.ImageSize = new Size(20, 20);
            imgList.Images.Add("principal", new Bitmap("principal.png"));
            imgList.Images.Add("hoja", new Bitmap("hoja.png"));
            imgList.Images.Add("rama", new Bitmap("rama.png"));

            tv_conceptosEstadoResultados.ImageList = imgList;
            tv_conceptosEstadoResultados.DoubleClick += tv_conceptosEstadoResultados_DoubleClick;
            chb_directo.Checked = true;

            ContextMenu cm = new ContextMenu();
            cm.MenuItems.Add(new MenuItem("Agregar concepto hijo", new EventHandler(Evento)));
            cm.MenuItems.Add(new MenuItem("Eliminar concepto seleccionado", new EventHandler(Evento)));
            cm.MenuItems.Add(new MenuItem("Modificar concepto seleccionado", new EventHandler(Evento)));
            tv_conceptosEstadoResultados.ContextMenu = cm;
        }
        TreeNode nodoSeleccionado;
        void tv_conceptosEstadoResultados_DoubleClick(object sender, EventArgs e)
        {
            nodoSeleccionado = tv_conceptosEstadoResultados.SelectedNode;
        }
        Boolean agregando;
        TreeNode nodeEditando;
        private void Evento(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;
            nodoSeleccionado = tv_conceptosEstadoResultados.SelectedNode;
            if (nodoSeleccionado == null) return;
            if (agregando) { Mensajes.Exclamacion("Actualmente se encuentra editando un concepto. Termine la edición para continuar configurando."); return; }

            if (mi.Text.Equals("Agregar concepto hijo"))
            {
                AgregarConcepto();
            }
            else if (mi.Text.Equals("Eliminar concepto seleccionado"))
            {
                EliminarConcepto();

            }
            else if (mi.Text.Equals("Modificar concepto seleccionado"))
            {
                ModificarConcepto();
            }
        }
        private void EliminarConcepto()
        {
            nodoSeleccionado = tv_conceptosEstadoResultados.SelectedNode;

            if (nodoSeleccionado == null)
            {
                Mensajes.Exclamacion("Selecciona un nodo antes.");
                return;
            }
            ConceptoEstadoFinanciero concepto = (ConceptoEstadoFinanciero)nodoSeleccionado.Tag;
            if (concepto == null)
            {
                if (nodoSeleccionado.Text.Equals("<Editando>"))
                    concepto.NodoAsociado.Parent.Nodes.Remove(nodoSeleccionado);
                return;
            }
            if (Mensajes.PreguntaAdvertenciaSIoNO("¿Desea eliminar el nodo seleccionado '" + concepto.NombreConcepto + "'?"))
            {

                if (nodoSeleccionado.Nodes.Count > 0 && Mensajes.PreguntaAdvertenciaSIoNO("¿Desea conservar los conceptos hijos y agregarlos al concepto padre '" + concepto.NodoAsociado.Parent.Text + "'?"))
                {
                    foreach (TreeNode nodoH in concepto.NodoAsociado.Nodes)
                    {
                        concepto.NodoAsociado.Parent.Nodes.Add((TreeNode)nodoH.Clone());
                    }
                }
                concepto.NodoAsociado.Parent.Nodes.Remove(concepto.NodoAsociado);
            }
            SetIconos();
        }
        private void AgregarConcepto()
        {
            nodoSeleccionado = tv_conceptosEstadoResultados.SelectedNode;

            if (nodoSeleccionado == null)
            {
                Mensajes.Exclamacion("Selecciona un nodo antes.");
                return;
            }

            nodeEditando = new TreeNode("<Editando>");
            nodeEditando.Tag = null;
            nodoSeleccionado.Nodes.Add(nodeEditando);
            nodeEditando.ImageKey = "hijos";
            nodeEditando.SelectedImageKey = "hijos";
            nodoSeleccionado.Expand();
            agregando = true;
            tv_conceptosEstadoResultados.SelectedNode = nodeEditando;
            txt_nombreConcepto.Focus();
            SetIconos();
        }
        private void ModificarConcepto()
        {
            nodoSeleccionado = tv_conceptosEstadoResultados.SelectedNode;

            if (nodoSeleccionado == null)
            {
                Mensajes.Exclamacion("Selecciona un nodo antes.");
                return;
            }

            ConceptoEstadoFinanciero concepto = (ConceptoEstadoFinanciero)nodoSeleccionado.Tag;
            if (concepto == null) return;
            nodeEditando = nodoSeleccionado;

            agregando = true;


            for(int i = 0; i < cmb_beneficios.Items.Count; i++)
            {
                if (cmb_beneficios.Items[i].ToString().Split('-')[0].Trim().Equals(concepto.IDBeneficio.ToString()))
                {
                    cmb_beneficios.SelectedIndex = i;
                    break;
                }
            }


            txt_nombreConcepto.Text = concepto.NombreConcepto;
            if (concepto.EsIndirecto)
                chb_indirecto.Checked = true;

            if (esModoDesarrollador)
            {
                txt_query.Text = concepto.Query;
                Formatear();
            }
            txt_nombreConcepto.Focus();
            SetIconos();
        }

        private void chb_directo_CheckedChanged(object sender, EventArgs e)
        {
            chb_indirecto.Checked = !chb_directo.Checked;
        }

        private void chb_indirecto_CheckedChanged(object sender, EventArgs e)
        {
            chb_directo.Checked = !chb_indirecto.Checked;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (nodeEditando == null)
            {
                Mensajes.Informacion("Primero debe agregar un concepto a uno ya existente en el arbol.");
                return;
            }
            ConceptoEstadoFinanciero conceptoEditando = null;
            if (nodeEditando.Tag != null)
            {

                conceptoEditando = (ConceptoEstadoFinanciero)nodeEditando.Tag;
            }
            else
            {
                consecutivo++;
                conceptoEditando = new ConceptoEstadoFinanciero();
                conceptoEditando.ID = consecutivo;
                conceptoEditando.NodoAsociado = nodeEditando;
                

            }
            int id = 0;
            if(cmb_beneficios.SelectedItem != null)
                id = Convert.ToInt32(cmb_beneficios.SelectedItem.ToString().Trim().Split('-')[0]);

            conceptoEditando.NombreConcepto = txt_nombreConcepto.Text;
            conceptoEditando.Query = txt_query.Text;
            conceptoEditando.IDBeneficio = id;

            if (chb_directo.Checked)
                conceptoEditando.EsIndirecto = false;
            else
                conceptoEditando.EsIndirecto = true;

            agregando = false;
            nodeEditando.Text = txt_nombreConcepto.Text;
            nodeEditando.Tag = conceptoEditando;

            txt_nombreConcepto.Text = "";
            chb_directo.Checked = true;
            chb_indirecto.Checked = false;
            txt_query.Text = "";
            cmb_beneficios.SelectedIndex = -1;
            

            conceptoEditando = null;

            btn_actualizarBD_Click(null,null);

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            txt_nombreConcepto.Text = "";
            chb_directo.Checked = true;
            chb_indirecto.Checked = false;
            cmb_beneficios.SelectedItem = null;
            txt_query.Text = "";
            agregando = false;
            nodoSeleccionado = null;
            nodeEditando = null;
        }


        private void ConstruirCatalogoColumnas()
        {
            niveles = 0;
            inserciones.Clear();
            RecorrerNodos(tv_conceptosEstadoResultados.TopNode, 0, "");
            //Mensajes.Informacion("nivel maximo: " + niveles, "niveles");
            String queryEliminacion = "if exists (Select * from sysobjects where type='U' and name='Tb_Bi_Ctl_Cuentas_Estado_Resultados') drop table Tb_Bi_Ctl_Cuentas_Estado_Resultados";
            dbAcceso.EjecutarConsulta(queryEliminacion);
            String queryCreacion = "Create Table Tb_Bi_Ctl_Cuentas_Estado_Resultados( ";
            String columnas = "";
            String alias = "";
            for (int i = 0; i < niveles; i++)
            {
                queryCreacion += "Nivel" + (i + 1) + " int, ";
                columnas += "Nivel" + (i + 1) + ", ";
                alias += "@Nivel" + (i + 1) + ", ";
            }
            alias = alias.Substring(0, alias.Length - 2);
            columnas = columnas.Substring(0, columnas.Length - 2);

            queryCreacion = queryCreacion.Substring(0, queryCreacion.Length - 2);
            queryCreacion += ")";
            dbAcceso.EjecutarConsulta(queryCreacion);
            List<Object> valoresObject = new List<object>();
            foreach (String insert in inserciones)
            {
                valoresObject.Clear();
                String ins = "insert into Tb_Bi_Ctl_Cuentas_Estado_Resultados(" + columnas + ") values (" + alias + ")";

                String[] valores = insert.Split('|');

                int valoresNoNull = valores.Length;

                for (int i = 0; i < valoresNoNull - 1; i++)
                {
                    valoresObject.Add(Convert.ToInt32(valores[i]));
                }

                for (int j = 0; j < (niveles - (valoresNoNull - 1)); j++)
                    valoresObject.Add(null);

                dbAcceso.EjecutarConsulta(ins, valoresObject);
            }


        }
        static int niveles;
        List<String> inserciones = new List<string>();
        private void RecorrerNodos(TreeNode nodo, int nivelActual, String insercion)
        {
            ConceptoEstadoFinanciero concepto = (ConceptoEstadoFinanciero)nodo.Tag;
            if (concepto != null)
            {
                insercion += concepto.ID + "|";
                if (nivelActual > niveles)
                    niveles = nivelActual;
            }
            ++nivelActual;
            foreach (TreeNode hijo in nodo.Nodes)
            {
                RecorrerNodos(hijo, nivelActual, insercion);
            }
            if (nodo.Nodes.Count == 0)
                inserciones.Add(insercion);
        }

        private void btn_actualizarBD_Click(object sender, EventArgs e)
        {
            ActualizarEstadoResultadosEnBD();
            Mensajes.Informacion("Actualización correcta");
        }

        private void Formatear()
        {
            //String t = txt_query.SelectedRtf;
            //String t2 = txt_query.Text;
            //String texto = QuitarEnters(t2);

            ResetFormat(txt_query);

            //palabras reservadas
            Color Reservadas = Color.Blue;
            ResaltarTexto(txt_query, "CREATE", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "TABLE", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "DROP", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "IF", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "DATABASE", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "GO", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "NOT", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "PRIMARY", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "FOREIGN", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "KEY", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "NONCLUSTERED", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "CLUSTERED", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "REFERENCES", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "TOP", Reservadas, false, false, true);

            ResaltarTexto(txt_query, "USE", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "SELECT", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "INNER", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "JOIN", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "WHERE", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "ANY", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "FROM", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "ELSE", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "AS", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "AND", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "ALTER", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "ASC", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "BEGIN", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "BETWEEN", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "BY", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "CASE", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "CONSTRAINT", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "CONTINUE", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "DESC", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "DISTINCT", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "END", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "UNION", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "OR", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "IN", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "ADD", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "ALL", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "EXISTS", Reservadas, false, false, true);

            ResaltarTexto(txt_query, "MAX", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "NULL", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "IDENTITY", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "WITH", Reservadas, false, false, true);
            ResaltarTexto(txt_query, "NOCHECK", Reservadas, false, false, true);

            //Tipos de datos
            Color tipos = Color.LightSalmon;
            ResaltarTexto(txt_query, "VARCHAR", tipos, false, false, true);
            ResaltarTexto(txt_query, "INT", tipos, false, false, true);
            ResaltarTexto(txt_query, "BIGINT", tipos, false, false, true);
            ResaltarTexto(txt_query, "DATETIME", tipos, false, false, true);
            ResaltarTexto(txt_query, "BIT", tipos, false, false, true);
            ResaltarTexto(txt_query, "DOUBLE", tipos, false, false, true);
            ResaltarTexto(txt_query, "VARBINARY", tipos, false, false, true);
            ResaltarTexto(txt_query, "NUMERIC", tipos, false, false, true);

            Color variablesSQL = Color.Green;
            ResaltarTexto(txt_query, "information_schema", variablesSQL, false, false, false);
            ResaltarTexto(txt_query, "referential_constraints", variablesSQL, false, false, false);
            ResaltarTexto(txt_query, "sysobjects", variablesSQL, false, false, false);
            ResaltarTexto(txt_query, "type", variablesSQL, false, false, false);
            ResaltarTexto(txt_query, "CONSTRAINT_name", variablesSQL, false, false, false);

            //operadores
            //Color operadores = Color.Green;
            //ResaltarTexto(txt_query, ">", operadores, true, true);
            //ResaltarTexto(txt_query, "<", operadores, true, true);
            //ResaltarTexto(txt_query, ">=", operadores, true, true);
            //ResaltarTexto(txt_query, "<=", operadores, true, true);
            //ResaltarTexto(txt_query, "+", operadores, true, true);
            //ResaltarTexto(txt_query, "-", operadores, true, true);
            //ResaltarTexto(txt_query, "*", operadores, true, true);
            //ResaltarTexto(txt_query, "/", operadores, true, true);
            //ResaltarTexto(txt_query, "=", operadores, true, true);
            //simbolos
            Color simbolos = Color.Red;
            ResaltarTexto(txt_query, "'", simbolos, false, true, false);
            ResaltarTexto(txt_query, ".", simbolos, false, true, false);
            ResaltarTexto(txt_query, "*", simbolos, false, true, false);
            ResaltarTexto(txt_query, "(", simbolos, false, true, false);
            ResaltarTexto(txt_query, ")", simbolos, false, true, false);
            ResaltarTexto(txt_query, ";", simbolos, false, true, false);
            ResaltarTexto(txt_query, ",", simbolos, false, true, false);
            ResaltarTexto(txt_query, "#", simbolos, false, true, false);
            ResaltarTexto(txt_query, "%", simbolos, false, true, false);
            ResaltarTexto(txt_query, "@", simbolos, false, true, false);

            //Quitando mayusculas
            //System.Drawing.Font currentFont = txt_query.SelectionFont;
            //txt_query.SelectionFont = new Font(
            //       currentFont.FontFamily,
            //       currentFont.Size,
            //       FontStyle.Regular
            //    );
            //ResetFormat(txt_query);
        }
        private void ResetFormat(RichTextBox rich)
        {
            rich.SelectionStart = 0;
            rich.SelectionLength = rich.Text.Length;
            rich.SelectionColor = Color.Black;
            //rich.SelectedText = rich.SelectedText.ToLower();
            System.Drawing.Font currentFont = rich.SelectionFont;
            rich.SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   FontStyle.Regular
                );
        }
        private void ResaltarTexto(RichTextBox rich, String cadena, Color ColorText, Boolean bold, Boolean parcial, Boolean toUpper)
        {
            int pos_caracter;
            int long_cadena;
            int pos_seleccion_inicio;
            int pos_seleccion_long;
            int coincidencias = 0;
            var tipoBusqueda = RichTextBoxFinds.WholeWord;

            //restablecienco color
            int st = rich.SelectionStart;
            rich.SelectionStart = rich.Text.Length;
            rich.SelectionLength = 0;
            rich.SelectionColor = Color.Black;
            rich.SelectionStart = st;


            if (parcial)
            {
                tipoBusqueda = RichTextBoxFinds.None;
            }

            pos_seleccion_inicio = rich.SelectionStart;
            pos_seleccion_long = rich.SelectionLength;
            long_cadena = cadena.Length;

            pos_caracter = rich.Find(cadena, 0, tipoBusqueda);

            while (pos_caracter >= 0)
            {
                coincidencias++;

                if (bold)
                {
                    ToggleBold(rich);
                }
                rich.SelectionStart = pos_caracter;
                rich.SelectionLength = long_cadena;
                rich.SelectionColor = ColorText;
                if (toUpper)
                    rich.SelectedText = rich.SelectedText.ToUpper();
                else
                    rich.SelectedText = rich.SelectedText.ToLower();


                int siguiente = (pos_caracter + long_cadena);
                if (siguiente >= rich.Text.Length)
                {
                    break;
                }

                int posicionNuevaBusqueda = rich.Find(cadena, siguiente, tipoBusqueda);

                pos_caracter = posicionNuevaBusqueda;
            }

            rich.SelectionStart = pos_seleccion_inicio;
            rich.SelectionLength = pos_seleccion_long;
            rich.SelectionColor = Color.Black;
            if (bold)
            {
                ToggleBold(rich);
            }
        }
        private void ToggleBold(RichTextBox rich)
        {
            if (rich.SelectionFont != null)
            {
                System.Drawing.Font currentFont = rich.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (rich.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }

                rich.SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   newFontStyle
                );
            }
        }

        private void btn_formato_Click(object sender, EventArgs e)
        {
            Formatear();
        }


        private void tv_conceptosEstadoResultados_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ModificarConcepto();
        }

        private void tv_conceptosEstadoResultados_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            nodoSeleccionado = tv_conceptosEstadoResultados.SelectedNode;
        }

        private void btn_modificarConcepto_Click(object sender, EventArgs e)
        {
            if (agregando)
                Mensajes.Informacion("Se encuentra editando un concepto, termine para continuar.");
            else
                ModificarConcepto();
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if (agregando)
                Mensajes.Informacion("Se encuentra editando un concepto, termine para continuar.");
            else
                AgregarConcepto();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (agregando)
                Mensajes.Informacion("Se encuentra editando un concepto, termine para continuar.");
            else
                EliminarConcepto();

        }
        TreeNode cortado = null;        
        private void btn_cortar_Click(object sender, EventArgs e)
        {
            if (cortado == null)
            {
                btn_cortar.Text = "Pegar...";
                cortado = tv_conceptosEstadoResultados.SelectedNode;
                TreeNode padre = cortado.Parent;
                cortado.Parent.Nodes.Remove(cortado);
                //Mensajes.Informacion("Nodo cortado...", "Nodo");
            }
            else
            {
                btn_cortar.Text = "Cortar";
                tv_conceptosEstadoResultados.SelectedNode.Nodes.Add(cortado);
                cortado = null;
                //Mensajes.Informacion("Nodo pegado.", "Nodo");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void tv_conceptosEstadoResultados_Click(object sender, EventArgs e)
        {

        }

        private void tv_conceptosEstadoResultados_DoubleClick_1(object sender, EventArgs e)
        {
            
            ModificarConcepto();
        }


    }
}
