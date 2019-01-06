using Herramientas.Archivos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace ContabilidadElectronica.Formularios
{
    public partial class VisorXML345 : Form
    {
        public VisorXML345()
        {
            InitializeComponent();

        }
        XML xml;
        private void btn_cargarXML_Click(object sender, EventArgs e)
        {
            if (cmb_tipoXML.SelectedItem == null)
            {
                Herramientas.Forms.Mensajes.Exclamacion("Por favor seleccione un tipo de XML.");
                return;
            }
            String ruta = Herramientas.Archivos.Dialogos.BuscarArchivo(new List<string>() { "Archivo XML" }, new List<String>() { "xml" });
            if (ruta != null && !ruta.Equals(""))
            {
                xml = new XML(ruta);
                String nombreArchivo = Herramientas.Archivos.Archivo.ObtenerNombreArchivo(ruta);
                ll_nombreArchivo.Text = nombreArchivo;
                tv_estructura.Nodes.Clear();
                if (cmb_tipoXML.SelectedIndex == 0)
                {
                    Thread tPolizasPeriodo = new Thread(CargarNodoPolizasPeriodo);
                    tPolizasPeriodo.IsBackground = true;
                    tPolizasPeriodo.Start(xml.ContenidoTexto);
                }
                if (cmb_tipoXML.SelectedIndex == 1)
                {
                    Thread tPolizasPeriodo = new Thread(CargarNodoAuxiliarFolios);
                    tPolizasPeriodo.IsBackground = true;
                    tPolizasPeriodo.Start(xml.ContenidoTexto);
                }
                if (cmb_tipoXML.SelectedIndex == 2)
                {
                    Thread tPolizasPeriodo = new Thread(CargarNodoAuxiliarCuentas);
                    tPolizasPeriodo.IsBackground = true;
                    tPolizasPeriodo.Start(xml.ContenidoTexto);
                }
            }
        }
        private void CargarNodoPolizasPeriodo(object oxml)
        {
            //extrayendo el xml
            try
            {
                String xml = oxml.ToString();

                string temp = Path.GetTempPath() + Herramientas.Conversiones.Formatos.DateTimeAFechaLOGArchivo(DateTime.Now) + ".xml";

                Herramientas.Archivos.Archivo.GuardarArchivoDeTexto(temp, xml);

                //Create an xml reader;
                XmlDocument _xmlDocument = new XmlDocument();
                _xmlDocument.Load(temp);
                XmlNamespaceManager xmlnsManager = new XmlNamespaceManager(_xmlDocument.NameTable);
                xmlnsManager.AddNamespace("PLZ", "http://www.sat.gob.mx/esquemas/ContabilidadE/1_1/PolizasPeriodo");

                //Select the element with in the xml you wish to extract;
                //XmlNodeList _nodeList = _xmlDocument.SelectNodes("//PLZ:Polizas/PLZ:Poliza[@NumUnIdenPol='PG2015100012']/PLZ:Transaccion", xmlnsManager);

                XmlNode xPolizas = _xmlDocument.SelectSingleNode("//PLZ:Polizas", xmlnsManager);

                TreeNode tnPolizas = new TreeNode();
                tnPolizas.Text += xPolizas.Attributes["RFC"].Name.ToString() + " = " + xPolizas.Attributes["RFC"].Value.ToString() + " | ";
                tnPolizas.Text += xPolizas.Attributes["Anio"].Name.ToString() + " = " + xPolizas.Attributes["Anio"].Value.ToString() + " | ";
                tnPolizas.Text += xPolizas.Attributes["Mes"].Name.ToString() + " = " + xPolizas.Attributes["Mes"].Value.ToString() + " | ";
                tnPolizas.Text += xPolizas.Attributes["TipoSolicitud"].Name.ToString() + " = " + xPolizas.Attributes["TipoSolicitud"].Value.ToString() + " | ";
                if (xPolizas.Attributes["TipoSolicitud"].Value.ToString().Equals("AF") || xPolizas.Attributes["TipoSolicitud"].Value.ToString().Equals("FC"))
                    tnPolizas.Text += xPolizas.Attributes["NumOrden"].Name.ToString() + " = " + xPolizas.Attributes["NumOrden"].Value.ToString();
                if (xPolizas.Attributes["TipoSolicitud"].Value.ToString().Equals("DE") || xPolizas.Attributes["TipoSolicitud"].Value.ToString().Equals("CO"))
                    tnPolizas.Text += xPolizas.Attributes["NumTramite"].Name.ToString() + " = " + xPolizas.Attributes["NumTramite"].Value.ToString();

                tv_estructura.Invoke((MethodInvoker)delegate
                {
                    tv_estructura.Nodes.Add(tnPolizas);
                });


                XmlNodeList _nodeList = _xmlDocument.SelectNodes("PLZ:Polizas/PLZ:Poliza", xmlnsManager);
                //recorriendo cada poliza
                foreach (XmlNode xPoliza in _nodeList)
                {
                    double totalDebe = 0;
                    double totalHaber = 0;

                    TreeNode tnPoliza = new TreeNode();
                    tnPoliza.Text += xPoliza.Attributes["NumUnIdenPol"].Name.ToString() + " = " + xPoliza.Attributes["NumUnIdenPol"].Value.ToString() + " | ";
                    tnPoliza.Text += xPoliza.Attributes["Fecha"].Name.ToString() + " = " + xPoliza.Attributes["Fecha"].Value.ToString() + " | ";
                    tnPoliza.Text += xPoliza.Attributes["Concepto"].Name.ToString() + " = " + xPoliza.Attributes["Concepto"].Value.ToString();

                    tv_estructura.Invoke((MethodInvoker)delegate
                    {
                        tnPolizas.Nodes.Add(tnPoliza);
                    });

                    XmlNodeList xTransaccionLista = xPoliza.SelectNodes("PLZ:Transaccion", xmlnsManager);
                    foreach (XmlNode xTransaccion in xTransaccionLista)
                    {
                        TreeNode tnTransaccion = new TreeNode();
                        tnTransaccion.Text += xTransaccion.Attributes["NumCta"].Name.ToString() + " = " + xTransaccion.Attributes["NumCta"].Value.ToString() + " | ";
                        tnTransaccion.Text += xTransaccion.Attributes["Debe"].Name.ToString() + " = " + xTransaccion.Attributes["Debe"].Value.ToString() + " | ";
                        tnTransaccion.Text += xTransaccion.Attributes["Haber"].Name.ToString() + " = " + xTransaccion.Attributes["Haber"].Value.ToString() + " | ";
                        tnTransaccion.Text += xTransaccion.Attributes["DesCta"].Name.ToString() + " = " + xTransaccion.Attributes["DesCta"].Value.ToString() + " | ";
                        tnTransaccion.Text += xTransaccion.Attributes["Concepto"].Name.ToString() + " = " + xTransaccion.Attributes["Concepto"].Value.ToString();
                        tv_estructura.Invoke((MethodInvoker)delegate
                        {
                            tnPoliza.Nodes.Add(tnTransaccion);
                        });

                        totalDebe += Convert.ToDouble(xTransaccion.Attributes["Debe"].Value.ToString());
                        totalHaber += Convert.ToDouble(xTransaccion.Attributes["Haber"].Value.ToString());

                        

                        double totalEnXML = 0;
                        double totalEnCheques = 0;
                        double totalEnTransferencias = 0;

                        XmlNodeList xCompNalLista = xTransaccion.SelectNodes("PLZ:CompNal", xmlnsManager);
                        foreach (XmlNode xCompNal in xCompNalLista)
                        {
                            TreeNode tnCompNal = new TreeNode();
                            tnCompNal.Text += xCompNal.Attributes["RFC"].Name.ToString() + " = " + xCompNal.Attributes["RFC"].Value.ToString() + " | ";
                            tnCompNal.Text += xCompNal.Attributes["MontoTotal"].Name.ToString() + " = " + xCompNal.Attributes["MontoTotal"].Value.ToString() + " | ";
                            tnCompNal.Text += xCompNal.Attributes["Moneda"].Name.ToString() + " = " + xCompNal.Attributes["Moneda"].Value.ToString() + " | ";
                            tnCompNal.Text += xCompNal.Attributes["TipCamb"].Name.ToString() + " = " + xCompNal.Attributes["TipCamb"].Value.ToString() + " | ";
                            tnCompNal.Text += xCompNal.Attributes["UUID_CFDI"].Name.ToString() + " = " + xCompNal.Attributes["UUID_CFDI"].Value.ToString();
                            tv_estructura.Invoke((MethodInvoker)delegate
                            {
                                tnTransaccion.Nodes.Add(tnCompNal);
                            });

                            totalEnXML += Convert.ToDouble(xCompNal.Attributes["MontoTotal"].Value.ToString()) * Convert.ToDouble(xCompNal.Attributes["TipCamb"].Value.ToString());

                        }
                        //recorriendo cada Comprobante nacional Otro
                        XmlNodeList xCompNalOtrLista = xTransaccion.SelectNodes("PLZ:CompNalOtr", xmlnsManager);
                        foreach (XmlNode xCompNalOtr in xCompNalOtrLista)
                        {
                            //atributos CompNal

                            TreeNode tnCompNal = new TreeNode();
                            tnCompNal.Text += xCompNalOtr.Attributes["RFC"].Name.ToString() + " = " + xCompNalOtr.Attributes["RFC"].Value.ToString() + " | ";
                            tnCompNal.Text += xCompNalOtr.Attributes["MontoTotal"].Name.ToString() + " = " + xCompNalOtr.Attributes["MontoTotal"].Value.ToString() + " | ";
                            tnCompNal.Text += xCompNalOtr.Attributes["Moneda"].Name.ToString() + " = " + xCompNalOtr.Attributes["Moneda"].Value.ToString() + " | ";
                            tnCompNal.Text += xCompNalOtr.Attributes["TipCamb"].Name.ToString() + " = " + xCompNalOtr.Attributes["TipCamb"].Value.ToString() + " | ";
                            tv_estructura.Invoke((MethodInvoker)delegate
                            {
                                tnTransaccion.Nodes.Add(tnCompNal);
                            });
                        }
                        //recorriendo cada Comprobante nacional Otro
                        XmlNodeList xCompExtLista = xTransaccion.SelectNodes("PLZ:CompExt", xmlnsManager);
                        foreach (XmlNode xCompExt in xCompExtLista)
                        {
                            TreeNode tnCompExt = new TreeNode();
                            tnCompExt.Text += xCompExt.Attributes["NumFactExt"].Name.ToString() + " = " + xCompExt.Attributes["NumFactExt"].Value.ToString() + " | ";
                            tnCompExt.Text += xCompExt.Attributes["MontoTotal"].Name.ToString() + " = " + xCompExt.Attributes["MontoTotal"].Value.ToString() + " | ";
                            tnCompExt.Text += xCompExt.Attributes["Moneda"].Name.ToString() + " = " + xCompExt.Attributes["Moneda"].Value.ToString() + " | ";
                            tnCompExt.Text += xCompExt.Attributes["TipCamb"].Name.ToString() + " = " + xCompExt.Attributes["TipCamb"].Value.ToString() + " | ";
                            tv_estructura.Invoke((MethodInvoker)delegate
                            {
                                tnTransaccion.Nodes.Add(tnCompExt);
                            });
                        }
                        //recorriendo cada Comprobante nacional Otro
                        XmlNodeList xChequeLista = xTransaccion.SelectNodes("PLZ:Cheque", xmlnsManager);
                        foreach (XmlNode xCheque in xChequeLista)
                        {
                            TreeNode tnCheque = new TreeNode();
                            tnCheque.Text += xCheque.Attributes["RFC"].Name.ToString() + " = " + xCheque.Attributes["RFC"].Value.ToString() + " | ";
                            tnCheque.Text += xCheque.Attributes["Monto"].Name.ToString() + " = " + xCheque.Attributes["Monto"].Value.ToString() + " | ";
                            tnCheque.Text += xCheque.Attributes["Moneda"].Name.ToString() + " = " + xCheque.Attributes["Moneda"].Value.ToString() + " | ";
                            tnCheque.Text += xCheque.Attributes["TipCamb"].Name.ToString() + " = " + xCheque.Attributes["TipCamb"].Value.ToString() + " | ";
                            tnCheque.Text += xCheque.Attributes["Num"].Name.ToString() + " = " + xCheque.Attributes["Num"].Value.ToString() + " | ";
                            tnCheque.Text += xCheque.Attributes["Fecha"].Name.ToString() + " = " + xCheque.Attributes["Fecha"].Value.ToString() + " | ";
                            tnCheque.Text += xCheque.Attributes["Benef"].Name.ToString() + " = " + xCheque.Attributes["Benef"].Value.ToString();
                            tv_estructura.Invoke((MethodInvoker)delegate
                            {
                                tnTransaccion.Nodes.Add(tnCheque);
                            });

                            totalEnCheques += Convert.ToDouble(xCheque.Attributes["Monto"].Value.ToString()) * Convert.ToDouble(xCheque.Attributes["TipCamb"].Value.ToString());

                        }
                        //recorriendo cada Comprobante nacional Otro
                        XmlNodeList xTransferenciaLista = xTransaccion.SelectNodes("PLZ:Transferencia", xmlnsManager);
                        foreach (XmlNode xTransferencia in xTransferenciaLista)
                        {
                            TreeNode tnTransferencia = new TreeNode();
                            tnTransferencia.Text += xTransferencia.Attributes["RFC"].Name.ToString() + " = " + xTransferencia.Attributes["RFC"].Value.ToString() + " | ";
                            tnTransferencia.Text += xTransferencia.Attributes["Monto"].Name.ToString() + " = " + xTransferencia.Attributes["Monto"].Value.ToString() + " | ";
                            tnTransferencia.Text += xTransferencia.Attributes["TipCamb"].Name.ToString() + " = " + xTransferencia.Attributes["TipCamb"].Value.ToString() + " | ";
                            tnTransferencia.Text += xTransferencia.Attributes["CtaDest"].Name.ToString() + " = " + xTransferencia.Attributes["Num"].Value.ToString() + " | ";
                            tnTransferencia.Text += xTransferencia.Attributes["Fecha"].Name.ToString() + " = " + xTransferencia.Attributes["Fecha"].Value.ToString() + " | ";
                            tnTransferencia.Text += xTransferencia.Attributes["Benef"].Name.ToString() + " = " + xTransferencia.Attributes["Benef"].Value.ToString();
                            tv_estructura.Invoke((MethodInvoker)delegate
                            {
                                tnTransaccion.Nodes.Add(tnTransferencia);
                            });

                            totalEnTransferencias += Convert.ToDouble(xTransferencia.Attributes["Monto"].Value.ToString()) * Convert.ToDouble(xTransferencia.Attributes["TipCamb"].Value.ToString());

                        }
                        //recorriendo cada Comprobante nacional Otro
                        XmlNodeList xOtrosLista = xTransaccion.SelectNodes("PLZ:OtrMetodoPago", xmlnsManager);
                        foreach (XmlNode xOtrMetodoPago in xOtrosLista)
                        {
                            TreeNode tnTransferencia = new TreeNode();
                            tnTransferencia.Text += xOtrMetodoPago.Attributes["RFC"].Name.ToString() + " = " + xOtrMetodoPago.Attributes["RFC"].Value.ToString() + " | ";
                            tnTransferencia.Text += xOtrMetodoPago.Attributes["Monto"].Name.ToString() + " = " + xOtrMetodoPago.Attributes["Monto"].Value.ToString() + " | ";
                            tnTransferencia.Text += xOtrMetodoPago.Attributes["TipCamb"].Name.ToString() + " = " + xOtrMetodoPago.Attributes["TipCamb"].Value.ToString() + " | ";
                            tnTransferencia.Text += xOtrMetodoPago.Attributes["CtaDest"].Name.ToString() + " = " + xOtrMetodoPago.Attributes["Num"].Value.ToString() + " | ";
                            tnTransferencia.Text += xOtrMetodoPago.Attributes["Fecha"].Name.ToString() + " = " + xOtrMetodoPago.Attributes["Fecha"].Value.ToString() + " | ";
                            tnTransferencia.Text += xOtrMetodoPago.Attributes["Benef"].Name.ToString() + " = " + xOtrMetodoPago.Attributes["Benef"].Value.ToString();
                            tv_estructura.Invoke((MethodInvoker)delegate
                            {
                                tnTransaccion.Nodes.Add(tnTransferencia);
                            });
                        }
                        //agregando totales por transaccion

                        tv_estructura.Invoke((MethodInvoker)delegate
                        {
                            tnTransaccion.Text += " | TOTAL XML = " + Herramientas.Conversiones.Formatos.DoubleAMoneda(totalEnXML);
                            tnTransaccion.Text += " | TOTAL CHEQUES = " + Herramientas.Conversiones.Formatos.DoubleAMoneda(totalEnCheques);
                            tnTransaccion.Text += " | TOTAL TRANSFERENCIAS = " + Herramientas.Conversiones.Formatos.DoubleAMoneda(totalEnTransferencias);
                        });


                    }

                    //agregando totales

                    tv_estructura.Invoke((MethodInvoker)delegate
                    {
                        tnPoliza.Text += " | DEBE = " + Herramientas.Conversiones.Formatos.DoubleAMoneda(totalDebe);
                        tnPoliza.Text += " | HABER = " + Herramientas.Conversiones.Formatos.DoubleAMoneda(totalHaber);
                    });


                }

                Herramientas.Forms.Mensajes.Informacion("XML Cargado correctamente.");
            }
            catch
            {
                Herramientas.Forms.Mensajes.Error("Ocurrio un error al cargar el XML.");
            }
        }

        private void CargarNodoAuxiliarFolios(object oxml)
        {
            //extrayendo el xml
            try
            {
                String xml = oxml.ToString();

                string temp = Path.GetTempPath() + Herramientas.Conversiones.Formatos.DateTimeAFechaLOGArchivo(DateTime.Now) + ".xml";

                Herramientas.Archivos.Archivo.GuardarArchivoDeTexto(temp, xml);

                //Create an xml reader;
                XmlDocument _xmlDocument = new XmlDocument();
                _xmlDocument.Load(temp);
                XmlNamespaceManager xmlnsManager = new XmlNamespaceManager(_xmlDocument.NameTable);
                xmlnsManager.AddNamespace("RepAux", "http://www.sat.gob.mx/esquemas/ContabilidadE/1_1/AuxiliarFolios");

                //Select the element with in the xml you wish to extract;
                //XmlNodeList _nodeList = _xmlDocument.SelectNodes("//PLZ:Polizas/PLZ:Poliza[@NumUnIdenPol='PG2015100012']/PLZ:Transaccion", xmlnsManager);

                XmlNode xFolios = _xmlDocument.SelectSingleNode("RepAux:RepAuxFol", xmlnsManager);

                TreeNode tnFolios = new TreeNode();
                tnFolios.Text += xFolios.Attributes["RFC"].Name.ToString() + " = " + xFolios.Attributes["RFC"].Value.ToString() + " | ";
                tnFolios.Text += xFolios.Attributes["Anio"].Name.ToString() + " = " + xFolios.Attributes["Anio"].Value.ToString() + " | ";
                tnFolios.Text += xFolios.Attributes["Mes"].Name.ToString() + " = " + xFolios.Attributes["Mes"].Value.ToString() + " | ";
                tnFolios.Text += xFolios.Attributes["TipoSolicitud"].Name.ToString() + " = " + xFolios.Attributes["TipoSolicitud"].Value.ToString() + " | ";
                if (xFolios.Attributes["TipoSolicitud"].Value.ToString().Equals("AF") || xFolios.Attributes["TipoSolicitud"].Value.ToString().Equals("FC"))
                    tnFolios.Text += xFolios.Attributes["NumOrden"].Name.ToString() + " = " + xFolios.Attributes["NumOrden"].Value.ToString();
                if (xFolios.Attributes["TipoSolicitud"].Value.ToString().Equals("DE") || xFolios.Attributes["TipoSolicitud"].Value.ToString().Equals("CO"))
                    tnFolios.Text += xFolios.Attributes["NumTramite"].Name.ToString() + " = " + xFolios.Attributes["NumTramite"].Value.ToString();

                tv_estructura.Invoke((MethodInvoker)delegate
                {
                    tv_estructura.Nodes.Add(tnFolios);
                });


                XmlNodeList xDetallesLista = _xmlDocument.SelectNodes("RepAux:RepAuxFol/RepAux:DetAuxFol", xmlnsManager);
                //recorriendo cada poliza
                foreach (XmlNode xFolio in xDetallesLista)
                {
                    double totalDebe = 0;
                    double totalHaber = 0;

                    TreeNode tnFolio = new TreeNode();
                    tnFolio.Text += xFolio.Attributes["NumUnIdenPol"].Name.ToString() + " = " + xFolio.Attributes["NumUnIdenPol"].Value.ToString() + " | ";
                    tnFolio.Text += xFolio.Attributes["Fecha"].Name.ToString() + " = " + xFolio.Attributes["Fecha"].Value.ToString();

                    tv_estructura.Invoke((MethodInvoker)delegate
                    {
                        tnFolios.Nodes.Add(tnFolio);
                    });

                    
                    double totalEnXML = 0;
                    double totalEnCheques = 0;
                    double totalEnTransferencias = 0;

                    XmlNodeList xCompNalLista = xFolio.SelectNodes("RepAux:ComprNal", xmlnsManager);

                    foreach (XmlNode xCompNal in xCompNalLista)
                    {
                        TreeNode tnCompNal = new TreeNode();
                        tnCompNal.Text += xCompNal.Attributes["RFC"].Name.ToString() + " = " + xCompNal.Attributes["RFC"].Value.ToString() + " | ";
                        tnCompNal.Text += xCompNal.Attributes["MontoTotal"].Name.ToString() + " = " + xCompNal.Attributes["MontoTotal"].Value.ToString() + " | ";
                        tnCompNal.Text += xCompNal.Attributes["Moneda"].Name.ToString() + " = " + xCompNal.Attributes["Moneda"].Value.ToString() + " | ";
                        tnCompNal.Text += xCompNal.Attributes["TipCamb"].Name.ToString() + " = " + xCompNal.Attributes["TipCamb"].Value.ToString() + " | ";
                        tnCompNal.Text += xCompNal.Attributes["UUID_CFDI"].Name.ToString() + " = " + xCompNal.Attributes["UUID_CFDI"].Value.ToString();
                        tv_estructura.Invoke((MethodInvoker)delegate
                        {
                            tnFolio.Nodes.Add(tnCompNal);
                        });

                        totalEnXML += Convert.ToDouble(xCompNal.Attributes["MontoTotal"].Value.ToString()) * Convert.ToDouble(xCompNal.Attributes["TipCamb"].Value.ToString());

                    }
                    //recorriendo cada Comprobante nacional Otro
                    XmlNodeList listacomproExtranjeros = xFolio.SelectNodes("RepAux:ComprExt", xmlnsManager);
                    foreach (XmlNode xCompExt in listacomproExtranjeros)
                    {
                        TreeNode tnCompNal = new TreeNode();
                        tnCompNal.Text += xCompExt.Attributes["NumFactExt"].Name.ToString() + " = " + xCompExt.Attributes["NumFactExt"].Value.ToString() + " | ";
                        tnCompNal.Text += xCompExt.Attributes["MontoTotal"].Name.ToString() + " = " + xCompExt.Attributes["MontoTotal"].Value.ToString() + " | ";
                        tnCompNal.Text += xCompExt.Attributes["Moneda"].Name.ToString() + " = " + xCompExt.Attributes["Moneda"].Value.ToString() + " | ";
                        tnCompNal.Text += xCompExt.Attributes["TipCamb"].Name.ToString() + " = " + xCompExt.Attributes["TipCamb"].Value.ToString() + " | ";
                        tv_estructura.Invoke((MethodInvoker)delegate
                        {
                            tnFolio.Nodes.Add(tnCompNal);
                        });
                    }
                    //recorriendo cada Comprobante nacional Otro

                    XmlNodeList listaOtrosMetodosPago = xFolio.SelectNodes("RepAux:ComprNalOtr", xmlnsManager);
                    foreach (XmlNode xOtrMetodoPago in listaOtrosMetodosPago)
                    {
                        TreeNode tnTransferencia = new TreeNode();
                        tnTransferencia.Text += xOtrMetodoPago.Attributes["RFC"].Name.ToString() + " = " + xOtrMetodoPago.Attributes["RFC"].Value.ToString() + " | ";
                        tnTransferencia.Text += xOtrMetodoPago.Attributes["Monto"].Name.ToString() + " = " + xOtrMetodoPago.Attributes["Monto"].Value.ToString() + " | ";
                        tnTransferencia.Text += xOtrMetodoPago.Attributes["TipCamb"].Name.ToString() + " = " + xOtrMetodoPago.Attributes["TipCamb"].Value.ToString() + " | ";
                        tnTransferencia.Text += xOtrMetodoPago.Attributes["CtaDest"].Name.ToString() + " = " + xOtrMetodoPago.Attributes["Num"].Value.ToString() + " | ";
                        tnTransferencia.Text += xOtrMetodoPago.Attributes["Fecha"].Name.ToString() + " = " + xOtrMetodoPago.Attributes["Fecha"].Value.ToString() + " | ";
                        tnTransferencia.Text += xOtrMetodoPago.Attributes["Benef"].Name.ToString() + " = " + xOtrMetodoPago.Attributes["Benef"].Value.ToString();
                        tv_estructura.Invoke((MethodInvoker)delegate
                        {
                            tnFolio.Nodes.Add(tnTransferencia);
                        });
                    }
                    //agregando totales por transaccion

                    tv_estructura.Invoke((MethodInvoker)delegate
                    {
                        tnFolio.Text += " | TOTAL XML = " + Herramientas.Conversiones.Formatos.DoubleAMoneda(totalEnXML);
                        //tnPoliza.Text += " | TOTAL CHEQUES = " + Herramientas.Conversiones.Formatos.DoubleAMoneda(totalEnCheques);
                        //tnPoliza.Text += " | TOTAL TRANSFERENCIAS = " + Herramientas.Conversiones.Formatos.DoubleAMoneda(totalEnTransferencias);
                    });

                    //agregando totales

                    //tv_estructura.Invoke((MethodInvoker)delegate
                    //{
                    //    tnFolio.Text += " | DEBE = " + Herramientas.Conversiones.Formatos.DoubleAMoneda(totalDebe);
                    //    tnFolio.Text += " | HABER = " + Herramientas.Conversiones.Formatos.DoubleAMoneda(totalHaber);
                    //});


                }

                Herramientas.Forms.Mensajes.Informacion("XML Cargado correctamente.");
            }
            catch
            {
                Herramientas.Forms.Mensajes.Error("Ocurrio un error al cargar el XML.");
            }
        }

        private void CargarNodoAuxiliarCuentas(object oxml)
        {
            //extrayendo el xml
            try
            {
                String xml = oxml.ToString();

                string temp = Path.GetTempPath() + Herramientas.Conversiones.Formatos.DateTimeAFechaLOGArchivo(DateTime.Now) + ".xml";

                Herramientas.Archivos.Archivo.GuardarArchivoDeTexto(temp, xml);

                //Create an xml reader;
                XmlDocument _xmlDocument = new XmlDocument();
                _xmlDocument.Load(temp);
                XmlNamespaceManager xmlnsManager = new XmlNamespaceManager(_xmlDocument.NameTable);
                xmlnsManager.AddNamespace("AuxiliarCtas", "http://www.sat.gob.mx/esquemas/ContabilidadE/1_1/AuxiliarCtas");

                //Select the element with in the xml you wish to extract;
                //XmlNodeList _nodeList = _xmlDocument.SelectNodes("//PLZ:Polizas/PLZ:Poliza[@NumUnIdenPol='PG2015100012']/PLZ:Transaccion", xmlnsManager);

                XmlNode xPolizas = _xmlDocument.SelectSingleNode("AuxiliarCtas:AuxiliarCtas", xmlnsManager);

                TreeNode tnPolizas = new TreeNode();
                tnPolizas.Text += xPolizas.Attributes["RFC"].Name.ToString() + " = " + xPolizas.Attributes["RFC"].Value.ToString() + " | ";
                tnPolizas.Text += xPolizas.Attributes["Anio"].Name.ToString() + " = " + xPolizas.Attributes["Anio"].Value.ToString() + " | ";
                tnPolizas.Text += xPolizas.Attributes["Mes"].Name.ToString() + " = " + xPolizas.Attributes["Mes"].Value.ToString() + " | ";
                tnPolizas.Text += xPolizas.Attributes["TipoSolicitud"].Name.ToString() + " = " + xPolizas.Attributes["TipoSolicitud"].Value.ToString() + " | ";
                if (xPolizas.Attributes["TipoSolicitud"].Value.ToString().Equals("AF") || xPolizas.Attributes["TipoSolicitud"].Value.ToString().Equals("FC"))
                    tnPolizas.Text += xPolizas.Attributes["NumOrden"].Name.ToString() + " = " + xPolizas.Attributes["NumOrden"].Value.ToString();
                if (xPolizas.Attributes["TipoSolicitud"].Value.ToString().Equals("DE") || xPolizas.Attributes["TipoSolicitud"].Value.ToString().Equals("CO"))
                    tnPolizas.Text += xPolizas.Attributes["NumTramite"].Name.ToString() + " = " + xPolizas.Attributes["NumTramite"].Value.ToString();

                tv_estructura.Invoke((MethodInvoker)delegate
                {
                    tv_estructura.Nodes.Add(tnPolizas);
                });
                
                XmlNodeList _nodeList = _xmlDocument.SelectNodes("AuxiliarCtas:AuxiliarCtas/AuxiliarCtas:Cuenta", xmlnsManager);
                //recorriendo cada poliza
                foreach (XmlNode xPoliza in _nodeList)
                {
                    double totalDebe = 0;
                    double totalHaber = 0;

                    TreeNode tnCuenta = new TreeNode();
                    tnCuenta.Text += xPoliza.Attributes["NumCta"].Name.ToString() + " = " + xPoliza.Attributes["NumCta"].Value.ToString() + " | ";
                    tnCuenta.Text += xPoliza.Attributes["SaldoIni"].Name.ToString() + " = " + xPoliza.Attributes["SaldoIni"].Value.ToString() + " | ";
                    tnCuenta.Text += xPoliza.Attributes["SaldoFin"].Name.ToString() + " = " + xPoliza.Attributes["SaldoFin"].Value.ToString() + " | ";
                    tnCuenta.Text += xPoliza.Attributes["DesCta"].Name.ToString() + " = " + xPoliza.Attributes["DesCta"].Value.ToString();

                    tv_estructura.Invoke((MethodInvoker)delegate
                    {
                        tnPolizas.Nodes.Add(tnCuenta);
                    });


                    XmlNodeList detallesLista = xPoliza.SelectNodes("AuxiliarCtas:DetalleAux", xmlnsManager);

                    foreach (XmlNode xDetalle in detallesLista)
                    {
                        TreeNode tnCompNal = new TreeNode();
                        tnCompNal.Text += xDetalle.Attributes["NumUnIdenPol"].Name.ToString() + " = " + xDetalle.Attributes["NumUnIdenPol"].Value.ToString() + " | ";
                        tnCompNal.Text += xDetalle.Attributes["Fecha"].Name.ToString() + " = " + xDetalle.Attributes["Fecha"].Value.ToString() + " | ";
                        tnCompNal.Text += xDetalle.Attributes["Debe"].Name.ToString() + " = " + xDetalle.Attributes["Debe"].Value.ToString() + " | ";
                        tnCompNal.Text += xDetalle.Attributes["Haber"].Name.ToString() + " = " + xDetalle.Attributes["Haber"].Value.ToString() + " | ";
                        tnCompNal.Text += xDetalle.Attributes["Concepto"].Name.ToString() + " = " + xDetalle.Attributes["Concepto"].Value.ToString();
                        tv_estructura.Invoke((MethodInvoker)delegate
                        {
                            tnCuenta.Nodes.Add(tnCompNal);
                        });

                        totalDebe +=Convert.ToDouble(xDetalle.Attributes["Debe"].Value.ToString());
                        totalHaber += Convert.ToDouble(xDetalle.Attributes["Haber"].Value.ToString());

                    }


                    //agregando totales

                    tv_estructura.Invoke((MethodInvoker)delegate
                    {
                        tnCuenta.Text += " | DEBE = " + Herramientas.Conversiones.Formatos.DoubleAMoneda(totalDebe);
                        tnCuenta.Text += " | HABER = " + Herramientas.Conversiones.Formatos.DoubleAMoneda(totalHaber);
                    });


                }

                Herramientas.Forms.Mensajes.Informacion("XML Cargado correctamente.");
            }
            catch
            {
                Herramientas.Forms.Mensajes.Error("Ocurrio un error al cargar el XML.");
            }
        }

        private void tv_estructura_Click(object sender, EventArgs e)
        {
            TreeViewHitTestInfo info = tv_estructura.HitTest(tv_estructura.PointToClient(Cursor.Position));
            if (info != null)
            {
                try
                {
                    dgv_datos.Rows.Clear();
                    String[] valores = info.Node.Text.Split('|');

                    foreach (String valor in valores)
                    {
                        dgv_datos.Rows.Add(valor.Split('=')[0].Trim(), valor.Split('=')[1].Trim());
                    }
                }
                catch
                {
                }

            }
        }


    }
}
