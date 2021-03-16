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
                String[] Parametros = {"p_capitulo", "P_EJERCICIO" };
                String[] Valores = { objPartidas.SubCapt, objPartidas.Ejercicio };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PRESUPUESTO.Obt_Grid_Cat_Partida", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objPartidas = new Partidas();
                    objPartidas.Partida = Convert.ToString(dr.GetValue(0));
                    objPartidas.Concepto = Convert.ToString(dr.GetValue(1));
                    objPartidas.Descrip = Convert.ToString(dr.GetValue(2));
                    objPartidas.Id = Convert.ToString(dr.GetValue(3));
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



        public void InsertarPartida(ref Partidas objPartidas, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_PARTIDA", "P_ESTATUS", "P_DESCRIP" };
                object[] Valores = { objPartidas.Partida, objPartidas.Estatus, objPartidas.Descrip };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("INS_CAT_PARTIDA", ref Verificador, Parametros, Valores, ParametrosOut);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmd);
            }
        }
    }
}
