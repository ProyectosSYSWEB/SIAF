using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class CD_Poliza_CFDI
    {
        public void PolizaCFDIInsertar(Poliza_CFDI objPolizaCFDI, List<Poliza_CFDI> lstPolizasCFDI, ref string Verificador)
        {                     

            for (int i = 0; i < lstPolizasCFDI.Count; i++)
            {
                CD_Datos CDDatos = new CD_Datos();
                OracleCommand Cmd = null;
                try
                {
                    String[] Parametros = { "P_ID_POLIZA", "P_NOMBRE_ARCHIVO_XML", "P_NOMBRE_ARCHIVO_PDF", "P_BENEF_TIPO",
                                        "P_CFDI_FOLIO", "P_CFDI_FECHA", "P_CFDI_TOTAL", "P_CFDI_RFC","P_TIPO_GASTO","P_CFDI_UUID","P_CFDI_NOMBRE", "P_FECHA_CAPTURA", "P_USUARIO_CAPTURA" };
                    object[] Valores = {    objPolizaCFDI.IdPoliza, lstPolizasCFDI[i].NombreArchivoXML,  lstPolizasCFDI[i].NombreArchivoPDF, lstPolizasCFDI[i].Beneficiario_Tipo,
                    lstPolizasCFDI[i].CFDI_Folio, lstPolizasCFDI[i].CFDI_Fecha,   lstPolizasCFDI[i].CFDI_Total, lstPolizasCFDI[i].CFDI_RFC, lstPolizasCFDI[i].Tipo_Gasto,lstPolizasCFDI[i].CFDI_UUID,lstPolizasCFDI[i].CFDI_Nombre,
                        lstPolizasCFDI[i].Fecha_Captura,lstPolizasCFDI[i].Usuario_Captura};
                    String[] ParametrosOut = { "p_Bandera" };
                    Cmd = CDDatos.GenerarOracleCommand("INS_SAF_POLIZAS_CFDI", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void PolizaCFDIEditar(Poliza_CFDI objPolizaCFDI, List<Poliza_CFDI> lstPolizasCFDI, ref string Verificador)
        {
            EliminarCFDIEditar(objPolizaCFDI.IdPoliza, ref Verificador);
            PolizaCFDIInsertar(objPolizaCFDI, lstPolizasCFDI, ref Verificador);
            
        }
        public void EliminarCFDIEditar(int IdPoliza, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID_POLIZA" };
                object[] Valores = { IdPoliza };
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("DEL_SAF_POLIZAS_CFDI", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void PolizaCFDIConsultaDatos(Poliza_CFDI objPolizaCFDI, ref List<Poliza_CFDI> lstPolizasCFDI, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
                String[] Parametros = { "P_ID_POLIZA" };
                String[] Valores = { Convert.ToString(objPolizaCFDI.IdPoliza) };
           
                cmm = CDDatos.GenerarOracleCommandCursor("pkg_contabilidad.Obt_Grid_Polizas_CFDI", ref dr, Parametros, Valores);
                while (dr.Read())
                {

                    objPolizaCFDI = new Poliza_CFDI();
                    objPolizaCFDI.Beneficiario_Tipo = Convert.ToString(dr.GetValue(0));
                    objPolizaCFDI.CFDI_Folio = Convert.ToString(dr.GetValue(1));
                    objPolizaCFDI.CFDI_Fecha = Convert.ToString(dr.GetValue(2));
                    objPolizaCFDI.CFDI_Total = Convert.ToDouble(dr.GetValue(3));
                    objPolizaCFDI.CFDI_RFC = Convert.ToString(dr.GetValue(4));
                    objPolizaCFDI.Tipo_Gasto = Convert.ToString(dr.GetValue(5));
                    objPolizaCFDI.NombreArchivoXML = Convert.ToString(dr.GetValue(6));
                    objPolizaCFDI.NombreArchivoPDF = Convert.ToString(dr.GetValue(7));
                    objPolizaCFDI.Ruta_XML= "~/AdjuntosTemp/" + Convert.ToString(dr.GetValue(6));
                    objPolizaCFDI.Ruta_PDF = "~/AdjuntosTemp/" + Convert.ToString(dr.GetValue(7));
                    objPolizaCFDI.CFDI_UUID = Convert.ToString(dr.GetValue(8));
                    objPolizaCFDI.CFDI_Nombre = Convert.ToString(dr.GetValue(9));
                    objPolizaCFDI.Fecha_Captura = Convert.ToString(dr.GetValue(10));
                    objPolizaCFDI.Usuario_Captura = Convert.ToString(dr.GetValue(11));
                    lstPolizasCFDI.Add(objPolizaCFDI);                    
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
        public void PolizaCFDIConsultaDatosAdmin(Poliza_CFDI objPolizaCFDI, ref List<Poliza_CFDI> lstPolizasCFDI, string Buscar)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
                String[] Parametros = { "P_TIPO_GASTO", "P_TIPO_BENEFICIARIO", "P_BUSCAR" };
                String[] Valores = { objPolizaCFDI.Tipo_Gasto, objPolizaCFDI.Beneficiario_Tipo, Buscar };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_contabilidad.Obt_Grid_Polizas_CFDI_Admin", ref dr, Parametros, Valores);
                while (dr.Read())
                {

                    objPolizaCFDI = new Poliza_CFDI();
                    objPolizaCFDI.Beneficiario_Tipo = Convert.ToString(dr.GetValue(0));
                    objPolizaCFDI.CFDI_Folio = Convert.ToString(dr.GetValue(1));
                    objPolizaCFDI.CFDI_Fecha = Convert.ToString(dr.GetValue(2));
                    objPolizaCFDI.CFDI_Total = Convert.ToDouble(dr.GetValue(3));
                    objPolizaCFDI.CFDI_RFC = Convert.ToString(dr.GetValue(4));
                    objPolizaCFDI.Tipo_Gasto = Convert.ToString(dr.GetValue(5));
                    objPolizaCFDI.NombreArchivoXML = Convert.ToString(dr.GetValue(6));
                    objPolizaCFDI.NombreArchivoPDF = Convert.ToString(dr.GetValue(7));
                    objPolizaCFDI.Ruta_XML = "~/AdjuntosTemp/" + Convert.ToString(dr.GetValue(6));
                    objPolizaCFDI.Ruta_PDF = "~/AdjuntosTemp/" + Convert.ToString(dr.GetValue(7));
                    objPolizaCFDI.CFDI_UUID = Convert.ToString(dr.GetValue(8));
                    objPolizaCFDI.CFDI_Nombre = Convert.ToString(dr.GetValue(9));
                    objPolizaCFDI.Fecha_Captura = Convert.ToString(dr.GetValue(10));
                    objPolizaCFDI.Usuario_Captura = Convert.ToString(dr.GetValue(11));
                    objPolizaCFDI.Centro_Contable = Convert.ToString(dr.GetValue(12));
                    lstPolizasCFDI.Add(objPolizaCFDI);
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
