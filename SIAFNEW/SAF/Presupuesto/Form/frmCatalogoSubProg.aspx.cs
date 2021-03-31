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
    public partial class frmCatalogoSubProg : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Subprog CN_Subprog = new CN_Subprog();
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
            CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Nvl_Academicos", ref DDLNvlacd, "p_tipocombo", "N");            
        }

        protected void BTNGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Basicos objBasicos = new Basicos();
                if (SesionUsu.Usu_TipoUsu == "SA")
                {
                    objBasicos.valor = DDLNvlacd.SelectedValue;
                    objBasicos.clave = txtPrograma.Text;
                    objBasicos.descripcion = txtDescripcion.Text;
                    objBasicos.tipo = "CAT_SUBPROG";
                    objBasicos.status = "A";
                    objBasicos.orden = "";
                    string Verificador = string.Empty;
                    CN_Subprog.InsertarSubPrograma(ref objBasicos, ref Verificador);
                    if (Verificador == "0")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 1, 'Se ha guardado correctamente.');", true);                        
                        txtPrograma.Text = "";
                        txtDescripcion.Text = "";
                    }
                    else
                    {                        
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '"+ Verificador +"')", true);
                    }
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'No tiene los privilegios necesarios para realizar esta acción.')", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "')", true);                
            }
        }
    }
}