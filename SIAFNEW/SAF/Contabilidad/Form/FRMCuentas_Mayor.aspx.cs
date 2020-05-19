using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEntidad;
using CapaNegocio;

namespace SAF.CATS
{
    
    public partial class FRMCuentas_Moyor : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;
        CN_Usuario CNUsuario = new CN_Usuario();
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Cuentas_Mayor  CNcuentas_mayor = new CN_Cuentas_Mayor ();
        Cuentas_Mayor Objcuentas_mayor = new Cuentas_Mayor();
        private static List<Comun> ListConceptos = new List<Comun>();

        #endregion      
        protected void Page_Load(object sender, EventArgs e)
        {
             SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                //SesionUsu.Editar = -1;
                inicializar();
                cargarcombos();
                
            }
        }
        protected void inicializar()
        {
            CargarGrid();
            DDLtipo.Enabled = true;
           lblError.Text= string.Empty;
            SesionUsu.Editar = -1;
            MultiViewcuentas_contables.ActiveViewIndex = 1;
            BTNNuevo.Visible = true;
        }
        protected void cargarcombos()
        {
            CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_rubro", ref ddlrubro);
            CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_naturaleza", ref ddlnaturaleza);
             
        }
        protected void BTN_Cancelar_Click(object sender, EventArgs e)
        {

            inicializar();
            CargarGrid();
            DDLtipo.Enabled = true;
        }

        protected void BTN_Guardar_Click(object sender, EventArgs e)
        {
            GuardarDatos();
        }
        private void GuardarDatos()
        {

           lblError.Text= string.Empty;
            Objcuentas_mayor = new Cuentas_Mayor();

            if (SesionUsu.Editar == 1)
            {
                string ID = grdcuentas_de_mayor.Rows[grdcuentas_de_mayor.SelectedIndex].Cells[0].Text;
                Objcuentas_mayor.id_padre = txtid_padre.Text;
                Objcuentas_mayor.id = ID;
            }
            else { Objcuentas_mayor.id_padre = txtid_padre.Text; }
            Objcuentas_mayor.tipo = DDLtipo.SelectedItem.ToString();
            Objcuentas_mayor.clave = txtclave.Text;
            Objcuentas_mayor.descripcion = txtdescripcion.Text;
            Objcuentas_mayor.naturaleza = ddlnaturaleza.SelectedValue;
            Objcuentas_mayor.rubro = ddlrubro.SelectedValue;
            Objcuentas_mayor.estado_financiero = ddlestado_financiero.SelectedValue;
            Objcuentas_mayor.status = ddlstatus.SelectedValue;
            Objcuentas_mayor.usuario = SesionUsu.Usu_Nombre;
            Objcuentas_mayor.nivel = ddlnivel.SelectedValue;


            try
            {

                Verificador = string.Empty;
                if (SesionUsu.Editar == 0)
                {                    
                    CNcuentas_mayor.insertar_cuenta_mayor(ref Objcuentas_mayor, ref Verificador);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "confirmacion();", true);
                 


                }
                else
                {
                    
                    //Objcuentas_mayor.id = grdcuentas_de_mayor.Rows [ grdcuentas_de_mayor.SelectedIndex ].Cells[0].Text;
                    CNcuentas_mayor.Editar_cuentas_mayor(ref Objcuentas_mayor, ref Verificador);
                    
                }
                if (Verificador != "0")
                {
                   lblError.Text= Verificador;

                }
                else
                {
                    inicializar();
                    CargarGrid();

                }

            }
            catch (Exception ex)
            {
               lblError.Text= ex.Message;
            }
        }
        
        protected void BTNver_reporte_Click(object sender, ImageClickEventArgs e)
        {

        }

        
        private void CargarGrid()
        {
            try
            {
                DataTable dt = new DataTable(); 

                
                grdcuentas_de_mayor.DataSource = dt;
                grdcuentas_de_mayor.DataSource = GetList();
                grdcuentas_de_mayor.DataBind();

            }
            catch (Exception ex)
            {
               lblError.Text= ex.Message;
            }
        }
        private List<Cuentas_Mayor > GetList()
        {
            try
            {
                List<Cuentas_Mayor> List = new List<Cuentas_Mayor>();               
                Objcuentas_mayor.tipo = DDLtipo.SelectedValue;
                CNcuentas_mayor.ConsultarCuentas_mayor(ref Objcuentas_mayor, TXTbuscar.Text, ref List);

                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void grdcuentas_de_mayor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdcuentas_de_mayor.PageIndex = 0;
            grdcuentas_de_mayor.PageIndex = e.NewPageIndex;
            CargarGrid();
        }

        protected void grdcuentas_de_mayor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlstatus.Enabled = true;           
                MultiViewcuentas_contables.ActiveViewIndex = 0;
                SesionUsu.Editar = 1;
                BTNNuevo.Visible = false;
                DDLtipo.Enabled = false;   
                int v = grdcuentas_de_mayor.SelectedIndex;                 
                Objcuentas_mayor.id = grdcuentas_de_mayor.Rows[v].Cells[0].Text;
                CNcuentas_mayor.Consultarcuenta_mayor(ref Objcuentas_mayor, ref Verificador);

                if (Verificador == "0")
                {
                    if (Objcuentas_mayor.id_padre == "") { txtid_padre.Text = "0"; } else { txtid_padre.Text = Objcuentas_mayor.id_padre; }                  
                    DDLtipo.Text= Objcuentas_mayor.tipo;
                    txtclave.Text = Objcuentas_mayor.clave;
                    txtdescripcion.Text = Objcuentas_mayor.descripcion;
                    ddlnaturaleza.SelectedValue = Objcuentas_mayor.naturaleza;
                    ddlrubro.SelectedValue = Objcuentas_mayor.rubro;
                    ddlnivel.SelectedValue = Objcuentas_mayor.nivel;
                    ddlestado_financiero.SelectedValue = Objcuentas_mayor.estado_financiero;
                    ddlstatus.SelectedValue = Objcuentas_mayor.status;


                }
                else
                {
                   lblError.Text= Verificador;
                }
            }
            catch (Exception ex)
            {
               lblError.Text= ex.Message;
            }
        }

        protected void DDLtipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid();
            ddlnivel.SelectedValue = DDLtipo.SelectedValue;
        }

        protected void lbagregar_Click(object sender, EventArgs e)
        {            
            try
            {
                Objcuentas_mayor = new Cuentas_Mayor();
                SesionUsu.Row = Convert.ToInt32(DataBinder.Eval(sender, "CommandArgument").ToString());
                Objcuentas_mayor.id = Convert.ToString(SesionUsu.Row);
                CNcuentas_mayor.Eliminar_cuenta_mayor(ref Objcuentas_mayor, ref Verificador);
                if (Verificador != "0")
                {
                   lblError.Text= Verificador;

                }
                else
                {
                    inicializar();
                    CargarGrid();

                }
            }
            catch (Exception ex)
            {
               lblError.Text= ex.Message;
            }

              
        }

      

        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdcuentas_de_mayor.SelectedIndex = row.RowIndex;
            int nivel = Convert.ToInt32(grdcuentas_de_mayor.SelectedRow.Cells[5].Text);
            int IDP = Convert.ToInt32(grdcuentas_de_mayor.SelectedRow.Cells[0].Text);

            if (nivel <= 3)
            {
                nivel = nivel + 1;
                BTNNuevo_Click(null, null);
                ddlnivel.SelectedValue = Convert.ToString(nivel);
                DDLtipo.SelectedValue = Convert.ToString(nivel);
                txtid_padre.Text = Convert.ToString(IDP);
            }
            else
            {
                CargarGrid();
            }

        }
       
        protected void BTNNuevo_Click(object sender, ImageClickEventArgs e)
        {
            DDLtipo.SelectedValue = Convert.ToString(1);
            txtid_padre.Text = "0";
            DDLtipo.Enabled = false;
            MultiViewcuentas_contables.ActiveViewIndex = 0;
            txtclave.Text = string.Empty;
            txtdescripcion.Text = string.Empty;
            SesionUsu.Editar = 0;
            BTNNuevo.Visible = false;
            Objcuentas_mayor = new Cuentas_Mayor();

            ddlstatus.Enabled = false;
            ddlrubro.Enabled = false;
            ddlestado_financiero.Enabled = false;
            ddlstatus.SelectedIndex = 0;
        }
    }
}