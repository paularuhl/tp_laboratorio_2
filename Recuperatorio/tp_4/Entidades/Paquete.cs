using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region Atributos
        /// <summary>
        /// Dirección de entrega del paquete
        /// </summary>
        private string direccionEntrega;
        /// <summary>
        /// Estado actual del paquete
        /// </summary>
        private EEstado estado;
        /// <summary>
        /// ID de trackeo del paquete
        /// </summary>
        private string trackingID;
        #endregion

        #region Delegados y Eventos
        /// <summary>
        /// Delegado que manejará metodos que informan los cambios de estado del paquete.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoEstado(object sender, EventArgs e);
        /// <summary>
        /// Delegado que manejará metodos que informan excepciones.
        /// </summary>
        /// <param name="e"></param>
        public delegate void DelegadoException(Exception e);

        /// <summary>
        /// Evento encargado de informar cambios de estado del paquete
        /// </summary>
        public event DelegadoEstado InformaEstado;
        /// <summary>
        /// Evento encargado de informar excepciones del paquete
        /// </summary>
        public event DelegadoException InformaException;

        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad que asigna y retorna la dirección de entrega del paquete
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }
        /// <summary>
        /// Propiedad que asigna y retorna el Estado actual del paquete
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }
        /// <summary>
        /// Propiedad que asigna y retorna el ID de trackeo del paquete
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor publico parametrizado que asigna id de trackeo y dirección de entrega al nuevo paquete.
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.TrackingID = trackingID;
            this.DireccionEntrega = direccionEntrega;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Método que simula el ciclo de vida del viaje del paquete.
        /// </summary>
        public void MockCicloDeVida()
        {
            // d.Repetir las acciones desde el punto A hasta que el estado sea Entregado.
            while (this.Estado != EEstado.Entregado)
            {
                // a.Colocar una demora de 4 segundos.
                Thread.Sleep(4000);
                // b.Pasar al siguiente estado. --
                this.Estado += 1;
                // c.Informar el estado a través de InformarEstado. EventArgs no tendrá ningún dato extra.
                this.InformaEstado(this.Estado, new EventArgs());
            }

            try
            {
                // e.Finalmente guardar los datos del paquete en la base de datos
                PaqueteDAO.Insertar(this);
            }
            catch (Exception ex)
            {
                //informa via evento una excepción al guardar el paquete en base de datos.
                this.InformaException(ex);
            }
        }

        /// <summary>
        /// Muestra los datos del parámetro "elemento" IMostrar de tipo paquete.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete paquete = (Paquete)elemento; //pq queremos los atributos de paquete
            return string.Format("{0} para {1}", this.TrackingID, this.DireccionEntrega);
        }

        /// <summary>
        /// Retorna el correo en tipo string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this); //doble chequear
        } 
        #endregion

        #region Operadores
        /// <summary>
        /// Dos paquetes son iguales si el Tracking ID de los mismos es igual.
        /// </summary>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            if(p1 is null || p2 is null)
            {
                return false;
            }
            return p1.TrackingID == p2.TrackingID;
        }
        /// <summary>
        /// Dos paquetes son distintos si el Tracking ID de los mismos no es igual.
        /// </summary>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion

        #region NestedTypes
        /// <summary>
        /// Enumerado con los posibles estados del envío
        /// </summary>
        public enum EEstado
        {
            Ingresado, EnViaje, Entregado
        } 
        #endregion
    }
}
