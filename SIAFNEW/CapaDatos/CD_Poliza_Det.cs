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
    public class CD_Poliza_Det
    {
        public void PolizaDetConsultaGrid(ref Poliza_Detalle ObjPolizaDet, ref List<Poliza_Detalle> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;


                string[] Parametros = { "P_ID_POLIZA" };
                object[] Valores = { ObjPolizaDet.IdPoliza };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_contabilidad.Obt_Grid_Polizas_Detalle", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjPolizaDet = new Poliza_Detalle();
                    ObjPolizaDet.IdPoliza = Convert.ToInt32(dr.GetValue(1));
                    ObjPolizaDet.IdCuenta_Contable = Convert.ToInt32(dr.GetValue(2));
                    ObjPolizaDet.DescCuenta_Contable = Convert.ToString(dr.GetValue(6));
                    //ObjPolizaDet.Numero_poliza = Convert.ToString(dr.GetValue(3));
                    ObjPolizaDet.Cargo = Convert.ToDouble(dr.GetValue(4));
                    ObjPolizaDet.Abono = Convert.ToDouble(dr.GetValue(5));
                    ObjPolizaDet.Numero_Movimiento = Convert.ToInt32(dr.GetValue(3));
                    List.Add(ObjPolizaDet);
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
        public void PolizaDetInsertar(List<Poliza_Detalle> PDet, Int32 IdPoliza, /*GridView grv,*/ ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                CDDatos.StartTrans();
                for (int i = 0; i < PDet.Count; i++)
                {
                    String[] Parametros = { "P_ID_POLIZA", "P_ID_CUENTA_CONTABLE", "P_NUMERO_MOVIMIENTO", "P_CARGO", "P_ABONO" };
                    object[] Valores = { IdPoliza, PDet[i].IdCuenta_Contable, i+1,/*((Label)grv.Rows[i].FindControl("lblNumero_Movimiento_Aut")).Text,*/ PDet[i].Cargo, PDet[i].Abono };
                    String[] ParametrosOut = { "p_Bandera"};                    
                    Cmd = CDDatos.GenerarOracleCommand("INS_SAF_POLIZAS_DETALLE", ref Verificador, Parametros, Valores, ParametrosOut);
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

        public void PolizaDetInsertar_GC(Poliza objPoliza, int idCtaCont, int Ejercicio, int Mes, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                CDDatos.StartTrans();
                String[] Parametros = { "P_ID_POLIZA", "P_ID_CUENTA_CONT"   , "P_EJERCICIO", "P_MES" };
                object[] Valores = { objPoliza.IdPoliza, idCtaCont, Ejercicio, Mes };
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("INS_SAF_POLIZAS_DETALLE_GC", ref Verificador, Parametros, Valores, ParametrosOut);
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
