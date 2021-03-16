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
    public partial class frmCapitulo : System.Web.UI.Page
    {
        #region Variables
        Sesion SesionUsu = new Sesion();
        CN_Capitulo CN_Capitulo = new CN_Capitulo();        
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
            GRDCargarDatosDepend();
        }

        protected void GRDCargarDatosDepend()
        {
            try
            {
                Basicos objBasicos = new Basicos();
                List<Basicos> list = new List<Basicos>();
                objBasicos.tipo = "CAT_CAPITULO";
                objBasicos.valor = "1";
                CN_Capitulo.CapitulosGrid(ref objBasicos, ref list);
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //sda.Fill(ds);//
                GRDCapitulos.DataSource = list;
                GRDCapitulos.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }      
        protected void GRDCapitulos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblError.Text = string.Empty;
            try
            {
                Dependencias objDependencias = new Dependencias();
                string Verificador = string.Empty;
                int fila = e.RowIndex;
                objDependencias.C_Contab = Convert.ToString(GRDCapitulos.Rows[fila].Cells[2].Text);
            //    if (SesionUsu.Usu_TipoUsu == "SU")
            //    {
            //        CN_Dependencias.EliminarDependencia(ref objDependencias, ref Verificador);
            //        if (Verificador == "0")
            //            lblError.Text = "Se ha eliminado correctamente";
            //        else
            //            lblError.Text = Verificador;
            //    }
            //    else
            //    {
            //        lblError.Text = Verificador;
            //    }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void GRDCapitulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Dependencias objDependencias = new Dependencias();
                objDependencias.C_Contab = Convert.ToString(GRDCapitulos.SelectedRow.Cells[2].Text);
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
                Response.Redirect("frmCatalogoCapitulos.aspx", true);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}