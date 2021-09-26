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
    public partial class frmCatalogoProyecto : System.Web.UI.Page
    {

        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Proyecto CN_Proyecto = new CN_Proyecto();
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
            CNComun.LlenaCombo("pkg_Presupuesto.Obt_Grid_Cat_TipoProy", ref DDLTipoProy, "p_todos", "N");
        }
        protected void BTNGuardarProyecto_Click(object sender, EventArgs e)
        {
            try
            {
                Proyectos objProyectos = new Proyectos();
                if (SesionUsu.Usu_TipoUsu == "SA")
                {
                    objProyectos.Id_Tipo_Proyecto = DDLTipoProy.SelectedValue;
                    objProyectos.Clave_Proy = txtClavepro.Text;
                    objProyectos.Descrip = txtDescrip.Text;
                    objProyectos.Status = "A";
                    objProyectos.Ejercicio = SesionUsu.Usu_Ejercicio;
                    string Verificador = string.Empty;
                    CN_Proyecto.InsertarProyecto(ref objProyectos, ref Verificador);
                    if (Verificador == "0")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Se ha guardado correctamente.')", true);                        
                        txtClavepro.Text = "";
                        txtDescrip.Text = "";
                        DDLTipoProy.SelectedIndex = 0;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '"+ Verificador+" .')", true);
                    }
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'No tiene los privilegios para realizar esta acción.')", true);                
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);                
            }
        }
    }
}