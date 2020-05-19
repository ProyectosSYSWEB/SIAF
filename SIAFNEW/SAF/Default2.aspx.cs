using System;
using System.Data;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using CapaEntidad;
using CapaNegocio;

namespace SAF
{
    public partial class Default2 : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;
        CN_Usuario CNUsuario = new CN_Usuario();
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        Comun Comun = new Comun();
        Mnu mnu = new Mnu();
        CN_Mnu CNMnu = new CN_Mnu();
        CN_Comun CNMonitor = new CN_Comun();
        CN_Comun CNComun = new CN_Comun();
        CN_Informativa CNInformativa = new CN_Informativa();
        cuentas_contables Objinformativa = new cuentas_contables();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                busca_informativa();
                Inicializar();
            }
        }

        #region <Funciones y Sub>
        private void Inicializar()
        {           
            //ConsultaChart();
        }
        private void ConsultaChart()
        {
            lblMensaje.Text = string.Empty;
            try
            {
                //MonitorConsultaChart("1");
                //MonitorConsultaChart("2");
                //MonitorConsultaChart("3");
                //MonitorConsultaChart_Presupuesto("1");
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }
        private void ConsultaGrid()
        {
            MonitorConsultaGrid(grvAvances1, 1);
            MonitorConsultaGrid(grvAvances2, 2);
            MonitorConsultaGrid(grvAvances3, 3);
            MonitorConsultaGrid(grvAvances4, 4);
            MonitorConsultaGrid(grvAvances5, 5);
            MonitorConsultaGrid(grvAvances6, 6);
        }
        //private void MonitorConsultaGridPP(GridView grv, string Color, int Rango)
        //{
        //    Int32[] Celdas = new Int32[] { 3 };
        //    lblMensaje.Text = string.Empty;
        //    grv.DataSource = null;
        //    grv.DataBind();
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        grv.DataSource = dt;
        //        grv.DataSource = GetListPP(Color, Rango);
        //        grv.DataBind();
        //        CNComun.HideColumns(grv, Celdas);
        //    }
        //    catch (Exception ex)
        //    {
        //        lblMensaje.Text = ex.Message;
        //    }

        //}
        //private List<Comun> GetListPP(string Color, int Rango)
        //{
        //    try
        //    {
        //        List<Comun> List = new List<Comun>();
        //        CNMonitor.Monitor_EstadisticaPP(Color, Rango, ref List);
        //        return List;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        private void MonitorConsultaGrid(GridView grv, int Rango)
        {
            lblMensaje.Text = string.Empty;
            grv.DataSource = null;
            grv.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grv.DataSource = dt;
                grv.DataSource = GetList(Rango);
                grv.DataBind();

            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }

        }
        private List<Comun> GetList(int Rango)
        {
            try
            {
                List<Comun> List = new List<Comun>();
                //CNMonitor.Monitor_Estadistica(Rango, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void MonitorConsultaChart(string tipo)
        {
            try
            {



                //if (tipo == "1")
                //{
                //    string[] x = new string[0];
                //    int[] y = new int[0];

                //    List<Comun> List = new List<Comun>();
                //    CNMonitor.Estadisticas(tipo, ref x, ref y);
                //    chartIndicador.Series[0].Points.DataBindXY(x, y);
                //    chartIndicador.Series[0].ChartType = SeriesChartType.Bar;
                //    chartIndicador.Series[0].IsValueShownAsLabel = true;
                //}
                //else if (tipo == "2")
                //{
                //    string[] x = new string[0];
                //    int[] y = new int[0];

                //    List<Comun> List = new List<Comun>();
                //    CNMonitor.Estadisticas(tipo, ref x, ref y);
                //    chartIndicador1.Series[0].Points.DataBindXY(x, y);
                //    chartIndicador1.Series[0].ChartType = SeriesChartType.Column;
                //    chartIndicador1.Series[0].Palette = ChartColorPalette.Chocolate;
                //    chartIndicador1.Series[0].IsValueShownAsLabel = true;
                //}
                //else if (tipo == "3")
                //{
                //    string[] x = new string[0];
                //    int[] y = new int[0];

                //    List<Comun> List = new List<Comun>();
                //    CNMonitor.Estadisticas(tipo, ref x, ref y);
                //    chartIndicador2.Series[0].Points.DataBindXY(x, y);
                //    chartIndicador2.Series[0].ChartType = SeriesChartType.Pie;
                //    chartIndicador2.Series[0].Palette = ChartColorPalette.BrightPastel;
                //    chartIndicador2.Series[0].IsValueShownAsLabel = true;
                //}
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }
        //private void MonitorConsultaChart_Presupuesto(string tipo)
        //{
        //    try
        //    {
        //        if (tipo == "1")
        //        {
        //            string[] x = new string[0];
        //            int[] y = new int[0];




        //            List<Comun> List = new List<Comun>();
        //            CNMonitor.Estadisticas_Presupuesto(tipo, ref x, ref y);
        //            chartIndicador3.Series[0].Points.DataBindXY(x, y);
        //            chartIndicador3.Series[0].ChartType = SeriesChartType.Bar;

        //            chartIndicador3.Series[0].Points[0].Color = Color.Red;
        //            chartIndicador3.Series[0].Points[1].Color = Color.Yellow;
        //            chartIndicador3.Series[0].Points[2].Color = Color.Green;

        //            chartIndicador3.Series[0].Points[0].PostBackValue = "ROJO";
        //            chartIndicador3.Series[0].Points[1].PostBackValue = "AMARILLO";
        //            chartIndicador3.Series[0].Points[2].PostBackValue = "VERDE";
        //            chartIndicador3.Series[0].IsValueShownAsLabel = true;
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        lblMensaje.Text = ex.Message;
        //    }
        //}
        //private List<Comun> GetList_Graficas(int Rango)
        //{
        //    try
        //    {
        //        List<Comun> List = new List<Comun>();
        //        CNMonitor.Estadisticas(Rango, ref List);
        //        return List;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        private void Ver_Reporte(GridView grv, int index)
        {
            grv.SelectedIndex = index;
            string CentroContab = grv.SelectedRow.Cells[3].Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "ver_Adecuaciones('RP-Adecuaciones','" + CentroContab + "');", true);
        }
        #endregion

        protected void btnIrGraficas_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            ConsultaChart();
        }
        protected void grvAvances1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnSi_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
        }
        private void busca_informativa()
        {
            try
            {
                lblMensaje.Text = string.Empty;
                Objinformativa.usuario = SesionUsu.Usu_Nombre;
                Objinformativa.ejercicio = SesionUsu.Usu_Ejercicio;
                //CNInformativa.Consultar_Observaciones(ref Objinformativa, ref Verificador);

                if (Verificador == "0" && Objinformativa.observaciones != "")
                {
                    lblMsg_Observaciones.Text = Objinformativa.observaciones;
                    ModalPopupExtender1.Show();

                }
                else
                {
                    lblMensaje.Text = Verificador;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }

        }
        protected void btnIrSemaforos_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            ConsultaGrid();
        }        
        protected void chartIndicador3_Load(object sender, EventArgs e)
        {

            //chartIndicador3.Series[0].Points[0].Url = "Patrimonio/Form/frmTransferencias.aspx";
            //chartIndicador3.Series[0].Points[1].Url = "";
            //chartIndicador3.Series[0].Points[2].Url = "";
        }
        protected void chartIndicador3_Click(object sender, ImageMapEventArgs e)
        {
            grvAvances_PP1.DataSource = null;
            grvAvances_PP1.DataBind();

            string color = Convert.ToString(e.PostBackValue);
            //MonitorConsultaGridPP(grvAvances_PP1, color, 1);
            //MonitorConsultaGridPP(grvAvances_PP2, color, 2);
            //MonitorConsultaGridPP(grvAvances_PP3, color, 3);
            //MonitorConsultaGridPP(grvAvances_PP4, color, 4);
            //MonitorConsultaGridPP(grvAvances_PP5, color, 5);
            //MonitorConsultaGridPP(grvAvances_PP6, color, 6);

            MultiView1.ActiveViewIndex = 2;

        }
        protected void btnIrGraficasPP_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            ConsultaChart();

        }
        protected void lnkBttnDetalle6_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            Ver_Reporte(grvAvances_PP1, row.RowIndex);
            //grvAvances_PP1.SelectedIndex = row.RowIndex;
            //string CentroContab=grvAvances_PP1.SelectedRow.Cells[3].Text;            
            //ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "Ver_Adecuaciones('RP-Adecuaciones','" + CentroContab + "');", true);
        }
        protected void lnkBttnDetalle7_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            Ver_Reporte(grvAvances_PP2, row.RowIndex);
        }
        protected void lnkBttnDetalle8_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            Ver_Reporte(grvAvances_PP3, row.RowIndex);
        }
        protected void lnkBttnDetalle9_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            Ver_Reporte(grvAvances_PP4, row.RowIndex);
        }
        protected void lnkBttnDetalle10_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            Ver_Reporte(grvAvances_PP5, row.RowIndex);
        }
        protected void lnkBttnDetalle11_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            Ver_Reporte(grvAvances_PP6, row.RowIndex);
        }
    }
}