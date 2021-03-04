using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class CD_Cat_Ctrl_Presp_Saf
    {
        public void ObtenerDatosCodProg(string Id, ref Cat_Ctrl_Presp_Saf objPresupUnv, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmd = null;
            try
            {
                string[] ParametrosIn = { "P_ID" };
                object[] Valores = { Id };
                string[] ParametrosOut = { "P_CENTRO_CONTABLE", "P_PROGRAMA", "P_SUBPROGRAMA", "P_DEPENDENCIA", "P_PROYECTO", "P_STATUS", "P_BANDERA" };

                cmd = CDDatos.GenerarOracleCommand("OBT_DESC_CAT_ESTRUCT", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    objPresupUnv = new Cat_Ctrl_Presp_Saf();
                    objPresupUnv.Centro_Contable = Convert.ToString(cmd.Parameters["P_CENTRO_CONTABLE"].Value);
                    objPresupUnv.Programa = Convert.ToString(cmd.Parameters["P_PROGRAMA"].Value);
                    objPresupUnv.SubPrograma = Convert.ToString(cmd.Parameters["P_SUBPROGRAMA"].Value);
                    objPresupUnv.Dependencia = Convert.ToString(cmd.Parameters["P_DEPENDENCIA"].Value);
                    objPresupUnv.Proyecto = Convert.ToString(cmd.Parameters["P_PROYECTO"].Value);                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref cmd);
            }
        }


        public void InsertarCodigoProg(ref Cat_Ctrl_Presp_Saf objCodProg, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_FUNCION_PROGRAMA", "P_SUBPROGRAMA", "P_DEPENDENCIA", "P_PROYECTO", "P_PARTIDA", "P_FUENTE", "P_TIPO_GASTO", "P_DIG_MINIST", "P_EJERCICIO" };
                object[] Valores = { objCodProg.Funcion, objCodProg.SubPrograma, objCodProg.Dependencia, objCodProg.Proyecto, objCodProg.Partida, objCodProg.Fuente, objCodProg.TipoGasto, objCodProg.Dig_Ministrado, objCodProg.Ejercicio};
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




    }
}
