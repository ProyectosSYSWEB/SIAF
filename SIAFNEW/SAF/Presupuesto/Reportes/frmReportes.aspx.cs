using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEntidad;
using CapaNegocio;

namespace SAF.Presupuesto.Reportes
{
    public partial class frmReportes : System.Web.UI.Page
    {
        #region <Variables>
        Int32[] Celdas = new Int32[] { 0 };
        string Verificador = string.Empty;
        string VerificadorDet = string.Empty;
        CN_Usuario CNUsuario = new CN_Usuario();
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Pres_Reportes CNReportes = new CN_Pres_Reportes();      
        Pres_Reportes objReportes = new Pres_Reportes();
        private static List<Pres_Reportes> ListCodigo = new List<Pres_Reportes>();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                //SesionUsu.Editar = -1;
                inicializar();

            }
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "PRUEBA", "Autocomplete();", true);


        }
        private void inicializar()
        {
            lblError.Text = string.Empty;
            try
            {
                MultiView1.ActiveViewIndex = 0;
                cargarcombos();

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }
        private void cargarcombos()
        {
            try
            {             
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref ddlDependencia, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, "A");
               

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }
        protected void imgBttnPdf(object sender, ImageClickEventArgs e)
        {
            try
            {
                rowFuente();
                rowCapitulo();
                string ruta1 = string.Empty;
                switch (ddltipo.SelectedValue)
                {
                    case "EJERCIDO":
                        ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-EJERCIDO&Ejercicio="+SesionUsu.Usu_Ejercicio +"&Fuente="+ objReportes.Fuente+"&Capitulo="+objReportes.Capitulo+"&Ministrable="+ddlministrable.SelectedValue+"&Dependencia=" + ddlDependencia.SelectedValue;
                        break;
                    case "AUMENTO":
                        ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-AUMENTO&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + objReportes.Fuente + "&Capitulo=" + objReportes.Capitulo + "&Ministrable=" + ddlministrable.SelectedValue + "&Dependencia=" + ddlDependencia.SelectedValue;
                        break;
                    case "AUTORIZADO":
                        ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-AUTORIZADO&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + objReportes.Fuente + "&Capitulo=" + objReportes.Capitulo + "&Ministrable=" + ddlministrable.SelectedValue + "&Dependencia=" + ddlDependencia.SelectedValue;
                        break;
                    case "MODIFICADO":
                        ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-MODIFICADO&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + objReportes.Fuente + "&Capitulo=" + objReportes.Capitulo + "&Ministrable=" + ddlministrable.SelectedValue + "&Dependencia=" + ddlDependencia.SelectedValue;
                        break;
                    case "DISMINUCION":
                        ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-DISMINUCION&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + objReportes.Fuente + "&Capitulo=" + objReportes.Capitulo + "&Ministrable=" + ddlministrable.SelectedValue + "&Dependencia=" + ddlDependencia.SelectedValue;
                        break;
                    case "COMPROMETIDO":
                        ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-COMPROMETIDO&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + objReportes.Fuente + "&Capitulo=" + objReportes.Capitulo + "&Ministrable=" + ddlministrable.SelectedValue + "&Dependencia=" + ddlDependencia.SelectedValue;
                        break;
                    case "XMINISTRAR":
                        ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-XMINISTRAR&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + objReportes.Fuente + "&Capitulo=" + objReportes.Capitulo + "&Ministrable=" + ddlministrable.SelectedValue + "&Dependencia=" + ddlDependencia.SelectedValue;
                        break;
                    case "MINISTRADO":
                        ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-MINISTRADO&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + objReportes.Fuente + "&Capitulo=" + objReportes.Capitulo + "&Ministrable=" + ddlministrable.SelectedValue + "&Dependencia=" + ddlDependencia.SelectedValue;
                        break;
                    case "XEJERCER":
                        ruta1 = "VisualizadorCrystal.aspx?Tipo=RP-XEJERCER&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Fuente=" + objReportes.Fuente + "&Capitulo=" + objReportes.Capitulo + "&Ministrable=" + ddlministrable.SelectedValue + "&Dependencia=" + ddlDependencia.SelectedValue;
                        break;




                        






                }
                string _open1 = "window.open('" + ruta1 + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }           
        }

        protected void imgBttnExcel(object sender, ImageClickEventArgs e)
        {

        }

        protected void ddlDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarGrid(ref grdFuente, 0);
                CargarGrid(ref grdCapitulo, 1);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        private void CargarGrid(ref GridView grid, int idGrid)
        {
            lblError.Text = string.Empty;
            grid.DataSource = null;
            grid.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grid.DataSource = dt;
                grid.DataSource = GetList(idGrid);
                grid.DataBind();
                Celdas = new Int32[] { 1};
                if (grid.Rows.Count > 0)
                {
                    CNComun.HideColumns(grid, Celdas);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        public void rowFuente()
        {
            try
            {
                objReportes.Fuente = "0";
            foreach (GridViewRow row in grdFuente.Rows)
            {
                CheckBox chkUrs_Disponibles = (CheckBox)row.FindControl("chkfuente");
                if (chkUrs_Disponibles.Checked == true)
                {
                        objReportes.Fuente  = objReportes.Fuente +","+ Convert.ToString(grdFuente.Rows[row.RowIndex].Cells[1].Text);

                    }
                }           

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
         }
        public void rowCapitulo()
        {
            try
            {
                objReportes.Capitulo = "0";
                foreach (GridViewRow row in grdCapitulo .Rows)
                {
                    CheckBox chkUrs_Disponibles = (CheckBox)row.FindControl("chkcapitulo");
                    if (chkUrs_Disponibles.Checked == true)
                    {
                        objReportes.Capitulo  = objReportes.Capitulo + "," + Convert.ToString(grdCapitulo.Rows[row.RowIndex].Cells[1].Text);
                    }
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        private List<Pres_Reportes> GetList(int IdGrid)
        {
            try
            {
                List<Pres_Reportes> List = new List<Pres_Reportes>();               
                objReportes.Dependencia = ddlDependencia.SelectedValue;
                objReportes.Ejercicio = SesionUsu.Usu_Ejercicio;
                if (IdGrid == 0)
                {
                    CNReportes.ConsultaGrid_Fuente_F(ref objReportes, ref List);
                }
                else
                {                  
                    CNReportes.ConsultaGrid_Capitulo(ref objReportes, ref List);
                }

                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}