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
    public partial class frmBasicos : System.Web.UI.Page
    {

        #region <Variables>
        string Verificador = string.Empty;
        Int32[] Celdas = new Int32[] { 0 };
        CN_Usuario CNUsuario = new CN_Usuario();
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Basicos CNBasicos = new CN_Basicos();
        Basicos ObjBasicos = new Basicos();
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

                grdBasicos.DataSource = dt;
                grdBasicos.DataSource = GetList();
                grdBasicos.DataBind();
                CNComun.HideColumns(grdBasicos, Celdas);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void habil_cuenta()
        {
            if (SesionUsu.Editar == 0)
            {
                txtOrden.Enabled = false;
            }
            else
            {
                txtOrden.Enabled = true;
            }
        }

        private List<Basicos> GetList()
        {
            try
            {
                List<Basicos> List = new List<Basicos>();

                ObjBasicos.tipo = ddlTipoB.SelectedValue;
                ObjBasicos.status = ddlStatusB.SelectedValue;
                CNBasicos.ConsultarBasicos(ref ObjBasicos, txtBuscar.Text, ref List);

                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void inicializar()
        {
          
            MultiViewBasicos.ActiveViewIndex = 0;
            cargarcombos();
            CargarGrid();
            lblError.Text = string.Empty;
           
        }

        protected void cargarcombos()
        {
            CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Cat_basicos", ref ddlTipoB);
            CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Cat_basicos", ref ddlTipo);
                           
        }

        protected void grdBasicos_SelectedIndexChanged(object sender, EventArgs e)

           
            {
                try
                {
                  

                    lblError.Text = string.Empty;  
                    
                    ddlTipo.Items.RemoveAt(0);
                    ddlStatus.Items.RemoveAt(0);
                    MultiViewBasicos.ActiveViewIndex = 1;
                    SesionUsu.Editar = 1;
                    int v = grdBasicos.SelectedIndex;

                    ObjBasicos.id = grdBasicos.Rows[v].Cells[0].Text;
                    CNBasicos.Consulta_Basico(ref ObjBasicos, ref Verificador);
                       
                    if (Verificador == "0")
                    {

                        ddlTipo.SelectedValue = ObjBasicos.tipo;
                        ddlStatus.SelectedValue = ObjBasicos.status;
                        txtClave.Text = ObjBasicos.clave;
                        txtDescripcion.Text = ObjBasicos.descripcion;
                        txtvalor.Text = ObjBasicos.valor;
                        txtOrden.Text = ObjBasicos.orden;
                        MultiViewBasicos.ActiveViewIndex=1;
                        btnContinuar.Visible = false;
                        habil_cuenta();
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
            lblError.Text = string.Empty;
        }  

        protected void btnCancelar_Click1(object sender, EventArgs e)
        {    
            ddlTipo.Items.Insert(0, "TODOS");
            ddlStatus.Items.Insert(0, "TODOS");

            CNComun.Limpiador_controles(this);
            MultiViewBasicos.ActiveViewIndex = 0;
            lblError.Text = string.Empty;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }


        protected void index_linbtn(object sender)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;            
            grdBasicos.SelectedIndex = row.RowIndex;
            ObjBasicos.id  = grdBasicos.SelectedRow.Cells[0].Text;

        }

        
        private void GuardarDatos()
        {

            lblError.Text = string.Empty;
            
            ObjBasicos = new Basicos();
            
            ObjBasicos.tipo = ddlTipo.SelectedValue;
            ObjBasicos.clave = txtClave.Text;
            ObjBasicos.status = ddlStatus.SelectedValue;
            ObjBasicos.descripcion = txtDescripcion.Text;
            ObjBasicos.valor = txtvalor.Text;
            ObjBasicos.orden = txtOrden.Text;

            try
            {

                Verificador = string.Empty;
                if (SesionUsu.Editar == 0)
                {
                    CNBasicos.insertar_Basicos(ref ObjBasicos, ref Verificador);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "confirmacion();", true);

                }
                else
                {
                    ObjBasicos.id = grdBasicos.Rows[grdBasicos.SelectedIndex].Cells[0].Text;
                    CNBasicos.Editar_Basicos(ref ObjBasicos, ref Verificador);
                    
                }
                if (Verificador != "0")
                {
                    lblError.Text = Verificador;
                }
                else
                {
                    if (guar_continue == 0)
                    {
                        
                        ddlTipo.Items.Insert(0, "TODOS");
                        ddlStatus.Items.Insert(0, "TODOS");
                        
                        CargarGrid();

                        CNComun.HideColumns(grdBasicos, Celdas);
                        lblError.Text = string.Empty;

                        MultiViewBasicos.ActiveViewIndex = 0;
                        CNComun.Limpiador_controles(this);
                      
                    }
                    else
                    {
                        lblError.Text = "El registro se Guardo correctamente";

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


        protected void BTN_continuar_Click(object sender, EventArgs e)
        {
            guar_continue = 1;
            GuardarDatos();
        }

        protected void btnGuardar_Click1(object sender, EventArgs e)
        {            
            GuardarDatos();

         }

        protected void grdBasicos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdBasicos.PageIndex = 0;
            grdBasicos.PageIndex = e.NewPageIndex;
            CargarGrid(0);
        }


        private void CargarGrid(int indexCopia)
        {
            lblError.Text = string.Empty;
            grdBasicos.DataSource = null;
            grdBasicos.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grdBasicos.DataSource = dt;
                grdBasicos.DataSource = GetList();
                grdBasicos.DataBind();

                if (grdBasicos.Rows.Count > 0)
                {
                    CNComun.HideColumns(grdBasicos, Celdas);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }


        protected void LinkButton1_Click(object sender, EventArgs e)
        {
  
        }

        protected void lbtnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                lblError.Text = string.Empty;
                index_linbtn(sender);
                ObjBasicos.id = grdBasicos.SelectedRow.Cells[0].Text;
                Verificador = string.Empty;
                CNBasicos.Eliminar_Basico(ref ObjBasicos, ref Verificador);

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

        protected void BTNver_reporte_Click(object sender, ImageClickEventArgs e)
        {


            string ruta = "../Reportes/VisualizadorCrystal_patrimonio.aspx?Tipo=RP-basicos&tipo_p=" + ddlTipoB.SelectedValue + "&status=" + ddlStatusB.SelectedValue + "&descripcion=" + txtBuscar.Text + "&catalogo=" + ddlTipoB.SelectedItem.ToString();


            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);


        }

        protected void ddlStatusB_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid();
        }

        protected void ddlTipoB_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid();
        }
        

        protected void imgBttnExcel(object sender, ImageClickEventArgs e)
        {

            string ruta = "../Reportes/VisualizadorCrystal_patrimonio.aspx?Tipo=RP-basicos_xls&tipo_p=" + ddlTipoB.SelectedValue + "&status=" + ddlStatusB.SelectedValue + "&descripcion=" + txtBuscar.Text + "&catalogo=" + ddlTipoB.SelectedItem.ToString();


            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }

        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            int total_valores = 0;
            total_valores = ddlStatus.Items.Count;

            MultiViewBasicos.ActiveViewIndex = 1;
            if (ddlTipoB.SelectedValue == "00000")
            {
                ddlTipo.SelectedIndex = ddlTipo.SelectedIndex + 1;
            }
            else

            { ddlTipo.SelectedValue = ddlTipoB.SelectedValue; }

            if (ddlStatusB.SelectedValue == "T")
            {
                ddlStatus.SelectedIndex = ddlStatusB.SelectedIndex + 1;
            }
            else

            { ddlStatus.SelectedValue = ddlStatusB.SelectedValue; }

            ddlTipo.Items.RemoveAt(0);
            ddlStatus.Items.RemoveAt(0);


            lblError.Text = string.Empty;
            txtBuscar.Text = string.Empty;
            SesionUsu.Editar = 0;
            btnContinuar.Visible = true;
            habil_cuenta();
            lblError.Text = string.Empty;
        }
    }
}