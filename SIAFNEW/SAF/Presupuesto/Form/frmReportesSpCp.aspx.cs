using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAF.Presupuesto.Form
{
    public partial class frmReportesSpCp : System.Web.UI.Page
    {
        Sesion SesionUsu = new Sesion();
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
        }

        protected void btn_generar_reporte(object sender, EventArgs e)
        {
            try
            {
                var mesIni = ddlMesIni.SelectedValue;
                var mesFin = ddlMesFin.SelectedValue;                
                var reporte = DDLReporte.SelectedValue;

                string ruta1 = string.Empty;
                ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=" + reporte + "&MesIni=" + mesIni + "&MesFin=" + mesFin + "&Ejercicio=" + SesionUsu.Usu_Ejercicio;
                string _open1 = "window.open('" + ruta1 + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
            }
            catch(Exception ex)
            {
                var mensaje = ex.Message;
            }
        }
    }
}