using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using CapaEntidad;

namespace CapaDatos
{
   public class CD_Pres_Documento
    {
        public void ConsultaGrid_Documentos(ref Pres_Documento  objDocumento, ref List<Pres_Documento> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "p_dependencia","p_fecha_inicial","p_fecha_final","p_tipo", "p_supertipo", "p_status","p_buscar","p_editor" };
                String[] Valores = { objDocumento.Dependencia, objDocumento.Fecha_Inicial, objDocumento.Fecha_Final, objDocumento.Tipo, objDocumento.SuperTipo, objDocumento.Status, objDocumento.P_Buscar, objDocumento.Editor };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_Presupuesto.Obt_Grid_Documentos", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objDocumento= new Pres_Documento();                    
                    objDocumento.Id= Convert.ToInt32(dr.GetValue(0));
                    objDocumento.Dependencia = Convert.ToString(dr.GetValue(1));
                    objDocumento.SuperTipo = Convert.ToString(dr.GetValue(2));
                    objDocumento.Tipo = Convert.ToString(dr.GetValue(3));
                    objDocumento.No_documento = Convert.ToString(dr.GetValue(4));
                    objDocumento.Fecha = Convert.ToString(dr.GetValue(5));
                    objDocumento.Status = Convert.ToString(dr.GetValue(6));
                    objDocumento.Concepto = Convert.ToString(dr.GetValue(7));
                    objDocumento.Origen = Convert.ToDouble(dr.GetValue(8));
                    objDocumento.Destino = Convert.ToDouble(dr.GetValue(9));
                    objDocumento.Opcion_Modificar = Convert.ToString(dr.GetValue(10)) == "S" ? false : true;
                    objDocumento.Opcion_Modificar_Str = Convert.ToString(dr.GetValue(6)) == "Autorizado" ? "Ver" : "Editar";
                    if(objDocumento.SuperTipo=="Ministración")
                        objDocumento.Opcion_Modificar2 = true;// Convert.ToString(dr.GetValue(10)) == "RECIBIDA" ? false : true;
                    else
                        objDocumento.Opcion_Modificar2 = Convert.ToString(dr.GetValue(10)) == "S" ? true : false;
                    objDocumento.Opcion_Eliminar = Convert.ToString(dr.GetValue(14)) == "S" ? false : true;
                    objDocumento.Opcion_Eliminar2 = Convert.ToString(dr.GetValue(14)) == "S" ? true : false;
                    

                    List.Add(objDocumento);
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
        public void ConsultarDocumentoSel(ref Pres_Documento objDocumento, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {


                string[] ParametrosIn = { "P_ID" };
                object[] Valores = { Convert.ToInt32(objDocumento.Id)
            };
                string[] ParametrosOut = {  "P_DEPENDENCIA",
                                            "P_FOLIO",
                                            "P_TIPO",
                                            "P_FECHA",
                                            "P_STATUS",
                                            "P_DESCRIPCION",
                                            "P_MOTIVO_RECHAZO",
                                            "P_MOTIVO_AUTORIZACION",
                                            "P_CUENTA",
                                            "P_NUMERO_CHEQUE",
                                            "P_CLAVE_CUENTA",
                                            "P_CLAVE_EVENTO",
                                            "P_REGULARIZA",
                                            "P_FECHA_FINAL",
                                            "P_GENERACION_SIMULTANEA",
                                            "P_CONTABILIZAR",
                                            "P_POLIZA",
                                            "P_ISR",
                                            "P_IMPORTE_OPERACION",
                                            "P_IMPORTE_CHEQUE",
                                            "p_bandera"
                };

                Cmd = CDDatos.GenerarOracleCommand("SEL_SAF_PRESUP_DOCUMENTOS", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    objDocumento = new Pres_Documento();
                    objDocumento.Dependencia = Convert.ToString(Cmd.Parameters["P_DEPENDENCIA"].Value);
                    objDocumento.Folio = Convert.ToString(Cmd.Parameters["P_FOLIO"].Value);
                    objDocumento.Tipo = Convert.ToString(Cmd.Parameters["P_TIPO"].Value);
                    objDocumento.Fecha = Convert.ToString(Cmd.Parameters["P_FECHA"].Value);
                    objDocumento.Status = Convert.ToString(Cmd.Parameters["P_STATUS"].Value);
                    objDocumento.Descripcion = Convert.ToString(Cmd.Parameters["P_DESCRIPCION"].Value);
                    objDocumento.MotivoRechazo = Convert.ToString(Cmd.Parameters["P_MOTIVO_RECHAZO"].Value);
                    objDocumento.MotivoAutorizacion = Convert.ToString(Cmd.Parameters["P_MOTIVO_AUTORIZACION"].Value);
                    objDocumento.Cuenta = Convert.ToString(Cmd.Parameters["P_CUENTA"].Value);
                    objDocumento.NumeroCheque = Convert.ToString(Cmd.Parameters["P_NUMERO_CHEQUE"].Value);
                    objDocumento.ClaveCuenta = Convert.ToString(Cmd.Parameters["P_CLAVE_CUENTA"].Value);
                    objDocumento.ClaveEvento = Convert.ToString(Cmd.Parameters["P_CLAVE_EVENTO"].Value);
                    objDocumento.Regulariza = Convert.ToString(Cmd.Parameters["P_REGULARIZA"].Value);
                    objDocumento.Fecha_Final = Convert.ToString(Cmd.Parameters["P_FECHA_FINAL"].Value);
                    objDocumento.GeneracionSimultanea = Convert.ToString(Cmd.Parameters["P_GENERACION_SIMULTANEA"].Value);
                    objDocumento.Contabilizar = Convert.ToString(Cmd.Parameters["P_CONTABILIZAR"].Value);
                    objDocumento.PolizaComprometida= Convert.ToString(Cmd.Parameters["P_POLIZA"].Value);
                    objDocumento.ISR = Convert.ToDouble(Cmd.Parameters["P_ISR"].Value);
                    objDocumento.Importe_Operacion = Convert.ToDouble(Cmd.Parameters["P_IMPORTE_OPERACION"].Value);
                    objDocumento.Importe_Cheque = Convert.ToDouble(Cmd.Parameters["P_IMPORTE_CHEQUE"].Value);

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
        public void ConsultarCedulasAdicionales(ref Pres_Documento objDocumento, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {


                string[] ParametrosIn = { "P_ID" };
                object[] Valores = { Convert.ToInt32(objDocumento.Id)
            };
                string[] ParametrosOut = {  "P_DEVENGADO",
                                            "P_EJERCIDO",
                                            "P_PAGADO",
                                            "P_BANDERA"

                };

                Cmd = CDDatos.GenerarOracleCommand("SEL_SAF_PRESUP_CEDULAS_EXTRAS", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    objDocumento = new Pres_Documento();
                    objDocumento.CedulaDevengado = Convert.ToString(Cmd.Parameters["P_DEVENGADO"].Value);
                    objDocumento.CedulaEjercido = Convert.ToString(Cmd.Parameters["P_EJERCIDO"].Value);
                    objDocumento.CedulaPagado = Convert.ToString(Cmd.Parameters["P_PAGADO"].Value);
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
        public void GenerarPoliza(ref Pres_Documento objdocumento, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID_DOC" };
                object[] Valores =    { objdocumento.Id};
                String[] ParametrosOut = { "p_Bandera" };

                if (objdocumento.ClaveEvento == "01")
                    Cmd = CDDatos.GenerarOracleCommand("GNR_POLIZAS_AUTO_CEDULAS", ref Verificador, Parametros, Valores, ParametrosOut);
                else
                {
                    if (objdocumento.ClaveEvento == "06")
                        Cmd = CDDatos.GenerarOracleCommand("GNR_POLIZAS_AUTO_HONO", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void InsertaDocumentoEncabezado(ref Pres_Documento objdocumento, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            { 
                String[] Parametros = { "P_CENTRO_CONTABLE", "P_DEPENDENCIA", "P_SUPERTIPO", "P_TIPO", "P_FECHA", "P_MES_ANIO", "P_TIPO_CAPTURA", "P_STATUS",
                                        "P_DESCRIPCION", "P_MOTIVO_RECHAZO", "P_MOTIVO_AUTORIZACION", "P_CUENTA", "P_NUMERO_CHEQUE", "P_CEDULA_COMPROMETIDO", "P_CEDULA_DEVENGADO",
                                        "P_CEDULA_EJERCIDO", "P_CEDULA_PAGADO", "P_POLIZA_COMPROMETIDO","P_POLIZA_DEVENGADO", "P_POLIZA_EJERCIDO", "P_POLIZA_PAGADO", "P_CLAVE_CUENTA", "P_CLAVE_EVENTO",
                                        "P_KEY_DOCUMENTO", "P_KEY_POLIZA", "P_KEY_POLIZA_811", "P_EJERCICIO", "P_REGULARIZA", "P_FECHA_FINAL", "P_GENERACION_SIMULTANEA",
                                        "P_USUARIO","P_CONTABILIZAR", "P_ISR","P_IMPORTE_OPERACION","P_IMPORTE_CHEQUE"};
                object[] Valores =    { objdocumento.CentroContable, objdocumento.Dependencia,objdocumento.SuperTipo,objdocumento.Tipo ,objdocumento.Fecha,
                                        objdocumento.MesAnio,objdocumento.TipoCaptura,objdocumento.Status,objdocumento.Descripcion,objdocumento.MotivoRechazo,objdocumento.MotivoAutorizacion,
                                        objdocumento.Cuenta,objdocumento.NumeroCheque,objdocumento.CedulaComprometido,objdocumento.CedulaDevengado,objdocumento.CedulaEjercido,
                                        objdocumento.CedulaPagado,objdocumento.PolizaComprometida, objdocumento.PolizaDevengado,objdocumento.PolizaEjercido,objdocumento.PolizaPagado,objdocumento.ClaveCuenta,
                                        objdocumento.ClaveEvento,objdocumento.KeyDocumento,objdocumento.KeyPoliza, objdocumento.KeyPoliza811, objdocumento.Ejercicios , objdocumento.Regulariza,
                                        objdocumento.Fecha_Final,objdocumento.GeneracionSimultanea,objdocumento.Usuario, objdocumento.Contabilizar, objdocumento.ISR,objdocumento.Importe_Operacion,objdocumento.Importe_Cheque };
                String[] ParametrosOut = { "P_ID", "P_FOLIO", "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("INS_SAF_PRESUP_DOCUMENTOS", ref Verificador, Parametros, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    objdocumento.Id  = Convert.ToInt32 (Cmd.Parameters["P_ID"].Value);
                    objdocumento.Folio = Convert.ToString(Cmd.Parameters["P_FOLIO"].Value);
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
        public void EditarDocumentoEncabezado(Pres_Documento objdocumento, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID",
                                        "P_CENTRO_CONTABLE",
                                        "P_DEPENDENCIA",
                                        "P_FOLIO",
                                        "P_TIPO",
                                        "P_FECHA",
                                        "P_MES_ANIO",
                                        "P_STATUS",
                                        "P_DESCRIPCION",
                                        "P_MOTIVO_RECHAZO",
                                        "P_MOTIVO_AUTORIZACION",
                                        "P_CUENTA",
                                        "P_NUMERO_CHEQUE",
                                        "P_CLAVE_CUENTA",
                                        "P_CLAVE_EVENTO",
                                        "P_REGULARIZA",
                                        "P_FECHA_FINAL",
                                        "P_GENERACION_SIMULTANEA",
                                        "P_USUARIO",
                                        "P_CONTABILIZAR",
                                        "P_ISR"};
                object[] Valores =    {  objdocumento.Id,
                                        objdocumento.CentroContable,
                                        objdocumento.Dependencia,
                                        objdocumento.Folio,
                                        objdocumento.Tipo ,
                                        objdocumento.Fecha,
                                        objdocumento.MesAnio,
                                        objdocumento.Status,
                                        objdocumento.Descripcion,
                                        objdocumento.MotivoRechazo,
                                        objdocumento.MotivoAutorizacion,
                                        objdocumento.Cuenta,
                                        objdocumento.NumeroCheque,
                                        objdocumento.ClaveCuenta,
                                        objdocumento.ClaveEvento,
                                        objdocumento.Regulariza,
                                        objdocumento.Fecha_Final,
                                        objdocumento.GeneracionSimultanea,
                                        objdocumento.Usuario,
                                        objdocumento.Contabilizar,
                                        objdocumento .ISR};
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_PRESUP_DOCUMENTOS", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void EditarCedulaEncabezado(Pres_Documento objdocumento, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID",
                                        "P_CENTRO_CONTABLE",
                                        "P_DEPENDENCIA",
                                        "P_FOLIO",
                                        "P_TIPO",
                                        "P_FECHA",
                                        "P_MES_ANIO",
                                        "P_STATUS",
                                        "P_DESCRIPCION",
                                        "P_MOTIVO_RECHAZO",
                                        "P_MOTIVO_AUTORIZACION",
                                        "P_CUENTA",
                                        "P_NUMERO_CHEQUE",
                                        "P_CLAVE_CUENTA",
                                        "P_CLAVE_EVENTO",
                                        "P_REGULARIZA",
                                        "P_FECHA_FINAL",
                                        "P_GENERACION_SIMULTANEA",
                                        "P_USUARIO",
                                        "P_CONTABILIZAR",
                                        "P_ISR",
                                         "P_POLIZA",
                                        "P_IMPORTE_OPERACION",
                                        "P_IMPORTE_CHEQUE"};
                object[] Valores =    {  objdocumento.Id,
                                        objdocumento.CentroContable,
                                        objdocumento.Dependencia,
                                        objdocumento.Folio,
                                        objdocumento.Tipo ,
                                        objdocumento.Fecha,
                                        objdocumento.MesAnio,
                                        objdocumento.Status,
                                        objdocumento.Descripcion,
                                        objdocumento.MotivoRechazo,
                                        objdocumento.MotivoAutorizacion,
                                        objdocumento.Cuenta,
                                        objdocumento.NumeroCheque,
                                        objdocumento.ClaveCuenta,
                                        objdocumento.ClaveEvento,
                                        objdocumento.Regulariza,
                                        objdocumento.Fecha_Final,
                                        objdocumento.GeneracionSimultanea,
                                        objdocumento.Usuario,
                                        objdocumento.Contabilizar,
                                        objdocumento .ISR,
                                        objdocumento.PolizaComprometida,
                                        objdocumento.Importe_Operacion,
                                        objdocumento.Importe_Cheque};
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_PRESUP_CEDULAS", ref Verificador, Parametros, Valores, ParametrosOut);               
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
        public void EliminarDocumentoEncabezado(Pres_Documento objdocumento, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID_DOCUMENTO" };
                object[] Valores = { objdocumento.Id };
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("DEL_SAF_PRESUP_DOCUMENTO", ref Verificador, Parametros, Valores, ParametrosOut);
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
