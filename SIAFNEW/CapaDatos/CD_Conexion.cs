using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;

namespace CapaEntidad
{
    public class Conexion
    {
        private OracleConnection cn { set; get; }
        public OracleConnection getConexion()
        {
            if (cn == null)
            {
                string conexion = System.Configuration.ConfigurationManager.AppSettings["CONEXION"].ToString();
                cn = new OracleConnection(conexion);
            }
            return cn;
        }
        public OracleConnection getConexion(string Esquema)
        {
            if (cn == null)
            {
                string conexion = System.Configuration.ConfigurationManager.AppSettings["CONEXION_INGRESOS"].ToString();
                cn = new OracleConnection(conexion);
            }
            return cn;
        }
    }
}
