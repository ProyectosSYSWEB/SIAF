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
                {
                    GRDFunciones.Columns.RemoveAt(3);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }        

        protected void GRDFunciones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblError.Text = string.Empty;
            try
            {
                Dependencias objDependencias = new Dependencias();
                string Verificador = string.Empty;
                int fila = e.RowIndex;
                objDependencias.C_Contab = Convert.ToString(GRDFunciones.Rows[fila].Cells[0].Text);
                //if (SesionUsu.Usu_TipoUsu == "SA")
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
                        lblError.Text = Verificador;
                }
                else
                    lblError.Text = "No tiene permisos para realizar esta acción";
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
                Response.Redirect("frmCatalogoFunciones.aspx", true);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
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
                        lblError.Text = "Se ha editado correctamente";
                    else
                        lblError.Text = Verificador;
                }
                else
                    lblError.Text = "No tiene permisos para realizar esta acción";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}