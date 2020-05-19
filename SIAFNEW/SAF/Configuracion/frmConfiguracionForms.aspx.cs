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
    public partial class frmConfiguracionForms : System.Web.UI.Page
    {

        #region <Variables>
        string Verificador = string.Empty;
        Int32[] Celdas = new Int32[] { 0 };
        CN_Usuario CNUsuario = new CN_Usuario();
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Configuracion_forms CNConfiguracion_forms = new CN_Configuracion_forms();
        Configuracion_forms ObjConfiguracion_forms = new Configuracion_forms();
        private static List<Comun> ListConceptos = new List<Comun>();
        private static List<Comun> Listcodigo = new List<Comun>(); //En tu declaración de variables
        int guar_continue;
        string var_sistema;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                inicializar();
            }
        
       }


        protected void inicializar()
        {
            var_sistema = Convert.ToString(Request.QueryString["sistema"]);

            ddlSistemasb.SelectedValue = var_sistema;
            ddlSistemasb.Enabled = false;

       

            MultiViewConfiguracion.ActiveViewIndex = 0;
           lblError.Text = string.Empty;
            
            CargarGrid();
            cargarcombos();

        }


        protected void cargarcombos()
        {
            CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Tipo_formatos", ref ddlFormatos);
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
           lblError.Text = string.Empty;

            try
            {

                CargarGrid();

            }
            catch (Exception ex)
            {
             
            }
        }



        private void CargarGrid()
        {
            try
            {
                DataTable dt = new DataTable();

                grdConfiguraciones.DataSource = dt;
                grdConfiguraciones.DataSource = GetList();
                grdConfiguraciones.DataBind();
                CNComun.HideColumns(grdConfiguraciones, Celdas);
            }
            catch (Exception ex)
            {
                
            }
        }

        private List<Configuracion_forms> GetList()
        {
            try
            {

               List<Configuracion_forms> List = new List<Configuracion_forms>();

                ObjConfiguracion_forms.Sistema = ddlSistemasb.SelectedValue;
                CNConfiguracion_forms.Consultar_Configuraciones(ref ObjConfiguracion_forms, txtBuscar.Text, ref List);

                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // empieza para paginado del grid 


        private void CargarGrid(int indexCopia)
        {
           lblError.Text = string.Empty;
            grdConfiguraciones.DataSource = null;
            grdConfiguraciones.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grdConfiguraciones.DataSource = dt;
                grdConfiguraciones.DataSource = GetList();
                grdConfiguraciones.DataBind();

                if (grdConfiguraciones.Rows.Count > 0)
                {
                    CNComun.HideColumns(grdConfiguraciones, Celdas);
                }
            }
            catch (Exception ex)
            {
               lblError.Text = "No se encontró ningún dato. Verifique su búsqueda. " + ex.Message;
            }
        }

        // termina paginado del grid

        protected void index_linbtn(object sender)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdConfiguraciones.SelectedIndex = row.RowIndex;
            ObjConfiguracion_forms.Id = grdConfiguraciones.SelectedRow.Cells[0].Text;

        }

        private void GuardarDatos()
        {

           lblError.Text = string.Empty;
            ObjConfiguracion_forms = new Configuracion_forms();

            try
            {

                Verificador = string.Empty;
                if (SesionUsu.Editar == 0)
                {

                    ObjConfiguracion_forms.Sistema = ddlSistemas.SelectedValue;
                    ObjConfiguracion_forms.Formato = ddlFormatos.SelectedValue;
                    ObjConfiguracion_forms.Posicion = txtPosicion.Text;
                    ObjConfiguracion_forms.Nombre = txtNombre.Text;
                    ObjConfiguracion_forms.Puesto = txtPuesto.Text;
                    
                    CNConfiguracion_forms.Insertar_Configuracion_forms(ref ObjConfiguracion_forms, ref Verificador);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "confirmacion();", true);

                }
                else
                {
                    ObjConfiguracion_forms.Id = txtID.Text;
                    ObjConfiguracion_forms.Sistema = ddlSistemas.SelectedValue;
                    ObjConfiguracion_forms.Formato = ddlFormatos.SelectedValue;
                    ObjConfiguracion_forms.Posicion = txtPosicion.Text;
                    ObjConfiguracion_forms.Nombre = txtNombre.Text;
                    ObjConfiguracion_forms.Puesto = txtPuesto.Text;

                    CNConfiguracion_forms.Editar_Configuracion_forms(ref ObjConfiguracion_forms, ref Verificador);
                    SesionUsu.Editar = 0;
                    CargarGrid();

                }
                if (Verificador != "0")
                {
                   lblError.Text = Verificador;
                }
                else
                {
                    if (guar_continue == 0)
                    {
                        SesionUsu.Editar = 0;
                        MultiViewConfiguracion.ActiveViewIndex = 0;
                    }
                    else
                    {

                        ddlFormatos.Enabled = true;
                        txtPosicion.Enabled = true;
                        txtNombre.Enabled = true;
                        txtPuesto.Enabled = true;

                        ddlFormatos.SelectedIndex = 0;
                        txtPosicion.Text = String.Empty;
                        txtNombre.Text = String.Empty;
                        txtPuesto.Text = String.Empty;
                        txtID.Text = String.Empty;

                    }
                    CargarGrid();
                   lblError.Text = "Se guardó correctamente el registro.";
                    

                }

            }
            catch (Exception ex)
            {
               lblError.Text = "No se pudo guardar el registro. Verifique datos y/o conexión a internet. " + ex.Message;
            }
        }


        protected void btnNuevo_Click(object sender, EventArgs e)
        {
           lblError.Text = string.Empty;
            ddlSistemas.SelectedValue = ddlSistemasb.SelectedValue;
            ddlSistemas.Enabled = false;
            ddlFormatos.Enabled = true;
            txtPosicion.Enabled = true;
            txtNombre.Enabled = true;
            txtPuesto.Enabled = true;

            ddlFormatos.SelectedIndex = 0;
            txtPosicion.Text = String.Empty;
            txtNombre.Text = String.Empty;
            txtPuesto.Text = String.Empty;
            txtID.Text= String.Empty;

            MultiViewConfiguracion.ActiveViewIndex = 1;
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
           lblError.Text = string.Empty;
            MultiViewConfiguracion.ActiveViewIndex = 0;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
           lblError.Text = string.Empty;
            GuardarDatos();
        }

        protected void grdConfiguraciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

           lblError.Text = string.Empty;

            ddlSistemas.Enabled = true;
            ddlFormatos.Enabled = true;
            txtPosicion.Enabled = true;
            txtNombre.Enabled = true;
            txtPuesto.Enabled = true;


            MultiViewConfiguracion.ActiveViewIndex = 1;
            SesionUsu.Editar = 1;
            int v = grdConfiguraciones.SelectedIndex;

            ObjConfiguracion_forms.Id = grdConfiguraciones.Rows[v].Cells[0].Text;
            CNConfiguracion_forms.Consulta_ConfiguracionForm(ref ObjConfiguracion_forms, ref Verificador);

            if (Verificador == "0")
            {
                    txtID.Text = string.Empty;
                    txtPosicion.Text = String.Empty;
                    txtNombre.Text = String.Empty;
                    txtPuesto.Text = String.Empty;

                    txtID.Text= grdConfiguraciones.Rows[v].Cells[0].Text; 
                    ddlSistemas.SelectedValue = ObjConfiguracion_forms.Sistema;
                    ddlFormatos.SelectedValue = ObjConfiguracion_forms.Formato;
                    txtPosicion.Text = ObjConfiguracion_forms.Posicion;
                    txtNombre.Text = ObjConfiguracion_forms.Nombre;
                    txtPuesto.Text = ObjConfiguracion_forms.Puesto;


                MultiViewConfiguracion.ActiveViewIndex = 1;
                btnContinuar.Visible = false;

            }
            else
            {
               lblError.Text = Verificador;
            }

        }
            catch (Exception ex)
            {

               lblError.Text = "No se pudo obtener la información deseada. Intente nuevamente. " + ex.Message;
            }

}

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            guar_continue = 1;
            GuardarDatos();
        }

        protected void lblEliminar_Click(object sender, EventArgs e)
        {
            try
            {
               lblError.Text = string.Empty;
                index_linbtn(sender);
                ObjConfiguracion_forms.Id= grdConfiguraciones.SelectedRow.Cells[0].Text;
                Verificador = string.Empty;
                CNConfiguracion_forms.Eliminar_Configuracion_forms(ref ObjConfiguracion_forms, ref Verificador);

                if (Verificador != "0")
                {
                   lblError.Text = Verificador;

                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "confirmacion('" + Verificador + "');", true);
                    CargarGrid();
                }

            }
            catch (Exception ex)
            {
               lblError.Text = "No se pudo eliminar el registro. " + ex.Message;
            }
        }

        protected void btnNuevo_Click1(object sender, ImageClickEventArgs e)
        {
           lblError.Text = string.Empty;
            ddlSistemas.SelectedValue = ddlSistemasb.SelectedValue;
            ddlSistemas.Enabled = false;
            ddlFormatos.Enabled = true;
            txtPosicion.Enabled = true;
            txtNombre.Enabled = true;
            txtPuesto.Enabled = true;

            ddlFormatos.SelectedIndex = 0;
            txtPosicion.Text = String.Empty;
            txtNombre.Text = String.Empty;
            txtPuesto.Text = String.Empty;
            txtID.Text = String.Empty;

            MultiViewConfiguracion.ActiveViewIndex = 1;
        }
    }
}