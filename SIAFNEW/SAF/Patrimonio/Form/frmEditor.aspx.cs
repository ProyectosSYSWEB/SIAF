using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEntidad;
using CapaNegocio;
using AjaxControlToolkit;

namespace SAF.Patrimonio
{
    public partial class frmEditor : System.Web.UI.Page
    {
        #region <Variables>
        String Verificador = string.Empty;
        int[] Columnas;
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        Bien ObjBien = new Bien();
        CN_Comun CNComun = new CN_Comun();
        CN_Usuario CNUsuario = new CN_Usuario();
        CN_Bien CNBien = new CN_Bien();
        Comun ObjCC = new Comun();
        Int32[] Celdas = new Int32[] { 0, 0, 0};
        private static List<Comun> Formulario=new List<Comun>();
        private static List<Comun> Dependencias = new List<Comun>();
        private static List<Comun> Polizas = new List<Comun>();
        
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
 
            SesionUsu.Editar = -1;
            MultiView1.ActiveViewIndex = 0;
            CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Dependencia", ref DDLDependencia, "p_usuario", SesionUsu.CUsuario, ref Dependencias);
            CargarCombos();
            lblError.Text = string.Empty;
           
        }
        private void CargarCombos()
        {
          
            try
            {
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_basicos", ref DDLTipo_Alta, "p_tipo", "PAT_CAT_ALTAS");
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_CatBienes", ref DDLClave, "p_cuenta", "p_subcuenta", "p_4nivel", "0", "0", "0", ref Formulario);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        
        private void CargarGrid()
        {
            grvInventario.DataSource = null;
            grvInventario.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grvInventario.DataSource = dt;
                grvInventario.DataSource = GetList();
                grvInventario.DataBind();
                if (grvInventario.Rows.Count > 0)
                {
                    Columnas = new int[6];
                    Columnas[0] = 0;
                    Columnas[1] = 0;
                    Columnas[3] = 0;

                    CNComun.HideColumns(grvInventario, Columnas);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un problema al cargar los datos: " + ex.Message + "');", true);
            }
        }
       
        private List<Bien> GetList()
        {
            try
            {
                //string Fecha_Fin= System.DateTime.Now.ToString("dd/MM/") + SesionUsu.Usu_Ejercicio;
                string Fecha_Fin = "31/12/" + SesionUsu.Usu_Ejercicio;
                List<Bien> List = new List<Bien>();
                Bien Parametros = new Bien();
                Parametros.Dependencia=DDLDependencia.SelectedValue;
                Parametros.Estatus = "T";
                CNBien.ConsultarGrid(Parametros,txtBuscar.Text.ToUpper(),"01/01/1995",Fecha_Fin, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
      
        
        
        private void Limpiador_controles(Control control)
        {
            try
            {
                var textbox = control as TextBox;
                if (textbox != null)
                {
                    textbox.Text = string.Empty;
                }

                foreach (Control childControl in control.Controls)
                {
                    Limpiador_controles(childControl);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un problema al cargar los datos: " + ex.Message + "');", true);
                //lblError.Text = ex.Message;
            } 
        }
       
       
        
            private void LimpiarControles()
        {
            txtCentroContable.Text = string.Empty;
            txtInventario.Text = string.Empty;
            txtFecha_Alta.Text = string.Empty;
            txtFecha_Contable.Text = string.Empty;
            txtPoliza.Text = string.Empty;
            txtContab.Text = string.Empty;
            // CEDULA
            txtCedula.Text = string.Empty;
              //TRANSFERENCIA
            txtVolante_Transferencia.Text = string.Empty;
            txtInv_Anterior.Text = string.Empty;
            txtAlta_Anterior.Text = string.Empty;
            txtProcedencia.Text = string.Empty;
            txtProyecto.Text = string.Empty;
            txtFuente.Text = string.Empty;

           
            lblError.Text = string.Empty;
           
          MultiView1.ActiveViewIndex = 1;

        }
        private void Cancelar()
        {
            MultiView1.ActiveViewIndex = 0;
            lblDependencia.Visible = true;
            DDLDependencia.Visible = true;
            lblBuscar.Visible = true;
            txtBuscar.Visible = true;
            imgbtnBuscar.Visible = true;

            CargarGrid();
        }
        #endregion

        #region <Botones y Eventos>


       

        protected void grvInventario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvInventario.PageIndex = 0;
            grvInventario.PageIndex = e.NewPageIndex;
            CargarGrid();
        }
        protected void grvInventario_SelectedIndexChanged(object sender, EventArgs e)
        {
                MultiView1.ActiveViewIndex = 0;
                lblDependencia.Visible = false;
                DDLDependencia.Visible = false;
                lblBuscar.Visible = false;
                txtBuscar.Visible = false;
                imgbtnBuscar.Visible = false;

            Bien_Detalle ObjBien_Detalle = new Bien_Detalle();
                LimpiarControles();

                ObjBien_Detalle.Id = Convert.ToInt32(grvInventario.SelectedRow.Cells[0].Text);
                Verificador = string.Empty;
                CNBien.ConsultarBien(ref ObjBien_Detalle, ref Verificador);
                if (Verificador == "0")
                {

                txtCentroContable.Text = ObjBien_Detalle.Centro_Contable;
                txtDependencia.Text = ObjBien_Detalle.Dependencia;
                txtSubDependencia.Text = ObjBien_Detalle.SubDependencia;
                txtInventario.Text = ObjBien_Detalle.No_Inventario;
                txtFecha_Alta.Text = ObjBien_Detalle.Fecha_Alta_Str;
                txtFecha_Contable.Text = ObjBien_Detalle.Fecha_Contable_Str;
                DDLTipo_Alta.SelectedValue = ObjBien_Detalle.IdTipo_Alta.ToString();
                txtPoliza.Text =ObjBien_Detalle.Poliza;
                txtContab.Text = ObjBien_Detalle.Codigo_Contable;
                DDLClave.SelectedValue = ObjBien_Detalle.Clave;
                // CEDULA
                txtCedula.Text = ObjBien_Detalle.Cedula;
                //TRANSFERENCIA
                txtInv_Anterior.Text = ObjBien_Detalle.Inventario_Anterior;
                txtVolante_Transferencia.Text = ObjBien_Detalle.Volante;
                txtAlta_Anterior.Text = ObjBien_Detalle.Fecha_Alta_Ant_Str;
                txtProcedencia.Text = ObjBien_Detalle.Procedencia;

                txtProyecto.Text = ObjBien_Detalle.Proyecto;
                txtFuente.Text = ObjBien_Detalle.Fuente_Financiamiento;
                txtPartida.Text = ObjBien_Detalle.Partida;
               
               txtCentroTrabajo.Text = ObjBien_Detalle.Centro_Trabajo;
                DDLEstatus.SelectedValue = ObjBien_Detalle.Estatus;
                DDLReclasificado.SelectedValue = ObjBien_Detalle.Reclasificado;
                txtFecha_Reclasificacion.Text = ObjBien_Detalle.Fecha_Reclasificacion_Str;
                lblError.Text = string.Empty;

                MultiView1.ActiveViewIndex = 1;

                 }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un problema al consultar los datos: " + Verificador + "');", true);
                }

                    }
        
        protected void imgbtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
                CargarGrid();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                Bien_Detalle ObjBien_Detalle = new Bien_Detalle();
                ObjBien_Detalle.Id = Convert.ToInt32(grvInventario.SelectedRow.Cells[0].Text);
                Verificador = string.Empty;
                ObjBien_Detalle.Centro_Contable = txtCentroContable.Text;
                ObjBien_Detalle.Dependencia = txtDependencia.Text;
                ObjBien_Detalle.SubDependencia = txtSubDependencia.Text;
                ObjBien_Detalle.No_Inventario = txtInventario.Text;
                ObjBien_Detalle.Fecha_Alta_Str = txtFecha_Alta.Text;
                ObjBien_Detalle.Fecha_Contable_Str = txtFecha_Contable.Text;
                ObjBien_Detalle.IdTipo_Alta = Convert.ToInt32(DDLTipo_Alta.SelectedValue);
                ObjBien_Detalle.Poliza = txtPoliza.Text;
                ObjBien_Detalle.Codigo_Contable = txtContab.Text;
                ObjBien_Detalle.Clave = DDLClave.SelectedValue;
                ObjBien_Detalle.Cedula = txtCedula.Text;
                ObjBien_Detalle.Inventario_Anterior = txtInv_Anterior.Text.Trim().ToUpper();
                ObjBien_Detalle.Volante = txtVolante_Transferencia.Text.Trim().ToUpper();
                ObjBien_Detalle.Fecha_Alta_Ant_Str = txtAlta_Anterior.Text;
                ObjBien_Detalle.Procedencia = txtProcedencia.Text.Trim().ToUpper();
                ObjBien_Detalle.Proyecto = txtProyecto.Text;
                ObjBien_Detalle.Fuente_Financiamiento = txtFuente.Text;
                ObjBien_Detalle.Centro_Trabajo =txtCentroTrabajo.Text;
                ObjBien_Detalle.Partida = txtPartida.Text;
                ObjBien_Detalle.Estatus = DDLEstatus.SelectedValue;
                ObjBien_Detalle.Reclasificado = DDLReclasificado.SelectedValue;
                ObjBien_Detalle.Fecha_Reclasificacion_Str = txtFecha_Reclasificacion.Text;
                ObjBien_Detalle.Captura_Usuario = SesionUsu.Usu_Nombre;

                CNBien.ActualizarBien_SuperEditor(ref ObjBien_Detalle, ref Verificador);
                        if (Verificador != "0")
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Los datos no pudieron guardarse: " + Verificador + "');", true);
                    else
                        {
           
                         ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 1, 'Los datos del resguardo se actualizaron correctamente.');", true);
                        Cancelar();
                        }
        

    }
                catch (Exception ex)
                {
                lblError.Text = ex.Message;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

       
    }


    #endregion



}