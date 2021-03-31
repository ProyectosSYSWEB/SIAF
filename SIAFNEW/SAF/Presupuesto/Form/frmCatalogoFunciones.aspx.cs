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
    public partial class frmCatalogoFunciones : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Funcion CN_Funcion = new CN_Funcion();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];            
        }        

        protected void BTNGuardarFuncion_Click(object sender, EventArgs e)
        {
            try
            {
                if (SesionUsu.Usu_TipoUsu == "SA")
                {
                    Funcion objFuncion = new Funcion();
                    objFuncion.Clave = txtFuncion.Text;
                    objFuncion.Descripcion = txtDescripcion.Text;
                    objFuncion.Valor = "";
                    objFuncion.Tipo = "CAT_FUNCION";
                    objFuncion.Status = "A";
                    objFuncion.Orden = "";
                    string Verificador = string.Empty;
                    CN_Funcion.InsertarFuncion(ref objFuncion, ref Verificador);
                    if (Verificador == "0")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 1, 'Se ha guardado correctamente.');", true);
                        txtFuncion.Text = "";
                        txtDescripcion.Text = "";                        
                    }
                    else
                    {                        
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '"+ Verificador+"')", true);
                    }
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'No tiene los privilegios necesarios para realizar esta acción.');", true);                    
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "')", true);
            }
        }
    }
}