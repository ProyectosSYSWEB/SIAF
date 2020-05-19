using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class CD_Ministracion
    {
        public void EliminarPagadoCaja(ref string salida)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                Cmd = CDDatos.GenerarOracleCommand("DEL_PAGADAS_CAJA", ref salida);
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
        public void InsertarArchivoCaja(List<Ministracion> lstMinistracion, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                CDDatos.StartTrans();
                string Error = string.Empty;
                for (int i = 0; i < lstMinistracion.Count; i++)
                {
                    if (lstMinistracion[i].Ejercicio != null && lstMinistracion[i].Centro_Contable != null && lstMinistracion[i].Descripcion != null)
                    {
                        String[] Parametros = { "P_EJERCICIO", "P_MES", "P_CENTRO_CONTABLE", "P_DESCRIPCION", "P_BANCO", "P_CUENTA", "P_SUBTOTAL", "P_VIGILANCIA",
                        "P_LIMPIEZA", "P_ANTICIPO", "P_TOTAL", "P_ENERGIA_ELECTRICA", "P_TELEFONO", "P_TOTAL_FEDERAL", "P_TOTAL_ESTATAL", "P_SUMA_DESC_SERV", "P_MONTO_A_TRASFERIR" };
                        object[] Valores = { lstMinistracion[i].Ejercicio, lstMinistracion[i].Mes, lstMinistracion[i].Centro_Contable, lstMinistracion[i].Descripcion, lstMinistracion[i].Banco, lstMinistracion[i].Cuenta, lstMinistracion[i].SubTotal, lstMinistracion[i].Vigilancia,
                    lstMinistracion[i].Limpieza, lstMinistracion[i].Anticipo, lstMinistracion[i].Total, lstMinistracion[i].Energia_Electrica, lstMinistracion[i].Telefono, 
                            lstMinistracion[i].TotalFederal, lstMinistracion[i].TotalEstatal, lstMinistracion[i].Suma_Desc_Serv, lstMinistracion[i].Monto_Transferir
                    };
                        String[] ParametrosOut = { "p_Bandera" };

                        
                        
                        
                        Cmd = CDDatos.GenerarOracleCommand("INS_MIN_GC", ref Verificador, Parametros, Valores, ParametrosOut);
                        Error = Error + Verificador;
                    }
                }
                Verificador = Error;


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
        public void EliminarArchivoCaja(List<Ministracion> lstMinistracion, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                CDDatos.StartTrans();
                string Error = string.Empty;
              
                        String[] Parametros = { "P_EJERCICIO", "P_MES" };
                        object[] Valores = { lstMinistracion[1].Ejercicio, lstMinistracion[1].Mes };
                        String[] ParametrosOut = { "p_Bandera" };

                        Cmd = CDDatos.GenerarOracleCommand("DEL_SAF_MINISTRACIONES_GC", ref Verificador, Parametros, Valores, ParametrosOut);
                        Error = Error + Verificador;
              
                Verificador = Error;


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
        public void MinistracionConsultaGrid(Ministracion ObjMinistracion, ref List<Ministracion> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                cmm = CDDatos.GenerarOracleCommandCursor("pkg_contabilidad.Obt_Grid_Mes_Ministracion", ref dr);

                while (dr.Read())
                {
                    ObjMinistracion = new Ministracion();
                    ObjMinistracion.Ejercicio = Convert.ToString(dr.GetValue(0));
                    ObjMinistracion.Mes = Convert.ToString(dr.GetValue(1));
                    ObjMinistracion.Total = Convert.ToString(dr.GetValue(2));
                    List.Add(ObjMinistracion);
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
