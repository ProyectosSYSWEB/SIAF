using System;
using CapaEntidad;
using CapaNegocio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAF.Presupuesto.Form
{
    public partial class frmCatalogoAdecuaciones : System.Web.UI.Page
    {
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Presupuesto CN_Presupuesto = new CN_Presupuesto();
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
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Partidas", ref DDLPartida);
                DDLPartida.SelectedValue = "1";
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Fuentes", ref DDLFuente);
                DDLPartida.SelectedValue = "1";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }
    }
}