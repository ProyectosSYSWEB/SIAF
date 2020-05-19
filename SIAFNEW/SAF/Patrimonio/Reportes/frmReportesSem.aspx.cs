using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocio;

namespace SAF.Patrimonio.Reportes
{
    public partial class frmReportesSem : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;
        CN_Usuario CNUsuario = new CN_Usuario();
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        string ruta, _open;
        private static List<Comun> Listcodigo = new List<Comun>(); //En tu declaración de variables

        #endregion      
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SesionUsu = (Sesion)Session["Usuario"];
                if (!IsPostBack)
                {
                    Inicializar();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Error al cargar la página: " + ex.Message + "');", true);
            }
        }

        protected void btnAceptar_Click(object sender, ImageClickEventArgs e)
        {
            string caseSwitch = DDLReportes.SelectedValue;
            switch (caseSwitch)
            {
                case "RP-SemovienteEspecie":
                    ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-SemovienteEspecie&status=" + DDLStatus.SelectedValue ;
                    _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                    break;
                case "RP-SemovienteSexo":
                    ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-SemovienteSexo&status=" + DDLStatus.SelectedValue + "&clave=" + DDLEspecie.SelectedValue;
                    _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                    break;
                case "RP-SemovienteEtapaDetalle":
                    ruta = "VisualizadorCrystal_patrimonio.aspx?Tipo=RP-SemovienteEtapaDetalle&ejercicio=" +SesionUsu.Usu_Ejercicio + "&clave=" + DDLEspecie.SelectedValue+"&mes_inicial=" + DDLMes.SelectedValue.Substring(0,2)+ "&mes_final=" + DDLMes.SelectedValue.Substring(2, 2) + "&dependencia=" + DDLDependencia.SelectedValue;
                    _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                    break;
            }


        }

        protected void DDLReportes_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(DDLReportes.SelectedValue)
            {
                case "RP-SemovienteEspecie":
                    lblEspecie.Visible = false;
                    DDLEspecie.Visible = false;
                    lblStatus.Visible = true;
                    DDLStatus.Visible = true;
                    lblDependencia.Visible = false;
                    DDLDependencia.Visible = false;
                    lblMes.Visible = false;
                    DDLMes.Visible = false;
                    break;
                case "RP-SemovienteSexo":
                    lblEspecie.Visible = true;
                    DDLEspecie.Visible = true;
                    lblStatus.Visible = true;
                    DDLStatus.Visible = true;
                    lblDependencia.Visible = false;
                    DDLDependencia.Visible = false;
                    lblMes.Visible = false;
                    DDLMes.Visible = false;
                    break;
                case "RP-SemovienteEtapaDetalle":
                    lblEspecie.Visible = true;
                    DDLEspecie.Visible = true;
                    lblStatus.Visible = false;
                    DDLStatus.Visible = false;
                    lblDependencia.Visible = true;
                    DDLDependencia.Visible = true;
                    lblMes.Visible = true;
                    DDLMes.Visible = true;
                    break;
            }
        }

        protected void Inicializar()
        {
           
            CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Especies", ref DDLEspecie);
            CNComun.LlenaCombo("PKG_PATRIMONIO.Obt_Combo_Dependencia", ref DDLDependencia, "p_usuario", SesionUsu.Usu_Nombre);
            MultiView1.ActiveViewIndex = 0;
            lblEspecie.Visible = false;
            DDLEspecie.Visible = false;
            lblStatus.Visible = true;
            DDLStatus.Visible = true;
            lblDependencia.Visible = false;
            DDLDependencia.Visible = false;
            lblDependencia.Visible = false;
            DDLDependencia.Visible = false;
            lblMes.Visible = false;
            DDLMes.Visible = false;

        }

       
    }
}
