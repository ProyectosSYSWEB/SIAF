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
                    objPartidas.Ejercicio = Convert.ToString(dr.GetValue(4));
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

        public void ObtenerDatosPartida(ref Partidas objPartidas, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = { "P_ID", "P_EJERCICIO" };
                object[] Valores = { objPartidas.Id, objPartidas.Ejercicio };
                string[] ParametrosOut = { "P_CLAVE", "P_CONCEPTO", "P_DESCRIPCION", "P_BANDERA" };

                Cmd = CDDatos.GenerarOracleCommand("OBT_SAF_PRESUP_PARTIDAS", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    objPartidas = new Partidas();
                    objPartidas.Id = Convert.ToString(Cmd.Parameters["P_ID"].Value);
                    objPartidas.Clave = Convert.ToString(Cmd.Parameters["P_CLAVE"].Value);
                    objPartidas.Concepto = Convert.ToString(Cmd.Parameters["P_CONCEPTO"].Value);
                    objPartidas.Descrip = Convert.ToString(Cmd.Parameters["P_DESCRIPCION"].Value);
                    objPartidas.Ejercicio = Convert.ToString(Cmd.Parameters["P_EJERCICIO"].Value);                    
                }
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
        public void EditarPartida(ref Partidas objPartidas, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_PARTIDA", "P_CONCEPTO", "P_DESCRIPCION", "P_EJERCICIO", "P_ID" };
                object[] Valores = { objPartidas.Clave, objPartidas.Concepto, objPartidas.Descrip, objPartidas.Ejercicio, objPartidas.Id };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_PRESUP_PARTIDAS", ref Verificador, Parametros, Valores, ParametrosOut);

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
