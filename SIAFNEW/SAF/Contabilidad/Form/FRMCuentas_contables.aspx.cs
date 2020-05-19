using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEntidad;
using CapaNegocio;

namespace SAF.Rep
{      
    public partial class FRMCuentas_contables : System.Web.UI.Page
    {

        #region <Variables>
        Int32[] Celdas = new Int32[] { 0 };
        string Verificador = string.Empty;
        CN_Usuario CNUsuario = new CN_Usuario();
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Cuentas_contables CNcuentas_contables = new CN_Cuentas_contables();
        cuentas_contables Objcuentas_contables = new cuentas_contables();
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
                cargarcombos();
                
            }
        }
        private void CargarGrid()
        {
            try
            {
                DataTable dt = new DataTable();

                grdcuentas_contables.DataSource = dt;
                grdcuentas_contables.DataSource = GetList();
                grdcuentas_contables.DataBind();
                if (SesionUsu.Usu_TipoUsu == "2" || SesionUsu.Usu_TipoUsu == "3")
                {
                  
                }
                else
                {
                    Celdas = new Int32[] { 5, 6, 7 };
                }

                
                if (grdcuentas_contables.Rows.Count > 0)
                    CNComun.HideColumns(grdcuentas_contables, Celdas);

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        private List<cuentas_contables> GetList()
        {
            try
            {
                List<cuentas_contables> List = new List<cuentas_contables>();

                Objcuentas_contables.ejercicio = SesionUsu.Usu_Ejercicio;
                Objcuentas_contables.centro_contable = DDLCentro_Contable.SelectedValue;
                Objcuentas_contables.cuenta_mayor = ddlCuenta_Mayor.SelectedValue;              
                CNcuentas_contables.ConsultarCuentas_contables(ref Objcuentas_contables,TXTbuscar.Text, ref List);

                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected void inicializar()
        {
            BTN_continuar.Visible = false;
            DDLCentro_Contable.Enabled = true;
            ddlCuenta_Mayor.Enabled = true;
            lblError.Text = string.Empty;
            SesionUsu.Editar = -1;
            MultiViewcuentas_contables.ActiveViewIndex = 1;
            Label15.Visible = false;
            DDLSubdependencia.Visible = false;
            CargarGrid();
           

        }

        protected void cargarcombos()
        {
            CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Centros_Contables", ref DDLCentro_Contable, "P_USUARIO","p_ejercicio", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio );
            //CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Centros_Contables", ref DDLCentro_Contable);
            CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Cuentas_Mayor", ref ddlCuenta_Mayor, ref Listcodigo);
            
                
        }

        protected void ddlCuentas_Contables_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlMayor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      

        protected void DDLCentro_Contable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SesionUsu.Editar == -1)
            {
                CargarGrid();
            }


            txtcuenta_contable.Text =Listcodigo[ddlCuenta_Mayor.SelectedIndex].EtiquetaDos + ".00000.00000.00000";
            txtdescripcion.Text = Listcodigo[ddlCuenta_Mayor.SelectedIndex].EtiquetaTres; 
        }

        //protected void grdcuentas_contables_SelectedIndexChanged(object sender, EventArgs e)
        //{            
        //    try
        //    {
        //        lblError.Text = string.Empty;
        //        MultiViewcuentas_contables.ActiveViewIndex = 0;
        //        SesionUsu.Editar = 1;
        //        int v = grdcuentas_contables.SelectedIndex;

        //        Objcuentas_contables.id = grdcuentas_contables.Rows[v].Cells[0].Text;
        //        CNcuentas_contables.Consultarcuenta_contable(ref Objcuentas_contables, ref Verificador);

        //        if (Verificador == "0")
        //        {

        //            DDLCentro_Contable.SelectedValue = Objcuentas_contables.centro_contable;
        //            ddlCuenta_Mayor.SelectedValue = Objcuentas_contables.cuenta_mayor;
        //            txtcuenta_contable.Text  = Objcuentas_contables.cuenta_contable;
        //            txtdescripcion.Text = Objcuentas_contables.descripcion;
        //            txttipo.Text = Objcuentas_contables.tipo;
        //            ddlclasificacion.SelectedValue = Objcuentas_contables.clasificacion;
        //            ddlstatus.SelectedValue = Objcuentas_contables.status;
        //            ddlclasificacion.SelectedValue = Objcuentas_contables.clasificacion;
        //            ddlnivel.SelectedValue = Objcuentas_contables.nivel;                                     
        //           //lbtnagregar_Click(null, null);
        //            habil_cuenta();
        //            DDLCentro_Contable.Enabled = false;
        //            ddlCuenta_Mayor.Enabled = false;
        //            txttipo.Enabled = false;
        //            ddlclasificacion.Enabled = false;



        //        }
        //        else
        //        {
        //            lblError.Text = Verificador;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblError.Text = ex.Message;
        //    }
        //}

        protected void BTN_Cancelar_Click(object sender, EventArgs e)
        {
            inicializar();

        }

        protected void BTN_Guardar_Click(object sender, EventArgs e)
        {
            guar_continue = 0;
            GuardarDatos();

            Label15.Visible = false;
            DDLSubdependencia.Visible = false;
            DDLCentro_Contable.Enabled = true;
            ddlCuenta_Mayor.Enabled = true ;
        }
        private void GuardarDatos()
        {
            txtcuenta_contable.Text = txt1.Text + "." + txt2.Text + "." + txt3.Text + "." + txt4.Text ;
            lblError.Text = string.Empty;
           // Objcuentas_contables.id  = grdcuentas_contables.Rows[grdcuentas_contables.SelectedIndex].Cells[0].Text;
            Objcuentas_contables = new cuentas_contables();
            Objcuentas_contables.ejercicio = SesionUsu.Usu_Ejercicio;
            Objcuentas_contables.centro_contable = DDLCentro_Contable.SelectedValue;
            Objcuentas_contables.cuenta_contable = txtcuenta_contable.Text ;
            Objcuentas_contables.descripcion = txtdescripcion.Text;
            Objcuentas_contables.tipo = txttipo.SelectedValue;
            Objcuentas_contables.clasificacion = ddlclasificacion.SelectedValue;
            Objcuentas_contables.nivel = ddlnivel.SelectedValue;
            Objcuentas_contables.status = ddlstatus.SelectedValue;
            Objcuentas_contables.usuario = SesionUsu.Usu_Nombre;
            Objcuentas_contables.cuenta_mayor = ddlCuenta_Mayor.SelectedValue.ToString();   
  
            
            try
            {

                Verificador = string.Empty;
                if (SesionUsu.Editar == 0)
                {
                    CNcuentas_contables.insertar_cuenta_contable(ref Objcuentas_contables, ref Verificador);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "confirmacion();", true);
                   

                }
                else
                {
                    Objcuentas_contables.id = grdcuentas_contables.Rows[grdcuentas_contables.SelectedIndex].Cells[0].Text;
                    CNcuentas_contables.Editar_cuentas_contables(ref Objcuentas_contables, ref Verificador);
                }
                if (Verificador != "0")
                {
                    lblError.Text = Verificador;

                }
                else
                {
                    if (guar_continue == 0)
                    {
                        inicializar();
                        CargarGrid();
                    }
                    else
                    {
                        lblError.Text = "Se agrego correctamente el registro";
                        
                    }

                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void BTNbuscar_Click(object sender, ImageClickEventArgs e)
        {
            lblError.Text = string.Empty;
            CargarGrid();
        }
       
        protected void BTNver_reporte_Click(object sender, ImageClickEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerCatalogo_Cuentas('RP-003'," + SesionUsu.Usu_Ejercicio + ",'" + Convert.ToString(DDLCentro_Contable.SelectedValue) + "','" + ddlCuenta_Mayor.SelectedValue + "');", true);
           
      
        }

        protected void DDLCentro_Contable_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (SesionUsu.Editar == -1)
            {
                CargarGrid();
            }
        }


         protected void index_linbtn(object sender)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdcuentas_contables.SelectedIndex = row.RowIndex;
             Objcuentas_contables.id = grdcuentas_contables.SelectedRow.Cells[0].Text;
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {           
            try
            {
                lblError.Text = string.Empty;
                index_linbtn(sender);
                Objcuentas_contables.id = grdcuentas_contables.SelectedRow.Cells[0].Text;            
                Verificador = string.Empty;       
                CNcuentas_contables.Eliminar_cuenta_contable(ref Objcuentas_contables, ref Verificador);
                
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

        protected void lbtnagregar_Click(object sender, EventArgs e)
        {

            DDLCentro_Contable.Enabled = false;
            ddlCuenta_Mayor.Enabled = false;

            index_linbtn(sender);
            SesionUsu.Editar = 0;
           
            MultiViewcuentas_contables.ActiveViewIndex = 0;
            int nivel_cuenta= Convert.ToInt32( grdcuentas_contables.SelectedRow.Cells[4].Text) ;
            if (nivel_cuenta < 4)
            {
                nivel_cuenta = nivel_cuenta + 1;
                txt4.Enabled = true;
                txtdescripcion.Text = string.Empty;
            }
           
            txtcuenta_contable.Text= grdcuentas_contables.SelectedRow.Cells[1].Text;
            ddlnivel.SelectedValue  =Convert.ToString( nivel_cuenta );
            if (nivel_cuenta==2)
            {
                txttipo.SelectedValue = "AC";
                ddlclasificacion.Enabled = true;
                habil_cuenta();
                txt2.Enabled = true;
            }
            if (nivel_cuenta == 3)
            {
                CNComun.LlenaCombo("pkg_contabilidad.Obt_Combo_Sub_Contables", ref DDLSubdependencia, "p_centro_contable", DDLCentro_Contable.SelectedValue);
                string cadena = txtcuenta_contable.Text;
                txtcuenta_contable.Text = cadena.Substring(0, 11) + DDLSubdependencia.SelectedValue + ".00000";
                txtdescripcion.Text = DDLSubdependencia.SelectedItem.Text.Substring(8);
                Label15.Visible = true;
                DDLSubdependencia.Visible = true;
                ddlclasificacion.Enabled = false;
                txttipo.SelectedValue = "AC";
                ddlclasificacion.SelectedValue = "ESP";
                habil_cuenta( );
                txt3.Enabled = true;
            }
            if (nivel_cuenta == 4)
            {
                ddlclasificacion.Enabled = false;
                txttipo.SelectedValue = "AF";
                ddlclasificacion.SelectedValue = "ESP";
                habil_cuenta( );
                txt4.Enabled = true;
                txtdescripcion.Text = string.Empty;
                BTN_continuar.Visible = true;
            }
           
           
            
        }
        protected void habil_cuenta()
        {
             
            txt1.Text = txtcuenta_contable.Text.Substring(0, 4);
            txt2.Text = txtcuenta_contable.Text.Substring(5, 5);
            txt3.Text = txtcuenta_contable.Text.Substring(11, 5);
            txt4.Text = txtcuenta_contable.Text.Substring(17, 5);
            txt1.Enabled = false;
            txt2.Enabled = false;
            txt3.Enabled = false;
            txt4.Enabled = false;
        }

        protected void grdcuentas_contables_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdcuentas_contables.PageIndex = 0;
            grdcuentas_contables.PageIndex = e.NewPageIndex;
            CargarGrid();
        }

        protected void DDLSubdependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cadena = txtcuenta_contable.Text;
            txtcuenta_contable.Text = cadena.Substring(0,11) + DDLSubdependencia.SelectedValue + ".00000";

            txtdescripcion.Text = DDLSubdependencia.SelectedItem.Text.Substring(8);
            habil_cuenta();
            txt3.Enabled = true;
        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt1_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void txt2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt4_TextChanged(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
        }

        protected void BTN_continuar_Click(object sender, EventArgs e)
        {

            guar_continue = 1;
            GuardarDatos();
            txt4.Text = "00000";
            txtdescripcion.Text = string.Empty;
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            try
            {
                MultiViewcuentas_contables.ActiveViewIndex = 2;
                ddlCuenta_Mayor.Enabled = false;
                index_linbtn(sender);
                CargarGrid_polizas();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        private void CargarGrid_polizas()
        {
            try
            {
                DataTable dt = new DataTable();

                grvPolizas.DataSource = dt;
                grvPolizas.DataSource = GetList_poliza();
                grvPolizas.DataBind();

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        private List<cuentas_contables> GetList_poliza()
        {
            try
            {
                List<cuentas_contables> List = new List<cuentas_contables>();

                Objcuentas_contables.ejercicio = SesionUsu.Usu_Ejercicio;
                Objcuentas_contables.centro_contable = DDLCentro_Contable.SelectedValue;
                Objcuentas_contables.tipo = "T";
                Objcuentas_contables.cuenta_contable = grdcuentas_contables.SelectedRow.Cells[1].Text;
                Objcuentas_contables.nivel = grdcuentas_contables.SelectedRow.Cells[4].Text;
                Objcuentas_contables.buscar = txtBuscar0.Text;
                CNcuentas_contables.PolizaConsultaGrid(ref Objcuentas_contables,  ref List);

                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void txtBuscar0_TextChanged(object sender, EventArgs e)
        {

        }

        protected void imgbtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargarGrid_polizas();
        }

        protected void linkBttnImprimir_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grvPolizas.SelectedIndex = row.RowIndex;
            string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-005&Ejercicio="+SesionUsu.Usu_Ejercicio+"&id="+ grvPolizas.SelectedRow.Cells[0].Text;
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }

        protected void DDLCentro_Contable0_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid_polizas();
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            MultiViewcuentas_contables.ActiveViewIndex = 1;
            ddlCuenta_Mayor.Enabled = true;
        }

        protected void grvPolizas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvPolizas.PageIndex = 0;
            grvPolizas.PageIndex = e.NewPageIndex;
            CargarGrid_polizas();
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdcuentas_contables.SelectedIndex = row.RowIndex;
            try
            {
                lblError.Text = string.Empty;
                MultiViewcuentas_contables.ActiveViewIndex = 0;
                SesionUsu.Editar = 1;
                int v = grdcuentas_contables.SelectedIndex;

                Objcuentas_contables.id = grdcuentas_contables.Rows[v].Cells[0].Text;
                CNcuentas_contables.Consultarcuenta_contable(ref Objcuentas_contables, ref Verificador);

                if (Verificador == "0")
                {

                    DDLCentro_Contable.SelectedValue = Objcuentas_contables.centro_contable;
                    ddlCuenta_Mayor.SelectedValue = Objcuentas_contables.cuenta_mayor;
                    txtcuenta_contable.Text = Objcuentas_contables.cuenta_contable;
                    txtdescripcion.Text = Objcuentas_contables.descripcion;
                    txttipo.Text = Objcuentas_contables.tipo;
                    ddlclasificacion.SelectedValue = Objcuentas_contables.clasificacion;
                    ddlstatus.SelectedValue = Objcuentas_contables.status;
                    ddlclasificacion.SelectedValue = Objcuentas_contables.clasificacion;
                    ddlnivel.SelectedValue = Objcuentas_contables.nivel;
                    //lbtnagregar_Click(null, null);
                    habil_cuenta();
                    DDLCentro_Contable.Enabled = false;
                    ddlCuenta_Mayor.Enabled = false;
                    txttipo.Enabled = false;
                    ddlclasificacion.Enabled = false;



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

        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            lblError.Text = string.Empty;
            MultiViewcuentas_contables.ActiveViewIndex = 0;
            txtcuenta_contable.Text = string.Empty;
            txtdescripcion.Text = string.Empty;
            //cargarcombos();

            SesionUsu.Editar = 0;
            //txtcuenta_contable.Visible = true;
            ddlclasificacion.Enabled = false;
            txttipo.SelectedValue = "AC";
            ddlclasificacion.SelectedValue = "ESP";
            ddlnivel.SelectedValue = "1";
            txtcuenta_contable.Text = Listcodigo[ddlCuenta_Mayor.SelectedIndex].EtiquetaDos + ".00000.00000.00000";
            txtdescripcion.Text = Listcodigo[ddlCuenta_Mayor.SelectedIndex].EtiquetaTres;
            habil_cuenta();
            txt1.Enabled = true;
        }
    }
}