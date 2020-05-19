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
    public partial class frmInventario : System.Web.UI.Page
    {
        #region <Variables>
        String Verificador = string.Empty;
        int[] Columnas;
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        Bien ObjBien = new Bien();
        //Bien_Detalle ObjBien_Detalle;
        CN_Comun CNComun = new CN_Comun();
        CN_Usuario CNUsuario = new CN_Usuario();
        CN_Bien CNBien = new CN_Bien();
        Comun ObjCC = new Comun();
        Int32[] Celdas = new Int32[] { 0, 0, 0};
        private static List<Comun> Formulario=new List<Comun>();
        private static List<Comun> Dependencias = new List<Comun>();
        private static List<Comun> Polizas = new List<Comun>();
        private static string Code;
        private static string No_Inv;
        private static List<Bien_Detalle> ListaComponentes = new List<Bien_Detalle>();
        private static int Mes_Inicial;
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
            Code = Convert.ToString(Request.QueryString["Code"]);
            Mes_Inicial = System.DateTime.Today.Month;
            SesionUsu.Editar = -1;
            MultiView1.ActiveViewIndex = 0;
            CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Dependencia", ref DDLDependencia, "p_usuario", SesionUsu.CUsuario, ref Dependencias);
            HiddenCentro_Contable.Value = Dependencias[DDLDependencia.SelectedIndex].EtiquetaDos;
            txtFecha_Ini.Text = "31/12/1995";
            txtFecha_Fin.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            lblError.Text = string.Empty;
            if (Code == "02721")
            {
                btnGuardar.ValidationGroup = string.Empty;
            }
            else
            {
                btnGuardar.ValidationGroup = "General";
            }
        }
        private void Cargarcombos()
        {
          
            try
            {
               
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_basicos", ref DDLTipo_Alta, "p_tipo", "PAT_CAT_ALTAS");
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_Responsable", ref DDLResponsable, "p_dependencia","p_tipo", DDLDependencia.SelectedValue,"1" );
                DDLCantidad.Items.Clear();
                for (int elemento = 1; elemento <= 50; elemento++) 
                {
                    DDLCantidad.Items.Add(elemento.ToString());
                }
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_categoria", ref DDLClasificacion);
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_centro_trabajo", ref DDLCentroTrabajo, "p_dependencia", DDLDependencia.SelectedValue);
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_Catsubclases", ref DDLSubClase);
                //CNComun.LlenaCombo("pkg_patrimonio.obt_combo_proveedores", ref DDLProveedor);
            }
            catch (Exception ex)
            {
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un problema al cargar los datos: "+ex.Message+"');", true);
                lblError.Text = ex.Message;
            }
        }
        private void CargarCombosAlta(DateTime fecha_actual)
        {
            //DDLCantidad.Enabled = false;
            Formulario.Clear();
            if (fecha_actual.Year <= 2018)
            {
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_polizas", ref DDLPoliza, "p_centro_contable", "p_ejercicio", "p_mes", "p_tipo", HiddenCentro_Contable.Value, SesionUsu.Usu_Ejercicio, fecha_actual.Month.ToString(), "A", ref Polizas);
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_ctas_contables", ref DDLContab, "p_centro_contable", "p_poliza", "p_ejercicio", "p_mes", HiddenCentro_Contable.Value, DDLPoliza.SelectedValue, SesionUsu.Usu_Ejercicio, fecha_actual.Month.ToString());
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_CatBienes", ref DDLClave, "p_cuenta", "p_subcuenta", "p_4nivel", DDLContab.SelectedValue.Substring(0, 4), DDLContab.SelectedValue.Substring(0, 6), DDLContab.SelectedValue.Substring(17, 5), ref Formulario);
            }
            else
            {
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_polizas", ref DDLPoliza, "p_centro_contable", "p_ejercicio", "p_mes", "p_tipo", "p_clasificacion", HiddenCentro_Contable.Value, SesionUsu.Usu_Ejercicio, fecha_actual.Month.ToString(), "A", DDLClasificacion.SelectedValue, ref Polizas);
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_ctas_contables", ref DDLContab, "p_centro_contable", "p_poliza", "p_ejercicio", "p_mes", "p_clasificacion", HiddenCentro_Contable.Value, DDLPoliza.SelectedValue, SesionUsu.Usu_Ejercicio, fecha_actual.Month.ToString(), DDLClasificacion.SelectedValue);
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_CatBienes", ref DDLClave, "p_cuenta", "p_subcuenta", "p_4nivel", "p_clasificacion", DDLContab.SelectedValue.Substring(0, 4), DDLContab.SelectedValue.Substring(0, 6), DDLContab.SelectedValue.Substring(17, 5), DDLClasificacion.SelectedValue, ref Formulario);
            }
            
            
            CNComun.LlenaCombo("pkg_patrimonio.obt_combo_cedulas", ref DDLCedula, "p_dependencia", "p_mes_anio",  DDLDependencia.SelectedValue, fecha_actual.Month.ToString()+ fecha_actual.Year.ToString().Substring(2,2));

            CNComun.LlenaCombo("pkg_patrimonio.obt_combo_proyectos", ref DDLProyecto, "p_ejercicio", "p_centro_contable", "p_poliza_numero", "p_cedula_numero","p_tipo_alta",SesionUsu.Usu_Ejercicio, HiddenCentro_Contable.Value, "",DDLCedula.SelectedValue,DDLTipo_Alta.SelectedValue);
            CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Fuente_Financiamient", ref DDLFuente, "p_ejercicio", "p_centro_contable", "p_poliza_numero", "p_cedula_numero", "p_proyecto", "p_tipo_alta",SesionUsu.Usu_Ejercicio, HiddenCentro_Contable.Value, "", DDLCedula.SelectedValue, "",DDLTipo_Alta.SelectedValue);

            
            Activa_Formulario();
            }
        private void VerificaFechas(TextBox txt)
        {
           
            DateTime fecha = Convert.ToDateTime(txt.Text);
            string Anio = fecha.ToString("yyyy");
            if (Anio != SesionUsu.Usu_Ejercicio)
            {
                if (SesionUsu.Editar == 0)
                    txt.Text = fecha.Day.ToString() + "/" + fecha.Month.ToString() + "/" + SesionUsu.Usu_Ejercicio;
                //lblMsj.Text = "Ejercicio incorrecto";
                else
                    txt.Text=HiddenFecha_Alta.Value;

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
                    Columnas[1] = 9;
                    Columnas[3] = 10;

                    if (DDLStatus.SelectedValue == "A")
                        Columnas[2] = 7;
                    else
                        Columnas[2] = 11;

                    string Code = Convert.ToString(Request.QueryString["Code"]);
                    if (Code != "02721")
                    {
                        Columnas[4] = 13;
                        Columnas[5] = 14;
                    }
                    else
                    {
                        Columnas[4] = 0;
                        Columnas[5] = 0;
                    }

                    CNComun.HideColumns(grvInventario, Columnas);
                }
            }
            catch (Exception ex)
            {
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un problema al cargar los datos: " + ex.Message + "');", true);
                lblError.Text = ex.Message;
            }
        }
        private void CargarGridComponentes(List<Bien_Detalle> ListaComponentes)
        {
            grvComponentes.DataSource = null;
            grvComponentes.DataBind();
            try
            {
                grvComponentes.DataSource = ListaComponentes;
                grvComponentes.DataBind();

                //if (SesionUsu.Editar == 2)
                   Celdas = new Int32[] { 0, 1 };
                //else
                //    Celdas = new Int32[] { 0 };

                if (grvComponentes.Rows.Count > 0)
                    CNComun.HideColumns(grvComponentes, Celdas);

                linkBtnComponentes.Text = ListaComponentes.Count.ToString() + " componente(s) agregado(s) al conjunto.";
            }
            catch (Exception ex)
            {
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un problema al cargar los datos: " + ex.Message + "');", true);
                lblError.Text = ex.Message;
            }
        }
        private List<Bien> GetList()
        {
            try
            {
                List<Bien> List = new List<Bien>();
                Bien Parametros = new Bien();
                Parametros.Dependencia=DDLDependencia.SelectedValue;
                Parametros.Estatus = DDLStatus.SelectedValue;
                CNBien.ConsultarGrid(Parametros,txtBuscar.Text.ToUpper(),txtFecha_Ini.Text,txtFecha_Fin.Text, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
      
        private void InicializaCamposGuardar(bool Valor)
        {
            lblBuscar.Visible = Valor;
            txtBuscar.Visible = Valor;
            imgbtnBuscar.Visible = Valor;
            btnNuevo.Visible = Valor;
            lblEstatus.Visible = Valor;
            DDLStatus.Visible = Valor;
            DDLDependencia.Enabled = Valor;
            pnlFechas.Visible = Valor;
            lblFecha_Ini.Visible = Valor;
            txtFecha_Ini.Visible = Valor;
            imgCalendarioIni.Visible = Valor;
            txtFecha_Fin.Visible = Valor;
            imgCalendarioFin.Visible = Valor;
            MultiView1.ActiveViewIndex = 0;
        }
        private void Campos_Editables(bool Valor)
        {
            txtFecha_Alta.Enabled = Valor;
            Calendario_FecAlta.Visible = Valor;
            txtProveedor.Enabled = Valor;
            txtFecha_Factura.Enabled = Valor;
            txtFolio_Factura.Enabled = Valor;
            imgCalendario.Visible = Valor;
            DDLTipo_Alta.Enabled = Valor;
            DDLPoliza.Enabled = Valor;
            DDLContab.Enabled = Valor;
            DDLClave.Enabled = Valor;
            DDLCedula.Enabled = Valor;
            DDLClasificacion.Enabled = Valor;
            imgCalendarioAltaAnterior.Visible = Valor;
            txtAlta_Anterior.Enabled= Valor;
            txtProcedencia.Enabled = Valor;
            txtVolante_Transferencia.Enabled = Valor;
            txtInv_Anterior.Enabled = Valor;
            DDLProyecto.Enabled = Valor;
            DDLFuente.Enabled = Valor;
            txtCosto.Enabled = Valor;

            string Code = Convert.ToString(Request.QueryString["Code"]);
            if (Code != "02721")
            {
                chkResguardo.Enabled = false;
            }
            else
            {
                chkResguardo.Enabled = true;
            }

            chkValidado.Visible = false;
            DDLTipo_Alta.Enabled = Valor;
            DDLCantidad.Enabled = false;
            DDLCentroTrabajo.Enabled = true;
            DDLResponsable.Enabled = true;
            txtCorresponsable.Enabled = true;
            txtProveedor.Enabled = Valor;
            txtFolio_Factura.Enabled = Valor;
            txtFecha_Factura.Enabled = Valor;
            imgCalendario.Visible = Valor;
            txtObservaciones.Enabled = true;

            btnGuardar.Visible = true;

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
                //var dropDownList = control as DropDownList;
                //if (dropDownList != null)
                //{
                //    dropDownList.SelectedIndex = 0;
                //}

                foreach (Control childControl in control.Controls)
                {
                    Limpiador_controles(childControl);
                }
            }
            catch (Exception ex)
            {
                // ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un problema al cargar los datos: " + ex.Message + "');", true);
                lblError.Text = ex.Message;
            } 
        }
        private void Activa_Formulario()
        {
            DDLCantidad.Enabled = false;
            DDLCantidad.SelectedValue = "1";
            linkBtnComponentes.Visible = false;

            if (Formulario.Count == 0)
            {
                DDLClave.Items.Clear();
                DDLClave.Items.Add("Póngase en contacto con su analista de patrimonio");
            }

            if (DDLClave.SelectedValue == "Póngase en contacto con su analista de patrimonio")
            {
                TabContBienes.Visible = false;
                TabContBienes.Enabled = false;
            }
            else
            {
                DDLSubClase.SelectedValue = Convert.ToString(Formulario[DDLClave.SelectedIndex].EtiquetaSeis);
                if (Formulario[DDLClave.SelectedIndex].EtiquetaCuatro == "S")
                    DDLCantidad.Enabled = true;
                if (Formulario[DDLClave.SelectedIndex].EtiquetaCinco == "S")
                    linkBtnComponentes.Visible = true;

               
                TabContBienes.Visible = true;
                TabContBienes.Enabled = true;
               

                if (Convert.ToInt32(Formulario[DDLClave.SelectedIndex].EtiquetaDos) == 1)
                    TabPanelEnabled(ref TabMuebles, ref TabContBienes, Convert.ToInt32(Formulario[DDLClave.SelectedIndex].EtiquetaDos) - 1);
                else
                    if (Convert.ToInt32(Formulario[DDLClave.SelectedIndex].EtiquetaDos) == 2)
                        TabPanelEnabled(ref TabInmuebles, ref TabContBienes, Convert.ToInt32(Formulario[DDLClave.SelectedIndex].EtiquetaDos) - 1);
                    else
                        if (Convert.ToInt32(Formulario[DDLClave.SelectedIndex].EtiquetaDos) == 3)
                            TabPanelEnabled(ref TabVehiculos, ref TabContBienes, Convert.ToInt32(Formulario[DDLClave.SelectedIndex].EtiquetaDos) - 1);
                        else
                            if (Convert.ToInt32(Formulario[DDLClave.SelectedIndex].EtiquetaDos) == 4)
                                TabPanelEnabled(ref TabTic, ref TabContBienes, Convert.ToInt32(Formulario[DDLClave.SelectedIndex].EtiquetaDos) - 1);
                            else
                                if (Convert.ToInt32(Formulario[DDLClave.SelectedIndex].EtiquetaDos) == 5)
                                    TabPanelEnabled(ref TabEquipos, ref TabContBienes, Convert.ToInt32(Formulario[DDLClave.SelectedIndex].EtiquetaDos) - 1);
                                else
                                    if (Convert.ToInt32(Formulario[DDLClave.SelectedIndex].EtiquetaDos) == 6)
                                        TabPanelEnabled(ref TabBiologicos, ref TabContBienes, Convert.ToInt32(Formulario[DDLClave.SelectedIndex].EtiquetaDos) - 1);
                                    else
                                        if (Convert.ToInt32(Formulario[DDLClave.SelectedIndex].EtiquetaDos) == 7)
                                            TabPanelEnabled(ref TabIntangibles, ref TabContBienes, Convert.ToInt32(Formulario[DDLClave.SelectedIndex].EtiquetaDos) - 1);
                                        else
                                            if (Convert.ToInt32(Formulario[DDLClave.SelectedIndex].EtiquetaDos) == 8)
                                                TabPanelEnabled(ref TabColecciones, ref TabContBienes, Convert.ToInt32(Formulario[DDLClave.SelectedIndex].EtiquetaDos) - 1);
            } 
        }
        private void LimpiarFrmComponente()
        {
            txtComponenteCaracteristicas.Text = string.Empty;
            txtComponenteMarca.Text = string.Empty;
            txtComponenteModelo.Text = string.Empty;
            txtComponenteSerie.Text = string.Empty;
            txtComponenteColor.Text = string.Empty;
        }
        private void EditarComponentes(bool Valor)
        {
            grvComponentes.Enabled = Valor;
            btnComponente_Agregar.Enabled = Valor;
            txtComponenteCaracteristicas.Enabled = Valor;
            txtComponenteMarca.Enabled = Valor;
            txtComponenteModelo.Enabled = Valor;
            txtComponenteSerie.Enabled = Valor;
            txtComponenteColor.Enabled = Valor;
           
        }
        private void TabPanelEnabled(ref AjaxControlToolkit.TabPanel Panel_Activo, ref AjaxControlToolkit.TabContainer TabCont, Int32 PanelActivo)
        {
            TabMuebles.Enabled = false;
            TabInmuebles.Enabled = false;
            TabVehiculos.Enabled = false;
            TabTic.Enabled = false;
            TabEquipos.Enabled = false;
            TabBiologicos.Enabled = false;
            TabIntangibles.Enabled = false;
            TabColecciones.Enabled = false;

            TabCont.ActiveTabIndex = PanelActivo;
            Panel_Activo.Enabled = true;
        }
            private void Nuevo()
        {
            //Limpiador_controles(this);
            lblInventario.Visible = false;
            txtInventario.Visible = false;
            InicializaCamposGuardar(false);
            Campos_Editables(true);
            MultiView1.ActiveViewIndex = 1;
            TabContBienes.Visible = false;
            TabContBienes.Enabled = false;
            HiddenClave_Bien.Value = string.Empty;
            HiddenFecha_Alta.Value = string.Empty;
            txtFecha_Contable.Text = string.Empty;
            HiddenFechaReclasificacion.Value = string.Empty;
            HiddenCedula.Value = string.Empty;
            Cargarcombos();
            Limpiador_controles(TabContBienes);
            SesionUsu.Editar = 0;
            
            txtCosto.Text = "0.00";
            txtINM_Terreno.Text = "0.00";
            txtINM_Edificio.Text = "0.00";
            txtSem_Revalorizado.Text = "0.00";
            txtFolio_Factura.Text = string.Empty;
            txtFecha_Factura.Text = string.Empty;
            txtVolante_Transferencia.Text = string.Empty;
            txtInv_Anterior.Text = string.Empty;
            DDLCedula.Visible = true;
            DDLCedula.Enabled = true;
            pnlTransferencia.Visible = false;
            lblError.Text = string.Empty;
            txtProveedor.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
           
            Code = Convert.ToString(Request.QueryString["Code"]);

            chkValidado.Checked = false;
            chkResguardo.Checked = false;
            if (Code != "02721")
            {
                chkValidado.Enabled = false;
                chkResguardo.Enabled = false;
            }
            else
            {
                chkValidado.Enabled = true;
                chkResguardo.Enabled = true;
            }

        }
        private void Cancelar()
        {
           
            lblInventario.Visible = false;
            txtInventario.Visible = false;
            lblError.Text = string.Empty;
            if (ListaComponentes != null && ListaComponentes.Count > 0)
                ListaComponentes.Clear();


            Session["ListaComponentes"] = ListaComponentes;
            linkBtnComponentes.Visible = false;
            CargarGridComponentes(ListaComponentes);
            SesionUsu.Editar = -1;
            InicializaCamposGuardar(true);
            CargarGrid();
        }
        #endregion

        #region <Botones y Eventos>
        protected void btnComponente_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                Bien_Detalle objComponente = new Bien_Detalle();
               
                    Page.Validate("Componente");
                    if (Page.IsValid)
                    {
                        objComponente.Caracteristicas = txtComponenteCaracteristicas.Text.ToUpper();
                        objComponente.Marca = txtComponenteMarca.Text.ToUpper();
                        objComponente.Modelo = txtComponenteModelo.Text.ToUpper();
                        objComponente.No_Serie = txtComponenteSerie.Text.ToUpper();
                        objComponente.Color = txtComponenteColor.Text.ToUpper();
                    }
               
                if (Session["ListaComponentes"] == null)
                {
                    ListaComponentes = new List<Bien_Detalle>();
                    ListaComponentes.Add(objComponente);
                }
                else
                {
                    ListaComponentes = (List<Bien_Detalle>)Session["ListaComponentes"];
                    ListaComponentes.Add(objComponente);
                }
                Session["ListaComponentes"] = ListaComponentes;

                if (ListaComponentes.Count > 0)
                    btnGuardar.Enabled = true;
                CargarGridComponentes(ListaComponentes);
                linkBtnComponentes.Text = ListaComponentes.Count.ToString() + " componente(s) agregado(s) al conjunto.";

                LimpiarFrmComponente();
                modalComponentes.Show();

            }

            catch (Exception ex)
            {
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un problema al cargar los datos: " + ex.Message + "');", true);
                lblError.Text = ex.Message;
            }
        }
       
        protected void DDLClave_SelectedIndexChanged(object sender, EventArgs e)
        {
            Activa_Formulario();
        }
        protected void DDLDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            //HiddenCentro_Contable.Value = Dependencias[DDLDependencia.SelectedIndex].EtiquetaDos;
        }
        protected void DDLPoliza_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime fecha_actual;
                fecha_actual = Convert.ToDateTime(txtFecha_Alta.Text);
                Formulario.Clear();
            if (fecha_actual.Year <= 2018)
            {
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_ctas_contables", ref DDLContab, "p_centro_contable", "p_poliza", "p_ejercicio", "p_mes",  HiddenCentro_Contable.Value, DDLPoliza.SelectedValue, SesionUsu.Usu_Ejercicio, fecha_actual.Month.ToString());
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_CatBienes", ref DDLClave, "p_cuenta", "p_subcuenta", "p_4nivel",  DDLContab.SelectedValue.Substring(0, 4), DDLContab.SelectedValue.Substring(0, 6), DDLContab.SelectedValue.Substring(17, 5),  ref Formulario);
            }
            else
            {
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_ctas_contables", ref DDLContab, "p_centro_contable", "p_poliza", "p_ejercicio", "p_mes", "p_clasificacion", HiddenCentro_Contable.Value, DDLPoliza.SelectedValue, SesionUsu.Usu_Ejercicio, fecha_actual.Month.ToString(), DDLClasificacion.SelectedValue);
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_CatBienes", ref DDLClave, "p_cuenta", "p_subcuenta", "p_4nivel", "p_clasificacion", DDLContab.SelectedValue.Substring(0, 4), DDLContab.SelectedValue.Substring(0, 6), DDLContab.SelectedValue.Substring(17, 5), DDLClasificacion.SelectedValue, ref Formulario);
            }
            
            Activa_Formulario();
        }

        protected void DDLContab_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime fecha_actual;
            fecha_actual = Convert.ToDateTime(txtFecha_Alta.Text);
            Formulario.Clear();
            if (fecha_actual.Year <= 2018)
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_CatBienes", ref DDLClave, "p_cuenta", "p_subcuenta", "p_4nivel", DDLContab.SelectedValue.Substring(0, 4), DDLContab.SelectedValue.Substring(0, 6), DDLContab.SelectedValue.Substring(17, 5), ref Formulario);
            else
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_CatBienes", ref DDLClave, "p_cuenta", "p_subcuenta", "p_4nivel", "p_clasificacion", DDLContab.SelectedValue.Substring(0, 4), DDLContab.SelectedValue.Substring(0, 6), DDLContab.SelectedValue.Substring(17, 5), DDLClasificacion.SelectedValue, ref Formulario);

            DDLSubClase.SelectedValue = Convert.ToString(Formulario[DDLClave.SelectedIndex].EtiquetaSeis);
            Activa_Formulario();
        }
        protected void DDLClasificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime fecha_actual = Convert.ToDateTime(txtFecha_Alta.Text);
            if (fecha_actual.Year<=2018)
            {
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_polizas", ref DDLPoliza, "p_centro_contable", "p_ejercicio", "p_mes", "p_tipo", HiddenCentro_Contable.Value, SesionUsu.Usu_Ejercicio, fecha_actual.Month.ToString(), "A",  ref Polizas);
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_ctas_contables", ref DDLContab, "p_centro_contable", "p_poliza", "p_ejercicio", "p_mes", HiddenCentro_Contable.Value, DDLPoliza.SelectedValue, SesionUsu.Usu_Ejercicio, fecha_actual.Month.ToString());
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_CatBienes", ref DDLClave, "p_cuenta", "p_subcuenta", "p_4nivel", DDLContab.SelectedValue.Substring(0, 4), DDLContab.SelectedValue.Substring(0, 6), DDLContab.SelectedValue.Substring(17, 5), ref Formulario);
            }
            else
            {
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_polizas", ref DDLPoliza, "p_centro_contable", "p_ejercicio", "p_mes", "p_tipo", "p_clasificacion", HiddenCentro_Contable.Value, SesionUsu.Usu_Ejercicio, fecha_actual.Month.ToString(), "A", DDLClasificacion.SelectedValue, ref Polizas);
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_ctas_contables", ref DDLContab, "p_centro_contable", "p_poliza", "p_ejercicio", "p_mes", "p_clasificacion", HiddenCentro_Contable.Value, DDLPoliza.SelectedValue, SesionUsu.Usu_Ejercicio, fecha_actual.Month.ToString(), DDLClasificacion.SelectedValue);
                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_CatBienes", ref DDLClave, "p_cuenta", "p_subcuenta", "p_4nivel", "p_clasificacion", DDLContab.SelectedValue.Substring(0, 4), DDLContab.SelectedValue.Substring(0, 6), DDLContab.SelectedValue.Substring(17, 5), DDLClasificacion.SelectedValue, ref Formulario);
            }
            DDLSubClase.SelectedValue = Convert.ToString(Formulario[DDLClave.SelectedIndex].EtiquetaSeis);
            if (DDLClasificacion.SelectedValue == "A")
                DDLSubClase.Enabled = false;
            else
                DDLSubClase.Enabled = true;
        }
        protected void DDLCedula_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("pkg_patrimonio.obt_combo_proyectos", ref DDLProyecto, "p_ejercicio", "p_centro_contable", "p_poliza_numero", "p_cedula_numero", "p_tipo_alta", SesionUsu.Usu_Ejercicio, HiddenCentro_Contable.Value, "", DDLCedula.SelectedValue, DDLTipo_Alta.SelectedValue);
            CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Fuente_Financiamient", ref DDLFuente, "p_ejercicio", "p_centro_contable", "p_poliza_numero", "p_cedula_numero", "p_proyecto", "p_tipo_alta", SesionUsu.Usu_Ejercicio, HiddenCentro_Contable.Value, "", DDLCedula.SelectedValue, "", DDLTipo_Alta.SelectedValue);
        }
        protected void txtFecha_Alta_TextChanged(object sender, EventArgs e)
        {
            VerificaFechas(txtFecha_Alta);
            if(SesionUsu.Editar==0)
                txtFecha_Contable.Text = txtFecha_Alta.Text;
                DateTime fecha_actual = Convert.ToDateTime(txtFecha_Alta.Text);
                if (Mes_Inicial != fecha_actual.Month)
                {
                    CargarCombosAlta(fecha_actual);
                    Mes_Inicial = fecha_actual.Month;
                }
        }
      
        protected void grvInventario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvInventario.PageIndex = 0;
            grvInventario.PageIndex = e.NewPageIndex;
            CargarGrid();
        }
        protected void grvInventario_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Code = Convert.ToString(Request.QueryString["Code"]);
            if (grvInventario.SelectedRow.Cells[2].Text.Length ==10)
            {
               Bien_Detalle ObjBien_Detalle = new Bien_Detalle();
            
                //btnNuevo_Click(null, null);
                try
                {
                   
                    ObjBien_Detalle.Id = Convert.ToInt32(grvInventario.SelectedRow.Cells[0].Text);
                    Verificador = string.Empty;
                    CNBien.ConsultarBien(ref ObjBien_Detalle, ref Verificador);
                    if (Verificador == "0")
                    {
                        DDLDependencia.SelectedValue = ObjBien_Detalle.Dependencia;
                        Nuevo();
                        //DDLTipo_Alta.Items.Insert(3,new ListItem("03-TRANSFERENCIA","1057"));
                        //Cargarcombos();
                        linkBtnComponentes.Text ="0 componente(s) agregado(s) en el conjunto";
                        linkBtnComponentes.Visible = false;
                        Mes_Inicial = Convert.ToDateTime(ObjBien_Detalle.Fecha_Alta_Str).Month;
                        SesionUsu.Editar = 1;
                        txtFecha_Alta.Text = ObjBien_Detalle.Fecha_Alta_Str;
                        HiddenCentro_Contable.Value = ObjBien_Detalle.Centro_Contable;
                        HiddenEjercicio.Value = ObjBien_Detalle.Ejercicio.ToString();
                        HiddenFecha_Alta.Value = ObjBien_Detalle.Fecha_Alta_Str;
                        HiddenFechaReclasificacion.Value = ObjBien_Detalle.Fecha_Reclasificacion_Str;
                        txtFecha_Contable.Text = ObjBien_Detalle.Fecha_Contable_Str;
                        
                        DDLTipo_Alta.SelectedValue = ObjBien_Detalle.IdTipo_Alta.ToString();
                        string Tipo_Poliza = string.Empty;
                       
                        lblInventario.Visible = true;
                        txtInventario.Visible = true;
                        txtInventario.Text = ObjBien_Detalle.No_Inventario;
                        DDLClasificacion.SelectedValue = ObjBien_Detalle.Clasificacion;
                        DDLCentroTrabajo.SelectedValue = ObjBien_Detalle.Centro_Trabajo;
                        string Fecha_Poliza = string.Empty;
                        string Ejercicio_Poliza = string.Empty;
                        if (ObjBien_Detalle.Fecha_Reclasificacion_Str != null && ObjBien_Detalle.Fecha_Reclasificacion_Str != string.Empty && ObjBien_Detalle.Fecha_Reclasificacion_Str != "")
                        {
                            Fecha_Poliza = ObjBien_Detalle.Fecha_Contable_Str;
                            Ejercicio_Poliza = Convert.ToDateTime(ObjBien_Detalle.Fecha_Contable_Str).Year.ToString();
                        }
                        else
                        {
                            Fecha_Poliza = ObjBien_Detalle.Fecha_Alta_Str;
                            Ejercicio_Poliza = ObjBien_Detalle.Ejercicio.ToString(); 
                        }

                        //Comprueba si el RESGUARDO ya está impreso y si la captura ya está validada por un analista
                        if (ObjBien_Detalle.Resguardo=="S")
                            chkResguardo.Checked = true;
                        else
                            chkResguardo.Checked = false;

                        chkValidado.Checked = ObjBien_Detalle.Validado;
                        CNComun.LlenaCombo("pkg_patrimonio.obt_combo_Responsable", ref DDLResponsable, "p_dependencia", "p_tipo", DDLDependencia.SelectedValue, "1");
                        DDLResponsable.SelectedValue = ObjBien_Detalle.Responsable;
                        if (ObjBien_Detalle.Ejercicio >= 2015)
                        {
                            if (ObjBien_Detalle.Ejercicio <= 2018)
                            {
                                //LLena Combo Pólizas y Obtiene Póliza
                                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_polizas", ref DDLPoliza, "p_centro_contable", "p_ejercicio", "p_mes", "p_tipo", ObjBien_Detalle.Centro_Contable, Ejercicio_Poliza.ToString(), Convert.ToDateTime(Fecha_Poliza).Month.ToString(), Tipo_Poliza, ref Polizas);

                                //LLena Combo Cuentas Contables y Obtiene Cuenta
                                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_ctas_contables", ref DDLContab, "p_centro_contable", "p_poliza", "p_ejercicio", "p_mes", ObjBien_Detalle.Centro_Contable, ObjBien_Detalle.Poliza, Ejercicio_Poliza.ToString(), Convert.ToDateTime(Fecha_Poliza).Month.ToString());
                            }
                            else
                            {
                                //LLena Combo Pólizas y Obtiene Póliza
                                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_polizas", ref DDLPoliza, "p_centro_contable", "p_ejercicio", "p_mes", "p_tipo","p_clasificacion", ObjBien_Detalle.Centro_Contable, Ejercicio_Poliza.ToString(), Convert.ToDateTime(Fecha_Poliza).Month.ToString(), Tipo_Poliza, DDLClasificacion.SelectedValue,ref Polizas);

                                //LLena Combo Cuentas Contables y Obtiene Cuenta
                                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_ctas_contables", ref DDLContab, "p_centro_contable", "p_poliza", "p_ejercicio", "p_mes", "p_clasificacion", ObjBien_Detalle.Centro_Contable, ObjBien_Detalle.Poliza, Ejercicio_Poliza.ToString(), Convert.ToDateTime(Fecha_Poliza).Month.ToString(),DDLClasificacion.SelectedValue);
                            }

                            //LLena Combo Cedulas, Proyectos, Fuente Financ 
                            if (ObjBien_Detalle.Ejercicio < 2017)
                            {
                                DDLCedula.Items.Clear();
                                DDLCedula.Items.Add(ObjBien_Detalle.Cedula);
                            }
                            else
                                CNComun.LlenaCombo("pkg_patrimonio.obt_combo_cedulas", ref DDLCedula, "p_dependencia", "p_mes_anio", "p_tipo", DDLDependencia.SelectedValue, Convert.ToDateTime(ObjBien_Detalle.Fecha_Alta_Str).Month.ToString() + Convert.ToDateTime(ObjBien_Detalle.Fecha_Alta_Str).Year.ToString().Substring(2, 2), ObjBien_Detalle.IdTipo_Alta.ToString());
                            //CNComun.LlenaCombo("pkg_patrimonio.obt_combo_cedulas", ref DDLCedula, "p_dependencia", "p_mes_anio", "p_tipo", DDLDependencia.SelectedValue, Convert.ToDateTime(Fecha_Poliza).Month.ToString() + Convert.ToDateTime(Fecha_Poliza).Year.ToString().Substring(2, 2), ObjBien_Detalle.IdTipo_Alta.ToString());

                            //CNComun.LlenaCombo("pkg_patrimonio.obt_combo_proyectos", ref DDLProyecto, "p_ejercicio", "p_centro_contable", "p_poliza_numero", "p_cedula_numero", "p_tipo_alta",SesionUsu.Usu_Ejercicio, ObjBien_Detalle.Centro_Contable, "", "", ObjBien_Detalle.IdTipo_Alta.ToString());
                            //CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Fuente_Financiamient", ref DDLFuente, "p_ejercicio", "p_centro_contable", "p_poliza_numero", "p_cedula_numero", "p_proyecto", "p_tipo_alta", SesionUsu.Usu_Ejercicio, ObjBien_Detalle.Centro_Contable, "", "", "",ObjBien_Detalle.IdTipo_Alta.ToString());


                            //LLena Combo Empleados y Obtiene Empleado
                            CNComun.LlenaCombo("pkg_patrimonio.obt_combo_Responsable", ref DDLResponsable, "p_dependencia","p_tipo", DDLDependencia.SelectedValue,"1");
                            DDLResponsable.SelectedValue = ObjBien_Detalle.Responsable;
                           
                        }
                        else
                        {
                            DDLPoliza.Items.Clear();
                            DDLContab.Items.Clear();
                            DDLCedula.Items.Clear();
                            //DDLProyecto.Items.Clear();
                            //DDLFuente.Items.Clear();
                            DDLPoliza.Items.Add(ObjBien_Detalle.Poliza);
                            DDLContab.Items.Add(ObjBien_Detalle.Codigo_Contable);
                            DDLCedula.Items.Add(ObjBien_Detalle.Cedula);
                            //DDLProyecto.Items.Add(ObjBien_Detalle.Proyecto);
                            //DDLFuente.Items.Add(ObjBien_Detalle.Fuente_Financiamiento);
                            HiddenCedula.Value = ObjBien_Detalle.Cedula;
                        }
                        CNComun.LlenaCombo("pkg_patrimonio.obt_combo_proyectos", ref DDLProyecto, "p_ejercicio", "p_centro_contable", "p_poliza_numero", "p_cedula_numero", "p_tipo_alta", SesionUsu.Usu_Ejercicio, ObjBien_Detalle.Centro_Contable, "", "", ObjBien_Detalle.IdTipo_Alta.ToString());
                        CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Fuente_Financiamient", ref DDLFuente, "p_ejercicio", "p_centro_contable", "p_poliza_numero", "p_cedula_numero", "p_proyecto", "p_tipo_alta", SesionUsu.Usu_Ejercicio, ObjBien_Detalle.Centro_Contable, "", "", "", ObjBien_Detalle.IdTipo_Alta.ToString());

                        txtProveedor.Text = ObjBien_Detalle.Proveedor;
                        DDLPoliza.SelectedValue = ObjBien_Detalle.Poliza;
                        DDLContab.SelectedValue = ObjBien_Detalle.Codigo_Contable;
                        DDLProyecto.SelectedValue = ObjBien_Detalle.Proyecto;
                        DDLFuente.SelectedValue = ObjBien_Detalle.Fuente_Financiamiento;

                        if (ObjBien_Detalle.IdTipo_Alta == 1057)
                        {
                            Tipo_Poliza = "T";
                            lblCedula.Visible = false;
                            DDLCedula.Visible = false;
                            pnlTransferencia.Visible = true;
                            txtInv_Anterior.Text = ObjBien_Detalle.Inventario_Anterior;
                            txtVolante_Transferencia.Text = ObjBien_Detalle.Volante;
                            txtAlta_Anterior.Text = ObjBien_Detalle.Fecha_Alta_Ant_Str;
                            txtProcedencia.Text = ObjBien_Detalle.Procedencia;
                        }
                        else
                        {
                            Tipo_Poliza = "A";
                            lblCedula.Visible = true;
                            DDLCedula.Visible = true;
                            DDLCedula.Enabled = true;
                            DDLCedula.SelectedValue = ObjBien_Detalle.Cedula;
                            pnlTransferencia.Visible = false;
                          
                        }

                       

                        //LLena Combo Claves y Obtiene Clave
                        Formulario.Clear();
                        if (ObjBien_Detalle.Ejercicio <= 2018)
                            CNComun.LlenaCombo("pkg_patrimonio.obt_combo_CatBienes", ref DDLClave, "p_cuenta", "p_subcuenta", "p_4nivel", DDLContab.SelectedValue.Substring(0, 4), DDLContab.SelectedValue.Substring(0, 6), DDLContab.SelectedValue.Substring(17, 5), ref Formulario);
                        else
                            CNComun.LlenaCombo("pkg_patrimonio.obt_combo_CatBienes", ref DDLClave, "p_cuenta", "p_subcuenta", "p_4nivel","p_clasificacion", DDLContab.SelectedValue.Substring(0, 4), DDLContab.SelectedValue.Substring(0, 6), DDLContab.SelectedValue.Substring(17, 5),DDLClasificacion.SelectedValue, ref Formulario);

                       
                        DDLClave.SelectedValue = ObjBien_Detalle.Clave;
                        DDLSubClase.SelectedValue = Convert.ToString(Formulario[DDLClave.SelectedIndex].EtiquetaSeis);
                        HiddenClave_Bien.Value = DDLClave.SelectedItem.ToString().Substring(0, 8);

                        txtCorresponsable.Text = ObjBien_Detalle.Corresponsable;

                        txtFolio_Factura.Text = ObjBien_Detalle.Factura_Numero.ToString();
                        txtFecha_Factura.Text = ObjBien_Detalle.Factura_Fecha_Str;
                        txtCosto.Text = ObjBien_Detalle.Costo.ToString("N");
                        txtObservaciones.Text = ObjBien_Detalle.Observaciones;

                      
                        TabContBienes.Visible = true;
                        TabContBienes.Enabled = true;
                        Campos_Editables(true);
                        EditarComponentes(true);
                        if (ObjBien_Detalle.Formulario == 1)
                        {
                            TabPanelEnabled(ref TabMuebles, ref TabContBienes, (ObjBien_Detalle.Formulario - 1));
                            txtM_Caracteristicas.Text = ObjBien_Detalle.Caracteristicas;
                            txtM_Marca.Text = ObjBien_Detalle.Marca;
                            txtM_Modelo.Text = ObjBien_Detalle.Modelo;
                            txtM_Serie.Text = ObjBien_Detalle.No_Serie;
                            txtM_Color.Text = ObjBien_Detalle.Color;
                            TabMuebles.Enabled = true;
                        }
                        else
                            if (ObjBien_Detalle.Formulario == 2)
                            {
                                TabPanelEnabled(ref TabInmuebles, ref TabContBienes, (ObjBien_Detalle.Formulario - 1));
                                txtINM_Direccion.Text = ObjBien_Detalle.Inm_Direccion;
                                txtINM_Ciudad.Text = ObjBien_Detalle.Inm_Ciudad;
                                txtINM_TipoDoc.Text = ObjBien_Detalle.Inm_TipoDoc;
                                txtINM_NumeroDoc.Text = ObjBien_Detalle.Inm_NumeroDoc;
                                txtINM_EstatusDoc.Text = ObjBien_Detalle.Inm_EstatusDoc;
                                txtINM_FechaDoc.Text = ObjBien_Detalle.Inm_FechaDoc_Str;
                                txtINM_Notaria.Text = ObjBien_Detalle.Inm_NotariaPublica;
                                txtINM_LugarExpedicionDoc.Text = ObjBien_Detalle.Inm_ExpedicionDoc;
                                txtINM_Terreno.Text = ObjBien_Detalle.Inm_AvaluoTerreno.ToString("N");
                                txtINM_Edificio.Text = ObjBien_Detalle.Inm_AvaluoEdificio.ToString("N");
                                txtINM_FechaAvaluo.Text = ObjBien_Detalle.Inm_FechaAvaluo_Str;
                                TabInmuebles.Enabled = true;
                            }
                            else
                                if (ObjBien_Detalle.Formulario == 3)
                                {
                                    TabPanelEnabled(ref TabVehiculos, ref TabContBienes, (ObjBien_Detalle.Formulario - 1));
                                    txtVEH_Caracteristicas.Text = ObjBien_Detalle.Caracteristicas;
                                    txtVEH_Marca.Text = ObjBien_Detalle.Marca;
                                    txtVEH_Modelo.Text = ObjBien_Detalle.Modelo;
                                    txtVEH_Año.Text = ObjBien_Detalle.Veh_Año;
                                    txtVEH_Color.Text = ObjBien_Detalle.Color;
                                    txtVEH_Serie.Text = ObjBien_Detalle.No_Serie;
                                    txtVEH_Motor.Text = ObjBien_Detalle.Veh_NumeroMotor;
                                    txtVEH_Placas.Text = ObjBien_Detalle.Veh_NumeroPlacas;
                                    txtVEH_Tenencia.Text = ObjBien_Detalle.Veh_Tenencia;
                                    txtVEH_Poliza.Text = ObjBien_Detalle.Veh_PolizaSeguro;
                                    txtVEH_Seguro.Text = ObjBien_Detalle.Veh_FechaVencimiento_Str;
                                    TabVehiculos.Enabled = true;
                                }

                                else
                                    if (ObjBien_Detalle.Formulario == 4)
                                    {
                                        TabPanelEnabled(ref TabTic, ref TabContBienes, (ObjBien_Detalle.Formulario - 1));
                                        txtTIC_Caracteristicas.Text = ObjBien_Detalle.Caracteristicas;
                                        txtTIC_Marca.Text = ObjBien_Detalle.Marca;
                                        txtTIC_Modelo.Text = ObjBien_Detalle.Modelo;
                                        txtTIC_Serie.Text = ObjBien_Detalle.No_Serie;
                                        txtTIC_Accesorios.Text = ObjBien_Detalle.Tic_Accesorios;
                                        txtTIC_Procesador.Text = ObjBien_Detalle.Tic_Procesador;
                                        txtTIC_RAM.Text = ObjBien_Detalle.Tic_RAM;
                                        txtTIC_DiscoDuro.Text = ObjBien_Detalle.Tic_DiscoDuro;
                                        TabTic.Enabled = true;
                                    }
                                    else
                                        if (ObjBien_Detalle.Formulario == 5)
                                        {
                                            TabPanelEnabled(ref TabEquipos, ref TabContBienes, (ObjBien_Detalle.Formulario - 1));
                                            txtEquipo_Caracteristicas.Text = ObjBien_Detalle.Caracteristicas;
                                            txtEquipo_Marca.Text = ObjBien_Detalle.Marca;
                                            txtEquipo_Modelo.Text = ObjBien_Detalle.Modelo;
                                            txtEquipo_Serie.Text = ObjBien_Detalle.No_Serie;
                                            txtEquipo_Color.Text = ObjBien_Detalle.Color;
                                            TabEquipos.Enabled = true;
                                        }
                                        else
                                            if (ObjBien_Detalle.Formulario == 6)
                                            {
                                                TabPanelEnabled(ref TabBiologicos, ref TabContBienes, (ObjBien_Detalle.Formulario - 1));
                                                txtSem_Raza.Text = ObjBien_Detalle.Sem_Raza;
                                                txtSem_Arete.Text = ObjBien_Detalle.Sem_Arete;
                                                txtSem_Edad.Text = ObjBien_Detalle.Sem_Edad;
                                                txtSem_Nac.Text = ObjBien_Detalle.Sem_FechaNac_Str;
                                                txtSem_Color.Text = ObjBien_Detalle.Color;
                                                txtSem_Peso.Text = ObjBien_Detalle.Sem_Peso;
                                                txtSem_Revalorizado.Text = ObjBien_Detalle.Sem_CostoRevalorizado.ToString("N");
                                                txtSem_Fecha.Text = ObjBien_Detalle.Sem_FechaRevalorizado_Str;
                                                TabBiologicos.Enabled = true;
                                            }
                                            else
                                                if (ObjBien_Detalle.Formulario == 7)
                                                {
                                                    TabPanelEnabled(ref TabIntangibles, ref TabContBienes, (ObjBien_Detalle.Formulario - 1));
                                                    txtInt_Caracteristicas.Text = ObjBien_Detalle.Caracteristicas;
                                                    txtInt_Software.Text = ObjBien_Detalle.Int_TipoSoftware;
                                                    txtInt_Marca.Text = ObjBien_Detalle.Marca;
                                                    txtInt_Patente.Text = ObjBien_Detalle.Int_Patente;
                                                    txtInt_Derecho.Text = ObjBien_Detalle.Int_DerechoAutor;
                                                    txtInt_Caducidad.Text = ObjBien_Detalle.Int_CaducidadLicencia;
                                                    txtInt_Usuarios.Text = ObjBien_Detalle.Int_Usuarios;
                                                    txtInt_Capacidad.Text = ObjBien_Detalle.Tic_DiscoDuro;
                                                    txtInt_Version.Text = ObjBien_Detalle.Int_Version;
                                                    txtInt_Idioma.Text = ObjBien_Detalle.Int_Idioma;
                                                    txtInt_SO.Text = ObjBien_Detalle.Tic_SO;
                                                    TabIntangibles.Enabled = true;
                                                }
                                                else
                                                    if (ObjBien_Detalle.Formulario == 8)
                                                    {
                                                        TabPanelEnabled(ref TabColecciones, ref TabContBienes, (ObjBien_Detalle.Formulario - 1));
                                                        txtCol_Descripcion.Text = ObjBien_Detalle.Caracteristicas;
                                                        txtCol_Titulo.Text = ObjBien_Detalle.Col_Titulo;
                                                        txtCol_Autor.Text = ObjBien_Detalle.Col_Autor;
                                                        txtCol_Editorial.Text = ObjBien_Detalle.Col_Editorial;
                                                        txtCol_Tomos.Text = ObjBien_Detalle.Col_Tomos;
                                                        txtCol_Edicion.Text = ObjBien_Detalle.Col_Edicion;
                                                        txtCol_Titulo.Text = ObjBien_Detalle.Col_ISBN;
                                                        TabColecciones.Enabled = true;
                                                    }
                        //TabContBienes.Enabled = false;
                        if (ObjBien_Detalle.Tipo == "CONJUNTO")
                        {
                            CNBien.Obtener_Grid_Componentes(ref ObjBien_Detalle, ref ListaComponentes);
                            Session["ListaComponentes"] = ListaComponentes;

                            if (ListaComponentes.Count >= 1)
                                CargarGridComponentes(ListaComponentes);
                            linkBtnComponentes.Text = ListaComponentes.Count.ToString()+" componente(s) agregado(s) en el conjunto.";
                            linkBtnComponentes.Visible = true;
                          
                        }

                       
                        if (Code != "02721" )
                        {
                            if (ObjBien_Detalle.Validado)
                            {
                                TabContBienes.Enabled = false;
                                Campos_Editables(false);
                                EditarComponentes(false);
                            }
                            else
                            {
                                TabContBienes.Enabled = true;
                                Campos_Editables(true);
                                DDLProyecto.Enabled = false;
                                DDLFuente.Enabled = false;
                                EditarComponentes(true);
                            }
                        }
                    }
                    else
                    {
                        if (Code != "02721")
                            lblError.Text = "Ocurrió un problema al obtener los datos del resguardo. Comuníquese con su analista del Departamento de Patrimonio.";
                        else
                            //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un problema al cargar los datos: " + ex.Message + "');", true);
                            lblError.Text = "Ocurrió un problema: " + Verificador;
                    }
                }
                catch (Exception ex)
                {

                    if (Code != "02721")
                    {
                        lblError.Text = "Ocurrió un problema al obtener los datos del resguardo: "+ txtInventario.Text+". Comuníquese con su analista del Departamento de Patrimonio.";
                        MultiView1.ActiveViewIndex = 2;
                    }
                    else
                        //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un problema al cargar los datos: " + ex.Message + "');", true);
                        lblError.Text = ex.Message;
                   
                }
            }
        }
        protected void grvInventario_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int fila = e.RowIndex;
            if (grvInventario.Rows[fila].Cells[10].Text.ToUpper() == "TRUE")
            {
                string ruta = "../Reportes/VisualizadorCrystal_patrimonio.aspx?Tipo=RP-RESGUARDO&id=" + grvInventario.Rows[fila].Cells[0].Text;
                string _open = "window.open('" + ruta + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else
            {
                //lblMsj.Text = "El resguardo no se puede imprimir porque no ha sido validado.";
                //modalMensaje.Show();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'El resguardo no se puede imprimir porque no ha sido validado.');", true);
            }
        }
        protected void imgBttnPdf(object sender, ImageClickEventArgs e)
        {
            string ruta = "../Reportes/VisualizadorCrystal_patrimonio.aspx?Tipo=RP-109&status=" + DDLStatus.SelectedValue + "&dependencia=" + DDLDependencia.SelectedValue  + "&mes_inicial=" + txtFecha_Ini.Text + "&mes_final=" + txtFecha_Fin.Text + "&buscar=" + txtBuscar.Text;
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }
        protected void imgBttnExcel(object sender, ImageClickEventArgs e)
        {
            string ruta = "../Reportes/VisualizadorCrystal_patrimonio.aspx?Tipo=RP-109xls&dependencia=" + DDLDependencia.SelectedValue + "&status=" + DDLStatus.SelectedValue + "&mes_inicial=" + txtFecha_Ini.Text + "&mes_final=" + txtFecha_Fin.Text + "&buscar=" + txtBuscar.Text;
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }
        protected void imgbtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
                CargarGrid();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            
            //ListaComponentes = (List<Bien_Detalle>)Session["ListaComponentes"];
                try
                {
                    Bien_Detalle ObjBien_Detalle = new Bien_Detalle();
                    ObjBien_Detalle.Centro_Contable = HiddenCentro_Contable.Value;
                    ObjBien_Detalle.Dependencia = DDLDependencia.SelectedValue;
                    ObjBien_Detalle.SubDependencia = DDLContab.SelectedValue.Substring(11, 5);
                    ObjBien_Detalle.Ejercicio = Convert.ToInt32(HiddenEjercicio.Value);
                    ObjBien_Detalle.Fecha_Alta_Str = txtFecha_Alta.Text;
                    ObjBien_Detalle.Fecha_Contable_Str = txtFecha_Contable.Text;
                    ObjBien_Detalle.Fecha_Reclasificacion_Str = HiddenFechaReclasificacion.Value;
                    ObjBien_Detalle.Clave_Anterior = string.Empty;
                    ObjBien_Detalle.IdTipo_Alta = Convert.ToInt32(DDLTipo_Alta.SelectedValue);
                ObjBien_Detalle.Clasificacion = DDLClasificacion.SelectedValue;
                    ObjBien_Detalle.Poliza = DDLPoliza.SelectedValue;
                    
                    ObjBien_Detalle.Codigo_Contable = DDLContab.SelectedValue;
                    ObjBien_Detalle.Clave = DDLClave.SelectedValue;
                    ObjBien_Detalle.Reclasificado = "N";

                    ObjBien_Detalle.Cantidad = Convert.ToInt32(DDLCantidad.SelectedValue);
                    ObjBien_Detalle.Centro_Trabajo = DDLCentroTrabajo.SelectedValue;
                    if (SesionUsu.Editar == 1)
                    {
                        ObjBien_Detalle.No_Inventario = txtInventario.Text;
                        // Validando si es una reclasificación
                        if (DDLClave.SelectedItem.ToString().Substring(0, 8) != HiddenClave_Bien.Value && HiddenClave_Bien.Value != string.Empty)
                        {
                            ObjBien_Detalle.Fecha_Reclasificacion_Str = System.DateTime.Now.ToString("dd/MM/yyyy");
                            ObjBien_Detalle.Clave_Anterior = HiddenClave_Bien.Value;
                            ObjBien_Detalle.Fecha_Alta_Str = HiddenFecha_Alta.Value;
                            ObjBien_Detalle.Fecha_Contable_Str = txtFecha_Contable.Text;
                            ObjBien_Detalle.Reclasificado = "N";
                        }

                      
                            ObjBien_Detalle.Responsable = DDLResponsable.SelectedValue;
                            ObjBien_Detalle.Responsable_Nombre = DDLResponsable.SelectedItem.ToString();
                            
                }
                    else
                    {
                        ObjBien_Detalle.Responsable = DDLResponsable.SelectedValue;
                        ObjBien_Detalle.Responsable_Nombre = DDLResponsable.SelectedItem.ToString();
                    }

               
              

                if (DDLTipo_Alta.SelectedValue == "1057")
                {
                    ObjBien_Detalle.Cedula = string.Empty;
                    ObjBien_Detalle.Volante = txtVolante_Transferencia.Text.Trim().ToUpper();
                    ObjBien_Detalle.Inventario_Anterior = txtInv_Anterior.Text.Trim().ToUpper();
                    ObjBien_Detalle.Fecha_Alta_Ant_Str = txtAlta_Anterior.Text;
                    ObjBien_Detalle.Procedencia = txtProcedencia.Text.Trim().ToUpper();
                }
                else
                {
                    ObjBien_Detalle.Cedula = DDLCedula.SelectedValue;
                    ObjBien_Detalle.Procedencia = string.Empty;
                    ObjBien_Detalle.Volante = string.Empty;
                    ObjBien_Detalle.Inventario_Anterior = string.Empty;
                    ObjBien_Detalle.Fecha_Alta_Ant_Str = string.Empty;
                    ObjBien_Detalle.Fecha_Contable_Str = txtFecha_Contable.Text;
                }

                ObjBien_Detalle.Proyecto = DDLProyecto.SelectedValue;
                ObjBien_Detalle.Fuente_Financiamiento = DDLFuente.SelectedValue;
                ObjBien_Detalle.Corresponsable = txtCorresponsable.Text.ToUpper();
                    //ObjBien_Detalle.Proveedor = DDLProveedor.SelectedValue;
                    ObjBien_Detalle.Proveedor = txtProveedor.Text.ToUpper();
                    ObjBien_Detalle.Factura_Numero = txtFolio_Factura.Text.Trim().ToUpper();
                    ObjBien_Detalle.Factura_Fecha_Str = txtFecha_Factura.Text;
                    ObjBien_Detalle.Costo = Convert.ToDouble(txtCosto.Text);
                    ObjBien_Detalle.Descripcion = DDLClave.SelectedItem.ToString().Substring(11, DDLClave.SelectedItem.ToString().Length - 11);
                    ObjBien_Detalle.Observaciones = txtObservaciones.Text.Trim().ToUpper();
                    ObjBien_Detalle.Captura_Usuario = SesionUsu.Usu_Nombre;
                    if (chkResguardo.Checked)
                        ObjBien_Detalle.Resguardo = "S";
                    else
                        ObjBien_Detalle.Resguardo = "N";

                ObjBien_Detalle.Validado = chkValidado.Checked;
                //CAMPOS UTILIZADOS POR MAS DE UN TIPO DE BIEN
                    ObjBien_Detalle.Caracteristicas = string.Empty;
                    ObjBien_Detalle.Marca = string.Empty;
                    ObjBien_Detalle.Modelo = string.Empty;
                    ObjBien_Detalle.No_Serie = string.Empty;
                    ObjBien_Detalle.Color = string.Empty;
                    ObjBien_Detalle.Tic_DiscoDuro = string.Empty;
                    ObjBien_Detalle.Tic_SO = string.Empty;


                    //ObjBien_Detalle.Formulario = Convert.ToInt32(Formulario[DDLClave.SelectedIndex].EtiquetaDos);
                    ObjBien_Detalle.Formulario = TabContBienes.ActiveTabIndex + 1;
                    ObjBien_Detalle.Partida = DDLClave.SelectedItem.ToString().Substring(0, 5);
                    if (ObjBien_Detalle.Formulario == 1)
                    {
                        //MUEBLES
                        ObjBien_Detalle.Caracteristicas = txtM_Caracteristicas.Text;
                        ObjBien_Detalle.Marca = txtM_Marca.Text;
                        ObjBien_Detalle.Modelo = txtM_Modelo.Text;
                        ObjBien_Detalle.No_Serie = txtM_Serie.Text;
                        ObjBien_Detalle.Color = txtM_Color.Text;
                    }
                    else
                        if (ObjBien_Detalle.Formulario == 3)
                    {
                        //VEHICULOS
                        ObjBien_Detalle.Caracteristicas = txtVEH_Caracteristicas.Text;
                        ObjBien_Detalle.Marca = txtVEH_Marca.Text;
                        ObjBien_Detalle.Modelo = txtVEH_Modelo.Text;
                        ObjBien_Detalle.Color = txtVEH_Color.Text;
                        ObjBien_Detalle.No_Serie = txtVEH_Serie.Text;
                    }
                    else
                            if (ObjBien_Detalle.Formulario == 4)
                    {
                        //TIC
                        ObjBien_Detalle.Caracteristicas = txtTIC_Caracteristicas.Text;
                        ObjBien_Detalle.Marca = txtTIC_Marca.Text;
                        ObjBien_Detalle.Modelo = txtTIC_Modelo.Text;
                        ObjBien_Detalle.No_Serie = txtTIC_Serie.Text;
                        ObjBien_Detalle.Tic_DiscoDuro = txtTIC_DiscoDuro.Text;
                        //ObjBien_Detalle.Tic_SO = txtTIC_SO.Text;
                        ObjBien_Detalle.Tic_SO =string.Empty;
                }
                    else
                         if (ObjBien_Detalle.Formulario == 5)
                    {
                        //EQUIPOS
                        ObjBien_Detalle.Caracteristicas = txtEquipo_Caracteristicas.Text;
                        ObjBien_Detalle.Marca = txtEquipo_Marca.Text;
                        ObjBien_Detalle.Modelo = txtEquipo_Modelo.Text;
                        ObjBien_Detalle.No_Serie = txtEquipo_Serie.Text;
                        ObjBien_Detalle.Color = txtEquipo_Color.Text;
                    }
                    else
                                    if (ObjBien_Detalle.Formulario == 6)
                    {
                        //SEMOVIENTES

                        ObjBien_Detalle.Color = txtSem_Color.Text;
                    }
                    else if (ObjBien_Detalle.Formulario == 7)
                    {
                        //INTANGIBLES
                        ObjBien_Detalle.Caracteristicas = txtInt_Caracteristicas.Text;
                        ObjBien_Detalle.Marca = txtInt_Marca.Text;
                        ObjBien_Detalle.Tic_DiscoDuro = txtInt_Capacidad.Text;
                        ObjBien_Detalle.Tic_SO = txtInt_SO.Text;
                    }
                    else if (ObjBien_Detalle.Formulario == 8)
                        ObjBien_Detalle.Caracteristicas = txtCol_Descripcion.Text;

                    //INMUEBLES
                    ObjBien_Detalle.Inm_Direccion = txtINM_Direccion.Text;
                    ObjBien_Detalle.Inm_Ciudad = txtINM_Ciudad.Text;
                    ObjBien_Detalle.Inm_TipoDoc = txtINM_TipoDoc.Text;
                    ObjBien_Detalle.Inm_NumeroDoc = txtINM_NumeroDoc.Text;
                    ObjBien_Detalle.Inm_EstatusDoc = txtINM_EstatusDoc.Text;
                    ObjBien_Detalle.Inm_FechaDoc_Str = txtINM_FechaDoc.Text;
                    ObjBien_Detalle.Inm_NotariaPublica = txtINM_Notaria.Text;
                    ObjBien_Detalle.Inm_ExpedicionDoc = txtINM_LugarExpedicionDoc.Text;
                    ObjBien_Detalle.Inm_AvaluoTerreno = Convert.ToDouble(txtINM_Terreno.Text);
                    ObjBien_Detalle.Inm_AvaluoEdificio = Convert.ToDouble(txtINM_Edificio.Text);
                    ObjBien_Detalle.Inm_FechaAvaluo_Str = txtINM_FechaAvaluo.Text;

                    //VEHICULOS
                    ObjBien_Detalle.Veh_Año = txtVEH_Año.Text;
                    ObjBien_Detalle.Veh_NumeroMotor = txtVEH_Motor.Text;
                    ObjBien_Detalle.Veh_NumeroPlacas = txtVEH_Placas.Text;
                    ObjBien_Detalle.Veh_Tenencia = txtVEH_Tenencia.Text;
                    ObjBien_Detalle.Veh_PolizaSeguro = txtVEH_Poliza.Text;
                    ObjBien_Detalle.Veh_FechaVencimiento_Str = txtVEH_Seguro.Text;


                    //TIC
                    ObjBien_Detalle.Tic_Accesorios = txtTIC_Accesorios.Text;
                    ObjBien_Detalle.Tic_Procesador = txtTIC_Procesador.Text;
                    ObjBien_Detalle.Tic_RAM = txtTIC_RAM.Text;
                    ObjBien_Detalle.Tic_Disquete = string.Empty;
                    ObjBien_Detalle.Tic_UnidadOptica = string.Empty;

                //SEMOVIENTES
                ObjBien_Detalle.Sem_Raza = txtSem_Raza.Text;
                    ObjBien_Detalle.Sem_Arete = txtSem_Arete.Text;
                    ObjBien_Detalle.Sem_Edad = txtSem_Edad.Text;
                    ObjBien_Detalle.Sem_FechaNac_Str = txtSem_Nac.Text;
                    ObjBien_Detalle.Sem_Peso = txtSem_Peso.Text;
                    ObjBien_Detalle.Sem_CostoRevalorizado = Convert.ToDouble(txtSem_Revalorizado.Text);
                    ObjBien_Detalle.Sem_FechaRevalorizado_Str = txtSem_Fecha.Text;
                    ObjBien_Detalle.Sem_Sexo = DDLSexo.SelectedValue;

                    //INTANGIBLES
                    ObjBien_Detalle.Int_TipoSoftware = txtInt_Software.Text;
                    ObjBien_Detalle.Int_Patente = txtInt_Patente.Text;
                    ObjBien_Detalle.Int_DerechoAutor = txtInt_Derecho.Text;
                    ObjBien_Detalle.Int_CaducidadLicencia = txtInt_Caducidad.Text;
                    ObjBien_Detalle.Int_Usuarios = txtInt_Usuarios.Text;
                    ObjBien_Detalle.Int_Version = txtInt_Version.Text;
                    ObjBien_Detalle.Int_Idioma = txtInt_Idioma.Text;

                    //COLECCIONES
                    ObjBien_Detalle.Col_Titulo = txtCol_Titulo.Text;
                    ObjBien_Detalle.Col_Autor = txtCol_Autor.Text;
                    ObjBien_Detalle.Col_Editorial = txtCol_Editorial.Text;
                    ObjBien_Detalle.Col_Tomos = txtCol_Tomos.Text;
                    ObjBien_Detalle.Col_Edicion = txtCol_Edicion.Text;
                    ObjBien_Detalle.Col_ISBN = txtCol_Titulo.Text;

                Boolean PaginaValidada = true;
                if (Code != "02721" )
                {
                    //RFVProveedor.IsValid = true;
                    //RFVFolio_Factura.IsValid = true;
                    //RFVFecha_Factura.IsValid = true;
                    if (ObjBien_Detalle.Ejercicio >= 2015)
                    {
                        //Page.Validate("General");
                        if (ObjBien_Detalle.Formulario == 1)
                            Page.Validate("Muebles");
                        else if (ObjBien_Detalle.Formulario == 2)
                            Page.Validate("Inmuebles");
                        else if (ObjBien_Detalle.Formulario == 3)
                            Page.Validate("Vehiculos");
                        else if (ObjBien_Detalle.Formulario == 4)
                            Page.Validate("TIC");
                        else if (ObjBien_Detalle.Formulario == 5)
                            Page.Validate("Equipos");
                        else if (ObjBien_Detalle.Formulario == 6)
                            Page.Validate("Semovientes");
                        else if (ObjBien_Detalle.Formulario == 7)
                            Page.Validate("Intangibles");
                        else if (ObjBien_Detalle.Formulario == 8)
                            Page.Validate("Colecciones");

                        PaginaValidada = Page.IsValid;
                    }
                }
                
                    
                    if (PaginaValidada)
                    {
                        if (SesionUsu.Editar == 0)
                        {
                        ObjBien_Detalle.Fecha_Contable_Str = txtFecha_Contable.Text;
                        if (linkBtnComponentes.Visible == true)
                            {
                                     ListaComponentes = (List<Bien_Detalle>)Session["ListaComponentes"];
                                    if ( ListaComponentes!=null && ListaComponentes.Count > 0)
                                    {
                                        No_Inv = string.Empty;
                                        ObjBien_Detalle.Tipo = "CONJUNTO";
                                        CNBien.InsertarBien(ref ObjBien_Detalle, ref Verificador);
                                if (Verificador == "0")
                                {
                                    No_Inv  = ObjBien_Detalle.No_Inventario;
                                    CNBien.Insertar_Componente(ListaComponentes, ObjBien_Detalle, ref Verificador);
                                }
                                    }
                                else 
                                    modalComponentes.Show();
                            }
                            else
                            {
                            No_Inv = string.Empty;
                            ObjBien_Detalle.Tipo = "UNICO";
                            CNBien.InsertarBien(ref ObjBien_Detalle, ref Verificador);
                            No_Inv = ObjBien_Detalle.No_Inventario;
                            }
                        }
                        else if (SesionUsu.Editar == 1)
                            {
                            if (linkBtnComponentes.Visible == true)
                            {
                                ListaComponentes = (List<Bien_Detalle>)Session["ListaComponentes"];
                                if (ListaComponentes != null && ListaComponentes.Count > 0)
                                {
                                    ObjBien_Detalle.Id = Convert.ToInt32(grvInventario.SelectedRow.Cells[0].Text);
                                    CNBien.ActualizarBien(ref ObjBien_Detalle, ref Verificador);
                                    if (Verificador == "0")
                                    {
                                        string No_Inventario = lblInventario.Text;
                                        CNBien.Insertar_Componente(ListaComponentes, ObjBien_Detalle, ref Verificador);
                                    }
                                }
                                else
                                    modalComponentes.Show();
                            }
                            else
                            {
                                ObjBien_Detalle.Id = Convert.ToInt32(grvInventario.SelectedRow.Cells[0].Text);
                                CNBien.ActualizarBien(ref ObjBien_Detalle, ref Verificador);
                            }
                    }
                        if (Verificador != "0")
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Los datos no pudieron guardarse: " + Verificador + "');", true);
                    else
                        {
                        
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 1, 'El resguardo se guardó con el No. de inventario: " + ObjBien_Detalle.No_Inventario+"');", true);
                                Cancelar();
                                
                    }
                }

                }
                catch (Exception ex)
                {
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un problema al cargar los datos: " + ex.Message + "');", true);
                lblError.Text = ex.Message;
            }
            }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }
        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            Nuevo();
            HiddenEjercicio.Value = SesionUsu.Usu_Ejercicio;
            HiddenCentro_Contable.Value = Dependencias[DDLDependencia.SelectedIndex].EtiquetaDos;
            txtFecha_Alta.Text = System.DateTime.Now.ToString("dd/MM/") + SesionUsu.Usu_Ejercicio;
            txtFecha_Contable.Text = txtFecha_Alta.Text;

            //ELIMINA TIPO DE ALTA TRANSFERENCIA
            DDLTipo_Alta.SelectedValue = "1057";
            DDLTipo_Alta.Items.RemoveAt(DDLTipo_Alta.SelectedIndex);
            CargarCombosAlta(System.DateTime.Now);
            //DDLTipo_Alta.Items.Remove("1057");
        }

        protected void linkBtnComponentes_Click(object sender, EventArgs e)
        {
            modalComponentes.Show();
            //if (SesionUsu.Editar == 0)
                //EditarComponentes(true);
            //else
            //    EditarComponentes(false);
     
        }

        protected void linkBttnEliminar_Click(object sender, EventArgs e)
        {
                try
            {
                LinkButton cbi = (LinkButton)(sender);
                GridViewRow row = (GridViewRow)cbi.NamingContainer;
                grvInventario.SelectedIndex = row.RowIndex;
                if (grvInventario.SelectedRow.Cells[2].Text.Length == 10)
                {
                    Bien Obj_Bien = new Bien();
                    Obj_Bien.Id = Convert.ToInt32(grvInventario.SelectedRow.Cells[0].Text);
                    Obj_Bien.Captura_Usuario = SesionUsu.CUsuario;
                    Obj_Bien.No_Inventario = grvInventario.SelectedRow.Cells[2].Text;
                  
                    Verificador = string.Empty;

                    CNBien.EliminarBien(Obj_Bien, ref Verificador);

                    if (Verificador != "0")
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un problema al realizar la operación solicitada: " + Verificador + "');", true);
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "confirmacion('" + Verificador + "');", true);
                        CargarGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un problema al cargar los datos: " + ex.Message + "');", true);
                lblError.Text = ex.Message;
            }

        }
       

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            modalComponentes.Hide();
        }
        protected void grvComponentes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
                try
                {
                    int fila = e.RowIndex;
                    int pagina = grvComponentes.PageSize * grvComponentes.PageIndex;
                    fila = pagina + fila;
                    List<Bien_Detalle> ListaComponentes = new List<Bien_Detalle>();
                    ListaComponentes = (List<Bien_Detalle>)Session["ListaComponentes"];
                    ListaComponentes.RemoveAt(fila);
                    Session["ListaComponentes"] = ListaComponentes;
                    CargarGridComponentes(ListaComponentes);
                    //linkBtnComponentes.Text = ListaComponentes.Count.ToString() + " componente(s) agregado(s) al conjunto.";
                if (ListaComponentes.Count > 0)
                        btnGuardar.Enabled = true;
                    else
                        btnGuardar.Enabled = false;

                    modalComponentes.Show();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                
            }
        }
        protected void grvComponentes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvComponentes.PageIndex = 0;
            grvComponentes.PageIndex = e.NewPageIndex;
            ListaComponentes = (List<Bien_Detalle>)Session["ListaComponentes"];
            CargarGridComponentes(ListaComponentes);
        }

        protected void DDLTipo_Alta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLTipo_Alta.SelectedValue== "1057")
            {
                
                DDLCedula.Visible = false;
                pnlTransferencia.Visible = true;
            }
            else
            {
                DDLCedula.Visible = true;
                DDLCedula.Enabled = true;
                pnlTransferencia.Visible = false;
                
            }

            CNComun.LlenaCombo("pkg_patrimonio.obt_combo_proyectos", ref DDLProyecto, "p_ejercicio", "p_centro_contable", "p_poliza_numero", "p_cedula_numero", "p_tipo_alta", SesionUsu.Usu_Ejercicio, HiddenCentro_Contable.Value, "", DDLCedula.SelectedValue, DDLTipo_Alta.SelectedValue);
            CNComun.LlenaCombo("pkg_patrimonio.Obt_Combo_Fuente_Financiamient", ref DDLFuente, "p_ejercicio", "p_centro_contable", "p_poliza_numero", "p_cedula_numero", "p_proyecto", "p_tipo_alta", SesionUsu.Usu_Ejercicio, HiddenCentro_Contable.Value, "", "", "", DDLTipo_Alta.SelectedValue);
        }

        protected void chk_validado_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int ID;
                Boolean Status;
                Verificador = string.Empty;
                CheckBox cbi = (CheckBox)(sender);
                GridViewRow row = (GridViewRow)cbi.NamingContainer;
                grvInventario.SelectedIndex = row.RowIndex;
               

               ID = Convert.ToInt32(grvInventario.SelectedRow.Cells[0].Text);
                Status = Convert.ToBoolean(grvInventario.SelectedRow.Cells[10].Text);

                CNBien.ActualizarStatusValidado(ref Verificador,ID, !Status);

                if (Verificador != "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un problema al cargar los datos: " + Verificador + "');", true);
                }
                CargarGrid();
            }
            catch (Exception ex)
            {
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un problema al cargar los datos: " + ex.Message + "');", true);
                lblError.Text = ex.Message;
                CargarGrid();
            }
        }

       
    }


    #endregion



}