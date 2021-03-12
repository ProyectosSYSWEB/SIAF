//MODIFICADO POR CARLOS EL 08FEBRERO2021
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEntidad;
using CapaNegocio;
using System.Web.UI.DataVisualization.Charting;

namespace SAF.Presupuesto
{
    public partial class frmCedula : System.Web.UI.Page
    {

        #region <Variables>
        Int32[] Celdas = new Int32[] { 0 };
        string Verificador = string.Empty;
        string VerificadorDet = string.Empty;
        CN_Usuario CNUsuario = new CN_Usuario();
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_Pres_Documento CNDocumentos = new CN_Pres_Documento();
        CN_Pres_Documento_Det CNDocDet = new CN_Pres_Documento_Det();
        Pres_Documento objDocumento = new Pres_Documento();
        Pres_Documento_Detalle objDocumentoDet = new Pres_Documento_Detalle();
        private static List<Comun> ListConceptos = new List<Comun>();
        private static List<Pres_Documento_Detalle> ListDocDet = new List<Pres_Documento_Detalle>();
        private static List<Comun> Listcodigo = new List<Comun>(); //En tu declaración de variables
        private static List<Comun> ListDependencia = new List<Comun>();
        private static List<Comun> ListPartida = new List<Comun>();
        
        int honorarios = 1;
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
                SesionUsu.Usu_Rep = "C";
                               
                MultiView1.ActiveViewIndex = 0;
                TabContainer1.ActiveTabIndex = 0;
                //DateTime fechaIni = Convert.ToDateTime("01/01/" + SesionUsu.Usu_Ejercicio);
                //DateTime fechaFin = Convert.ToDateTime("31/12/" + SesionUsu.Usu_Ejercicio);
                //CalendarExtenderIni.StartDate = fechaIni;
                //CalendarExtenderIni.EndDate = fechaFin;
                cargarcombos();
                ValidacionTipoEnc();
                grdDocumentos.DataSource = null;
                grdDocumentos.DataBind();

                lblImporte_Operacion.Enabled = false;
                lblImporte_Operacion.Text = "0.00";
                txtImporteCheque.Text = "0.00";
                txtImporteISR.Text = "0.00";
                if (ddlevento.SelectedValue != "06")
                {
                    lblImporteISR.Visible = false;
                    txtImporteISR.Visible = false;
                    txtImporteCheque.Visible = false;
                    lblImporteCheque.Visible = false;
                    RFVImporteCheque.Enabled = false;
                    RFVImporteISR.Enabled = false;
                }
                else
                {
                    lblImporteISR.Visible = true;
                    txtImporteISR.Visible = true;
                    txtImporteCheque.Visible = true;
                    lblImporteCheque.Visible = true;
                    RFVImporteCheque.Enabled = true;
                    RFVImporteISR.Enabled = true;
                }


            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }
        private void LimpiarControles()
        {
            ddlevento.SelectedIndex = 0;
            ddlevento.Enabled = true;
            txtCedula.Text = string.Empty;
            txtPoliza.Text = string.Empty;
            DDLCuenta_Banco.Enabled = true;
            DDLCuenta_Banco.SelectedIndex = 0;
           
            txtNumero_Cheque.Text = string.Empty;
            DateTime fechaIni = Convert.ToDateTime("01/" + ListDependencia[ddlCentroContable.SelectedIndex].EtiquetaDos + "/" + SesionUsu.Usu_Ejercicio);
            DateTime fechaFin = Convert.ToDateTime("01/" + ListDependencia[ddlCentroContable.SelectedIndex].EtiquetaDos + "/" + SesionUsu.Usu_Ejercicio);
            fechaFin = fechaFin.AddMonths(1).AddDays(-1);
            CalendarExtenderIni.StartDate = fechaIni;
            CalendarExtenderIni.EndDate = fechaFin;
            //txtfechaDocumento.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            txtfechaDocumento.Text = fechaIni.ToString("dd/MM/yyyy");
            lblImporte_Operacion.Text = "0.00";
            txtImporteCheque.Text = "0.00";
            txtImporteISR.Text = "0.00";
            txtConcepto.Text = string.Empty;
            txtAutorizacion.Text = string.Empty;
            txtCancelacion.Text = string.Empty;
            txtSeguimiento.Text = string.Empty;
            ddlFuente_F.Enabled = true;
            CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Cheque_Cuenta", ref DDLCuenta_Banco, "p_ejercicio", "p_centro_contable", SesionUsu.Usu_Ejercicio, ddlCentroContable.SelectedValue);
           
            
            ddlTipoEnc.SelectedIndex = 0;
            ddlStatusEnc.Visible = true;
            ddlStatusEnc.SelectedValue = "I";
            lblMsjCP.Text = string.Empty;
            ddlStatusEnc_SelectedIndexChanged(null, null);
         
            /*Controles Detalle*/
            DateTime fecha = Convert.ToDateTime(txtfechaDocumento.Text);
            string MesFecha = fecha.ToString("MM");
            //ddlMesInicialDet.SelectedValue = MesFecha;
            //ddlMesFinalDet.SelectedValue = MesFecha;
            validadorStatus.ValidationGroup = "Guardar";
            ddlStatusEnc.Enabled = false;
            lblDisponible.Text = "0.00";
            lblDisponible.Text = "0.00";
            lblTotal_Origen.Text = "0.00";
            lblFormatoDisponible.Text = "0.00";
            lblFormatoTotal_Origen.Text = "0.00";
            txtImporteOrigen.Text = "0.00";
            lblImporte_Operacion.Text = "0.00";
            txtImporteCheque.Text = "0.00";

            ValidacionTipoEnc();
            //ddlMesFin.SelectedValue = System.DateTime.Now.ToString("MM");
            grdDetalles.DataSource = null;
            grdDetalles.DataBind();
            lblError.Text = string.Empty;
            ddlDepen_SelectedIndexChanged(null, null);
        }
        private void Valida_Origen_Destino()
        {
            lblErrorDet.Text = string.Empty;
            try
            {
                if (SesionUsu.Usu_Rep == "A")
                {
                    if (Convert.ToDouble(txtImporteOrigen.Text)> Convert.ToDouble(lblDisponible.Text))
                        lblErrorDet.Text = "El importe debe ser menor o igual al disponible.";
                    else
                    {
                        //int tot = (Convert.ToInt32(ddlMesFinalDet.SelectedValue) - Convert.ToInt32(ddlMesInicialDet.SelectedValue)) + 1;
                        //txtImporteMensual.Text = Convert.ToString((Convert.ToDouble(txtImporteOrigen.Text)+ (Convert.ToDouble(txtImporteDestino.Text))) / tot);
                    }
                }
            }
            catch (Exception ex)
            {

                lblErrorDet.Text = ex.Message;
            }

        }
        
        
        private void cargarcombos()
        {
            try
            {
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Capitulo", ref ddlCapitulo, "p_nivel", "1");
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Eventos", ref ddlevento);
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref ddlCentroContable, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, SesionUsu.Usu_Rep, ref ListDependencia);
                DDLCentroContable_SelectedIndexChanged(null, null);

                CNComun.LlenaCombo("PKG_PRESUPUESTO.Obt_Combo_Fuente_F", ref ddlFuente_F, "p_ejercicio", "p_dependencia", SesionUsu.Usu_Ejercicio, ddlDepen.SelectedValue);
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Status_Todos", ref ddlStatus,"p_supertipo","C");
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Status_Usuario", ref ddlStatusEnc, "p_tipo_usuario", "p_supertipo", SesionUsu.Usu_TipoUsu, "C");
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Tipo_Documento", ref ddlTipo, "p_supertipo", SesionUsu.Usu_Rep );
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Tipo_Documento", ref ddlTipoEnc, "p_supertipo", SesionUsu.Usu_Rep);                
               
               
               
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

            rbtdoc_simultaneo.SelectedValue = "N";
            rbtdoc_simultaneo.Visible = false;
            lbldoc_simultaneo.Visible = false;
          
                rbtOrigen_Destino.Visible = false;
                validadorTipo.ValidationGroup = string.Empty;
                rbtdoc_simultaneo.SelectedValue = "S";
                //lblMesInicialDet.Visible = false;
                //ddlMesInicialDet.Visible = false;
                lblLeyTotal_Origen.Text = "TOTAL";
        }
        private void StatusEnc(string Status)
        {
            lblAutorizacion.Visible = false;
            txtAutorizacion.Visible = false;
            lblCancelacion.Visible = false;
            txtCancelacion.Visible = false;
            txtAutorizacion.Text = string.Empty;

            if (Status == "A")
            {
                lblAutorizacion.Visible = true;
                txtAutorizacion.Visible = true;
                txtAutorizacion.Text = "AUTORIZÓ " + SesionUsu.Usu_Nombre + " EL DÍA " + DateTime.Now.ToString("dd/MM/yyyy");
            }
            else if (Status == "R")
            {
                lblAutorizacion.Visible = true;
                txtAutorizacion.Visible = true;
                lblCancelacion.Visible = true;
                txtCancelacion.Visible = true;
            }

        }
        private void CargarGridDetalle(List<Pres_Documento_Detalle> ListDocDet)
        {
            lblError.Text = string.Empty;
            try
            {
                grdDetalles.DataSource = ListDocDet;
                grdDetalles.DataBind();
                Sumatoria(grdDetalles);
                lblImporte_Operacion.Text = lblTotal_Origen.Text;

                Celdas = new Int32[] { 1,2, 3, 4, 8,9,11,12,13,14,15,16,17 };
                       
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
                    ddlTipoEnc.Enabled = true;
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
            Origen = grdView.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[14].Text));
            Destino = grdView.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[15].Text));
            lblTotal_Origen.Text = Convert.ToString(Origen); // String.Format("{0:c}", Convert.ToDouble(cargos));
            
            lblFormatoTotal_Origen.Text = String.Format("{0:C}", Convert.ToDouble(Origen));           
        }
        private void GuardarDetalle(ref string Verificador, int Documento)
        {
            ListDocDet = (List<Pres_Documento_Detalle>)Session["DocDet"];
            CNDocDet.DocumentoDetInsertar(ListDocDet, Documento, ref Verificador);
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
                Verificador = string.Empty;
                objDocumento.CentroContable = "";
                objDocumento.Dependencia = ddlCentroContable.SelectedValue;
                string fech = txtfechaDocumento.Text;
                objDocumento.Folio = fech.Substring(3, 2);
                objDocumento.SuperTipo = SesionUsu.Usu_Rep;
                objDocumento.Fecha = txtfechaDocumento.Text;
                objDocumento.MesAnio = fech.Substring(3, 2) + SesionUsu.Usu_Ejercicio.Substring(2, 2);
                objDocumento.TipoCaptura = "M";
                objDocumento.Status = ddlStatusEnc.SelectedValue;
                objDocumento.Descripcion = txtConcepto.Text;
                objDocumento.Importe_Cheque = Convert.ToDouble(txtImporteCheque.Text);
                objDocumento.Importe_Operacion = Convert.ToDouble(lblImporte_Operacion.Text);

                objDocumento.MotivoRechazo = txtCancelacion.Text;
                objDocumento.MotivoAutorizacion = txtAutorizacion.Text;
                objDocumento.Seguimiento = txtSeguimiento.Text;
                objDocumento.ClaveCuenta = DDLCuenta_Banco.SelectedValue; 
                objDocumento.Cuenta = DDLCuenta_Banco.SelectedValue;

                objDocumento.NumeroCheque = txtNumero_Cheque.Text;
                objDocumento.Contabilizar = "S";
                if (rbtdoc_simultaneo.SelectedValue == "S")
                {
                    objDocumento.CedulaComprometido = txtCedula.Text;// si es simultaneo folio y si no segun el tipo y los demas null
                    objDocumento.CedulaDevengado = txtCedula.Text;    // si es simultaneo folio
                    objDocumento.CedulaEjercido = txtCedula.Text;     // si es simultaneo folio
                    objDocumento.CedulaPagado = txtCedula.Text;       // si es simultaneo folio
                }
                else
                {
                    objDocumento.CedulaDevengado = "";
                    objDocumento.CedulaEjercido = "";
                    objDocumento.CedulaPagado = "";
                    objDocumento.CedulaComprometido = txtCedula.Text;// si es simultaneo folio y si no segun el tipo y los demas null
                }
                objDocumento.ISR = Convert.ToDouble(txtImporteISR.Text);
                objDocumento.KeyPoliza811 = "";
                objDocumento.Ejercicios = SesionUsu.Usu_Ejercicio;
                objDocumento.Regulariza = "N"; //rbtmovimiento.SelectedValue;
                objDocumento.Fecha_Final = "";
                objDocumento.GeneracionSimultanea = rbtdoc_simultaneo.SelectedValue;
                objDocumento.Usuario = SesionUsu.Usu_Nombre;
                objDocumento.PolizaComprometida = txtPoliza.Text;
                objDocumento.PolizaDevengado = txtPoliza.Text;
                objDocumento.PolizaEjercido = txtPoliza.Text;
                objDocumento.PolizaPagado = txtPoliza.Text;
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
                lblError.Text = ex.Message;
            }

        }
        protected void EditaRegistro(object sender, GridViewUpdateEventArgs e)
        {
            List<Pres_Documento_Detalle> ListDocDet = new List<Pres_Documento_Detalle>();
            ListDocDet = (List<Pres_Documento_Detalle>)Session["DocDet"];
            GridViewRow row = grdDetalles.Rows[e.RowIndex];
            ListDocDet[e.RowIndex].Importe_origen = Convert.ToDouble(((TextBox)(row.Cells[7].Controls[0])).Text);
            ListDocDet[e.RowIndex].Importe_destino = Convert.ToDouble(((TextBox)(row.Cells[8].Controls[0])).Text);
            grdDetalles.EditIndex = -1;
            Session["DocDet"] = ListDocDet;
            CargarGridDetalle(ListDocDet);
        }
        private void disponible()
        {
            lblError.Text = string.Empty;
            lblDisponible.Text = "0.00";
            lblFormatoDisponible.Text = "0.00";
            try
            {
                objDocumentoDet.Id_Codigo_Prog = Convert.ToInt32(ddlCodigoProg.SelectedValue);
                objDocumentoDet.SuperTipo = "C";
                objDocumentoDet.Tipo = ddlevento.SelectedValue;
                objDocumentoDet.Mes_inicial = Convert.ToInt32(txtfechaDocumento.Text.Substring(3,2));
                objDocumentoDet.Ejercicios = SesionUsu.Usu_Ejercicio;

                CNDocDet.ObtDisponibleCodigoProg(objDocumentoDet, ref Verificador);
                if (Verificador == "0")
                {
                    lblDisponible.Text = Convert.ToString(objDocumentoDet.Importe_disponible);
                    lblFormatoDisponible.Text = string.Format("{0:c}", Convert.ToDouble(objDocumentoDet.Importe_disponible));
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
                List<Pres_Documento> List = new List<Pres_Documento>();
                objDocumento.Usuario= SesionUsu.Usu_Nombre;
                objDocumento.Ejercicios = SesionUsu.Usu_Ejercicio;
                objDocumento.Dependencia = ddlCentroContable.SelectedValue;
                objDocumento.Fecha_Inicial = ddlMesIni.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2,2);
                objDocumento.Fecha_Final = ddlMesFin.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2);
                objDocumento.Tipo = ddlTipo.SelectedValue;
                objDocumento.SuperTipo = SesionUsu.Usu_Rep;
                objDocumento.Status = ddlStatus.SelectedValue;
                objDocumento.P_Buscar = txtbuscar.Text;

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
            //lblStatusEnc.Text = string.Empty;
            validadorStatus.ValidationGroup = "Guardar";
            //CNComun.Limpiador_controles(UpdatePanel1);
            
            string Status = string.Empty;
            try
            {
                objDocumento.Id =Convert.ToInt32(grdDocumentos.SelectedRow.Cells[0].Text);
                CNDocumentos.ConsultarDocumentoSel(ref objDocumento, ref Verificador);
                if (Verificador == "0")
                {
                    ddlDepen.SelectedValue = ddlCentroContable.SelectedValue;
                    Session["DocDet"] = null;
                    grdDetalles.DataSource = null;
                    grdDetalles.DataBind();
                    /*Inicializa controles para editar*/
                    SesionUsu.Editar = 1;
                    CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Status_Usuario", ref ddlStatusEnc, "p_tipo_usuario", "p_supertipo", SesionUsu.Usu_TipoUsu, "C");
                    //lblMesIni.Visible = false;
                    //lblMesFin.Visible = false;
                    //ddlMesFin.Visible = false;
                    //ddlMesIni.Visible = false;                    
                    ddlStatusEnc.Enabled = true;
                    ddlTipoEnc.Enabled = false;
                    ddlevento.Enabled = false;
                    ddlCentroContable.SelectedValue = objDocumento.Dependencia;
                    ddlDepen.SelectedValue = objDocumento.Dependencia;
                    ddlDepen_SelectedIndexChanged(null, null);
                   

                    txtCedula.Text = objDocumento.Folio;
                    txtPoliza.Text = objDocumento.PolizaComprometida;
                    ddlTipoEnc.SelectedValue = objDocumento.Tipo;
                    //ValidacionTipoDet();
                    txtfechaDocumento.Text = objDocumento.Fecha;
                    Status= objDocumento.Status;
                    if ( Status == "R" || Status == "I")
                    {
                        validadorStatus.ValidationGroup = string.Empty;
                        //lblStatusEnc.Text = (Status == "A")?"Autorizado":"Rechazado";                                                
                        StatusEnc(Status);
                        ddlStatusEnc.Visible = (Status == "A") ? false:true;
                        penel_detalle.Visible = true;
                        //CNComun.Habilitar_controles(UpdatePanel1);
                        btnGuardar.Enabled = true  ;
                    }
                    else
                    {
                        ddlStatusEnc.SelectedValue = objDocumento.Status;
                        ddlStatusEnc_SelectedIndexChanged(null, null);
                        ddlStatusEnc.Visible = true;
                        penel_detalle.Visible = false;
                        //CNComun.Inhabilitar_controles(UpdatePanel1);
                        btnGuardar.Enabled = false;
                    }                    
                        txtConcepto.Text = objDocumento.Descripcion;
                    txtCancelacion.Text = objDocumento.MotivoRechazo;
                    txtAutorizacion.Text = objDocumento.MotivoAutorizacion;
                    txtSeguimiento.Enabled = false;
                    txtSeguimiento.Text = objDocumento.Seguimiento;
                    txtNumero_Cheque.Text = objDocumento.NumeroCheque;
                    DDLCuenta_Banco.SelectedValue= objDocumento.Cuenta;
                    ddlevento.SelectedValue = objDocumento.ClaveEvento;
                    txtImporteCheque.Text = Convert.ToString(objDocumento.Importe_Cheque);
                    lblImporte_Operacion.Text = Convert.ToString(objDocumento.Importe_Operacion);
                    txtImporteISR.Text = Convert.ToString(objDocumento.ISR);
                    //rbtmovimiento.SelectedValue = objDocumento.Regulariza;

                    rbtdoc_simultaneo.SelectedValue = objDocumento.GeneracionSimultanea;
                    //rdoBttnContabilizar.SelectedValue = objDocumento.Contabilizar;

                    /*Llena Grid Detalle*/
                    //ddlMesInicialDet.SelectedValue = "01";
                    //ddlMesFinalDet.SelectedValue = "01";
                    txtImporteOrigen.Text = "0.00";                    
                    //txtImporteDestino.Text = "0";
                    objDocumentoDet.Id_Documento = Convert.ToInt32(grdDocumentos.SelectedRow.Cells[0].Text);
                    List<Pres_Documento_Detalle> ListDocDet = new List<Pres_Documento_Detalle>();
                    CNDocDet.DocumentoDetConsultaGrid(ref objDocumentoDet, ref ListDocDet);
                   
                    if (ddlevento.SelectedValue != "06")
                    {
                        lblImporteISR.Visible = false;
                        txtImporteISR.Visible = false;
                        txtImporteCheque.Visible = false;
                        lblImporteCheque.Visible = false;
                    }
                    else
                    {

                        lblImporteISR.Visible = true;
                        txtImporteISR.Visible = true;
                        txtImporteCheque.Visible = true;
                        lblImporteCheque.Visible = true;
                        //txt_clave_beneficiario.Text = objDocumentoDet.Beneficiario_clave;
                        //txtBeneficiario.Text = objDocumentoDet.Beneficiario_nombre;
                        //txtReferencia.Text = objDocumentoDet.Referencia;
                        //txtDesPartida.Text = objDocumentoDet.Desc_Partida; 
                        //ddlDepen.SelectedValue = objDocumentoDet.Desc_Codigo_Prog.Substring(8,5);
                        //ddlCapitulo.SelectedValue= objDocumentoDet.Desc_Codigo_Prog.Substring(19, 1)+"000";
                        //ddlFuente_F.SelectedValue= objDocumentoDet.Desc_Codigo_Prog.Substring(25, 5);
                       
                    }
                    
                    DataTable dt = new DataTable();
                    Session["DocDet"] = ListDocDet;
                    CargarGridDetalle(ListDocDet);
                    SesionUsu.Editar = 1;
                    ddlFuente_F.SelectedValue = lblFF.Text;
                    MultiView1.ActiveViewIndex = 1;
                    TabContainer1.ActiveTabIndex = 0;
                   
                    if (ddlStatusEnc.SelectedValue=="R"|| ddlStatusEnc.SelectedValue == "I" )
                    {
                        
                        //CNComun.Habilitar_controles(UpdatePanel1);
                        btnGuardar.Enabled = true ;
                    }
                    else
                    { 
                        //CNComun.Inhabilitar_controles(UpdatePanel1);                       
                        btnGuardar.Enabled = false  ;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Error: " + ex.Message + "');", true);
                //lblError.Text = ex.Message;
            }
        }
        
        protected void ddlStatusEnc_SelectedIndexChanged(object sender, EventArgs e)
        {
            StatusEnc(ddlStatusEnc.SelectedValue);
        }
        protected void ddlMesIni_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlMesFin_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            //lblMesIni.Visible = true;
            //lblMesFin.Visible = true;
            //ddlMesFin.Visible = true;
            //ddlMesIni.Visible = true;
            //ddlTipo.Enabled = true;
            CNComun.Habilitar_controles(UpdatePanel1);
            btnGuardar.Enabled = true;
            ddlCentroContable.Enabled = true;
            ddlTipoEnc.Enabled = true;
            ddlMesFin.SelectedValue = ddlMesIni.SelectedValue;
            ddlStatus.Enabled = true;
            MultiView1.ActiveViewIndex = 0;
            penel_detalle.Visible = false;
            txtbuscar.Text = string.Empty;
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblErrorDet.Text = string.Empty;
            lblMsjCP.Text = string.Empty;
            string VerificadorInserta = string.Empty;
            string Folio = string.Empty;
            try
            {
                if (grdDetalles.Rows.Count > 0)
                {
                    if (ddlevento.SelectedValue == "06")
                    {
                        if (Convert.ToInt32(lblImporte_Operacion.Text) == Convert.ToInt32(txtImporteISR.Text) + Convert.ToInt32(txtImporteCheque.Text))
                        {
                            honorarios = 1;
                        }
                        else
                        {
                            honorarios = 0;
                        }

                    }
                    else
                    {
                        honorarios = 1;
                    }
                    if (honorarios == 1)
                    {
                        if (rbtdoc_simultaneo.SelectedValue == "S" && SesionUsu.Usu_Rep == "C" && SesionUsu.Editar == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                switch (i)
                                {
                                    case 0:
                                        objDocumento.Tipo = "CC";
                                        guarda_encabezado(ref VerificadorInserta, ref Folio);
                                        if (VerificadorInserta != "0")
                                            i = 4;
                                        break;
                                        //case 1:
                                        //    objDocumento.Tipo = "CD";
                                        //    guarda_encabezado(ref VerificadorInserta, ref Folio);
                                        //    if (VerificadorInserta != "0")
                                        //        i = 4;
                                        //    break;
                                        //case 2:
                                        //    if (ddlevento.SelectedValue != "09")
                                        //    {
                                        //        if (ddlevento.SelectedValue != "10")
                                        //        {
                                        //            objDocumento.Tipo = "CE";
                                        //        guarda_encabezado(ref VerificadorInserta, ref Folio);
                                        //        if (VerificadorInserta != "0")
                                        //            i = 4;
                                        //        }
                                        //    }

                                        //    break;
                                        //case 3:
                                        //    if (ddlevento.SelectedValue != "09")
                                        //    {
                                        //        if (ddlevento.SelectedValue != "10")
                                        //        {
                                        //            objDocumento.Tipo = "CP";
                                        //        guarda_encabezado(ref VerificadorInserta, ref Folio);
                                        //         if (VerificadorInserta != "0")
                                        //        i = 4;
                                        //        }
                                        //    }
                                        //    break;
                                }
                            }

                            if (VerificadorInserta != "0")
                                //lblErrorDet.Text = VerificadorInserta;
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Error: '"+ VerificadorInserta+");", true);

                            else
                            {
                                SesionUsu.Editar = -1;
                                ddlCentroContable.Enabled = true;
                                ddlTipoEnc.Enabled = true;
                                MultiView1.ActiveViewIndex = 0;
                                ddlStatus.SelectedValue = ddlStatusEnc.SelectedValue;
                                CargarGrid(ref grdDocumentos, 0);
                                //lblMesIni.Visible = true;
                                //ddlMesIni.Visible = true;
                                //lblMesFin.Visible = true;
                                //ddlMesFin.Visible = true;
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 1, 'La cédula ha sido agregada correctamente.');", true);
                                //lblError.Text = "Los datos han sido agregados correctamente.";
                            }
                        }
                        else
                        {

                            objDocumento.Tipo = ddlTipoEnc.SelectedValue;
                            VerificadorInserta = "0";
                            guarda_encabezado(ref VerificadorInserta, ref Folio);
                            if (VerificadorInserta != "0")
                                //lblErrorDet.Text = VerificadorInserta;
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Error: '" + VerificadorInserta + ");", true);
                            else
                            {
                                SesionUsu.Editar = -1;
                                MultiView1.ActiveViewIndex = 0;
                                ddlStatus.SelectedValue = ddlStatusEnc.SelectedValue;
                                CargarGrid(ref grdDocumentos, 0);
                                //lblMesIni.Visible = true;
                                //ddlMesIni.Visible = true;
                                //lblMesFin.Visible = true;
                                //ddlMesFin.Visible = true;
                                //lblError.Text = (Folio == string.Empty) ? "Los datos han sido modificados correctamente." : "Los datos han sido agregados correctamente, con el número de folio:" + Folio;
                                string MiMensaje= (Folio == string.Empty) ? "La cédula ha sido modificada correctamente." : "La cédula ha sido agregada correctamente, con el número de folio:" + Folio; 
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 1, '"+MiMensaje+"');", true);
                                ddlCentroContable.Enabled = true;
                                penel_detalle.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        //lblErrorDet.Text = "El importe de operación no coincide con el importe cheque + importe ISR.";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'El importe de operación no coincide con el importe cheque + importe ISR.');", true);
                    }
                }

                else
                {
                    //lblErrorDet.Text = "No se han agregado códigos programáticos.";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'No se han agregado códigos programáticos.');", true);
                }
            }
            catch (Exception ex)
            {
                lblErrorDet.Text = ex.Message;
            }
        }
        protected void grdDocumentos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdDocumentos.PageIndex = 0;
            grdDocumentos.PageIndex = e.NewPageIndex;
            CargarGrid(ref grdDocumentos, 0);
        }
        //protected void ddlFecha_Ini_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (txtImporteOrigen.Text != string.Empty)
        //        txtImporteDestino_TextChanged(null, null);
        //}
        protected void ddlDepen_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            Listcodigo.Clear();
            Session["Cod_Prog"] = null;
            try
            {
                ValidacionTipoDet();
                ListPartida.Clear();
                CNComun.LlenaCombo("PKG_PRESUPUESTO.Obt_Combo_Fuente_F", ref ddlFuente_F, "p_ejercicio", "p_dependencia", SesionUsu.Usu_Ejercicio, ddlDepen.SelectedValue);
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Codigos_Progr", ref ddlCodigoProg, "p_ejercicio", "p_dependencia","p_capitulo","p_fuente", SesionUsu.Usu_Ejercicio, ddlDepen.SelectedValue,ddlCapitulo.SelectedValue.Substring(0, 1), ddlFuente_F.SelectedValue, ref ListPartida);
                
                disponible();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        protected void imgBttnAgregarCP_Click(object sender, ImageClickEventArgs e)
        {
        }
        protected void txtImporteDestino_TextChanged(object sender, EventArgs e)
        {
            //if (txtImporteDestino.Text == string.Empty)
            //    txtImporteDestino.Text = "0";

            //Valida_Origen_Destino();
        }
        protected void ddlMesFinalDet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtImporteOrigen.Text != string.Empty)
                txtImporteDestino_TextChanged(null, null);
        }
        protected void LstCodigoProg_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblFormatoDisponible.Text = string.Format("{0:c}", "0");
            lblDisponible.Text = "0"; //string.Empty;
            disponible();
            //txtImporteDestino.Text = string.Empty;
            //string s = ddlCodigoProg.SelectedValue;
            //try
            //{
            //    txtImporteOrigen.Text = Listcodigo[ddlCodigoProg.SelectedIndex].EtiquetaDos;
            //}
            //catch (Exception ex)
            //{
            //    lblErrorDet.Text = ex.Message;
            //}
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
            
            grdDetalles.EditIndex = e.NewEditIndex;
            List<Pres_Documento_Detalle> ListDocDet = new List<Pres_Documento_Detalle>();
            ListDocDet = (List<Pres_Documento_Detalle>)Session["DocDet"];
            Session["DocDet"] = ListDocDet;
            CargarGridDetalle(ListDocDet);

        }
        protected void grdDetalles_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            List<Pres_Documento_Detalle> ListDocDet = new List<Pres_Documento_Detalle>();
            ListDocDet = (List<Pres_Documento_Detalle>)Session["DocDet"];
            grdDetalles.EditIndex = -1;
            CargarGridDetalle(ListDocDet);
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
            //Valida_Origen_Destino();
        }
        
        
        
        
        protected void imgBttnPDF_Click(object sender, ImageClickEventArgs e)
        {
            string ruta1 = string.Empty;
            ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-DOCUMENTOS&SuperTipo=" + SesionUsu.Usu_Rep + "&Dependencia=" + ddlCentroContable.SelectedValue + "&TipoDoc=" + ddlTipo.SelectedValue + "&Status=" + ddlStatus.SelectedValue + "&MesIni=" + ddlMesIni.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&MesFin=" + ddlMesFin.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&Ejercicio=" + SesionUsu.Usu_Ejercicio;
            string _open1 = "window.open('" + ruta1 + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }
        protected void imgBttnPDF_Lotes_Click(object sender, ImageClickEventArgs e)
        {
            string ruta1 = string.Empty;
            
                    ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-LoteC&Dependencia=" + ddlCentroContable.SelectedValue + "&TipoDoc=" + ddlTipo.SelectedValue + "&Status=" + ddlStatus.SelectedValue + "&MesIni=" + ddlMesIni.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&MesFin=" + ddlMesFin.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&Ejercicio=" + SesionUsu.Usu_Ejercicio;
                   

            string _open1 = "window.open('" + ruta1 + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }
        
       
        protected void btnAgregarDet_Click(object sender, EventArgs e)
        {
            lblErrorDet.Text = string.Empty;
            lblMsjCP.Text = string.Empty;
            ddlevento.Enabled = false;
            if (Convert.ToDouble(txtImporteOrigen.Text)==0 || Convert.ToDouble(txtImporteOrigen.Text) > Convert.ToDouble(lblDisponible.Text))
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'El importe capturado no está permitido.');", true);
            else
            {
                var content = new List<Pres_Documento_Detalle>();
                if (Session["DocDet"] != null)
                {
                    //string MesIni = Convert.ToString(Convert.ToInt32(ddlMesInicialDet.SelectedValue));
                    string MesIni = Convert.ToString(Convert.ToInt32(txtfechaDocumento.Text.Substring(3, 2)));
                    List<Pres_Documento_Detalle> ListDocDetBusca = new List<Pres_Documento_Detalle>();
                    ListDocDetBusca = (List<Pres_Documento_Detalle>)Session["DocDet"];
                    var filteredCodigosProg = from c in ListDocDetBusca
                                              where  Convert.ToString(c.Id_Codigo_Prog) == ddlCodigoProg.SelectedValue//txtSearch.Text
                                              
                                              select c;

                    content = filteredCodigosProg.ToList<Pres_Documento_Detalle>();
                }
                if (content.Count == 0)
                {
                    objDocumentoDet.Id_Codigo_Prog = Convert.ToInt32(ddlCodigoProg.SelectedValue);
                    objDocumentoDet.Desc_Codigo_Prog = ddlCodigoProg.SelectedItem.Text.Substring(0,34);
                    objDocumentoDet.Ur_clave = ddlDepen.SelectedValue;
                    objDocumentoDet.Tipo = "O";
                    //objDocumentoDet.Tipo = (SesionUsu.Usu_Rep != "C")? rbtOrigen_Destino.SelectedValue : ddlTipoEnc.SelectedValue.Substring(1);
                    //objDocumentoDet.Mes_inicial = Convert.ToInt32(ddlMesInicialDet.SelectedValue);
                    //objDocumentoDet.Mes_final = Convert.ToInt32(ddlMesInicialDet.SelectedValue);
                    objDocumentoDet.Mes_inicial = Convert.ToInt32(txtfechaDocumento.Text.Substring(3, 2));
                    objDocumentoDet.Mes_final = Convert.ToInt32(txtfechaDocumento.Text.Substring(3, 2));
                    objDocumentoDet.Cuenta_banco = DDLCuenta_Banco.SelectedValue;
                    //objDocumentoDet.Desc_Partida = ListPartida[ddlCodigoProg.SelectedIndex].EtiquetaCuatro;

                    objDocumentoDet.Importe_origen = Math.Abs(Convert.ToDouble(txtImporteOrigen.Text));
                    //if (ddlevento.SelectedValue == "98") //CANCELACION DE CEDULAS
                    //{
                    //    objDocumentoDet.Importe_origen = objDocumentoDet.Importe_origen * (-1);
                    //}
                    objDocumentoDet.Importe_destino = 0;
                    //objDocumentoDet.Importe_mensual = Convert.ToDouble(txtImporteOrigen.Text);
                    objDocumentoDet.Importe_mensual = objDocumentoDet.Importe_origen;

                    objDocumentoDet.Concepto  = txtDesPartida.Text.ToUpper();
                    objDocumentoDet.Referencia = txtReferencia.Text;
                    objDocumentoDet.Beneficiario_tipo = DDLTipoBeneficiario.SelectedValue;
                    objDocumentoDet.Beneficiario_clave  = txt_clave_beneficiario.Text;
                    objDocumentoDet.Beneficiario_nombre = txtBeneficiario.Text.ToUpper();

                    //if (SesionUsu.Usu_Rep=="A")
                    //{                        
                    //    if (rbtOrigen_Destino.SelectedValue == "D")
                    //    {
                    //        objDocumentoDet.Importe_origen = 0;
                    //        objDocumentoDet.Importe_destino = Convert.ToDouble(txtImporteOrigen.Text);
                    //    }
                    //    //objDocumentoDet.Mes_inicial = (ddlDepen.SelectedValue == "81101") ? 12 : Convert.ToInt32(ddlMesInicialDet.SelectedValue);
                    //    //objDocumentoDet.Mes_final = (ddlDepen.SelectedValue == "81101") ? 12 : Convert.ToInt32(ddlMesFinalDet.SelectedValue);
                    //    //int tot = (Convert.ToInt32(ddlMesFinalDet.SelectedValue) - Convert.ToInt32(ddlMesInicialDet.SelectedValue)) + 1;
                    //    objDocumentoDet.Mes_inicial = (ddlDepen.SelectedValue == "81101") ? 12 : Convert.ToInt32(txtfechaDocumento.Text.Substring(3, 2));
                    //    objDocumentoDet.Mes_final = (ddlDepen.SelectedValue == "81101") ? 12 : Convert.ToInt32(txtfechaDocumento.Text.Substring(3, 2));
                    //    int tot = Convert.ToInt32(txtfechaDocumento.Text.Substring(3, 2)) - Convert.ToInt32(txtfechaDocumento.Text.Substring(3, 2)) + 1;
                    //    objDocumentoDet.Importe_mensual = Convert.ToDouble((Convert.ToDouble(txtImporteOrigen.Text)) / tot);
                    //}


                    if (Session["DocDet"] == null)
                    {
                        ListDocDet = new List<Pres_Documento_Detalle>();
                        ListDocDet.Add(objDocumentoDet);
                    }
                    else
                    {
                        ListDocDet = (List<Pres_Documento_Detalle>)Session["DocDet"];
                        ListDocDet.Add(objDocumentoDet);
                    }
                    Session["DocDet"] = ListDocDet;
                    CargarGridDetalle(ListDocDet);
                    ddlTipoEnc.Enabled = false;
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'El código programático ya está capturado.');", true);
            }

        }
        protected void ddlTipoEnc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidacionTipoDet();
        }
        protected void rbtOrigen_Destino_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(ddlTipoEnc.SelectedValue== "0")

        }
        protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
        {
            if (TabContainer1.ActiveTabIndex == 1)
            {
                Page.Validate("Guardar");
                if (Page.IsValid==false)
                    TabContainer1.ActiveTabIndex = 0;
                else
                     if (ddlevento.SelectedValue == "97")//PAGO DE PASIVOS DE EJERCICIOS ANTERIORES
                        {
                            ddlCapitulo.SelectedValue = "9000";
                            
                            ddlCapitulo.Enabled = false;
                        }
                       else
                            ddlCapitulo.Enabled = true;

                DDLCapitulo_SelectedIndexChanged(null, null);
            }
        }
        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            SesionUsu.Editar = 0;
            MultiView1.ActiveViewIndex = 1;
            TabContainer1.ActiveTabIndex = 0;            
            Session["DocDet"] = null;
            ddlCentroContable.Enabled = false;
            penel_detalle.Visible = true;
            LimpiarControles();
        }
        protected void DDLCentroContable_SelectedIndexChanged(object sender, EventArgs e)
        {

            CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref ddlDepen, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, ddlCentroContable.SelectedValue);
            CNComun.LlenaCombo("PKG_PRESUPUESTO.Obt_Combo_Fuente_F", ref ddlFuente_F, "p_ejercicio", "p_dependencia", SesionUsu.Usu_Ejercicio, ddlDepen.SelectedValue);
            if (SesionUsu.Usu_TipoUsu == "A" || SesionUsu.Usu_TipoUsu == "SA")
            {
                string DepOriginal = ddlDepen.SelectedValue;
                ddlDepen.SelectedValue = "81101";
                ddlDepen.Items.RemoveAt(ddlDepen.SelectedIndex);
                ddlDepen.SelectedValue = DepOriginal;
                ddlDepen.SelectedIndex = 0;
            }

            try
            {
                string MesAbierto = ListDependencia[ddlCentroContable.SelectedIndex].EtiquetaDos.PadLeft(2, '0');
                DateTime fechaIni = Convert.ToDateTime("01/" + MesAbierto + "/" + SesionUsu.Usu_Ejercicio);
                DateTime fechaFin = Convert.ToDateTime("31/12/" + SesionUsu.Usu_Ejercicio);
                CalendarExtenderIni.StartDate = fechaIni;
                CalendarExtenderIni.EndDate = fechaFin;
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Cheque_Cuenta", ref DDLCuenta_Banco, "p_ejercicio", "p_centro_contable", SesionUsu.Usu_Ejercicio, ddlCentroContable.SelectedValue);


                
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
                //ddlDepen_SelectedIndexChanged(null, null);
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Codigos_Progr", ref ddlCodigoProg, "p_ejercicio", "p_dependencia", "p_capitulo", "p_fuente", SesionUsu.Usu_Ejercicio, ddlDepen.SelectedValue, ddlCapitulo.SelectedValue.Substring(0, 1), ddlFuente_F.SelectedValue, ref ListPartida);
                
                disponible();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
}
        protected void DDLFuente_F_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ddlDepen_SelectedIndexChanged(null, null);
            CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Codigos_Progr", ref ddlCodigoProg, "p_ejercicio", "p_dependencia", "p_capitulo", "p_fuente", SesionUsu.Usu_Ejercicio, ddlDepen.SelectedValue, ddlCapitulo.SelectedValue.Substring(0,1), ddlFuente_F.SelectedValue, ref ListPartida);
            
            disponible();
        }
        protected void imgBttnXLS_Click(object sender, ImageClickEventArgs e)
        {
            string ruta1 = string.Empty;
            ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-DOCUMENTOS_XLS&SuperTipo=" + SesionUsu.Usu_Rep + "&Dependencia=" + ddlCentroContable.SelectedValue + "&TipoDoc=" + ddlTipo.SelectedValue + "&Status=" + ddlStatus.SelectedValue + "&MesIni=" + ddlMesIni.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&MesFin=" + ddlMesFin.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&Ejercicio=" + SesionUsu.Usu_Ejercicio;
            string _open1 = "window.open('" + ruta1 + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }
        #endregion

        protected void ddlevento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCapitulo.SelectedIndex = 0;
           
            ddlCapitulo.Enabled = true;
            if (ddlevento.SelectedValue != "06")
            {
                lblImporteISR.Visible = false;
                txtImporteISR.Visible = false;
                txtImporteCheque.Visible = false;
                lblImporteCheque.Visible = false;
                RFVImporteCheque.Enabled = false;
                RFVImporteISR.Enabled = false;
               
            }
            else
            {
                lblImporteISR.Visible = true;
                txtImporteISR.Visible = true;
                txtImporteCheque.Visible = true ;
                lblImporteCheque.Visible = true ;
                RFVImporteCheque.Enabled = true;
                RFVImporteISR.Enabled = true;
            }
           
        }

        protected void DDLTipoBeneficiario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdDetalles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void linkBttnEditar_Click(object sender, EventArgs e)
        {

        }

        protected void grdDocumentos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblError.Text = string.Empty;
            try
            {
                int fila = e.RowIndex;
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

        protected void txtfechaDocumento_TextChanged(object sender, EventArgs e)
        {
            disponible();
        }
    }
}