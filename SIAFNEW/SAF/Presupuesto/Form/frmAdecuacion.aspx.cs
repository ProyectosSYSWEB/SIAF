using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEntidad;
using CapaNegocio;

namespace SAF.Presupuesto
{
    public partial class frmAdecuacion : System.Web.UI.Page
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
        

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                inicializar();              
            }
            


        }
        #region <Funciones y Sub>
        private void inicializar()
        {
            lblError.Text = string.Empty;
            try
            {
                SesionUsu.Usu_Rep = "A";
               
                MultiView1.ActiveViewIndex = 0;
                TabContainer1.ActiveTabIndex = 0;
                DateTime fechaIni = Convert.ToDateTime("01/01/" + SesionUsu.Usu_Ejercicio);
                DateTime fechaFin = Convert.ToDateTime("31/12/" + SesionUsu.Usu_Ejercicio);
                CalendarExtenderIni.StartDate = fechaIni;
                CalendarExtenderIni.EndDate = fechaFin;
                cargarcombos();
                ValidacionTipoEnc();
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

            //ddlStatus.SelectedValue = "I";
            //ddlStatus.Enabled = false;
            //rdoBttnContabilizar.SelectedValue = "N";
            txtfechaDocumento.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            txtfolio.Text = string.Empty;
            //rbtdoc_simultaneo.SelectedValue = "S";
            txtConcepto.Text = string.Empty;
            txtAutorizacion.Text = string.Empty;
            txtCancelacion.Text = string.Empty;
            ddlTipoEnc.SelectedValue = "AA";
            
            ddlStatusEnc.SelectedValue = "I";
            lblMsjCP.Text = string.Empty;
            lblfolio.Visible = false;
            txtfolio.Visible = false;
            txtfolio.Text = string.Empty;
            ddlStatusEnc_SelectedIndexChanged(null, null);
         
            /*Controles Detalle*/
            DateTime fecha = Convert.ToDateTime(txtfechaDocumento.Text);
            string MesFecha = fecha.ToString("MM");
            ddlMesInicialDet.SelectedValue = MesFecha;
            ddlMesFinalDet.SelectedValue = MesFecha;
            //ddlDepen.SelectedValue = ddlDependencia.SelectedValue;
            //ddlDepen_SelectedIndexChanged(null, null);
            validadorStatus.ValidationGroup = "Guardar";
            ddlStatusEnc.Enabled = true;
            lblDisponible.Text = "0";
            lblDisponible.Text = "0";
            lblTotal_Origen.Text = "0";
            lblTotal_Destino.Text = "0";
            lblFormatoDisponible.Text = "0";
            lblFormatoTotal_Origen.Text = "0";
            lblFormatoTotal_Destino.Text = "0";
            txtImporteOrigen.Text = "0";            
            ValidacionTipoEnc();
            ddlMesFin.SelectedValue = System.DateTime.Now.ToString("MM");
            grdDetalles.DataSource = null;
            grdDetalles.DataBind();
            lblError.Text = string.Empty;
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
        private void ocultar()
        {
            
            lblfolio.Visible = false;
            txtfolio.Visible = false;
            lbldoc_simultaneo.Visible = false;
            rbtdoc_simultaneo.Visible = false;
         }
        
        private void cargarcombos()
        {
            try
            {
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Capitulo", ref ddlCapitulo, "p_nivel", "1");
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Centro_Contable", ref ddlCentroContable, "p_usuario", "p_ejercicio", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio,ref ListDependencia);
                DDLCentroContable_SelectedIndexChanged(null, null);
                ddlDepen_SelectedIndexChanged(null, null);
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Status_Todos", ref ddlStatus);
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Status_Usuario", ref ddlStatusEnc, "p_tipo_usuario", "p_supertipo", SesionUsu.Usu_TipoUsu, "A");
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Tipo_Documento", ref ddlTipo, "p_supertipo", SesionUsu.Usu_Rep );
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Tipo_Documento", ref ddlTipoEnc, "p_supertipo", SesionUsu.Usu_Rep);
                
                //CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref ddlDepen, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, SesionUsu.Usu_Rep);
                ddlTipoEnc.Items.RemoveAt(0);
                //ddlTipoEnc.Items.Insert(0, new ListItem("--ELEGIR TIPO--", "0"));
               
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }
        private void ValidacionTipoEnc()
        {
                    lblMesInicialDet.Text = "Mes:";
                    lblMesFinalDet.Visible = false;
                    ddlMesFinalDet.Visible = false;
                    ocultar();
        }
        private void ValidacionTipoDet()
        {
            rbtdoc_simultaneo.SelectedValue = "N";
            rbtdoc_simultaneo.Visible = false;
            lbldoc_simultaneo.Visible = false;
            lblLeyTotal_Destino.Visible = true;
            lblFormatoTotal_Destino.Visible = true;
            lblLeyTotal_Origen.Text = "TOTAL ORIGEN";
            
            if (SesionUsu.Usu_Rep == "A")
            {
                validadorTipo.ValidationGroup = "GpoCodProg";
                if (ddlTipoEnc.SelectedValue == "AA")
                {
                    if (ddlDepen.SelectedValue != "81101")
                    {
                        lblMesInicialDet.Visible = true;
                        ddlMesInicialDet.Visible = true;
                        lblMesFinalDet.Visible = true;
                        ddlMesFinalDet.Visible = true;
                        rbtOrigen_Destino.SelectedValue = "D";
                        rbtOrigen_Destino.Enabled = false;
                    }
                    else
                    {
                        lblMesInicialDet.Visible = false;
                        ddlMesInicialDet.Visible = false;
                        lblMesFinalDet.Visible = false;
                        ddlMesFinalDet.Visible = false;
                        rbtOrigen_Destino.SelectedValue = "O";
                        rbtOrigen_Destino.Enabled = false;
                    }
                }

                else if (ddlTipoEnc.SelectedValue == "AR")
                {
                    lblMesFinalDet.Visible = true;
                    ddlMesFinalDet.Visible = true;
                    ddlMesInicialDet.Visible = true;
                    lblMesInicialDet.Visible = true;

                    if (ddlDepen.SelectedValue != "81101")
                    {
                        rbtOrigen_Destino.SelectedValue = "O";
                        rbtOrigen_Destino.Enabled = false;
                    }
                    else
                    {
                        ddlMesInicialDet.SelectedValue = "12";
                        ddlMesInicialDet.Visible = false;
                        lblMesInicialDet.Visible = false;
                        rbtOrigen_Destino.SelectedValue = "D";
                        rbtOrigen_Destino.Enabled = false;
                    }
                }
                else if (ddlTipoEnc.SelectedValue == "AC" || ddlTipoEnc.SelectedValue == "AP")
                {

                   
                        rbtOrigen_Destino.Enabled = true;
                    
                }
            }
            
        }
        private void StatusEnc(string Status)
        {
            lblAutorizacion.Visible = false;
            txtAutorizacion.Visible = false;
            lblCancelacion.Visible = false;
            txtCancelacion.Visible = false;


            if (Status == "A")
            {
                lblAutorizacion.Visible = true;
                txtAutorizacion.Visible = true;
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
                
                        Celdas = new Int32[] { 2, 3, 4, 8, 9, 10 };
                       
                if (grdDetalles.Rows.Count > 0)
                {
                    ddlTipoEnc.Enabled = false;
                    CNComun.HideColumns(grdDetalles, Celdas);
                }
                else
                {
                    ddlTipoEnc.Enabled = true;
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
            lblTotal_Destino.Text = string.Empty;
            decimal Origen = 0;
            decimal Destino = 0;
            Origen = grdView.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[9].Text));
            Destino = grdView.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[10].Text));
            lblTotal_Origen.Text = Convert.ToString(Origen); // String.Format("{0:c}", Convert.ToDouble(cargos));
            lblTotal_Destino.Text = Convert.ToString(Destino); //String.Format("{0:c}", Convert.ToDouble(abonos));
            lblFormatoTotal_Origen.Text = String.Format("{0:C}", Convert.ToDouble(Origen));
            lblFormatoTotal_Destino.Text = String.Format("{0:C}", Convert.ToDouble(Destino));
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
                
                if (SesionUsu.Usu_TipoUsu == "A")
                    Celdas = new Int32[] { 0, 10 };
                else
                    Celdas = new Int32[] { 0, 0 };
                if (grid.Rows.Count > 0)
                {
                    CNComun.HideColumns(grid , Celdas);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        private void guarda_encabezado(ref string VerificadorInserta, ref string Folio)
        {
            Verificador = string.Empty;
            objDocumento.CentroContable = "";
            objDocumento.Dependencia = ddlCentroContable.SelectedValue;
            objDocumento.Folio = txtfolio.Text;
            objDocumento.SuperTipo = SesionUsu.Usu_Rep;
            objDocumento.Fecha = txtfechaDocumento.Text;
            string fech = txtfechaDocumento.Text;
            objDocumento.MesAnio = fech.Substring(3, 2) + SesionUsu.Usu_Ejercicio.Substring(2, 2);
            objDocumento.TipoCaptura = "M";
            objDocumento.Status = ddlStatusEnc.SelectedValue;
            objDocumento.Descripcion = txtConcepto.Text;
            objDocumento.MotivoRechazo = txtCancelacion.Text;
            objDocumento.MotivoAutorizacion = txtAutorizacion.Text;
            objDocumento.Cuenta = string.Empty;
            objDocumento.NumeroCheque = "00000";
            objDocumento.Contabilizar = "S";
            if (rbtdoc_simultaneo.SelectedValue == "S")
            {
                objDocumento.CedulaComprometido = txtfolio.Text;// si es simultaneo folio y si no segun el tipo y los demas null
                objDocumento.CedulaDevengado = txtfolio.Text;    // si es simultaneo folio
                objDocumento.CedulaEjercido = txtfolio.Text;     // si es simultaneo folio
                objDocumento.CedulaPagado = txtfolio.Text;       // si es simultaneo folio
            }
            else
            {
                objDocumento.CedulaDevengado = "";
                objDocumento.CedulaEjercido = "";
                objDocumento.CedulaPagado = "";
                objDocumento.CedulaComprometido = txtfolio.Text;// si es simultaneo folio y si no segun el tipo y los demas null
            }
            objDocumento.KeyPoliza811 = "";
            objDocumento.Ejercicios = SesionUsu.Usu_Ejercicio;
            objDocumento.Regulariza = "N"; //rbtmovimiento.SelectedValue;
            objDocumento.Fecha_Final = "";
            objDocumento.GeneracionSimultanea = rbtdoc_simultaneo.SelectedValue;
            objDocumento.Usuario = SesionUsu.Usu_Nombre;

            objDocumento.PolizaComprometida = "";
            objDocumento.PolizaDevengado = "";
            objDocumento.PolizaEjercido = "";
            objDocumento.PolizaPagado = "";
            objDocumento.ClaveCuenta = "";
            objDocumento.ClaveEvento = "00";
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
                bool Modifica = true;
                if (objDocumento.Status == "A")
                    if (objDocumento.SuperTipo == "A")//Si es una Adecuación, valida los importes
                        if (lblFormatoTotal_Origen.Text != lblFormatoTotal_Destino.Text)
                            Modifica = false;

                if (Modifica)
                {
                    objDocumento.Id = Convert.ToInt32(grdDocumentos.SelectedRow.Cells[0].Text);
                    CNDocumentos.EditarDocumentoEncabezado(objDocumento, ref Verificador);
                    if (Verificador == "0")
                    {
                        VerificadorDet = string.Empty;
                        GuardarDetalle(ref VerificadorDet, Convert.ToInt32(grdDocumentos.SelectedRow.Cells[0].Text));
                        if (VerificadorDet == "0")
                        {
                            VerificadorInserta = "0";
                            //lblError.Text = "Los datos han sido actualizados correctamente";
                            //SesionUsu.Editar = -1;
                            //MultiView1.ActiveViewIndex = 0;
                            //CargarGrid(ref grdDocumentos, 0);
                        }
                        else
                            VerificadorInserta = VerificadorDet;
                    }
                    else
                        VerificadorInserta = Verificador;
                }
                else
                    VerificadorInserta = "Para cambiar el estatus a AUTORIZADO, el importe origen y destino deben ser iguales.";
            }

        }
        
        private void disponible()
        {
            lblError.Text = string.Empty;
            lblDisponible.Text = string.Empty;
            
            try
            {
                
                objDocumentoDet.Id_Codigo_Prog = Convert.ToInt32(ddlCodigoProg.SelectedValue);
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
           
                    ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-003&id=" + grdDocumentos.SelectedRow.Cells[0].Text;
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
            lblStatusEnc.Text = string.Empty;
            validadorStatus.ValidationGroup = "Guardar";
            string Status = string.Empty;
            
            string strEstatus = string.Empty;
            try
            {
                bool Editable = false;
                objDocumento.Id =Convert.ToInt32(grdDocumentos.SelectedRow.Cells[0].Text);
                strEstatus = grdDocumentos.SelectedRow.Cells[5].Text;
                if (SesionUsu.Usu_TipoUsu == "SA")
                    Editable = true;
                else
                {
                    if (SesionUsu.Usu_TipoUsu == "A")
                    {
                        if (strEstatus == "Tr&#225;mite")
                            Editable = true;
                    }
                    else
                    {
                        if (strEstatus != "Autorizado")
                            Editable = true;
                    }
                }
                 
                    if(Editable)
                        CNDocumentos.ConsultarDocumentoSel(ref objDocumento, ref Verificador);
                if (Verificador == "0")
                {
                    ddlDepen.SelectedValue = ddlCentroContable.SelectedValue;
                    Session["DocDet"] = null;
                    grdDetalles.DataSource = null;
                    grdDetalles.DataBind();


                    /*Inicializa controles para editar*/
                    SesionUsu.Editar = 1;
                        CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Status_Usuario", ref ddlStatusEnc, "p_tipo_usuario", "p_supertipo", SesionUsu.Usu_TipoUsu, "A");
                        ddlCentroContable.Enabled = true;
                   
                    ddlStatusEnc.Enabled = true;
                    ddlTipoEnc.Enabled = false;
                    
                    ddlCentroContable.SelectedValue = objDocumento.Dependencia;
                    ddlDepen.SelectedValue = objDocumento.Dependencia;
                    ddlDepen_SelectedIndexChanged(null, null);
                    lblfolio.Visible = true;
                    txtfolio.Visible = true;
                    txtfolio.Text = objDocumento.Folio;
                    ddlTipoEnc.SelectedValue = objDocumento.Tipo;
                    ValidacionTipoDet();
                    txtfechaDocumento.Text = objDocumento.Fecha;
                    Status= objDocumento.Status;
                    if (Status == "A" || Status == "R")
                    {
                        validadorStatus.ValidationGroup = string.Empty;
                        lblStatusEnc.Text = (Status == "A")?"Autorizado":"Rechazado";                                                
                        StatusEnc(Status);
                        ddlStatusEnc.Visible = (Status == "A") ? false:true;
                        btnGuardar.Visible = false;
                    }
                    else
                    {
                        ddlStatusEnc.SelectedValue = objDocumento.Status;
                        ddlStatusEnc_SelectedIndexChanged(null, null);
                        ddlStatusEnc.Visible = true;
                    }
                    txtConcepto.Text = objDocumento.Descripcion;
                    txtCancelacion.Text = objDocumento.MotivoRechazo;
                    txtAutorizacion.Text = objDocumento.MotivoAutorizacion;
                    rbtdoc_simultaneo.SelectedValue = objDocumento.GeneracionSimultanea;
                    

                    /*Llena Grid Detalle*/
                    ddlMesInicialDet.SelectedValue = "01";
                    ddlMesFinalDet.SelectedValue = "01";
                    txtImporteOrigen.Text = "0";
                    //txtImporteDestino.Text = "0";
                    objDocumentoDet.Id_Documento = Convert.ToInt32(grdDocumentos.SelectedRow.Cells[0].Text);
                    List<Pres_Documento_Detalle> ListDocDet = new List<Pres_Documento_Detalle>();
                    CNDocDet.DocumentoDetConsultaGrid(ref objDocumentoDet, ref ListDocDet);
                    DataTable dt = new DataTable();
                    Session["DocDet"] = ListDocDet;
                    CargarGridDetalle(ListDocDet);
                    SesionUsu.Editar = 1;


                    MultiView1.ActiveViewIndex = 1;
                    TabContainer1.ActiveTabIndex = 0;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
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
            
            ddlCentroContable.Enabled = true;
            ddlTipoEnc.Enabled = true;
            ddlStatus.Enabled = true;
            MultiView1.ActiveViewIndex = 0;
            
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
                   
                       
                            objDocumento.Tipo = ddlTipoEnc.SelectedValue;
                            guarda_encabezado(ref VerificadorInserta, ref Folio);
                            if (VerificadorInserta != "0")
                                lblErrorDet.Text = VerificadorInserta;
                            else
                            {
                                SesionUsu.Editar = -1;
                                MultiView1.ActiveViewIndex = 0;
                                ddlStatus.SelectedValue = ddlStatusEnc.SelectedValue;
                                CargarGrid(ref grdDocumentos, 0);
                                lblError.Text = (Folio == string.Empty) ? "Los datos han sido modificados correctamente." : "Los datos han sido agregados correctamente, con el número de folio:" + Folio;
                                ddlCentroContable.Enabled = true;
                            }
                    
                }
                else
                {
                    lblErrorDet.Text = "No se han agregado códigos programáticos.";
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
        protected void btnDisponible_Click(object sender, EventArgs e)
        {
            disponible();
        }
       
        
        protected void txtImporteOrigen_TextChanged(object sender, EventArgs e)
        {
            if (txtImporteOrigen.Text == string.Empty)
                txtImporteOrigen.Text = "0";

            //Valida_Origen_Destino();
        }
        
        protected void ddlMesInicialDet_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlMesFinalDet.SelectedValue = ddlMesInicialDet.SelectedValue;
            if (txtImporteOrigen.Text != string.Empty)
                txtImporteDestino_TextChanged(null, null);

        }
        protected void grdDocumentos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblError.Text = string.Empty;
            try
            {
                int fila = e.RowIndex;
                objDocumento.Id =Convert.ToInt32(grdDocumentos.Rows[fila].Cells[0].Text);
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
        protected void imgBttnPDF_Click(object sender, ImageClickEventArgs e)
        {
            string ruta1 = string.Empty;
            ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-DOCUMENTOS&SuperTipo=" + SesionUsu.Usu_Rep + "&Dependencia=" + ddlCentroContable.SelectedValue + "&TipoDoc=" + ddlTipo.SelectedValue + "&Status=" + ddlStatus.SelectedValue + "&MesIni=" + ddlMesIni.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&MesFin=" + ddlMesFin.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2);
            string _open1 = "window.open('" + ruta1 + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }
        protected void imgBttnPDF_Lotes_Click(object sender, ImageClickEventArgs e)
        {
            string ruta1 = string.Empty;
            
                    ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-LoteA&Dependencia=" + ddlCentroContable.SelectedValue + "&TipoDoc=" + ddlTipo.SelectedValue + "&Status=" + ddlStatus.SelectedValue + "&MesIni=" + ddlMesIni.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&MesFin=" + ddlMesFin.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2);
                    

            string _open1 = "window.open('" + ruta1 + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }
       
        protected void btnAgregarDet_Click(object sender, EventArgs e)
        {
            lblErrorDet.Text = string.Empty;
            lblMsjCP.Text = string.Empty;
            bool ImportePermitido = false;
            

            if (ddlTipoEnc.SelectedValue != "AA" && Convert.ToDouble(lblDisponible.Text) == 0) // && Convert.ToDouble(txtImporteOrigen.Text) > Convert.ToDouble(lblDisponible.Text))
                lblMsjCP.Text = lblMsjCP.Text + "*No hay saldo disponible.";
            else if (ddlTipoEnc.SelectedValue != "AA" && Convert.ToDouble(txtImporteOrigen.Text) > Convert.ToDouble(lblDisponible.Text))
                lblMsjCP.Text = lblMsjCP.Text + "*El importe debe ser menor o igual al disponible.";
            else if (ddlTipoEnc.SelectedValue == "AA")
                {
                if (SesionUsu.Usu_TipoUsu!="N" && Convert.ToDouble(txtImporteOrigen.Text) >= Convert.ToDouble(lblDisponible.Text))
                    lblMsjCP.Text = lblMsjCP.Text + "*El importe debe ser menor al disponible.";
                else
                    ImportePermitido = true;
            }
            else if (txtImporteOrigen.Text == "0")
                lblMsjCP.Text = lblMsjCP.Text + "*Agregar importe.";

            if (ImportePermitido)
            {
                var content = new List<Pres_Documento_Detalle>();
                if (Session["DocDet"] != null)
                {
                    string MesIni = Convert.ToString(Convert.ToInt32(ddlMesInicialDet.SelectedValue));
                    List<Pres_Documento_Detalle> ListDocDetBusca = new List<Pres_Documento_Detalle>();
                    ListDocDetBusca = (List<Pres_Documento_Detalle>)Session["DocDet"];
                    var filteredCodigosProg = from c in ListDocDet
                                              where c.Mes_inicial.ToString() == MesIni && c.Tipo == rbtOrigen_Destino.SelectedValue 
                                              && Convert.ToString(c.Id_Codigo_Prog) == ddlCodigoProg.SelectedValue//txtSearch.Text
                                              
                                              select c;

                    content = filteredCodigosProg.ToList<Pres_Documento_Detalle>();
                }
                if (content.Count == 0)
                {
                    objDocumentoDet.Id_Codigo_Prog = Convert.ToInt32(ddlCodigoProg.SelectedValue);
                    objDocumentoDet.Desc_Codigo_Prog = ddlCodigoProg.SelectedItem.Text;
                    objDocumentoDet.Ur_clave = ddlDepen.SelectedValue;
                    objDocumentoDet.Tipo = (SesionUsu.Usu_Rep != "C")? rbtOrigen_Destino.SelectedValue : ddlTipoEnc.SelectedValue.Substring(1);
                    objDocumentoDet.Mes_inicial = Convert.ToInt32(ddlMesInicialDet.SelectedValue);
                    objDocumentoDet.Cuenta_banco =  "";
                    objDocumentoDet.Desc_Partida = ListPartida[ddlCodigoProg.SelectedIndex].EtiquetaCuatro;
                    objDocumentoDet.Importe_origen = Convert.ToDouble(txtImporteOrigen.Text);
                    objDocumentoDet.Importe_destino = 0;
                    objDocumentoDet.Importe_mensual = Convert.ToDouble(txtImporteOrigen.Text);
                    objDocumentoDet.Mes_final = Convert.ToInt32(ddlMesInicialDet.SelectedValue);
                    
                                          
                        if (rbtOrigen_Destino.SelectedValue == "D")
                        {
                            objDocumentoDet.Importe_origen = 0;
                            objDocumentoDet.Importe_destino = Convert.ToDouble(txtImporteOrigen.Text);
                        }
                        objDocumentoDet.Mes_inicial = (ddlDepen.SelectedValue == "81101") ? 12 : Convert.ToInt32(ddlMesInicialDet.SelectedValue);
                        objDocumentoDet.Mes_final = (ddlDepen.SelectedValue == "81101") ? 12 : Convert.ToInt32(ddlMesFinalDet.SelectedValue);
                        int tot = (Convert.ToInt32(ddlMesFinalDet.SelectedValue) - Convert.ToInt32(ddlMesInicialDet.SelectedValue)) + 1;
                        objDocumentoDet.Importe_mensual = Convert.ToDouble((Convert.ToDouble(txtImporteOrigen.Text)) / tot);
                    

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
                    lblMsjCP.Text = "El mes ya se encuentra asignado.";
            }

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
            }
        }
        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            SesionUsu.Editar = 0;
            MultiView1.ActiveViewIndex = 1;
            TabContainer1.ActiveTabIndex = 0;            
            Session["DocDet"] = null;
            ddlCentroContable.Enabled = false;
            LimpiarControles();
            ValidacionTipoDet();
        }
        protected void ddlTipoEnc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidacionTipoDet();
        }
        protected void DDLCentroContable_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencia_x_Centro", ref ddlDepen, "p_centro_contable", "p_usuario", ddlCentroContable.SelectedValue, SesionUsu.Usu_Nombre);
            ddlDepen_SelectedIndexChanged(null, null);
            try
            {
               
                
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
            ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-DOCUMENTOS_XLS&SuperTipo=" + SesionUsu.Usu_Rep + "&Dependencia=" + ddlCentroContable.SelectedValue + "&TipoDoc=" + ddlTipo.SelectedValue + "&Status=" + ddlStatus.SelectedValue + "&MesIni=" + ddlMesIni.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&MesFin=" + ddlMesFin.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2);
            string _open1 = "window.open('" + ruta1 + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }
        #endregion

       
    }
}