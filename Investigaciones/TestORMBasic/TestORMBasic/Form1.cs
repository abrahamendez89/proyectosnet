using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Newtonsoft.Json;

namespace TestORMBasic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            _ClaseA a = new _ClaseA();
            a.In_atributo2 = 5;
            a.St_atributo1 = "algo";
            a.Oo_classB = new _ClaseB();
            a.Oo_classB.St_atributo1 = "atributo";
            a.Oo_classB.Ll_classALista = new List<_ClaseA>();
            a.Oo_classB.Ll_classALista.Add(new _ClaseA() { In_atributo2 = 3 });
            a.Oo_classB.Ll_classALista.Add(new _ClaseA() { In_atributo2 = 2 });
            a.Oo_classB.Ll_classALista.Add(new _ClaseA() { In_atributo2 = 1 });

            String json = JsonConvert.SerializeObject(a);

            _ClaseA regreso = JsonConvert.DeserializeObject<_ClaseA>(json);
        }
    }
}
