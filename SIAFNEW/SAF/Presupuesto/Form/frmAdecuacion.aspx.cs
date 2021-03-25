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

            ScriptManager.RegisterStartupScript(this, GetType(), "COD_PROG", "Autocomplete();", true);

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
                lblFF.Text = string.Empty;
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
            DateTime fechaIni = Convert.ToDateTime("01/" + ListDependencia[ddlCentroContable.SelectedIndex].EtiquetaDos + "/" + SesionUsu.Usu_Ejercicio);
            DateTime fechaFin = Convert.ToDateTime("01/" + ListDependencia[ddlCentroContable.SelectedIndex].EtiquetaDos + "/" + SesionUsu.Usu_Ejercicio);
            fechaFin = fechaFin.AddMonths(1).AddDays(-1);
            CalendarExtenderIni.StartDate = fechaIni;
            CalendarExtenderIni.EndDate = fechaFin;
            //txtfechaDocumento.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            txtfechaDocumento.Text = fechaIni.ToString("dd/MM/yyyy");
            txtfolio.Text = string.Empty;
            //rbtdoc_simultaneo.SelectedValue = "S";
            txtConcepto.Text = string.Empty;
            txtAutorizacion.Text = string.Empty;
            txtCancelacion.Text = string.Empty;
            txtSeguimiento.Text = string.Empty;
            if (ddlTipo.SelectedValue != "T")
                ddlTipoEnc.SelectedValue = ddlTipo.SelectedValue;
            else
                ddlTipoEnc.SelectedIndex = 0;
            ddlTipoEnc_SelectedIndexChanged(null, null);
            //ddlStatusEnc.SelectedValue = "I";
            lblMsjCP.Text = string.Empty;
            lblfolio.Visible = false;
            txtfolio.Visible = false;
            txtfolio.Text = string.Empty;
            ddlTipoEnc.Enabled = true;
            ddlStatusEnc.SelectedIndex = 0;
            ddlStatusEnc_SelectedIndexChanged(null, null);
         
            /*Controles Detalle*/
            DateTime fecha = Convert.ToDateTime(txtfechaDocumento.Text);
            string MesFecha = fecha.ToString("MM");
            ddlMesInicialDet.SelectedValue = MesFecha;
            ddlMesFinalDet.SelectedValue = MesFecha;
            lblDependenciaDocumento.Text = string.Empty;
            //ddlDepen.SelectedValue = ddlDependencia.SelectedValue;
            //ddlDepen_SelectedIndexChanged(null, null);
            validadorStatus.ValidationGroup = "Guardar";
            ddlFuente_F.Enabled = true;
            ddlStatusEnc.Enabled = true;
            lblDisponible.Text = "0";
            lblDisponible.Text = "0";
            lblTotal_Origen.Text = "0";
            lblTotal_Destino.Text = "0";
            lblFormatoDisponible.Text = "0";
            lblFormatoTotal_Origen.Text = "0";
            lblFormatoTotal_Destino.Text = "0";
            txtImporteOrigen.Text = "0.00";            
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
                        //lblErrorDet.Text = "El importe debe ser menor o igual al disponible.";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'El importe debe ser menor o igual al disponible.');", true);
                    else
                    {
                        //int tot = (Convert.ToInt32(ddlMesFinalDet.SelectedValue) - Convert.ToInt32(ddlMesInicialDet.SelectedValue)) + 1;
                        //txtImporteMensual.Text = Convert.ToString((Convert.ToDouble(txtImporteOrigen.Text)+ (Convert.ToDouble(txtImporteDestino.Text))) / tot);
                    }
                }
            }
            catch (Exception ex)
            {

                //lblErrorDet.Text = ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Error: '"+ ex.Message+");", true);
            }

        }
        private void ocultar()
        {
            
            lblfolio.Visible = false;
            txtfolio.Visible = false;
            
         }
        
        private void cargarcombos()
        {
            try
            {
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Capitulo", ref ddlCapitulo, "p_nivel", "1");
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref ddlCentroContable, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, SesionUsu.Usu_Rep, ref ListDependencia);
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
                    lblMesInicialDet.Text = "Mes inicial";
                    lblMesFinalDet.Visible = false;
                    ddlMesFinalDet.Visible = false;
                   
                    ocultar();
        }
        private void ValidacionTipoDet()
        {
           
            lblMesInicialDet.Text = "Mes inicial";
            lblMesFinalDet.Visible = true;
            ddlMesFinalDet.Visible = true;
            ddlMesFinalDet.Enabled = true;
            lblLeyTotal_Destino.Visible = true;
            lblFormatoTotal_Destino.Visible = true;
            
            lblLeyTotal_Origen.Text = "TOTAL ORIGEN";
            
            //validadorTipo.ValidationGroup = "GpoCodProg";
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
                    
                    lblMesFinalDet.Visible = false;
                    ddlMesFinalDet.Visible = false;
                    ddlMesFinalDet.Enabled = false;
                    ddlMesInicialDet.Visible = true;
                    lblMesInicialDet.Visible = true;
                    lblMesInicialDet.Text = "Mes";

                    if (ddlDepen.SelectedValue != "81101")
                    {
                        rbtOrigen_Destino.SelectedValue = "O";
                        rbtOrigen_Destino.Enabled = false;
                    }
                    else
                    {
                        ddlMesInicialDet.SelectedValue = "12";
                        ddlMesFinalDet.SelectedValue = "12";
                        ddlMesFinalDet.Enabled = false;

                        ddlMesInicialDet.Visible = false;
                        lblMesInicialDet.Visible = false;
                        rbtOrigen_Destino.SelectedValue = "D";
                        rbtOrigen_Destino.Enabled = false;
                    }
                }
                else if (ddlTipoEnc.SelectedValue == "AC" || ddlTipoEnc.SelectedValue == "AP")
                {
                    lblMesInicialDet.Text = "Mes";
                    lblMesFinalDet.Visible = false;
                    ddlMesFinalDet.Visible = false;

                    rbtOrigen_Destino.Enabled = true;
                    rbtOrigen_Destino.SelectedValue = "O";
                if (SesionUsu.Usu_TipoUsu == "A" || SesionUsu.Usu_TipoUsu == "SA")
                {
                        string DepOriginal = ddlDepen.SelectedValue;
                        ddlDepen.SelectedValue = "81101";
                        ddlDepen.Items.RemoveAt(ddlDepen.SelectedIndex);
                        ddlDepen.SelectedValue = DepOriginal;
                        ddlDepen.SelectedIndex = 0;
                    
                }


            }
            
            
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
                txtAutorizacion.Text = "AUTORIZÓ " +SesionUsu.Usu_Nombre + " EL DÍA "+DateTime.Now.ToString("dd/MM/yyyy");
            }
            else if (Status == "R")
            {
                lblAutorizacion.Visible = false;
                txtAutorizacion.Visible = false;
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
                if(lblStatusEnc.Text=="Autorizado")
                    Celdas = new Int32[] { 2, 3, 4, 8, 9, 10 ,14};
                 else
                    Celdas = new Int32[] { 2, 3, 4, 8, 9, 10 };
                if (grdDetalles.Rows.Count > 0)
                {
                    lblFF.Text = grdDetalles.Rows[0].Cells[4].Text.Substring(25,5);
                    ddlMesInicialDet.SelectedValue= grdDetalles.Rows[0].Cells[6].Text.PadLeft(2,'0');
                    ddlTipoEnc.Enabled = false;
                    //if(SesionUsu.Usu_TipoUsu=="SA" || SesionUsu.Usu_TipoUsu == "A")
                    //    ddlFuente_F.Enabled = true;
                    //else
                    ddlFuente_F.Enabled = false;
                    if(ddlTipoEnc.SelectedValue=="AP")
                      ddlMesInicialDet.Enabled = false;
                    CNComun.HideColumns(grdDetalles, Celdas);
                }
                else
                {
                    ddlTipoEnc.Enabled = true;
                    ddlFuente_F.Enabled = true;
                    ddlMesInicialDet.Enabled = true;
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
                    Celdas = new Int32[] { 0, 0 };//10 para ocultar ELIMINAR
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
            objDocumento.Dependencia = lblDependenciaDocumento.Text;
            objDocumento.Folio = txtfolio.Text;
            objDocumento.SuperTipo = "A";
            objDocumento.Tipo = ddlTipoEnc.SelectedValue;
            objDocumento.Fecha = txtfechaDocumento.Text;
            string fech = txtfechaDocumento.Text;
            objDocumento.MesAnio = fech.Substring(3, 2) + SesionUsu.Usu_Ejercicio.Substring(2, 2);
            objDocumento.TipoCaptura = "M";
            objDocumento.Status = ddlStatusEnc.SelectedValue;
            objDocumento.Descripcion = txtConcepto.Text;
            objDocumento.MotivoRechazo = txtCancelacion.Text;
            objDocumento.MotivoAutorizacion = txtAutorizacion.Text;
            objDocumento.Seguimiento = txtSeguimiento.Text;
            objDocumento.Cuenta = "00000";
            objDocumento.NumeroCheque = "00000";
            objDocumento.Contabilizar = "S";
           
                objDocumento.CedulaDevengado = "";
                objDocumento.CedulaEjercido = "";
                objDocumento.CedulaPagado = "";
                objDocumento.CedulaComprometido = txtfolio.Text;// si es simultaneo folio y si no segun el tipo y los demas null
            
            objDocumento.KeyPoliza811 = "";
            objDocumento.Ejercicios = SesionUsu.Usu_Ejercicio;
            objDocumento.Regulariza = "N"; //rbtmovimiento.SelectedValue;
            objDocumento.Fecha_Final = "";
            objDocumento.GeneracionSimultanea = "N";
            objDocumento.Usuario = SesionUsu.Usu_Nombre;

            objDocumento.PolizaComprometida = "";
            objDocumento.PolizaDevengado = "";
            objDocumento.PolizaEjercido = "";
            objDocumento.PolizaPagado = "";
            objDocumento.ClaveCuenta = "00";
            objDocumento.ClaveEvento = "00";
            objDocumento.KeyDocumento = "";
            objDocumento.KeyPoliza = "";
            objDocumento.Importe_Operacion = Convert.ToDouble("0.00");
            objDocumento.Importe_Cheque = Convert.ToDouble("0.00");
            objDocumento.ISR = Convert.ToDouble("0.00");

            bool ImporteAutorizado = true;
            if (objDocumento.Status == "A")
                    if (lblFormatoTotal_Origen.Text != lblFormatoTotal_Destino.Text)
                        ImporteAutorizado = false;

            if (SesionUsu.Editar == 0 )
            {
                if (ImporteAutorizado)
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
                    VerificadorInserta = "Para cambiar el estatus a AUTORIZADO, el importe origen y destino deben ser iguales.";
            }
            else
            {
               
               

                if (ImporteAutorizado)
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
            lblDisponible.Text = "0.00";
            //lblFormatoDisponible.Text = "0.00";
            lblFormatoDisponible.Text = string.Format("{0:c}", "0");
            //lblDisponible.Visible = false;
            lblLeyDisponible.Visible = false;
            lblFormatoDisponible.Visible = false;

            try
            {
                if (rbtOrigen_Destino.SelectedValue == "O")
                {
                    
                    lblLeyDisponible.Visible = true;
                    lblFormatoDisponible.Visible = true;

                    objDocumentoDet.Id_Codigo_Prog = Convert.ToInt32(ddlCodigoProg.SelectedValue);
                    objDocumentoDet.Tipo = ddlTipoEnc.SelectedValue;
                    objDocumentoDet.SuperTipo = "A";
                    objDocumentoDet.Mes_inicial = Convert.ToInt32(ddlMesInicialDet.SelectedValue);
                    objDocumentoDet.Ejercicios = SesionUsu.Usu_Ejercicio;

                    CNDocDet.ObtDisponibleCodigoProg(objDocumentoDet, ref Verificador);
                    if (Verificador == "0")
                    {
                      
                        lblDisponible.Text = Convert.ToString(objDocumentoDet.Importe_disponible);
                        lblFormatoDisponible.Text = string.Format("{0:c}", Convert.ToDouble(objDocumentoDet.Importe_disponible));
                    }
                }
                //else
                    
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

                if (SesionUsu.Usu_TipoUsu == "SA")
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
            lblError.Text = string.Empty;
            validadorStatus.ValidationGroup = "Guardar";
            string Status = string.Empty;
            
            string strEstatus = string.Empty;
            try
            {
                bool Editable = false;
                objDocumento.Id =Convert.ToInt32(grdDocumentos.SelectedRow.Cells[0].Text);
                strEstatus = grdDocumentos.SelectedRow.Cells[5].Text;

                switch (SesionUsu.Usu_TipoUsu)
                {
                    case "SA":
                        Editable = true;
                        break;
                    case "A":
                        if (strEstatus == "Tr&#225;mite" || strEstatus == "Inicial" || strEstatus == "Rechazado")
                            Editable = true;
                        break;
                    case "N":
                        if (strEstatus == "Inicial" || strEstatus == "Rechazado" )
                            Editable = true;
                        break;
                }
               
                if (Editable)
                    CNDocumentos.ConsultarDocumentoSel(ref objDocumento, ref Verificador);
                else
                    //lblError.Text = "No tiene los permisos necesarios para editar este documento.";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'No tiene los permisos necesarios para editar este documento.');", true);
                if (Verificador == "0")
                {
                    ddlDepen.SelectedValue = ddlCentroContable.SelectedValue;
                    Session["DocDet"] = null;
                    grdDetalles.DataSource = null;
                    grdDetalles.DataBind();


                    /*Inicializa controles para editar*/
                    SesionUsu.Editar = 1;
                        CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Status_Usuario", ref ddlStatusEnc, "p_tipo_usuario", "p_supertipo", SesionUsu.Usu_TipoUsu, "A");

                    ddlCentroContable.Enabled = false;
                    ddlStatusEnc.Enabled = true;
                    ddlTipoEnc.Enabled = false;
                    
                    ddlCentroContable.SelectedValue = objDocumento.CentroContable;
                    lblDependenciaDocumento.Text = objDocumento.Dependencia;
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
                        lblStatusEnc.Visible = false;
                        StatusEnc(Status);
                        //ddlStatusEnc.Visible = (Status == "A") ? false:true;
                        
                    }
                    else
                    {
                        //ddlStatusEnc.SelectedValue = objDocumento.Status;
                        //ddlStatusEnc_SelectedIndexChanged(null, null);
                        //ddlStatusEnc.Visible = true;
                    }
                    //Repetido, estaba en el ELSE
                    ddlStatusEnc.SelectedValue = objDocumento.Status;
                    ddlStatusEnc_SelectedIndexChanged(null, null);
                    ddlStatusEnc.Visible = true;


                    txtConcepto.Text = objDocumento.Descripcion;
                    txtCancelacion.Text = objDocumento.MotivoRechazo;
                    txtAutorizacion.Text = objDocumento.MotivoAutorizacion;
                    txtSeguimiento.Text = objDocumento.Seguimiento;
                    

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
                    ddlFuente_F.SelectedValue = lblFF.Text;
                    SesionUsu.Editar = 1;


                    MultiView1.ActiveViewIndex = 1;
                    TabContainer1.ActiveTabIndex = 0;
                }
            }
            catch (Exception ex)
            {
                //lblError.Text = ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Error:"+ex.Message+"');", true);
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
            lblErrorDet.Text = string.Empty;
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
            bool PaginaValida = true;

            try
            {
                if (ddlStatusEnc.SelectedValue=="R")
                    Page.Validate("Rechazado");
                

                PaginaValida = Page.IsValid;

                if (PaginaValida)
                {
                    if (grdDetalles.Rows.Count > 0)
                    {
                        guarda_encabezado(ref VerificadorInserta, ref Folio);
                        if (VerificadorInserta == "0")
                           {
                            SesionUsu.Editar = 0;
                            MultiView1.ActiveViewIndex = 0;
                            ddlStatus.SelectedValue = ddlStatusEnc.SelectedValue;
                            CargarGrid(ref grdDocumentos, 0);
                            //lblError.Text = (Folio == string.Empty) ? "Los datos han sido modificados correctamente." : "Los datos han sido agregados correctamente, con el número de folio:" + Folio;
                            string MiMensaje= (Folio == string.Empty) ? "Los datos han sido modificados correctamente." : "Los datos han sido agregados correctamente, con el número de folio:" + Folio;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 1, 'Error:"+MiMensaje+"');", true);
                            ddlCentroContable.Enabled = true;
                            }
                        else
                             lblErrorDet.Text = VerificadorInserta;
                             //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Error: " + VerificadorInserta + "');", true);


                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'No se han agregado códigos programáticos.');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                //lblErrorDet.Text = ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Error: " + ex.Message + "');", true);
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
                if (lblFF.Text == string.Empty)
                    ddlFuente_F.SelectedIndex = 0;
                else
                    ddlFuente_F.SelectedValue = lblFF.Text;

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
            bool MesPermitido = false;
            lblMsjCP.Text = string.Empty;
            ddlMesFinalDet.SelectedValue = ddlMesInicialDet.SelectedValue;
            if (txtImporteOrigen.Text != string.Empty)
                txtImporteDestino_TextChanged(null, null);
            if (ddlTipoEnc.SelectedValue == "AC" || ddlTipoEnc.SelectedValue == "AP")
            {
                int MesActual = System.DateTime.Now.Month;
                int MesSeleccionado = Convert.ToInt32(ddlMesInicialDet.SelectedValue);
               
                if (ddlTipoEnc.SelectedValue == "AP")
                {
                    if (MesSeleccionado <= MesActual)
                        MesPermitido = true;
                    else
                        //lblMsjCP.Text = "En un traspaso no se puede elegir un mes posterior al mes actual.";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'En un traspaso no se puede elegir un mes posterior al mes actual.');", true);
                }
                else if (ddlTipoEnc.SelectedValue == "AC")
                {
                    if (MesSeleccionado >= MesActual)
                        MesPermitido = true;
                    else
                        //lblMsjCP.Text = "En una recalendarización no se puede elegir un mes anterior al mes actual.";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'En una recalendarización no se puede elegir un mes anterior al mes actual.');", true);
                }
                
            }
            else if (ddlTipoEnc.SelectedValue == "AR")
                MesPermitido = true;
            if (MesPermitido)
                disponible();
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
            ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-DOCUMENTOS&SuperTipo=" + SesionUsu.Usu_Rep + "&Dependencia=" + ddlCentroContable.SelectedValue + "&TipoDoc=" + ddlTipo.SelectedValue + "&Status=" + ddlStatus.SelectedValue + "&MesIni=" + ddlMesIni.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&MesFin=" + ddlMesFin.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&Ejercicio=" + SesionUsu.Usu_Ejercicio;
            string _open1 = "window.open('" + ruta1 + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }
        protected void imgBttnPDF_Lotes_Click(object sender, ImageClickEventArgs e)
        {
            string ruta1 = string.Empty;
            
                    ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-LoteA&Dependencia=" + ddlCentroContable.SelectedValue + "&TipoDoc=" + ddlTipo.SelectedValue + "&Status=" + ddlStatus.SelectedValue + "&MesIni=" + ddlMesIni.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&MesFin=" + ddlMesFin.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&Ejercicio=" +SesionUsu.Usu_Ejercicio;
                    

            string _open1 = "window.open('" + ruta1 + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }
       
        protected void btnAgregarDet_Click(object sender, EventArgs e)
        {
            lblErrorDet.Text = string.Empty;
            lblMsjCP.Text = string.Empty;
            bool ImportePermitido = false;
            string Alerta = string.Empty;
            //bool MesPermitido = false;

            if (Convert.ToDouble(txtImporteOrigen.Text)>0.00 && txtImporteOrigen.Text!=string.Empty && txtImporteOrigen.Text!=null)
            {
                if (ddlTipoEnc.SelectedValue == "AR")
                {
                    if (Math.Abs(Convert.ToDouble(txtImporteOrigen.Text)) <= Convert.ToDouble(lblDisponible.Text))
                        ImportePermitido = true;
                    else
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'El importe debe ser menor o igual al disponible.');", true);
                }
                else
                {
                    if (rbtOrigen_Destino.SelectedValue == "O")
                    {
                        if (Math.Abs(Convert.ToDouble(txtImporteOrigen.Text)) < Convert.ToDouble(lblDisponible.Text))
                            ImportePermitido = true;
                        else
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'El importe debe ser menor al disponible.');", true);
                    }
                    else
                    {
                        if (rbtOrigen_Destino.SelectedValue == "D")
                        {
                            if (Math.Abs(Convert.ToDouble(txtImporteOrigen.Text)) > 0)
                                ImportePermitido = true;
                            else
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'El importe no está permitido.');", true);
                        }
                        else
                            ImportePermitido = true;
                    }
                }
                //switch (ddlTipoEnc.SelectedValue)
                //{
                //    case "AA":
                //        if (SesionUsu.Usu_TipoUsu != "N" && Convert.ToDouble(txtImporteOrigen.Text) >= Convert.ToDouble(lblDisponible.Text))
                //            lblMsjCP.Text = "*El importe debe ser menor al disponible.";
                //        else
                //            ImportePermitido = true;
                //        break;
                //    case "AR":
                //        if (Convert.ToDouble(txtImporteOrigen.Text) >= Convert.ToDouble(lblDisponible.Text))
                //            lblMsjCP.Text = "*El importe debe ser menor al disponible.";
                //        else
                //            ImportePermitido = true;
                //        break;
                //    default:

                //        if (Convert.ToDouble(txtImporteOrigen.Text) >= Convert.ToDouble(lblDisponible.Text))
                //            lblMsjCP.Text = "*El importe debe ser menor al disponible.";
                //        else
                //            ImportePermitido = true;
                //        break;
                //}
            }

            //int MesActual = System.DateTime.Now.Month;
            //int MesSeleccionado = Convert.ToInt32(ddlMesInicialDet.SelectedValue);
            //if (ddlTipoEnc.SelectedValue == "AP")
            //{
            //    if (MesSeleccionado < MesActual)
            //        MesPermitido = true;
            //}
            //else if (ddlTipoEnc.SelectedValue == "AC")
            //{
            //    if (MesSeleccionado > MesActual)
            //        MesPermitido = true;
            //}

            //else
            //    MesPermitido = true;
            if (ImportePermitido )//&& MesPermitido)
            {
                var content = new List<Pres_Documento_Detalle>();
                if (Session["DocDet"] != null )
                {
                    string MesIni = Convert.ToString(Convert.ToInt32(ddlMesInicialDet.SelectedValue));
                    
                    List<Pres_Documento_Detalle> ListDocDetBusca = new List<Pres_Documento_Detalle>();
                    ListDocDetBusca = (List<Pres_Documento_Detalle>)Session["DocDet"];
                    if (ddlTipoEnc.SelectedValue == "AP")
                    {
                        var filteredCodigosProg = from c in ListDocDetBusca //Anteriormente ListDocDet
                                                  where Convert.ToString(c.Id_Codigo_Prog) == ddlCodigoProg.SelectedValue//txtSearch.Text

                                                  select c;

                        content = filteredCodigosProg.ToList<Pres_Documento_Detalle>();

                        Alerta = "El código programático ya está capturado.";
                    }
                    else
                    {
                        var filteredCodigosProg = from c in ListDocDetBusca //Anteriormente ListDocDet
                                                  where c.Mes_inicial.ToString() == MesIni && c.Tipo == rbtOrigen_Destino.SelectedValue
                                                  && Convert.ToString(c.Id_Codigo_Prog) == ddlCodigoProg.SelectedValue//txtSearch.Text

                                                  select c;

                        content = filteredCodigosProg.ToList<Pres_Documento_Detalle>();
                        Alerta = "El mes ya se encuentra asignado.";
                    }
                }
                if (content.Count == 0)
                {
                    objDocumentoDet.Id_Codigo_Prog = Convert.ToInt32(ddlCodigoProg.SelectedValue);
                    objDocumentoDet.Desc_Codigo_Prog = ddlCodigoProg.SelectedItem.Text.Substring(0, 34);
                    objDocumentoDet.Ur_clave = ddlDepen.SelectedValue;
                    if (ddlDepen.SelectedValue != "81101")
                        lblDependenciaDocumento.Text = ddlDepen.SelectedValue;
                    objDocumentoDet.Tipo = rbtOrigen_Destino.SelectedValue;
                    //objDocumentoDet.Mes_inicial = Convert.ToInt32(ddlMesInicialDet.SelectedValue);
                    //if(ddlTipoEnc.SelectedValue=="AA" || ddlTipoEnc.SelectedValue=="AR")
                    //    objDocumentoDet.Mes_final = Convert.ToInt32(ddlMesFinalDet.SelectedValue);
                    //else
                    //objDocumentoDet.Mes_final = Convert.ToInt32(ddlMesInicialDet.SelectedValue);
                    objDocumentoDet.Cuenta_banco = "00000";
                    //objDocumentoDet.Desc_Partida = ListPartida[ddlCodigoProg.SelectedIndex].EtiquetaCuatro;

                    objDocumentoDet.Mes_inicial = (ddlDepen.SelectedValue == "81101") ? 12 : Convert.ToInt32(ddlMesInicialDet.SelectedValue);
                    objDocumentoDet.Mes_final = (ddlDepen.SelectedValue == "81101") ? 12 : Convert.ToInt32(ddlMesFinalDet.SelectedValue);
                    //int tot = (Convert.ToInt32(ddlMesFinalDet.SelectedValue) - Convert.ToInt32(ddlMesInicialDet.SelectedValue)) + 1;
                    int tot = (objDocumentoDet.Mes_final - objDocumentoDet.Mes_inicial) + 1;
                    objDocumentoDet.Importe_mensual = Math.Round(Convert.ToDouble((Convert.ToDecimal(txtImporteOrigen.Text)) / tot), 2);
                    objDocumentoDet.Importe_origen = objDocumentoDet.Importe_mensual * tot;
                    objDocumentoDet.Importe_destino = 0;
                    objDocumentoDet.Concepto = string.Empty;
                    objDocumentoDet.TipoDocReferencia = string.Empty;
                    objDocumentoDet.Referencia = string.Empty;
                    objDocumentoDet.Beneficiario_tipo ="X";
                    objDocumentoDet.Beneficiario_nombre = string.Empty;
                    objDocumentoDet.Beneficiario_clave = string.Empty;
                   
                    if (rbtOrigen_Destino.SelectedValue == "D")
                    {
                        objDocumentoDet.Importe_origen = 0;
                        objDocumentoDet.Importe_destino = objDocumentoDet.Importe_mensual * tot;
                    }

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
                    txtImporteOrigen.Text = "0.00";
                    //ddlTipoEnc.Enabled = false;
                    //ddlFuente_F.Enabled = false;
                }
                else
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '"+Alerta+"');", true);

            }
            else
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'El importe no está permitido.');", true);
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
            DDLCentroContable_SelectedIndexChanged(null,null);
            //ValidacionTipoDet();
        }
        protected void ddlTipoEnc_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDLCentroContable_SelectedIndexChanged(null, null);
           
        }
        protected void DDLCentroContable_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            try
            {
                
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref ddlDepen, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, ddlCentroContable.SelectedValue);
                ddlDepen_SelectedIndexChanged(null, null);
                
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
            ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-DOCUMENTOS_XLS&SuperTipo=" + SesionUsu.Usu_Rep + "&Dependencia=" + ddlCentroContable.SelectedValue + "&TipoDoc=" + ddlTipo.SelectedValue + "&Status=" + ddlStatus.SelectedValue + "&MesIni=" + ddlMesIni.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&MesFin=" + ddlMesFin.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&Ejercicio=" + SesionUsu.Usu_Ejercicio;
            string _open1 = "window.open('" + ruta1 + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }
        #endregion

       
    }
}