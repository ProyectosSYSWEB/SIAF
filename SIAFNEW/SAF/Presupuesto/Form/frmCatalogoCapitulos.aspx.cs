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
    public partial class frmCatalogoCapitulos : System.Web.UI.Page
    {

        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Capitulo CN_Capitulo = new CN_Capitulo();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                CargarDatosCapitulo();
            }
        }

        private void CargarDatosCapitulo()
        {
            try
            {
                Basicos objCapitulo = new Basicos();
                if (Session["SessionCapituloEdit"] != null)
                    objCapitulo = (Basicos)Session["SessionCapituloEdit"];
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, '" + ex.Message + ".')", true);
            }
        }

        protected void BTNGuardarCap_Click(object sender, EventArgs e)
        {
            try
            {
                if (SesionUsu.Usu_TipoUsu == "SA")
                {
                    Basicos objBasicos = new Basicos();
                    string Verificador = string.Empty;
                    objBasicos.clave = txtCap.Text;
                    objBasicos.descripcion = txtDescrip.Text;
                    objBasicos.valor = txtNvl.Text;
                    objBasicos.tipo = "CAT_CAPITULO";
                    objBasicos.status = "A";
                    CN_Capitulo.InsertarCapitulo(ref objBasicos, ref Verificador);
                    if (Verificador == "0")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Se ha guardado correctamente.')", true);                        
                        txtCap.Text = "";
                        txtDescrip.Text = "";                        
                    }
                    else                    
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, '"+ Verificador+".')", true);                        
                    
                }
                else                
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'No tiene los privilegios necesarios para realizar esta acción.')", true);                    
                
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, '"+ ex.Message+".')", true);
            }
        }
    }
}