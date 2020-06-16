using CapaEntidad;
using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class CD_Poliza_Conciliacion
    {
        public void ConciliacionInsertarEnc(ref Poliza_Conciliacion ObjConciliacion, ref string Verificador)
        {

            
                CD_Datos CDDatos = new CD_Datos();
                OracleCommand Cmd = null;
                try
                {
                    String[] Parametros = { "P_EJERCICIO", "P_FECHA_INICIAL", "P_FECHA_FINAL", "P_CENTRO_CONTABLE", "P_CUENTA_CONTABLE",                    
                    "P_ELABORO_NOMBRE","P_ELABORO_PUESTO","P_VB_NOMBRE","P_VB_PUESTO"};
                    object[] Valores = {    ObjConciliacion.Ejercicio, ObjConciliacion.Fecha_inicial, ObjConciliacion.Fecha_final, ObjConciliacion.Centro_contable, ObjConciliacion.Cuenta_contable,                                     
                                    ObjConciliacion.Elaboro_nombre,ObjConciliacion.Elaboro_puesto, ObjConciliacion.Vb_nombre, ObjConciliacion.Vb_puesto
                    };
                    String[] ParametrosOut = { "P_ID_ENC", "P_BANDERA" };

                    Cmd = CDDatos.GenerarOracleCommand("INS_SAF_CONCILIACION_ENC", ref Verificador, Parametros, Valores, ParametrosOut);
                    ObjConciliacion.IdEnc = Convert.ToInt32(Cmd.Parameters["P_ID_ENC"].Value);


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

        public void ConciliacionEditarEnc(ref Poliza_Conciliacion ObjConciliacion, ref string Verificador)
        {


            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = {"P_ID_ENC", "P_FECHA_INICIAL", "P_FECHA_FINAL", "P_CUENTA_CONTABLE", 
                    "P_ELABORO_NOMBRE","P_ELABORO_PUESTO","P_VB_NOMBRE","P_VB_PUESTO"};
                object[] Valores = { ObjConciliacion.IdEnc, ObjConciliacion.Fecha_inicial, ObjConciliacion.Fecha_final, ObjConciliacion.Cuenta_contable,
                                    ObjConciliacion.Elaboro_nombre,ObjConciliacion.Elaboro_puesto, ObjConciliacion.Vb_nombre, ObjConciliacion.Vb_puesto
                    };
                String[] ParametrosOut = { "P_BANDERA" };

                Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_CONCILIACION_ENC", ref Verificador, Parametros, Valores, ParametrosOut);
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

        public void ConciliacionInsertar(Poliza_Conciliacion ObjConciliacion, List<Poliza_Conciliacion> lstPolizaDet,  ref string Verificador)
        {
            
            for (int i = 0; i < lstPolizaDet.Count; i++)
            {                 
                CD_Datos CDDatos = new CD_Datos();
                OracleCommand Cmd = null;
                try
                {
                    String[] Parametros = { "P_EJERCICIO", "P_FECHA_INICIAL", "P_FECHA_FINAL", "P_CENTRO_CONTABLE", "P_CUENTA_CONTABLE", "P_TIPO",
                    "P_FECHA","P_NUMERO_POLIZA", "P_NUMERO_CHEQUE", "P_IMPORTE","P_CONCEPTO", "P_DESCRIPCION","P_ID_POLIZA_DET",
                    "P_ELABORO_NOMBRE","P_ELABORO_PUESTO","P_VB_NOMBRE","P_VB_PUESTO"};
                    object[] Valores = {    ObjConciliacion.Ejercicio, ObjConciliacion.Fecha_inicial, ObjConciliacion.Fecha_final, ObjConciliacion.Centro_contable, ObjConciliacion.Cuenta_contable, lstPolizaDet[i].Tipo,
                                    lstPolizaDet[i].Fecha, lstPolizaDet[i].Numero_Poliza, lstPolizaDet[i].Numero_Cheque, lstPolizaDet[i].Importe, lstPolizaDet[i].Concepto, lstPolizaDet[i].Observaciones, 0,
                                    ObjConciliacion.Elaboro_nombre,ObjConciliacion.Elaboro_puesto, ObjConciliacion.Vb_nombre, ObjConciliacion.Vb_puesto
                    };
                    String[] ParametrosOut = { "P_BANDERA" };

                    Cmd = CDDatos.GenerarOracleCommand("INS_SAF_POLIZAS_CONCILIACION", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void ConciliacionDetInsertar(int IdEnc, List<Poliza_Conciliacion> lstPolizaDet, ref string Verificador)
        {

            for (int i = 0; i < lstPolizaDet.Count; i++)
            {
                CD_Datos CDDatos = new CD_Datos();
                OracleCommand Cmd = null;
                try
                {
                    String[] Parametros = { "P_TIPO",
                    "P_FECHA","P_NUMERO_POLIZA", "P_NUMERO_CHEQUE", "P_IMPORTE","P_CONCEPTO", "P_DESCRIPCION","P_ID_POLIZA_DET",
                    "P_ID_ENC"};
                    object[] Valores = { lstPolizaDet[i].Tipo,
                                    lstPolizaDet[i].Fecha, lstPolizaDet[i].Numero_Poliza, lstPolizaDet[i].Numero_Cheque, lstPolizaDet[i].Importe, lstPolizaDet[i].Concepto, lstPolizaDet[i].Observaciones, 0,
                                    IdEnc
                    };
                    String[] ParametrosOut = { "P_BANDERA" };

                    Cmd = CDDatos.GenerarOracleCommand("INS_SAF_CONCILIACION_DET", ref Verificador, Parametros, Valores, ParametrosOut);
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

        public void ConciliacionEditar(Poliza_Conciliacion ObjConciliacion, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID", "P_TIPO", "P_IMPORTE",
                                        "P_DESCRIPCION", "P_CUENTA_CONTABLE", "P_FECHA", "P_ELABORO_NOMBRE",
                                        "P_ELABORO_PUESTO","P_VB_NOMBRE","P_VB_PUESTO","P_NOMBRE_ARCHIVO", "P_CUENTA_CHEQUES", "P_CONCEPTO"};
                object[] Valores = {    ObjConciliacion.Id, ObjConciliacion.Tipo, ObjConciliacion.Importe,
                                        ObjConciliacion.Descripcion, ObjConciliacion.Cuenta_contable, ObjConciliacion.Fecha, ObjConciliacion.Elaboro_nombre,
                                        ObjConciliacion.Elaboro_puesto, ObjConciliacion.Vb_nombre, ObjConciliacion.Vb_puesto, ObjConciliacion.Nombre_archivo, ObjConciliacion.Cuenta_Cheques, ObjConciliacion.Concepto};
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_POLIZAS_CONCILIACION", ref Verificador, Parametros, Valores, ParametrosOut);
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

        public void ConciliacionConsultaGrid(Poliza_Conciliacion ObjConciliacion, ref List<Poliza_Conciliacion> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;                
                String[] Parametros = { "P_EJERCICIO", "P_CENTRO_CONTABLE", "P_FECHA_INICIAL", "P_FECHA_FINAL" };
                String[] Valores = { Convert.ToString(ObjConciliacion.Ejercicio), Convert.ToString(ObjConciliacion.Centro_contable), ObjConciliacion.Fecha_inicial, ObjConciliacion.Fecha_final };
                cmm = CDDatos.GenerarOracleCommandCursor("pkg_contabilidad.Obt_Grid_Conciliacion_Enc", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    ObjConciliacion = new Poliza_Conciliacion();
                    //ObjConciliacion.Id = Convert.ToInt32(dr.GetValue(0));
                    ObjConciliacion.Centro_contable = Convert.ToInt32(dr.GetValue(0));
                    ObjConciliacion.Desc_Cuenta_Contable = Convert.ToString(dr.GetValue(6));
                    ObjConciliacion.Fecha_inicial = Convert.ToString(dr.GetValue(2));
                    ObjConciliacion.Fecha_final = Convert.ToString(dr.GetValue(3));
                    ObjConciliacion.Elaboro_nombre = Convert.ToString(dr.GetValue(4));
                    ObjConciliacion.Vb_nombre = Convert.ToString(dr.GetValue(5));
                    ObjConciliacion.Cuenta_contable = Convert.ToInt32(dr.GetValue(1));
                    ObjConciliacion.IdEnc = Convert.ToInt32(dr.GetValue(7));
                    List.Add(ObjConciliacion);
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

        public void ConciliacionAdjConsultaGrid(Poliza_Conciliacion ObjConciliacion, ref List<Poliza_Conciliacion> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "P_ID_ENC" };
                String[] Valores = { Convert.ToString(ObjConciliacion.IdEnc) };
                cmm = CDDatos.GenerarOracleCommandCursor("pkg_contabilidad.Obt_Grid_Conciliacion_Adj", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    ObjConciliacion = new Poliza_Conciliacion();                    
                    ObjConciliacion.NombreArchivoPDF = Convert.ToString(dr.GetValue(0));
                    ObjConciliacion.Ruta_PDF = "~/AdjuntosTemp/" + Convert.ToString(dr.GetValue(0));
                    List.Add(ObjConciliacion);
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


        public void Polizas_ConciliacionConsultaGrid(Poliza_Detalle ObjPolizaDet, ref List<Poliza_Detalle> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "P_EJERCICIO", "P_CUENTA", "P_NUMERO_POLIZA" };
                String[] Valores = { Convert.ToString(ObjPolizaDet.Ejercicio), ObjPolizaDet.Cheque_cuenta, ObjPolizaDet.Numero_poliza};
                cmm = CDDatos.GenerarOracleCommandCursor("pkg_contabilidad.Obt_Grid_Polizas_Conciliacion", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    ObjPolizaDet = new Poliza_Detalle();
                    ObjPolizaDet.Fecha = Convert.ToString(dr.GetValue(1));
                    ObjPolizaDet.Tot_Abono = Convert.ToDouble(dr.GetValue(8));
                    ObjPolizaDet.Tipo = Convert.ToString(dr.GetValue(9));
                    ObjPolizaDet.Numero_poliza = Convert.ToString(dr.GetValue(0));
                    ObjPolizaDet.IdPoliza = Convert.ToInt32(dr.GetValue(2));
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

        public void ConsultarConciliacionSel(Poliza_Conciliacion ObjConciliacion, ref Poliza_Conciliacion ObjRespConciliacion, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {


                string[] ParametrosIn = {
                                          "P_EJERCICIO",
                                          "P_FECHA_INICIAL",
                                          "P_FECHA_FINAL",
                                          "P_CENTRO_CONTABLE",
                                          "P_CUENTA_CONTABLE",
                                          "P_ELABORO_NOMBRE",
                                          "P_VB_NOMBRE"
                };
                object[] Valores = { ObjConciliacion.Ejercicio, ObjConciliacion.Fecha_inicial, ObjConciliacion.Fecha_final, ObjConciliacion.Centro_contable,
                ObjConciliacion.Cuenta_contable, ObjConciliacion.Elaboro_nombre, ObjConciliacion.Vb_nombre
                };
                string[] ParametrosOut ={
                                          "P_VB_PUESTO",
                                          "P_ELABORO_PUESTO",
                                          "P_BANDERA"
                };
                Cmd = CDDatos.GenerarOracleCommand("SEL_SAF_CONCILIACION", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjRespConciliacion = new Poliza_Conciliacion();
                    //ObjConciliacion.Fecha_inicial = Convert.ToString(Cmd.Parameters["P_FECHA_INICIAL"].Value);
                    //ObjConciliacion.Fecha_final = Convert.ToString(Cmd.Parameters["P_FECHA_FINAL"].Value);
                    //ObjConciliacion.Centro_contable = Convert.ToInt32(Cmd.Parameters["P_CENTRO_CONTABLE"].Value);
                    //ObjConciliacion.Cuenta_contable = Convert.ToInt32(Cmd.Parameters["P_CUENTA_CONTABLE"].Value);
                    //ObjConciliacion.Elaboro_nombre = Convert.ToString(Cmd.Parameters["P_ELABORO_NOMBRE"].Value);
                    //ObjConciliacion.Elaboro_puesto = Convert.ToString(Cmd.Parameters["P_ELABORO_PUESTO"].Value);
                    ObjRespConciliacion.Elaboro_puesto = Convert.ToString(Cmd.Parameters["P_ELABORO_PUESTO"].Value);
                    ObjRespConciliacion.Vb_puesto = Convert.ToString(Cmd.Parameters["P_VB_PUESTO"].Value);
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

        public void ConsultarConciliacionEncSel(ref Poliza_Conciliacion ObjConciliacion, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {


                string[] ParametrosIn = {"P_ID_ENC"
                                          
                };
                object[] Valores = { ObjConciliacion.IdEnc
                };
                string[] ParametrosOut ={
                                          "P_EJERCICIO",
                                          "P_FECHA_INICIAL",
                                          "P_FECHA_FINAL",
                                          "P_CENTRO_CONTABLE",
                                          "P_CUENTA_CONTABLE",
                                          "P_ELABORO_NOMBRE",
                                          "P_VB_NOMBRE",
                                          "P_VB_PUESTO",
                                          "P_ELABORO_PUESTO",
                                          "P_BANDERA"
                };
                Cmd = CDDatos.GenerarOracleCommand("SEL_SAF_CONCILIACION_ENC", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjConciliacion = new Poliza_Conciliacion();
                    ObjConciliacion.Ejercicio = Convert.ToInt32(Cmd.Parameters["P_EJERCICIO"].Value);
                    ObjConciliacion.Fecha_inicial = Convert.ToString(Cmd.Parameters["P_FECHA_INICIAL"].Value);
                    ObjConciliacion.Fecha_final = Convert.ToString(Cmd.Parameters["P_FECHA_FINAL"].Value);
                    ObjConciliacion.Centro_contable = Convert.ToInt32(Cmd.Parameters["P_CENTRO_CONTABLE"].Value);
                    ObjConciliacion.Cuenta_contable = Convert.ToInt32(Cmd.Parameters["P_CUENTA_CONTABLE"].Value);
                    ObjConciliacion.Elaboro_nombre = Convert.ToString(Cmd.Parameters["P_ELABORO_NOMBRE"].Value);
                    ObjConciliacion.Elaboro_puesto = Convert.ToString(Cmd.Parameters["P_ELABORO_PUESTO"].Value);
                    ObjConciliacion.Vb_nombre = Convert.ToString(Cmd.Parameters["P_VB_NOMBRE"].Value);
                    ObjConciliacion.Vb_puesto = Convert.ToString(Cmd.Parameters["P_VB_PUESTO"].Value);
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

        //public void ConciliacionDetConsultaGrid(Poliza_Conciliacion objConciliacion, ref List<Poliza_Conciliacion>lstConciliacionDet)
        //{
        //    CD_Datos CDDatos = new CD_Datos();
        //    OracleCommand cmm = null;
        //    try
        //    {
        //        OracleDataReader dr = null;
        //        String[] Parametros = { "P_EJERCICIO", "P_CENTRO_CONTABLE", "P_CUENTA",
        //        "P_ELABORO_NOMBRE","P_VB_NOMBRE", "P_FECHA_INICIAL", "P_FECHA_FINAL"
        //        };
        //        String[] Valores = { Convert.ToString(objConciliacion.Ejercicio), Convert.ToString(objConciliacion.Centro_contable), Convert.ToString(objConciliacion.Cuenta_contable),
        //        objConciliacion.Elaboro_nombre, objConciliacion.Vb_nombre, objConciliacion.Fecha_inicial, objConciliacion.Fecha_final
        //        };
        //        cmm = CDDatos.GenerarOracleCommandCursor("pkg_contabilidad.Obt_Grid_Conciliacion_Detalle", ref dr, Parametros, Valores);

        //        while (dr.Read())
        //        {
        //            objConciliacion = new Poliza_Conciliacion();
        //            objConciliacion.DescTipo = Convert.ToString(dr.GetValue(0));
        //            objConciliacion.Tipo = Convert.ToString(dr.GetValue(1));
        //            objConciliacion.Fecha = Convert.ToString(dr.GetValue(2));
        //            objConciliacion.Numero_Poliza = Convert.ToString(dr.GetValue(3));
        //            objConciliacion.Importe = Convert.ToDouble(dr.GetValue(4));
        //            objConciliacion.Concepto = Convert.ToString(dr.GetValue(6));
        //            objConciliacion.Observaciones = Convert.ToString(dr.GetValue(5));
        //            objConciliacion.CveTipo = Convert.ToString(dr.GetValue(7));
        //            lstConciliacionDet.Add(objConciliacion);
        //        }
        //        dr.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        CDDatos.LimpiarOracleCommand(ref cmm);
        //    }
        //}
        public void ConciliacionDetConsultaGrid(Poliza_Conciliacion objConciliacion, ref List<Poliza_Conciliacion> lstConciliacionDet)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "P_ID_ENC" };
                String[] Valores = { Convert.ToString(objConciliacion.IdEnc) };
                cmm = CDDatos.GenerarOracleCommandCursor("pkg_contabilidad.Obt_Grid_Conciliacion_Detalle", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objConciliacion = new Poliza_Conciliacion();
                    objConciliacion.DescTipo = Convert.ToString(dr.GetValue(0));
                    objConciliacion.Tipo = Convert.ToString(dr.GetValue(1));
                    objConciliacion.Fecha = Convert.ToString(dr.GetValue(2));
                    objConciliacion.Numero_Poliza = Convert.ToString(dr.GetValue(3));
                    objConciliacion.Importe = Convert.ToDouble(dr.GetValue(4));
                    objConciliacion.Concepto = Convert.ToString(dr.GetValue(6));
                    objConciliacion.Observaciones = Convert.ToString(dr.GetValue(5));
                    objConciliacion.CveTipo = Convert.ToString(dr.GetValue(7));
                    lstConciliacionDet.Add(objConciliacion);
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

        public void ConciliacionEliminar(Poliza_Conciliacion ObjConciliacion, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {


                string[] ParametrosIn = { "P_ID_ENC" };
                object[] Valores = { ObjConciliacion.IdEnc
            };
                string[] ParametrosOut ={
                                          "P_BANDERA"
                };

                Cmd = CDDatos.GenerarOracleCommand("DEL_SAF_CONCILIACION", ref Verificador, ParametrosIn, Valores, ParametrosOut);
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
        public void ConciliacionDetEliminar(int IdEnc, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {


                string[] ParametrosIn = { "P_ID_ENC"
                };
                object[] Valores = { IdEnc
            };
                string[] ParametrosOut ={
                                          "P_BANDERA"
                };

                Cmd = CDDatos.GenerarOracleCommand("DEL_SAF_CONCILIACION_DET", ref Verificador, ParametrosIn, Valores, ParametrosOut);
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

        public void PolizaAdjEliminar(Poliza_Conciliacion ObjConciliacion, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {


                string[] ParametrosIn = { "P_ID_ENC" };
                object[] Valores = { ObjConciliacion.IdEnc
            };
                string[] ParametrosOut ={
                                          "P_BANDERA"
                };

                Cmd = CDDatos.GenerarOracleCommand("DEL_SAF_CONCILIACION_ADJ", ref Verificador, ParametrosIn, Valores, ParametrosOut);
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

        public void PolizaAdjInsertar(Poliza_Conciliacion objConciliacion, List<Poliza_Conciliacion> lstAdjuntos, ref string Verificador)
        {

            for (int i = 0; i < lstAdjuntos.Count; i++)
            {
                CD_Datos CDDatos = new CD_Datos();
                OracleCommand Cmd = null;
                Poliza_Conciliacion objPolizaAdj = new Poliza_Conciliacion();
                try
                {
                    String[] Parametros = { "P_ID_ENC", "P_ARCHIVO" };
                    object[] Valores = { objConciliacion.IdEnc, lstAdjuntos[i].NombreArchivoPDF};
                    String[] ParametrosOut = { "p_Bandera" };
                    Cmd = CDDatos.GenerarOracleCommand("INS_SAF_CONCIALIACION_ADJ", ref Verificador, Parametros, Valores, ParametrosOut);

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
}
