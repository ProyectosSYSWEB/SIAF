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
    public partial class frmProyecto : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Proyecto CN_Proyecto = new CN_Proyecto();
        Pres_Reportes objReportes = new Pres_Reportes();
        string capitulos = "";
        List<string> ListaCaps = new List<string>();
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
            GRDCargarDatosProyectos();
            
        }

        protected void CargarCombos()
        {
            CNComun.LlenaCombo("pkg_Presupuesto.Obt_Grid_Cat_TipoProy", ref DDLTipoProy, "p_todos", "N");
            DDLTipoProy.SelectedValue = "1";
        }

        protected void GRDCargarDatosProyectos()
        {
            try
            {
                Proyectos objProyectos = new Proyectos();
                objProyectos.Ejercicio = SesionUsu.Usu_Ejercicio;
                string Proyecto = DDLTipoProy.SelectedValue;
                objProyectos.Tipo_Proy = Proyecto.Substring(0, 1);
                List<Proyectos> listPresUnv = new List<Proyectos>();
                CN_Proyecto.ProyectoGrid(ref objProyectos, ref listPresUnv);                
                GRDProyectos.DataSource = listPresUnv;
                GRDProyectos.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void DDLTipoProy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Proyectos objProyectos = new Proyectos();
                objProyectos.Ejercicio = SesionUsu.Usu_Ejercicio;
                string Proyecto = DDLTipoProy.SelectedValue;
                objProyectos.Tipo_Proy = Proyecto.Substring(0, 1);
                List<Proyectos> listPresUnv = new List<Proyectos>();
                CN_Proyecto.ProyectoGrid(ref objProyectos, ref listPresUnv);
                GRDProyectos.DataSource = listPresUnv;
                GRDProyectos.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void GRDProyectos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblError.Text = string.Empty;
            try
            {
                Dependencias objDependencias = new Dependencias();
                string Verificador = string.Empty;
                int fila = e.RowIndex;
                objDependencias.C_Contab = Convert.ToString(GRDProyectos.Rows[fila].Cells[3].Text);
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
                lblError.Text = ex.Message;
            }
        }

        protected void GRDProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Dependencias objDependencias = new Dependencias();
                objDependencias.C_Contab = Convert.ToString(GRDProyectos.SelectedRow.Cells[3].Text);
                //strEstatus = grdDocumentos.SelectedRow.Cells[8].Text;

                //MultiView1.ActiveViewIndex = 1;
                //TabGridDepen.ActiveTabIndex = 0;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Response.Redirect("frmCatalogoProyecto.aspx", true);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}