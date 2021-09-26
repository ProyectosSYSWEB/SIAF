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
    public partial class frmCatalogoProgramas : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Programa CNPrograma = new CN_Programa();
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
            CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Funcion", ref DDLFuncion);
            DDLFuncion.SelectedIndex = 1;
            //CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Fun_Fed", ref DDLFuenteFed);
        }

        protected void BTNGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Programa objPrograma = new Programa();
                if (SesionUsu.Usu_TipoUsu == "SA")
                {
                    objPrograma.Funcion = DDLFuncion.SelectedValue;
                    objPrograma.Funfed = "57";
                    objPrograma.F_Prog = txtPrograma.Text;
                    objPrograma.Descripcion = txtDescripcion.Text;
                    string Verificador = string.Empty;
                    CNPrograma.InsertarPrograma(ref objPrograma, ref Verificador);
                    if (Verificador == "0")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Se ha guardado correctamente.')", true);                        
                        txtPrograma.Text = "";
                        txtDescripcion.Text = "";
                        DDLFuncion.SelectedIndex = 1;
                    }
                    else
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + ".')", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'No tiene los privilegios para realizar esta acción.')", true);                
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);                
            }
        }
    }
}