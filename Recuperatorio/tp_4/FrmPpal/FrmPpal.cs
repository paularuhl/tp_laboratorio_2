using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmPpal
{
    public partial class FrmPpal : Form
    {
        /// <summary>
        /// Correo ♥
        /// </summary>
        Correo correo;

        public FrmPpal()
        {
            this.correo = new Correo();
            InitializeComponent();
        }

        /// <summary>
        /// Agrega un paquete al correo, asignando los eventos y manejadores correspondientes.
        /// De haber una excepción al hacerlo, lo informará por un messagebox.
        /// 
        /// (C) En la parte inferior derecha ingresaremos paquetes al sistema al cargar los datos 
        /// y hacer click en el botón Agregar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete p = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
            p.InformaEstado += this.paq_InformaEstado;
            p.InformaException += this.paq_InformaException;

            try
            {
                this.correo += p;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Paquete Repetido", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }

            this.ActualizarEstados();
        }

        /// <summary>
        /// Muestra la lista de paquetes completa via el botón correspondiente.
        /// 
        /// (D) Al hacer click en el botón Mostrar Todos, se mostrará la información en el cuadro de texto sito en la
        /// parte inferior izquierda y se guardará esa información en un archivo de texto en el 
        /// escritorio de la máquina.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Al cerrar el form, finaliza todas las entregas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        /// <summary>
        /// Muestra el paquete entregado seleccionado via un menu de contexto.
        ///
        /// (B) Al seleccionar un elemento de la lista de "Entregado" y hacer click con el botón derecho del mouse,
        /// veremos un menú Mostrar.Al hacer click en este, se deberá mostrar la información del paquete en el
        /// cuadro de texto situado en la parte inferior izquierda.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        /// <summary>
        /// Ante cambios de estado de paquetes, actualiza la lista de estados del form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        /// <summary>
        /// Actualizan la lista de estados 
        /// 
        /// (A) En la parte superior veremos los paquetes Ingresados y como cambiar su estado a En Viaje y luego
        /// Finalizados. Al alcanzar ese último estado, guardaremos la información del paquete en una base de
        /// datos provista para tal fin.
        /// </summary>
        private void ActualizarEstados()
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();

            foreach (Paquete paq in this.correo.Paquetes)
            {
                switch (paq.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(paq);
                        break;
                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(paq);
                        break;
                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(paq);
                        break;
                }
            }
        }

        /// <summary>
        /// Muestra los datos de un elemento que implementa IMostrar,
        /// luego guarda sus datos en un archivo de texto en el escritorio.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                rtbMostrar.Text = elemento.MostrarDatos(elemento);
                rtbMostrar.Text.Guardar("salida.txt");
            }
        
        }

        /// <summary>
        /// Muestra un mensaje de error relacionado con la base de datos.
        /// </summary>
        /// <param name="e"></param>
        private void paq_InformaException(Exception e)
        {
            MessageBox.Show(e.Message, "Error al cargar paquete a la base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
