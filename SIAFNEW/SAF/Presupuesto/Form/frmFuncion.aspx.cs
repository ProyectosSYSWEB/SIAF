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
    public partial class frmFuncion : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Funcion CN_Funcion = new CN_Funcion();
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
        }
        protected void GRDCargarDatosFuncion()
        {
            try
            {
                Multiview1.ActiveViewIndex = 0;
                Funcion objFuncion = new Funcion();
                List<Funcion> listFuncion = new List<Funcion>();
                CN_Funcion.FuncionGrid(ref objFuncion, ref listFuncion);
                GRDFunciones.DataSource = listFuncion;
                GRDFunciones.DataBind();
                if (SesionUsu.Usu_TipoUsu != "SA")                
                    GRDFunciones.Columns.RemoveAt(3);                
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "')", true);
            }
        }        
        protected void GRDFunciones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {            
            try
            {
                string Verificador = string.Empty;
                Funcion objFuncion = new Funcion();
                int fila = e.RowIndex;
                objFuncion.Clave = Convert.ToString(GRDFunciones.Rows[fila].Cells[0].Text);
                if (SesionUsu.Usu_TipoUsu == "SA")
                {
                    CN_Funcion.Eliminar(objFuncion, ref Verificador);                    
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
        protected void GRDFunciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (SesionUsu.Usu_TipoUsu == "SA")
                {                    
                    string Verificador = string.Empty;
                    Funcion objFuncion = new Funcion();
                    objFuncion.Clave = Convert.ToString(GRDFunciones.SelectedRow.Cells[0].Text);
                    CN_Funcion.ObtenerDatosFuncion(ref objFuncion, ref Verificador);
                    if (Verificador == "0")
                    {
                        Session["SessionIDFuncion"] = objFuncion.Id;
                        txtFuncion.Text = objFuncion.Clave;
                        txtDescripcion.Text = objFuncion.Descripcion;
                        Multiview1.ActiveViewIndex = 1;
                    }
                    else
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "')", true);                    
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'No tiene permisos para realizar esta acción')", true);
                    
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
                Response.Redirect("frmCatalogoFunciones.aspx", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "')", true);
            }
        }
        protected void BTNEditarFuncion_Click(object sender, EventArgs e)
        {
            try
            {
                if (SesionUsu.Usu_TipoUsu == "SA")
                {
                    string Verificador = string.Empty;
                    Funcion objFuncion = new Funcion();
                    objFuncion.Id = (String)Session["SessionIDFuncion"];
                    objFuncion.Clave = txtFuncion.Text;
                    objFuncion.Descripcion = txtDescripcion.Text;
                    CN_Funcion.EditarFuncion(ref objFuncion, ref Verificador);
                    if (Verificador == "0")
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Se ha editado correctamente')", true);
                    else
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "')", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'No tiene permisos para realizar esta acción')", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "')", true);
            }
        }
    }
}