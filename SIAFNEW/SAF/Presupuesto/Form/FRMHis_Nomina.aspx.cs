using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEntidad;
using CapaNegocio;


namespace SAF.Presupuesto
{
    public partial class FRMHis_Nomina : System.Web.UI.Page
    {
        #region <Variables>
        Int32[] Celdas = new Int32[] { 0 };
        string Verificador = string.Empty;
        string VerificadorDet = string.Empty;
        CN_Usuario CNUsuario = new CN_Usuario();
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Pres_Nomina CNNomina = new CN_Pres_Nomina();
        Pres_Nomina objNomina = new Pres_Nomina();
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
                MultiView1.ActiveViewIndex = 0;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }
        protected void grdTrabajadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //int v = grdTrabajadores.SelectedIndex;
                //lblNombre0.Text = grdTrabajadores.Rows[v].Cells[0].Text + "    RFC:  " + grdTrabajadores.Rows[v].Cells[1].Text;
                CargarGrid(ref grdNominas_pag, 1);
                MultiView1.ActiveViewIndex = 1;
            }
            catch (Exception ex)
            {
            }
        }

       

        protected void ddlEjercicio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BTNbuscar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //CargarGrid(ref grdTrabajadores, 0);
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

                //SesionUsu.DependenciaB = DDLDependencia.SelectedValue;
                //SesionUsu.BusquedaB = txtBuscar.Text;
                //SesionUsu.StatusB = DDLStatus.SelectedValue;
                //SesionUsu.TipoPersonalB = DDLTipoEmpleado.SelectedValue;


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
        private List<Pres_Nomina> GetList(int IdGrid)
        {
            try
            {
                List<Pres_Nomina> List = new List<Pres_Nomina>();
                objNomina.Buscar = txtBuscar.Text;

                if (IdGrid == 0)
                {
                    CNNomina.ConsultaGrid_Trabajador(ref objNomina, ref List);
                }
                else
                {
                    int v = GridEmpleados.SelectedIndex;             
                    objNomina.RFC = GridEmpleados.Rows[v].Cells[1].Text;                    
                    CNNomina.ConsultaMovimiento_Nomina(ref objNomina, ref List);
                }

                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void ddlEjercicio0_SelectedIndexChanged(object sender, EventArgs e)
        {          
            
        }
       
        protected void grdNominas_pag_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void GridEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int v = GridEmpleados.SelectedIndex;
                lblNombre0.Text = GridEmpleados.Rows[v].Cells[0].Text + "    RFC:  " + GridEmpleados.Rows[v].Cells[1].Text;
                CargarGrid(ref grdNominas_pag, 1);
                MultiView1.ActiveViewIndex = 1;
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}