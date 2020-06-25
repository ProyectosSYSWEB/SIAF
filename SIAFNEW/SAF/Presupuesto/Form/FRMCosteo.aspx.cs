using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEntidad;
using CapaNegocio;

namespace SAF.Presupuesto.Form
{
    public partial class FRMCosteo : System.Web.UI.Page
    {
        #region <Variables>
        Int32[] Celdas = new Int32[] { 0 };
        string Verificador = string.Empty;
        string VerificadorDet = string.Empty;
        CN_Usuario CNUsuario = new CN_Usuario();
        Usuario Usuario = new Usuario();
        String tipo_plantilla = "";
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Costeo CNCosteo = new CN_Costeo();        
        Pres_Costeo objcosteo = new Pres_Costeo();
        private static List<Comun> ListDependencia = new List<Comun>();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                //SesionUsu.Editar = -1;
                inicializar();
            }
        }
        private void cargar_tab()
        {
            lblError.Text = string.Empty;
            objcosteo.Dependencia = DDLDependencia.SelectedValue;
            objcosteo.Ejercicio = ddlEjercicio.SelectedValue;
            objcosteo.Tipo_personal = DDL_Tipo0.SelectedValue;
            CNCosteo.Sel_tabulador(ref objcosteo, ref Verificador);
            if (Verificador == "0")
            {
                txtprima.Text = objcosteo.Prima_Vacacional;
                txtaguinaldo.Text = objcosteo.Aguinaldo;
                txtajuste_c.Text = objcosteo.Ajuste_Calendario;
                txtissste.Text = objcosteo.Issste;
                txtfovissste.Text = objcosteo.Fovissste;
                txtsar.Text = objcosteo.Sar;            
            }
        }
        private void inicializar()
        {
            lblError.Text = string.Empty;
            try
            {
                SesionUsu.Usu_Rep = "A";               
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref DDLDependencia, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, SesionUsu.Usu_Rep, ref ListDependencia);
                CNComun.LlenaCombo("DPP.PKG_PRES.OBT_Combo_Semestre", ref DDLSemestre, "p_ejercicio", SesionUsu.Usu_Ejercicio, "DPP");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Error: " + ex.Message + "');", true);
            }
        }
        protected void DDLdependencia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlEjercicio_SelectedIndexChanged(object sender, EventArgs e)
        {

            lblError.Text = string.Empty;
            try
            {
                cargar_tab();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Error: " + ex.Message + "');", true);
            }
        }

        protected void imgBttnPDF_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (ddltipo_plantilla.SelectedValue == "P")
                { tipo_plantilla = "P"; }
                else
                { tipo_plantilla = ""; }
                string ruta = string.Empty;
                ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-018"+ tipo_plantilla + "&Semestre=" + DDLSemestre.SelectedItem.ToString() + "&Dependencia=" + DDLDependencia.SelectedItem.ToString() + "&Meses="+ ddlMeses.SelectedValue + "&Prima_V="+ txtprima.Text +"&Aguinaldo=" + txtaguinaldo.Text
                                                                                     + "&Ajuste_C=" + txtajuste_c.Text + "&Issste=" + txtissste.Text +"&Fovissste="+ txtfovissste.Text + "&Sar=" + txtsar.Text;
                string _open = "window.open('" + ruta + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void DDL_Tipo0_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            try
            {
                cargar_tab();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Error: " + ex.Message + "');", true);
            }
        }

        protected void imgBttnExcel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (ddltipo_plantilla.SelectedValue == "P")
                { tipo_plantilla = "P"; }
                else
                { tipo_plantilla = ""; }
                string ruta = string.Empty;
                ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-019"+ tipo_plantilla + "&Semestre=" + "49" + "&Dependencia=" + DDLDependencia.SelectedItem.ToString() + "&Meses=" + ddlMeses.SelectedValue + "&Prima_V=" + txtprima.Text + "&Aguinaldo=" + txtaguinaldo.Text
                                                                                     + "&Ajuste_C=" + txtajuste_c.Text + "&Issste=" + txtissste.Text + "&Fovissste=" + txtfovissste.Text + "&Sar=" + txtsar.Text;
                string _open = "window.open('" + ruta + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void ddltipo_plantilla_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}