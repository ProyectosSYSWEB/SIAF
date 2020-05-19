using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Transferencia
    {
        public void TransferenciaConsultaGrid(ref Transferencia ObjTransferencia, String FechaInicial, String FechaFinal, String Buscar, ref List<Transferencia> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "P_Dependencia_Origen", "P_Destino_Dependencia", "P_Fecha_Inicial", "P_Fecha_Final", "P_Status", "P_Busca" };
                String[] Valores = { ObjTransferencia.Origen_Dependencia, ObjTransferencia.Destino_Dependencia, FechaInicial, FechaFinal, ObjTransferencia.Status, Buscar };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_patrimonio.Obt_Grid_Patrimonio_Transf", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    ObjTransferencia = new Transferencia();
                    ObjTransferencia.IdTransferencia = Convert.ToInt32(dr.GetValue(0));
                    ObjTransferencia.Folio = Convert.ToString(dr.GetValue(1));
                    ObjTransferencia.Fecha_Transferencia = Convert.ToString(dr.GetValue(2));
                    ObjTransferencia.Fecha_Movimiento = Convert.ToString(dr.GetValue(3));
                    ObjTransferencia.Dias_Transcurridos = Convert.ToInt32(dr.GetValue(4));
                    ObjTransferencia.Origen_Dependencia = Convert.ToString(dr.GetValue(5));
                    ObjTransferencia.Destino_Dependencia = Convert.ToString(dr.GetValue(6));
                    ObjTransferencia.Observaciones = Convert.ToString(dr.GetValue(7));
                    ObjTransferencia.Status = Convert.ToString(dr.GetValue(11));
                    ObjTransferencia.ImgVerde = Convert.ToString(dr.GetValue(8))=="0"?false:true;
                    ObjTransferencia.ImgRojo = Convert.ToString(dr.GetValue(9)) == "0" ? false : true;
                    ObjTransferencia.StatusMovto = Convert.ToString(dr.GetValue(12)) == "E" ? "Editar" : "Ver";
                    ObjTransferencia.Editable = Convert.ToString(dr.GetValue(11)) == "RECIBIDA" ? false : true;
                    ObjTransferencia.Poliza_Baja = Convert.ToInt32(dr.GetValue(13)) ;
                    ObjTransferencia.Imprimir_Poliza_Baja = Convert.ToString(dr.GetValue(14)) == "0" ? false : true;
                    ObjTransferencia.Poliza_Alta = Convert.ToInt32(dr.GetValue(15));
                    ObjTransferencia.Imprimir_Poliza_Alta = Convert.ToString(dr.GetValue(16)) == "0" ? false : true;

                    //ObjTransferencia.ColorLink = Convert.ToString(dr.GetValue(11)) == "RECIBIDA" ? "#6B696B" : "#0066CC";
                    List.Add(ObjTransferencia);
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
        public void TransferenciaInsertar(ref Transferencia ObjTransferencia, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_FECHA_TRANSFERENCIA", "P_ORIGEN_DEPENDENCIA", "P_DESTINO_DEPENDENCIA",
                                        "P_OBSERVACIONES","P_USUARIO_TRANSFERENCIA"};
                object[] Valores = {ObjTransferencia.Fecha_Transferencia,ObjTransferencia.Origen_Dependencia,ObjTransferencia.Destino_Dependencia,
                                   ObjTransferencia.Observaciones,ObjTransferencia.Usuario_Transferencia};
                String[] ParametrosOut = { "P_BANDERA", "P_ID_TRANSFERENCIA" };

                Cmd = CDDatos.GenerarOracleCommand("INS_SAF_PAT_TRANSFERENCIAS", ref Verificador, Parametros, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjTransferencia.IdTransferencia = Convert.ToInt32(Cmd.Parameters["P_ID_TRANSFERENCIA"].Value);
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
        public void TransferenciaEditar(Transferencia ObjTransferencia, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID_TRANSFERENCIA","P_FECHA_TRANSFERENCIA", "P_ORIGEN_DEPENDENCIA", 
                                        "P_DESTINO_DEPENDENCIA", "P_OBSERVACIONES"};
                object[] Valores = {    ObjTransferencia.IdTransferencia, ObjTransferencia.Fecha_Transferencia,
                                        ObjTransferencia.Origen_Dependencia,ObjTransferencia.Destino_Dependencia,
                                        ObjTransferencia.Observaciones};
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_PAT_TRANSFERENCIAS", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void TransferenciaEditarStatus(ref Transferencia ObjTransferencia, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID_TRANSFERENCIA","P_STATUS", "P_USUARIO_MOVIMIENTO", 
                                        "P_OBSERVACIONES"};
                object[] Valores = {    ObjTransferencia.IdTransferencia,ObjTransferencia.Status,ObjTransferencia.Usuario_Movimiento,
                                        ObjTransferencia.Observaciones};
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_PAT_TRANSF_STATUS", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void TransferenciaConsultaDatos(ref Transferencia ObjTransferencia, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {


                string[] ParametrosIn = { "P_ID_TRANSFERENCIA" };
                object[] Valores = { ObjTransferencia.IdTransferencia
            };
                string[] ParametrosOut ={                                          
                                          "P_FECHA_TRANSFERENCIA",
                                          "P_ORIGEN_DEPENDENCIA",
                                          "P_DESTINO_DEPENDENCIA",
                                          "P_OBSERVACIONES",
                                          "P_BANDERA"
                };

                Cmd = CDDatos.GenerarOracleCommand("SEL_SAF_TRANSFERENCIAS", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjTransferencia = new Transferencia();
                    ObjTransferencia.Fecha_Transferencia = Convert.ToString(Cmd.Parameters["P_FECHA_TRANSFERENCIA"].Value);
                    ObjTransferencia.Origen_Dependencia = Convert.ToString(Cmd.Parameters["P_ORIGEN_DEPENDENCIA"].Value);
                    ObjTransferencia.Destino_Dependencia = Convert.ToString(Cmd.Parameters["P_DESTINO_DEPENDENCIA"].Value);
                    ObjTransferencia.Observaciones = Convert.ToString(Cmd.Parameters["P_OBSERVACIONES"].Value);
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
        public void TransferenciaEliminar(Transferencia ObjTransferencia, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID_TRANSFERENCIA" };
                object[] Valores = { ObjTransferencia.IdTransferencia };
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("DEL_SAF_PAT_TRANSFERENCIAS", ref Verificador, Parametros, Valores, ParametrosOut);
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
