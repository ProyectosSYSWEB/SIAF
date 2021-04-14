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
        //Pres_Documento objDocumento = new Pres_Documento();
        //Pres_Documento_Detalle objDocumentoDet = new Pres_Documento_Detalle();
        private static List<Comun> ListConceptos = new List<Comun>();
        private static List<Pres_Documento_Detalle> ListDocDet = new List<Pres_Documento_Detalle>();
        private static List<Comun> Listcodigo = new List<Comun>(); //En tu declaración de variables
        private static List<Comun> ListDependencia = new List<Comun>();
        private static List<Comun> ListPartida = new List<Comun>();
        //int guar_continue;

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
            try
            {
                //DateTime fechaIni = Convert.ToDateTime("01/" + ListDependencia[ddlCentroContable.SelectedIndex].EtiquetaDos + "/" + SesionUsu.Usu_Ejercicio);
                //DateTime fechaFin = Convert.ToDateTime("01/" + ListDependencia[ddlCentroContable.SelectedIndex].EtiquetaDos + "/" + SesionUsu.Usu_Ejercicio);
                //fechaFin = fechaFin.AddMonths(1).AddDays(-1);
                //CalendarExtenderIni.StartDate = fechaIni;
                //CalendarExtenderIni.EndDate = fechaFin;
                ////txtfechaDocumento.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                //txtfechaDocumento.Text = fechaIni.ToString("dd/MM/yyyy");
                txtFolio.Text = string.Empty;
                txtCuenta.Text = string.Empty;
                txtConcepto.Text = string.Empty;
                txtAutorizacion.Text = string.Empty;
                txtCancelacion.Text = string.Empty;
                txtSeguimiento.Text = string.Empty;
                ddlFuente_F.Enabled = true;

                if (ddlTipo.SelectedValue != "T")
                    ddlTipoEnc.SelectedValue = ddlTipo.SelectedValue;
                else
                    ddlTipoEnc.SelectedIndex = 0;
                ddlTipoEnc_SelectedIndexChanged(null, null);
                
                ddlStatusEnc.Visible = true;
                ddlStatusEnc.Enabled = true;
                ddlStatusEnc_SelectedIndexChanged(null, null);
                //ddlStatusEnc.SelectedValue = "I";
                lblStatusEnc.Visible = false;
                lblMsjCP.Text = string.Empty;
                

                /*Controles Detalle*/
                DateTime fecha = Convert.ToDateTime(txtfechaDocumento.Text);
                string MesFecha = fecha.ToString("MM");
                ddlMesInicialDet.SelectedValue = MesFecha;
                ddlMesInicialDet.Enabled = true;

                validadorStatus.ValidationGroup = "Guardar";
                lblDisponible.Text = "0.00";
                lblDisponible.Text = "0.00";
                lblTotal_Origen.Text = "0.00";
                lblFormatoDisponible.Text = "0.00";
                lblFormatoTotal_Origen.Text = "0.00";
                txtImporteOrigen.Text = "0.00";

                ddlMesFin.SelectedValue = System.DateTime.Now.ToString("MM");
                grdDetalles.DataSource = null;
                grdDetalles.DataBind();
                lblError.Text = string.Empty;
                btnGuardar.Visible = true;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
       
        
        private void cargarcombos()
        {
            try
            {
                
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref ddlCentroContable, "p_usuario", "p_ejercicio", "p_supertipo",SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio,"M",ref ListDependencia);
                DDLCentroContable_SelectedIndexChanged(null, null);
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Status_Todos", ref ddlStatus);
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Status_Usuario", ref ddlStatusEnc, "p_tipo_usuario", "p_supertipo", SesionUsu.Usu_TipoUsu, "M");
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Tipo_Documento", ref ddlTipo, "p_supertipo", "M" );
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Tipo_Documento", ref ddlTipoEnc, "p_supertipo", "M");
                ddlTipoEnc.Items.RemoveAt(0);
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
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref ddlDepen, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, ddlCentroContable.SelectedValue);
                if (SesionUsu.Usu_TipoUsu == "A" || SesionUsu.Usu_TipoUsu == "SA")
                {
                    string DepOriginal = ddlDepen.SelectedValue;
                    ddlDepen.SelectedValue = "81101";
                    ddlDepen.Items.RemoveAt(ddlDepen.SelectedIndex);
                    ddlDepen.SelectedValue = DepOriginal;
                    ddlDepen.SelectedIndex = 0;
                }
                    CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Capitulo", ref ddlCapitulo, "p_nivel", "1");
                CNComun.LlenaCombo("PKG_PRESUPUESTO.Obt_Combo_Fuente_F", ref ddlFuente_F, "p_ejercicio", "p_dependencia", SesionUsu.Usu_Ejercicio, ddlDepen.SelectedValue);
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Codigos_Progr", ref ddlCodigoProg, "p_ejercicio", "p_dependencia", "p_capitulo", "p_fuente", SesionUsu.Usu_Ejercicio, ddlDepen.SelectedValue, ddlCapitulo.SelectedValue.Substring(0, 1), ddlFuente_F.SelectedValue, ref ListPartida);
                CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Cheque_Cuenta", ref DDLCta_Banco, "p_ejercicio", "p_centro_contable", SesionUsu.Usu_Ejercicio, ddlCentroContable.SelectedValue);
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
                Celdas = new Int32[] { 3,4,7,9 };
                       
                if (grdDetalles.Rows.Count > 0)
                {
                    ddlTipoEnc.Enabled = false;
                    ddlFuente_F.Enabled = false;
                    ddlMesInicialDet.Enabled = false;
                    ddlDepen.Enabled = false;
                    if (ddlTipoEnc.SelectedValue == "MN" && SesionUsu.Editar==0)
                    {

                        Celdas = new Int32[] { 3, 3, 4, 7 };
                    }
                    //if (Convert.ToString(grdDocumentos.SelectedRow.Cells[8].Text) == "Editar" || Convert.ToString(grdDocumentos.SelectedRow.Cells[8].Text) == "Ver")
                    //    ddlFuente_F.SelectedValue = ListDocDet.ElementAt(0).Desc_Codigo_Prog.Substring(25, 5);
                    lblFF.Text = grdDetalles.Rows[0].Cells[4].Text.Substring(25, 5);
                }
                else
                {
                    ddlTipoEnc.Enabled = true;
                    ddlFuente_F.Enabled = true;
                    ddlMesInicialDet.Enabled = true;
                    ddlDepen.Enabled = true;
                    lblFF.Text = string.Empty;
                }
                    CNComun.HideColumns(grdDetalles, Celdas);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        private void CargarGridDetalle_Ordinaria()
        {
            lblError.Text = string.Empty;
          
            try
            {
                DataTable dt = new DataTable();
                grdDetalles.DataSource = dt;
                grdDetalles.DataSource = GetList_Ordinaria();
                grdDetalles.DataBind();
                Sumatoria(grdDetalles);
                Celdas = new Int32[] { 3, 4, 7 };

                if (grdDetalles.Rows.Count > 0)
                {
                    ddlTipoEnc.Enabled = false;
                    ddlFuente_F.Enabled = false;
                    ddlMesInicialDet.Enabled = false;
                    ddlDepen.Enabled = false;
                    CNComun.HideColumns(grdDetalles, Celdas);
                }
                else
                {
                    ddlTipoEnc.Enabled = true;
                    ddlFuente_F.Enabled = true;
                    ddlMesInicialDet.Enabled = true;
                    ddlDepen.Enabled = true;
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

                if (SesionUsu.Usu_TipoUsu== "N" )
                    Celdas = new Int32[] { 0, 8, 9,10 };
                else
                    Celdas = new Int32[] { 0, 8 };

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
                objDocumento.Dependencia = ddlDepen.SelectedValue;
                objDocumento.Folio = txtFolio.Text;
                objDocumento.SuperTipo = "M";
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
                objDocumento.ClaveCuenta = DDLCta_Banco.SelectedValue;
                objDocumento.ClaveEvento = "00";
                objDocumento.GeneracionSimultanea = "N";
                objDocumento.KeyDocumento = "";
                objDocumento.KeyPoliza = "";
                objDocumento.Importe_Operacion = Convert.ToDouble("0.00");
                objDocumento.Importe_Cheque = Convert.ToDouble("0.00");
                objDocumento.ISR = Convert.ToDouble("0.00");

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
            catch (Exception ex)
            {

            }

        }
        protected void EditaRegistro(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                List<Pres_Documento_Detalle> ListDocDet = new List<Pres_Documento_Detalle>();
                ListDocDet = (List<Pres_Documento_Detalle>)Session["DocDet"];
                GridViewRow row = grdDetalles.Rows[e.RowIndex];
                ListDocDet[e.RowIndex].Importe_origen = Convert.ToDouble(((TextBox)(row.Cells[7].Controls[0])).Text);
                ListDocDet[e.RowIndex].Importe_destino = 0.00;
                ListDocDet[e.RowIndex].Importe_mensual = Convert.ToDouble(((TextBox)(row.Cells[7].Controls[0])).Text); 
                grdDetalles.EditIndex = -1;
                Session["DocDet"] = ListDocDet;
                CargarGridDetalle(ListDocDet);
            }
            catch (Exception ex)
            {
            }
        }
        private void disponible()
        {
            lblError.Text = string.Empty;
            lblDisponible.Text = "0.00";
            lblFormatoDisponible.Text = "0.00";
            try
            {
                Pres_Documento_Detalle objDocDetalle = new Pres_Documento_Detalle();
                objDocDetalle.Id_Codigo_Prog = Convert.ToInt32(ddlCodigoProg.SelectedValue);
                objDocDetalle.Tipo = ddlTipoEnc.SelectedValue;
                objDocDetalle.SuperTipo = "M";
                objDocDetalle.Mes_inicial = Convert.ToInt32(ddlMesInicialDet.SelectedValue);
                objDocDetalle.Ejercicios = SesionUsu.Usu_Ejercicio;

                CNDocDet.ObtDisponibleCodigoProg(objDocDetalle, ref Verificador);
                if (Verificador == "0")
                {
                    lblDisponible.Text = Convert.ToString(objDocDetalle.Importe_disponible);
                    lblFormatoDisponible.Text = string.Format("{0:c}", Convert.ToDouble(objDocDetalle.Importe_disponible));
                }
            }

            catch (Exception ex)
            {
                
            }
        }
        private List<Pres_Documento> GetList(int IdGrid)
        {
            try
            {
                List<Pres_Documento> List = new List<Pres_Documento>();
                Pres_Documento objDocumento = new Pres_Documento();
                objDocumento.Usuario= SesionUsu.Usu_Nombre;
                objDocumento.Ejercicios = SesionUsu.Usu_Ejercicio;
                objDocumento.Dependencia = ddlCentroContable.SelectedValue;
                objDocumento.Fecha_Inicial = ddlMesIni.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2,2);
                objDocumento.Fecha_Final = ddlMesFin.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2);
                objDocumento.Tipo = ddlTipo.SelectedValue;
                objDocumento.SuperTipo = "M";
                objDocumento.Status = ddlStatus.SelectedValue;
                objDocumento.P_Buscar = txtbuscar.Text;

                if (IdGrid == 0)
                {
                    CNDocumentos.ConsultaGrid_Documentos(ref objDocumento, ref List);
                }
               

                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private List<Pres_Documento_Detalle> GetList_Ordinaria()
        {
            try
            {
                List<Pres_Documento_Detalle> List = new List<Pres_Documento_Detalle>();
                Pres_Documento Datos = new Pres_Documento();

                Datos.Ejercicios = SesionUsu.Usu_Ejercicio;
                Datos.Dependencia = ddlDepen.SelectedValue;
                Datos.Tipo = ("M" != "C") ? rbtOrigen_Destino.SelectedValue : ddlTipoEnc.SelectedValue.Substring(1);
                Datos.Fecha_Inicial = ddlMesInicialDet.SelectedValue;
                Datos.Cuenta = ("M" == "M") ? (DDLCta_Banco.SelectedValue == "0") ? txtCuenta.Text : DDLCta_Banco.SelectedValue : "";
                Datos.P_Buscar = ddlFuente_F.SelectedValue;

                CNDocumentos.ConsultarGrid_CodProg_Ordinaria(ref Datos, ref List);

                Session["DocDet"] = List;
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
        protected void linkBDetalle_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdDocumentos.SelectedIndex = row.RowIndex;
            string ruta1 = string.Empty;
            ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-PRESUP_MIN_DET&id=" + grdDocumentos.SelectedRow.Cells[0].Text;
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
        protected void linkBttnEditar_Click(object sender, EventArgs e)
        {
            Pres_Documento objDocumento = new Pres_Documento();
            Pres_Documento_Detalle objDocumentoDet = new Pres_Documento_Detalle();
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            CargarCombosAdicionales();
            grdDocumentos.SelectedIndex = row.RowIndex;
           
            Verificador = string.Empty;
            lblMsjCP.Text = string.Empty;
            lblStatusEnc.Text = string.Empty;
            validadorStatus.ValidationGroup = "Guardar";
            ddlCentroContable.Enabled = false;
            string Status = string.Empty;

            
                try
                {
                if (Convert.ToString(grdDocumentos.SelectedRow.Cells[8].Text) == "Editar")
                    SesionUsu.Editar = 1;
                else
                    SesionUsu.Editar = 0;


                objDocumento.Id = Convert.ToInt32(grdDocumentos.SelectedRow.Cells[0].Text);
                    CNDocumentos.ConsultarDocumentoSel(ref objDocumento, ref Verificador);
                    if (Verificador == "0")
                    {
                  
                    Session["DocDet"] = null;
                        grdDetalles.DataSource = null;
                        grdDetalles.DataBind();


                        /*Inicializa controles para editar*/
                         ddlStatusEnc.Enabled = true;
                        ddlTipoEnc.Enabled = false;
                        ddlCentroContable.SelectedValue = objDocumento.Dependencia;
                        ddlDepen.SelectedValue = objDocumento.Dependencia;
                       
                        lblFolio.Visible = true;
                        txtFolio.Visible = true;
                        txtFolio.Text = objDocumento.Folio;
                        ddlTipoEnc.SelectedValue = objDocumento.Tipo;
                        ddlTipoEnc_SelectedIndexChanged(null, null);
                   
                        txtfechaDocumento.Text = objDocumento.Fecha;
                        Status = objDocumento.Status;
                        if (Status == "A")
                        {
                            validadorStatus.ValidationGroup = string.Empty;
                            lblStatusEnc.Text = "Autorizado";
                            StatusEnc(Status);
                            ddlStatusEnc.Visible = (Status == "A") ? false : true;
                            btnGuardar.Visible = false;
                            SesionUsu.Editar = 0;
                            if (SesionUsu.Usu_TipoUsu=="SA")
                            {
                                btnGuardar.Visible = true;
                                SesionUsu.Editar = 1;
                                ddlStatusEnc.Visible = true;
                                ddlStatusEnc.SelectedValue = "A";
                                lblStatusEnc.Visible = false ;
                            }
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
                        txtSeguimiento.Text = objDocumento.Seguimiento;
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
                        MultiView1.ActiveViewIndex = 1;
                        TabContainer1.ActiveTabIndex = 0;
                        ddlFuente_F.SelectedValue = lblFF.Text;
                        LstCodigoProg_SelectedIndexChanged(null, null);
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
            Pres_Documento objDocumento = new Pres_Documento();
            lblErrorDet.Text = string.Empty;
            lblMsjCP.Text = string.Empty;
            string VerificadorInserta = string.Empty;
            string Folio = string.Empty;
            try
            {
                if (grdDetalles.Rows.Count > 0)
                {
                   
                       
                            
                            guarda_encabezado(ref VerificadorInserta, ref Folio);
                    if (VerificadorInserta == "0")
                    {
                        SesionUsu.Editar = -1;
                        MultiView1.ActiveViewIndex = 0;
                        ddlStatus.SelectedValue = ddlStatusEnc.SelectedValue;
                        CargarGrid(ref grdDocumentos, 0);
                        //lblError.Text = (Folio == string.Empty) ? "Los datos han sido modificados correctamente." : "Los datos han sido agregados correctamente, con el número de folio:" + Folio;
                        string MiMensaje = (Folio == string.Empty) ? "Los datos han sido modificados correctamente." : "Los datos han sido agregados correctamente, con el número de folio:" + Folio;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 1, '" + MiMensaje + "');", true);
                        ddlCentroContable.Enabled = true;
                    }

                    else
                    {
                        CNComun.VerificaTextoMensajeError(ref VerificadorInserta);
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Error:" + VerificadorInserta + "');", true);
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
        
        
        
        
       
        protected void LstCodigoProg_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblFormatoDisponible.Text = string.Format("{0:c}", "0.00");
            lblDisponible.Text = "0.00"; //string.Empty;
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
            Pres_Documento objDocumento = new Pres_Documento();

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
            ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-DOCUMENTOS&SuperTipo=" + "M" + "&Dependencia=" + ddlCentroContable.SelectedValue + "&TipoDoc=" + ddlTipo.SelectedValue + "&Status=" + ddlStatus.SelectedValue + "&MesIni=" + ddlMesIni.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&MesFin=" + ddlMesFin.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&Ejercicio=" + SesionUsu.Usu_Ejercicio;
            string _open1 = "window.open('" + ruta1 + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }
        protected void imgBttnPDF_Lotes_Click(object sender, ImageClickEventArgs e)
        {
            string ruta1 = string.Empty;
           
                    ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-LoteM&Dependencia=" + ddlCentroContable.SelectedValue + "&TipoDoc=" + ddlTipo.SelectedValue + "&Status=" + ddlStatus.SelectedValue + "&MesIni=" + ddlMesIni.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&MesFin=" + ddlMesFin.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&Ejercicio=" +SesionUsu.Usu_Ejercicio;
            string _open1 = "window.open('" + ruta1 + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }
        
        
        protected void btnAgregarDet_Click(object sender, EventArgs e)
        {
            try
            {
                Pres_Documento_Detalle objDocumentoDet = new Pres_Documento_Detalle();
                if (ddlTipoEnc.SelectedValue == "MN")
                {
                    CargarGridDetalle_Ordinaria();

                }
                else
                {
                    lblErrorDet.Text = string.Empty;
                    lblMsjCP.Text = string.Empty;
                    if (ddlTipoEnc.SelectedValue == "0")
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Seleccione TipoEnc válido.');", true);
                    else if (Convert.ToDouble(txtImporteOrigen.Text) > Convert.ToDouble(lblDisponible.Text))
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'El importe debe ser menor o igual al disponible.');", true);
                    else if (Convert.ToDouble(txtImporteOrigen.Text) == 0)
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'El importe no está permitido.');", true);
                    else
                    {
                        var content = new List<Pres_Documento_Detalle>();
                        if (Session["DocDet"] != null)
                        {
                            string MesIni = Convert.ToString(Convert.ToInt32(ddlMesInicialDet.SelectedValue));
                            List<Pres_Documento_Detalle> ListDocDetBusca = new List<Pres_Documento_Detalle>();
                            ListDocDetBusca = (List<Pres_Documento_Detalle>)Session["DocDet"];
                            var filteredCodigosProg = from c in ListDocDetBusca
                                                      where c.Mes_inicial.ToString() == MesIni && c.Tipo == rbtOrigen_Destino.SelectedValue
                                                      && Convert.ToString(c.Id_Codigo_Prog) == ddlCodigoProg.SelectedValue//txtSearch.Text

                                                      select c;

                            content = filteredCodigosProg.ToList<Pres_Documento_Detalle>();
                        }
                        if (content.Count == 0)
                        {
                            objDocumentoDet.Id_Codigo_Prog = Convert.ToInt32(ddlCodigoProg.SelectedValue);
                            objDocumentoDet.Desc_Codigo_Prog = ddlCodigoProg.SelectedItem.Text;
                            objDocumentoDet.Desc_Partida = ListPartida[ddlCodigoProg.SelectedIndex].EtiquetaCuatro;
                            objDocumentoDet.Ur_clave = ddlDepen.SelectedValue;
                            objDocumentoDet.Tipo = ("M" != "C") ? rbtOrigen_Destino.SelectedValue : ddlTipoEnc.SelectedValue.Substring(1);
                            objDocumentoDet.Mes_inicial = Convert.ToInt32(ddlMesInicialDet.SelectedValue);
                            objDocumentoDet.Cuenta_banco = ("M" == "M") ? (DDLCta_Banco.SelectedValue == "0") ? txtCuenta.Text : DDLCta_Banco.SelectedValue : "";
                            objDocumentoDet.Importe_origen = Math.Abs(Convert.ToDouble(txtImporteOrigen.Text));
                            objDocumentoDet.Importe_destino = 0;

                            //objDocumentoDet.Importe_mensual = Convert.ToDouble(txtImporteOrigen.Text);
                            objDocumentoDet.Importe_mensual = objDocumentoDet.Importe_origen;
                            objDocumentoDet.Mes_final = Convert.ToInt32(ddlMesInicialDet.SelectedValue);
                            objDocumentoDet.Concepto = string.Empty;
                            objDocumentoDet.TipoDocReferencia = string.Empty;
                            objDocumentoDet.Referencia = string.Empty;
                            objDocumentoDet.Beneficiario_tipo = "X";
                            objDocumentoDet.Beneficiario_nombre = string.Empty;
                            objDocumentoDet.Beneficiario_clave = string.Empty;


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
                            //ddlTipoEnc.Enabled = false;
                            txtImporteOrigen.Text = "0.00";
                        }
                        else
                            //lblMsjCP.Text = "El mes ya se encuentra asignado.";
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'El mes ya se encuentra asignado.');", true);
                    }
                }
            }
            catch (Exception ex)
            {

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
            lblError.Text = string.Empty;
            if (SesionUsu.Usu_TipoUsu=="A" || SesionUsu.Usu_TipoUsu == "SA")
            { 
                SesionUsu.Editar = 0;
                MultiView1.ActiveViewIndex = 1;
                TabContainer1.ActiveTabIndex = 0;
                Session["DocDet"] = null;
                ddlCentroContable.Enabled = false;
                ddlDepen.Enabled = true;
                LimpiarControles();
                CargarCombosAdicionales();
            }
            else
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'No tiene los permisos necesarios para crear este tipo de documento.');", true);
        }
        protected void DDLCentroContable_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CNComun.LlenaCombo("pkg_Presupuesto.Obt_Combo_Dependencias", ref ddlDepen, "p_usuario", "p_ejercicio", "p_supertipo", SesionUsu.Usu_Nombre, SesionUsu.Usu_Ejercicio, ddlCentroContable.SelectedValue);
            //CNComun.LlenaCombo("PKG_PRESUPUESTO.Obt_Combo_Fuente_F", ref ddlFuente_F, "p_ejercicio", "p_dependencia", SesionUsu.Usu_Ejercicio, ddlDepen.SelectedValue);
            //if (SesionUsu.Usu_TipoUsu == "A" || SesionUsu.Usu_TipoUsu == "SA")
            //{
            //    string DepOriginal = ddlDepen.SelectedValue;
            //    ddlDepen.SelectedValue = "81101";
            //    ddlDepen.Items.RemoveAt(ddlDepen.SelectedIndex);
            //    ddlDepen.SelectedValue = DepOriginal;
            //    ddlDepen.SelectedIndex = 0;
            //}
           
            try
            {
                    string MesAbierto = ListDependencia[ddlCentroContable.SelectedIndex].EtiquetaDos.PadLeft(2, '0');
                    DateTime fechaIni = Convert.ToDateTime("01/" + MesAbierto + "/" + SesionUsu.Usu_Ejercicio);
                    DateTime fechaFin = Convert.ToDateTime("01/" + MesAbierto + "/" + SesionUsu.Usu_Ejercicio);
                    fechaFin = fechaFin.AddMonths(1).AddDays(-1);
                    CalendarExtenderIni.StartDate = fechaIni;
                    CalendarExtenderIni.EndDate = fechaFin;
                    txtfechaDocumento.Text = fechaIni.ToString("dd/MM/yyyy");
            }
            catch (Exception ex)
            {
                string Msj = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Msj);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '"+Msj+"');", true);
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
        protected void ddlMesInicialDet_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMsjCP.Text = string.Empty;
            lblFormatoDisponible.Text = "$0.00";
            lblDisponible.Text = "0.00";
            disponible();
        }
        protected void ddlTipoEnc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoEnc.SelectedValue == "MN")
            {
                lblCapitulo.Visible = false;
                ddlCapitulo.Visible = false;
                lblCodigoProg.Visible = false;
                ddlCodigoProg.Visible = false;
                lblLeyDisponible.Visible = false;
                lblFormatoDisponible.Visible = false;
                lblImporteOrigen.Visible = false;
                txtImporteOrigen.Visible = false;
            }
            else
            {
                lblCapitulo.Visible = true;
                ddlCapitulo.Visible = true;
                lblCodigoProg.Visible = true;
                ddlCodigoProg.Visible = true;
                lblLeyDisponible.Visible = true;
                lblFormatoDisponible.Visible = true;
                lblImporteOrigen.Visible = true;
                txtImporteOrigen.Visible = true;
                
            }
        }
        protected void imgBttnXLS_Click(object sender, ImageClickEventArgs e)
        {
            string ruta1 = string.Empty;
            ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=RP-DOCUMENTOS_XLS&SuperTipo=" + "M" + "&Dependencia=" + ddlCentroContable.SelectedValue + "&TipoDoc=" + ddlTipo.SelectedValue + "&Status=" + ddlStatus.SelectedValue + "&MesIni=" + ddlMesIni.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&MesFin=" + ddlMesFin.SelectedValue + SesionUsu.Usu_Ejercicio.Substring(2, 2) + "&Ejercicio=" + SesionUsu.Usu_Ejercicio;
            string _open1 = "window.open('" + ruta1 + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }

        #endregion

        
    }
}