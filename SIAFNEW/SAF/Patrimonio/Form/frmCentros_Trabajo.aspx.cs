using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEntidad;
using CapaNegocio;

namespace SAF.Patrimonio.Form
{
    public partial class frmCentros_Trabajo : System.Web.UI.Page
    {

        #region <Variables>
        string Verificador = string.Empty;
        Int32[] Celdas = new Int32[] { 0 };
        CN_Usuario CNUsuario = new CN_Usuario();
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Centros_Trabajo CNCentros_Trabajo = new CN_Centros_Trabajo();
        Centros_Trabajo ObjCentros_Trabajo = new Centros_Trabajo();
        private static List<Comun> ListConceptos = new List<Comun>();
        private static List<Comun> Listcodigo = new List<Comun>(); //En tu declaración de variables
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

        private void CargarGrid()
        {
            try
            {
                DataTable dt = new DataTable();

                grdCentros_Trabajo.DataSource = dt;
                grdCentros_Trabajo.DataSource = GetList();
                grdCentros_Trabajo.DataBind();

                CNComun.HideColumns(grdCentros_Trabajo, Celdas);
            }
            catch (Exception ex)
            {
                lblError.Text ="No se encontro ningún registro, por favor veifique sus datos. " + ex.Message;
            }
        }

        protected void habil_cuenta()
        {
            //if (SesionUsu.Editar == 0)
            //{
            //    txtOrden.Enabled = false;
            //}
            //else
            //{
            //    txtOrden.Enabled = true;
            //}
        }

        private void busca_max_depen()
        {
            ObjCentros_Trabajo.dependencia = ddlDependencia.SelectedValue;
            CNCentros_Trabajo.ConsultarMax_id_dependencia(ref ObjCentros_Trabajo, ref Verificador);
            if (ObjCentros_Trabajo.max_id != "")
            {
                int Consecutivo;
                Consecutivo=Convert.ToInt16(ObjCentros_Trabajo.max_id.Substring(5, 3)) + 1;
                txtConsecutivo.Text = Convert.ToString( Consecutivo);
            }
            else
            {
                txtConsecutivo.Text = "001";
            }
        }


        private void GuardarDatos()
        {

            lblError.Text = string.Empty;

            ObjCentros_Trabajo = new Centros_Trabajo();

            ObjCentros_Trabajo.centro_contable = ddlCentros1.SelectedValue;
            ObjCentros_Trabajo.clave = ddlDependencia.SelectedValue + txtConsecutivo.Text;
            ObjCentros_Trabajo.descripcion = txtDescripcion.Text;
            ObjCentros_Trabajo.status = ddlStatus.SelectedValue;
            
            try
            {

                Verificador = string.Empty;
                if (SesionUsu.Editar == 0)
                {
                    CNCentros_Trabajo.insertar_Centros_Trabajo(ref  ObjCentros_Trabajo, ref Verificador);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "confirmacion();", true);

                }
                else
                {
                    ObjCentros_Trabajo.id = grdCentros_Trabajo.Rows[grdCentros_Trabajo.SelectedIndex].Cells[0].Text;
                    CNCentros_Trabajo.Editar_Centros_Trabajo(ref  ObjCentros_Trabajo, ref Verificador);
                }
                if (Verificador != "0")
                {
                    lblError.Text = Verificador;
                }
                else
                {
                    if (guar_continue == 0)
                    {

                        ddlCentros1.Items.Insert(0, "TODAS");
                        ddlStatus.Items.Insert(0, "TODOS");

                        CargarGrid();

                        CNComun.HideColumns(grdCentros_Trabajo, Celdas);
                        lblError.Text = string.Empty;

                        MultiViewCentros_Trabajo.ActiveViewIndex = 0;
                        CNComun.Limpiador_controles(this);

                    }
                    else
                    {
                        lblError.Text = "Se agrego correctamente el registro";

                        CargarGrid();
                        CNComun.Limpiador_controles(this);

                    }

                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }


        protected void lbtnEliminar_Click(object sender, EventArgs e)
        {

            

        }

        protected void index_linbtn(object sender)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdCentros_Trabajo.SelectedIndex = row.RowIndex;
            ObjCentros_Trabajo.id = grdCentros_Trabajo.SelectedRow.Cells[0].Text;

        }

        protected void grdCentros_Trabajo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCentros_Trabajo.PageIndex = 0;
            grdCentros_Trabajo.PageIndex = e.NewPageIndex;
            CargarGrid(0);
        }

        private void CargarGrid(int indexCopia)
        {
            lblError.Text = string.Empty;
            grdCentros_Trabajo.DataSource = null;
            grdCentros_Trabajo.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grdCentros_Trabajo.DataSource = dt;
                grdCentros_Trabajo.DataSource = GetList();
                grdCentros_Trabajo.DataBind();

                if (grdCentros_Trabajo.Rows.Count > 0)
                {
                    CNComun.HideColumns(grdCentros_Trabajo, Celdas);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        
        private List<Centros_Trabajo> GetList()
        {
            try
            {
                List<Centros_Trabajo> List = new List<Centros_Trabajo>();

                ObjCentros_Trabajo.centro_contable = ddlCentrosB.SelectedValue;
                ObjCentros_Trabajo.status = ddlStatusB.SelectedValue;
                CNCentros_Trabajo.ConsultarCentros_Trabajo(ref ObjCentros_Trabajo, txtBuscar.Text, ref List);

                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void inicializar()
        {

            MultiViewCentros_Trabajo.ActiveViewIndex = 0;
            cargarcombos();
            CargarGrid();
            lblError.Text = string.Empty;

        }

        protected void cargarcombos()
        {
            CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Centros_Contables", ref ddlCentrosB);
            CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Centros_Contables", ref ddlCentros1);

        }
        

        protected void BTNver_reporte_Click(object sender, ImageClickEventArgs e)
        {
            string ruta = "../Reportes/VisualizadorCrystal_patrimonio.aspx?Tipo=RP-Centros_Trabajo&centro_contable=" + ddlCentrosB.SelectedValue + "&status=" + ddlStatusB.SelectedValue + "&descripcion=" + txtBuscar.Text + "&catalogo=" + ddlCentrosB.SelectedItem.ToString() ;

            
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

           // ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerCentros_Trabajo('RP-Centros_Trabajo','" + ddlCentrosB.SelectedValue + "','" + ddlStatusB.SelectedValue + "','" + txtBuscar.Text + "', '" + ddlCentrosB.SelectedItem.ToString() + "');", true);
           
        }

        protected void imgBttnExcel(object sender, ImageClickEventArgs e)
        {

            string ruta = "../Reportes/VisualizadorCrystal_patrimonio.aspx?Tipo=RP-Centros_Trabajo_xls&centro_contable=" + ddlCentrosB.SelectedValue + "&status=" + ddlStatusB.SelectedValue + "&descripcion=" + txtBuscar.Text + "&catalogo=" + ddlCentrosB.SelectedItem.ToString();


            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);


           // ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerCentros_Trabajo('RP-Centros_Trabajo_xls','" + ddlCentrosB.SelectedValue + "','" + ddlStatusB.SelectedValue + "','" + txtBuscar.Text + "', '" + ddlCentrosB.SelectedItem.ToString() + "');", true);
        }

        protected void ddlCentrosB_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid();
        }

        protected void btnCancelar_Click1(object sender, EventArgs e)
        {
            ddlCentros1.Items.Insert(0, "TODAS");
            ddlStatus.Items.Insert(0, "TODOS");
            CNComun.Limpiador_controles(this);
            lblError.Text = "";
            ddlStatus.Enabled = true;
            ddlCentros1.Enabled = true;
            MultiViewCentros_Trabajo.ActiveViewIndex = 0;
        }

        protected void btnGuardar_Click1(object sender, EventArgs e)
        {
            GuardarDatos();
             
        }

        protected void BTN_continuar_Click(object sender, EventArgs e)
        {
            guar_continue = 1;
            GuardarDatos();
        }

        protected void ddlStatusB_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid();
        }

        protected void grdCentros_Trabajo_SelectedIndexChanged(object sender, EventArgs e)
        {
             try
                {
                    lblError.Text = string.Empty;
                    ddlCentros1.Items.RemoveAt(0);
                    ddlStatus.Items.RemoveAt(0);
                    MultiViewCentros_Trabajo.ActiveViewIndex = 1;
                    SesionUsu.Editar = 1;
                    int v = grdCentros_Trabajo.SelectedIndex;

                    ObjCentros_Trabajo.id = grdCentros_Trabajo.Rows[v].Cells[0].Text;
                    CNCentros_Trabajo.Consulta_Centros_Trabajo(ref ObjCentros_Trabajo, ref Verificador);
                       
                    if (Verificador == "0")
                    {
                        ddlCentros1.SelectedValue = ObjCentros_Trabajo.centro_contable;
                        CNComun.LlenaCombo("PKG_PATRIMONIO.Obt_combo_dependenciaxcentro", ref ddlDependencia, "p_centro", ddlCentros1.SelectedValue);
                        ddlStatus.SelectedValue = ObjCentros_Trabajo.status;
                        ddlDependencia.SelectedValue = ObjCentros_Trabajo.clave.Substring(0, 5);
                        txtConsecutivo.Text = ObjCentros_Trabajo.clave.Substring(5,3);
                        txtDescripcion.Text = ObjCentros_Trabajo.descripcion;
                        btnContinuar.Visible = false;
                        MultiViewCentros_Trabajo.ActiveViewIndex=1;
                        habil_cuenta();
                        ddlCentros1.Enabled = false;
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

        protected void BTNbuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargarGrid();
            lblError.Text = "";
        }

        protected void lbtnEliminar_Click1(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = string.Empty;
                index_linbtn(sender);
                ObjCentros_Trabajo.id = grdCentros_Trabajo.SelectedRow.Cells[0].Text;
                Verificador = string.Empty;
                CNCentros_Trabajo.Eliminar_Centros_Trabajo(ref ObjCentros_Trabajo, ref Verificador);

                if (Verificador != "0")
                {
                    lblError.Text = Verificador;
                }
                else
                {
                    inicializar();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "confirmacion('" + Verificador + "');", true);
                    CargarGrid();
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }



        protected void ddlDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            //busca_max_depen();
        }
        protected void ddlCentros1_SelectedIndexChanged(object sender, EventArgs e)
        {

CNComun.LlenaCombo("PKG_PATRIMONIO.Obt_combo_dependenciaxcentro", ref ddlDependencia, "p_centro", ddlCentros1.SelectedValue);

        
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid();
        }

        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            int total_valores = 0;
            total_valores = ddlStatus.Items.Count;
            MultiViewCentros_Trabajo.ActiveViewIndex = 1;
            if (ddlCentrosB.SelectedValue == "00000")
            {
                ddlCentros1.SelectedIndex = ddlCentrosB.SelectedIndex + 1;
            }
            else

            { ddlCentros1.SelectedValue = ddlCentrosB.SelectedValue; }

            if (ddlStatusB.SelectedValue == "T")
            {
                ddlStatus.SelectedIndex = ddlStatusB.SelectedIndex + 1;
            }
            else

            { ddlStatus.SelectedValue = ddlStatusB.SelectedValue; }

            ddlCentros1.Items.RemoveAt(0);
            ddlStatus.Items.RemoveAt(0);


            lblError.Text = string.Empty;
            txtBuscar.Text = string.Empty;
            btnContinuar.Visible = true;
            SesionUsu.Editar = 0;
            CNComun.LlenaCombo("PKG_PATRIMONIO.Obt_combo_dependenciaxcentro", ref ddlDependencia, "p_centro", ddlCentros1.SelectedValue);
            ObjCentros_Trabajo.dependencia = ddlDependencia.SelectedValue;
            //busca_max_depen();
            ddlStatus.SelectedIndex = 0;
            ddlStatus.Enabled = false;
            habil_cuenta();
            lblError.Text = "";
        }
    }
    }
