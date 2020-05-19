using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using CapaEntidad;

namespace CapaDatos
{
    public  class CD_Informativa
    {
        public void Consultar_Observaciones(ref cuentas_contables Objinformativa, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = { "p_ejercicio", "p_usuario" };
                object[] Valores = { Objinformativa.ejercicio, Objinformativa.usuario };
                string[] ParametrosOut = { "p_observaciones", "p_bandera" };

                Cmd = CDDatos.GenerarOracleCommand("SEL_SAF_INFO_OBSERVACIONES", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    Objinformativa = new cuentas_contables();
                    Objinformativa.observaciones = Convert.ToString(Cmd.Parameters["p_observaciones"].Value);

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
        public void Consultar_Observaciones_edit(ref cuentas_contables Objinformativa, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = { "p_id" };
                object[] Valores = { Objinformativa.id  };
                string[] ParametrosOut = { "p_centro_contable", "p_observaciones", "p_fecha_inicial", "p_fecha_final", "p_status", "p_bandera" };

                Cmd = CDDatos.GenerarOracleCommand("SEL_SAF_EDIT_informativa", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    Objinformativa = new cuentas_contables();
                    Objinformativa.id = Convert.ToString(Cmd.Parameters["p_id"].Value);
                    Objinformativa.centro_contable  = Convert.ToString(Cmd.Parameters["p_centro_contable"].Value);
                    Objinformativa.observaciones = Convert.ToString(Cmd.Parameters["p_observaciones"].Value);
                    Objinformativa.fecha_inicial = Convert.ToString(Cmd.Parameters["p_fecha_inicial"].Value);
                    Objinformativa.fecha_final = Convert.ToString(Cmd.Parameters["p_fecha_final"].Value);
                    Objinformativa.status  = Convert.ToString(Cmd.Parameters["p_status"].Value);

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


        public void Delete_Observaciones_edit(ref cuentas_contables Objinformativa, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = { "p_id" };
                object[] Valores = { Objinformativa.id };
                string[] ParametrosOut = { "p_bandera" };

                Cmd = CDDatos.GenerarOracleCommand("DEL_SAF_INFORMATIVA", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {             

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



        public void ConsultarInformativa(ref cuentas_contables Objinformativa, string buscar, ref List<cuentas_contables> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
                String[] Parametros = { "p_centro_contable", "p_buscar" };
                Object[] Valores = {  Objinformativa.centro_contable , buscar };
               
                cmm = CDDatos.GenerarOracleCommandCursor("pkg_contabilidad.obt_grid_Informativa", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    Objinformativa = new cuentas_contables();
                    Objinformativa.id = Convert.ToString(dr[0]);
                    Objinformativa.centro_contable  = Convert.ToString(dr[1]);
                    Objinformativa.observaciones   = Convert.ToString(dr[2]);
                    Objinformativa.status  = Convert.ToString(dr[3]);
                    Objinformativa.fecha_inicial  = Convert.ToString(dr[4]);
                    Objinformativa.fecha_final  = Convert.ToString(dr[5]);
                    List.Add(Objinformativa );

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
        public void insertar_observaciones(ref cuentas_contables objinformativa, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_CENTRO_CONTABLE", "P_DESCRIPCION", "P_FECHA_INICIAL", "P_FECHA_FINAL", "P_STATUS" };
                object[] Valores = { objinformativa.centro_contable, objinformativa .descripcion, objinformativa .fecha_inicial , objinformativa.fecha_final, objinformativa.status  };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("INS_SAF_INFORMATIVA", ref Verificador, Parametros, Valores, ParametrosOut);

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

        public void update_observaciones(ref cuentas_contables objinformativa, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "p_id", "P_CENTRO_CONTABLE", "P_DESCRIPCION", "P_FECHA_INICIAL", "P_FECHA_FINAL", "P_STATUS" };
                object[] Valores = { objinformativa.id  ,objinformativa.centro_contable, objinformativa.descripcion, objinformativa.fecha_inicial, objinformativa.fecha_final, objinformativa.status };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_INFORMATIVA", ref Verificador, Parametros, Valores, ParametrosOut);

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
