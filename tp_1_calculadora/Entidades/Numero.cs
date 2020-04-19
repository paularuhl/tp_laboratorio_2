using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    /// <summary>
    /// Esta clase permite operar entre numeros, y realizar conversiones entre sistema binario y sistema decimal.
    /// </summary>
    public class Numero
    {
        /// <summary>
        /// Atributo con el que se va a operar
        /// </summary>
        private double numero;

        /// <summary>
        /// Esta propiedad le asigna un valor al campo numero de ésta clase.
        /// </summary>
        private string SetNumero
        {
            set
            {
                numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Este Constructor por defecto, inicializa el atributo numero en 0.
        /// </summary>
        public Numero() : this(0)
        {
        }

        /// <summary>
        /// Este constructor asigna un valor numérico al atributo numero.
        /// </summary>
        /// <param name="numero"> numero a asignar </param>
        public Numero(double numero) : this(numero.ToString())
        {
        }

        /// <summary>
        /// Este constructor asigna un valor de tipo string al atributo numero.
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }

        /// <summary>
        /// Este método valida que lo ingresado por el usuario pueda convertirse a double.
        /// </summary>
        /// <param name="strNumero">Numero a validar</param>
        /// <returns>Devuelve el numero convertido a tipo double, caso contrario 0 si no puede convertirse.</returns>
        private double ValidarNumero(string strNumero)
        {
            double numero;
            double.TryParse(strNumero, out numero);
            return numero;
        }

        /// <summary>
        /// Este método convierte un numero binario a uno decimal.
        /// </summary>
        /// <param name="binario">Número binario, en tipo string</param>
        /// <returns>Devuelve el resultado si es posible convertir, caso contrario devuelve el mensaje "Valor inválido"</returns>
        public static string BinarioDecimal(string binario)
        {
            double numero = 0;
            int largoArrayBinario = binario.Length;

            foreach(char a in binario)
            {
                if (a != '0' && a != '1') return "Valor inválido";
            }

            for (int i = 0; i < largoArrayBinario; i++)
            {
                numero += double.Parse(binario[i].ToString()) * Math.Pow(2, largoArrayBinario - i - 1);
            }

            return numero.ToString();
        }

        /// <summary>
        /// Este método convierte un numero decimal a uno binario
        /// </summary>
        /// <param name="numero">Número decimal, en tipo double</param>
        /// <returns>Devuelve el resultado de la conversión.</returns>
        public static string DecimalBinario(double numero)
        {
            string numeroBinario = String.Empty;
            numero = (int)numero;
            do
            {
                numeroBinario = numeroBinario + (numero % 2);
                numero = (int)numero / 2;
                if (numero < 2) numeroBinario = numeroBinario + numero;

            } while (numero > 1);

            char[] charArray = numeroBinario.ToCharArray();
            Array.Reverse(charArray);

            return new string(charArray);
        }

        /// <summary>
        /// Sobrecarga del metodo DecimalBinario que verifica que 
        /// el numero ingresado para convertir sea efectivamente un número, y luego realiza la conversión.
        /// </summary>
        /// <param name="numero">Numero que sera convertido</param>
        /// <returns>Si se pudo convertir, devuelve el resultado en tipo string, caso contrario, el mensaje "Valor inválido".</returns>
        public static string DecimalBinario(string numero)
        {
            double numeroDecimal;
            if (double.TryParse(numero, out numeroDecimal))
            {
                return DecimalBinario(numeroDecimal);
            }
            else
            {
                return "Valor inválido";
            }
        }

        /// <summary>
        /// Sobrecarga del operador +, capaz de sumar dos objetos de tipo Numero.
        /// </summary>
        /// <param name="n1">1er operando</param>
        /// <param name="n2">2do operando</param>
        /// <returns>Devuelve el resultado de la operación</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador -, capaz de restar un objeto de tipo Numero a otro.
        /// </summary>
        /// <param name="n1">1er operando</param>
        /// <param name="n2">2do operando</param>
        /// <returns>Devuelve el resultado de la operación</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador *, capaz de multiplicar dos objetos de tipo Numero.
        /// </summary>
        /// <param name="n1">1er operando</param>
        /// <param name="n2">2do operando</param>
        /// <returns>Devuelve el resultado de la operación</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador /, capaz de realizar una división entre dos objetos de tipo Numero.
        /// </summary>
        /// <param name="n1">1er operando</param>
        /// <param name="n2">2do operando</param>
        /// <returns>Devuelve el resultado de la división. En caso de que el 2do operando sea un 0, retorna el minimo valor posible de la clase double.</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0) return double.MinValue;

            return n1.numero / n2.numero;
        }

    }
}
