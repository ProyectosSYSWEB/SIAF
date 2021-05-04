//MODIFICADO POR CARLOS EL 08FEBRERO2021
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEntidad;
using CapaNegocio;

namespace SAF.Presupuesto
{
    public partial class frmCedula : System.Web.UI.Page
    {

        #region <Variables>
        bool Adicional = false;
        Int32[] Celdas = new Int32[] { 0 };
        string Verificador = string.Empty;
        string VerificadorDet = string.Empty;
        CN_Usuario CNUsuario = new CN_Usuario();
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Pres_Documento CNDocumentos = new CN_Pres_Documento();
        CN_Pres_Documento_Det CNDocDet = new CN_Pres_Documento_Det();
        //Pres_Documento objDocumento = new Pres_Documento();
        //Pres_Documento_Detalle objDocumentoDet = new Pres_Documento_Detalle();
        private static List<Comun> ListConceptos = new List<Comun>();
        private static List<Pres_Documento_Detalle> ListDocDet = new List<Pres_Documento_Detalle>();
        private static List<Comun> Listcodigo = new List<Comun>();
        private static List<Comun> ListDependencia = new List<Comun>();
        private static List<Comun> ListPartida = new List<Comun>();
        
       
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                inicializar();              
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "COD_PROG", "Autocomplete();", true);
        }
        #region <Funciones y Sub>
        private void inicializar()
        {
            lblError.Text = string.Empty;
            try
            {
                
                MultiView1.ActiveViewIndex = 0;
                TabContainer1.ActiveTabIndex = 0;
                CargarCombos();
                grdDocumentos.DataSource = null;
                grdDocumentos.DataBind();                
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }
        private void LimpiarControles()
        {
            

            ddlevento.Enabled = true;
            txtCedula.Text = string.Empty;
            txtPoliza.Text = string.Empty;
            DDLCuenta_Banco.Visible = true;
            DDLCuenta_Banco.Enabled = true;
            lblcuenta.Visible = true;
            txtImporte_Operacion.Enabled = false;

            txtNumero_Cheque.Text = string.Empty;
            DateTime fechaIni = Convert.ToDateTime("01/" + ListDependencia[ddlDependencia.SelectedIndex].EtiquetaDos + "/" + SesionUsu.Usu_Ejercicio);
            DateTime fechaFin = Convert.ToDateTime("01/" + ListDependencia[ddlDependencia.SelectedIndex].EtiquetaDos + "/" + SesionUsu.Usu_Ejercicio);
            fechaFin = fechaFin.AddMonths(1).AddDays(-1);
            CalendarExtenderIni.StartDate = fechaIni;
            CalendarExtenderIni.EndDate = fechaFin;
            txtfechaDocumento.Text = fechaIni.ToString("dd/MM/yyyy");
            txtImporte_Operacion.Enabled = false;
            txtImporte_Operacion.Text = "0.00";
            txtImporteCheque.Text = "0.00";
            txtImporteISR.Text = "0.00";
            txtConcepto.Text = string.Empty;
            txtSeguimiento.Text = string.Empty;
            ddlFuente_F.Enabled = true;

           
            ddlStatusEnc.Visible = true;
            ddlStatusEnc.SelectedValue = "I";
            lblMsjCP.Text = string.Empty;
         
            /*Controles Detalle*/
            DateTime fecha = Convert.ToDateTime(txtfechaDocumento.Text);
            string MesFecha = fecha.ToString("MM");
            validadorStatus.ValidationGroup = "Guardar";
            ddlStatusEnc.Enabled = false;
            lblDisponible.Text = "0.00";
            lblDisponible.Text = "0.00";
            lblTotal_Origen.Text = "0.00";
            lblFormatoDisponible.Text = "0.00";
            lblFormatoTotal_Origen.Text = "0.00";
            txtImporteOrigen.Text = "0.00";
            txtConcepto.Text = string.Empty;
            txtDesPartida.Text = string.Empty;
            txtReferencia.Text = string.Empty;
            txtClaveBeneficiario.Text = string.Empty;
            txtBeneficiario.Text = string.Empty;


            ValidacionTipoEnc();
            grdDetalles.DataSource = null;
            grdDetalles.DataBind();
            lblError.Text = string.Empty;
        }
        private void Valida_Origen_Destino()
        {
            lblErrorDet.Text = string.Empty;
            try
            {
               
                    if (Convert.ToDouble(txtImporteOrigen.Text)> Convert.ToDouble(lblDisponible.Text))
                        lblErrorDet.Text = "El importe debe ser menor o igual al disponible.";
                    else
                    {
                        //int tot = (Convert.ToInt32(ddlMesFinalDet.SelectedValue) - Convert.ToInt32(ddlMesInicialDet.SelectedValue)) + 1;
                        //txtImporteMensual.Text = Convert.ToString((Convert.ToDouble(txtImporteOrigen.Text)+ (Convert.ToDouble(txtImporteDestino.Text))) / tot);
                    }
                
            }
            catch (Exception ex)
            {

                lblErrorDet.Text = ex.Message;
            }

        }
        
        
        private void CargarCombos()
        {
            try
            {
              
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref ddlDependencia, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, "C", ref ListDependencia);
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Status_Todos", ref ddlStatus,"p_supertipo","C");CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Eventos", ref ddlevento);
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Eventos", ref ddlEventos);
                //CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Tipo_Documento", ref ddlTipo, "p_supertipo", "C" );


            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        private void CargarCombosAdicionales()
        {
            try
            {
                if (Session["CargarAdicional"] != null)
                    Adicional = (bool)Session["CargarAdicional"];

                if (Adicional == true)
                {
                    CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Eventos", ref ddlevento);
                    ddlevento.Items.RemoveAt(0);
                    ddlevento_SelectedIndexChanged(null, null);
                    CNComun.LlenaCombo("PKG_PRESUPUESTO.Obt_Combo_Fuente_F", ref ddlFuente_F, "p_ejercicio", "p_dependencia", SesionUsu.Usu_Ejercicio, ddlDependencia.SelectedValue);
                    ConsultarLiteralFuncion();
                    string Literal = (String)Session["LiteralCedula"];
                    CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Capitulo", ref ddlCapitulo, "p_nivel", "p_clave_evento", "1", ddlevento.SelectedValue);
                    CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Status_Usuario", ref ddlStatusEnc, "p_tipo_usuario", "p_supertipo", SesionUsu.Usu_TipoUsu, "C");
                    CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Tipo_Documento", ref ddlTipoEnc, "p_supertipo", "C");
                    CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Cheque_Cuenta", ref DDLCuenta_Banco, "p_ejercicio", "p_centro_contable", "PARAMETRO", SesionUsu.Usu_Ejercicio, ddlDependencia.SelectedValue, Literal);
                }
                else
                {
                    CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Eventos", ref ddlevento);
                    ddlevento.Items.RemoveAt(0);
                    ddlevento_SelectedIndexChanged(null, null);
                    CNComun.LlenaCombo("PKG_PRESUPUESTO.Obt_Combo_Fuente_F", ref ddlFuente_F, "p_ejercicio", "p_dependencia", SesionUsu.Usu_Ejercicio, ddlDependencia.SelectedValue);
                    CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Capitulo", ref ddlCapitulo, "p_nivel", "p_clave_evento", "1", ddlevento.SelectedValue);
                    CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Status_Usuario", ref ddlStatusEnc, "p_tipo_usuario", "p_supertipo", SesionUsu.Usu_TipoUsu, "C");
                    CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Tipo_Documento", ref ddlTipoEnc, "p_supertipo", "C");
                    CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Cheque_Cuenta", ref DDLCuenta_Banco, "p_ejercicio", "p_centro_contable", SesionUsu.Usu_Ejercicio, ddlDependencia.SelectedValue);
                }
                
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        private void ValidacionTipoEnc()
        {             
                    ddlTipoEnc.Enabled = false;
                    ddlTipoEnc.SelectedValue = "CC";
                    lblcuenta.Visible = true;
                    DDLCuenta_Banco.Visible = true;
        }
        private void ValidacionTipoDet()
        {
              
                lblLeyTotal_Origen.Text = "TOTAL";
        }
        
        private void CargarGridDetalle(List<Pres_Documento_Detalle> ListDocDet)
        {
            lblError.Text = string.Empty;
            try
            {
               
                 grdDetalles.DataSource = ListDocDet;
                grdDetalles.DataBind();
                Sumatoria(grdDetalles);
                txtImporte_Operacion.Text = lblTotal_Origen.Text;

                if (ddlevento.SelectedValue == "10" || ddlevento.SelectedValue == "98")
                    Celdas = new Int32[] { 1,2,3,  4,10,12,13,14,15,16,17,18,20 };
                else
                    Celdas = new Int32[] { 1, 2,3,  4,10,12, 13, 14, 15, 16, 17,18 };

                if (grdDetalles.Rows.Count > 0)
                {
                    ddlTipoEnc.Enabled = false;
                    ddlevento.Enabled = false;
                    ddlFuente_F.Enabled = false;
                    DDLCuenta_Banco.Enabled = false;
                    CNComun.HideColumns(grdDetalles, Celdas);
                    lblFF.Text = grdDetalles.Rows[0].Cells[4].Text.Substring(25, 5);
                }
                else
                {
                    ddlTipoEnc.Enabled = false;
                    ddlStatusEnc.Enabled = false;
                    ddlevento.Enabled = true;
                    ddlFuente_F.Enabled = true;
                    DDLCuenta_Banco.Enabled = true;
                    lblFF.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        private void Sumatoria(GridView grdView)
        {
            lblTotal_Origen.Text = string.Empty;
            
            decimal Origen = 0;
            decimal Destino = 0;
            Origen = grdView.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[15].Text));
            Destino = grdView.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[16].Text));
            lblTotal_Origen.Text = String.Format("{0:0.00}", Convert.ToDouble(Origen));//Convert.ToString(Origen); // String.Format("{0:c}", Convert.ToDouble(cargos));
           
            lblFormatoTotal_Origen.Text = String.Format("{0:C}", Convert.ToDouble(Origen));           
        }
        private void GuardarDetalle(ref string Verificador, int Documento)
        {
            List<Pres_Documento_Detalle> ListaDetalle = new List<Pres_Documento_Detalle>();
            ListaDetalle = (List<Pres_Documento_Detalle>)Session["DocDet"];
            CNDocDet.DocumentoDetInsertar(ListaDetalle, Documento, ref Verificador);
        }
        private void CargarGrid(ref GridView grid, int idGrid)
        {
            lblError.Text = string.Empty;
            grid.DataSource = null;
            grid.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grid.DataSource = dt;
                grid.DataSource = GetList(idGrid);
                grid.DataBind();
                Celdas = new Int32[] { 0,9 };

                if (grid.Rows.Count > 0)
                {
                    CNComun.HideColumns(grid, Celdas);
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        private void guarda_encabezado(ref string VerificadorInserta, ref string Folio)
        {
            try
            {
                Pres_Documento objDocumento = new Pres_Documento();
                Verificador = string.Empty;
                objDocumento.CentroContable = "";
                objDocumento.Dependencia = ddlDependencia.SelectedValue;
                string fech = txtfechaDocumento.Text;
                objDocumento.Folio = fech.Substring(3, 2);
                objDocumento.Tipo = ddlTipoEnc.SelectedValue;
                objDocumento.SuperTipo = "C";
                objDocumento.Fecha = txtfechaDocumento.Text;
                objDocumento.MesAnio = fech.Substring(3, 2) + SesionUsu.Usu_Ejercicio.Substring(2, 2);
                objDocumento.TipoCaptura = "M";
                objDocumento.Status = ddlStatusEnc.SelectedValue;
                objDocumento.Descripcion = txtConcepto.Text;
                objDocumento.Importe_Cheque = Convert.ToDouble(txtImporteCheque.Text);
                objDocumento.Importe_Operacion = Convert.ToDouble(txtImporte_Operacion.Text);

              
                objDocumento.Seguimiento = txtSeguimiento.Text;                
                objDocumento.MotivoRechazo = "";
                objDocumento.MotivoAutorizacion = "";
                objDocumento.NumeroCheque = txtNumero_Cheque.Text;
                objDocumento.Contabilizar = "S";
                if (SesionUsu.Editar == 0)
                {
                    objDocumento.CedulaComprometido = "";// si es simultaneo folio y si no segun el tipo y los demas null
                    objDocumento.CedulaDevengado = "";    // si es simultaneo folio
                    objDocumento.CedulaEjercido = "";     // si es simultaneo folio
                    objDocumento.CedulaPagado = "";
                    objDocumento.ClaveCuenta = DDLCuenta_Banco.SelectedValue;
                    objDocumento.Cuenta = DDLCuenta_Banco.SelectedValue;
                }
                    else
                {
                    objDocumento.CedulaComprometido = txtCedula.Text;// si es simultaneo folio y si no segun el tipo y los demas null
                    objDocumento.CedulaDevengado = txtCedula.Text;    // si es simultaneo folio
                    objDocumento.CedulaEjercido = txtCedula.Text;     // si es simultaneo folio
                    objDocumento.CedulaPagado = txtCedula.Text;       // si es simultaneo folio
                    objDocumento.ClaveCuenta = (String)Session["CuentaBanco"];
                    objDocumento.Cuenta = (String)Session["CuentaBanco"];
                }
                objDocumento.ISR = Convert.ToDouble(txtImporteISR.Text);
                objDocumento.KeyPoliza811 = "";
                objDocumento.Ejercicios = SesionUsu.Usu_Ejercicio;
                objDocumento.Regulariza = "N"; //rbtmovimiento.SelectedValue;
                objDocumento.Fecha_Final = "";
                objDocumento.GeneracionSimultanea = "S";
                objDocumento.Usuario = SesionUsu.Usu_Nombre;

                objDocumento.PolizaComprometida = txtPoliza.Text.ToUpper();
                objDocumento.PolizaDevengado = txtPoliza.Text.ToUpper(); ;
                objDocumento.PolizaEjercido = txtPoliza.Text.ToUpper(); ;
                objDocumento.PolizaPagado = txtPoliza.Text.ToUpper(); ;
                objDocumento.ClaveEvento = ddlevento.SelectedValue;
                objDocumento.KeyDocumento = "";
                objDocumento.KeyPoliza = "";

                if (SesionUsu.Editar == 0)
                {
                    CNDocumentos.InsertaDocumentoEncabezado(ref objDocumento, ref Verificador);
                    if (Verificador == "0")
                    {
                        VerificadorDet = string.Empty;
                        GuardarDetalle(ref VerificadorDet, Convert.ToInt32(objDocumento.Id));
                        if (VerificadorDet == "0")
                        {
                            Folio = objDocumento.Folio;
                            VerificadorInserta = "0";
                        }
                        else
                            VerificadorInserta = VerificadorDet;
                    }
                    else
                        VerificadorInserta = Verificador;
                }
                else
                {
                    objDocumento.Id = Convert.ToInt32(grdDocumentos.SelectedRow.Cells[0].Text);
                    CNDocumentos.EditarCedulaEncabezado(objDocumento, ref Verificador);
                    if (Verificador == "0")
                    {
                        VerificadorDet = string.Empty;
                        GuardarDetalle(ref VerificadorDet, Convert.ToInt32(grdDocumentos.SelectedRow.Cells[0].Text));
                        if (VerificadorDet == "0")
                        {

                            if (ddlStatusEnc.SelectedValue == "A")
                            {
                                Pres_Documento CedulasAdicionales = new Pres_Documento();
                                string VerificadorCedulasAdicionales = string.Empty;
                                CedulasAdicionales.Id = Convert.ToInt32(grdDocumentos.SelectedRow.Cells[0].Text);
                                CedulasAdicionales.ClaveEvento = objDocumento.ClaveEvento;
                                CNDocumentos.ConsultarCedulasAdicionales(ref CedulasAdicionales, ref VerificadorCedulasAdicionales);
                                if (VerificadorCedulasAdicionales == "0")
                                {
                                    GuardarDetalle(ref VerificadorCedulasAdicionales, Convert.ToInt32(CedulasAdicionales.CedulaDevengado));
                                    GuardarDetalle(ref VerificadorCedulasAdicionales, Convert.ToInt32(CedulasAdicionales.CedulaEjercido));
                                    GuardarDetalle(ref VerificadorCedulasAdicionales, Convert.ToInt32(CedulasAdicionales.CedulaPagado));
                                    if (VerificadorCedulasAdicionales == "0")
                                    {
                                        CedulasAdicionales.Id = Convert.ToInt32(grdDocumentos.SelectedRow.Cells[0].Text);
                                        CedulasAdicionales.ClaveEvento = objDocumento.ClaveEvento;
                                        if (CedulasAdicionales.ClaveEvento == "01" || CedulasAdicionales.ClaveEvento == "06")
                                            CNDocumentos.GenerarPoliza(ref CedulasAdicionales, ref VerificadorCedulasAdicionales);

                                        if (VerificadorCedulasAdicionales != "0")
                                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Error al generar la póliza automática: " + VerificadorCedulasAdicionales + "');", true);
                                    }
                                    else
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Error al guardar el detalle de las cédulas adicionales: " + VerificadorCedulasAdicionales + "');", true);

                                }
                                else
                                {
                                    VerificadorInserta = VerificadorCedulasAdicionales;
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Error al consultar  las cédulas adicionales: " + VerificadorCedulasAdicionales + "');", true);
                                }
                            }
                        }
                        else
                        {
                            VerificadorInserta = VerificadorDet;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Error al guardar el detalle de la cédula CC: " + VerificadorDet + "');", true); ;
                        }
                    }
                    else
                    {
                        VerificadorInserta = Verificador;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Error al guardar la cédula CC: " + Verificador + "');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                VerificadorInserta = ex.Message;
            }

        }
        protected void EditaRegistro(object sender, GridViewUpdateEventArgs e)
        {
            //List<Pres_Documento_Detalle> ListDocDet = new List<Pres_Documento_Detalle>();
            //ListDocDet = (List<Pres_Documento_Detalle>)Session["DocDet"];
            //GridViewRow row = grdDetalles.Rows[e.RowIndex];
            //ListDocDet[e.RowIndex].Importe_origen = Convert.ToDouble(((TextBox)(row.Cells[7].Controls[0])).Text);
            //ListDocDet[e.RowIndex].Importe_destino = Convert.ToDouble(((TextBox)(row.Cells[8].Controls[0])).Text);
            //grdDetalles.EditIndex = -1;
            //Session["DocDet"] = ListDocDet;
            //CargarGridDetalle(ListDocDet);
        }
        private void disponible()
        {
            lblError.Text = string.Empty;
            lblDisponible.Text = "0.00";
            lblFormatoDisponible.Text = "0.00";
            try
            {
                Pres_Documento_Detalle objDocDet = new Pres_Documento_Detalle();
                objDocDet.Id_Codigo_Prog = Convert.ToInt32(ddlCodigoProg.SelectedValue);
                objDocDet.SuperTipo = "C";
                objDocDet.Tipo = ddlevento.SelectedValue;
                objDocDet.Mes_inicial = Convert.ToInt32(txtfechaDocumento.Text.Substring(3,2));
                objDocDet.Ejercicios = SesionUsu.Usu_Ejercicio;

                CNDocDet.ObtDisponibleCodigoProg(objDocDet, ref Verificador);
                if (Verificador == "0")
                {
                    lblDisponible.Text = Convert.ToString(objDocDet.Importe_disponible);
                    lblFormatoDisponible.Text = string.Format("{0:c}", Convert.ToDouble(objDocDet.Importe_disponible));
                }
            }

            catch (Exception ex)
            {
                //lblError.Text = "No tiene código programático";
                //lblDisponible.Text  = "0";


            }
        }
        private List<Pres_Documento> GetList(int IdGrid)
        {
            try
            {
                Pres_Documento objDocumento = new Pres_Documento();
                List<Pres_Documento> List = new List<Pres_Documento>();
                objDocumento.Usuario= SesionUsu.Usu_Nombre;
                objDocumento.Ejercicios = SesionUsu.Usu_Ejercicio;
                objDocumento.Dependencia = ddlDependencia.SelectedValue;
                objDocumento.Fecha_Inicial = ddlMesIni.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2,2);
                objDocumento.Fecha_Final = ddlMesFin.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2);
                objDocumento.ClaveEvento = ddlEventos.SelectedValue; //EVENTO
                objDocumento.SuperTipo = "C";
                objDocumento.Tipo = ddlTipoCedula.SelectedValue;
                objDocumento.Status = ddlStatus.SelectedValue;
                objDocumento.P_Buscar = txtbuscar.Text;
                if(SesionUsu.Usu_TipoUsu=="SA")
                    objDocumento.Editor = "1";
                else
                    objDocumento.Editor = "0";

                if (IdGrid == 0)
                {
                    CNDocumentos.ConsultaGrid_Documentos(ref objDocumento, ref List);
                }
                else
                {

                    //objDocumento.ID = Convert.ToInt32(grg.SelectedRow.Cells[0].Text);
                    //CNDocumentos.ConsultaGrid(ref objDocumento, ref List);
                }

                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void ConsultarLiteralFuncion()
        {
            try
            {
                Pres_Documento objDocumento = new Pres_Documento();
                string Verificador = string.Empty;
                objDocumento.Id_Funcion = ddlFuente_F.SelectedValue;
                objDocumento.Ejercicios = SesionUsu.Usu_Ejercicio;
                CNDocumentos.ConsultarLiteralFuncion(ref objDocumento, ref Verificador);
                Session["LiteralCedula"] = objDocumento.Literal;

            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Error : " + ex.Message + "');", true);
            }
        }


        #endregion

        #region <Botones y Eventos>
        protected void LinkBEliminar_Click(object sender, EventArgs e)
        {

        }
        protected void LinkBImprimir_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdDocumentos.SelectedIndex = row.RowIndex;
            string ruta1 = string.Empty;
          
                    ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-002&id=" + grdDocumentos.SelectedRow.Cells[0].Text;
            string _open1 = "window.open('" + ruta1 + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }
        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CargarGrid(ref grdDocumentos, 0);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        protected void grdDocumentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            lblMsjCP.Text = string.Empty;
            validadorStatus.ValidationGroup = "Guardar";
            Session["DocDet"] = null;
            Pres_Documento objDocumento = new Pres_Documento();
            Pres_Documento_Detalle objDocumentoDet = new Pres_Documento_Detalle();

            string Status = string.Empty;
            try
            {
                Session["CargarAdicional"] = false;
                CargarCombosAdicionales();
                
                objDocumento.Id =Convert.ToInt32(grdDocumentos.SelectedRow.Cells[0].Text);
                CNDocumentos.ConsultarDocumentoSel(ref objDocumento, ref Verificador);
                if (Verificador == "0")
                {
                    grdDetalles.DataSource = null;
                    grdDetalles.DataBind();
                    /*Inicializa controles para editar*/
                    SesionUsu.Editar = 1;
                    //CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Status_Usuario", ref ddlStatusEnc, "p_tipo_usuario", "p_supertipo", SesionUsu.Usu_TipoUsu, "C");                    
                    ddlStatusEnc.Enabled = true;
                    ddlTipoEnc.Enabled = false;
                    ddlevento.Enabled = false;
                    ddlDependencia.SelectedValue = objDocumento.Dependencia;
                    ddlFuente_F.SelectedValue = objDocumento.Fuente;
                    txtCedula.Text = objDocumento.Folio;
                    txtPoliza.Text = objDocumento.PolizaComprometida;
                    ddlTipoEnc.SelectedValue = objDocumento.Tipo;                    
                    txtfechaDocumento.Text = objDocumento.Fecha;
                    Status= objDocumento.Status;
                    if ( Status == "R" || Status == "I")
                    {
                        validadorStatus.ValidationGroup = string.Empty;
                                             
                        ddlStatusEnc.Visible = (Status == "A") ? false:true;
                        panel_detalle.Visible = true;
                        btnGuardar.Enabled = true  ;
                    }
                    else
                    {
                        ddlStatusEnc.SelectedValue = objDocumento.Status;
                        ddlStatusEnc.Visible = true;
                        panel_detalle.Visible = false;
                        btnGuardar.Enabled = false;
                    }                    
                        txtConcepto.Text = objDocumento.Descripcion;
                    txtSeguimiento.Text = objDocumento.Seguimiento;
                    if (objDocumento.ClaveEvento != "99" && objDocumento.Cuenta != "LA OPCIÓN NO CONTIENE DATOS")
                        DDLCuenta_Banco.SelectedValue = objDocumento.Cuenta;
                    Session["CuentaBanco"] = objDocumento.Cuenta;
                    ddlFuente_F.Visible = true;
                    DDLCuenta_Banco.Visible = true;
                    DDLCuenta_Banco.SelectedValue = objDocumento.Cuenta;
                    txtNumero_Cheque.Text = objDocumento.NumeroCheque;                                        
                    lblcuenta.Visible = true;
                    ddlevento.SelectedValue = objDocumento.ClaveEvento;
                    ddlevento_SelectedIndexChanged(null, null);
                    txtImporteCheque.Text = Convert.ToString(objDocumento.Importe_Cheque);
                    txtImporte_Operacion.Text = Convert.ToString(objDocumento.Importe_Operacion);
                    txtImporteISR.Text = Convert.ToString(objDocumento.ISR);
                    txtImporteOrigen.Text = "0.00";                    
                    objDocumentoDet.Id_Documento = Convert.ToInt32(grdDocumentos.SelectedRow.Cells[0].Text);
                    List<Pres_Documento_Detalle> ListDocDet = new List<Pres_Documento_Detalle>();
                    CNDocDet.DocumentoDetConsultaGrid(ref objDocumentoDet, ref ListDocDet);
                    
                    DataTable dt = new DataTable();
                    Session["DocDet"] = ListDocDet;
                    
                    CargarGridDetalle(ListDocDet);
                    SesionUsu.Editar = 1;
                    ddlFuente_F.SelectedValue = lblFF.Text;
                 
                    
                   
                    if (ddlStatusEnc.SelectedValue == "I" )
                    {
                        MultiView1.ActiveViewIndex = 1;
                        TabContainer1.ActiveTabIndex = 0;
                        btnGuardar.Enabled = true ;
                    }
                    else
                    { if (ddlStatusEnc.SelectedValue == "A")
                        {
                            //MultiView1.ActiveViewIndex = 2;
                            //txtNumero_Cedula_Act.Text = objDocumento.Folio;
                            //txtConcepto_Act.Text = objDocumento.Descripcion;
                            //txtSeguimiento_Act.Text = objDocumento.Seguimiento;
                            //txtNumero_Cheque_Act.Text = objDocumento.NumeroCheque;
                        }
                        else
                         btnGuardar.Enabled = false  ;
                    }
                }
            }
            catch (Exception ex)
            {
                string Msj = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Msj);               
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Msj + "');", true); //lblMsj.Text = ex.Message;
            }
        }
        
        
        
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            CNComun.Habilitar_controles(UpdatePanel1);
           
            btnGuardar.Enabled = true;
            ddlDependencia.Enabled = true;
            ddlTipoEnc.Enabled = true;
            ddlMesFin.SelectedValue = ddlMesIni.SelectedValue;
            ddlStatus.Enabled = true;
            MultiView1.ActiveViewIndex = 0;
            panel_detalle.Visible = false;
            txtbuscar.Text = string.Empty;
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Pres_Documento objDocumento = new Pres_Documento();
            lblErrorDet.Text = string.Empty;
            lblMsjCP.Text = string.Empty;
            string VerificadorInserta = string.Empty;
            string Folio = string.Empty;
            VerificadorInserta = "0";
            bool ImportePermitido = true;
            try
            {
                if (grdDetalles.Rows.Count > 0)
                {
                    if (ddlevento.SelectedValue == "06")
                    {
                      
                        Decimal importe_operacion = Convert.ToDecimal(txtImporte_Operacion.Text);
                        Decimal importe_isr = Convert.ToDecimal(txtImporteISR.Text);
                        Decimal importe_cheque = Convert.ToDecimal(txtImporteCheque.Text);
                        Decimal importe = importe_operacion - (importe_isr + importe_cheque);
                        if (importe==0)
                            ImportePermitido = true;
                        else
                            ImportePermitido = false;
                    }
                    
                      if(  ImportePermitido )
                    {
                            guarda_encabezado(ref VerificadorInserta, ref Folio);
                        if (VerificadorInserta == "0")
                        {
                            SesionUsu.Editar = -1;
                            MultiView1.ActiveViewIndex = 0;
                            ddlStatus.SelectedValue = ddlStatusEnc.SelectedValue;
                            CargarGrid(ref grdDocumentos, 0);
                            string MiMensaje = (Folio == string.Empty) ? "La cédula ha sido modificada correctamente." : "La cédula ha sido agregada correctamente, con el número de folio:" + Folio;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 1, '" + MiMensaje + "');", true);
                            ddlDependencia.Enabled = true;
                            panel_detalle.Visible = false;
                        }
                        else
                        {
                            CNComun.VerificaTextoMensajeError(ref VerificadorInserta);
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Error:" + VerificadorInserta + "');", true);

                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'El importe de operación no coincide con el importe cheque + importe ISR.');", true);
                    }
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'No se han agregado códigos programáticos.');", true);
                }
            }
            catch (Exception ex)
            {
                string Msj = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Msj);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Error:" + Msj + "');", true);
            }
        }
        protected void grdDocumentos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdDocumentos.PageIndex = 0;
            grdDocumentos.PageIndex = e.NewPageIndex;
            CargarGrid(ref grdDocumentos, 0);
        }
        

        protected void txtImporteDestino_TextChanged(object sender, EventArgs e)
        {
            //if (txtImporteDestino.Text == string.Empty)
            //    txtImporteDestino.Text = "0";

            //Valida_Origen_Destino();
        }
        
        protected void LstCodigoProg_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblFormatoDisponible.Text = string.Format("{0:c}", "0");
            lblDisponible.Text = "0"; //string.Empty;
            disponible();
            
        }
        protected void grdDetalles_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int fila = e.RowIndex;
                int pagina = grdDetalles.PageSize * grdDetalles.PageIndex;
                fila = pagina + fila;
                List<Pres_Documento_Detalle> ListDocDet = new List<Pres_Documento_Detalle>();
                ListDocDet = (List<Pres_Documento_Detalle>)Session["DocDet"];
                ListDocDet.RemoveAt(fila);
                Session["DocDet"] = ListDocDet;
                CargarGridDetalle(ListDocDet);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        protected void grdDetalles_RowEditing(object sender, GridViewEditEventArgs e)
        {
            
            //grdDetalles.EditIndex = e.NewEditIndex;
            //List<Pres_Documento_Detalle> ListDocDet = new List<Pres_Documento_Detalle>();
            //ListDocDet = (List<Pres_Documento_Detalle>)Session["DocDet"];
            //Session["DocDet"] = ListDocDet;
            //CargarGridDetalle(ListDocDet);

        }
        protected void grdDetalles_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //List<Pres_Documento_Detalle> ListDocDet = new List<Pres_Documento_Detalle>();
            //ListDocDet = (List<Pres_Documento_Detalle>)Session["DocDet"];
            //grdDetalles.EditIndex = -1;
            //CargarGridDetalle(ListDocDet);
        }
        protected void txtImporteOrigen_TextChanged(object sender, EventArgs e)
        {
            try
            { 
            if (txtImporteOrigen.Text == string.Empty)
                txtImporteOrigen.Text = "0";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
           }

        protected void linkBttnEditar_Click(object sender, EventArgs e)
        {

        }


        protected void imgBttnPDF_Click(object sender, ImageClickEventArgs e)
        {
            string ruta1 = string.Empty;
            ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-DOCUMENTOS&SuperTipo=" + "C" + "&Dependencia=" + ddlDependencia.SelectedValue + "&TipoDoc=" + "T" + "&Status=" + ddlStatus.SelectedValue + "&MesIni=" + ddlMesIni.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&MesFin=" + ddlMesFin.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&Ejercicio=" + SesionUsu.Usu_Ejercicio + "&Evento=" + ddlEventos.SelectedValue;
            string _open1 = "window.open('" + ruta1 + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }
        protected void imgBttnPDF_Lotes_Click(object sender, ImageClickEventArgs e)
        {
            string ruta1 = string.Empty;
            
                    ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-LoteC&Dependencia=" + ddlDependencia.SelectedValue + "&TipoDoc=" + "T" + "&Status=" + ddlStatus.SelectedValue + "&MesIni=" + ddlMesIni.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&MesFin=" + ddlMesFin.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&Ejercicio=" + SesionUsu.Usu_Ejercicio+"&Evento=" + ddlEventos.SelectedValue;
                   

            string _open1 = "window.open('" + ruta1 + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }
        
       
        protected void btnAgregarDet_Click(object sender, EventArgs e)
        {
            if (ddlCodigoProg.SelectedValue != "0")
            {
                lblErrorDet.Text = string.Empty;
                lblMsjCP.Text = string.Empty;
                ddlevento.Enabled = false;

                if (Convert.ToDouble(txtImporteOrigen.Text) == 0 || Convert.ToDouble(txtImporteOrigen.Text) > Convert.ToDouble(lblDisponible.Text))
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'El importe capturado no está permitido.');", true);
                else
                {
                    var content = new List<Pres_Documento_Detalle>();
                    Pres_Documento_Detalle Detalle = new Pres_Documento_Detalle();
                    List<Pres_Documento_Detalle> ListDocDet = new List<Pres_Documento_Detalle>();

                    if (Session["DocDet"] != null)
                    {
                        List<Pres_Documento_Detalle> ListDocDetBusca = new List<Pres_Documento_Detalle>();
                        ListDocDetBusca = (List<Pres_Documento_Detalle>)Session["DocDet"];
                        var filteredCodigosProg = from c in ListDocDetBusca //Anteriormente ListDocDet
                                                  where Convert.ToString(c.Id_Codigo_Prog) == ddlCodigoProg.SelectedValue//txtSearch.Text

                                                  select c;

                        content = filteredCodigosProg.ToList<Pres_Documento_Detalle>();
                    }
                    if (content.Count == 0)
                    {
                        Detalle.Id_Codigo_Prog = Convert.ToInt32(ddlCodigoProg.SelectedValue);
                        Detalle.Desc_Codigo_Prog = ddlCodigoProg.SelectedItem.Text.Substring(0, 34);
                    //Detalle.Ur_clave = ddlDependencia.SelectedValue;
                    Detalle.Ur_clave = ddlCodigoProg.SelectedItem.Text.Substring(8, 5);
                    Detalle.Tipo = "O";

                        Detalle.Mes_inicial = Convert.ToInt32(txtfechaDocumento.Text.Substring(3, 2));
                        Detalle.Mes_final = Convert.ToInt32(txtfechaDocumento.Text.Substring(3, 2));
                        Detalle.Cuenta_banco = DDLCuenta_Banco.SelectedValue;

                        Detalle.Importe_origen = Math.Abs(Convert.ToDouble(txtImporteOrigen.Text));
                        Detalle.Importe_destino = 0;
                        Detalle.Importe_mensual = Detalle.Importe_origen;
                        Detalle.Concepto = txtDesPartida.Text.ToUpper();
                        Detalle.TipoDocReferencia = ddlTipoDocReferencia.SelectedValue;
                        Detalle.Referencia = txtReferencia.Text;
                        Detalle.Beneficiario_tipo = DDLTipoBeneficiario.SelectedValue;
                        Detalle.Beneficiario_clave = txtClaveBeneficiario.Text;
                        Detalle.Beneficiario_nombre = txtBeneficiario.Text.ToUpper();

                        if (Session["DocDet"] == null)
                        {
                            ListDocDet = new List<Pres_Documento_Detalle>();
                            ListDocDet.Add(Detalle);
                        }
                        else
                        {
                            ListDocDet = (List<Pres_Documento_Detalle>)Session["DocDet"];
                            ListDocDet.Add(Detalle);
                        }

                    Session["DocDet"] = ListDocDet;
                    CargarGridDetalle(ListDocDet);
                    txtImporteOrigen.Text = "0.00";

                }
                    else
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'El código programático ya está capturado.');", true);
            }
            }
        }
        protected void ddlTipoEnc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidacionTipoDet();
        }
        protected void rbtOrigen_Destino_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
        {
            if (TabContainer1.ActiveTabIndex == 1)
            {
                Page.Validate("Guardar");
                if (Page.IsValid==false)
                    TabContainer1.ActiveTabIndex = 0;

            }
        }
        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            SesionUsu.Editar = 0;
            MultiView1.ActiveViewIndex = 1;
            TabContainer1.ActiveTabIndex = 0;
            Session["DocDet"] = null;
            Session["CargarAdicional"] = false;
            ddlDependencia.Enabled = false;
            panel_detalle.Visible = true;
            CargarCombosAdicionales();
            LimpiarControles();
            string LiteralCedula = (String)Session["LiteralCedula"];
            txtPoliza.Text = txtfechaDocumento.Text.Substring(3, 2) + LiteralCedula;

        }
        protected void DDLCentroContable_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //string MesAbierto = ListDependencia[ddlDependencia.SelectedIndex].EtiquetaDos.PadLeft(2, '0');
                //DateTime fechaIni = Convert.ToDateTime("01/" + MesAbierto + "/" + SesionUsu.Usu_Ejercicio);
                //DateTime fechaFin = Convert.ToDateTime("31/12/" + SesionUsu.Usu_Ejercicio);
                //CalendarExtenderIni.StartDate = fechaIni;
                //CalendarExtenderIni.EndDate = fechaFin;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }            
        }
        protected void DDLCapitulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Codigos_Progr", ref ddlCodigoProg, "p_ejercicio", "p_dependencia", "p_capitulo", "p_fuente","p_clave_evento", "p_grupo",SesionUsu.Usu_Ejercicio, ddlDependencia.SelectedValue, ddlCapitulo.SelectedValue.Substring(0, 1), ddlFuente_F.SelectedValue, ddlevento.SelectedValue, ddlGrupoCodigoProgramatico.SelectedValue, ref ListPartida);
                disponible();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
}
        protected void ddlGrupoCodigoProgramatico_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Codigos_Progr", ref ddlCodigoProg, "p_ejercicio", "p_dependencia", "p_capitulo", "p_fuente", "p_clave_evento", "p_grupo", SesionUsu.Usu_Ejercicio, ddlDependencia.SelectedValue, ddlCapitulo.SelectedValue.Substring(0, 1), ddlFuente_F.SelectedValue, ddlevento.SelectedValue, ddlGrupoCodigoProgramatico.SelectedValue, ref ListPartida);
                disponible();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        protected void DDLFuente_F_SelectedIndexChanged(object sender, EventArgs e)
        {

            CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Codigos_Progr", ref ddlCodigoProg, "p_ejercicio", "p_dependencia", "p_capitulo", "p_fuente", "p_clave_evento", "p_grupo", SesionUsu.Usu_Ejercicio, ddlDependencia.SelectedValue, ddlCapitulo.SelectedValue.Substring(0, 1), ddlFuente_F.SelectedValue, ddlevento.SelectedValue, ddlGrupoCodigoProgramatico.SelectedValue, ref ListPartida);
            disponible();
            ConsultarLiteralFuncion();
            string Literal = (String)Session["LiteralCedula"];
            CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Cheque_Cuenta", ref DDLCuenta_Banco, "p_ejercicio", "p_centro_contable", "PARAMETRO", SesionUsu.Usu_Ejercicio, ddlDependencia.SelectedValue, Literal);
            txtPoliza.Text = txtfechaDocumento.Text.Substring(3, 2) + Literal;
        }
        protected void imgBttnXLS_Click(object sender, ImageClickEventArgs e)
        {
            string ruta1 = string.Empty;
            ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-DOCUMENTOS_XLS&SuperTipo=" + "C" + "&Dependencia=" + ddlDependencia.SelectedValue + "&TipoDoc=" + "T" + "&Status=" + ddlStatus.SelectedValue + "&MesIni=" + ddlMesIni.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&MesFin=" + ddlMesFin.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&Ejercicio=" + SesionUsu.Usu_Ejercicio+ "&Evento=" + ddlEventos.SelectedValue;
            string _open1 = "window.open('" + ruta1 + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }
        #endregion

        protected void ddlevento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlevento.SelectedValue != "06")
                {
                    lblImporteISR.Visible = false;
                    txtImporteISR.Visible = false;
                    txtImporteCheque.Visible = false;
                    lblImporteCheque.Visible = false;
                    RFVImporteCheque.Enabled = false;
                    RFVImporteISR.Enabled = false;
                    txtImporteCheque.Text = "0.00";
                    txtImporteISR.Text = "0.00";
                }
                else
                {
                    lblImporteISR.Visible = true;
                    txtImporteISR.Visible = true;
                    txtImporteCheque.Visible = true;
                    lblImporteCheque.Visible = true;
                    RFVImporteCheque.Enabled = true;
                    RFVImporteISR.Enabled = true;
                    txtImporteCheque.Text = "0.00";
                    txtImporteISR.Text = "0.00";
                }
                if (ddlevento.SelectedValue == "10" || ddlevento.SelectedValue == "98")
                {
                    btnAgregarDet.Visible = false;
                    lblMesCedulaOrigen.Visible = true;
                    ddlMesCedulaOrigen.Visible = true;
                    lblCedulaOrigen.Visible = true;
                    ddlCedulaOrigen.Visible = true;


                    //DDLCuenta_Banco.Enabled = false;
                    //txtPoliza.Enabled = false;
                    //txtNumero_Cheque.Enabled = false;

                    CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Cedulas", ref ddlCedulaOrigen, "p_ejercicio", "p_dependencia", "p_mes", "p_clave_evento", SesionUsu.Usu_Ejercicio, ddlDependencia.SelectedValue, ddlMesCedulaOrigen.SelectedValue, ddlevento.SelectedValue);
                }
                else
                {
                    btnAgregarDet.Visible = true;
                    lblMesCedulaOrigen.Visible = false;
                    ddlMesCedulaOrigen.Visible = false;
                    lblCedulaOrigen.Visible = false;
                    ddlCedulaOrigen.Visible = false;

                    DDLCuenta_Banco.Enabled = true;
                    txtPoliza.Enabled = true;
                    txtNumero_Cheque.Enabled = true;

                }
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Capitulo", ref ddlCapitulo, "p_nivel", "p_clave_evento", "1", ddlevento.SelectedValue);
                DDLCapitulo_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {

            }
        }

        protected void grdDetalles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        protected void grdDocumentos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblError.Text = string.Empty;

            try
            {
                int fila = e.RowIndex;
                Pres_Documento objDocumento = new Pres_Documento();
                objDocumento.Id = Convert.ToInt32(grdDocumentos.Rows[fila].Cells[0].Text);
                CNDocumentos.EliminarDocumentoEncabezado(objDocumento, ref Verificador);
                if (Verificador == "0")
                    CargarGrid(ref grdDocumentos, 0);
                else
                    lblError.Text = Verificador;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void ddlMesCedulaOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Cedulas", ref ddlCedulaOrigen, "p_ejercicio", "p_dependencia", "p_mes","p_clave_evento", SesionUsu.Usu_Ejercicio,ddlDependencia.SelectedValue,ddlMesCedulaOrigen.SelectedValue, ddlevento.SelectedValue);
        }

        protected void ddlCedulaOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCedulaOrigen.SelectedValue!="000000")
            {
                try
                {
                    List<Pres_Documento_Detalle> ListDocDet = new List<Pres_Documento_Detalle>();
                    Pres_Documento_Detalle Detalle = new Pres_Documento_Detalle();
                    Pres_Documento Encabezado = new Pres_Documento();
                    string Resultado = "0";
                    Encabezado.Id = Convert.ToInt32(ddlCedulaOrigen.SelectedValue);
                    CNDocumentos.ConsultarDocumentoSel(ref Encabezado, ref Resultado);
                    if (Resultado == "0")
                    {
                        txtImporteCheque.Text = Convert.ToString(Encabezado.Importe_Cheque);
                        txtImporte_Operacion.Text = Convert.ToString(Encabezado.Importe_Operacion);
                        txtImporteISR.Text = Convert.ToString(Encabezado.ISR);
                        DDLCuenta_Banco.SelectedValue = Encabezado.Cuenta;
                        txtPoliza.Text = Encabezado.PolizaComprometida;
                        txtNumero_Cheque.Text = Encabezado.NumeroCheque;

                        Detalle.Id_Documento = Convert.ToInt32(ddlCedulaOrigen.SelectedValue);
                        CNDocDet.DocumentoDetConsultaGrid(ref Detalle, ref ListDocDet);
                        if (Resultado != "0")
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Error al recuperar el detalle de la cédula.');", true);
                        

                        DataTable dt = new DataTable();
                        Session["DocDet"] = ListDocDet;
                        CargarGridDetalle(ListDocDet);
                    }
                    else
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Error al recuperar encabezado de la cédula.');", true);

                }
                catch (Exception ex)
                {
                }
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelarEdicion_Click(object sender, EventArgs e)
        {

        }
    }
}