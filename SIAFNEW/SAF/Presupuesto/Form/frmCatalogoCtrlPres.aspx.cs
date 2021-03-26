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
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Proyecto", ref DDLProy);
                DDLProy.SelectedValue = "1";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            
        }

        protected void DDLCentroContab_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_DepXCentCont", ref DDLDepend, "p_centroCotab", DDLCentroContab.SelectedValue);            
        }

        protected void BTNGuardarCatPres_Click(object sender, EventArgs e)
        {
            try
            {
                Presupues objEstrucProg = new Presupues();
                if (SesionUsu.Usu_TipoUsu == "SA")
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
                        lblError.Text = "Se ha guardado correctamente";
                    else
                        lblError.Text = Verificador;
               }
               else
                   lblError.Text = "No tiene los privilegios para realizar esta acción";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void DDLPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Nivel = DDLPrograma.SelectedValue;
            CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_SubPrograma", ref DDLSubprog, "p_nivel", Nivel.Substring(0,1));
        }
    }
}