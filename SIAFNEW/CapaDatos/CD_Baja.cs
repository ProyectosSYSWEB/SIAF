using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data.OracleClient;

namespace CapaDatos
{
    public class CD_Baja
    {
        public void ConsultarDatos(ref Baja ObjBaja, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {


                string[] ParametrosIn = { "P_ID_BAJA" };
                object[] Valores = { ObjBaja.IdTransferencia
            };
                string[] ParametrosOut ={                                          
                                          "P_FECHA_BAJA", 
                                          "P_DEPENDENCIA",
                                          "P_TIPO_BAJA",
                                          "P_OBSERVACIONES",
                                          "P_BANDERA"
                };

                Cmd = CDDatos.GenerarOracleCommand("SEL_SAF_PAT_BAJA", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjBaja = new Baja();
                    ObjBaja.Fecha_Transferencia = Convert.ToString(Cmd.Parameters["P_FECHA_BAJA"].Value);
                    ObjBaja.Origen_Dependencia = Convert.ToString(Cmd.Parameters["P_DEPENDENCIA"].Value);
                    ObjBaja.Tipo_Baja_Str = Convert.ToString(Cmd.Parameters["P_TIPO_BAJA"].Value);
                    ObjBaja.Observaciones = Convert.ToString(Cmd.Parameters["P_OBSERVACIONES"].Value);
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
        public void Obtener_Grid(ref Baja ObjBaja, String FechaInicial, String FechaFinal, String Buscar, ref List<Baja> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "P_Dependencia", "P_Fecha_Inicial", "P_Fecha_Final", "P_Status","P_Buscar" };
                String[] Valores = { ObjBaja.Origen_Dependencia, FechaInicial, FechaFinal, ObjBaja.Status,Buscar };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_patrimonio.Obt_Grid_Bajas", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    ObjBaja = new Baja();
                    ObjBaja.IdTransferencia = Convert.ToInt32(dr.GetValue(0));
                    ObjBaja.Folio = Convert.ToString(dr.GetValue(1));
                    ObjBaja.Fecha_Transferencia = Convert.ToString(dr.GetValue(2));
                    ObjBaja.Origen_Dependencia = Convert.ToString(dr.GetValue(3));
                    ObjBaja.Tipo_Baja_Str = Convert.ToString(dr.GetValue(4));
                    ObjBaja.Observaciones = Convert.ToString(dr.GetValue(5));
                    ObjBaja.Status = Convert.ToString(dr.GetValue(9));
                    ObjBaja.ImgVerde = Convert.ToString(dr.GetValue(6)) == "0" ? false : true;
                    ObjBaja.ImgRojo = Convert.ToString(dr.GetValue(7)) == "0" ? false : true;
                    ObjBaja.StatusMovto = Convert.ToString(dr.GetValue(10)) == "E" ? "Editar" : "Ver";
                    ObjBaja.Poliza_Baja= Convert.ToInt32(dr.GetValue(11)); 
                    if(Convert.ToString(dr.GetValue(12))=="1")
                        ObjBaja.Imprimir_Poliza_Baja= true;
                    else
                        ObjBaja.Imprimir_Poliza_Baja = false;
                    ObjBaja.Tipo_Baja = Convert.ToInt32(dr.GetValue(13));
                    List.Add(ObjBaja);
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
        public void Editar_Status(ref Baja ObjBaja, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_DEPENDENCIA","P_ID_BAJA","P_STATUS", "P_USUARIO_MOVIMIENTO", 
                                        "P_OBSERVACIONES",
                                        "P_BAJA_FECHA","P_BAJA_TIPO","P_EJERCICIO"};
                object[] Valores = {    ObjBaja.Origen_Dependencia,ObjBaja.IdTransferencia,ObjBaja.Status,ObjBaja.Usuario_Movimiento,
                                        ObjBaja.Observaciones,
                                        ObjBaja.Fecha_Movimiento,ObjBaja.Tipo_Baja,ObjBaja.bien.Ejercicio};
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_PAT_BAJAS_STATUS", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void Insertar(ref Baja ObjBaja, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_FECHA_BAJA", 
                                        "P_DEPENDENCIA",
                                        "P_TIPO_BAJA",
                                        "P_OBSERVACIONES",
                                        "P_USUARIO"};
                object[] Valores = {ObjBaja.Fecha_Transferencia,
                                    ObjBaja.Origen_Dependencia,
                                    ObjBaja.Tipo_Baja_Str,
                                    ObjBaja.Observaciones,
                                    ObjBaja.Usuario_Transferencia};
                String[] ParametrosOut = { "P_BANDERA", "P_ID_BAJA" };

                Cmd = CDDatos.GenerarOracleCommand("INS_SAF_PAT_BAJA", ref Verificador, Parametros, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjBaja.IdTransferencia = Convert.ToInt32(Cmd.Parameters["P_ID_BAJA"].Value);
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
        public void Editar(Baja ObjBaja, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID_BAJA","P_FECHA_BAJA", "P_DEPENDENCIA", 
                                        "P_TIPO_BAJA", "P_OBSERVACIONES"};
                object[] Valores = {    ObjBaja.IdTransferencia, ObjBaja.Fecha_Transferencia,
                                        ObjBaja.Origen_Dependencia,ObjBaja.Tipo_Baja_Str,
                                        ObjBaja.Observaciones};
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_PAT_BAJAS", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void Eliminar(Baja ObjBaja, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID_TRANSFERENCIA" };
                object[] Valores = { ObjBaja.IdTransferencia };
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

        public void Insertar_Detalle(List<Baja> BajasDet, Baja Baja, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                CDDatos.StartTrans();
                for (int i = 0; i < BajasDet.Count; i++)
                {
                    String[] Parametros = { "P_ID_BAJA", 
                                            "P_ID_PAT_INVENT"
                                          };
                    object[] Valores = { Baja.IdTransferencia,
                                         BajasDet[i].IdInventario
                                       };
                    String[] ParametrosOut = { "p_Bandera" };
                    Cmd = CDDatos.GenerarOracleCommand("INS_SAF_PAT_BAJAS_DET", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void Obtener_Grid_Detalle(ref Baja ObjBaja, ref List<Baja> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;


                string[] Parametros = { "P_ID_BAJA" };
                object[] Valores = { ObjBaja.IdTransferencia };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_patrimonio.Obt_Grid_Patrimonio_Bajas_Det", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjBaja = new Baja();
                    //ObjTransferenciaDet.poliza_origen.IdPoliza = Convert.ToInt32(dr.GetValue(0));
                    //ObjTransferenciaDet.poliza_origen.Concepto = Convert.ToString(dr.GetValue(1));
                    //ObjTransferenciaDet.poliza_origen.IdCuenta_Contable = Convert.ToInt32(dr.GetValue(4));
                    //ObjTransferenciaDet.poliza_origen.DescCuenta_Contable = Convert.ToString(dr.GetValue(5));
                    ObjBaja.IdInventario = Convert.ToInt32(dr.GetValue(0));
                    ObjBaja.Inventario_Numero = Convert.ToString(dr.GetValue(1));
                    ObjBaja.bien_det.Cantidad = Convert.ToInt32(dr.GetValue(2));
                    ObjBaja.bien_det.Marca = Convert.ToString(dr.GetValue(3));
                    ObjBaja.bien_det.Modelo = Convert.ToString(dr.GetValue(4));
                    ObjBaja.bien_det.No_Serie = Convert.ToString(dr.GetValue(5));
                    ObjBaja.bien_det.Costo = Convert.ToDouble(dr.GetValue(6));
                    List.Add(ObjBaja);
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
