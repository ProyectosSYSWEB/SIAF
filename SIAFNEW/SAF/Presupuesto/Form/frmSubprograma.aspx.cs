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
    public partial class frmSubprograma : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Subprog CN_Subprog = new CN_Subprog();
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
        protected void CargarCombos()
        {
            CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Nvl_Academicos", ref DDLNvlacd, "p_tipocombo", "T");
        }
        protected void GRDCargarDatosFuncion()
        {
            try
            {
                Multiview1.ActiveViewIndex = 0;
                Subprograma objSubprogramaa = new Subprograma();
                List<Subprograma> list = new List<Subprograma>();
                objSubprogramaa.DependenciaI = "11101";
                objSubprogramaa.DependenciaF = "81101";
                objSubprogramaa.NivAcad = "9";
                objSubprogramaa.Ejercicio = SesionUsu.Usu_Ejercicio;
                CN_Subprog.SubprogramasGrid(ref objSubprogramaa, ref list);
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //sda.Fill(ds);//
                GRDProgramas.DataSource = list;
                GRDProgramas.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        protected void DDLNvlacd_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Subprograma objSubprogramaa = new Subprograma();
                List<Subprograma> list = new List<Subprograma>();
                objSubprogramaa.DependenciaI = "11101";
                objSubprogramaa.DependenciaF = "81101";
                objSubprogramaa.NivAcad = DDLNvlacd.SelectedValue;
                objSubprogramaa.Ejercicio = SesionUsu.Usu_Ejercicio;
                CN_Subprog.SubprogramasGrid(ref objSubprogramaa, ref list);
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //sda.Fill(ds);//
                GRDProgramas.DataSource = list;
                GRDProgramas.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        protected void GRDProgramas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblError.Text = string.Empty;
            try
            {
                Subprograma objSubProg = new Subprograma();
                string Verificador = string.Empty;
                int fila = e.RowIndex;
                objSubProg.Id = Convert.ToString(GRDProgramas.Rows[fila].Cells[2].Text);
                if (SesionUsu.Usu_TipoUsu == "SA")
                {
                    CN_Subprog.EliminarSubProg(objSubProg, ref Verificador);
                    if (Verificador == "0")
                        lblError.Text = "Se ha eliminado correctamente";
                    else
                        lblError.Text = Verificador;
                }
                else
                {
                    lblError.Text = Verificador;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        protected void GRDProgramas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (SesionUsu.Usu_TipoUsu == "SA")
                {                    
                    Subprograma objSubProg = new Subprograma();
                    string Verificador = string.Empty;
                    CargarCombos2();
                    objSubProg.Id = Convert.ToString(GRDProgramas.SelectedRow.Cells[2].Text);
                    CN_Subprog.ObtenerDatosSubprograma(ref objSubProg, ref Verificador);
                    if (Verificador == "0")
                    {
                        Multiview1.ActiveViewIndex = 1;
                        Session["SessionIdSubProg"] = objSubProg.Id;
                        DDLNvlacd2.SelectedValue = objSubProg.NivAcad;
                        txtPrograma.Text = objSubProg.Clave;
                        txtDescripcion.Text = objSubProg.Descripcion;
                    }
                    else
                    {
                        lblError.Text = Verificador;
                    }
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
                Response.Redirect("frmCatalogoSubProg.aspx", true);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        protected void CargarCombos2()
        {
            try
            {
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Nvl_Academicos", ref DDLNvlacd2, "p_tipocombo", "T");
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        protected void BTNEditarSubProg_Click(object sender, EventArgs e)
        {
            try
            {

                if(SesionUsu.Usu_TipoUsu == "SA")
                {
                    Subprograma objSubProg = new Subprograma();
                    string Verificador = string.Empty;
                    objSubProg.Id = (String)Session["SessionIdSubProg"];
                    objSubProg.NivAcad = DDLNvlacd2.SelectedValue;
                    objSubProg.Clave = txtPrograma.Text;
                    objSubProg.Descripcion = txtDescripcion.Text;
                    CN_Subprog.EditarSubProg(ref objSubProg, ref Verificador);
                    if (Verificador == "0")
                        lblError.Text = "Se ha modificado correctamente";
                    else
                        lblError.Text = Verificador;
                }
                else
                    lblError.Text = "No tiene privilegios para realizar esta acción";
            }
            catch (Exception ex) 
            {
                lblError.Text = ex.Message;
            }
        }
    }
}