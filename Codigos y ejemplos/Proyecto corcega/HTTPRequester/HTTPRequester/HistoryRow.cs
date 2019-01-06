using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTTPRequester
{
    public class HistoryRow
    {

        public delegate void _EVT_CambioURL(HistoryRow Anterior, String nuevaURL);
        public event _EVT_CambioURL EVT_CambioURL;

        public Boolean isChanged { get; set; }
        public Boolean ActivarEventos { get; set; }

        private int id;
        public int ID { get { return id; } set { isChanged = true; id = value; } }
        private string url;
        public String URL { get { return url; } set 
        {
            if (url != null && !url.Equals(value) && EVT_CambioURL != null && ActivarEventos)
            {
                EVT_CambioURL(this, value);
                return;
            }

            if (url != value) { isChanged = true; }

            url = value; 
            
        } }
        private string method;
        public String Method { get { return method; } set { if (method != value) { isChanged = true; } method = value; } }
        private List<Header> headers;
        public List<Header> Headers { get { return headers; } set { headers = value; isChanged = true; } }
        private string body;
        public String Body { get { return body; } set { if (body != value) { isChanged = true; } body = value; } }
    }
}
