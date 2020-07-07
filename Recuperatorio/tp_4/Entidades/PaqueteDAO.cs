using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        /// <summary>
        /// Inserta un paquete en la base de datos.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Insertar(Paquete p)
        {
            bool resultado = false;

            try
            {
                conexion.Open();
                comando.Parameters.Clear();
                comando.Connection = PaqueteDAO.conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "insert into Paquetes values (@direccionEntrega, @trackingID, @alumno)";

                comando.Parameters.Clear();

                comando.Parameters.Add(new SqlParameter("direccionEntrega", p.DireccionEntrega));
                comando.Parameters.Add(new SqlParameter("trackingID", p.TrackingID));
                comando.Parameters.Add(new SqlParameter("alumno", "Ruhl Paula"));

                bool.TryParse(comando.ExecuteNonQuery().ToString(), out resultado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }

        /// <summary>
        /// Constructor estático, instancia el atributo conexión y el comando a utilizar.
        /// </summary>
        static PaqueteDAO() 
        {
            conexion = new SqlConnection("Data Source = .; Database = correo-sp-2017; Trusted_Connection=True;");
            comando = new SqlCommand();
        }
    }
}
