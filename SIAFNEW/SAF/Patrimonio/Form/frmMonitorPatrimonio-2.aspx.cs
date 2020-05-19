using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaEntidad;


namespace SAF.Patrimonio.Form
{
    public partial class frmMonitorPatrimonio : System.Web.UI.Page
    {
        #region <Variables>
        CN_Comun CNMonitor = new CN_Comun();
        Sesion SesionUsu = new Sesion();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                Cargarcombos();
            }
        }

        #region <Funciones y Sub>
        private void MonitorConsultaGrid()
        {
            lblError.Text = string.Empty;
            grvMonitorCont.DataSource = null;
            grvMonitorCont.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grvMonitorCont.DataSource = dt;
                grvMonitorCont.DataSource = GetList();
                grvMonitorCont.DataBind();

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }
        private List<Comun> GetList()
        {
            try
            {
                List<Comun> List = new List<Comun>();
                CNMonitor.Monitor_Patrimonio(DDLCentro_Contable.SelectedValue, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void Cargarcombos()
        {
            lblError.Text = string.Empty;
            try
            {
                CNMonitor.LlenaCombo("pkg_contabilidad.Obt_Combo_Centros_Contables", ref DDLCentro_Contable, "p_usuario", "p_ejercicio", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio);
                DDLCentro_Contable_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        #endregion

        protected void grvMonitorCont_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvMonitorCont.PageIndex = 0;
            grvMonitorCont.PageIndex = e.NewPageIndex;
            MonitorConsultaGrid();
        }

        protected void DDLCentro_Contable_SelectedIndexChanged(object sender, EventArgs e)
        {
            MonitorConsultaGrid();
        }
    }
}