using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class CD_PresupUnv
    {

        public void ObtenerDatosCodProg(ref PresupUnv objPresupUnv, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = { "P_CODIGO_PROG" };
                object[] Valores = { objPresupUnv.Codigo_Programatico };
                string[] ParametrosOut = { "P_CENTRO_CONTABLE", "P_DEPENDENCIA", "P_PROGRAMA", "P_SUBPROGRAMA", "P_PARTIDA", "P_FUENTE", "P_PROYECTO", "P_TIPO_GASTO", "P_DIG_MINISTRADO" , "P_FUNCION", "p_bandera" };

                Cmd = CDDatos.GenerarOracleCommand("OBT_DESC_CTX_DP01", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    objPresupUnv = new PresupUnv();
                    objPresupUnv.Centro_Contable = Convert.ToString(Cmd.Parameters["P_CENTRO_CONTABLE"].Value);
                    objPresupUnv.Dependencia = Convert.ToString(Cmd.Parameters["P_DEPENDENCIA"].Value);
                    objPresupUnv.Programa = Convert.ToString(Cmd.Parameters["P_PROGRAMA"].Value);
                    objPresupUnv.Subprograma = Convert.ToString(Cmd.Parameters["P_SUBPROGRAMA"].Value);
                    objPresupUnv.Partida = Convert.ToString(Cmd.Parameters["P_PARTIDA"].Value);
                    objPresupUnv.Fuente = Convert.ToString(Cmd.Parameters["P_FUENTE"].Value);
                    objPresupUnv.Proyecto = Convert.ToString(Cmd.Parameters["P_PROYECTO"].Value);
                    objPresupUnv.Tipo_Gasto = Convert.ToString(Cmd.Parameters["P_TIPO_GASTO"].Value);
                    objPresupUnv.Dig_Ministrado = Convert.ToString(Cmd.Parameters["P_DIG_MINISTRADO"].Value);
                    objPresupUnv.Funcion = Convert.ToString(Cmd.Parameters["P_FUNCION"].Value);                    
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


        public void PresUnvGrid(ref PresupUnv objPresUnv, ref List<PresupUnv> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { };
                String[] Valores = {  };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PRESUPUESTO.Obt_Grid_Reg_Presup", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objPresUnv = new PresupUnv();
                    objPresUnv.Id = Convert.ToInt32(dr.GetValue(0));
                    objPresUnv.Tipo_Gasto = Convert.ToString(dr.GetValue(1));
                    objPresUnv.Dependencia = Convert.ToString(dr.GetValue(2));
                    objPresUnv.Referencia_Documento = Convert.ToString(dr.GetValue(3));
                    objPresUnv.Concepto = Convert.ToString(dr.GetValue(4));
                    objPresUnv.Codigo_Programatico = Convert.ToString(dr.GetValue(5));
                    List.Add(objPresUnv);
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
