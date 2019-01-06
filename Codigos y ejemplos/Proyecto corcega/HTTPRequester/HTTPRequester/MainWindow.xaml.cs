using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Threading;
using System.Windows.Threading;
using System.Net;

namespace HTTPRequester
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>



    public partial class MainWindow : Window
    {
        HistoryRow objActual;
        public MainWindow()
        {
            InitializeComponent();

            cmbMetodos.Items.Add("GET");
            cmbMetodos.Items.Add("POST");
            cmbMetodos.Items.Add("DELETE");
            cmbMetodos.Items.Add("PUT");
            //Verificando existencia de base de datos historial
            try
            {
                SQLiteHelper.VerificarExistenciaBD();
                ActualizaCombo();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ActualizaCombo()
        {
            cmbUrl.SelectionChanged -= new SelectionChangedEventHandler(cmbUrl_SelectionChanged);
            List<HistoryRow> historial = SQLiteHelper.ObtenerHistorial();//.OrderByDescending(x => x.ID).ToList();

            historial.ForEach(x => x.EVT_CambioURL -= new HistoryRow._EVT_CambioURL(x_EVT_CambioURL));
            historial.ForEach(x => x.EVT_CambioURL += new HistoryRow._EVT_CambioURL(x_EVT_CambioURL));

            if (historial.Count == 0)
            {
                objActual = new HistoryRow();
                historial.Add(objActual);
            }
            else
            {
                objActual = historial[0];
            }
            CargaDatos();
            cmbUrl.ItemsSource = historial;
            cmbUrl.SelectedItem = historial[0];
            cmbUrl.Items.Refresh();
            cmbUrl.SelectionChanged += new SelectionChangedEventHandler(cmbUrl_SelectionChanged);
            //grdPrincipal.DataContext = cmbUrl.SelectedItem;
        }

        void x_EVT_CambioURL(HistoryRow anterior, String nuevaURL)
        {
            HistoryRow row = new HistoryRow();
            row.URL = nuevaURL;
            row.Method = anterior.Method;
            row.Body = anterior.Body;
            row.isChanged = true;
            ((List<HistoryRow>)cmbUrl.ItemsSource).Insert(0, row);
            cmbUrl.Items.Refresh();
            cmbUrl.SelectedItem = ((List<HistoryRow>)cmbUrl.ItemsSource)[0];
            row.ActivarEventos = true;
            row.EVT_CambioURL -= new HistoryRow._EVT_CambioURL(x_EVT_CambioURL);
            row.EVT_CambioURL += new HistoryRow._EVT_CambioURL(x_EVT_CambioURL);
            objActual = row;
            //grdPrincipal.DataContext = objActual;
        }
        void cmbUrl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            HistoryRow row = (HistoryRow)cmbUrl.SelectedItem;
            if (row != null)
            {
                //grdPrincipal.DataContext = row;
                //cmbUrl.Text = row.URL;
                if (objActual != row)
                {
                    objActual = row;
                    CargaDatos();
                }

            }

        }
        List<Header> headers = new List<Header>();

        public void CargaDatos()
        {
            cmbUrl.Text = objActual.URL;
            cmbMetodos.SelectedItem = objActual.Method;
            txtBody.Text = objActual.Body;
        }

        public void AsignaDatos()
        {
            objActual.URL = cmbUrl.Text;
            objActual.Method = cmbMetodos.SelectedItem.ToString();
            objActual.Body = txtBody.Text;
        }

        public void HttpPost(string URI, string method, string body)
        {
            /*
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
            //req.Proxy = new System.Net.WebProxy(ProxyString, true);
            //Add these, as we're doing a POST
            req.ContentType = "application/x-www-form-urlencoded";
            if (headers.Count > 0)
            {
                foreach (Header header in headers)
                {
                    req.Headers.Add(header.Key, header.Value);
                }
            }
            req.Method = method;
            //We need to count how many bytes we're sending. Post'ed Faked Forms should be name=value&
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(body);
            req.ContentLength = bytes.Length;
            System.IO.Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length); //Push it out there
            os.Close();
            var start = Process.GetCurrentProcess().TotalProcessorTime;
            System.Net.WebResponse resp = req.GetResponse();
            var stop = Process.GetCurrentProcess().TotalProcessorTime;
            var cosa = resp.ContentType;
            if (resp != null)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());


                String resultado = sr.ReadToEnd().Trim();

                if (resp.ContentType.Contains("application/json"))
                {
                    resultado = JsonHelper.FormatJson(resultado);
                }
                else if (resp.ContentType.Contains("text/html"))
                {

                }

                Dispatcher.BeginInvoke(DispatcherPriority.Background,
                       (Action)(() =>
                       {
                           lblResponseTime.Content = (stop - start).TotalMilliseconds + " ms";
                           txtResponse.Text = resultado;
                       }));
            }
            else
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Background,
                     (Action)(() =>
                     {
                         lblResponseTime.Content = (stop - start).TotalMilliseconds + " ms";
                         txtResponse.Text = "";
                     }));
            }
            */

            WebClient wc = new WebClient();
            wc.Headers.Add("Content-Type", "application/json");
            wc.Encoding = System.Text.Encoding.UTF8;
            if (headers.Count > 0)
            {
                foreach (Header header in headers)
                {
                    wc.Headers.Add(header.Key, header.Value);
                }
            }
            var start = Process.GetCurrentProcess().TotalProcessorTime;
            var stop = Process.GetCurrentProcess().TotalProcessorTime;
            try
            {
                byte[] data = Encoding.ASCII.GetBytes(body);
                var response = wc.UploadString(URI, method, body);
                stop = Process.GetCurrentProcess().TotalProcessorTime;
                String resultado = JsonHelper.FormatJson(response);
                /*if ( .ContentType.Contains("application/json"))
                {
                    resultado = JsonHelper.FormatJson(response);
                }
                */
                Dispatcher.BeginInvoke(DispatcherPriority.Background,
               (Action)(() =>
               {
                   lblResponseTime.Content = (stop - start).TotalMilliseconds + " ms";
                   txtResponse.Text = resultado;
               }));

            }
            catch (Exception ex)
            {
                stop = Process.GetCurrentProcess().TotalProcessorTime;
                Dispatcher.BeginInvoke(DispatcherPriority.Background,
                (Action)(() =>
                {
                    lblResponseTime.Content = (stop - start).TotalMilliseconds + " ms";
                    txtResponse.Text = "";
                }));
            }

            times.Add((stop - start).TotalMilliseconds);
            Dispatcher.BeginInvoke(DispatcherPriority.Background,
                       (Action)(() =>
                       {
                           lbResults.Items.Add("Responds in (ms): " + (stop - start).TotalMilliseconds);

                       }));


            //return resultado;
        }

        public void HttpGet(string URI)
        {
            /*
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
            req.ContentType = "application/x-www-form-urlencoded";
            if (headers.Count > 0)
            {
                foreach (Header header in headers)
                {
                    req.Headers.Add(header.Key, header.Value);
                }
            }
            //req.Proxy = new System.Net.WebProxy(ProxyString, true); //true means no proxy
            var start = Process.GetCurrentProcess().TotalProcessorTime;
            System.Net.WebResponse resp = req.GetResponse();
            var stop = Process.GetCurrentProcess().TotalProcessorTime;

            if (resp != null)
            {
                var cosa = resp.ContentType;
                System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());



                String resultado = sr.ReadToEnd().Trim();

                if (resp.ContentType.Contains("application/json"))
                {
                    resultado = JsonHelper.FormatJson(resultado);
                }
                else if (resp.ContentType.Contains("text/html"))
                {

                }
                Dispatcher.BeginInvoke(DispatcherPriority.Background,
                       (Action)(() =>
                       {
                           lblResponseTime.Content = (stop - start).TotalMilliseconds + " ms";
                           txtResponse.Text = resultado;
                       }));
            }
            else
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Background,
                     (Action)(() =>
                     {
                         lblResponseTime.Content = (stop - start).TotalMilliseconds + " ms";
                         txtResponse.Text = "";
                     }));
            }
             * */
            //return resultado;


            WebClient wc = new WebClient();
            wc.Headers["Content-Type"] = "application/x-www-form-urlencoded";


            var start = Process.GetCurrentProcess().TotalProcessorTime;
            var stop = Process.GetCurrentProcess().TotalProcessorTime;
            try
            {
                String response = wc.DownloadString(URI);
                stop = Process.GetCurrentProcess().TotalProcessorTime;
                string resultado = response;
                //Dispatcher.BeginInvoke(DispatcherPriority.Background,
                //    if (resp.ContentType.Contains("application/json"))
                //{
                    resultado = JsonHelper.FormatJson(resultado);
                //}
                    Dispatcher.BeginInvoke(DispatcherPriority.Background,
                      (Action)(() =>
                      {
                          lblResponseTime.Content = (stop - start).TotalMilliseconds + " ms";
                          txtResponse.Text = resultado;
                      }));
            }
            catch (Exception ex)
            {
                stop = Process.GetCurrentProcess().TotalProcessorTime;
                Dispatcher.BeginInvoke(DispatcherPriority.Background,
                (Action)(() =>
                {
                    lbResults.Items.Add("Error: " + ex.Message + " Time: " + (stop - start).TotalMilliseconds);
                }));
            }
        }
        private void EjecutarEnviarThread()
        {

            try
            {


                if (objActual.Method == "GET")
                {
                    HttpGet(objActual.URL);

                }
                else if (objActual.Method != null)
                {
                    HttpPost(objActual.URL, objActual.Method, objActual.Body.Replace("\n",""));
                }




            }
            catch (Exception ex)
            {
                Dispatcher.BeginInvoke(
                       (Action)(() =>
                       {
                           lblResponseTime.Content = "ERROR";
                           txtResponse.Text = ex.Message;
                       }));

            }

            try
            {
                SQLiteHelper.InsertarHistorialPorURL(objActual);
            }
            catch (Exception ex)
            {

            }

            Dispatcher.BeginInvoke(DispatcherPriority.Background,
                        (Action)(() =>
                        {
                            ActualizaCombo();
                        }));

        }
        private void btnEnviar_Click(object sender, RoutedEventArgs e)
        {



            if (cmbMetodos.SelectedItem == null)
            {
                MessageBox.Show("Select a Web Method", "Information", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            objActual.ActivarEventos = false;
            AsignaDatos();
            objActual.ActivarEventos = true;
            lblResponseTime.Content = "ENVIANDO...";
            txtResponse.Text = "";

            Thread t = new Thread(EjecutarEnviarThread);
            //t.Priority = ThreadPriority.Highest;
            t.Start();



        }

        private void btnAddHeader_Click(object sender, RoutedEventArgs e)
        {
            headers.Add(new Header());
            grdHeaders.ItemsSource = headers;
        }

        private void btnRemoveHeader_Click(object sender, RoutedEventArgs e)
        {
            if (grdHeaders.SelectedItem != null)
            {
                headers.Remove((Header)grdHeaders.SelectedItem);
                grdHeaders.Items.Refresh();
            }
        }
        int petitions = 0;
        int threads = 0;
        int delay = 0;
        List<double> times = new List<double>();
        List<Thread> threadsArr = new List<Thread>();
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            objActual.ActivarEventos = false;
            AsignaDatos();
            objActual.ActivarEventos = true;
            try
            {
                petitions = Convert.ToInt32(txtRequesPerThread.Text);
            }
            catch
            {
                MessageBox.Show("Requests per thread must be a number", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            try
            {
                threads = Convert.ToInt32(txtThreads.Text);
            }
            catch
            {
                MessageBox.Show("Threads must be a number", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            try
            {
                delay = Convert.ToInt32(txtDelay.Text);
            }
            catch
            {
                MessageBox.Show("Delay must be a number", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            if (cmbMetodos.SelectedItem == null)
            {
                MessageBox.Show("Select a Web Method", "Information", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            //creando hilos
            spProgress.Children.Clear();
            times.Clear();
            lbResults.Items.Clear();
            threadsArr.Clear();
            lblAvgTime.Content = 0.ToString("0.0000");
            lblMaxTime.Content = 0.ToString("0.0000");
            lblMinTime.Content = 0.ToString("0.0000");
            for (int i = 0; i < threads; i++)
            {
                Thread t = new Thread(ThreadExecution);
                t.Start();
                threadsArr.Add(t);
            }
            Thread tVerifica = new Thread(CalculaTiempos);
            tVerifica.Start();

        }
        public void CalculaTiempos()
        {
            while (true)
            {
                Thread.Sleep(10);
                if (threadsArr.Where(x => x.ThreadState == System.Threading.ThreadState.Running && x.ThreadState != System.Threading.ThreadState.Stopped && x.ThreadState != System.Threading.ThreadState.Suspended).ToList().Count == 0)
                {
                    try
                    {
                        double avg = times.Sum() / times.Count;
                        double max = times.Max();
                        double min = times.Min();
                        Dispatcher.BeginInvoke(DispatcherPriority.Background,
                             (Action)(() =>
                             {
                                 lblAvgTime.Content = avg.ToString("0.0000");
                                 lblMaxTime.Content = max.ToString("0.0000");
                                 lblMinTime.Content = min.ToString("0.0000");
                                 MessageBox.Show("Request finish", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                             }));
                    }
                    catch
                    { }
                    break;
                }
            }
        }
        public void ThreadExecution()
        {

            ProgressBar pb = null;
             Dispatcher.BeginInvoke(DispatcherPriority.Background,
                      (Action)(() =>
                      {
                           pb = new ProgressBar();
                          pb.Height = 10;
                          pb.Margin = new Thickness(5);
                        spProgress.Children.Add(pb);
                      }));

            for (int i = 0; i < petitions; i++)
            {
                if (objActual.Method.Equals("GET"))
                {
                    HttpGetThread(objActual.URL);
                }
                else
                {
                    HttpPostThread(objActual.URL, objActual.Method, objActual.Body);
                }
                Dispatcher.BeginInvoke(DispatcherPriority.Background,
                      (Action)(() =>
                      {
                pb.Value = (i * 100) / petitions;
                      }));
                Thread.Sleep(delay);
               
            }
        }
        //ACA PARA MULTIPLES
         
        public void HttpGetThread(string URI)
        {
            /*
            System.Net.WebRequest req  = System.Net.WebRequest.Create(URI);
            req.ContentType = "application/x-www-form-urlencoded";
            if (headers.Count > 0)
            {
                foreach (Header header in headers)
                {
                    req.Headers.Add(header.Key, header.Value);
                }
            }
            //req.Proxy = new System.Net.WebProxy(ProxyString, true); //true means no proxy
            var start = Process.GetCurrentProcess().TotalProcessorTime;
            var stop = Process.GetCurrentProcess().TotalProcessorTime;
            try
            {
                System.Net.WebResponse resp = req.GetResponse();
                stop = Process.GetCurrentProcess().TotalProcessorTime;
            }
            catch (Exception ex)
            {
                stop = Process.GetCurrentProcess().TotalProcessorTime;
                Dispatcher.BeginInvoke(DispatcherPriority.Background,
                (Action)(() =>
                {
                    lbResults.Items.Add("[" + start.ToString() + "] Error: " + ex.Message + " Time: " + (stop - start).TotalMilliseconds);
                }));
            }

            times.Add((stop - start).TotalMilliseconds);
            Dispatcher.BeginInvoke(DispatcherPriority.Background,
                       (Action)(() =>
                       {
                           lbResults.Items.Add("["+start.ToString()+"] Responds in (ms): " + (stop - start).TotalMilliseconds);
                           
                       }));

            */
            WebClient wc = new WebClient();
            wc.Headers["Content-Type"] = "application/x-www-form-urlencoded";


            var start = Process.GetCurrentProcess().TotalProcessorTime;
            var stop = Process.GetCurrentProcess().TotalProcessorTime;
            try
            {
                String response = wc.DownloadString(URI);
                stop = Process.GetCurrentProcess().TotalProcessorTime;
            }
            catch (Exception ex)
            {
                stop = Process.GetCurrentProcess().TotalProcessorTime;
                Dispatcher.BeginInvoke(DispatcherPriority.Background,
                (Action)(() =>
                {
                    lbResults.Items.Add("Error: " + ex.Message + " Time: " + (stop - start).TotalMilliseconds);
                }));
            }

            times.Add((stop - start).TotalMilliseconds);
            Dispatcher.BeginInvoke(DispatcherPriority.Background,
                       (Action)(() =>
                       {
                           lbResults.Items.Add("Responds in (ms): " + (stop - start).TotalMilliseconds);

                       }));
            
        }
        public void HttpPostThread(string URI, string method, string body)
        {
            /*
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
            //req.Proxy = new System.Net.WebProxy(ProxyString, true);
            //Add these, as we're doing a POST
            req.ContentType = "application/x-www-form-urlencoded";
           
            req.Method = method;
            //We need to count how many bytes we're sending. Post'ed Faked Forms should be name=value&
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(body);
            req.ContentLength = bytes.Length;
            System.IO.Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length); //Push it out there
            os.Close();
            var start = Process.GetCurrentProcess().TotalProcessorTime;
            var stop = Process.GetCurrentProcess().TotalProcessorTime;
            try
            {
                System.Net.WebResponse resp = req.GetResponse();
                stop = Process.GetCurrentProcess().TotalProcessorTime;
            }
            catch (Exception ex)
            {
                stop = Process.GetCurrentProcess().TotalProcessorTime;
                Dispatcher.BeginInvoke(DispatcherPriority.Background,
                (Action)(() =>
                       {
                           lbResults.Items.Add("Error: "+ex.Message+" Time: " + (stop - start).TotalMilliseconds);
                       }));
            }

            times.Add((stop - start).TotalMilliseconds);
            Dispatcher.BeginInvoke(DispatcherPriority.Background,
                       (Action)(() =>
                       {
                           lbResults.Items.Add("Responds in (ms): " + (stop - start).TotalMilliseconds);
                         
                       }));

            //return resultado;
             * */

            WebClient wc = new WebClient();
            wc.Headers.Add("Content-Type", "application/json");
            wc.Encoding = System.Text.Encoding.UTF8;
            if (headers.Count > 0)
            {
                foreach (Header header in headers)
                {
                    wc.Headers.Add(header.Key, header.Value);
                }
            }
            var start = Process.GetCurrentProcess().TotalProcessorTime;
            var stop = Process.GetCurrentProcess().TotalProcessorTime;
            try
            {
                byte[] data = Encoding.ASCII.GetBytes(body);
                var response = wc.UploadString(URI, method, body);
                stop = Process.GetCurrentProcess().TotalProcessorTime;
            }
            catch (Exception ex)
            {
                stop = Process.GetCurrentProcess().TotalProcessorTime;
                Dispatcher.BeginInvoke(DispatcherPriority.Background,
                (Action)(() =>
                {
                    lbResults.Items.Add("Error: " + ex.Message + " Time: " + (stop - start).TotalMilliseconds);
                }));
            }

            times.Add((stop - start).TotalMilliseconds);
            Dispatcher.BeginInvoke(DispatcherPriority.Background,
                       (Action)(() =>
                       {
                           lbResults.Items.Add("Responds in (ms): " + (stop - start).TotalMilliseconds);

                       }));
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            threadsArr.ForEach(x => x.Abort());
        }

    }
    public class Header
    {
        public String Key { get; set; }
        public String Value { get; set; }
    }
}
