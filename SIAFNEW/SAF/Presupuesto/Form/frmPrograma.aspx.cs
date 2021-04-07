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
    public partial class frmPrograma : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Programa CN_Programa = new CN_Programa();
        CN_Comun CNComun = new CN_Comun();
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
            GRDCargarDatosFuncion();
            CargarCombos();
        }
        private void CargarCombos()
        {
            try {
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Funcion", ref DDLFuncion);                
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "')", true);
            }
        }
        private void CargarCombosEdit()
        {
            try
            {
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Funcion", ref DDLFuncion2);
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "')", true);
            }
        }
        protected void GRDCargarDatosFuncion()
        {
            try
            {
                Multiview1.ActiveViewIndex = 0;
                Programa objPrograma = new Programa();
                List<Programa> list = new List<Programa>();
                objPrograma.Funcion = "0";
                CN_Programa.ProgramasGrid(ref objPrograma, ref list);
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //sda.Fill(ds);//
                GRDProgramas.DataSource = list;
                GRDProgramas.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "')", true);
            }
        }
        protected void DDLFuncion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Programa objPrograma = new Programa();
                List<Programa> list = new List<Programa>();
                objPrograma.Funcion = DDLFuncion.SelectedValue;
                CN_Programa.ProgramasGrid(ref objPrograma, ref list);
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //sda.Fill(ds);//
                GRDProgramas.DataSource = list;
                GRDProgramas.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "')", true);
            }
        }
        protected void GRDProgramas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {            
            try
            {
                Programa objPrograma = new Programa();
                string Verificador = string.Empty;
                int fila = e.RowIndex;
                objPrograma.Id = Convert.ToString(GRDProgramas.Rows[fila].Cells[3].Text);
                if (SesionUsu.Usu_TipoUsu == "SA")
                {
                    CN_Programa.EliminarPrograma(objPrograma, ref Verificador);
                    if (Verificador == "0")
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Se ha eliminado correctamente')", true);
                    else
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "')", true);
                }
                else                
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'No tiene privilegios para realizar esta acción')", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "')", true);
            }
        }
        protected void GRDProgramas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (SesionUsu.Usu_TipoUsu == "SA")
                {
                    CargarCombosEdit();
                    string Verificador = string.Empty;
                    Programa objPrograma = new Programa();
                    objPrograma.Id = Convert.ToString(GRDProgramas.SelectedRow.Cells[3].Text);
                    CN_Programa.ObtenerDatosPrograma(ref objPrograma, ref Verificador);
                    if (Verificador == "0")
                    {
                        Multiview1.ActiveViewIndex = 1;
                        Session["SessionFuncionEdit"] = objPrograma.Id;
                        DDLFuncion2.SelectedValue = objPrograma.Id_FuncionProg;
                        txtPrograma.Text = objPrograma.Clave;
                        txtDescripcion.Text = objPrograma.Descripcion;
                    }
                    else
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, '" + Verificador + "')", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'No tiene privilegios para realizar esta acción')", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "')", true);
            }
        }
        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Response.Redirect("frmCatalogoProgramas.aspx", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "')", true);
            }
        }
        protected void BTNEditarProg_Click(object sender, EventArgs e)
        {
            try
            {
                if (SesionUsu.Usu_TipoUsu == "SA")
                {
                    string Verificador = string.Empty;
                    Programa objPrograma = new Programa();
                    objPrograma.Id = (String)Session["SessionFuncionEdit"];
                    objPrograma.Id_FuncionProg = DDLFuncion2.SelectedValue;
                    objPrograma.Clave = txtPrograma.Text;
                    objPrograma.Descripcion = txtDescripcion.Text;
                    CN_Programa.EditarPrograma(ref objPrograma, ref Verificador);
                    if (Verificador == "0")
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Se ha modificado correctamente')", true);
                    else
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "')", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'No tiene privielgios para realizar esta acción')", true);
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "')", true);
            }
        }
        protected void imgBttnPdf_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

            }
            catch(Exception ex) 
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "')", true);
            }
        }
        protected void btnObtnerReporte(object sender, ImageClickEventArgs e)
        {
            try
            {
                string ruta1 = "";
                ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RPT-PRESUP_PROGRAMAS";
                string _open1 = "window.open('" + ruta1 + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
    }
}