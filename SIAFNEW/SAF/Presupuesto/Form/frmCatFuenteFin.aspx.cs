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
            CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_TipoFinan", ref DDLTipofuente);
            DDLTipofuente.SelectedValue = "1";            
            CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Tipo_Fondo", ref DDLTipofondo);
            DDLTipofondo.SelectedValue = "1";            
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
                    objFuentesFin.TipoFinan = DDLTipofuente.SelectedValue;
                    objFuentesFin.TipoFondo = DDLTipofondo.SelectedValue;
                    objFuentesFin.Descrip = txtDescrip.Text;                    
                    string Verificador = string.Empty;
                    CN_FuenteFin.InsertarFuente(ref objFuentesFin, ref Verificador);
                }
                else
                    lblError.Text = lblError.Text = "No tiene los privilegios para realizar esta acción";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}