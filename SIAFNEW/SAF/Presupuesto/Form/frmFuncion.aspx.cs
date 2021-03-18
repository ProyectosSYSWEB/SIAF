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

        protected void GRDFunciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Dependencias objDependencias = new Dependencias();
                objDependencias.C_Contab = Convert.ToString(GRDFunciones.SelectedRow.Cells[0].Text);
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
                Response.Redirect("frmCatalogoFunciones.aspx", true);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}