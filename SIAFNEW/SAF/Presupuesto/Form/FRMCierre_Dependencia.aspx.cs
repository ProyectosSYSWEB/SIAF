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
    public partial class FRMCierre_Dependencia : System.Web.UI.Page
    {
        #region <Variables>
        Int32[] Celdas = new Int32[] { 0 };
        string Verificador = string.Empty;
        string VerificadorDet = string.Empty;
        CN_Usuario CNUsuario = new CN_Usuario();
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Pres_Plantilla CNPlantilla = new CN_Pres_Plantilla();
        CN_Pres_Documento_Det CNDocDet = new CN_Pres_Documento_Det();
        Pres_Plantilla objPlantilla = new Pres_Plantilla();
        private static List<Comun> ListDependencia = new List<Comun>();
        int guar_continue;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {                
                inicializar();
            }
        }
        private void inicializar()
        {
            lblError.Text = string.Empty;
            try
            {
                CNComun.LlenaCombo("DPP.PKG_PRES.OBT_Combo_Semestre", ref DDLSemestre, "p_ejercicio", SesionUsu.Usu_Ejercicio, "DPP");
                CargarGrid(ref GRDcierre, 0);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Error: " + ex.Message + "');", true);
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarGrid(ref GRDcierre, 0);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        private void CargarGrid(ref GridView grid, int idGrid)
        {
            lblError.Text = string.Empty;
            grid.DataSource = null;
            grid.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grid.DataSource = dt;
                grid.DataSource = GetList(idGrid);
                grid.DataBind();
                Celdas = new Int32[] { };
                if (grid.Rows.Count > 0)
                {
                    CNComun.HideColumns(grid, Celdas);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Error: " + ex.Message + "');", true);
            }
        }
        private List<Pres_Plantilla> GetList(int IdGrid)
        {
            try
            {
                List<Pres_Plantilla> List = new List<Pres_Plantilla>();
                objPlantilla.Semestre = DDLSemestre.SelectedValue;
                CNPlantilla.ConsultaGrid_cierre_dep(ref objPlantilla, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected void index_linbtn(object sender, Control grid)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            GRDcierre.SelectedIndex = row.RowIndex;     
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                index_linbtn(sender ,GRDcierre);
                CERRAR_PLANTILLA();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Error: " + ex.Message + "');", true);
            }
        }
        protected void CERRAR_PLANTILLA()
        {
            try
            {
                lblError.Text = string.Empty;
                int e = GRDcierre.SelectedIndex;
                objPlantilla.Dependencia = GRDcierre.Rows[e].Cells[1].Text;
                objPlantilla.Semestre = DDLSemestre.SelectedValue;
                objPlantilla.Usuario = SesionUsu.Usu_Nombre;
                Verificador = string.Empty;
                CNPlantilla.cerrar_plantilla(ref objPlantilla, ref Verificador);
                if (Verificador == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'LA PLANTILLA SE GUARDO EXITOSAMENTE');", true);
                    CargarGrid(ref GRDcierre, 0);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Error: " + ex.Message + "');", true);
            }
        }
    }
}