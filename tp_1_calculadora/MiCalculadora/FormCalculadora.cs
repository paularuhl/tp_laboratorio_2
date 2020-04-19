using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
            lblResultado.Text = string.Empty;

            string[] operadores = { "+", "-", "*", "/", string.Empty };
            foreach (string operador in operadores)
            {
                this.cmbOperador.Items.Add(operador);
            }
        }

        /// <summary>
        /// Este método cierra nuestro programa si clickeamos "Cerrar";
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Este método realiza una conversión de un numero decimal a uno binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
        }

        /// <summary>
        /// Este método realiza una conversión de un numero binario a uno decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
        }

        /// <summary>
        /// Este método recibe el disparador para reiniciar los valores de la calculadora, dejándolos vacíos. 
        /// Solo aplica para textbox, combobox y labels.
        /// </summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Este método llama al método que opera el contenido de las TextBox con el operador del ComboBox,
        /// aplicando un criterio de verificacion correspondiente al criterio interno de la calculadora.
        /// </summary>
        /// <param name="numero1">Primer operando</param>
        /// <param name="numero2">Segundo operando</param>
        /// <param name="operador">Operador a ejecutar</param>
        /// <returns></returns>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();

            string[] operadores = { "+", "-", "*", "/" };
            cmbOperador.Text = operadores.Contains(cmbOperador.Text) ? cmbOperador.Text : this.cmbOperador.Items[0].ToString();

            if (!(txtNumero1.Text.All(char.IsDigit)) || string.IsNullOrEmpty(txtNumero1.Text)) txtNumero1.Text = "0";
            if (!(txtNumero2.Text.All(char.IsDigit)) || string.IsNullOrEmpty(txtNumero2.Text)) txtNumero2.Text = "0";

        }

        /// <summary>
        /// Este método reinicia los valores de la calculadora, dejándolos vacíos. 
        /// Solo aplica para textbox, combobox y labels.
        /// </summary>
        private void Limpiar()
        {
            this.lblResultado.Text = string.Empty;
            this.txtNumero1.Text = string.Empty;
            this.txtNumero2.Text = string.Empty;
            this.cmbOperador.Text = this.cmbOperador.Items[4].ToString();
        }

        /// <summary>
        /// Este método realiza una operación dependiendo de los operandos y el operador seleccionado.
        /// </summary>
        /// <param name="numero1">Primer operando</param>
        /// <param name="numero2">Segundo operando</param>
        /// <param name="operador">Operador a ejecutar</param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            return Calculadora.Operar(new Numero(numero1), new Numero(numero2), operador);
        }

    }
}
