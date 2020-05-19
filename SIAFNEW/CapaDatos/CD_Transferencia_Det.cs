using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Transferencia_Det
    {
        public void TransferenciaDetInsertar(List<Transferencia_Detalle> TDet, Int32 IdTransferencia, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                CDDatos.StartTrans();
                for (int i = 0; i < TDet.Count; i++)
                {
                    String[] Parametros = { "P_ID_TRANSFERENCIA","P_ORIGEN_ID_PAT_INVENT" };
                    object[] Valores = { IdTransferencia,TDet[i].IdInventario};
                    String[] ParametrosOut = { "p_Bandera" };
                    Cmd = CDDatos.GenerarOracleCommand("INS_SAF_PAT_TRANSFERENCIAS_DET", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void TransferenciaDetConsultaGrid(ref Transferencia_Detalle ObjTransferenciaDet, ref List<Transferencia_Detalle> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;


                string[] Parametros = { "P_ID_TRANSFERENCIA" };
                object[] Valores = { ObjTransferenciaDet.IdTransferencia };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_patrimonio.Obt_Grid_Patrimonio_Transf_Det", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjTransferenciaDet = new Transferencia_Detalle();
                    //ObjTransferenciaDet.poliza_origen.IdPoliza = Convert.ToInt32(dr.GetValue(0));
                    //ObjTransferenciaDet.poliza_origen.Concepto = Convert.ToString(dr.GetValue(1));
                    //ObjTransferenciaDet.poliza_origen.IdCuenta_Contable = Convert.ToInt32(dr.GetValue(4));
                    //ObjTransferenciaDet.poliza_origen.DescCuenta_Contable = Convert.ToString(dr.GetValue(5));
                    ObjTransferenciaDet.IdInventario = Convert.ToInt32(dr.GetValue(0));
                    ObjTransferenciaDet.Inventario_Numero = Convert.ToString(dr.GetValue(1));
                    ObjTransferenciaDet.bien_det.Cantidad = Convert.ToInt32(dr.GetValue(2));
                    ObjTransferenciaDet.bien_det.Marca = Convert.ToString(dr.GetValue(3));
                    ObjTransferenciaDet.bien_det.Modelo = Convert.ToString(dr.GetValue(4));
                    ObjTransferenciaDet.bien_det.No_Serie = Convert.ToString(dr.GetValue(5));
                    ObjTransferenciaDet.bien_det.Costo = Convert.ToDouble(dr.GetValue(6));
                    List.Add(ObjTransferenciaDet);
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
