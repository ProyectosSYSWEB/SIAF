using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEntidad;
using CapaNegocio;

namespace SAF.Presupuesto.Form
{
    public partial class FRMcrea_Plantilla : System.Web.UI.Page
    {
        #region <Variables>
        Int32[] Celdas = new Int32[] { 0 };
        string Verificador = string.Empty;
        string VerificadorDet = string.Empty;
        CN_Usuario CNUsuario = new CN_Usuario();
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Pres_Plantilla CNPlantilla = new CN_Pres_Plantilla();
        CN_Pres_Documento_Det CNDocDet = new CN_Pres_Documento_Det();
        Pres_Plantilla objPlantilla = new Pres_Plantilla();
        private static List<Comun> ListDependencia = new List<Comun>();
        int guar_continue;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                //SesionUsu.Editar = -1;
                inicializar();

            }
        }
        private void inicializar()
        {
            lblError.Text = string.Empty;
            try
            {
                SesionUsu.Usu_Rep = "A";
                MultiView1.ActiveViewIndex = 0;
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref ddlDependencia, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, SesionUsu.Usu_Rep, ref ListDependencia);
                CNComun.LlenaCombo("DPP.PKG_PRES.OBT_Combo_Semestre", ref ddlSemestre, "p_ejercicio", SesionUsu.Usu_Ejercicio, "DPP");
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void GRDDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MultiView1.ActiveViewIndex = 2;        
                int j = GRDDependencia.SelectedIndex;
                ddlDependencia.SelectedValue= GRDDependencia.Rows[j].Cells[0].Text;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {            
            try
            {
                int j = GRDDependencia.SelectedIndex;
                objPlantilla.Dependencia = GRDDependencia.Rows[j].Cells[0].Text;
                objPlantilla.Semestre = ddlSemestre.SelectedValue;
                objPlantilla.Fecha_Ini = txtfecha_ini.Text;
                objPlantilla.Fecha_Fin = txtfecha_fin.Text;
                objPlantilla.Usuario = SesionUsu.Usu_Nombre;               
                Verificador = string.Empty;
                CNPlantilla.Insertar_New_Plantilla(ref objPlantilla, ref Verificador);              
                if (Verificador == "0")
                {
                    // ModalPopupExtender.Show();  
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'La apertura de la plantilla se realizo con exito');", true);
                    CargarGrid(ref GRDEmpledo, 0);
                    MultiView1.ActiveViewIndex = 1;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void cancelar_act_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;            
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {            
            try
            {
                MultiView1.ActiveViewIndex = 0;
                CargarGrid(ref GRDDependencia);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void DDLDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlSemestre_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BTNbuscar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CargarGrid(ref GRDDependencia);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        private void CargarGrid(ref GridView grid)
        {
            lblError.Text = string.Empty;
            grid.DataSource = null;
            grid.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grid.DataSource = dt;
                grid.DataSource = GetList();
                grid.DataBind();
                Celdas = new Int32[] { };
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

        private List<Pres_Plantilla> GetList()
        {
            try
            {
                List<Pres_Plantilla> List = new List<Pres_Plantilla>();
                int e = GRDDependencia.SelectedIndex;
                objPlantilla.Dependencia = ddlDependencia.SelectedValue;
                objPlantilla.Semestre = ddlSemestre.SelectedValue;
                CNPlantilla.ConsultaGrid_New_Semestre(ref objPlantilla, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void Agrega_act_Click(object sender, EventArgs e)
        {
            try
            {
                CargarGrid(ref GRDEmpledo, 0);
                MultiView1.ActiveViewIndex = 1;
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
                Celdas = new Int32[] { };
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

        private List<Pres_Plantilla> GetList(int IdGrid)
        {
            try
            {
                List<Pres_Plantilla> List = new List<Pres_Plantilla>();
                objPlantilla.Semestre = ddlSemestre.SelectedValue;
                objPlantilla.Dependencia = ddlDependencia.SelectedValue;
                objPlantilla.Buscar = string.Empty;              
                CNPlantilla.ConsultaGrid_Plantilla(ref objPlantilla, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void GRDEmpledo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GRDEmpledo.PageIndex = 0;
            GRDEmpledo.PageIndex = e.NewPageIndex;
            CargarGrid(ref GRDEmpledo, 0);
        }

        protected void GRDEmpledo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = string.Empty;                
                int v = GRDEmpledo.SelectedIndex;
                objPlantilla.Id = GRDEmpledo.Rows[v].Cells[0].Text;           
                CNPlantilla.Delete_Plantilla(ref objPlantilla, ref Verificador);
                if (Verificador == "0")
                {
                    CargarGrid(ref GRDEmpledo, 0);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Se eliminó el docente de esta plantilla');", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '"+Verificador+"');", true);

                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        
    }
}