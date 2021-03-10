using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class CD_Adecuaciones
    {
        public void AdecuacionesGrid(Adecuaciones objAdecuacion, ref List<Adecuaciones> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "p_partida", "p_fuente", "p_mes_inicial", "p_mes_final" };
                String[] Valores = { objAdecuacion.Partida, objAdecuacion.Fuente, "", "" };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PRESUPUESTO.Obt_Grid_Adecuaciones", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objAdecuacion = new Adecuaciones();
                    objAdecuacion.Mes = Convert.ToString(dr.GetValue(0));
                    objAdecuacion.TipoOperacion = Convert.ToString(dr.GetValue(1));
                    objAdecuacion.Centro_Contab = Convert.ToString(dr.GetValue(2));
                    objAdecuacion.Codigo_Programatico = Convert.ToString(dr.GetValue(3));
                    objAdecuacion.Destino = Convert.ToString(dr.GetValue(4));
                    List.Add(objAdecuacion);
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
