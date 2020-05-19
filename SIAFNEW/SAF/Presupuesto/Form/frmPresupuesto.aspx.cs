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
    public partial class frmPresupuesto : System.Web.UI.Page
    {
        #region <Variables>
        Sesion SesionUsu = new Sesion();
        Mnu mnu = new Mnu();
        Presupues objPresupuesto = new Presupues();
        CN_Mnu CN_mnu = new CN_Mnu();
        CN_Presupuesto CNPresupuesto = new CN_Presupuesto();
        List<Presupues> listPresupuesto = new List<Presupues>();

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                Inicializar();
            }
        }


        #region <Funciones y Sub>
        private void Inicializar()
        {
            objPresupuesto.Ejercicio =Convert.ToInt32(SesionUsu.Usu_Ejercicio);
            CN_mnu.LlenarTree(ref trvPresupuesto, objPresupuesto, listPresupuesto);
            //if (trvPresupuesto.Nodes.Count >= 1)
                //trvPresupuesto.SelectedNode.Select();
            trvPresupuesto_SelectedNodeChanged(null, null);
        }
        private void CargarGrid()
        {
            lblError.Text = string.Empty;
            grvPresupuesto.DataSource = null;
            grvPresupuesto.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grvPresupuesto.DataSource = dt;
                grvPresupuesto.DataSource = GetList();
                grvPresupuesto.DataBind();
                if (grvPresupuesto.Rows.Count > 0)
                {
                    Sumatoria(grvPresupuesto);
                }
                else
                {
                    lblAutorizado.Text = string.Empty;
                    lblModificado.Text = string.Empty;
                    lblEjercido.Text = string.Empty;
                    lblAvance.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        private List<Presupues> GetList()
        {
            try
            {
                List<Presupues> List = new List<Presupues>();
                objPresupuesto.Id =Convert.ToString(trvPresupuesto.SelectedNode.Value);
                CNPresupuesto.PresupuestoConsultaGrid(ref objPresupuesto, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void Sumatoria(GridView grdView)
        {
            //grdView.AllowPaging = false;            
            double autorizado = 0;
            double modificado = 0;
            double ejercido = 0;
            double avance = 0;
            autorizado = grdView.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDouble(x.Cells[1].Text));
            modificado = grdView.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDouble(x.Cells[2].Text));
            ejercido = grdView.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDouble(x.Cells[3].Text));
            avance = grdView.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDouble(x.Cells[4].Text));
            lblAutorizado.Text = String.Format("{0:N}", Convert.ToDouble(autorizado));
            lblModificado.Text = String.Format("{0:N}", Convert.ToDouble(modificado));            
            lblEjercido.Text = String.Format("{0:N}", Convert.ToDouble(ejercido));
            lblAvance.Text = (Convert.ToDouble(modificado)==0)?"0%":Convert.ToString(Math.Round((ejercido/modificado)*100))+"%";
            //grdView.AllowPaging = true;

        }
        #endregion

        protected void trvPresupuesto_SelectedNodeChanged(object sender, EventArgs e)
        {
       
            
            CargarGrid();
        }

        protected void grvPresupuesto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvPresupuesto.PageIndex = e.NewPageIndex;
            CargarGrid();   
        }
    }
}