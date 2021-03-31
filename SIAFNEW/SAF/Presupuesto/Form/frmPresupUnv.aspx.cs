using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAF.Presupuesto.Form
{
    public partial class frmPresupUnv : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_PresupUnv CN_PresupUnv = new CN_PresupUnv();
        CN_Pres_Reportes CNReportes = new CN_Pres_Reportes();
        Pres_Reportes objReportes = new Pres_Reportes();
        string capitulos = "";
        List<string> ListaCaps = new List<string>();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                Inicializar();
            }
        }
        private void Inicializar()
        {
            GRDCargarDatosPresUnv();
        }       
        protected void GRDCargarDatosPresUnv()
        {
            try
            {
                PresupUnv objPresupUnv = new PresupUnv();
                List<PresupUnv> listPresUnv = new List<PresupUnv>();
                objPresupUnv.Ejercicio = SesionUsu.Usu_Ejercicio;
                CN_PresupUnv.PresUnvGrid(ref objPresupUnv, ref listPresUnv);
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //sda.Fill(ds);//
                GRDCodProg.DataSource = listPresUnv;
                GRDCodProg.DataBind();                
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        protected void GRDCodProg_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                string Id =  Convert.ToString(GRDCodProg.SelectedRow.Cells[0].Text);
                string Tipo = Convert.ToString(GRDCodProg.SelectedRow.Cells[7].Text);
                string ruta1 = "";                        
                ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RPT-PRESUP_UNV&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Id=" + Id + "&Tipo_V=" + Tipo;
                string _open1 = "window.open('" + ruta1 + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Response.Redirect("frmCatPresupUnv.aspx", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
    }
}