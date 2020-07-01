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
        Correo correo;
        public FrmPpal()
        {
            this.correo = new Correo();
            InitializeComponent();
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete p = new Paquete(this.mtxtTrackingID.Text, this.txtDireccion.Text);
            p.InformaEstado += this.paq_InformaEstado;

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

        private void btnMostrar_Click(object sender, EventArgs e)
        {

        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

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

        private void ActualizarEstados()
        {

        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

    }
}
