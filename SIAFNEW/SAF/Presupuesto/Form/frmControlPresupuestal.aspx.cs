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
    public partial class frmControlPresupuestal : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Estruct CN_Estruct = new CN_Estruct();
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
            CargarCombos();
            GRDCargarDatosEstructuraProg();            
        }
        protected void CargarCombos()
        {
            try
            {
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref DDLDependencia, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, "P");
                DDLDependencia.SelectedValue = "1";
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        protected void GRDCargarDatosEstructuraProg()
        {
            try
            {
                Estruct objEstruct = new Estruct();
                objEstruct.Ejercicio = SesionUsu.Usu_Ejercicio;
                objEstruct.Dependencia = DDLDependencia.SelectedValue;
                List<Estruct> list = new List<Estruct>();
                CN_Estruct.EstructGrid(ref objEstruct, ref list);
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //sda.Fill(ds);//
                GRDEstrucProg.DataSource = list;
                GRDEstrucProg.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        protected void DDLCentroContab_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Estruct objEstruct = new Estruct();
                objEstruct.Ejercicio = SesionUsu.Usu_Ejercicio;
                objEstruct.Dependencia = DDLDependencia.SelectedValue;
                List<Estruct> list = new List<Estruct>();
                CN_Estruct.EstructGrid(ref objEstruct, ref list);
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //sda.Fill(ds);//
                GRDEstrucProg.DataSource = list;
                GRDEstrucProg.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        protected void GRDEstrucProg_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {            
            try
            {
                Dependencias objDependencias = new Dependencias();
                string Verificador = string.Empty;
                int fila = e.RowIndex;
                objDependencias.C_Contab = Convert.ToString(GRDEstrucProg.Rows[fila].Cells[3].Text);
                //if (SesionUsu.Usu_TipoUsu == "SU")
                //{
                //    CN_Dependencias.EliminarDependencia(ref objDependencias, ref Verificador);
                //    if (Verificador == "0")
                //        lblError.Text = "Se ha eliminado correctamente";
                //    else
                //        lblError.Text = Verificador;
                //}
                //else
                //{
                //    lblError.Text = Verificador;
                //}
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        protected void GRDEstrucProg_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Dependencias objDependencias = new Dependencias();
                objDependencias.C_Contab = Convert.ToString(GRDEstrucProg.SelectedRow.Cells[3].Text);
                //strEstatus = grdDocumentos.SelectedRow.Cells[8].Text;

                //MultiView1.ActiveViewIndex = 1;
                //TabGridDepen.ActiveTabIndex = 0;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Response.Redirect("frmCatalogoCtrlPres.aspx", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
    }
}