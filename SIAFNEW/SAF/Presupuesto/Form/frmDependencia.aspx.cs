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
    public partial class frmDependencia : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Dependencias CN_Dependencias = new CN_Dependencias();
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
            GRDCargarDatosDepend();
        }


        protected void CargarCombos()
        {
            CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_CentrosContab", ref DDLCentroContab, "p_ejercicio", SesionUsu.Usu_Ejercicio);
        }


        protected void GRDCargarDatosDepend()
        {
            try
            {
                Dependencias objDependencias = new Dependencias();
                List<Dependencias> list = new List<Dependencias>();
                objDependencias.C_Contab = DDLCentroContab.SelectedValue;
                objDependencias.Ejercicio = Convert.ToInt32( SesionUsu.Usu_Ejercicio);
                CN_Dependencias.DependenciasGrid(ref objDependencias, ref list);
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //sda.Fill(ds);//
                GDRDependencias.DataSource = list;
                GDRDependencias.DataBind();
                LBLNumDepend.Text = "Total de dependencias: " + list.Count;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void DDLCentroContab_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Dependencias objDependencias = new Dependencias();
                List<Dependencias> list = new List<Dependencias>();
                objDependencias.C_Contab = DDLCentroContab.SelectedValue;
                objDependencias.Ejercicio = Convert.ToInt32( SesionUsu.Usu_Ejercicio);
                CN_Dependencias.DependenciasGrid(ref objDependencias, ref list);
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //sda.Fill(ds);//
                GDRDependencias.DataSource = list;
                GDRDependencias.DataBind();
                LBLNumDepend.Text = "Total de dependencias: " + list.Count;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void GDRDependencias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblError.Text = string.Empty;
            try
            {
                Dependencias objDependencias = new Dependencias();
                string Verificador = string.Empty;
                int fila = e.RowIndex;
                objDependencias.C_Contab = Convert.ToString(GDRDependencias.Rows[fila].Cells[6].Text);
                if (SesionUsu.Usu_TipoUsu == "SU")
                {
                    CN_Dependencias.EliminarDependencia(ref objDependencias, ref Verificador);
                    if(Verificador == "0")
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

        protected void GDRDependencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Dependencias objDependencias = new Dependencias();
                objDependencias.C_Contab = Convert.ToString(GDRDependencias.SelectedRow.Cells[6].Text);
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
                Response.Redirect("frmCatalogoDependencias.aspx", true);
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}