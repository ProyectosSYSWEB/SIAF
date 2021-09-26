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
    public partial class frmCatalogoCtrlPres : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Presupuesto CN_Presupuesto = new CN_Presupuesto();
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
            CargarCombos();
        }
        protected void CargarCombos()
        {
            try
            {                
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_CentrosContab", ref DDLCentroContab, "p_ejercicio", SesionUsu.Usu_Ejercicio);
                DDLCentroContab.SelectedValue = "1";
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Programa", ref DDLPrograma);
                DDLPrograma.SelectedValue = "1";
                string Nivel = DDLPrograma.SelectedValue;
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_SubPrograma", ref DDLSubprog, "p_nivel", Nivel.Substring(0,1));
                DDLSubprog.SelectedValue = "1";
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_DepXCentCont", ref DDLDepend, "p_centroCotab", DDLCentroContab.SelectedValue);
                DDLDepend.SelectedValue = "1";
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Proyecto", ref DDLProy, "p_ejercicio", SesionUsu.Usu_Ejercicio);
                DDLProy.SelectedValue = "1";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, '" + ex.Message + ".')", true);
            }
            
        }
        protected void DDLCentroContab_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_DepXCentCont", ref DDLDepend, "p_centroCotab", DDLCentroContab.SelectedValue);
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, '" + ex.Message + ".')", true);
            }
        }
        protected void BTNGuardarCatPres_Click(object sender, EventArgs e)
        {
            try
            {
                Presupues objEstrucProg = new Presupues();
                if (SesionUsu.Usu_TipoUsu == "SA" || SesionUsu.Usu_Nombre == "HERNANDEZ" || SesionUsu.Usu_Nombre == "GORDILLO" || SesionUsu.Usu_Nombre == "JOSE.GORDILLO" || SesionUsu.Usu_Nombre == "PEREZ" || SesionUsu.Usu_Nombre == "ELIESER" || SesionUsu.Usu_Nombre == "OEL" || SesionUsu.Usu_Nombre == "SANDRA.SANCHEZ" || SesionUsu.Usu_Nombre == "FREDY712" || SesionUsu.Usu_Nombre == "CONDE" || SesionUsu.Usu_Nombre == "JORGE.CAMACHO"  || SesionUsu.Usu_Nombre == "KAREMCTS")
                {
                    string Verificador = string.Empty;
                    objEstrucProg.Centro_Contable = DDLCentroContab.SelectedValue;
                    objEstrucProg.Programa = DDLPrograma.SelectedValue;
                    objEstrucProg.SubPrograma = DDLSubprog.SelectedValue;
                    objEstrucProg.Dependencia = DDLDepend.SelectedValue;
                    objEstrucProg.Proyecto = DDLProy.SelectedValue;
                    objEstrucProg.Status = "A";
                    objEstrucProg.Ejercicio = Convert.ToInt32(SesionUsu.Usu_Ejercicio);
                    CN_Presupuesto.InsertarEstructuraProg(objEstrucProg, ref Verificador);
                    if (Verificador == "0")
                    {
                        DDLCentroContab.SelectedIndex = 0;
                        DDLPrograma.SelectedIndex = 0;
                        DDLSubprog.SelectedIndex = 0;
                        DDLDepend.SelectedIndex = 0;
                        DDLProy.SelectedIndex = 0;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Se ha guardado correctamente.')", true);
                    }
                    else
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + ".')", true);                    
               }
               else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'No tiene los privilegios necesarios para realizar esta acción.')", true);
                
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '"+ ex.Message + ".')", true);                
            }
        }
        protected void DDLPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Nivel = DDLPrograma.SelectedValue;
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_SubPrograma", ref DDLSubprog, "p_nivel", Nivel.Substring(0, 1));
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, '" + ex.Message + ".')", true);
            }
        }
    }
}