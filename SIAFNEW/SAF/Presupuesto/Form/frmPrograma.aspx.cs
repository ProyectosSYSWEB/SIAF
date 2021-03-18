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
                lblError.Text = ex.Message;
            }
        }

        protected void GRDCargarDatosFuncion()
        {
            try
            {
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
                lblError.Text = ex.Message;
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
                lblError.Text = ex.Message;
            }
        }

        protected void GRDProgramas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblError.Text = string.Empty;
            try
            {
                Dependencias objDependencias = new Dependencias();
                string Verificador = string.Empty;
                int fila = e.RowIndex;
                objDependencias.C_Contab = Convert.ToString(GRDProgramas.Rows[fila].Cells[2].Text);
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

        protected void GRDProgramas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Dependencias objDependencias = new Dependencias();
                objDependencias.C_Contab = Convert.ToString(GRDProgramas.SelectedRow.Cells[2].Text);
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
                Response.Redirect("frmCatalogoProgramas.aspx", true);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}