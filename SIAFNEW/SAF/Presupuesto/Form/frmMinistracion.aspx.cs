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
    public partial class frmMinistracion : System.Web.UI.Page
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
                inicializar();              
            }
            


        }
        #region <Funciones y Sub>
        private void inicializar()
        {
            lblError.Text = string.Empty;
            try
            {
                SesionUsu.Usu_Rep = "M";
                string Permisos= Request.QueryString["P_REP"];
                if (Permisos == "D8P1P1-01")
                    btnNuevo.Visible = true; 
                else
                    btnNuevo.Visible = false;

                Celdas = new Int32[] { 0, 8, 9 };
                MultiView1.ActiveViewIndex = 0;
                TabContainer1.ActiveTabIndex = 0;
                DateTime fechaIni = Convert.ToDateTime("01/01/" + SesionUsu.Usu_Ejercicio);
                DateTime fechaFin = Convert.ToDateTime("31/12/" + SesionUsu.Usu_Ejercicio);
                CalendarExtenderIni.StartDate = fechaIni;
                CalendarExtenderIni.EndDate = fechaFin;
               
                cargarcombos();
                rbtOrigen_Destino.SelectedValue = "O";
                rbtOrigen_Destino.Visible = false;
                validadorTipo.Enabled = false;
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
            txtfechaDocumento.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            txtFolio.Text = string.Empty;
            txtCuenta.Text = string.Empty;
            txtConcepto.Text = string.Empty;
            txtAutorizacion.Text = string.Empty;
            txtCancelacion.Text = string.Empty;
            ddlTipoEnc.SelectedIndex = 0;
            ddlStatusEnc.Visible = true;
            ddlStatusEnc.SelectedValue = "I";
            lblStatusEnc.Visible = false;
            lblMsjCP.Text = string.Empty;
            ddlStatusEnc_SelectedIndexChanged(null, null);
         
            /*Controles Detalle*/
            DateTime fecha = Convert.ToDateTime(txtfechaDocumento.Text);
            string MesFecha = fecha.ToString("MM");
            ddlMesInicialDet.SelectedValue = MesFecha;
            validadorStatus.ValidationGroup = "Guardar";
            ddlStatusEnc.Enabled = false;
            lblDisponible.Text = "0";
            lblDisponible.Text = "0";
            lblTotal_Origen.Text = "0";
            lblFormatoDisponible.Text = "0";
            lblFormatoTotal_Origen.Text = "0";
            txtImporteOrigen.Text = "0";            

            ddlMesFin.SelectedValue = System.DateTime.Now.ToString("MM");
            grdDetalles.DataSource = null;
            grdDetalles.DataBind();
            lblError.Text = string.Empty;
            btnGuardar.Visible = true;
        }
       
        
        private void cargarcombos()
        {
            try
            {
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Capitulo", ref ddlCapitulo, "p_nivel", "1");
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Centro_Contable", ref ddlCentroContable, "p_usuario", "p_ejercicio", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio,ref ListDependencia);
                DDLCentroContable_SelectedIndexChanged(null, null);
                ddlDepen_SelectedIndexChanged(null, null);
                CNComun.LlenaCombo("PKG_CONTABILIDAD.Obt_Combo_Cheque_Cuenta", ref DDLCta_Banco, "p_ejercicio", "p_centro_contable", SesionUsu.Usu_Ejercicio, ddlCentroContable.SelectedValue);
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Status_Usuario", ref ddlStatus, "p_usuario", "p_supertipo", "USUARIO_NO_ESPECIFICADO", "M");
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Status_Usuario", ref ddlStatusEnc, "p_usuario", "p_supertipo", "USUARIO_NO_ESPECIFICADO", "M");
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Tipo_Documento", ref ddlTipo, "p_supertipo", SesionUsu.Usu_Rep );
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Tipo_Documento", ref ddlTipoEnc, "p_supertipo", SesionUsu.Usu_Rep);
                ddlTipoEnc.Items.RemoveAt(0);
                ddlTipoEnc.Items.Insert(0, new ListItem("--ELEGIR TIPO--", "0"));
                if(DDLCta_Banco.Items.Count>=1)
                    DDLCta_Banco.Items.RemoveAt(0);
                
                DDLCta_Banco.Items.Insert(0, new ListItem("--OTRA CUENTA BANCO--", "0"));
              
                    DDLCta_Banco_SelectedIndexChanged(null, null);

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
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
                Celdas = new Int32[] { 3,4,7 };
                       
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
            decimal Origen = 0;
           
            Origen = grdView.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[7].Text));
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
                string Permisos = Request.QueryString["P_REP"];
                if (Permisos=="D8P1P1-01")
                    Celdas = new Int32[] { 0,0,0 };
                else
                    Celdas = new Int32[] { 0,8,9 };

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
            objDocumento.Folio = txtFolio.Text;
            objDocumento.SuperTipo = SesionUsu.Usu_Rep;
            objDocumento.Fecha = txtfechaDocumento.Text;
            string fech = txtfechaDocumento.Text;
            objDocumento.MesAnio = fech.Substring(3, 2) + SesionUsu.Usu_Ejercicio.Substring(2, 2);
            objDocumento.TipoCaptura = "M";
            objDocumento.Status = ddlStatusEnc.SelectedValue;
            objDocumento.Descripcion = txtConcepto.Text;
            objDocumento.MotivoRechazo = txtCancelacion.Text;
            objDocumento.MotivoAutorizacion = txtAutorizacion.Text;
            objDocumento.Cuenta = (DDLCta_Banco.SelectedValue == "0") ? txtCuenta.Text : DDLCta_Banco.SelectedValue;
            objDocumento.NumeroCheque = "00000";
            objDocumento.Contabilizar = "S";
           
            objDocumento.KeyPoliza811 = "";
            objDocumento.Ejercicios = SesionUsu.Usu_Ejercicio;
            objDocumento.Regulariza = "N"; //rbtmovimiento.SelectedValue;
            objDocumento.Fecha_Final = "";
            objDocumento.Usuario = SesionUsu.Usu_Nombre;

            objDocumento.PolizaComprometida = "";
            objDocumento.PolizaDevengado = "";
            objDocumento.PolizaEjercido = "";
            objDocumento.PolizaPagado = "";
            objDocumento.ClaveCuenta = "";
            objDocumento.ClaveEvento = "00";
            objDocumento.GeneracionSimultanea = "N";
            objDocumento.KeyDocumento = "";
            objDocumento.KeyPoliza = "";

            objDocumento.CedulaDevengado = "";
            objDocumento.CedulaEjercido = "";
            objDocumento.CedulaPagado = "";
            objDocumento.CedulaComprometido = txtFolio.Text;
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
                    CNDocumentos.EditarDocumentoEncabezado(objDocumento, ref Verificador);
                    if (Verificador == "0")
                    {
                        VerificadorDet = string.Empty;
                        GuardarDetalle(ref VerificadorDet, Convert.ToInt32(grdDocumentos.SelectedRow.Cells[0].Text));
                        if (VerificadorDet == "0")
                        {
                            VerificadorInserta = "0";
                        }
                        else
                            VerificadorInserta = VerificadorDet;
                    }
                    else
                        VerificadorInserta = Verificador;
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
            lblDisponible.Text = string.Empty;
            try
            {
                objDocumentoDet.Id_Codigo_Prog = Convert.ToInt32(ddlCodigoProg.SelectedValue);
                objDocumentoDet.Desc_Codigo_Prog =ddlCodigoProg.SelectedItem.ToString();
                    objDocumentoDet.Tipo ="M";
                    objDocumentoDet.Mes_inicial =Convert.ToInt32(txtfechaDocumento.Text.Substring(3,2));
               
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
            ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-001&id=" + grdDocumentos.SelectedRow.Cells[0].Text;
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
            ddlCentroContable.Enabled = false;
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
                    CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Status_Usuario", ref ddlStatusEnc, "p_usuario", "p_supertipo", "USUARIO_NO_ESPECIFICADO", "M");
                    //lblMesIni.Visible = false;
                    //lblMesFin.Visible = false;
                    //ddlMesFin.Visible = false;
                    //ddlMesIni.Visible = false;                    
                    ddlStatusEnc.Enabled = true;
                    ddlTipoEnc.Enabled = false;
                    ddlCentroContable.SelectedValue = objDocumento.Dependencia;
                    ddlDepen.SelectedValue = objDocumento.Dependencia;
                    ddlDepen_SelectedIndexChanged(null, null);
                    lblFolio.Visible = true;
                    txtFolio.Visible = true;
                    txtFolio.Text = objDocumento.Folio;
                    ddlTipoEnc.SelectedValue = objDocumento.Tipo;
                    txtfechaDocumento.Text = objDocumento.Fecha;
                    Status= objDocumento.Status;
                    if (Status == "A" )
                    {
                        validadorStatus.ValidationGroup = string.Empty;
                        lblStatusEnc.Text = "Autorizado";                                                
                        StatusEnc(Status);
                        ddlStatusEnc.Visible = (Status == "A") ? false:true;
                        btnGuardar.Visible = false;
                    }
                    else
                    {
                        btnGuardar.Visible = true;
                        ddlStatusEnc.SelectedValue = objDocumento.Status;
                        ddlStatusEnc_SelectedIndexChanged(null, null);
                        ddlStatusEnc.Visible = true;
                    }
                    txtConcepto.Text = objDocumento.Descripcion;
                    txtCancelacion.Text = objDocumento.MotivoRechazo;
                    txtAutorizacion.Text = objDocumento.MotivoAutorizacion;
                    DDLCta_Banco.SelectedValue = objDocumento.Cuenta;
                    /*Llena Grid Detalle*/
                    ddlMesInicialDet.SelectedValue = "01";
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
        
        protected void ddlDepen_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            Listcodigo.Clear();
            Session["Cod_Prog"] = null;
            try
            {
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
            if (txtImporteOrigen.Text == string.Empty)
                txtImporteOrigen.Text = "0";
        }
       
        
        
        protected void ddlFecha_Ini_SelectedIndexChanged(object sender, EventArgs e)
        {

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
           
                    ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-LoteM&Dependencia=" + ddlCentroContable.SelectedValue + "&TipoDoc=" + ddlTipo.SelectedValue + "&Status=" + ddlStatus.SelectedValue + "&MesIni=" + ddlMesIni.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&MesFin=" + ddlMesFin.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2);
            string _open1 = "window.open('" + ruta1 + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }
        
        protected void DDLCta_Banco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLCta_Banco.SelectedValue == "00000")
                txtCuenta.Visible = true;
            else
                txtCuenta.Visible = false;
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
            else if (ddlTipoEnc.SelectedValue == "AA" && Convert.ToDouble(txtImporteOrigen.Text) >= Convert.ToDouble(lblDisponible.Text))
                lblMsjCP.Text = lblMsjCP.Text + "*El importe debe ser menor al disponible.";
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
                    objDocumentoDet.Cuenta_banco = (SesionUsu.Usu_Rep == "M") ? (DDLCta_Banco.SelectedValue == "0") ? txtCuenta.Text : DDLCta_Banco.SelectedValue : "";
                    objDocumentoDet.Desc_Partida = ListPartida[ddlCodigoProg.SelectedIndex].EtiquetaCuatro;
                    objDocumentoDet.Importe_origen = Convert.ToDouble(txtImporteOrigen.Text);
                    objDocumentoDet.Importe_destino = 0;
                    objDocumentoDet.Importe_mensual = Convert.ToDouble(txtImporteOrigen.Text);
                    objDocumentoDet.Mes_final = Convert.ToInt32(ddlMesInicialDet.SelectedValue);
                    
                  


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
        }
        protected void DDLCentroContable_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencia_x_Centro", ref ddlDepen, "p_centro_contable", "p_usuario", ddlCentroContable.SelectedValue, SesionUsu.Usu_Nombre);
            ddlDepen_SelectedIndexChanged(null, null);
            try
            {
                    string MesAbierto = ListDependencia[ddlCentroContable.SelectedIndex].EtiquetaDos.PadLeft(2, '0');
                    DateTime fechaIni = Convert.ToDateTime("01/" + MesAbierto + "/" + SesionUsu.Usu_Ejercicio);
                    DateTime fechaFin = Convert.ToDateTime("31/12/" + SesionUsu.Usu_Ejercicio);
                    CalendarExtenderIni.StartDate = fechaIni;
                    CalendarExtenderIni.EndDate = fechaFin;
                    CNComun.LlenaCombo("PKG_CONTABILIDAD.Obt_Combo_Cheque_Cuenta", ref DDLCta_Banco, "p_ejercicio", "p_centro_contable", SesionUsu.Usu_Ejercicio, ddlCentroContable.SelectedValue);
                    
                
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