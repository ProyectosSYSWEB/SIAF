using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using CapaEntidad;
namespace CapaDatos
{
    public class CD_Centros_Contables
    {
        public void Control_CierreConsultaGrid(ref Centros_Contables ObjControl_Cierre, ref List<Centros_Contables> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                string[] Parametros = { "p_ejercicio", "p_sistema" };
                object[] Valores = { ObjControl_Cierre.Ejercicio, ObjControl_Cierre.sistema };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_contabilidad.Obt_Grid_Control_Cierre", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjControl_Cierre = new Centros_Contables();
                    ObjControl_Cierre.Id_Control_Cierre = Convert.ToInt32(dr.GetValue(0));
                    ObjControl_Cierre.Centro_Contable = Convert.ToString(dr.GetValue(1));
                    ObjControl_Cierre.Mes_anio = Convert.ToString(dr.GetValue(2));
                    ObjControl_Cierre.Cierre_Definitivo = Convert.ToString(dr.GetValue(8));
                    //ObjControl_Cierre.Status = "../../images/" + Convert.ToString(dr.GetValue(5)) + ".PNG";
                    List.Add(ObjControl_Cierre);
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
        public void Control_CierreEditar(ref Centros_Contables ObjCentros_Contables, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                string[] ParametrosIn = { "P_ID_CONTROL_CIERRE", "P_MES_ANIO", "P_CIERRE_DEFINITIVO" };
                object[] Valores = { ObjCentros_Contables.Id_Control_Cierre, ObjCentros_Contables.Mes_anio, ObjCentros_Contables.Cierre_Definitivo};
                string[] ParametrosOut ={                                        
                                          "p_Bandera"
                };

                OracleCommand Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_CONTROL_CIERRE", ref Verificador, ParametrosIn, Valores, ParametrosOut);

                CDDatos.LimpiarOracleCommand(ref Cmd);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Control_CierreGral(ref Centros_Contables ObjControl_Cierre, string Tipo, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                string[] ParametrosIn = { "P_MES_ANIO", "P_SISTEMA", "P_EJERCICIO", "P_TIPO" };
                object[] Valores = { ObjControl_Cierre.Mes_anio, "CONTABILIDAD", ObjControl_Cierre.Ejercicio, Tipo };
                string[] ParametrosOut ={
                                          "p_Bandera"
                };

                OracleCommand Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_CONTROL_CIERRE_GRAL", ref Verificador, ParametrosIn, Valores, ParametrosOut);

                CDDatos.LimpiarOracleCommand(ref Cmd);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
