using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        private string SetNumero
        {
            set
            {
                numero = ValidarNumero(value);
            }
        }

        public Numero() : this(0)
        {
        }
        public Numero(double numero)
        {
            SetNumero = numero.ToString();
        }
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }

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
        /// <param name="entero">Número decimal, en tipo double</param>
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

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0) return double.MinValue;

            return n1.numero / n2.numero;
        }

    }
}
