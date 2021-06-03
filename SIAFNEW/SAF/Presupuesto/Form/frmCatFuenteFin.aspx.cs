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
    public partial class frmCatFuenteFin : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_FuenteFin CN_FuenteFin = new CN_FuenteFin();
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
            CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_TipoFinan", ref DDLTipofuente, "p_valor", "p_clave", "1", "0");
            DDLTipofuente.SelectedValue = "1";            
            CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_TipoFinan", ref DDLTipofondo, "p_valor", "p_clave", "2", "0");
            DDLTipofondo.SelectedValue = "1";
            //CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_TipoFinan", ref DDDLTipoSubFondo, "p_valor", "p_clave", "3", "0");
            //DDLTipofondo.SelectedValue = "1";
            CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_TipoFinan", ref DDLFuenteFin, "p_valor", "p_clave", "3", "4");

        }
        protected void DDLTipofuente_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Fuente = DDLTipofuente.SelectedValue;
            txtFuente.Text = Fuente.Substring(0, 3);
        }

        protected void BTNGuardarFuenteFin_Click(object sender, EventArgs e)
        {
            try
            {
                FuentesFin objFuentesFin = new FuentesFin();
                if (SesionUsu.Usu_TipoUsu == "SA")
                {
                    objFuentesFin.Fuente = txtFuente.Text;
                    objFuentesFin.TipoFinan = DDLFuenteFin.SelectedValue;
                    objFuentesFin.TipoFondo = DDLTipofondo.SelectedValue;
                    objFuentesFin.Descrip = txtDescrip.Text;
                    string Verificador = string.Empty;
                    CN_FuenteFin.InsertarFuente(ref objFuentesFin, ref Verificador);
                    if (Verificador == "0")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Se ha guardado correctamente.')", true);
                        txtFuente.Text = "";
                        txtDescrip.Text = "";
                    }
                    else
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, '"+ Verificador + ".')", true);                    
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'No tiene los privilegios para realizar esta acción.')", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, '" + ex.Message + ".')", true);
            }
        }
    }
}