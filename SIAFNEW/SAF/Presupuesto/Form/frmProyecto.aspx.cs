﻿using CapaEntidad;
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
            try
            {
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Grid_Cat_TipoProy", ref DDLTipoProy, "p_todos", "N");
                DDLTipoProy.SelectedValue = "1";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        protected void CargarCombos2()
        {
            try
            {
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Grid_Cat_TipoProy", ref DDLTipoProy2, "p_todos", "N");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        protected void GRDCargarDatosProyectos()
        {
            try
            {
                Multiview1.ActiveViewIndex = 0;
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
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
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
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        protected void GRDProyectos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {            
            try
            {
                Proyectos objProyectos = new Proyectos();
                string Verificador = string.Empty;
                int fila = e.RowIndex;
                objProyectos.Id = Convert.ToString(GRDProyectos.Rows[fila].Cells[2].Text);
                if (SesionUsu.Usu_TipoUsu == "SA")
                {
                    CN_Proyecto.EliminarProyecto(objProyectos, ref Verificador);
                    if (Verificador == "0")
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Se ha eliminado correctamente.')", true);
                    else
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + ".')", true);
                }
                else                
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'No tiene privilegios para realizar esta acción.')", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        protected void GRDProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (SesionUsu.Usu_TipoUsu == "SA")
                {
                    Proyectos objProyectos = new Proyectos();
                    string Verificador = string.Empty;
                    CargarCombos2();
                    objProyectos.Id = Convert.ToString(GRDProyectos.SelectedRow.Cells[2].Text);
                    objProyectos.Ejercicio = SesionUsu.Usu_Ejercicio;
                    CN_Proyecto.ObtenerDatosProyecto(ref objProyectos, ref Verificador);
                    if(Verificador == "0")
                    {
                        //DDLTipoProy2.SelectedValue = objProyectos.Id_Tipo_Proyecto;
                        txtClavepro.Text = objProyectos.Clave_Proy;
                        txtDescrip.Text = objProyectos.Descrip;
                        Session["SessionIdProyecto"] = objProyectos.Id;
                        Multiview1.ActiveViewIndex = 1;
                    }
                    else
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + ".')", true);
                }
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
                Response.Redirect("frmCatalogoProyecto.aspx", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + ".')", true);
            }
        }
        protected void BTNEditarProyecto_Click(object sender, EventArgs e)
        {
            try
            {
                if (SesionUsu.Usu_TipoUsu == "SA")
                {
                    Proyectos objProyectos = new Proyectos();
                    string Verificador = string.Empty;
                    objProyectos.Id = (String)Session["SessionIdProyecto"];
                    objProyectos.Id_Tipo_Proyecto = DDLTipoProy2.SelectedValue;
                    objProyectos.Clave_Proy = txtClavepro.Text;
                    objProyectos.Descrip = txtDescrip.Text;
                    objProyectos.Ejercicio = SesionUsu.Usu_Ejercicio;
                    CN_Proyecto.EditarProyecto(ref objProyectos, ref Verificador);
                    if (Verificador == "0")
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Se ha modificado correctamente.')", true);
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