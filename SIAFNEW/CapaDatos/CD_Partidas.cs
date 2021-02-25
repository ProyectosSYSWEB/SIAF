using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class CD_Partidas
    {
        public void PartidasGrid(ref Partidas objPartidas, ref List<Partidas> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { };
                String[] Valores = { };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PRESUPUESTO.Obt_Grid_Cat_Partida", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objPartidas = new Partidas();
                    objPartidas.Partida = Convert.ToString(dr.GetValue(0));
                    objPartidas.Descrip = Convert.ToString(dr.GetValue(1));                    
                    List.Add(objPartidas);
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
