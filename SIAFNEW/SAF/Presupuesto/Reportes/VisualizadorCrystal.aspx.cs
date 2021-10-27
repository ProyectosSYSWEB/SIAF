using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;


namespace SAF.Presupuesto.Reportes
{    public partial class VisualizadorCrystal : System.Web.UI.Page
    {

        private ReportDocument report = new ReportDocument();
        private System.Web.UI.Page p;
        ConnectionInfo connectionInfo = new ConnectionInfo();
        string Tipo;
        String Reporte = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            rptVisor();
        }
        private void reportes_dir()
        {
            p = new System.Web.UI.Page();
            string Ruta = p.Server.MapPath("~") + "\\" + Reporte;
            report.Load(p.Server.MapPath("~") + "\\" + Reporte);

        }
        private void rptVisor()
        {
            try
            {

                int Ejercicio = Convert.ToInt32(Request.QueryString["Ejercicio"]);
                string CentroContable = Convert.ToString(Request.QueryString["CentroContable"]);
                string Dependencia = Convert.ToString(Request.QueryString["Dependencia"]);
                string Dependencia_F = Convert.ToString(Request.QueryString["Dependencia_F"]);
                string MesIni = Convert.ToString(Request.QueryString["MesIni"]);
                string MesFin = Convert.ToString(Request.QueryString["MesFin"]);
                string Tipo_p = Convert.ToString(Request.QueryString["Tipo_p"]);
                string Cierre = Convert.ToString(Request.QueryString["Cierre"]);
                string Status = Convert.ToString(Request.QueryString["Status"]);
                string Id = Convert.ToString(Request.QueryString["Id"]);
                string Tipo_V = Convert.ToString(Request.QueryString["Tipo_V"]);
                string SuperTipo = Convert.ToString(Request.QueryString["SuperTipo"]);
                string TipoDoc = Convert.ToString(Request.QueryString["TipoDoc"]);
                string Fuente = Convert.ToString(Request.QueryString["Fuente"]);
                string Proyecto = Convert.ToString(Request.QueryString["Proyecto"]);
                string Capitulo = Convert.ToString(Request.QueryString["Capitulo"]);
                string Ministrable = Convert.ToString(Request.QueryString["Ministrable"]);
                string Nomina = Convert.ToString(Request.QueryString["Nomina"]);
                string Semestre = Convert.ToString(Request.QueryString["Semestre"]);
                string Prima_Vacacional = Convert.ToString(Request.QueryString["Prima_V"]);
                string Aguinaldo = Convert.ToString(Request.QueryString["aguinaldo"]);
                string ajuste_Calendario = Convert.ToString(Request.QueryString["Ajuste_C"]);
                string Issste = Convert.ToString(Request.QueryString["Issste"]);
                string Fovissste = Convert.ToString(Request.QueryString["Fovissste"]);
                string Sar = Convert.ToString(Request.QueryString["Sar"]);
                string Meses = Convert.ToString(Request.QueryString["Meses"]);
                string Mayor = Convert.ToString(Request.QueryString["Mayor"]);
                string Subprograma = Convert.ToString(Request.QueryString["Subprograma"]);
                string Partida = Convert.ToString(Request.QueryString["Partida"]);
                string Evento = Convert.ToString(Request.QueryString["Evento"]);
                string SubTipoDocumento = Convert.ToString(Request.QueryString["SubTipoDocumento"]);

                Tipo = Convert.ToString(Request.QueryString["Tipo"]);
                string caseSwitch = Tipo;
                switch (caseSwitch)
                {
                    case "RP-001":
                        Reporte = "Presupuesto\\Reportes\\RPT-001.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Id); reporte_PDF();
                        break;
                    case "RP-002":
                        Reporte = "Presupuesto\\Reportes\\RPT-002.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Id); reporte_PDF();
                        break;
                    case "RP-003":
                        Reporte = "Presupuesto\\Reportes\\RPT-003.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Id); reporte_PDF();
                        break;
                    case "RP-PRESUP_MIN_DET":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_MIN_DET.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Id); 
                        reporte_PDF();
                        break;
                    case "RP-LoteM":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_LOTEM.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, MesIni); report.SetParameterValue(2, MesFin);
                        report.SetParameterValue(3, TipoDoc); report.SetParameterValue(4, Status); report.SetParameterValue(5, Ejercicio);
                        reporte_PDF();
                        break;
                    case "RP-LoteC":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_LOTEC.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, MesIni); report.SetParameterValue(2, MesFin);
                        report.SetParameterValue(3, Status); report.SetParameterValue(4, Ejercicio); report.SetParameterValue(5, Evento);
                        report.SetParameterValue(6, SubTipoDocumento);
                        reporte_PDF();
                        break;
                    case "RP-LoteA":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_LOTEA.rpt";
                        reportes_dir();
                       report.SetParameterValue(0, Dependencia);  report.SetParameterValue(1, MesIni); report.SetParameterValue(2, MesFin);
                        report.SetParameterValue(3, TipoDoc); report.SetParameterValue(4, Status); report.SetParameterValue(5, Ejercicio);
                        reporte_PDF();
                        break;
                    case "RP-EJERCIDO":
                        Reporte = "Presupuesto\\Reportes\\RPT-Ejercido.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Fuente); report.SetParameterValue(2, Capitulo); report.SetParameterValue(3, Ministrable); report.SetParameterValue(4, Dependencia); report.SetParameterValue(5, Dependencia_F); reporte_PDF();

                        break;
                    case "RP-AUMENTO":
                        Reporte = "Presupuesto\\Reportes\\RPT-Aumento.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Fuente); report.SetParameterValue(2, Capitulo); report.SetParameterValue(3, Ministrable); report.SetParameterValue(4, Dependencia); report.SetParameterValue(5, Dependencia_F); reporte_PDF();

                        break;
                    case "RP-AUTORIZADO":
                        Reporte = "Presupuesto\\Reportes\\RPT-Autorizado.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Fuente); report.SetParameterValue(2, Capitulo); report.SetParameterValue(3, Ministrable); report.SetParameterValue(4, Dependencia); report.SetParameterValue(5, Dependencia_F); reporte_PDF();

                        break;
                    case "RP-MODIFICADO":
                        Reporte = "Presupuesto\\Reportes\\RPT-Modificado.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Fuente); report.SetParameterValue(2, Capitulo); report.SetParameterValue(3, Ministrable); report.SetParameterValue(4, Dependencia); report.SetParameterValue(5, Dependencia_F); reporte_PDF();

                        break;
                    case "RP-DISMINUCION":
                        Reporte = "Presupuesto\\Reportes\\RPT-Disminucion.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Fuente); report.SetParameterValue(2, Capitulo); report.SetParameterValue(3, Ministrable); report.SetParameterValue(4, Dependencia); report.SetParameterValue(5, Dependencia_F); reporte_PDF();
                        break;
                    case "RP-COMPROMETIDO":
                        Reporte = "Presupuesto\\Reportes\\RPT-Comprometido.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Fuente); report.SetParameterValue(2, Capitulo); report.SetParameterValue(3, Ministrable); report.SetParameterValue(4, Dependencia); report.SetParameterValue(5, Dependencia_F); reporte_PDF();
                        break;
                    case "RP-XMINISTRAR":
                        Reporte = "Presupuesto\\Reportes\\RPT-Xministrar.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Fuente); report.SetParameterValue(2, Capitulo); report.SetParameterValue(3, Ministrable); report.SetParameterValue(4, Dependencia); report.SetParameterValue(5, Dependencia_F); reporte_PDF();
                        break;
                    case "RP-MINISTRADO":
                        Reporte = "Presupuesto\\Reportes\\RPT-Ministrado.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Fuente); report.SetParameterValue(2, Capitulo); report.SetParameterValue(3, Ministrable); report.SetParameterValue(4, Dependencia); report.SetParameterValue(5, Dependencia_F); reporte_PDF();
                        break;
                    case "RP-XEJERCER":
                        Reporte = "Presupuesto\\Reportes\\RPT-Xejercer.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Fuente); report.SetParameterValue(2, Capitulo); report.SetParameterValue(3, Ministrable); report.SetParameterValue(4, Dependencia); report.SetParameterValue(5, Dependencia_F); reporte_PDF();
                        break;
                    case "RP-EJERCIDO_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-Ejercido.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Fuente); report.SetParameterValue(2, Capitulo); report.SetParameterValue(3, Ministrable); report.SetParameterValue(4, Dependencia); report.SetParameterValue(5, Dependencia_F); reporte_XLS();

                        break;
                    case "RP-AUMENTO_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-Aumento.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Fuente); report.SetParameterValue(2, Capitulo); report.SetParameterValue(3, Ministrable); report.SetParameterValue(4, Dependencia); report.SetParameterValue(5, Dependencia_F); reporte_XLS();

                        break;
                    case "RP-AUTORIZADO_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-Autorizado.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Fuente); report.SetParameterValue(2, Capitulo); report.SetParameterValue(3, Ministrable); report.SetParameterValue(4, Dependencia); report.SetParameterValue(5, Dependencia_F); reporte_XLS();

                        break;
                    case "RP-MODIFICADO_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-Modificado.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Fuente); report.SetParameterValue(2, Capitulo); report.SetParameterValue(3, Ministrable); report.SetParameterValue(4, Dependencia); report.SetParameterValue(5, Dependencia_F); reporte_XLS();

                        break;
                    case "RP-DISMINUCION_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-Disminucion.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Fuente); report.SetParameterValue(2, Capitulo); report.SetParameterValue(3, Ministrable); report.SetParameterValue(4, Dependencia); report.SetParameterValue(5, Dependencia_F); reporte_XLS();
                        break;
                    case "RP-COMPROMETIDO_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-Comprometido.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Fuente); report.SetParameterValue(2, Capitulo); report.SetParameterValue(3, Ministrable); report.SetParameterValue(4, Dependencia); report.SetParameterValue(5, Dependencia_F); reporte_XLS();
                        break;
                    case "RP-XMINISTRAR_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-Xministrar.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Fuente); report.SetParameterValue(2, Capitulo); report.SetParameterValue(3, Ministrable); report.SetParameterValue(4, Dependencia); report.SetParameterValue(5, Dependencia_F); reporte_XLS();
                        break;
                    case "RP-MINISTRADO_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-Ministrado.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Fuente); report.SetParameterValue(2, Capitulo); report.SetParameterValue(3, Ministrable); report.SetParameterValue(4, Dependencia); report.SetParameterValue(5, Dependencia_F); reporte_XLS();
                        break;
                    case "RP-XEJERCER_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-Xejercer.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Fuente); report.SetParameterValue(2, Capitulo); report.SetParameterValue(3, Ministrable); report.SetParameterValue(4, Dependencia); report.SetParameterValue(5, Dependencia_F); reporte_XLS();
                        break;
                    case "RP-007":
                        Reporte = "Presupuesto\\Reportes\\RPT-007.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Nomina); report.SetParameterValue(2, Tipo_p); report.SetParameterValue(3, Status); reporte_PDFDPP();
                        break;
                    case "RP-007XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-007.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Nomina); report.SetParameterValue(2, Tipo_p); report.SetParameterValue(3, Status); reporte_XLSDPP();
                        break;
                    case "RP-008":
                        Reporte = "Presupuesto\\Reportes\\RPT-008.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Nomina); report.SetParameterValue(2, Tipo_p); report.SetParameterValue(3, Status); reporte_PDFDPP();
                        break;
                    case "RP-008XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-008.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Nomina); report.SetParameterValue(2, Tipo_p); report.SetParameterValue(3, Status); reporte_XLSDPP();
                        break;
                    case "RP-008-A":
                        Reporte = "Presupuesto\\Reportes\\RPT-008-A.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Nomina); report.SetParameterValue(2, Tipo_p); report.SetParameterValue(3, Status); reporte_PDFDPP();
                        break;
                    case "RP-008-CAL":
                        Reporte = "Presupuesto\\Reportes\\RPT-008-CAL.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio);  report.SetParameterValue(1, Tipo_p); report.SetParameterValue(2, Status); reporte_PDFDPP();
                        break;
                    case "RP-009-1":
                        Reporte = "Presupuesto\\Reportes\\RPT-009-1.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); reporte_PDFDPP();
                        break;
                    case "RP-012":
                        Reporte = "Presupuesto\\Reportes\\RPT-012-CAL.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Tipo_p); reporte_PDFDPP();
                        break;
                    case "RP-012XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-012-CAL.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Tipo_p); reporte_XLSDPP();
                        break;
                    case "RP-012GRAF":
                        Reporte = "Presupuesto\\Reportes\\RPT-012-GRAF.rpt";
                        reportes_dir();
                        reporte_PDFDPP();
                        break;
                    case "RP-009-2":
                        Reporte = "Presupuesto\\Reportes\\RPT-009-2.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); reporte_PDFDPP();
                        break;
                    case "RP-004XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-004.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Tipo_p); report.SetParameterValue(2, Status); reporte_XLSDPP();
                        break;
                    case "RP-004":
                        Reporte = "Presupuesto\\Reportes\\RPT-004.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Tipo_p); report.SetParameterValue(2, Status); reporte_PDFDPP();
                        break;
                    case "RP-005":
                        Reporte = "Presupuesto\\Reportes\\RPT-005.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Semestre); reporte_PDFDPP();
                        break;
                    case "RP-006":
                        Reporte = "Presupuesto\\Reportes\\RPT-006.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia);  reporte_PDFDPP();
                        break;
                    case "RP-013":
                        Reporte = "Presupuesto\\Reportes\\RPT-013.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Tipo_p); reporte_PDFDPP();
                        break;
                    case "RP-014":
                        Reporte = "Presupuesto\\Reportes\\RPT-014.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Semestre); report.SetParameterValue(1, Dependencia); reporte_PDFDPP();
                        break;
                    case "RP-014XLSX":
                        Reporte = "Presupuesto\\Reportes\\RPT-014.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Semestre); report.SetParameterValue(1, Dependencia); reporte_XLSDPP();
                        break;
                    case "RP-015":
                        Reporte = "Presupuesto\\Reportes\\RPT-015.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Semestre); report.SetParameterValue(1, Dependencia); reporte_PDFDPP();
                        break;
                    case "RP-016":
                        Reporte = "Presupuesto\\Reportes\\RPT-016.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Semestre); report.SetParameterValue(1, Dependencia); reporte_PDFDPP();
                        break;
                    case "RP-017":
                        Reporte = "Presupuesto\\Reportes\\RPT-017.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Semestre); report.SetParameterValue(1, Dependencia); reporte_PDFDPP();
                        break;
                    case "RP-018":
                        Reporte = "Presupuesto\\Reportes\\RPT-018.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Semestre); report.SetParameterValue(1, Dependencia); report.SetParameterValue(2, Meses);
                        report.SetParameterValue(3, Prima_Vacacional); report.SetParameterValue(4, Aguinaldo); report.SetParameterValue(5, ajuste_Calendario);
                        report.SetParameterValue(6, Issste); report.SetParameterValue(7, Fovissste); report.SetParameterValue(8, Sar);
                        //reporte_XLSDPP();
                        reporte_PDFDPP();
                        break;
                    case "RP-019":
                        Reporte = "Presupuesto\\Reportes\\RPT-019.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Semestre); report.SetParameterValue(1, Dependencia); report.SetParameterValue(2, Meses);
                        report.SetParameterValue(3, Prima_Vacacional); report.SetParameterValue(4, Aguinaldo); report.SetParameterValue(5, ajuste_Calendario);
                        report.SetParameterValue(6, Issste); report.SetParameterValue(7, Fovissste); report.SetParameterValue(8, Sar);
                        reporte_PDFDPP();
                        break;
                    case "RP-015P":
                        Reporte = "Presupuesto\\Reportes\\RPT-015P.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Semestre); report.SetParameterValue(1, Dependencia); reporte_PDFDPP();
                        break;
                    case "RP-016P":
                        Reporte = "Presupuesto\\Reportes\\RPT-016P.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Semestre); report.SetParameterValue(1, Dependencia); reporte_PDFDPP();
                        break;
                    case "RP-017P":
                        Reporte = "Presupuesto\\Reportes\\RPT-017P.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Semestre); report.SetParameterValue(1, Dependencia); reporte_PDFDPP();
                        break;
                    case "RP-018P":
                        Reporte = "Presupuesto\\Reportes\\RPT-018P.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Semestre); report.SetParameterValue(1, Dependencia); report.SetParameterValue(2, Meses);
                        report.SetParameterValue(3, Prima_Vacacional); report.SetParameterValue(4, Aguinaldo); report.SetParameterValue(5, ajuste_Calendario);
                        report.SetParameterValue(6, Issste); report.SetParameterValue(7, Fovissste); report.SetParameterValue(8, Sar);
                        //reporte_XLSDPP();
                        reporte_PDFDPP();
                        break;
                    case "RP-019P":
                        Reporte = "Presupuesto\\Reportes\\RPT-019P.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Semestre); report.SetParameterValue(1, Dependencia); report.SetParameterValue(2, Meses);
                        report.SetParameterValue(3, Prima_Vacacional); report.SetParameterValue(4, Aguinaldo); report.SetParameterValue(5, ajuste_Calendario);
                        report.SetParameterValue(6, Issste); report.SetParameterValue(7, Fovissste); report.SetParameterValue(8, Sar);
                        reporte_PDFDPP();
                        break;
                    case "RP-MOVIMIENTOS":
                        Reporte = "Presupuesto\\Reportes\\RPT-Mov_P.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Id); 
                        reporte_PDFDPP();
                        break;
                    case "RP-TITULARES":
                        Reporte = "Presupuesto\\Reportes\\RPT-Titulares.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Id);
                        reporte_PDFDPP();
                        break;
                    case "RP-PRESUP_COMPARATIVO_CUENTA":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_COMPARATIVO_CUENTA.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, CentroContable); report.SetParameterValue(2, Mayor.Substring(0,4));
                        report.SetParameterValue(3, MesIni); report.SetParameterValue(4, MesFin); report.SetParameterValue(5, Mayor.Substring(4,1));
                        reporte_PDF();
                        break;
                    case "RP-PRESUP_COMPARATIVO_CUENTA_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_COMPARATIVO_CUENTA.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, CentroContable); report.SetParameterValue(2, Mayor.Substring(0, 4));
                        report.SetParameterValue(3, MesIni); report.SetParameterValue(4, MesFin); report.SetParameterValue(5, Mayor.Substring(4, 1));
                        reporte_XLS();
                        break;
                    case "RP-PRESUP_COMPARATIVO_CAP":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_COMPARATIVO_CAPITULO.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, CentroContable); 
                        report.SetParameterValue(2, MesIni); report.SetParameterValue(3, MesFin); report.SetParameterValue(4,Capitulo);
                        reporte_PDF();
                        break;
                    case "RP-PRESUP_COMPARATIVO_CAP_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_COMPARATIVO_CAPITULO.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, CentroContable);
                        report.SetParameterValue(2, MesIni); report.SetParameterValue(3, MesFin); report.SetParameterValue(4, Capitulo);
                        reporte_XLS();
                        break;
                    case "RP-PRESUP_COMPARATIVO_CAP_A":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_COMPARATIVO_CAPITULO_ANALITICO.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, CentroContable);
                        report.SetParameterValue(2, MesIni); report.SetParameterValue(3, MesFin); report.SetParameterValue(4, Capitulo);
                        reporte_PDF();
                        break;
                    case "RP-PRESUP_COMPARATIVO_CAP_A_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_COMPARATIVO_CAPITULO_ANALITICO.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, CentroContable);
                        report.SetParameterValue(2, MesIni); report.SetParameterValue(3, MesFin); report.SetParameterValue(4, Capitulo);
                        reporte_XLS();
                        break;
                    case "RP-PRESUP_COMPARATIVO_GRUPO":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_COMPARATIVO_GRUPO.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, CentroContable);
                        report.SetParameterValue(2, MesIni); report.SetParameterValue(3, MesFin); report.SetParameterValue(4, Mayor);
                        reporte_PDF();
                        break;
                    case "RP-PRESUP_COMPARATIVO_GRUPO_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_COMPARATIVO_GRUPO.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, CentroContable);
                        report.SetParameterValue(2, MesIni); report.SetParameterValue(3, MesFin); report.SetParameterValue(4, Mayor);
                        reporte_XLS();
                        break;
                    case "RP-PRESUP_COMPARATIVO_GRUPO_A":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_COMPARATIVO_GRUPO_ANALITICO.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, CentroContable);
                        report.SetParameterValue(2, MesIni); report.SetParameterValue(3, MesFin); report.SetParameterValue(4, Mayor);
                        reporte_PDF();
                        break;
                    case "RP-PRESUP_COMPARATIVO_GRUPO_A_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_COMPARATIVO_GRUPO_ANALITICO.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, CentroContable);
                        report.SetParameterValue(2, MesIni); report.SetParameterValue(3, MesFin); report.SetParameterValue(4, Mayor);
                        reporte_XLS();
                        break;
                    case "RP-DOCUMENTOS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_GRID_DOCS.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, MesIni); report.SetParameterValue(2, MesFin);
                        report.SetParameterValue(3, TipoDoc); report.SetParameterValue(4, SuperTipo); report.SetParameterValue(5, Status);
                        report.SetParameterValue(6, Ejercicio); report.SetParameterValue(7, Evento);
                        reporte_PDF();
                        break;
                    case "RP-DOCUMENTOS_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_GRID_DOCS.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, MesIni); report.SetParameterValue(2, MesFin);
                        report.SetParameterValue(3, TipoDoc); report.SetParameterValue(4, SuperTipo); report.SetParameterValue(5, Status);
                        report.SetParameterValue(6, Ejercicio); report.SetParameterValue(7, Evento);
                        reporte_XLS();
                        break;
                    case "RP-LISTADO_CEDULAS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP021A.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, CentroContable); report.SetParameterValue(1, MesIni);
                        report.SetParameterValue(2, Status); report.SetParameterValue(3, TipoDoc); report.SetParameterValue(4, Ejercicio);
                        reporte_PDF();
                        break;
                    case "RP-LISTADO_CEDULAS_F":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP021A_FF.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, CentroContable); report.SetParameterValue(1, MesIni);
                        report.SetParameterValue(2, Status); report.SetParameterValue(3, TipoDoc); report.SetParameterValue(4, Ejercicio); report.SetParameterValue(5, Fuente);
                        reporte_PDF();
                        break;
                    case "RP-LISTADO_CEDULAS_P":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP021A_PARTIDA.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, CentroContable); report.SetParameterValue(1, MesIni);
                        report.SetParameterValue(2, Status); report.SetParameterValue(3, TipoDoc); report.SetParameterValue(4, Ejercicio); report.SetParameterValue(5, Partida);
                        reporte_PDF();
                        break;
                    case "RP-LISTADO_CEDULAS_Y":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP021A_PROYECTO.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, CentroContable); report.SetParameterValue(1, MesIni);
                        report.SetParameterValue(2, Status); report.SetParameterValue(3, TipoDoc); report.SetParameterValue(4, Ejercicio); report.SetParameterValue(5, Proyecto);
                        reporte_PDF();
                        break;
                    case "RP-LISTADO_CEDULAS_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP021A.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, CentroContable); report.SetParameterValue(1, MesIni);
                        report.SetParameterValue(2, Status); report.SetParameterValue(3, TipoDoc); report.SetParameterValue(4, Ejercicio);
                        reporte_XLS();
                        break;
                    case "RP-LISTADO_CEDULAS_F_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP021A_FF.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, CentroContable); report.SetParameterValue(1, MesIni);
                        report.SetParameterValue(2, Status); report.SetParameterValue(3, TipoDoc); report.SetParameterValue(4, Ejercicio); report.SetParameterValue(5, Fuente);
                        reporte_XLS();
                        break;
                    case "RP-LISTADO_CEDULAS_P_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP021A_PARTIDA.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, CentroContable); report.SetParameterValue(1, MesIni);
                        report.SetParameterValue(2, Status); report.SetParameterValue(3, TipoDoc); report.SetParameterValue(4, Ejercicio); report.SetParameterValue(5, Partida);
                        reporte_XLS();
                        break;
                    case "RP-LISTADO_CEDULAS_Y_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP021A_PROYECTO.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, CentroContable); report.SetParameterValue(1, MesIni);
                        report.SetParameterValue(2, Status); report.SetParameterValue(3, TipoDoc); report.SetParameterValue(4, Ejercicio); report.SetParameterValue(5, Proyecto);
                        reporte_XLS();
                        break;
                    case "RP-PRESUP_RP008MD":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP008MD.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Capitulo); report.SetParameterValue(2, Fuente); report.SetParameterValue(3, Proyecto);
                        report.SetParameterValue(4, Ministrable); report.SetParameterValue(5, Ejercicio); report.SetParameterValue(6, MesIni);
                        reporte_PDF();
                        break;
                    case "RP-PRESUP_RP008MR":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP008MR.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Capitulo); report.SetParameterValue(2, Fuente); report.SetParameterValue(3, Proyecto);
                        report.SetParameterValue(4, Ministrable); report.SetParameterValue(5, Ejercicio); report.SetParameterValue(6, MesIni);
                        reporte_PDF();
                        break;
                    case "RP-PRESUP_RP008AD":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP008AD.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Capitulo); report.SetParameterValue(2, Fuente); report.SetParameterValue(3, Proyecto);
                        report.SetParameterValue(4, Ministrable); report.SetParameterValue(5, Ejercicio); report.SetParameterValue(6, MesIni);
                        reporte_PDF();
                        break;
                    case "RP-PRESUP_RP008AR":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP008AR.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Capitulo); report.SetParameterValue(2, Fuente); report.SetParameterValue(3, Proyecto);
                        report.SetParameterValue(4, Ministrable); report.SetParameterValue(5, Ejercicio); report.SetParameterValue(6, MesIni);
                        reporte_PDF();
                        break;
                    case "RP-PRESUP_RP008MD_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP008MD.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Capitulo); report.SetParameterValue(2, Fuente); report.SetParameterValue(3, Proyecto);
                        report.SetParameterValue(4, Ministrable); report.SetParameterValue(5, Ejercicio); report.SetParameterValue(6, MesIni);
                        reporte_XLS();
                        break;
                    case "RP-PRESUP_RP008MR_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP008MR.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Capitulo); report.SetParameterValue(2, Fuente); report.SetParameterValue(3, Proyecto);
                        report.SetParameterValue(4, Ministrable); report.SetParameterValue(5, Ejercicio); report.SetParameterValue(6, MesIni);
                        reporte_XLS();
                        break;
                    case "RP-PRESUP_RP008AD_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP008AD.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Capitulo); report.SetParameterValue(2, Fuente); report.SetParameterValue(3, Proyecto);
                        report.SetParameterValue(4, Ministrable); report.SetParameterValue(5, Ejercicio); report.SetParameterValue(6, MesIni);
                        reporte_XLS();
                        break;
                    case "RP-PRESUP_RP008AR_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP008AR.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Capitulo); report.SetParameterValue(2, Fuente); report.SetParameterValue(3, Proyecto);
                        report.SetParameterValue(4, Ministrable); report.SetParameterValue(5, Ejercicio); report.SetParameterValue(6, MesIni);
                        reporte_XLS();
                        break;
                    
                    case "RP-PRESUP_RP005MD":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP005MD.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Capitulo); report.SetParameterValue(2, Fuente); 
                        report.SetParameterValue(3, Ministrable); report.SetParameterValue(4, Ejercicio); report.SetParameterValue(5, MesIni);
                        reporte_PDF();
                        break;
                    case "RP-PRESUP_RP005MR":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP005MR.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Capitulo); report.SetParameterValue(2, Fuente);
                        report.SetParameterValue(3, Ministrable); report.SetParameterValue(4, Ejercicio); report.SetParameterValue(5, MesIni);
                        reporte_PDF();
                        break;
                    case "RP-PRESUP_RP005AD":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP005AD.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Capitulo); report.SetParameterValue(2, Fuente);
                        report.SetParameterValue(3, Ministrable); report.SetParameterValue(4, Ejercicio); report.SetParameterValue(5, MesIni);
                        reporte_PDF();
                        break;
                    case "RP-PRESUP_RP005AR":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP005AR.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Capitulo); report.SetParameterValue(2, Fuente);
                        report.SetParameterValue(3, Ministrable); report.SetParameterValue(4, Ejercicio); report.SetParameterValue(5, MesIni);
                        reporte_PDF();
                        break;
                    case "RP-PRESUP_RP005TD":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP005TD.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Capitulo); report.SetParameterValue(2, Fuente);
                        report.SetParameterValue(3, Ministrable); report.SetParameterValue(4, Ejercicio); report.SetParameterValue(5, MesIni);
                        reporte_PDF();
                        break;
                    case "RP-PRESUP_RP005TR":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP005TR.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Capitulo); report.SetParameterValue(2, Fuente);
                        report.SetParameterValue(3, Ministrable); report.SetParameterValue(4, Ejercicio); report.SetParameterValue(5, MesIni);
                        reporte_PDF();
                        break;
                    case "RP-PRESUP_RP005MD_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP005MD.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Capitulo); report.SetParameterValue(2, Fuente);
                        report.SetParameterValue(3, Ministrable); report.SetParameterValue(4, Ejercicio); report.SetParameterValue(5, MesIni);
                        reporte_XLS();
                        break;
                    case "RP-PRESUP_RP005MR_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP005MR.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Capitulo); report.SetParameterValue(2, Fuente);
                        report.SetParameterValue(3, Ministrable); report.SetParameterValue(4, Ejercicio); report.SetParameterValue(5, MesIni);
                        reporte_XLS();
                        break;
                    case "RP-PRESUP_RP005AD_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP005AD.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Capitulo); report.SetParameterValue(2, Fuente);
                        report.SetParameterValue(3, Ministrable); report.SetParameterValue(4, Ejercicio); report.SetParameterValue(5, MesIni);
                        reporte_XLS();
                        break;
                    case "RP-PRESUP_RP005AR_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP005AR.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Capitulo); report.SetParameterValue(2, Fuente);
                        report.SetParameterValue(3, Ministrable); report.SetParameterValue(4, Ejercicio); report.SetParameterValue(5, MesIni);
                        reporte_XLS();
                        break;
                    case "RP-PRESUP_RP005TD_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP005TD.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Capitulo); report.SetParameterValue(2, Fuente);
                        report.SetParameterValue(3, Ministrable); report.SetParameterValue(4, Ejercicio); report.SetParameterValue(5, MesIni);
                        reporte_XLS();
                        break;
                    case "RP-PRESUP_RP005TR_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP005TR.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Capitulo); report.SetParameterValue(2, Fuente);
                        report.SetParameterValue(3, Ministrable); report.SetParameterValue(4, Ejercicio); report.SetParameterValue(5, MesIni);
                        reporte_XLS();
                        break;
                    case "RP-PRESUP_RP002":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP002.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Capitulo); report.SetParameterValue(2, Fuente);
                        report.SetParameterValue(3, Ministrable); report.SetParameterValue(4, Ejercicio); report.SetParameterValue(5, TipoDoc);
                        report.SetParameterValue(6, Dependencia_F);
                        reporte_PDF();
                        break;
                    case "RP-PRESUP_RP002_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP002.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Capitulo); report.SetParameterValue(2, Fuente);
                        report.SetParameterValue(3, Ministrable); report.SetParameterValue(4, Ejercicio); report.SetParameterValue(5, TipoDoc);
                        report.SetParameterValue(6, Dependencia_F);
                        reporte_XLS();
                        break;
                    case "RP-PRESUP_RP004":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP004.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Capitulo); report.SetParameterValue(2, Ministrable);
                        report.SetParameterValue(3, Ejercicio); report.SetParameterValue(4, TipoDoc); report.SetParameterValue(5, Proyecto);
                        report.SetParameterValue(6, Dependencia_F);
                        reporte_PDF();
                        break;
                    case "RP-PRESUP_RP004_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP004.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Capitulo); report.SetParameterValue(2, Ministrable);
                        report.SetParameterValue(3, Ejercicio); report.SetParameterValue(4, TipoDoc); report.SetParameterValue(5, Proyecto);
                        report.SetParameterValue(6, Dependencia_F);
                        reporte_XLS();
                        break;
                    case "RP-PRESUP_RP012":
                        if(TipoDoc=="A")
                            Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP012A.rpt";
                        else
                            Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP012M.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Ejercicio); report.SetParameterValue(2, MesIni);
                        report.SetParameterValue(3, Capitulo); report.SetParameterValue(4, Fuente);
                        reporte_PDF();
                        break;
                    case "RP-PRESUP_RP012_XLS":
                        if (TipoDoc == "A")
                            Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP012A.rpt";
                        else
                            Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP012M.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Ejercicio); report.SetParameterValue(2, MesIni);
                        report.SetParameterValue(3, Capitulo); report.SetParameterValue(4, Fuente);
                        reporte_XLS();
                        break;
                    case "RP-PRESUP_RP019":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP019A.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, CentroContable); report.SetParameterValue(2, MesIni);
                        report.SetParameterValue(3, TipoDoc); 
                        reporte_PDF();
                        break;
                    case "RP-PRESUP_RP019_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP019A.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, CentroContable); report.SetParameterValue(2, MesIni);
                        report.SetParameterValue(3, TipoDoc);
                        reporte_XLS();
                        break;
                    case "RP-PRESUP_RP009A":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP009A.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Dependencia); report.SetParameterValue(2, Dependencia_F);
                        report.SetParameterValue(3, Capitulo); report.SetParameterValue(4, Fuente);
                        reporte_PDF();
                        break;
                    case "RP-PRESUP_RP009A_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP009A.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Dependencia); report.SetParameterValue(2, Dependencia_F);
                        report.SetParameterValue(3, Capitulo); report.SetParameterValue(4, Fuente);
                        reporte_XLS();
                        break;
                    case "RP-PRESUP_RP009B":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP009B.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Dependencia); report.SetParameterValue(2, Dependencia_F);
                        report.SetParameterValue(3, Capitulo); report.SetParameterValue(4, Fuente);
                        reporte_PDF();
                        break;
                    case "RP-PRESUP_RP009B_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP009B.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Dependencia); report.SetParameterValue(2, Dependencia_F);
                        report.SetParameterValue(3, Capitulo); report.SetParameterValue(4, Fuente);
                        reporte_XLS();
                        break;
                    case "RP-PRESUP_RP017A":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP017A.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, MesIni); report.SetParameterValue(2, CentroContable);
                        report.SetParameterValue(3, Dependencia); report.SetParameterValue(4, Dependencia_F); report.SetParameterValue(5, Fuente);
                        reporte_PDF();
                        break;
                    case "RP-PRESUP_RP017M":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP017M.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, MesIni); report.SetParameterValue(2, CentroContable);
                        report.SetParameterValue(3, Dependencia); report.SetParameterValue(4, Dependencia_F); report.SetParameterValue(5, Fuente);
                        reporte_PDF();
                        break;
                    case "RP-PRESUP_RP017A_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP017A.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, MesIni); report.SetParameterValue(2, CentroContable);
                        report.SetParameterValue(3, Dependencia); report.SetParameterValue(4, Dependencia_F); report.SetParameterValue(5, Fuente);
                        reporte_XLS();
                        break;
                    case "RP-PRESUP_RP017M_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP017M.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, MesIni); report.SetParameterValue(2, CentroContable);
                        report.SetParameterValue(3, Dependencia); report.SetParameterValue(4, Dependencia_F); report.SetParameterValue(5, Fuente);
                        reporte_XLS();
                        break;
                    case "RP-PRESUP_SP01":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_ER01.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Dependencia); report.SetParameterValue(2, MesIni.Substring(0,2)); report.SetParameterValue(3, MesFin.Substring(0, 2));
                        report.SetParameterValue(4, MesIni.Substring(2, 2)); report.SetParameterValue(5, MesFin.Substring(2, 2)); report.SetParameterValue(6, Capitulo); report.SetParameterValue(7, Fuente); report.SetParameterValue(8, Meses);
                        reporte_PDF();
                        break;
                    case "RP-PRESUP_SP02":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_ER02.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Dependencia); report.SetParameterValue(2, MesIni.Substring(0, 2)); report.SetParameterValue(3, MesFin.Substring(0, 2));
                        report.SetParameterValue(4, MesIni.Substring(2, 2)); report.SetParameterValue(5, MesFin.Substring(2, 2)); report.SetParameterValue(6, Capitulo); report.SetParameterValue(7, Fuente); report.SetParameterValue(8, Meses);
                        reporte_PDF();
                        break;

                    case "RP-PRESUP_SP04":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_ER04.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Dependencia); report.SetParameterValue(2, MesIni.Substring(0, 2)); report.SetParameterValue(3, MesFin.Substring(0, 2));
                        report.SetParameterValue(4, MesIni.Substring(2, 2)); report.SetParameterValue(5, MesFin.Substring(2, 2)); report.SetParameterValue(6, Capitulo); report.SetParameterValue(7, Fuente); report.SetParameterValue(8, Meses);
                        reporte_PDF();
                        break;
                    case "RP-PRESUP_SP05":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_ER05.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Dependencia); report.SetParameterValue(2, MesIni.Substring(0, 2)); report.SetParameterValue(3, MesFin.Substring(0, 2));
                        report.SetParameterValue(4, MesIni.Substring(2, 2)); report.SetParameterValue(5, MesFin.Substring(2, 2)); report.SetParameterValue(6, Capitulo); report.SetParameterValue(7, Fuente); report.SetParameterValue(8, Meses);
                        reporte_PDF();
                        break;
                    case "RP-PRESUP_SP01_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_ER01.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Dependencia); report.SetParameterValue(2, MesIni.Substring(0, 2)); report.SetParameterValue(3, MesFin.Substring(0, 2));
                        report.SetParameterValue(4, MesIni.Substring(2, 2)); report.SetParameterValue(5, MesFin.Substring(2, 2)); report.SetParameterValue(6, Capitulo); report.SetParameterValue(7, Fuente); report.SetParameterValue(8, Meses);
                        reporte_XLS();
                        break;
                    case "RP-PRESUP_SP02_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_ER02.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Dependencia); report.SetParameterValue(2, MesIni.Substring(0, 2)); report.SetParameterValue(3, MesFin.Substring(0, 2));
                        report.SetParameterValue(4, MesIni.Substring(2, 2)); report.SetParameterValue(5, MesFin.Substring(2, 2)); report.SetParameterValue(6, Capitulo); report.SetParameterValue(7, Fuente); report.SetParameterValue(8, Meses);
                        reporte_XLS();
                        break;
                    case "RP-PRESUP_SP04_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_ER04.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Dependencia); report.SetParameterValue(2, MesIni.Substring(0, 2)); report.SetParameterValue(3, MesFin.Substring(0, 2));
                        report.SetParameterValue(4, MesIni.Substring(2, 2)); report.SetParameterValue(5, MesFin.Substring(2, 2)); report.SetParameterValue(6, Capitulo); report.SetParameterValue(7, Fuente); report.SetParameterValue(8, Meses);
                        reporte_XLS();
                        break;
                    case "RP-PRESUP_SP05_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_ER05.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Dependencia); report.SetParameterValue(2, MesIni.Substring(0, 2)); report.SetParameterValue(3, MesFin.Substring(0, 2));
                        report.SetParameterValue(4, MesIni.Substring(2, 2)); report.SetParameterValue(5, MesFin.Substring(2, 2)); report.SetParameterValue(6, Capitulo); report.SetParameterValue(7, Fuente); report.SetParameterValue(8, Meses);
                        reporte_XLS();
                        break;
                    case "RP-PRESUP_RP003":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP003.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Capitulo); report.SetParameterValue(2, Subprograma);
                        report.SetParameterValue(3, Ejercicio); report.SetParameterValue(4, TipoDoc); report.SetParameterValue(5, Ministrable);
                        reporte_PDF();
                        break;
                    case "RP-PRESUP_RP003_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP003.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Capitulo); report.SetParameterValue(2, Subprograma);
                        report.SetParameterValue(3, Ejercicio); report.SetParameterValue(4, TipoDoc); report.SetParameterValue(5, Ministrable);
                        reporte_XLS();
                        break;
                    case "RP-PRESUP_RP030A":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP030A.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Capitulo); report.SetParameterValue(2, Ministrable);
                        report.SetParameterValue(3, Ejercicio); report.SetParameterValue(4, MesIni); report.SetParameterValue(5, Subprograma);
                        reporte_PDF();
                        break;
                    case "RP-PRESUP_RP030A_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP030A.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Capitulo); report.SetParameterValue(2, Ministrable);
                        report.SetParameterValue(3, Ejercicio); report.SetParameterValue(4, MesIni); report.SetParameterValue(5, Subprograma);
                        reporte_XLS();
                        break;
                    case "RP-PRESUP_RP030M":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP030M.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Capitulo); report.SetParameterValue(2, Ministrable);
                        report.SetParameterValue(3, Ejercicio); report.SetParameterValue(4, MesIni); report.SetParameterValue(5, Subprograma);
                        reporte_PDF();
                        break;
                    case "RP-PRESUP_RP030M_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_RP030M.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Capitulo); report.SetParameterValue(2, Ministrable);
                        report.SetParameterValue(3, Ejercicio); report.SetParameterValue(4, MesIni); report.SetParameterValue(5, Subprograma);
                        reporte_XLS();
                        break;
                    case "RP-PRESUP_DP01_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_DP01.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); 
                        reporte_XLS();
                        break;
                    case "RP-PRESUP_DET_CED_DERIVADA_XLS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_DET_CED_DERIVADA.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); 
                        reporte_XLS();
                        break;
                    case "RPT-UsuariosAdminUr":
                        Reporte = "Presupuesto\\Reportes\\RPT-UsuariosAdminUr.rpt";
                        reportes_dir();
                        reporte_PDF();
                        break;
                    case "RPT-UsuariosGral":
                        Reporte = "Presupuesto\\Reportes\\RPT-Usuarios.rpt";
                        reportes_dir();
                        reporte_PDF();
                        break;
                    case "RPT-PRESUP_UNV":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_UNV.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio); report.SetParameterValue(1, Id); report.SetParameterValue(2, Tipo_V);                                                
                        reporte_PDF();
                        break;
                    case "RPT-PRESUP_FUENTE_FIN":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_FUENTE_FIN.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio);
                        reporte_PDF();
                        break;
                    case "RPT-PRESUP_PROGRAMAS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_PROGRAMAS.rpt";
                        reportes_dir();
                        reporte_PDF();
                        break;
                    case "RPT-PRESUP_CAT_PARTIDAS_GASTO":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_CAT_PARTIDAS_GASTO.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio);
                        reporte_PDF();
                        break;
                    case "RPT-PRESUP_CCONTAB":
                        Reporte = "Presupuesto\\Reportes\\RPT_PRESUP_CCONTAB.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio);
                        reporte_PDF();
                        break;
                    case "RPT-PRESUP_DEPENDENCIAS":
                        Reporte = "Presupuesto\\Reportes\\RPT-PRESUP_DEPENDENCIAS.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Ejercicio);
                        reporte_PDF();
                        break;
                    case "RPT-Generales_Cedulas":
                        Reporte = "Presupuesto\\Reportes\\RPT-Generales_Cedulas.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Dependencia); report.SetParameterValue(1, Ejercicio); report.SetParameterValue(2, Id);
                        reporte_PDF();
                        break;
                    case "RPT-CP01_ADMIN":
                        Reporte = "Presupuesto\\Reportes\\RPT-CP01_ADMIN.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, MesIni); report.SetParameterValue(1, MesFin); report.SetParameterValue(2, Ejercicio);
                        reporte_PDF();
                        break;
                    case "RPT-CP07_ADMIN":
                        Reporte = "Presupuesto\\Reportes\\RPT-CP07_ADMIN.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, MesIni); report.SetParameterValue(1, MesFin); report.SetParameterValue(2, Ejercicio);
                        reporte_PDF();
                        break;
                    case "RPT-CP08_ADMIN":
                        Reporte = "Presupuesto\\Reportes\\RPT-CP08_ADMIN.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, MesIni); report.SetParameterValue(1, MesFin); report.SetParameterValue(2, Ejercicio);
                        reporte_PDF();
                        break;
                    case "RPT-CP09_ADMIN":
                        Reporte = "Presupuesto\\Reportes\\RPT-CP09_ADMIN.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, MesIni); report.SetParameterValue(1, MesFin); report.SetParameterValue(2, Ejercicio);
                        reporte_PDF();
                        break;
                    case "RPT-CP09nv2_ADMIN":
                        Reporte = "Presupuesto\\Reportes\\RPT-CP09nv2_ADMIN.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, MesIni); report.SetParameterValue(1, MesFin); report.SetParameterValue(2, Ejercicio);
                        reporte_PDF();
                        break;
                    case "RPT-CP09nv3_ADMIN":
                        Reporte = "Presupuesto\\Reportes\\RPT-CP09nv3_ADMIN";
                        reportes_dir();
                        report.SetParameterValue(0, MesIni); report.SetParameterValue(1, MesFin); report.SetParameterValue(2, Ejercicio);
                        reporte_PDF();
                        break;
                    case "RPT-CP09nv5_ADMIN":
                        Reporte = "Presupuesto\\Reportes\\RPT-CP09nv5_ADMIN.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, MesIni); report.SetParameterValue(1, MesFin); report.SetParameterValue(2, Ejercicio);
                        reporte_PDF();
                        break;
                    case "RPT-CPO2_ADMIN":
                        Reporte = "Presupuesto\\Reportes\\RPT-CPO2_ADMIN.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, MesIni); report.SetParameterValue(1, MesFin); report.SetParameterValue(2, Ejercicio);
                        reporte_PDF();
                        break;
                    case "RPT-ENTREGA-RECEPCION":
                        Reporte = "Presupuesto\\Reportes\\RPT-ENTREGA-RECEPCION.rpt";
                        reportes_dir();
                        report.SetParameterValue(0, Capitulo); report.SetParameterValue(1, Dependencia); report.SetParameterValue(2, Ejercicio); report.SetParameterValue(3, MesFin); report.SetParameterValue(4, MesIni); 
                        reporte_PDF();
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

                report.Close();
                report.Dispose();
                CR_Reportes.Dispose();
            }
        }
        private void reporte_PDFDPP()
        {
            report.PrintOptions.PaperSize = PaperSize.PaperLetter;
            connectionInfo.ServerName = "dsia";
            connectionInfo.UserID = "DPP";
            connectionInfo.Password = "ORACLE2018";
            SetDBLogonForReport(connectionInfo, report);
            report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, Tipo);
            CR_Reportes.ReportSource = report;

        }
        private void reporte_XLSDPP()
        {
            report.PrintOptions.PaperSize = PaperSize.PaperLetter;
            connectionInfo.ServerName = "dsia";
            connectionInfo.UserID = "DPP";
            connectionInfo.Password = "ORACLE2018";
            SetDBLogonForReport(connectionInfo, report);
            report.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, false, Tipo);
            CR_Reportes.ReportSource = report;
        }
        private void reporte_PDF()
        {
           
                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "SAF";
                connectionInfo.Password = "DSIA2014";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, Tipo);
                CR_Reportes.ReportSource = report;
            

            }
        private void reporte_XLS()
        {
            report.PrintOptions.PaperSize = PaperSize.PaperLetter;
            connectionInfo.ServerName = "dsia";
            connectionInfo.UserID = "SAF";
            connectionInfo.Password = "DSIA2014";
            SetDBLogonForReport(connectionInfo, report);
            report.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, false, Tipo);
            CR_Reportes.ReportSource = report;

        }
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

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
