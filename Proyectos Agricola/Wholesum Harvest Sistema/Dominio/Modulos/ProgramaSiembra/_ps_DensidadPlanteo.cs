using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Modulos.ProgramaSiembra
{
    public class _ps_DensidadPlanteo:ObjetoBase
    {
        
        #region atributos privados
        private float _fl_Centimetros_de_separacion;
        private int _in_Numero_de_hileras;
        private float _fl_CentimetrosCorazon;
        #endregion

        #region propiedades publicas
        public float fl_Centimetros_de_separacion
        {
            get { return _fl_Centimetros_de_separacion; }
            set { _fl_Centimetros_de_separacion = value; }
        }
        public int in_Numero_de_hileras
        {
            get { return _in_Numero_de_hileras; }
            set { _in_Numero_de_hileras = value; }
        }
        public float Fl_CentimetrosCorazon
        {
            get { return _fl_CentimetrosCorazon; }
            set { _fl_CentimetrosCorazon = value; }
        }
        #endregion

        #region consultas
        public static readonly String ConsultaTodos = "select * from _ps_DensidadPlanteo";
        #endregion
        

        
    }
}
