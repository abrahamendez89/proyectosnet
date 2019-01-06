using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCalc;
namespace Herramientas.Calculos
{
    public class Expresion
    {
        public static double CalcularExpresionString(String expresion)
        {
            Expression exp = new Expression(expresion);
            return Convert.ToDouble(exp.Evaluate());
        }
    }
}
