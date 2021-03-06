﻿using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class CD_Capitulos
    {
        public void CapitulosGrid(ref Basicos objBasicos, ref List<Basicos> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "p_tipo", "p_valor" };
                String[] Valores = { objBasicos.tipo, objBasicos.valor };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PRESUPUESTO.Obt_Grid_Capitulos", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objBasicos = new Basicos();
                    objBasicos.clave = Convert.ToString(dr.GetValue(0));
                    objBasicos.descripcion = Convert.ToString(dr.GetValue(1));
                    objBasicos.valor = Convert.ToString(dr.GetValue(2));
                    objBasicos.tipo = Convert.ToString(dr.GetValue(3));
                    objBasicos.status = Convert.ToString(dr.GetValue(4));                    
                    objBasicos.id = Convert.ToString(dr.GetValue(5));
                    List.Add(objBasicos);
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
        public void InsertarCapitulo(ref Basicos objBasicos, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_TIPO", "P_CLAVE", "P_STATUS", "P_DESCRIPCION", "P_VALOR", "P_ORDEN" };
                object[] Valores = { objBasicos.tipo, objBasicos.clave, objBasicos.status, objBasicos.descripcion, objBasicos.valor, objBasicos.orden };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("INS_SAF_Basicos", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void ObtenerDatosCapitulo(ref Basicos objBasicos, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = { "P_ID"};
                object[] Valores = { objBasicos.id};
                string[] ParametrosOut = { "P_CLAVE", "P_DESCRIPCION", "P_BANDERA" };

                Cmd = CDDatos.GenerarOracleCommand("OBT_SAF_BASICOS_CAP", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    objBasicos = new Basicos();
                    objBasicos.id = Convert.ToString(Cmd.Parameters["P_ID"].Value);
                    objBasicos.clave = Convert.ToString(Cmd.Parameters["P_CLAVE"].Value);
                    objBasicos.descripcion = Convert.ToString(Cmd.Parameters["P_DESCRIPCION"].Value);                    
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
        public void EditarCapitulo(ref Basicos objBasicos, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_CLAVE", "P_DESCRIPCION", "P_ID" };
                object[] Valores = { objBasicos.clave, objBasicos.descripcion, objBasicos.id };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_BASICOS_CAP", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void EliminarCapitulo(Basicos objBasicos, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID"};
                object[] Valores = { objBasicos.id };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("", ref Verificador, Parametros, Valores, ParametrosOut);

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
