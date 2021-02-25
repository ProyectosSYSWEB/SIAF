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
    public partial class frmCatPresupUnv : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        PresupUnv PresupUnv = new PresupUnv();
        List<PresupUnv> ListPresUnv = new List<PresupUnv>();
        CN_Comun CNComun = new CN_Comun();
        CN_PresupUnv CN_PresupUnv = new CN_PresupUnv();
        CN_Consultas CNConsultas = new CN_Consultas();
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
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_CentrosContab", ref DDLCentroContab);
                DDLCentroContab.SelectedValue = "81101";
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Funcion", ref DDLFuncion);
                DDLFuncion.SelectedValue = "1";
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Cod_Prog_Ctx_Dp01", ref DDLCodProg, "p_centro_contable", "p_funcion", DDLCentroContab.SelectedValue, DDLFuncion.SelectedValue);                                
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void DDLFuncion_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Cod_Prog_Ctx_Dp01", ref DDLCodProg, "p_centro_contable", "p_funcion", DDLCentroContab.SelectedValue, DDLFuncion.SelectedValue);
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void DDLCodProg_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Verificador = string.Empty;
                PresupUnv.Codigo_Programatico = DDLCodProg.SelectedValue;
                CN_PresupUnv.ObtenerDatosCodProg(ref PresupUnv, ref Verificador);
                txtCentroContab.Text = PresupUnv.Centro_Contable;
                txtDependencia.Text = PresupUnv.Dependencia;
                txtPrograma.Text = PresupUnv.Programa;
                txtSubProg.Text = PresupUnv.Subprograma;
                txtPartida.Text = PresupUnv.Partida;
                txtFuente.Text = PresupUnv.Fuente;
                txtProyecto.Text = PresupUnv.Proyecto;
                txtTipoGasto.Text = PresupUnv.Tipo_Gasto;
                txtDigMinis.Text = PresupUnv.Dig_Ministrado;
                txtFuncion.Text = PresupUnv.Funcion;                              
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }


    }
}