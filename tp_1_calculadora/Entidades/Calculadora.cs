using System;
using System.Linq;

namespace Entidades
{
    /// <summary>
    /// Esta clase realiza cálculos y validaciones.
    /// </summary>
    public class Calculadora
    {
        /// <summary>
        /// Este método realiza una operación aritmética sobre dos operandos y un operador que el usuario elija
        /// </summary>
        /// <param name="num1">Primer operando</param>
        /// <param name="num2">Segundo operando</param>
        /// <param name="operador">Operador aritmético</param>
        /// <returns>Devuelve un valor de tipo double con el resultado de la operación.</returns>
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

        /// <summary>
        /// Este método valida que el operador ingresado esté dentro de ciertos valores.
        /// </summary>
        /// <param name="operador">Operador a validar</param>
        /// <returns>Si la validación es correcta, devuelve el operador ingresado. Si no, devuelve +.</returns>
        private static string ValidarOperador(string operador)
        {
            string[] operadores = { "+", "-", "*", "/" };
            return operadores.Contains(operador) ? operador : operadores[0];
        }
    }
}
