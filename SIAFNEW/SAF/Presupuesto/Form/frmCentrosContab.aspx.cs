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
    public partial class frmCentrosContab : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_CentrosContab CN_CentrosContab = new CN_CentrosContab();
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
            GRDCargarDatosCentrosContab();
        }
        protected void GRDCargarDatosCentrosContab()
        {
            try
            {                
                Multiview1.ActiveViewIndex = 0;
                CentrosContab objCentroContab = new CentrosContab();
                objCentroContab.Ejercicio = SesionUsu.Usu_Ejercicio;
                List<CentrosContab> list = new List<CentrosContab>();
                CN_CentrosContab.CContabGrid(ref objCentroContab, ref list);
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //sda.Fill(ds);//
                GRDCentrosContab.DataSource = list;
                GRDCentrosContab.DataBind();
                LBLncc.Text = "Total de centros contables: " + Convert.ToString(list.Count);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        protected void GRDCentrosContab_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblError.Text = string.Empty;
            try
            {
                string Verificador = string.Empty;
                CentrosContab objCContab = new CentrosContab();
                int fila = e.RowIndex;
                objCContab.Id = Convert.ToString(GRDCentrosContab.Rows[fila].Cells[2].Text);
                if (SesionUsu.Usu_TipoUsu == "SA")
                {
                    CN_CentrosContab.EliminarCContab(objCContab, ref Verificador);
                    if (Verificador == "0")
                        lblError.Text = "Se ha eliminado correctamente";
                    else
                        lblError.Text = Verificador;
                }
                else
                {
                    lblError.Text = "No tiene los privilegios para realizar esta acción";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        protected void GRDCentrosContab_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (SesionUsu.Usu_TipoUsu == "SA")
                {
                    Multiview1.ActiveViewIndex = 1;
                    string Verificador = string.Empty;
                    CentrosContab objCContab = new CentrosContab();
                    objCContab.Id = Convert.ToString(GRDCentrosContab.SelectedRow.Cells[2].Text);
                    objCContab.Ejercicio = SesionUsu.Usu_Ejercicio;
                    CN_CentrosContab.ObtenerDatosCContab(ref objCContab, ref Verificador);
                    if (Verificador == "0")
                    {
                        Session["SessionIdCContab"] = objCContab.Id;
                        txtCentroContab.Text = objCContab.C_Contab;
                        txtDependencia.Text = objCContab.Descrip;
                        txtDirector.Text = objCContab.Director;
                        txtAdministrador.Text = objCContab.Administrador;
                        txtEntrante.Text = objCContab.Saliente;
                        txtSaliente.Text = objCContab.Entrante;
                    }
                    else
                        lblError.Text = Verificador;
                }
                else
                    lblError.Text = "No tiene los privilegios para realizar esta acción";
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
                Response.Redirect("frmCatalogoCentrosContab.aspx", true);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        protected void BTNEditarCContab_Click(object sender, EventArgs e)
        {
            try
            {
                if (SesionUsu.Usu_TipoUsu == "SA")
                {
                    CentrosContab objCContab = new CentrosContab();
                    string Verificador = string.Empty;
                    objCContab.Id = (String)Session["SessionIdCContab"];
                    objCContab.C_Contab = txtCentroContab.Text.ToUpper();
                    objCContab.Descrip = txtDependencia.Text.ToUpper();
                    objCContab.Director = txtDirector.Text;
                    objCContab.Administrador = txtAdministrador.Text;
                    objCContab.Saliente = txtSaliente.Text;
                    objCContab.Entrante = txtEntrante.Text;
                    objCContab.Ejercicio = SesionUsu.Usu_Ejercicio;
                    CN_CentrosContab.EditarCContab(ref objCContab, ref Verificador);
                    if (Verificador == "0")
                        lblError.Text = "Se ha guardado correctamente";
                    else
                        lblError.Text = Verificador;
                }
                else
                {
                    lblError.Text = "No tiene los privilegios para realizar esta acción";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}