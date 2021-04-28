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
                //CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_CentrosContab", ref DDLCContab);
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Programa", ref DDLPrograma);
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_SubPrograma", ref DDLSubprog, "p_nivel", "");
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref DDLDependencia, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, "P");
                DDLDependencia.SelectedValue = "1";
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Cod_Prog_Cat_Estruct", ref DDLCodProg, "P_DEPENDENCIA", "P_EJERCICIO", DDLDependencia.SelectedValue, SesionUsu.Usu_Ejercicio);
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Proyecto", ref DDLProyecto, "p_ejercicio", SesionUsu.Usu_Ejercicio);
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Partidas", ref DDLPartida);
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Fuentes", ref DDLFuente, "P_EJERCICIO", SesionUsu.Usu_Ejercicio);
                //DDLFuncion.SelectedValue = "1";
                //CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Cod_Prog_Ctx_Dp01", ref DDLCodProg, "p_centro_contable", "p_funcion", DDLCentroContab.SelectedValue, DDLFuncion.SelectedValue);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }

        private void CargarDatosCodProg()
        {
            try
            {
                string Verificador = string.Empty;
                CN_Cat_Ctrl_Presp.ObtenerDatosCodProg(DDLCodProg.SelectedValue, ref objCodProg, ref Verificador );
                //DDLCContab.SelectedValue = objCodProg.Centro_Contable;
                if (Verificador == "0")
                {
                    DDLPrograma.SelectedValue = objCodProg.Programa;
                    DDLSubprog.SelectedValue = objCodProg.SubPrograma;
                    DDLDependencia.SelectedValue = objCodProg.Dependencia;
                    DDLProyecto.SelectedValue = objCodProg.Proyecto;
                    DDLPartida.SelectedValue = objCodProg.Partida;
                    DDLFuente.SelectedValue = objCodProg.Fuente;                    
                    if (DDLDependencia.SelectedValue == "81101")
                        txtDigiMinistrado.Text = "2";
                    else
                        txtDigiMinistrado.Text = "1";
                    Session["CodigoProg"] = objCodProg;
                }
                else if (DDLDependencia.SelectedValue != "00000")
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + ".')", true);
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }

        protected void DDLCodProg_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Verificador = string.Empty;
                CN_Cat_Ctrl_Presp.ObtenerDatosCodProg(DDLCodProg.SelectedValue, ref objCodProg, ref Verificador);
                if (Verificador == "0")
                {
                    //DDLCContab.SelectedValue = objCodProg.Centro_Contable;
                    DDLPrograma.SelectedValue = objCodProg.Programa;
                    DDLSubprog.SelectedValue = objCodProg.SubPrograma;
                    DDLDependencia.SelectedValue = objCodProg.Dependencia;
                    DDLProyecto.SelectedValue = objCodProg.Proyecto;
                    DDLPartida.SelectedValue = objCodProg.Partida;
                    DDLFuente.SelectedValue = objCodProg.Fuente;
                    Session["CodigoProg"] = objCodProg;
                    CargarConsttruccionCodigoProg();
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + ".')", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }

        protected void DDLDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Cod_Prog_Cat_Estruct", ref DDLCodProg, "P_DEPENDENCIA", "P_EJERCICIO", DDLDependencia.SelectedValue, SesionUsu.Usu_Ejercicio);
                if (DDLCodProg.DataSource != null)
                {
                    if (DDLDependencia.SelectedValue == "81101")
                        txtDigiMinistrado.Text = "2";
                    else
                        txtDigiMinistrado.Text = "1";
                    CargarDatosCodProg();
                    CargarConsttruccionCodigoProg();
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'No existen estrucuturas programaticas para esta dependencia.')", true);                
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }

        protected void DDLFuente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarConsttruccionCodigoProg();
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }


        protected void CargarConsttruccionCodigoProg()
        {
            try
            {
                txtCodProg.Text = DDLPrograma.SelectedValue + "." + DDLSubprog.SelectedValue + "." + DDLDependencia.SelectedValue + "." + DDLProyecto.SelectedValue + "." + DDLPartida.SelectedValue + "." + DDLFuente.SelectedValue + "." + txtTipoGasto.Text + "." + txtDigiMinistrado.Text;
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }

        protected void BTNGuardarCodigo_Click(object sender, EventArgs e)
        {
            try
            {
                Cat_Ctrl_Presp_Saf objCodigoProg = new Cat_Ctrl_Presp_Saf();
                objCodigoProg.Funcion = DDLPrograma.SelectedValue;
                objCodigoProg.SubPrograma = DDLSubprog.SelectedValue;
                objCodigoProg.Dependencia = DDLDependencia.SelectedValue;
                objCodigoProg.Proyecto = DDLProyecto.SelectedValue;
                objCodigoProg.Partida = DDLPartida.SelectedValue;
                objCodigoProg.Fuente = DDLFuente.SelectedValue;
                objCodigoProg.TipoGasto = txtTipoGasto.Text;
                objCodigoProg.Dig_Ministrado = txtDigiMinistrado.Text;
                objCodigoProg.Ejercicio = SesionUsu.Usu_Ejercicio;
                string Verificador = string.Empty;
                CN_Cat_Ctrl_Presp.InsertarCodigoProg(objCodigoProg, ref Verificador);
                if (Verificador == "0")               
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Se ha guardado correctamente.')", true);                
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '"+ Verificador + ".')", true);                
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '"+ ex.Message + ".')", true);
            }
        }

        protected void DDLPartida_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarConsttruccionCodigoProg();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
    }
}