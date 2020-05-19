using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEntidad;
using CapaNegocio;

namespace SAF.Adquisiciones.Form
{
    public partial class FRMEditar_solicitud : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;
        CN_Usuario CNUsuario = new CN_Usuario();
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Adquisiciones CNadquisiciones = new CN_Adquisiciones();
        Adquisicion objadquisiciones = new Adquisicion();
        string USERBD = "ADQUISICIONES";
        private static List<Comun> Listcodigo = new List<Comun>(); //En tu declaración de variables

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
                MultiView1.ActiveViewIndex = 0;

            }
           
        }
        protected void inicializar()
        {
            txtFSolicitud.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //txtfecha_inicial.Text = "01/01" + SesionUsu.Usu_Ejercicio; // DateTime.Now.Year.ToString();
            //txtfecha_final.Text = DateTime.Now.ToString("dd/MM/") + SesionUsu.Usu_Ejercicio;
            txtfecha_inicial.Text = "01" + System.DateTime.Now.ToString("/MM/") + SesionUsu.Usu_Ejercicio;
            txtfecha_final.Text = System.DateTime.Now.ToString("dd/MM/") + SesionUsu.Usu_Ejercicio;
            txtFSolicitud.Text = System.DateTime.Now.ToString("dd/MM/") + SesionUsu.Usu_Ejercicio;
            TabPanel3.Enabled = false;
            CargarGrid(GRDsolicitudes, "1");
            CNComun.LlenaCombo("pkg_spada_saf.OBT_COMBO_DEPENDENCIA", USERBD, "p_usuario", SesionUsu.Usu_Nombre, ref DDLDependencia);
            CNComun.LlenaCombo("pkg_spada_saf.OBT_COMBO_DEPENDENCIA", USERBD, "p_usuario", SesionUsu.Usu_Nombre, ref ddldependencia_inicial);
        }

        private void CargarGrid(GridView   grid, string   num_grid)
        {
            try
            {
                DataTable dt = new DataTable();
                
          
                grid.DataSource = dt;
                grid.DataSource = GetList(num_grid);
                grid.DataBind();
           
            

            }
            catch (Exception ex)
            {

            }
        }
        private List<Adquisicion> GetList(string num_grid)
        {
            try
            {
                List<Adquisicion> List = new List<Adquisicion>();
               
                objadquisiciones.ejercicio = SesionUsu.Usu_Ejercicio;
                objadquisiciones.Usu_nombre = SesionUsu.Usu_Nombre;
                objadquisiciones.fecha_ini = txtfecha_inicial.Text;
                objadquisiciones.fecha_fin = txtfecha_final.Text;
                if (num_grid == "1") { CNadquisiciones.Grid_Solicitudes_X_Dependencias(ref objadquisiciones, ref   List); }
                if (num_grid == "2") { CNadquisiciones.Grid_Solicitudes_X_UR(ref objadquisiciones, ref   List); }
                if (num_grid == "3") { CNadquisiciones.Grid_Solicitudes_X_Dependencias(ref objadquisiciones, ref   List); }
                
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


       
       

        protected void cargarcombos()
        {
            //CNComun.LlenaCombo("pkg_spada_saf.Obt_Numero_Solicitud", USERBD, "p_ejercicio", "p_dependencia", SesionUsu.Usu_Ejercicio, DDLDependencia.SelectedValue, ref ddlid);


            CNComun.LlenaCombo("pkg_spada_saf.Obt_Combo_Status", USERBD, ref ddlstatus  );
            CNComun.LlenaCombo("pkg_spada_saf.Obt_Combo_Unidad_Medidas", USERBD, ref DDLCategoria );
            CNComun.LlenaCombo("pkg_spada_saf.Obt_Combo_Tipo_Compra", USERBD, ref ddltipo);
            CNComun.LlenaCombo("pkg_spada_saf.Obt_Combo_Funcion_Programas", USERBD, "p_ejercicio", "p_dependencia", SesionUsu.Usu_Ejercicio, DDLDependencia.SelectedValue, ref DDLPrograma);
            CNComun.LlenaCombo("pkg_spada_saf.Obt_Combo_Proyecto", USERBD, "p_ejercicio", "p_dependencia", "p_funcion_programa", SesionUsu.Usu_Ejercicio, DDLDependencia.SelectedValue, DDLPrograma.SelectedValue, ref DDLProyecto);
            CNComun.LlenaCombo("pkg_spada_saf.Obt_Combo_Partida", USERBD, "p_ejercicio", "p_dependencia", "p_funcion_programa", "p_proyecto", SesionUsu.Usu_Ejercicio, DDLDependencia.SelectedValue, DDLPrograma.SelectedValue, DDLProyecto.SelectedValue, ref DDLPartida);
            CNComun.LlenaCombo("pkg_spada_saf.Obt_Combo_Empleados", USERBD, "p_dependencia", DDLDependencia.SelectedValue, ref DDLResponsable);
            CNComun.LlenaCombo("pkg_spada_saf.Obt_Combo_Unidad_Medidas", USERBD, ref DDLUnidad);
            CNComun.LlenaCombo("pkg_spada_saf.Obt_Combo_Codigo_Programatico", USERBD, "p_ejercicio", "p_dependencia", "p_funcion_programa", "p_proyecto", "p_partida", SesionUsu.Usu_Ejercicio, DDLDependencia.SelectedValue, DDLPrograma.SelectedValue, DDLProyecto.SelectedValue, DDLPartida.SelectedValue, ref ddlcodigo_programatico, ref Listcodigo);
            CNComun.LlenaCombo("pkg_spada_saf.Obt_Combo_Productos", USERBD, "p_partida", DDLPartida.SelectedValue, ref DDLProducto);
        }
        protected void DDLPrograma_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("pkg_spada_saf.Obt_Combo_Proyecto", USERBD, "p_ejercicio", "p_dependencia", "p_funcion_programa", SesionUsu.Usu_Ejercicio, DDLDependencia.SelectedValue, DDLPrograma.SelectedValue, ref DDLProyecto);
            CNComun.LlenaCombo("pkg_spada_saf.Obt_Combo_Partida", USERBD, "p_ejercicio", "p_dependencia", "p_funcion_programa", "p_proyecto", SesionUsu.Usu_Ejercicio, DDLDependencia.SelectedValue, DDLPrograma.SelectedValue, DDLProyecto.SelectedValue, ref DDLPartida);
           
        }

        protected void DDLProyecto_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("pkg_spada_saf.Obt_Combo_Partida", USERBD, "p_ejercicio", "p_dependencia", "p_funcion_programa", "p_proyecto", SesionUsu.Usu_Ejercicio, DDLDependencia.SelectedValue, DDLPrograma.SelectedValue, DDLProyecto.SelectedValue, ref DDLPartida);
           
        }

        protected void DDLPartida_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("pkg_spada_saf.Obt_Combo_Codigo_Programatico", USERBD, "p_ejercicio", "p_dependencia", "p_funcion_programa", "p_proyecto", "p_partida", SesionUsu.Usu_Ejercicio, DDLDependencia.SelectedValue, DDLPrograma.SelectedValue, DDLProyecto.SelectedValue, DDLPartida.SelectedValue, ref ddlcodigo_programatico, ref Listcodigo);
            CNComun.LlenaCombo("pkg_spada_saf.Obt_Combo_Productos", USERBD, "p_partida", DDLPartida.SelectedValue, ref DDLProducto );
        }

        protected void GridModificar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridModificar_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridModificar_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridModificar_RowEditing(object sender, GridViewEditEventArgs e)
        {
            
        }

        protected void linkAgregarLote_Click(object sender, EventArgs e)
        {

        }

        protected void linkDocRequeridos_Click(object sender, EventArgs e)
        {

        }

        protected void CBLProgramatico_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ImagenBtnCalendario_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void DDLCategoria_DataBinding(object sender, EventArgs e)
        {

        }

        protected void btnCancelarLote_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnGuardarLote_Click(object sender, EventArgs e)
        {

        }

        protected void DDLDependencia_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            cargarcombos();
        }

        protected void btnCancelarSolicitud_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardarSolicitud_Click(object sender, EventArgs e)
        {

        }

        protected void DDLProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DDLCategoria_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnCancelarLote_Click1(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void DDLResponsable_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void ddlcodigo_programatico_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblAutorizado.Text = Listcodigo[ddlcodigo_programatico.SelectedIndex].EtiquetaDos;
            lblDisponibleRed.Text  = Listcodigo[ddlcodigo_programatico.SelectedIndex].EtiquetaTres ;
            
        }

        protected void txtFSolicitud_TextChanged(object sender, EventArgs e)
        {
            //VerificaFechas(txtFSolicitud);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
          
            
        }

        

        protected void ddldependencia_inicial_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDLDependencia.SelectedIndex = ddldependencia_inicial.SelectedIndex;
            cargarcombos();
        }



        protected void index_linbtn(object sender)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            GRDsolicitudes.SelectedIndex = row.RowIndex;
            objadquisiciones.Dependencia = GRDsolicitudes.SelectedRow.Cells[0].Text;
            ddldependencia_inicial.SelectedValue = GRDsolicitudes.SelectedRow.Cells[0].Text;
            panelprincipal.Visible = false;
            panel_detalle.Visible = true;
            panel_detalle.Visible = true;
            
        }

        protected void linbtnresgistrada_Click(object sender, EventArgs e)
        {
            index_linbtn(sender);
            objadquisiciones.status =  "SSL001";
            ddlstatus.SelectedValue = objadquisiciones.status;
            CargarGrid(GridSolicitudGeneradas, "2");
           
        }

        protected void Linbtnsolicitada_Click(object sender, EventArgs e)
        {

            index_linbtn(sender);
            objadquisiciones.status = "SSL002";
            ddlstatus.SelectedValue = objadquisiciones.status;
            CargarGrid(GridSolicitudGeneradas, "2");

        }

        protected void linbtndenaga_Click(object sender, EventArgs e)
        {
            index_linbtn(sender);
            objadquisiciones.status = "SSL003";
            ddlstatus.SelectedValue = objadquisiciones.status;
            CargarGrid(GridSolicitudGeneradas, "2");
        }

        protected void linbtnautorizada_Click(object sender, EventArgs e)
        {
            index_linbtn(sender);
            objadquisiciones.status = "SSL004";
            ddlstatus.SelectedValue = objadquisiciones.status;
            CargarGrid(GridSolicitudGeneradas, "2");
        }

        protected void linbtncotizacion_Click(object sender, EventArgs e)
        {
            index_linbtn(sender);
            objadquisiciones.status = "SSL005";
            ddlstatus.SelectedValue = objadquisiciones.status;
            CargarGrid(GridSolicitudGeneradas, "2");
        }

        protected void linbtnvisto_Click(object sender, EventArgs e)
        {
            index_linbtn(sender);
            objadquisiciones.status = "SSL006";
            ddlstatus.SelectedValue = objadquisiciones.status;
            CargarGrid(GridSolicitudGeneradas, "2");
        }

        protected void linbtncancelada_Click(object sender, EventArgs e)
        {
            index_linbtn(sender);
            objadquisiciones.status = "SSL007";
            ddlstatus.SelectedValue = objadquisiciones.status;
            CargarGrid(GridSolicitudGeneradas, "2");
        }

        protected void linbtnconcluida_Click(object sender, EventArgs e)
        {
            index_linbtn(sender);
            objadquisiciones.status = "SSL008";
            ddlstatus.SelectedValue = objadquisiciones.status;
            CargarGrid(GridSolicitudGeneradas, "2");
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
             
        }

        protected void GridSolicitudGeneradas_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel_detalle.Visible = false;
            panel_final.Visible = true;

           Limpiador_controles(this);
           Tab_Solicitud.TabIndex = 0;
           TabPanel1.Enabled = true;
        }

        protected void btncancelar_Click(object sender, EventArgs e)
        {
            Limpiador_controles(this);
            panelprincipal.Visible = true;
            panel_final.Visible = false;
            lblError.Text = string.Empty;
            inicializar();
        }
        //procedimiento para limpiar controles de texto
        private void Limpiador_controles(Control control)
        {
            try
            {
                var textbox = control as TextBox;
                if (textbox != null)
                {
                    textbox.Text = string.Empty;
                    lblNumSolicitud.Text = string.Empty;
                }
                var dropDownList = control as DropDownList;
                if (dropDownList != null)
                {
                    dropDownList.SelectedIndex = 0;
                }

                foreach (Control childControl in control.Controls)
                {
                    Limpiador_controles(childControl);
                }
            }
            catch (Exception ex)
            {
              
                lblError.Text = ex.Message;
            } 
        }

        protected void ddlid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            panel_detalle.Visible = false;
            panelprincipal.Visible = true;
        }

        protected void txtIVA_TextChanged(object sender, EventArgs e)
        {
            txtTotal.Text = txtImporte.Text + txtIVA.Text;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (lblNumSolicitud.Text == "")
            {

                try
                {
                    lblError.Text = string.Empty;
                    objadquisiciones.Responsable = DDLResponsable.SelectedValue;
                    objadquisiciones.Fecha_Solicitud = txtFSolicitud.Text;
                    objadquisiciones.Usu_nombre = SesionUsu.Usu_Nombre;
                    objadquisiciones.Lugar_Entrega = txtLugarEntrega.Text;
                    objadquisiciones.ID = "NULL";
                    objadquisiciones.Obj_Particular = txtObjProyecto.Text;
                    objadquisiciones.Justificacion = txtJustificacion.Text;
                    objadquisiciones.ID_UR = DDLDependencia.SelectedValue;
                    objadquisiciones.Tipo_Compra = "TCM001";
                    objadquisiciones.Comentario = txtComentarios.Text;
                    CNadquisiciones.Insertar_Solicitud_Compra(ref objadquisiciones, ref Verificador);

                    if (Verificador != "0")
                    {
                        lblError.Text = Verificador;
                    }
                    else
                    {
                        TabPanel3.Enabled = true;
                        lblNumSolicitud.Text = "# Solicitud:  " + objadquisiciones.Num_Solicitud;

                        //lblError.Text = "El registro fue gregado con éxito";
                        Tab_Solicitud.TabIndex = 1;
                        TabPanel1.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    lblError.Visible = true;
                    lblError.Text = ex.Message;
                }

            }
            else
            {
                TabPanel3.Enabled = true;
                Tab_Solicitud.TabIndex = 1;
                TabPanel1.Enabled = false;
            }


        }

        protected void txtfecha_inicial_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            TabPanel1.Enabled = true;
            Tab_Solicitud.TabIndex = 0;            
            TabPanel3.Enabled = false;
        }

     
        protected void btnagregar_lote_Click1(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void GridModificar0_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
              panelprincipal.Visible = false;           
            panel_final.Visible = true;
            Tab_Solicitud.ActiveTabIndex = 0;
            TabPanel1.Enabled = true;
            Limpiador_controles(this);
            inicializar();
           
        }
    }
}



            
           