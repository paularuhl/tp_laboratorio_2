using System;
using System.Linq;

namespace Entidades
{
    public class Calculadora
    {
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            switch (ValidarOperador(operador))
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
            }
            return resultado;
        }

        private static string ValidarOperador(string operador)
        {
            string[] operadores = { "+", "-", "*", "/" };
            return operadores.Contains(operador) ? operador : operadores[0];
        }
    }
}
