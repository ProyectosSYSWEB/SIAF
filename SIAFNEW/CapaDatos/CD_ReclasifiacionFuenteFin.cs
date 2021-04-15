using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class CD_ReclasifiacionFuenteFin
    {
        public void CodigosReclasificacion(Consultas objConsultas, ref List<Consultas> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "p_partida", "p_fuente", "p_dependI", "p_dependF", "p_mesIni", "p_mesFin", "p_ejercicio" };
                String[] Valores = { objConsultas.Partida, objConsultas.Fuente, objConsultas.DependenciaIni, objConsultas.DependenciaFin, objConsultas.Mes_Inicial, objConsultas.Mes_Final,
                   objConsultas.Ejercicio };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PRESUPUESTO.Obt_Grid_ReclasifFuenteF", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objConsultas = new Consultas();
                    objConsultas.Codigo_Programatico = Convert.ToString(dr.GetValue(0));
                    objConsultas.EjercidoSuma = Convert.ToString(dr.GetValue(1));
                    objConsultas.Dependencia = Convert.ToString(dr.GetValue(2));
                    List.Add(objConsultas);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref cmm);
            }
        }
    }
}
