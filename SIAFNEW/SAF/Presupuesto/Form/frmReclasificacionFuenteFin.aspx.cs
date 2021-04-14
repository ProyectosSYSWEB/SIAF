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
    public partial class frmReclasificacionFuenteFin : System.Web.UI.Page
    {

        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_ReclasificacionFuenteFin CN_Reclasificacion = new CN_ReclasificacionFuenteFin();
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
        private void CargarCombos()
        {
            try
            {
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref DDLDependenciaI, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, "CAT");
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref DDLDependenciaF, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, "CAT");
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Partidas", ref DDLPartida);
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Fuentes", ref DDLFuenteOrigen, "p_ejercicio", SesionUsu.Usu_Ejercicio);
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Fuentes", ref DDLFuenteDest1, "p_ejercicio", SesionUsu.Usu_Ejercicio);
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Fuentes", ref DDLFuenteDest2, "p_ejercicio", SesionUsu.Usu_Ejercicio);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }

        protected void BTNBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Consultas objConsultas = new Consultas();
                List<Consultas> List = new List<Consultas>();
                objConsultas.DependenciaIni = DDLDependenciaI.SelectedValue;
                objConsultas.DependenciaFin = DDLDependenciaF.SelectedValue;
                objConsultas.Partida = DDLPartida.SelectedValue;
                objConsultas.Fuente = DDLFuenteOrigen.SelectedValue;
                objConsultas.Mes_Inicial = DDLMesI.SelectedValue;
                objConsultas.Mes_Final = DDLMesF.SelectedValue;
                objConsultas.Ejercicio = SesionUsu.Usu_Ejercicio;
                CN_Reclasificacion.CodigosReclasificacion(objConsultas, ref List);

                GRDCodigosRecla.DataSource = List;
                GRDCodigosRecla.DataBind();
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
    }
}