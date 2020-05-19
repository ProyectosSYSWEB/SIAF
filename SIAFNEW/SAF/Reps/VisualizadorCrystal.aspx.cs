using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Data.OracleClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Reporting;
//using CrystalDecisions.Enterprise;
using CrystalDecisions.ReportAppServer;


    public partial class Reportes_VisualizadorCrystal : System.Web.UI.Page
    {
        private ReportDocument report = new ReportDocument();
        private System.Web.UI.Page p;



        protected void Page_Load(object sender, EventArgs e)
        {

            //if (!IsPostBack)
            //{
                Int32 IdProyecto = Convert.ToInt32(Request.QueryString["IdProyecto"]);
                Int32 Ejercicio = Convert.ToInt32(Request.QueryString["Ejercicio"]);
                String Tipo = Convert.ToString(Request.QueryString["tipo"]);
                String Programa = Convert.ToString(Request.QueryString["Programa"]);
                String CveReporte = Convert.ToString(Request.QueryString["CveReporte"]);
                Int32 IdMovimiento = Convert.ToInt32(Request.QueryString["IdMovimiento"]);
                Int32 Anio = Convert.ToInt32(Request.QueryString["Anio"]);
                Int32 Quincena = Convert.ToInt32(Request.QueryString["Quincena"]);
                String TPersonal = Convert.ToString(Request.QueryString["TPersonal"]);
                String Concepto = Convert.ToString(Request.QueryString["Concepto"]);
                String TipoPago = Convert.ToString(Request.QueryString["TipoPago"]);
                Int32 CP_Ini = Convert.ToInt32(Request.QueryString["CP_Ini"]);
                Int32 CP_Fin = Convert.ToInt32(Request.QueryString["CP_Fin"]);
                String TipoFolios = Convert.ToString(Request.QueryString["TipoFolios"]);
                String TipoRep = Convert.ToString(Request.QueryString["TipoRep"]);
                Int32 NumNomina = Convert.ToInt32(Request.QueryString["NumNomina"]);
                String Usuario = Convert.ToString(Request.QueryString["Usuario"]);
                String Cheque_o_Poliza = Convert.ToString(Request.QueryString["Cheque_o_Poliza"]);
                Int32 Impresora = Convert.ToInt32(Request.QueryString["Impresora"]);
                //Int32 IdMov = Convert.ToInt32(Request.QueryString["IdMov"]);      
            
                String Reporte = "";

                if (CveReporte == "RPF-001")
                {
                    if (Ejercicio >= 2012)
                    {
                        Reporte = "Reportes\\rptProyectosPIFI_2013.rpt";
                        rptPDF(Reporte, IdProyecto, Tipo, Ejercicio, Usuario);
                    }
                    else
                    {
                        Reporte = "Reportes\\rptProyectosPIFI.rpt";
                        rptPDF(Reporte, IdProyecto, Tipo, Ejercicio, Usuario);
                    }                    
                }
                else if (CveReporte == "RPF-002")
                {
                    Reporte = "Reportes\\rptRelacionChequesBMS.rpt";

                    rptPDF_RelacionChequesBMS_x_Programa(Reporte, Ejercicio, Programa);
                    
                }
                else if (CveReporte == "RPF-003")
                {
                    Reporte = "Reportes\\rptRecursosporComprobar.rpt";
                    rptPDF_Proyectos(Reporte, IdProyecto, Ejercicio);
                    
                }
                else if (CveReporte == "RPF-004")
                {
                    Reporte = "Reportes\\rptRelacionFacturas.rpt";
                    rptPDF_RelacionFacturas(Reporte, IdMovimiento);                    
                }
                else if (CveReporte == "RPF-005")
                {
                    if (Cheque_o_Poliza == "P")
                    {
                        Reporte = "Reportes\\rptPoliza.rpt";
                        rptPDF_Poliza(Reporte, IdMovimiento);                    
                    }
                    else if (Cheque_o_Poliza == "C")
                    {
                        if (Impresora == 1)
                        {
                            Reporte = "Reportes\\rptCheque-Epson.rpt";
                            rptCheque(Reporte, IdMovimiento);
                        }
                        else
                        {
                            Reporte = "Reportes\\rptCheque.rpt";
                            rptCheque(Reporte, IdMovimiento);
                        }
                    }
                    else if (Cheque_o_Poliza == "R")
                    {
                        Reporte = "Reportes\\rptRecibo_Gastos_a_Comprobar.rpt";
                        rptPDF_Poliza(Reporte, IdMovimiento);
                    }   
                }
                else if (CveReporte == "RPF-006")
                {
                    Reporte = "Reportes\\rptSaldosComprometidos.rpt";
                    rptPDF_SaldosComprometidos(Reporte, Ejercicio, Programa);
                    
                }

                else if (CveReporte == "RPF-007")
                {
                    Reporte = "Reportes\\rptSaldosComprometidos_Detalle.rpt";
                    rptPDF_SaldosComprometidos(Reporte, Ejercicio, Programa);
                    
                }

                else if (CveReporte == "RPF-008")
                {
                    Reporte = "Reportes\\rptChequesporUsuario.rpt";
                    rptPDF_ChequesporUsuario(Reporte, Ejercicio, Usuario, Programa);
                    
                }
                else if (CveReporte == "RPF-009")
                {
                    Reporte = "Reportes\\rptResumenSaldos.rpt";
                    rptPDF_RelacionChequesBMS_x_Programa(Reporte, Ejercicio, Programa);

                }
                else if (CveReporte == "10")
                {
                    Reporte = "Reportes\\rptRelacionTransferenciasBMS.rpt";
                    rptPDF_RelacionChequesBMS_x_Programa(Reporte, Ejercicio, Programa);

                }
                else if (CveReporte == "RPF-011")
                {
                    Reporte = "Reportes\\rptResumenRubro.rpt";
                     rptPDF_RelacionChequesBMS_x_Programa(Reporte, Ejercicio, Programa);

                }
                else if (CveReporte == "RPF-012")
                {
                    Reporte = "Reportes\\rptResumenCuentas.rpt";
                    rptPDF_SaldosComprometidos(Reporte, Ejercicio, Programa);

                }
                else if (CveReporte == "RPF-013")
                {
                    Reporte = "Reportes\\rptProyectosMeta.rpt";
                    rptPDF_ProyectosMeta(Reporte, Ejercicio, Programa);

                }
                else if (CveReporte == "RPF-014")
                {
                    Reporte = "Reportes\\rptGComprobarBMS.rpt";
                    rptPDF_RelacionChequesBMS_x_Programa(Reporte, Ejercicio, Programa);

                }
                else if (CveReporte == "RPF-015")
                {
                    Reporte = "Reportes\\rptRelacionReintegrosBMS.rpt";
                    rptPDF_Reintegros(Reporte, Ejercicio, Programa  );

                }
                else if (CveReporte == "RPF-016")
                {
                    Reporte = "Reportes\\rptRelacionOficiosTraspaso.rpt";
                    rptMovtosTraspasos(Reporte, Ejercicio, Programa);

                }
                else if (CveReporte == "RPF-017")
                {
                    Reporte = "Reportes\\rptRelacionProyectosTraspaso.rpt";
                    rptPDF_RelacionChequesBMS_x_Programa(Reporte, Ejercicio, Programa);

                }
                else if (CveReporte == "RPF-018")
                {
                    Reporte = "Reportes\\rptChequesporProyectos.rpt";
                    rptPDF_RelacionChequesBMS_x_Programa(Reporte, Ejercicio, Programa);

                }
                else if (CveReporte == "RPF-019")
                {
                    Reporte = "Reportes\\rptChequesporMes.rpt";
                    rptPDF_Cheques_x_Mes(Reporte, Ejercicio, Programa);

                }
                else if (CveReporte == "RPF-020")
                {
                    Reporte = "Reportes\\rptRelacionChequesBMS-Mexico.rpt";
                    rptPDF_RelacionChequesBMS_x_Programa(Reporte, Ejercicio, Programa);

                }

                else if (CveReporte == "RPF-021")
                {
                    Reporte = "Reportes\\rptChequesBMSporProyecto.rpt";
                    rptPDF_Proyecto_x_BMS(Reporte, Ejercicio, IdProyecto);

                }
                else if (CveReporte == "RPF-022")
                {
                    Reporte = "Reportes\\rptRelacionOficiosProyectos.rpt";
                    rptPDF_RelacionChequesBMS_x_Programa(Reporte, Ejercicio, Programa);

                }

                else if (CveReporte == "RPF-023")
                {
                    Reporte = "Reportes\\rptResumenSaldos_x_Proyecto1.rpt";
                    rptPDF_Resumen_Saldos_Proy(Reporte, IdProyecto);

                }

                else if (CveReporte == "RPF-024")
                {
                    Reporte = "Reportes\\rptCheques_del_BMS.rpt";
                    rptPDF_Cheques_del_BMS(Reporte, IdProyecto);

                }

                else if (CveReporte == "RPF-025")
                {
                        Reporte = "Reportes\\rptComprobaciones.rpt";
                        rptPDF_Comprobaciones(Reporte, Ejercicio, Programa, IdProyecto);

                }

                else if (CveReporte == "RPF-026")
                {
                    Reporte = "Reportes\\rptTotal_x_Tipo.rpt";
                    rptPDF_Total_x_Tipo(Reporte, Ejercicio);

                }

                else if (CveReporte == "RPF-027")
                {
                    Reporte = "Reportes\\rptObservaciones.rpt";
                    rptPDF_Observaciones(Reporte, Ejercicio, Usuario);

                }

                else if (CveReporte == "RSG-001")
                {
                    Reporte = "Reportes\\rptSigaConcentradoQuincena.rpt";
                    rptExcelSiga09(Reporte, Anio, Quincena, TPersonal, Concepto);
                    
                }
                else if (CveReporte == "RSG-002")
                {
                    Reporte = "Reportes\\rptSigaCostoGeneral.rpt";
                    rptPDFSiga09(Reporte, Anio, Quincena, TPersonal);
                    
                }
                else if (CveReporte == "RSG-003")
                {
                    Reporte = "Reportes\\rptRelacionChequesBMS-Mexico-Excel.rpt";
                    rptExcelBMS(Reporte, Ejercicio, Programa);

                }
                /*else if (CveReporte == "RH-015")
                {
                    Reporte = "Reportes\\rptSigaFoliosCheques.rpt";
                    rptPDFSiga09FoliosCheques(CveReporte, TipoPago, CP_Ini, CP_Fin, TipoFolios, NumNomina, Reporte);
                }          */
               
        }

        private void rptPDF_Comprobaciones(String Reporte, Int32 Ejercicio, String Programa, Int32 Proyecto)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, Ejercicio);
                report.SetParameterValue(1, Programa);
                report.SetParameterValue(2, Proyecto);
                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "pifi";
                connectionInfo.Password = "dsia2014";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "ProyectosPIFI");

            }
            catch (Exception ex)
            {

            }
            finally
            {
                CR_Reportes.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_Reportes.Dispose();
            }
        }
        private void rptPDF_Total_x_Tipo(String Reporte, Int32 Ejercicio)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, Ejercicio);
                report.PrintOptions.PaperSize = PaperSize.PaperLegal;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "pifi";
                connectionInfo.Password = "dsia2014";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "ProyectosPIFI");
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CR_Reportes.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_Reportes.Dispose();
            }
        }        
        private void rptPDFSiga09FoliosCheques(String CveReporte, String TipoPago, Int32 CP_Ini, Int32 CP_Fin, string TipoFolios, Int32 NumNomina, string Reporte)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, NumNomina);
                report.SetParameterValue(1, TipoPago);
                report.SetParameterValue(2, CP_Fin);
                report.SetParameterValue(3, CP_Ini);
                report.SetParameterValue(4, TipoFolios);
                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "pifi";
                connectionInfo.Password = "dsia2014";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Siga09");
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CR_Reportes.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_Reportes.Dispose();
            }
        }
        private void rptPDFSiga09(String Reporte, Int32 Anio, Int32 Quincena, string TPersonal)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, Anio);
                report.SetParameterValue(1, Quincena);
                report.SetParameterValue(2, TPersonal);
                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                //connectionInfo.DatabaseName = "pifi";
                connectionInfo.UserID = "pifi";
                connectionInfo.Password = "dsia2014";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Siga09");

            }
            catch (Exception ex)
            {

            }
            finally
            {
                CR_Reportes.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_Reportes.Dispose();
            }
        }
        private void rptExcelSiga09(String Reporte, Int32 Anio, Int32 Quincena, string TPersonal, string Concepto)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, Anio);
                report.SetParameterValue(1, Quincena);
                report.SetParameterValue(2, TPersonal);
                report.SetParameterValue(3, Concepto);
                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "pifi";
                connectionInfo.Password = "dsia2014";
                SetDBLogonForReport(connectionInfo, report);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                CR_Reportes.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_Reportes.Dispose();
            }
        }
        private void rptPDF(String Reporte, Int32 IdProyecto, string Tipo, Int32 Ejercicio, string Usuario)
        {
            try
            {
             
                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, IdProyecto);
                report.SetParameterValue(1, Tipo);
                report.SetParameterValue(2, Ejercicio);
                report.SetParameterValue(3, Usuario);
                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                //connectionInfo.DatabaseName = "pifi";
                connectionInfo.UserID = "pifi";
                connectionInfo.Password = "dsia2014";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "ProyectosPIFI");

            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                CR_Reportes.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_Reportes.Dispose();
            }
        }
        private void rptPDF_Proyectos(String Reporte, Int32 IdProyecto, Int32 Ejercicio)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, Ejercicio);
                report.SetParameterValue(1, IdProyecto);
                report.PrintOptions.PaperSize = PaperSize.PaperLegal;
                connectionInfo.ServerName = "dsia";
                //connectionInfo.DatabaseName = "pifi";
                connectionInfo.UserID = "pifi";
                connectionInfo.Password = "dsia2014";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "ProyectosPIFI");

            }
            catch (Exception ex)
            {

            }
            finally
            {
                CR_Reportes.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_Reportes.Dispose();
            }
        }
        private void rptPDF_RelacionFacturas(String Reporte, Int32 IdMovimiento)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, IdMovimiento);
                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                //connectionInfo.DatabaseName = "pifi";
                connectionInfo.UserID = "pifi";
                connectionInfo.Password = "dsia2014";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "ProyectosPIFI");

            }
            catch (Exception ex)
            {

            }
            finally
            {
                CR_Reportes.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_Reportes.Dispose();
            }
        }
        private void rptPDF_RelacionChequesBMS(String Reporte, Int32 Ejercicio)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, Ejercicio);
                
                report.PrintOptions.PaperSize = PaperSize.PaperLegal;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "pifi";
                connectionInfo.Password = "dsia2014";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "ProyectosPIFI");

            }
            catch (Exception ex)
            {

            }
            finally
            {
                CR_Reportes.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_Reportes.Dispose();
            }
        }
        private void rptPDF_RelacionChequesBMS_x_Programa(String Reporte, Int32 Ejercicio, string programa)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, Ejercicio);
                report.SetParameterValue(1, programa);
                report.PrintOptions.PaperSize = PaperSize.PaperLegal;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "pifi";
                connectionInfo.Password = "dsia2014";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "ProyectosPIFI");

            }
            catch (Exception ex)
            {

            }
            finally
            {
                CR_Reportes.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_Reportes.Dispose();
            }
        }
        private void rptPDF_Cheques_x_Mes(String Reporte, Int32 Ejercicio, string Programa)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, Ejercicio);
                report.SetParameterValue(1, Programa);
                report.PrintOptions.PaperSize = PaperSize.PaperLegal;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "pifi";
                connectionInfo.Password = "dsia2014";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "ProyectosPIFI");

            }
            catch (Exception ex)
            {

            }
            finally
            {
                CR_Reportes.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_Reportes.Dispose();
            }
        }
        private void rptPDF_Proyecto_x_BMS(String Reporte, Int32 Ejercicio, Int32 Proyecto)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, Ejercicio);
                report.SetParameterValue(1, Proyecto);
                report.PrintOptions.PaperSize = PaperSize.PaperLegal;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "pifi";
                connectionInfo.Password = "dsia2014";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "ProyectosPIFI");

            }
            catch (Exception ex)
            {

            }
            finally
            {
                CR_Reportes.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_Reportes.Dispose();
            }
        }
        private void rptPDF_Resumen_Saldos_Proy(String Reporte, Int32 Id_Proyecto)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, Id_Proyecto);
                report.PrintOptions.PaperSize = PaperSize.PaperLegal;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "pifi";
                connectionInfo.Password = "dsia2014";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "ProyectosPIFI");

            }
            catch (Exception ex)
            {

            }
            finally
            {
                CR_Reportes.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_Reportes.Dispose();
            }
        }
        private void rptPDF_Cheques_del_BMS(String Reporte, Int32 Id_Bms)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, Id_Bms);
                report.PrintOptions.PaperSize = PaperSize.PaperLegal;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "pifi";
                connectionInfo.Password = "dsia2014";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "ProyectosPIFI");

            }
            catch (Exception ex)
            {

            }
            finally
            {
                CR_Reportes.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_Reportes.Dispose();
            }
        }
        private void rptPDF_Poliza(String Reporte, Int32 IdMovimiento)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, IdMovimiento);
                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                //connectionInfo.DatabaseName = "pifi";
                connectionInfo.UserID = "pifi";
                connectionInfo.Password = "dsia2014";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "ProyectosPIFI");

            }
            catch (Exception ex)
            {

            }
            finally
            {
                CR_Reportes.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_Reportes.Dispose();
            }
        }
        private void rptExcelBMS(String Reporte, Int32 Ejercicio, string Programa)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, Ejercicio);
                report.SetParameterValue(1, Programa);
                report.PrintOptions.PaperSize = PaperSize.PaperLegal;
                connectionInfo.ServerName = "dsia";
                //connectionInfo.DatabaseName = "pifi";
                connectionInfo.UserID = "pifi";
                connectionInfo.Password = "dsia2014";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, false, "ProyectosPIFI");

            }
            catch (Exception ex)
            {

            }
            finally
            {
                CR_Reportes.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_Reportes.Dispose();
                //clsRepPolizayCheque cheque = new clsRepPolizayCheque();
                //cheque.ActualizaStatusCheque(IdMovimiento, lblMsgError);
            }
            
        }
        private void rptCheque(String Reporte, Int32 IdMovimiento)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, IdMovimiento);
                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                //connectionInfo.DatabaseName = "pifi";
                connectionInfo.UserID = "pifi";
                connectionInfo.Password = "dsia2014";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.Excel, Response, false, "ProyectosPIFI");

            }
            catch (Exception ex)
            {

            }
            finally
            {
                CR_Reportes.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_Reportes.Dispose();
                //clsRepPolizayCheque cheque = new clsRepPolizayCheque();
                //cheque.ActualizaStatusCheque(IdMovimiento, lblMsgError);
            }

        }
        private void rptMovtosTraspasos(String Reporte, Int32 Ejercicio, string Programa)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, Ejercicio);
                report.SetParameterValue(1, Programa);
                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                //connectionInfo.DatabaseName = "pifi";
                connectionInfo.UserID = "pifi";
                connectionInfo.Password = "dsia2014";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "ProyectosPIFI");

            }
            catch (Exception ex)
            {

            }
            finally
            {
                CR_Reportes.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_Reportes.Dispose();
            }
        }        
        private void rptPDF_SaldosComprometidos(String Reporte, Int32 Ejercicio, string Programa)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, Ejercicio);
                report.SetParameterValue(1, Programa);
                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "pifi";
                connectionInfo.Password = "dsia2014";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "ProyectosPIFI");

            }
            catch (Exception ex)
            {

            }
            finally
            {
                CR_Reportes.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_Reportes.Dispose();
            }
        }
        private void rptPDF_ProyectosMeta(String Reporte, Int32 Ejercicio, string Programa)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, Ejercicio);
                report.SetParameterValue(1, Programa);
                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "pifi";
                connectionInfo.Password = "dsia2014";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "ProyectosPIFI");

            }
            catch (Exception ex)
            {

            }
            finally
            {
                CR_Reportes.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_Reportes.Dispose();
            }
        }
        private void rptPDF_Reintegros(String Reporte, Int32 Ejercicio, string Programa)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, Ejercicio);
                report.SetParameterValue(1, Programa);
                report.PrintOptions.PaperSize = PaperSize.PaperLegal;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "pifi";
                connectionInfo.Password = "dsia2014";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "ProyectosPIFI");

            }
            catch (Exception ex)
            {

            }
            finally
            {
                CR_Reportes.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_Reportes.Dispose();
            }
        }
        private void rptPDF_SaldosComprometidos_Detalle(String Reporte, Int32 Ejercicio)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, Ejercicio);
                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "pifi";
                connectionInfo.Password = "dsia2014";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "ProyectosPIFI");

            }
            catch (Exception ex)
            {

            }
            finally
            {
                CR_Reportes.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_Reportes.Dispose();
            }
        }
        private void rptPDF_ChequesporUsuario(String Reporte, Int32 Ejercicio, String Usuario , string Programa)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, Ejercicio);
                report.SetParameterValue(1, Usuario);
                report.SetParameterValue(2, Programa);
                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "pifi";
                connectionInfo.Password = "dsia2014";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "ProyectosPIFI");

            }
            catch (Exception ex)
            {

            }
            finally
            {
                CR_Reportes.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_Reportes.Dispose();
            }
        }
        private void rptPDF_Observaciones(String Reporte, Int32 Ejercicio, String Usuario)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, Ejercicio);
                report.SetParameterValue(1, Usuario);
                report.PrintOptions.PaperSize = PaperSize.PaperLegal;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "pifi";
                connectionInfo.Password = "dsia2014";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "ProyectosPIFI");

            }
            catch (Exception ex)
            {

            }
            finally
            {
                CR_Reportes.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_Reportes.Dispose();
            }
        }
        //private void rptVisor(String FechaIn, String FechaFi)
        //{
        //    try
        //    {
               
        //        ConnectionInfo connectionInfo = new ConnectionInfo();
        //        p = new System.Web.UI.Page();
        //        report.Load(p.Server.MapPath("~") + "\\Reportes\\Reporte_FichaEmitida.rpt");
        //        report.SetParameterValue(0, FechaIn);
        //        report.SetParameterValue(1, FechaFi);
        //        report.PrintOptions.PaperSize = PaperSize.PaperLegal;
        //        connectionInfo.ServerName = "dsia";
        //        connectionInfo.UserID = "ingresos";
        //        connectionInfo.Password = "unach09";
        //        SetDBLogonForReport(connectionInfo, report);
        //        //CR_Reportes.ReportSource = report;

                
        //    }
        //    catch (Exception ex)
        //    {
                
        //    }
        //    finally
        //    {
        //        CR_Reportes.ReportSource = report;
        //        report.Close();
        //        report.Dispose();
        //        CR_Reportes.Dispose();
        //    }
        //}
        private void SetDBLogonForReport(ConnectionInfo connectionInfo, ReportDocument reportDocument)
        {
            try 
            {
                Tables tables = reportDocument.Database.Tables;

                foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
                {
                    TableLogOnInfo tableLogonInfo = table.LogOnInfo;
                    tableLogonInfo.ConnectionInfo = connectionInfo;
                    table.ApplyLogOnInfo(tableLogonInfo);
                }

            }catch(Exception ex)
            {
            }
        }
    }
