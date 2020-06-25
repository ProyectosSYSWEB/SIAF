using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using CapaEntidad;
using System.Web.UI.WebControls;
using System.IO;
#region Hecho por
//Nombre:      Lisseth Gtz. Gómez
//Correo:      lis_go82@hotmail.com
//Institución: Unach
#endregion

namespace CapaDatos
{
    public class CD_Pres_Documento_Det
    {
        public void DocumentoDetInsertar(List<Pres_Documento_Detalle> DDet, Int32 IdDoc, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                CDDatos.StartTrans();
                for (int i = 0; i < DDet.Count; i++)
                {
                    String[] Parametros = { "P_ID_DOCUMENTO", "P_ID_CODIGO_PROGRAMATICO", "P_CONSECUTIVO", "P_UR_CLAVE", "P_TIPO", "P_IMPORTE_ORIGEN", "P_IMPORTE_DESTINO", "P_IMPORTE_MENSUAL", "P_MES_INICIAL", "P_MES_FINAL", "P_CUENTA_BANCO", "P_CONCEPTO", "P_REFERENCIA", "P_BENEFICIARIO_TIPO", "P_BENEFICIARIO_NOMBRE", "P_BENEFICIARIO_CLAVE" };
                    object[] Valores = { IdDoc, DDet[i].Id_Codigo_Prog, i + 1, DDet[i].Ur_clave, DDet[i].Tipo, DDet[i].Importe_origen, DDet[i].Importe_destino, DDet[i].Importe_mensual, DDet[i].Mes_inicial, DDet[i].Mes_final, DDet[i].Cuenta_banco, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty  };
                    String[] ParametrosOut = { "P_BANDERA" };
                    Cmd = CDDatos.GenerarOracleCommand("INS_SAF_PRESUP_DOCUMENTOS_DET", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void ObtDisponibleCodigoProg(Pres_Documento_Detalle objDocDet, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                CDDatos.StartTrans();
                String[] Parametros = { "P_ID_CODIGO_PROG" };
                object[] Valores = { objDocDet.Id_Codigo_Prog };
                String[] ParametrosOut = { "P_DISPONIBLE", "P_BANDERA" };
                Cmd = CDDatos.GenerarOracleCommand("OBT_DISPONIBLE_CODIGO_PROG", ref Verificador, Parametros, Valores, ParametrosOut);
                objDocDet.Importe_disponible = Convert.ToDouble(Cmd.Parameters["P_DISPONIBLE"].Value);

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
        public void DocumentoDetConsultaGrid(ref Pres_Documento_Detalle objDocDet, ref List<Pres_Documento_Detalle> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;


                string[] Parametros = { "P_ID_DOCUMENTO" };
                object[] Valores = { objDocDet.Id_Documento };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PRESUPUESTO.Obt_Grid_Documentos_Detalle", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    objDocDet = new Pres_Documento_Detalle();
                    objDocDet.Tipo = Convert.ToString(dr.GetValue(3));
                    objDocDet.Ur_clave = Convert.ToString(dr.GetValue(2));
                    objDocDet.Id_Codigo_Prog = Convert.ToInt32(dr.GetValue(0));
                    objDocDet.Desc_Codigo_Prog = Convert.ToString(dr.GetValue(15));
                    objDocDet.Cuenta_banco = Convert.ToString(dr.GetValue(9));
                    objDocDet.Mes_inicial = Convert.ToInt32(dr.GetValue(7));
                    objDocDet.Mes_final = Convert.ToInt32(dr.GetValue(8));
                    objDocDet.Importe_origen = Convert.ToDouble(dr.GetValue(4));
                    objDocDet.Importe_destino = Convert.ToDouble(dr.GetValue(5));
                    objDocDet.Importe_mensual = Convert.ToDouble(dr.GetValue(6));
                    objDocDet.Desc_Partida = Convert.ToString(dr.GetValue(16));
                    List.Add(objDocDet);
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
