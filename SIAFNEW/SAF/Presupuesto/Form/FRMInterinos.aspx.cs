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
    public partial class FRMInterinos : System.Web.UI.Page
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
                //SesionUsu.Editar = -1;
                inicializar();
            }
        }
        private void inicializar()
        {
            lblError.Text = string.Empty;
            try
            {
                SesionUsu.Usu_Rep = "A";
                MultiView1.ActiveViewIndex = 0;
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref DDLDependencia, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, SesionUsu.Usu_Rep, ref ListDependencia);
                CNComun.LlenaCombo("DPP.PKG_PRES.OBT_Combo_Semestre", ref DDLSemestre, "p_ejercicio", SesionUsu.Usu_Ejercicio, "DPP");              
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Error: " + ex.Message + "');", true);
            }
        }
    }
}