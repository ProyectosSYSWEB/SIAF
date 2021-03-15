﻿using CapaEntidad;
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
                String[] Valores = { objAdecuacion.Partida, objAdecuacion.Fuente, Convert.ToString(objAdecuacion.MesIni), Convert.ToString(objAdecuacion.MesFin)};

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PRESUPUESTO.Obt_Grid_Adecuaciones", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objAdecuacion = new Adecuaciones();
                    objAdecuacion.Mes = Convert.ToString(dr.GetValue(0));
                    objAdecuacion.TipoOperacion = Convert.ToString(dr.GetValue(1));
                    objAdecuacion.Centro_Contab = Convert.ToString(dr.GetValue(2));
                    objAdecuacion.Codigo_Programatico = Convert.ToString(dr.GetValue(3));
                    objAdecuacion.Destino = Convert.ToString(dr.GetValue(4));
                    objAdecuacion.Origen = Convert.ToString(dr.GetValue(5));
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


        public void ObtenerDatosCogidoAdecuaciones(ref Adecuaciones objAdecuaciones, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = {"P_CODIGO"};
                object[] Valores = { objAdecuaciones.Codigo_Programatico };
                string[] ParametrosOut = {"P_MES","P_TIPO_OPE","P_C_CONTAB", "P_ORIGEN", "p_bandera"};

                Cmd = CDDatos.GenerarOracleCommand("OBT_COD_PROG_ADECUACIONES", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    objAdecuaciones = new Adecuaciones();
                    objAdecuaciones.Mes = Convert.ToString(Cmd.Parameters["P_MES"].Value);
                    objAdecuaciones.TipoOperacion = Convert.ToString(Cmd.Parameters["P_TIPO_OPE"].Value);
                    objAdecuaciones.Centro_Contab = Convert.ToString(Cmd.Parameters["P_C_CONTAB"].Value);
                    objAdecuaciones.Origen = Convert.ToString(Cmd.Parameters["P_ORIGEN"].Value);
                    objAdecuaciones.Codigo_Programatico = Convert.ToString(Cmd.Parameters["P_CODIGO"].Value);
                    objAdecuaciones.Destino = "0";
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
    }
}