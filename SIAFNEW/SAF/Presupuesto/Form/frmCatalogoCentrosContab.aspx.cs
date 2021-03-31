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
    public partial class frmCatalogoCentrosContab : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_CentrosContab CN_CentrosContab = new CN_CentrosContab();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
        }       

        protected void BTNGuardarCatCContab_Click(object sender, EventArgs e)
        {
            try
            {
                if (SesionUsu.Usu_TipoUsu == "SA")
                {
                    CentrosContab objCContab = new CentrosContab();
                    string Verificador = string.Empty;
                    objCContab.C_Contab = txtCentroContab.Text.ToUpper();
                    objCContab.Descrip = txtDependencia.Text.ToUpper();
                    objCContab.Director = txtDirector.Text;
                    objCContab.Administrador = txtAdministrador.Text;
                    objCContab.Saliente = txtSaliente.Text;
                    objCContab.Entrante = txtEntrante.Text;
                    objCContab.Ejercicio = SesionUsu.Usu_Ejercicio;
                    CN_CentrosContab.InsertarCentroContable(ref objCContab, ref Verificador);
                    if (Verificador == "0")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Se ha guardado correctamente.')", true);
                        txtCentroContab.Text = "";
                        txtDependencia.Text = "";
                        txtDirector.Text = "";
                        txtAdministrador.Text = "";
                        txtSaliente.Text = "";
                        txtEntrante.Text = "";
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