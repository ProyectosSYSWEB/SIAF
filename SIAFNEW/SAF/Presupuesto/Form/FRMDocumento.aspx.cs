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
    public partial class FRMDocumento : System.Web.UI.Page
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
        int guar_continue;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                //SesionUsu.Editar = -1;
                inicializar();              

            }
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "PRUEBA", "Autocomplete();", true);


        }
        private void inicializar()
        {
            lblError.Text = string.Empty;
            try
            {
                SesionUsu.Usu_Rep = Request.QueryString["P_REP"];
                MultiView1.ActiveViewIndex = 0;
                TabContainer1.ActiveTabIndex = 0;
                DateTime fechaIni = Convert.ToDateTime("01/01/" + SesionUsu.Usu_Ejercicio);
                DateTime fechaFin = Convert.ToDateTime("31/12/" + SesionUsu.Usu_Ejercicio);
                CalendarExtenderIni.StartDate = fechaIni;
                CalendarExtenderIni.EndDate = fechaFin;
                CalendarExtenderFin.StartDate = fechaIni;
                CalendarExtenderFin.EndDate = fechaFin;
                ValidacionTipoEnc();
                cargarcombos();
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
            txtcuenta.Text = string.Empty;
            txtNumero_Cheque.Text = string.Empty;
            ddlevento.SelectedIndex = 0;
            txtFechaFin.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            txtConcepto.Text = string.Empty;
            txtAutorizacion.Text = string.Empty;
            txtCancelacion.Text = string.Empty;
            ddlTipoEnc.SelectedIndex = 0;
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
            ddlDepen.SelectedValue = ddlDependencia.SelectedValue;
            ddlDepen_SelectedIndexChanged(null, null);
            validadorStatus.ValidationGroup = "Guardar";
            ddlStatusEnc.Enabled = false;
            lblDisponible.Text = "0";
            lblDisponible.Text = "0";
            lblTotal_Origen.Text = "0";
            lblTotal_Destino.Text = "0";
            lblFormatoDisponible.Text = "0";
            lblFormatoTotal_Origen.Text = "0";
            lblFormatoTotal_Destino.Text = "0";
            txtImporteOrigen.Text = "0";            
            txtCta_Banco.Text = string.Empty;
            ValidacionTipoEnc();
            ddlMesFin.SelectedValue = System.DateTime.Now.ToString("MM");
            grdDetalles.DataSource = null;
            grdDetalles.DataBind();
        }
        private void ValidacionTipoEnc()
        {

            switch (SesionUsu.Usu_Rep)
            {
                case "A":
                    txtdocumento.Text = "Adecuación";
                    lblMesInicialDet.Text = "Mes:";
                    lblMesFinalDet.Visible = false;
                    ddlMesFinalDet.Visible = false;
                    ocultar();
                    break;
                case "C":
                    txtdocumento.Text = "Cedula";        
                    lbldoc_simultaneo.Visible = true;
                    rbtdoc_simultaneo.Visible = true;
                    lblFechaFin.Visible = true;
                    txtFechaFin.Visible = true;
                    imgCalendarioFin.Visible = true;                    
                    lblcuenta.Visible = true;
                    DDLCta_Banco0.Visible = true;
                    DDLCta_Banco0_SelectedIndexChanged(null, null);
                    break;
                case "M":
                    txtdocumento.Text = "Ministración";
                    CNComun.LlenaCombo("PKG_CONTABILIDAD.Obt_Combo_Cheque_Cuenta", ref DDLCta_Banco, "p_ejercicio", "p_centro_contable", SesionUsu.Usu_Ejercicio, ddlDepen.SelectedValue);
                    DDLCta_Banco0.Visible = true;
                    lblcuenta.Visible = true;
                    DDLCta_Banco.Visible = true;
                    txtCta_Banco.Visible = true;
                    lblCta_Banco.Visible = true;
                    ocultar();
                    break;
            }

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
            lblNumero_Cheque.Visible = false;
            lblevento.Visible = false;
            txtNumero_Cheque.Visible = false;
            ddlevento.Visible = false;   
        }
        private void cargarcombos()
        {
            try
            {
                
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Eventos", ref ddlevento);
                CNComun.LlenaCombo("PKG_CONTABILIDAD.Obt_Combo_Cheque_Cuenta", ref DDLCta_Banco0, "p_ejercicio", "p_centro_contable", SesionUsu.Usu_Ejercicio, ddlDepen.SelectedValue);
                
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Status_Todos", ref ddlStatus);
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Status_Usuario", ref ddlStatusEnc, "p_usuario", "p_editar", SesionUsu.Usu_Nombre, "N");
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Tipo_Documento", ref ddlTipo, "p_supertipo", SesionUsu.Usu_Rep );
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Tipo_Documento", ref ddlTipoEnc, "p_supertipo", SesionUsu.Usu_Rep);
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref ddlDependencia, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, SesionUsu.Usu_Rep, ref ListDependencia);
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref ddlDepen, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, SesionUsu.Usu_Rep);
                ddlTipoEnc.Items.RemoveAt(0);
                ddlTipoEnc.Items.Insert(0, new ListItem("--ELEGIR TIPO--", "0"));
                if(DDLCta_Banco0.Items.Count>=1)
                    DDLCta_Banco0.Items.RemoveAt(0);
                if (DDLCta_Banco.Items.Count>= 1)
                    DDLCta_Banco.Items.RemoveAt(0);
                DDLCta_Banco0.Items.Insert(0, new ListItem("--OTRA CUENTA BANCO--", "0"));
                if (SesionUsu.Usu_Rep == "M")                
                    DDLCta_Banco0_SelectedIndexChanged(null, null);
                DDLCta_Banco.Items.Insert(0, new ListItem("--OTRA CUENTA BANCO--", "0"));
                if (SesionUsu.Usu_Rep == "M")                
                    DDLCta_Banco_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }
        private void ValidacionTipoDet()
        {
            rbtdoc_simultaneo.SelectedValue = "N";
            rbtdoc_simultaneo.Visible = false;
            lbldoc_simultaneo.Visible = false;

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
                else if (ddlTipoEnc.SelectedValue == "AC")
                {

                    if (ddlDepen.SelectedValue != "81101")
                    {
                        rbtOrigen_Destino.SelectedValue = null;
                    }
                }
            }
            else if (SesionUsu.Usu_Rep == "C")
            {
                rbtOrigen_Destino.Visible = false;
                validadorTipo.ValidationGroup = string.Empty;
                rbtdoc_simultaneo.SelectedValue = "S";
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
                //grvPolizas_Detalle.DataBind();
                Celdas = new Int32[] { 3, 4, 9, 10  };
                if (grdDetalles.Rows.Count > 0)
                    CNComun.HideColumns(grdDetalles, Celdas);
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


        protected void LinkBEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void LinkBImprimir_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdDocumentos.SelectedIndex = row.RowIndex;
            string ruta1=string.Empty;
            switch (SesionUsu.Usu_Rep)
            {
                case "M":
                    ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-001&id=" + grdDocumentos.SelectedRow.Cells[0].Text;
                    break;
                case "C":
                    ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-002&id=" + grdDocumentos.SelectedRow.Cells[0].Text;
                    break;
                case "A":
                    ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-003&id=" + grdDocumentos.SelectedRow.Cells[0].Text;
                    break;
            }

            string _open1 = "window.open('" + ruta1 + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }

        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            SesionUsu.Editar = 0;
            MultiView1.ActiveViewIndex = 1;
            TabContainer1.ActiveTabIndex = 0;
            //TabContainer1.Tabs[1].Enabled = false;
            //valTipo.ValidationGroup = "Nuevo";
            //valFecha.ValidationGroup = "Nuevo";
            //valFolio.ValidationGroup = "Nuevo";
            //valConcepto.ValidationGroup = "Nuevo";
            Session["DocDet"] = null;
            LimpiarControles();
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
                Celdas = new Int32[] {  };
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

        private List<Pres_Documento> GetList(int IdGrid)
        {
            try
            {
                List<Pres_Documento> List = new List<Pres_Documento>();
                objDocumento.Usuario= SesionUsu.Usu_Nombre;
                objDocumento.Dependencia = ddlDependencia.SelectedValue;
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

        protected void BTNbuscar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CargarGrid(ref grdDocumentos , 0);
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
            try
            {
                objDocumento.Id =Convert.ToInt32(grdDocumentos.SelectedRow.Cells[0].Text);
                CNDocumentos.ConsultarDocumentoSel(ref objDocumento, ref Verificador);
                if (Verificador == "0")
                {
                    ddlDepen.SelectedValue = ddlDependencia.SelectedValue;
                    Session["DocDet"] = null;
                    grdDetalles.DataSource = null;
                    grdDetalles.DataBind();


                    /*Inicializa controles para editar*/
                    SesionUsu.Editar = 1;
                    CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Status_Usuario", ref ddlStatusEnc, "p_usuario", "p_editar", SesionUsu.Usu_Nombre, "S");
                    //lblMesIni.Visible = false;
                    //lblMesFin.Visible = false;
                    //ddlMesFin.Visible = false;
                    //ddlMesIni.Visible = false;                    
                    ddlStatusEnc.Enabled = true;
                    //ddlTipo.Enabled = true;
                    ddlDependencia.SelectedValue = objDocumento.Dependencia;
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
                    txtNumero_Cheque.Text = objDocumento.NumeroCheque;
                    txtcuenta.Text = objDocumento.Cuenta;
                    ddlevento.SelectedValue = objDocumento.ClaveEvento;
                    //rbtmovimiento.SelectedValue = objDocumento.Regulariza;
                    txtFechaFin.Text = objDocumento.Fecha_Final;
                    rbtdoc_simultaneo.SelectedValue = objDocumento.GeneracionSimultanea;
                    //rdoBttnContabilizar.SelectedValue = objDocumento.Contabilizar;

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

        protected void ddlDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SesionUsu.Usu_Rep == "M" || SesionUsu.Usu_Rep == "C")
            {
                string MesAbierto = ListDependencia[ddlDependencia.SelectedIndex].EtiquetaCuatro.PadLeft(2, '0');

                DateTime fechaIni = Convert.ToDateTime("01/" + MesAbierto + "/" + SesionUsu.Usu_Ejercicio);
                DateTime fechaFin = Convert.ToDateTime("31/12/" + SesionUsu.Usu_Ejercicio);
                CalendarExtenderIni.StartDate = fechaIni;
                CalendarExtenderIni.EndDate = fechaFin;
                CalendarExtenderFin.StartDate = fechaIni;
                CalendarExtenderFin.EndDate = fechaFin;
                if(SesionUsu.Usu_Rep == "C")
                    CNComun.LlenaCombo("PKG_CONTABILIDAD.Obt_Combo_Cheque_Cuenta", ref DDLCta_Banco0, "p_ejercicio", "p_centro_contable", SesionUsu.Usu_Ejercicio, ddlDependencia.SelectedValue);
            }
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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
                                case 1:
                                    objDocumento.Tipo = "CD";
                                    guarda_encabezado(ref VerificadorInserta, ref Folio);
                                    if (VerificadorInserta != "0")
                                        i = 4;
                                    break;
                                case 2:
                                    objDocumento.Tipo = "CE";
                                    guarda_encabezado(ref VerificadorInserta, ref Folio);
                                    if (VerificadorInserta != "0")
                                        i = 4;
                                    break;
                                case 3:
                                    objDocumento.Tipo = "CP";
                                    guarda_encabezado(ref VerificadorInserta, ref Folio);
                                    if (VerificadorInserta != "0")
                                        i = 4;
                                    break;
                            }
                        }

                        if (VerificadorInserta != "0")                        
                            lblErrorDet.Text = VerificadorInserta;
                        
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
                            lblError.Text = "Los datos han sido agregados correctamente.";
                        }
                    }
                    else
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
                            //lblMesIni.Visible = true;
                            //ddlMesIni.Visible = true;
                            //lblMesFin.Visible = true;
                            //ddlMesFin.Visible = true;
                            lblError.Text =(Folio==string.Empty)?"Los datos han sido modificados correctamente." :"Los datos han sido agregados correctamente, con el Número de Folio:" + Folio;

                        }
                    }
                }
                else
                {
                    lblErrorDet.Text = "Se deben agregar al menos un detalle.";
                } 
            }
            catch (Exception ex)
            {
                lblErrorDet.Text = ex.Message;
            }
        }
        private void guarda_encabezado(ref string VerificadorInserta, ref string Folio)
        {
            Verificador=string.Empty;
            objDocumento.CentroContable = "";
            objDocumento.Dependencia = ddlDependencia.SelectedValue;
            objDocumento.Folio = txtfolio.Text ;
            objDocumento.SuperTipo = SesionUsu.Usu_Rep;           
            objDocumento.Fecha = txtfechaDocumento.Text;
            string fech = txtfechaDocumento.Text;
            objDocumento.MesAnio = fech.Substring(3,2)+ SesionUsu.Usu_Ejercicio.Substring(2,2) ;
            objDocumento.TipoCaptura = "M";
            objDocumento.Status = ddlStatusEnc.SelectedValue;
            objDocumento.Descripcion = txtConcepto.Text;
            objDocumento.MotivoRechazo = txtCancelacion.Text;
            objDocumento.MotivoAutorizacion = txtAutorizacion.Text;
            objDocumento.Cuenta = (DDLCta_Banco0.SelectedValue=="0")?txtcuenta.Text: DDLCta_Banco0.SelectedValue;
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
            objDocumento.Fecha_Final = (SesionUsu.Usu_Rep=="C")?txtFechaFin.Text:"" ;
            objDocumento.GeneracionSimultanea = rbtdoc_simultaneo.SelectedValue;
            objDocumento.Usuario = SesionUsu.Usu_Nombre;            

            objDocumento.PolizaComprometida = "";
            objDocumento.PolizaDevengado="";
            objDocumento.PolizaEjercido = "";
            objDocumento.PolizaPagado = "";
            objDocumento.ClaveCuenta ="" ;
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
                objDocumento.Id =Convert.ToInt32(grdDocumentos.SelectedRow.Cells[0].Text);
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

        }
        protected void btnGuardar2_Click(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {

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
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Codigos_Progr", ref ddlCodigoProg, "p_ejercicio", "p_dependencia", SesionUsu.Usu_Ejercicio, ddlDepen.SelectedValue, ref ListPartida);
                LstCodigoProg_SelectedIndexChanged(null, null);
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

        protected void btnDisponible_Click(object sender, EventArgs e)
        {
            objDocumentoDet.Id_Codigo_Prog =Convert.ToInt32(ddlCodigoProg.SelectedValue);
            CNDocDet.ObtDisponibleCodigoProg(objDocumentoDet, ref Verificador);
            if (Verificador == "0")
            {
                lblDisponible.Text = Convert.ToString(objDocumentoDet.Importe_disponible);
                lblFormatoDisponible.Text =string.Format("{0:c}",Convert.ToDouble(objDocumentoDet.Importe_disponible));


            }
        }

        protected void grdDetalles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdDetalles_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdDetalles.EditIndex = e.NewEditIndex;
            List<Pres_Documento_Detalle> ListDocDet = new List<Pres_Documento_Detalle>();
            ListDocDet = (List<Pres_Documento_Detalle>)Session["DocDet"];
            Session["DocDet"] = ListDocDet;
            CargarGridDetalle(ListDocDet);

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

        protected void grdDetalles_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            List<Pres_Documento_Detalle> ListDocDet = new List<Pres_Documento_Detalle>();
            ListDocDet = (List<Pres_Documento_Detalle>)Session["DocDet"];
            grdDetalles.EditIndex = -1;
            CargarGridDetalle(ListDocDet);
        }

        protected void txtImporteOrigen_TextChanged(object sender, EventArgs e)
        {
            if (txtImporteOrigen.Text == string.Empty)
                txtImporteOrigen.Text = "0";

            //Valida_Origen_Destino();
        }

        protected void ddlFecha_Ini_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        }

        protected void imgBttnPDF_Lotes_Click(object sender, ImageClickEventArgs e)
        {
            string ruta1 = string.Empty;
            switch (SesionUsu.Usu_Rep)
            {
                case "M":
                    ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-lote1&SuperTipo=" + SesionUsu.Usu_Rep + "&Dependencia=" + ddlDependencia.SelectedValue + "&TipoDoc=" + ddlTipo.SelectedValue + "&Status=" + ddlStatus.SelectedValue + "&MesIni=" + ddlMesIni.SelectedValue + "&MesFin=" + ddlMesFin.SelectedValue;
                    break;
                case "C":
                    ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-lote2&SuperTipo=" + SesionUsu.Usu_Rep + "&Dependencia=" + ddlDependencia.SelectedValue + "&TipoDoc=" + ddlTipo.SelectedValue + "&Status=" + ddlStatus.SelectedValue + "&MesIni=" + ddlMesIni.SelectedValue + "&MesFin=" + ddlMesFin.SelectedValue;
                    break;
                case "A":
                    ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-lote3&SuperTipo=" + SesionUsu.Usu_Rep + "&Dependencia=" + ddlDependencia.SelectedValue + "&TipoDoc=" + ddlTipo.SelectedValue + "&Status=" + ddlStatus.SelectedValue + "&MesIni=" + ddlMesIni.SelectedValue + "&MesFin=" + ddlMesFin.SelectedValue;
                    break;
            }

            string _open1 = "window.open('" + ruta1 + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }

        protected void DDLCta_Banco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DDLCta_Banco.SelectedValue=="0")
                txtCta_Banco.Visible = true;
        }

        protected void DDLCta_Banco0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLCta_Banco0.SelectedValue == "00000")
                txtcuenta.Visible = true;
            else
                txtcuenta.Visible = false;
        }

        protected void btnAgregarDet_Click(object sender, EventArgs e)
        {
            lblErrorDet.Text = string.Empty;
            lblMsjCP.Text = string.Empty;
            if (ddlTipoEnc.SelectedValue == "0")
                lblMsjCP.Text = "*Tipo requerido.<br>";
            else if (ddlTipoEnc.SelectedValue != "AA" && Convert.ToDouble(lblDisponible.Text) == 0) // && Convert.ToDouble(txtImporteOrigen.Text) > Convert.ToDouble(lblDisponible.Text))
                lblMsjCP.Text = lblMsjCP.Text + "*No hay saldo disponible.";
            else if (ddlTipoEnc.SelectedValue != "AA" && Convert.ToDouble(txtImporteOrigen.Text) > Convert.ToDouble(lblDisponible.Text))
                lblMsjCP.Text = lblMsjCP.Text + "*El importe debe ser menor o igual al disponible.";
            else if (txtImporteOrigen.Text == "0")
                lblMsjCP.Text = lblMsjCP.Text + "*Agregar importe.";
            else
            {
                var content = new List<Pres_Documento_Detalle>();
                if (Session["DocDet"] != null)
                {
                    string MesIni = Convert.ToString(Convert.ToInt32(ddlMesInicialDet.SelectedValue));
                    List<Pres_Documento_Detalle> ListDocDetBusca = new List<Pres_Documento_Detalle>();
                    ListDocDetBusca = (List<Pres_Documento_Detalle>)Session["DocDet"];
                    var filteredCodigosProg = from c in ListDocDet
                                              where c.Mes_inicial.ToString() == MesIni && c.Tipo == rbtOrigen_Destino.SelectedValue //txtSearch.Text
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
                    objDocumentoDet.Cuenta_banco = (SesionUsu.Usu_Rep == "M") ? (DDLCta_Banco.SelectedValue == "0") ? txtCta_Banco.Text : DDLCta_Banco.SelectedValue : "";
                    objDocumentoDet.Desc_Partida = ListPartida[ddlCodigoProg.SelectedIndex].EtiquetaCuatro;
                    objDocumentoDet.Importe_origen = Convert.ToDouble(txtImporteOrigen.Text);
                    objDocumentoDet.Importe_destino = 0;
                    objDocumentoDet.Importe_mensual = Convert.ToDouble(txtImporteOrigen.Text);
                    objDocumentoDet.Mes_final = Convert.ToInt32(ddlMesInicialDet.SelectedValue);
                    
                    if(SesionUsu.Usu_Rep=="A")
                    {                        
                        if (rbtOrigen_Destino.SelectedValue == "D")
                        {
                            objDocumentoDet.Importe_origen = 0;
                            objDocumentoDet.Importe_destino = Convert.ToDouble(txtImporteOrigen.Text);
                        }
                        objDocumentoDet.Mes_inicial = (ddlDepen.SelectedValue == "81101") ? 12 : Convert.ToInt32(ddlMesInicialDet.SelectedValue);
                        objDocumentoDet.Mes_final = (ddlDepen.SelectedValue == "81101") ? 12 : Convert.ToInt32(ddlMesFinalDet.SelectedValue);
                        int tot = (Convert.ToInt32(ddlMesFinalDet.SelectedValue) - Convert.ToInt32(ddlMesInicialDet.SelectedValue)) + 1;
                        objDocumentoDet.Importe_mensual = Convert.ToDouble((Convert.ToDouble(txtImporteOrigen.Text)) / tot);
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
                }
                else
                    lblMsjCP.Text = "El Mes ya se encuentra asignado.";
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
            }
        }
    }
}