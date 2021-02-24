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
    public partial class frmCatCtrlPresupSaf : System.Web.UI.Page
    {

        #region Variables
        Sesion SesionUsu = new Sesion();        
        CN_Comun CNComun = new CN_Comun();        
        Cat_Ctrl_Presp_Saf objCodProg = new Cat_Ctrl_Presp_Saf();
        CN_Cat_Ctrl_Presp_Saf CN_Cat_Ctrl_Presp = new CN_Cat_Ctrl_Presp_Saf();

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
            CargarDatosCodProg();
        }

        private void CargarCombos()
        {
            try
            {
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Cod_Prog_Cat_Estruct", ref DDLCodProg);                
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_CentrosContab", ref DDLCContab);
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Programa", ref DDLPrograma);
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_SubPrograma", ref DDLSubprog);
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Depend", ref DDLDependencia);
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Proyecto", ref DDLProyecto);
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Partidas", ref DDLPartida);
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Fuentes", ref DDLFuente);
                //DDLFuncion.SelectedValue = "1";
                //CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Cod_Prog_Ctx_Dp01", ref DDLCodProg, "p_centro_contable", "p_funcion", DDLCentroContab.SelectedValue, DDLFuncion.SelectedValue);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void CargarDatosCodProg()
        {
            try
            {
                string Verificador = string.Empty;
                CN_Cat_Ctrl_Presp.ObtenerDatosCodProg(DDLCodProg.SelectedValue, ref objCodProg, ref Verificador );
                DDLCContab.SelectedValue = objCodProg.Centro_Contable;
                DDLPrograma.SelectedValue = objCodProg.Programa;
                DDLSubprog.SelectedValue = objCodProg.SubPrograma;
                DDLDependencia.SelectedValue = objCodProg.Dependencia;
                DDLProyecto.SelectedValue = objCodProg.Proyecto;
                DDLPartida.SelectedValue = objCodProg.Partida;
                DDLFuente.SelectedValue = objCodProg.Fuente;
                txtTipoGasto.Text = "01";
                txtDigiMinistrado.Text = "01";
                Session["CodigoProg"] = objCodProg;
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
                CN_Cat_Ctrl_Presp.ObtenerDatosCodProg(DDLCodProg.SelectedValue, ref objCodProg, ref Verificador);
                DDLCContab.SelectedValue = objCodProg.Centro_Contable;
                DDLPrograma.SelectedValue = objCodProg.Programa;
                DDLSubprog.SelectedValue = objCodProg.SubPrograma;
                DDLDependencia.SelectedValue = objCodProg.Dependencia;
                DDLProyecto.SelectedValue = objCodProg.Proyecto;
                DDLPartida.SelectedValue = objCodProg.Partida;
                DDLFuente.SelectedValue = objCodProg.Fuente;
                txtTipoGasto.Text = "01";
                txtDigiMinistrado.Text = "01";
                Session["CodigoProg"] = objCodProg;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}