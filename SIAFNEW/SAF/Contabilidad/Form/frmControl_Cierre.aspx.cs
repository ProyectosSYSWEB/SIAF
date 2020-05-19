using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEntidad;
using CapaNegocio;


namespace SAF.Contabilidad.Form
{
    public partial class frmControl_Cierre : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;
        Sesion SesionUsu = new Sesion();
        Centros_Contables objControl_Cierre = new Centros_Contables();
        CN_Centros_Contables CNControlCierre = new CN_Centros_Contables();
        CN_Comun CNComun = new CN_Comun();
        Int32[] Celdas = new Int32[] { 0 };
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
            SesionUsu.Usu_Rep = Request.QueryString["P_REP"];
            SesionUsu.Editar = -1;
            CargarGrid();
            //MultiView1.ActiveViewIndex = 0;
            //TabContainer1.ActiveTabIndex = 0;
            //ddlFecha_Ini.SelectedValue = System.DateTime.Now.ToString("MM");
            //ddlFecha_Fin.Text = System.DateTime.Now.ToString("MM");            
            //txtFecha.Text = string.Empty;
            //Cargarcombos();
        }
        private void CargarGrid()
        {
            try
            {
                DataTable dt = new DataTable();
                grvControl_Cierre.DataSource = dt;
                grvControl_Cierre.DataSource = GetList();
                grvControl_Cierre.DataBind();
                if (grvControl_Cierre.Rows.Count > 0)
                {                    
                    CNComun.HideColumns(grvControl_Cierre, Celdas);
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        private List<Centros_Contables> GetList()
        {
            try
            {
                List<Centros_Contables> List = new List<Centros_Contables>();
                objControl_Cierre.Ejercicio =Convert.ToInt32(SesionUsu.Usu_Ejercicio);
                objControl_Cierre.sistema = SesionUsu.Usu_Rep;
                CNControlCierre.Control_CierreConsultaGrid(ref objControl_Cierre, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        protected void imgBttnStatus_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void grvControl_Cierre_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
           lblError.Text = string.Empty;
            int v = e.NewSelectedIndex;
            DropDownList DDL = new DropDownList();
            LinkButton linkBttn = new LinkButton();
            try
            {
                foreach (GridViewRow row in grvControl_Cierre.Rows)
                {
                    DDL = row.FindControl("ddlMes") as DropDownList;
                    DDL.Enabled = false;

                    DDL = row.FindControl("ddlMes2") as DropDownList;
                    DDL.Enabled = false;

                    linkBttn = row.FindControl("linkBttnEditar") as LinkButton;
                    linkBttn.Visible = false;

                    linkBttn = row.FindControl("linkBttnGuardar") as LinkButton;
                    linkBttn.Visible = false;

                    linkBttn = row.FindControl("linkBttnCancelar") as LinkButton;
                    linkBttn.Visible = false;
                }


                DDL = (DropDownList)grvControl_Cierre.Rows[v].FindControl("ddlMes");
                DDL.Enabled = true;

                DDL = (DropDownList)grvControl_Cierre.Rows[v].FindControl("ddlMes2");
                DDL.Enabled = true;

                linkBttn = (LinkButton)grvControl_Cierre.Rows[v].FindControl("linkBttnEditar");
                linkBttn.Visible = false;

                linkBttn = (LinkButton)grvControl_Cierre.Rows[v].FindControl("linkBttnGuardar");
                linkBttn.Visible = true;

                linkBttn = (LinkButton)grvControl_Cierre.Rows[v].FindControl("linkBttnCancelar");
                linkBttn.Visible = true;

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void linkBttnCancelar_Click(object sender, EventArgs e)
        {
            CargarGrid();
            //index_linbtn(sender);
        }


        protected void index_linbtn(object sender)
        {
            //LinkButton cbi = (LinkButton)(sender);
            //GridViewRow row = (GridViewRow)cbi.NamingContainer;
            //grvControl_Cierre.SelectedIndex = row.RowIndex;
            //Objcuentas_contables.id = grdcuentas_contables.SelectedRow.Cells[0].Text;

        }

        protected void linkBttnGuardar_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            int Fila=row.RowIndex;
            int IdCC=Convert.ToInt32(grvControl_Cierre.Rows[Fila].Cells[0].Text);
            DropDownList DDL = (DropDownList)grvControl_Cierre.Rows[Fila].FindControl("ddlMes");
            string mes_anio=DDL.SelectedValue;
            DropDownList DDL2 = (DropDownList)grvControl_Cierre.Rows[Fila].FindControl("ddlMes2");
            string mes_anio2 = DDL2.SelectedValue;
            Verificador = string.Empty;
            try
            {
                objControl_Cierre.Id_Control_Cierre = IdCC;
                objControl_Cierre.Mes_anio = mes_anio + SesionUsu.Usu_Ejercicio.Substring(2, 2);
                objControl_Cierre.Cierre_Definitivo = mes_anio2 + SesionUsu.Usu_Ejercicio.Substring(2, 2);
                CNControlCierre.Control_CierreEditar(ref objControl_Cierre, ref Verificador);
                if (Verificador == "0")
                {
                    CargarGrid();
                    lblError.Text = "El mes del Centro Contable ha sido modificado correctamente.";
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

        protected void grvControl_Cierre_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvControl_Cierre.PageIndex = 0;
            grvControl_Cierre.PageIndex = e.NewPageIndex;
            CargarGrid();
        }

        protected void grvControl_Cierre_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void bttnCierreGeneral_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            DropDownList DDLMesGral = (DropDownList)grvControl_Cierre.HeaderRow.FindControl("ddlMesGral");
            try
            {
                objControl_Cierre.Mes_anio = DDLMesGral.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2);
                objControl_Cierre.Ejercicio = Convert.ToInt32(SesionUsu.Usu_Ejercicio);
                CNControlCierre.Control_CierreGral(ref objControl_Cierre, "C", ref Verificador);
                if (Verificador == "0")                
                    CargarGrid();                
                else
                {
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
                }
            }
            catch (Exception ex)
            {
                string MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void bttnCierreGeneralD_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            DropDownList ddlMesGralD = (DropDownList)grvControl_Cierre.HeaderRow.FindControl("ddlMesGralD");
            try
            {
                objControl_Cierre.Mes_anio = ddlMesGralD.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2);
                objControl_Cierre.Ejercicio = Convert.ToInt32(SesionUsu.Usu_Ejercicio);
                CNControlCierre.Control_CierreGral(ref objControl_Cierre, "CD", ref Verificador);
                if (Verificador == "0")
                    CargarGrid();
                else
                {
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
                }
            }
            catch (Exception ex)
            {
                string MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true); //lblMsj.Text = ex.Message;
            }
        }

       
    }
}